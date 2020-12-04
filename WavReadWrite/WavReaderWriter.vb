Imports System.IO
Public Class WavReaderWriter
#Region " Gerneral Varibales"
    Public Structure Header
        Dim strChunkId As String ''Marks the file as a riff file. Characters are each 1 byte long.
        Dim intChunkSize As Integer ''Size of the overall file - 8 bytes, in bytes (32-bit integer). Typically, you'd fill this in after creation.
        Dim strFormat As String ''File FC:\Users\zaina\OneDrive\Documents\Visual Studio 2015\Projects\WavReadWrite\WavReadWrite\WavReaderWriter.vbormat. For our purposes, it always equals "WAVE".
    End Structure

    Public Structure Format
        Dim strSubChunk1Id As String ''	Format chunk marker.
        Dim intSubChunk1Size As Integer ''	Length of format data as listed above
        Dim shtAudioFormat As Short ''Type of format (1 is PCM) - 2 byte integer
        Dim shtChannelsNum As Short ''Number of Channels - 2 byte integer
        Dim intSampleRate As Integer ''Sample Rate - 32 byte integer. Common values are 44100 (CD), 48000 (DAT). Sample Rate = Number of Samples per second, or Hertz.
        Dim intByteRate As Integer ''(Sample Rate * BitsPerSample * Channels) / 8.
        Dim shtBlockAlign As Short ''	(BitsPerSample * Channels) / 8.1 - 8 bit mono2 - 8 bit stereo/16 bit mono4 - 16 bit stereo
        Dim shtBitsPerSample As Short ''Bits per sample
    End Structure

    Public Structure data
        Dim strSubChunk2Id As String ''"data" chunk header. Marks the beginning of the data section.
        Dim intSubChunk2Size As Integer ''	Size of the data section
    End Structure

    Dim FileToRead As FileStream '' initlaize the stream raeder to read file
    Dim FileToWrite As FileStream ''object  straem writer to write file
    Dim objHead As New Header '' creating object of struct as head chunk
    Dim objFmt As Format '' creating object of struct as fromat chunk 
    Dim objDat As data '' creating object of struct data chunk
    Dim intArraySize As Integer ''declaring varible for size of data array


#End Region

