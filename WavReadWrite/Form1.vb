Imports System.IO
Public Class Form1

#Region " Gereneral variables"
    Dim shtDataArray() As Short ''contains data of file
    Dim strHeaderList(12) As String ''contains list of information from header 
    Dim intTemp As Integer = 0  ''tepm variable or loop
    Dim objDt As New DataTable ''hold data in tablur form
    Dim objReadWrite As New WavReaderWriter ''object of calss read and write wav file
#End Region

#Region "Gui Events"
    ''this button will open file dailog and offer to select file from any drive and show its header info in rich text boox
    Private Sub btnOpenWavFile_Click(sender As Object, e As EventArgs) Handles btnOpenWavFile.Click
        WavOpenFileDialog.Filter = "Audio Files(*.wav)|*.wav|All files (*.*)|*.*" 'apply filter for only select wave file
        WavOpenFileDialog.Title = "Please Select An Audio File"
        If WavOpenFileDialog.ShowDialog() = DialogResult.OK Then    ''opening file dailog to select wav Faile
            tbxFileName.Text = WavOpenFileDialog.FileName           ' set file path in textbox
            strHeaderList = objReadWrite.ReadHeader(WavOpenFileDialog.FileName) ' call function of read header and return array of header data
            ''Printing haeder Info in RichTextbox     
            rbxHeaderInfo.AppendText("       Head Chunk           ")
            rbxHeaderInfo.AppendText(Environment.NewLine + " Chunk ID    :" & strHeaderList(0))
            rbxHeaderInfo.AppendText(Environment.NewLine + " Chunk Size  :" & strHeaderList(1))
            rbxHeaderInfo.AppendText(Environment.NewLine + " Chunk Format:" & strHeaderList(2))
            rbxHeaderInfo.AppendText(Environment.NewLine + "       Format Chunk           ")
            rbxHeaderInfo.AppendText(Environment.NewLine + "SubChunk 1 ID   :" & strHeaderList(3))
            rbxHeaderInfo.AppendText(Environment.NewLine + "SubChunk 1 Size :" & strHeaderList(4))
            rbxHeaderInfo.AppendText(Environment.NewLine + "Audio Format    :" & strHeaderList(5))
            rbxHeaderInfo.AppendText(Environment.NewLine + "Channels Number :" & strHeaderList(6))
            rbxHeaderInfo.AppendText(Environment.NewLine + "Sample Rate     :" & strHeaderList(7))
            rbxHeaderInfo.AppendText(Environment.NewLine + "Byte Rate       :" & strHeaderList(8))
            rbxHeaderInfo.AppendText(Environment.NewLine + "Block Align     :" & strHeaderList(9))
            rbxHeaderInfo.AppendText(Environment.NewLine + "Bits PerSample  :" & strHeaderList(10))
            rbxHeaderInfo.AppendText(Environment.NewLine + "       Data Chunk           ")
            rbxHeaderInfo.AppendText(Environment.NewLine + "SubChunk 2 ID   :" & strHeaderList(11))
            rbxHeaderInfo.AppendText(Environment.NewLine + "SubChunk 1 Size :" & strHeaderList(12))
            ''calling function of data read
            shtDataArray = objReadWrite.ReadData(WavOpenFileDialog.FileName)
            Dim information = My.Computer.FileSystem.GetFileInfo(WavOpenFileDialog.FileName)
            MsgBox("The file's full name is " & information.FullName & ".")
            MsgBox("Last access time is " & information.LastAccessTime & ".")
            MsgBox("The length is " & information.Length & ".")
            ''loop for add colums according to chaneels
            For i = 0 To strHeaderList(6) - 1
                objDt.Columns.Add("Channel " & i + 1)
            Next
            intTemp = 0
            ''loop for sorting data in tablur form
            For i = 0 To (shtDataArray.Length / strHeaderList(6)) - 1
                objDt.Rows.Add()
                For j = 0 To strHeaderList(6) - 1
                    objDt.Rows(i)("Channel " & j + 1) = shtDataArray(j + intTemp)
                Next
                intTemp = intTemp + strHeaderList(6)
            Next
            ''caling sub of craet csv file
            writeWavFileDataIntoCsv(shtDataArray)
        End If
        WavOpenFileDialog.Dispose()

    End Sub
    ''this button will save the file as new by assking destionation of path
    Private Sub btnCreateNewFile_Click(sender As Object, e As EventArgs) Handles btnCreateNewFile.Click
        Try
            WriteSaveFileDialog.Filter = "Audio Files(*.wav)|*.wav|All files (*.*)|*.*" 'apply filter for only select wave file
            WriteSaveFileDialog.Title = "Name An Audio File"
            If WriteSaveFileDialog.ShowDialog() = DialogResult.OK Then
                objReadWrite.WavFileWrite(WriteSaveFileDialog.FileName, shtDataArray) ''Call sub and give path as parameter
            End If
        Catch ex As Exception
            MsgBox("Error oucrs@new File button" & ex.Message)
        End Try
    End Sub
    ''this button will show data in datagrid view
    Private Sub BtnShowData_Click(sender As Object, e As EventArgs) Handles BtnShowData.Click
        GridViewDataInfo.DataSource = objDt ''show data table into grids view
    End Sub
#End Region

#Region " Functions and subs"
    ''' <summary>
    ''' This Functions convert data values in to pascal unit value and caluclate change of time for each value of cahnnels and write converted values into txt file
    ''' </summary>
    ''' <param name="dataarray">this holds data of wav file</param>
    Public Sub writeWavFileDataIntoCsv(ByVal dataarray() As Short)
        Dim PascalData(dataarray.Length) As Double 'this array will conatin values converted in pascal 
        Dim arrayTime(dataarray.Length / strHeaderList(6)) As Double 'this array will conatin rate of change in time 
        Dim dbltime As Double = (1 / strHeaderList(7)) ''caluclatin  cahngee in time
        Dim dbltemptime As Double = 0.000000
        Dim strPathGrapData As String = "C:\Users\Zainmpz\Desktop\New folder\GraphData.rtf" ''this holds path of txt file where is to save
        Dim GraphWriter As New StreamWriter(strPathGrapData)
        Try
            ''loop appling formula and conevert each value int pasacal
            For i = 0 To dataarray.Length - 1
                PascalData(i) = ((dataarray(i) / (2 ^ 15)) * 1)
            Next
            ''this loop is caluclating time for each value of channel
            For c = 0 To arrayTime.Length - 1
                arrayTime(c) = dbltemptime
                dbltemptime = dbltemptime + dbltime
            Next
            intTemp = 0
            ''this loop write the data from arrays into txt file
            For k = 0 To (shtDataArray.Length / strHeaderList(6)) - 1
                GraphWriter.Write("Sample " & k & ": " & arrayTime(k) & "        ")
                For j = 0 To strHeaderList(6) - 1
                    GraphWriter.Write(PascalData(intTemp + j) & "     ")
                Next
                GraphWriter.Write(Environment.NewLine)
                intTemp = intTemp + strHeaderList(6)
            Next
            GraphWriter.Close()
        Catch ex As Exception
            MsgBox("error occurs @ writing Pascal values" & ex.Message)
        End Try
    End Sub

#End Region

End Class
