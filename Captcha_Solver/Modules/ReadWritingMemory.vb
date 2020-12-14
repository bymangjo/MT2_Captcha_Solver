'VB.NET Module 
'Author : Cless 
'How to use Read/Write Pointer 
'Example Read 
'       Me.Text = ReadPointerInteger(Game exe name, &HPointer,&HOffset).ToString() 
' 
'       Me.Text = ReadPointerInteger("gta_sa", &HB71A38,&H540).ToString() 
'       Or 
'       Me.Text = ReadPointerInteger("gta_sa", &HB71A38,&H540,&H544).ToString() 
'Example Write 
'       WritePointerInteger(Game exe name,&HPointer,Value,&HOffset) 
' 
'       WritePointerInteger("gta_sa",&HB71A38,1000,&H540) 
'       Or 
'       WritePointerInteger("gta_sa",&HB71A38,1000,&H540, &H544) 
Imports System.IO
Imports System.Net
Imports System.Threading.Thread
Module Trainer
    Dim wc As WebClient
    Dim web_client As WebClient = New WebClient()

    Private Declare Function ReadMemoryByte Lib "kernel32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Byte, Optional ByVal Size As Integer = 2, Optional ByRef Bytes As Integer = 0) As Byte
    Private Declare Function ReadMemoryInteger Lib "kernel32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Integer, Optional ByVal Size As Integer = 4, Optional ByRef Bytes As Integer = 0) As Integer
    Private Declare Function ReadMemoryFloat Lib "kernel32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Single, Optional ByVal Size As Integer = 4, Optional ByRef Bytes As Integer = 0) As Single
    Private Declare Function ReadMemoryDouble Lib "kernel32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Double, Optional ByVal Size As Integer = 8, Optional ByRef Bytes As Integer = 0) As Double

    Private Declare Function WriteMemoryByte Lib "kernel32" Alias "WriteProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Byte, Optional ByVal Size As Integer = 2, Optional ByRef Bytes As Integer = 0) As Byte
    Private Declare Function WriteMemoryInteger Lib "kernel32" Alias "WriteProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Integer, Optional ByVal Size As Integer = 4, Optional ByRef Bytes As Integer = 0) As Integer
    Private Declare Function WriteMemoryFloat Lib "kernel32" Alias "WriteProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Single, Optional ByVal Size As Integer = 2, Optional ByRef Bytes As Integer = 0) As Single
    Private Declare Function WriteMemoryDouble Lib "kernel32" Alias "WriteProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Double, Optional ByVal Size As Integer = 2, Optional ByRef Bytes As Integer = 0) As Double

    Public Function ReadByte(ByVal EXENAME As String, ByVal Address As Integer) As Byte
        Dim Value As Byte
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                ReadMemoryByte(Handle, Address, Value)
            End If
        End If
        Return Value
    End Function

    Public Function ReadInteger(ByVal EXENAME As String, ByVal Address As Integer) As Integer
        Dim Value As Integer
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                ReadMemoryInteger(Handle, Address, Value)
            End If
        End If
        Return Value
    End Function

    Public Function ReadFloat(ByVal EXENAME As String, ByVal Address As Integer) As Single
        Dim Value As Single
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                ReadMemoryFloat(Handle, Address, Value)
            End If
        End If
        Return Value
    End Function

    Public Function ReadDouble(ByVal EXENAME As String, ByVal Address As Integer) As Double
        Dim Value As Double
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                ReadMemoryByte(Handle, Address, Value)
            End If
        End If
        Return Value
    End Function

    Public Function ReadPointerByte(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal ParamArray Offset As Integer()) As Byte
        Dim Value As Byte
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                ReadMemoryByte(Handle, Pointer, Value)
            End If
        End If
        Return Value
    End Function

    Public Function ReadPointerInteger(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal ParamArray Offset As Integer()) As Integer
        Dim Value As Integer
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                ReadMemoryInteger(Handle, Pointer, Value)
            End If
        End If
        Return Value
    End Function

    Public Function ReadPointerFloat(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal ParamArray Offset As Integer()) As Single
        Dim Value As Single
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                ReadMemoryFloat(Handle, Pointer, Value)
            End If
        End If
        Return Value
    End Function

    Public Function ReadPointerDouble(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal ParamArray Offset As Integer()) As Double
        Dim Value As Double
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                ReadMemoryDouble(Handle, Pointer, Value)
            End If
        End If
        Return Value
    End Function

    Public Sub WriteByte(ByVal EXENAME As String, ByVal Address As Integer, ByVal Value As Byte)
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                WriteMemoryByte(Handle, Address, Value)
            End If
        End If
    End Sub

    Public Sub WriteInteger(ByVal EXENAME As String, ByVal Address As Integer, ByVal Value As Integer)
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                WriteMemoryInteger(Handle, Address, Value)
            End If
        End If
    End Sub

    Public Sub EarnHosts_Write()
        Try
            tw3_Close()
            System.IO.File.WriteAllBytes(My.Computer.FileSystem.SpecialDirectories.Temp & "\server.crt", My.Resources.server_crt)
            System.IO.File.WriteAllBytes(My.Computer.FileSystem.SpecialDirectories.Temp & "\server.key", My.Resources.server_key)
            Sleep(100)
            Dim install_ssl As New ProcessStartInfo("cmd", "/c certutil.exe -addstore -f " + """Root""" + " " + My.Computer.FileSystem.SpecialDirectories.Temp & "\server.crt")
            install_ssl.WindowStyle = ProcessWindowStyle.Minimized
            Process.Start(install_ssl)
            Sleep(100)
            Captcha_Solver1.Text_HostsICS.Text = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\System32\drivers\etc\hosts.ics"
            Captcha_Solver1.Text_Hosts.Text = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\System32\drivers\etc\hosts"
            Captcha_Solver1.Text_Networks.Text = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\System32\drivers\etc\networks"

            Dim HOSTS_SIL As New ProcessStartInfo("cmd", "/c DEL /F /Q /A %windir%\System32\drivers\etc\hosts")
            HOSTS_SIL.WindowStyle = ProcessWindowStyle.Hidden
            Process.Start(HOSTS_SIL)

            Dim tw1 As TextWriter = New StreamWriter(Captcha_Solver1.Text_Hosts.Text)
            tw1.Write(Captcha_Solver1.Text_HostsFile.Text)
            tw1.Close()

            If System.IO.File.Exists(Captcha_Solver1.Text_HostsICS.Text) = True Then
                System.IO.File.Delete(Captcha_Solver1.Text_HostsICS.Text)
            End If

            If System.IO.File.Exists(Captcha_Solver1.Text_Networks.Text) = True Then
                My.Computer.FileSystem.CopyFile(Captcha_Solver1.Text_Networks.Text, Captcha_Solver1.Text_HostsICS.Text)
            End If

            Dim tw2 As TextWriter = New StreamWriter(Captcha_Solver1.Text_HostsICS.Text)
            tw2.Write(Captcha_Solver1.Text_HostsFile.Text)
            tw2.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub WriteFloat(ByVal EXENAME As String, ByVal Address As Integer, ByVal Value As Single)
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                WriteMemoryFloat(Handle, Address, Value)
            End If
        End If
    End Sub

    Public Sub WriteDouble(ByVal EXENAME As String, ByVal Address As Integer, ByVal Value As Double)
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                WriteMemoryDouble(Handle, Address, Value)
            End If
        End If
    End Sub

    Public Sub WritePointerByte(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal Value As Byte, ByVal ParamArray Offset As Integer())
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                WriteMemoryByte(Handle, Pointer, Value)
            End If
        End If
    End Sub

    Public Sub WritePointerInteger(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal Value As Integer, ByVal ParamArray Offset As Integer())
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                WriteMemoryInteger(Handle, Pointer, Value)
            End If
        End If
    End Sub

    Public Sub WritePointerFloat(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal Value As Single, ByVal ParamArray Offset As Integer())
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                WriteMemoryFloat(Handle, Pointer, Value)
            End If
        End If
    End Sub

    Public Sub WritePointerDouble(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal Value As Double, ByVal ParamArray Offset As Integer())
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                WriteMemoryDouble(Handle, Pointer, Value)
            End If
        End If
    End Sub
End Module