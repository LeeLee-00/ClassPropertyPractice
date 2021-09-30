Imports System.Drawing

Public Class Employee
    ' DRAWING SURFACE
    Private G As Graphics
    Private PhotoBox As New Rectangle(5, 5, 150, 200)
    Private InfoBox As New Rectangle(160, 5, 250, 200)

    ' EMPLOYEE PROPERTIES
    Public FirstName As String
    Public LastName As String
    Public Department As String
    Public Notes As String
    Public Status As EmployeeStatus

    'EMPLOYEE PHOOTO
    Public Photo As Image

    Public Enum EmployeeStatus
        Active
        Terminated
    End Enum

    Public Sub New(GFX As Graphics, FName As String, LName As String, Dept As String, EmpNotes As String, EmpStatus As Integer, Optional EmpPhoto As Image = Nothing)
        G = GFX
        FirstName = FName
        LastName = LName
        Department = Dept
        Notes = EmpNotes

        Select Case EmpStatus
            Case 0
                Status = EmployeeStatus.Active
            Case 1
                Status = EmployeeStatus.Terminated
            Case Else
                Status = EmployeeStatus.Active
        End Select
        Photo = EmpPhoto
    End Sub

    Public Sub Draw()
        ' Clear Drawing Surface
        G.Clear(Color.FromName("Control"))

        ' Employee Photo Box
        G.FillRectangle(Brushes.AliceBlue, PhotoBox)
        G.DrawRectangle(Pens.Black, PhotoBox)

        If Photo IsNot Nothing Then
            G.DrawImage(Photo, New Rectangle(PhotoBox.X + 1, PhotoBox.Y + 1, PhotoBox.Width - 1, PhotoBox.Height - 1))
        End If

        'Employee Information
        G.FillRectangle(Brushes.Lavender, InfoBox)
        G.DrawRectangle(Pens.Black, InfoBox)

        G.DrawString("" &
            "Employee Name: " & FirstName & " " & LastName & vbCrLf &
            "Employee Status: " & Status.ToString & vbCrLf &
            "Department: " & Department & vbCrLf &
            "Notes: " & Notes, New Font("Tahoma", 9), Brushes.Black, New Point(InfoBox.X + 5, InfoBox.Y + 5))

    End Sub
End Class
