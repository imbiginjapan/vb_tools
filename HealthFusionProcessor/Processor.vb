Imports System.AddIn
Imports System.Text

Imports Iatric.EasyConnect.AddIns.Views
Imports System.IO

''' <summary>
''' Class implementing the necessary contract to transform recieved data.
''' </summary>
''' <remarks>
''' 1.  This must be the only Public class in the project.
''' 2.  This class must inherit from AddInBase.
''' 3.  This class must implement ICustomProcessorAddInView interface.
''' </remarks>
<AddIn("AddIn Name", Description:="AddIn Description", Publisher:="AddIn Author")>
Public Class Processor
	Inherits AddInBase
	Implements ICustomProcessorAddInView

#Region "Member Variables"

    ' send vendor-defined provider value as parameter in call
    Private _provider As String


#End Region

#Region "Constructors"

	Public Sub New()

	End Sub

#End Region

#Region "Public Methods"



	Public Function Initialize(debugFilePath As String, parameters As String) As Boolean Implements Iatric.EasyConnect.AddIns.Views.ICustomProcessorAddInView.Initialize
		Dim result As String = Me.InitializeBase(debugFilePath, parameters)

		If String.IsNullOrEmpty(result) Then

			'add code here to set local parameter variables to parameter values passed into the add in
			'for example
            If Me.Parameters.Count > 0 Then
                _provider = Me.Parameters("provider")
            End If

            Return True
        Else
            Me.ErrorMessage = result
            Return False
        End If

        Return True
    End Function

	''' <summary>
	''' Process the given data and write the result to disk.
	''' </summary>
	''' <param name="data">Data to process.</param>
	''' <param name="tempFilePath">Complete path and file name where the file needs to be written.</param>
	''' <returns>The status of the data, such as success, filter, or error.  In the case of an error, Me.ErrorMessage should contain a description of the error.</returns>
	Public Function ProcessData(data() As Byte, tempFilePath As String) As Iatric.EasyConnect.AddIns.Views.DataStatus Implements Iatric.EasyConnect.AddIns.Views.ICustomProcessorAddInView.ProcessData

		'add code here to transform the message data
		'for example
		'Try
		'	'change the data anyway you like

		'	'if you want to pass the data on to the next processor, write the data to the tempFilePath
		'	File.WriteAllBytes(tempFilePath, data)
        Try
            Dim msg As New HL72Message()
            Dim msg_type As String
            Dim obx As List(Of String)
            Dim data_type As String
            Dim enc As New System.Text.UTF8Encoding()
            Dim messageInput As String
            Dim obx_first_index As Integer

            Dim obx_1 As String
            Dim obx_5 As String
            Dim obr_14 As String
            Dim nte_line As String

            'Get transaction from the engine
            messageInput = enc.GetString(data)
            msg.Load(messageInput)


            ' Set sending application, receiving/ordering provider and Report Time
            msg_type = msg.GetValue("ZRT", 0, 1)

            If msg_type = "RAD" Then
                msg.SetValue("MSH", 0, 2, "RAD")
                If msg.GetValue("OBR", 0, 22).Length > 0 Then
                    ' do nothing, report time already set
                Else
                    ' take OBR-14 (logged time) and place in OBR-22
                    obr_14 = msg.GetValue("OBR", 0, 14)
                    msg.SetValue("OBR", 0, 22, obr_14)
                End If
            Else
                msg.SetValue("MSH", 0, 2, "LAB")

            End If

            msg.SetValue("MSH", 0, 5, _provider)
            msg.SetValue("MSH", 0, 3, "STU")


            ' Set Data type for OBX segments if not already there
            obx = msg.GetSegments("OBX")
            Dim seg_index As Integer = 0
            For Each line As String In obx
                data_type = msg.GetValue("OBX", seg_index, 2)
                If data_type.Length > 0 Then
                    ' do nothing , it's already set
                Else
                    msg.SetValue("OBX", seg_index, 2, "TX")
                End If
                seg_index += 1
            Next line


            ' Move OBX to NTE for RAD results.
            If msg_type = "RAD" Then
                obx = msg.GetSegments("OBX")
                seg_index = 0
                For Each line In obx
                    obx_1 = msg.GetValue("OBX", seg_index, 1)
                    obx_5 = msg.GetValue("OBX", seg_index, 5)
                    nte_line = "NTE|" & obx_1 & "||" & obx_5
                    msg.AppendSegment(nte_line)
                    seg_index += 1
                Next line
                obx_first_index = msg.FirstIndexOfSegment("OBX")
                msg.RemoveAllSegments("OBX")
                msg.InsertSegment(obx_first_index, obx.First)
            End If


            ' File and Send Message
            data = enc.GetBytes(msg.ToString)
            File.WriteAllBytes(tempFilePath, data)

            Return DataStatus.Success

        Catch ex As Exception
            Me.ErrorMessage = ex.ToString()
            Return DataStatus.Error
        End Try

        Me.ErrorMessage = "Not Implemented"
        Return DataStatus.Error
    End Function

	''' <summary>
	''' Shut down any processing mechanisms that were in use.
	''' </summary>
	''' <returns>True if successful, False if an error was encountered.</returns>
	''' <remarks>If an error is encountered, the error should be recorded in Me.ErrorMessage.</remarks>
	Public Function ShutDown() As Boolean Implements Iatric.EasyConnect.AddIns.Views.ICustomProcessorAddInView.ShutDown

		'add code to release any resources that might have been openend

		Return True
	End Function

#End Region

#Region "Public Properties"

	Public Property ErrorMessage As String Implements Iatric.EasyConnect.AddIns.Views.ICustomProcessorAddInView.ErrorMessage

	Public Property FilterMessage As String Implements Iatric.EasyConnect.AddIns.Views.ICustomProcessorAddInView.FilterMessage

#End Region

End Class
