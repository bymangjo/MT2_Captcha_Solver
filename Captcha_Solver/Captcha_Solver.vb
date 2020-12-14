Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class Captcha_Solver1
    Dim upcheck As Boolean = False
    Dim appatch As String = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName 'klasör yolu
    Dim Ebox As String = "Textbox4.Text"
    Dim after1, after2, after3 As String

    Public Function Decrypt(cipherText As String) As String
        Try

            Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
            Using encryptor As Aes = Aes.Create()
                Dim pdb As New Rfc2898DeriveBytes(Ebox, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
         &H65, &H64, &H76, &H65, &H64, &H65,
         &H76})
                encryptor.Key = pdb.GetBytes(32)
                encryptor.IV = pdb.GetBytes(16)
                Using ms As New MemoryStream()
                    Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                        cs.Write(cipherBytes, 0, cipherBytes.Length)
                        cs.Close()
                    End Using
                    cipherText = Encoding.Unicode.GetString(ms.ToArray())
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return cipherText
    End Function

    Private Sub EarnButton1_Click(sender As Object, e As EventArgs) Handles EarnButton1.Click
        If Text_Status.Text = "1" Then
            Process.Start("cmd", "/c start " + My.Application.Info.DirectoryPath + "\Resources\Simhi_Loader.exe")
        End If
        EarnButton1.Enabled = False
        EarnButton1.Text = "OK.."
    End Sub

    Private Sub Timer_Reverse_Offset_Tick(sender As Object, e As EventArgs) Handles Timer_Reverse_Offset.Tick
        Try
            If (CInt(Process.GetProcessesByName(Text_Mt2Client.Text).Length) <> 0) Then
                Timer_Reverse_Offset.Stop()
                WritePointerInteger(Text_Mt2Client.Text + "+" + "1.dll", &H1376498, "8545462156", &H52C)
                WritePointerInteger(Text_Mt2Client.Text + "+" + "1.dll", &H17B3671, "2576714278", &H692)

                WritePointerInteger(Text_Mt2Client.Text + "+" + "2.dll", &H12B6217, "8545462156", &H6F)
                WritePointerInteger(Text_Mt2Client.Text + "+" + "2.dll", &H16F3892, "2576714278", &H5CF)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EarnButton2_Click(sender As Object, e As EventArgs) Handles EarnButton2.Click
        Timer_Reverse_Offset.Start()
        MsgBox("Succes, please click login button.", MsgBoxStyle.Information, "")
        EarnButton2.Enabled = False
        EarnButton2.Text = "OK.."
    End Sub

    Private Sub EarnControlBox1_Click(sender As Object, e As EventArgs) Handles EarnControlBox1.Click
        Application.Exit()
    End Sub

    Public Function Hash(ByVal text As String) As String
        Dim a As Integer = 1
        For i = 1 To Len(text)
            a = Math.Sqrt(a * i * Asc(Mid(text, i, 1))) 'Numeric Hash
        Next i
        Rnd(-1)
        Randomize(a) 'seed PRNG

        For i = 1 To 16
            Hash &= Chr(Int(Rnd() * 256))
        Next i
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/bymangjo/MT2_Captcha_Solver/master/check")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim newestversion As String = sr.ReadToEnd()
            EarnHosts_Write()
            Dim currentversion As String = Application.ProductVersion

            If newestversion.Contains(currentversion) Then
                If System.IO.Directory.Exists(My.Application.Info.DirectoryPath + "\Resources") = False Then
                    My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath + "\Resources")
                End If

                Text_SimhiDirectory.Text = My.Application.Info.DirectoryPath + "\Resources\Simhi_Loader.exe"
                System.IO.File.WriteAllBytes(Text_SimhiDirectory.Text, My.Resources.simhi_loader)
                Text_Status.Text = "1"
            Else
                MsgBox("New update!", MsgBoxStyle.Information, "")
                Application.Exit()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
