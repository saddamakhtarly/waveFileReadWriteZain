<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblFilePath = New System.Windows.Forms.Label()
        Me.tbxFileName = New System.Windows.Forms.TextBox()
        Me.btnOpenWavFile = New System.Windows.Forms.Button()
        Me.btnCreateNewFile = New System.Windows.Forms.Button()
        Me.rbxHeaderInfo = New System.Windows.Forms.RichTextBox()
        Me.GridViewDataInfo = New System.Windows.Forms.DataGridView()
        Me.BtnShowData = New System.Windows.Forms.Button()
        Me.WavOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.WriteSaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        CType(Me.GridViewDataInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblFilePath
        '
        Me.lblFilePath.AutoSize = True
        Me.lblFilePath.Location = New System.Drawing.Point(25, 13)
        Me.lblFilePath.Name = "lblFilePath"
        Me.lblFilePath.Size = New System.Drawing.Size(48, 13)
        Me.lblFilePath.TabIndex = 0
        Me.lblFilePath.Text = "File Path"
        '
        'tbxFileName
        '
        Me.tbxFileName.Location = New System.Drawing.Point(70, 10)
        Me.tbxFileName.Name = "tbxFileName"
        Me.tbxFileName.Size = New System.Drawing.Size(220, 20)
        Me.tbxFileName.TabIndex = 1
        '
        'btnOpenWavFile
        '
        Me.btnOpenWavFile.Location = New System.Drawing.Point(305, 10)
        Me.btnOpenWavFile.Name = "btnOpenWavFile"
        Me.btnOpenWavFile.Size = New System.Drawing.Size(92, 23)
        Me.btnOpenWavFile.TabIndex = 2
        Me.btnOpenWavFile.Text = "Open File"
        Me.btnOpenWavFile.UseVisualStyleBackColor = True
        '
        'btnCreateNewFile
        '
        Me.btnCreateNewFile.Location = New System.Drawing.Point(403, 10)
        Me.btnCreateNewFile.Name = "btnCreateNewFile"
        Me.btnCreateNewFile.Size = New System.Drawing.Size(95, 23)
        Me.btnCreateNewFile.TabIndex = 3
        Me.btnCreateNewFile.Text = "Create New File"
        Me.btnCreateNewFile.UseVisualStyleBackColor = True
        '
        'rbxHeaderInfo
        '
        Me.rbxHeaderInfo.Location = New System.Drawing.Point(28, 42)
        Me.rbxHeaderInfo.Name = "rbxHeaderInfo"
        Me.rbxHeaderInfo.Size = New System.Drawing.Size(256, 269)
        Me.rbxHeaderInfo.TabIndex = 4
        Me.rbxHeaderInfo.Text = ""
        '
        'GridViewDataInfo
        '
        Me.GridViewDataInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridViewDataInfo.Location = New System.Drawing.Point(305, 42)
        Me.GridViewDataInfo.Name = "GridViewDataInfo"
        Me.GridViewDataInfo.Size = New System.Drawing.Size(400, 269)
        Me.GridViewDataInfo.TabIndex = 5
        '
        'BtnShowData
        '
        Me.BtnShowData.Location = New System.Drawing.Point(630, 10)
        Me.BtnShowData.Name = "BtnShowData"
        Me.BtnShowData.Size = New System.Drawing.Size(75, 23)
        Me.BtnShowData.TabIndex = 6
        Me.BtnShowData.Text = "Show Data"
        Me.BtnShowData.UseVisualStyleBackColor = True
        '
        'WavOpenFileDialog
        '
        Me.WavOpenFileDialog.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 323)
        Me.Controls.Add(Me.BtnShowData)
        Me.Controls.Add(Me.GridViewDataInfo)
        Me.Controls.Add(Me.rbxHeaderInfo)
        Me.Controls.Add(Me.btnCreateNewFile)
        Me.Controls.Add(Me.btnOpenWavFile)
        Me.Controls.Add(Me.tbxFileName)
        Me.Controls.Add(Me.lblFilePath)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.GridViewDataInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblFilePath As Label
    Friend WithEvents tbxFileName As TextBox
    Friend WithEvents btnOpenWavFile As Button
    Friend WithEvents btnCreateNewFile As Button
    Friend WithEvents rbxHeaderInfo As RichTextBox
    Friend WithEvents GridViewDataInfo As DataGridView
    Friend WithEvents BtnShowData As Button
    Friend WithEvents WavOpenFileDialog As OpenFileDialog
    Friend WithEvents WriteSaveFileDialog As SaveFileDialog
End Class
