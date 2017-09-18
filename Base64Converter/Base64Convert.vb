Public Class Form1

    Private Sub btnDecode_Click(sender As Object, e As EventArgs) Handles btnDecode.Click
        Dim inputText As String = txtBase64.Text
        inputText = inputText.Replace(vbLf, "")
        inputText = inputText.Replace(vbCr, "")
        inputText = inputText.Replace(vbCrLf, "")

        Dim decodedBytes As Byte()
        decodedBytes = Convert.FromBase64String(inputText)

        Dim decodedText As String
        decodedText = System.Text.Encoding.UTF8.GetString(decodedBytes)
        txtASCII.Text = decodedText
    End Sub


    Private Sub btnEncoe_Click(sender As Object, e As EventArgs) Handles btnEncode.Click
        Dim inputText As String = txtBase64.Text
        'inputText = inputText.Replace(vbLf, "")
        'inputText = inputText.Replace(vbCr, "")
        'inputText = inputText.Replace(vbCrLf, "")

        Dim bytesToEncode As Byte()
        bytesToEncode = System.Text.Encoding.UTF8.GetBytes(inputText)

        Dim encodedText As String
        encodedText = Convert.ToBase64String(bytesToEncode)
        txtASCII.Text = encodedText
    End Sub
    

    
End Class