#Region "Functions and Subs"
    ''' <summary>
    ''' Tis function will read the haeder of wav file from 0offset to 44 and store it in array
    ''' </summary>
    ''' <param name="strWavFile">it cobnatins File path of wav file</param>
    ''' <returns>string array havin header information</returns>
    Public Function ReadHeader(ByVal strWavFile As String) As String()

        FileToRead = New FileStream(strWavFile, FileMode.Open) ''Initalize object with file path
        Dim strHeaderInfoList(12) As String
        Dim readBinary As New BinaryReader(FileToRead)        '' reffering obect as binary readr
        'fOR Header reading bytes and show in text box
        readBinary.BaseStream.Seek(0, SeekOrigin.Begin)       'indexing offsets 0 to 4 
        objHead.strChunkId = readBinary.ReadChars(4)          'reading bytes as chracters and stores in variale
        objHead.intChunkSize = readBinary.ReadInt32()         ' reading bytes as integerand stores in variale
        objHead.strFormat = readBinary.ReadChars(4)           ' reading bytes as string stores in variale
        'For Format reading bytes and show in text box
        objFmt.strSubChunk1Id = readBinary.ReadChars(4)      ' reading bytes as string stores in variale
        objFmt.intSubChunk1Size = readBinary.ReadInt32()     ' reading bytes as integer stores in variale
        objFmt.shtAudioFormat = readBinary.ReadInt16()       ' reading bytes as shortstores in variale
        objFmt.shtChannelsNum = readBinary.ReadInt16()       ' reading bytes as short stores in variale
        objFmt.intSampleRate = readBinary.ReadInt32()        ' reading bytes as integer stores in variale
        objFmt.intByteRate = readBinary.ReadInt32()          ' reading bytes as integer stores in variale
        objFmt.shtBlockAlign = readBinary.ReadInt16()        ' reading bytes as short stores in variale
        objFmt.shtBitsPerSample = readBinary.ReadInt16()     ' reading bytes as short stores in variale
        'For data reading bytes and show in text box
        objDat.strSubChunk2Id = readBinary.ReadChars(4)      ' reading bytes as string stores in variale
        objDat.intSubChunk2Size = readBinary.ReadInt32()     ' reading bytes as integer stores in variale
        readBinary.Close()
        ''storing reslts of haeder read into array
        strHeaderInfoList(0) = objHead.strChunkId
        strHeaderInfoList(1) = objHead.intChunkSize
        strHeaderInfoList(2) = objHead.strFormat
        strHeaderInfoList(3) = objFmt.strSubChunk1Id
        strHeaderInfoList(4) = objFmt.intSubChunk1Size
        strHeaderInfoList(5) = objFmt.shtAudioFormat
        strHeaderInfoList(6) = objFmt.shtChannelsNum
        strHeaderInfoList(7) = objFmt.intSampleRate
        strHeaderInfoList(8) = objFmt.intByteRate
        strHeaderInfoList(9) = objFmt.shtBlockAlign
        strHeaderInfoList(10) = objFmt.shtBitsPerSample
        strHeaderInfoList(11) = objDat.strSubChunk2Id
        strHeaderInfoList(12) = objDat.intSubChunk2Size
        Return strHeaderInfoList
    End Function

    ''' <summary>
    ''' this function will read wav file data and store into array as short Data
    ''' </summary>
    ''' <param name="strFilePath"> it will be hold wav file path</param>
    ''' <returns>Short data array of file</returns>
    Public Function ReadData(ByVal strFilePath As String) As Short()

        FileToRead = New FileStream(strFilePath, FileMode.Open) ''Initalize object with file path
        Dim readBinary As New BinaryReader(FileToRead)          '' reffering obect as binary readr
        intArraySize = (objDat.intSubChunk2Size / 2)            ''çalculating array size which stores data 
        Dim DataArray(intArraySize) As Short              ''intilazing array size      
        ''readind data from file and saving in array
        readBinary.BaseStream.Seek(44, SeekOrigin.Begin)        ''satrating read for index 44
        For i = 0 To intArraySize - 1                           ''loop from  44 to 2360 
            Dim shtData As Short = readBinary.ReadInt16()       ''read bytes as short
            DataArray(i) = shtData                           ''store readed data in array
        Next
        readBinary.Close()
        Return DataArray
    End Function

    ''' <summary>
    ''' This sub will write the file as new
    ''' </summary>
    ''' <param name="strFilePath"> conatins path where to save new file</param>
    ''' <param name="ShtDataArray">it will hold the data of wav file</param>
    Public Sub WavFileWrite(ByVal strFilePath As String, ByVal ShtDataArray() As Short)
        Try
            FileToWrite = New FileStream(strFilePath, FileMode.Create) ''intaite obj of  binary file writer
            Dim writeBinary As New BinaryWriter(FileToWrite)
            'Writing Header of file
            writeBinary.BaseStream.Seek(0, SeekOrigin.Begin)         'indexing offsets 0 to 4 
            writeBinary.Write(System.Text.Encoding.ASCII.GetBytes(objHead.strChunkId)) ''convert data into bytes and write specific index offset
            writeBinary.Write(objHead.intChunkSize)                       ''convert data into bytes and write on file at specific index offset
            writeBinary.Write(System.Text.Encoding.ASCII.GetBytes(objHead.strFormat))
            'writing format chunk of file
            writeBinary.Write(System.Text.Encoding.ASCII.GetBytes(objFmt.strSubChunk1Id))
            writeBinary.Write(objFmt.intSubChunk1Size)
            writeBinary.Write(objFmt.shtAudioFormat)
            writeBinary.Write(objFmt.shtChannelsNum)
            writeBinary.Write(objFmt.intSampleRate)
            writeBinary.Write(objFmt.intByteRate)
            writeBinary.Write(objFmt.shtBlockAlign)
            writeBinary.Write(objFmt.shtBitsPerSample)
            'writing Data chunk of file
            writeBinary.Write(System.Text.Encoding.ASCII.GetBytes(objDat.strSubChunk2Id))
            writeBinary.Write(objDat.intSubChunk2Size)
            ''writing data
            For index = 0 To ShtDataArray.Length - 1
                writeBinary.Write(ShtDataArray(index))
            Next
            writeBinary.Close()
            MsgBox(" New File Created")
        Catch ex As Exception
            MsgBox("error occurs @ writing Wav file" & ex.Message)
        End Try
    End Sub


#End Region



End Class
