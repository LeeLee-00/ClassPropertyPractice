Public Class Form1
    Dim MyEmployee As Employee
    Dim PhotoPath As String = ""

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click
        CreateEmployee("Lee", "John", "Administration", "This dude is the best!", 0)
    End Sub

    Private Sub CreateEmployee(Fname As String, LName As String, Dept As String, Notes As String, Status As Integer)
        If MsgBox("Would you like to add a photo?", MsgBoxStyle.YesNo, "Add Photo") = MsgBoxResult.Yes Then
            OFDPhoto.ShowDialog()
        End If

        If PhotoPath = "" Then
            MyEmployee = New Employee(Me.CreateGraphics, Fname, LName, Dept, Notes, Status)
        Else
            Dim oImg As Image = Image.FromFile(PhotoPath)
            MyEmployee = New Employee(Me.CreateGraphics, Fname, LName, Dept, Notes, Status, oImg)
        End If

        If MyEmployee IsNot Nothing Then
            MyEmployee.Draw()
        End If
    End Sub

    Private Sub OFDPhoto_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OFDPhoto.FileOk
        PhotoPath = OFDPhoto.FileName
    End Sub

End Class
