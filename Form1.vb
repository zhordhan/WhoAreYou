Imports Microsoft.Win32
Public Class Form1
    Sub DisableTaskMgr()
        Dim regkey As RegistryKey
        Dim keyValueInt As String = "1"
        Dim subKey As String = "Software\Microsoft\Windows\CurrentVersion\Policies\System"
        Try
            regkey = Registry.CurrentUser.CreateSubKey(subKey)
            regkey.SetValue("DisableTaskMgr", keyValueInt)
            regkey.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Registry Error!")
        End Try
    End Sub
    Sub EnableTaskMgr()
        Dim regkey As RegistryKey
        Dim keyValueInt As String = "0x00000000"
        Dim subKey As String = "Software\Microsoft\Windows\CurrentVersion\Policies\System"
        Try
            regkey = Registry.CurrentUser.CreateSubKey(subKey)
            regkey.SetValue("DisableTaskMgr", keyValueInt)
            regkey.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Registry Error!")
        End Try
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisableTaskMgr()
        TxtNamaFile.Visible = False
        TxtText.Visible = False
    End Sub
    Sub Who()

        If TextBox1.Text = TxtText.Text Then
            TextBox2.Text = TextBox1.Text
            EnableTaskMgr()
            Close()

        Else
            MsgBox("GET THE FUCK OUT FROM MY PC!", MsgBoxStyle.Critical, "FUCK YOU")
            TextBox1.Text = ""
            TextBox2.Text = ""
            Shutdown()

        End If

    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If TextBox2.Text = "" Then
            e.Cancel = True
        ElseIf TextBox2.Text = TxtText.Text Then
            e.Cancel = False
        End If
    End Sub
    Sub Shutdown()
        System.Diagnostics.Process.Start("shutdown", "-s -f -t 00")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        baca()
        Who()
    End Sub
    Sub baca()

        Try
            Dim file = TxtNamaFile.Text.ToString
            Using temp As New IO.StreamReader(file.ToString)
                TxtText.Text = temp.ReadLine
            End Using
        Catch ex As Exception
            MsgBox("Nama file tidak ditemukan", MsgBoxStyle.Critical)
        End Try

    End Sub

    
End Class
