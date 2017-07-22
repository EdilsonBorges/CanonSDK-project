Imports System.Runtime.InteropServices


' カメライベント通知用
Public Structure TCameraEventMsg
    Dim inEvent As Integer
    Dim inData As IntPtr
    Dim inDataSize As Integer
End Structure


' カメラプロパティ<-->表示文字列変換テーブル
Public Structure TPropStrVal
    Dim val As Integer
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=256)> Dim str As String
End Structure


Public Class VBSample
    Inherits System.Windows.Forms.Form

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    ' Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャは、Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更してください。  
    ' コード エディタを使って変更しないでください。
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TakeBtn As System.Windows.Forms.Button
    Friend WithEvents GetPicBtn As System.Windows.Forms.Button
    Friend WithEvents ISOSpeedCmb As System.Windows.Forms.ComboBox
    Friend WithEvents AvCmb As System.Windows.Forms.ComboBox
    Friend WithEvents TvCmb As System.Windows.Forms.ComboBox
    Private WithEvents AEModeCmb As System.Windows.Forms.ComboBox
    Friend WithEvents MeteringModeCmb As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ExposureCompCmb As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ExitBtn As System.Windows.Forms.Button
    Friend WithEvents InfoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TakeBtn = New System.Windows.Forms.Button
        Me.GetPicBtn = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.AEModeCmb = New System.Windows.Forms.ComboBox
        Me.ISOSpeedCmb = New System.Windows.Forms.ComboBox
        Me.AvCmb = New System.Windows.Forms.ComboBox
        Me.TvCmb = New System.Windows.Forms.ComboBox
        Me.MeteringModeCmb = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ExposureCompCmb = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ExitBtn = New System.Windows.Forms.Button
        Me.InfoTextBox = New System.Windows.Forms.TextBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'TakeBtn
        '
        Me.TakeBtn.Location = New System.Drawing.Point(224, 128)
        Me.TakeBtn.Name = "TakeBtn"
        Me.TakeBtn.Size = New System.Drawing.Size(96, 48)
        Me.TakeBtn.TabIndex = 0
        Me.TakeBtn.Text = "Take Picture"
        '
        'GetPicBtn
        '
        Me.GetPicBtn.Location = New System.Drawing.Point(224, 88)
        Me.GetPicBtn.Name = "GetPicBtn"
        Me.GetPicBtn.Size = New System.Drawing.Size(96, 32)
        Me.GetPicBtn.TabIndex = 1
        Me.GetPicBtn.Text = "Get Pictures"
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "AE Mode:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "ISO:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Av:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Tv:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AEModeCmb
        '
        Me.AEModeCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AEModeCmb.Location = New System.Drawing.Point(80, 16)
        Me.AEModeCmb.Name = "AEModeCmb"
        Me.AEModeCmb.Size = New System.Drawing.Size(120, 20)
        Me.AEModeCmb.TabIndex = 11
        '
        'ISOSpeedCmb
        '
        Me.ISOSpeedCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ISOSpeedCmb.Location = New System.Drawing.Point(80, 112)
        Me.ISOSpeedCmb.Name = "ISOSpeedCmb"
        Me.ISOSpeedCmb.Size = New System.Drawing.Size(120, 20)
        Me.ISOSpeedCmb.TabIndex = 12
        '
        'AvCmb
        '
        Me.AvCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AvCmb.Location = New System.Drawing.Point(80, 80)
        Me.AvCmb.Name = "AvCmb"
        Me.AvCmb.Size = New System.Drawing.Size(120, 20)
        Me.AvCmb.TabIndex = 14
        '
        'TvCmb
        '
        Me.TvCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TvCmb.Location = New System.Drawing.Point(80, 48)
        Me.TvCmb.Name = "TvCmb"
        Me.TvCmb.Size = New System.Drawing.Size(120, 20)
        Me.TvCmb.TabIndex = 15
        '
        'MeteringModeCmb
        '
        Me.MeteringModeCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MeteringModeCmb.Location = New System.Drawing.Point(80, 144)
        Me.MeteringModeCmb.Name = "MeteringModeCmb"
        Me.MeteringModeCmb.Size = New System.Drawing.Size(120, 20)
        Me.MeteringModeCmb.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 24)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Metering Mode:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ExposureCompCmb
        '
        Me.ExposureCompCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ExposureCompCmb.Location = New System.Drawing.Point(80, 176)
        Me.ExposureCompCmb.Name = "ExposureCompCmb"
        Me.ExposureCompCmb.Size = New System.Drawing.Size(120, 20)
        Me.ExposureCompCmb.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 24)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Exposure Comp:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ExitBtn
        '
        Me.ExitBtn.Location = New System.Drawing.Point(240, 16)
        Me.ExitBtn.Name = "ExitBtn"
        Me.ExitBtn.Size = New System.Drawing.Size(80, 32)
        Me.ExitBtn.TabIndex = 4
        Me.ExitBtn.Text = "Quit"
        '
        'InfoTextBox
        '
        Me.InfoTextBox.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.InfoTextBox.Location = New System.Drawing.Point(8, 216)
        Me.InfoTextBox.Name = "InfoTextBox"
        Me.InfoTextBox.Size = New System.Drawing.Size(312, 19)
        Me.InfoTextBox.TabIndex = 20
        Me.InfoTextBox.Text = "Info"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(224, 184)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(96, 16)
        Me.ProgressBar1.TabIndex = 21
        '
        'VBSample
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(328, 245)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.InfoTextBox)
        Me.Controls.Add(Me.ExposureCompCmb)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.MeteringModeCmb)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TvCmb)
        Me.Controls.Add(Me.AvCmb)
        Me.Controls.Add(Me.ISOSpeedCmb)
        Me.Controls.Add(Me.AEModeCmb)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ExitBtn)
        Me.Controls.Add(Me.GetPicBtn)
        Me.Controls.Add(Me.TakeBtn)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "VBSample"
        Me.Text = "VBSample"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "クラス変数"
    Dim theCamera As IntPtr
    Dim theCameraList As IntPtr
    Dim m_CameraModel As Integer
    'Dim m_CameraName As System.Text.StringBuilder
    Dim m_CameraName As String
    Dim isSDKLoaded As Boolean = False
    Dim m_deviceInfo As EdsDeviceInfo
    Dim g_StrValAEMode(17) As TPropStrVal
    Dim g_StrValISOSpeed(20) As TPropStrVal
    Dim g_StrValAv(54) As TPropStrVal
    Dim g_StrValTv(73) As TPropStrVal

#End Region


#Region "Event handler"


    Public Function PropertyEventHandler( _
        ByVal inEvent As Integer, _
        ByVal inPropID As Integer, _
        ByVal inParam As Integer, _
        ByVal inContext As IntPtr) As Long
        'イベントハンドラ
        'MessageBox.Show("EventHandler start")


        Dim err As Integer = EDS_ERR_OK
        Dim theStream As IntPtr = IntPtr.Zero
        Dim pDirItemInfo As IntPtr
        Dim dirItemInfo As EdsDirectoryItemInfo
        Dim isStrmOpen As Boolean = False

        Dim dwVal As Integer
        Dim wkIntPtr As IntPtr
        Dim pChgStr As String
        Dim iCurSel As Integer


        Select Case inEvent




            Case kEdsPropertyEvent_PropertyChanged
                '// EOS30D以前の機種に関しては，カスタムファンクションの場合のみ変更されたプロパティが通知されます。
                '// プロパティの指定がない場合には全てのプロパティを取得し直す必要があります。

                Select Case m_CameraName
                    Case "EOS 30D" '// 30D以降のルート以降
                        'inPropID = CType(Marshal.PtrToStructure(inData, GetType(Integer)), Integer)

                        wkIntPtr = Marshal.AllocHGlobal(4)

                        err = EdsGetPropertyData(theCamera, inPropID, 0, Marshal.SizeOf(wkIntPtr), wkIntPtr)
                        Select Case inPropID
                            Case kEdsPropID_AEMode
                                dwVal = CType(Marshal.PtrToStructure(wkIntPtr, GetType(Integer)), Integer)
                                pChgStr = GetPropStr(kEdsPropID_AEMode, dwVal)
                                iCurSel = Me.AEModeCmb.FindString(pChgStr)
                                If pChgStr <> "" And iCurSel = &HFFFFFFFF Then
                                    AEModeCmb.Items.Clear()
                                    iCurSel = Me.AEModeCmb.Items.Add(pChgStr)
                                    Me.AEModeCmb.SelectedIndex = iCurSel
                                Else
                                    Me.AEModeCmb.SelectedIndex = iCurSel
                                End If

                                pChgStr = GetPropStr(kEdsPropID_Av, dwVal)
                                iCurSel = Me.AvCmb.FindString(pChgStr)
                                Me.AvCmb.SelectedIndex = iCurSel
                                Return 0

                            Case kEdsPropID_ISOSpeed
                                dwVal = CType(Marshal.PtrToStructure(wkIntPtr, GetType(Integer)), Integer)
                                pChgStr = GetPropStr(kEdsPropID_ISOSpeed, dwVal)
                                iCurSel = Me.ISOSpeedCmb.FindString(pChgStr)
                                Me.ISOSpeedCmb.SelectedIndex = iCurSel
                                Return 0

                            Case kEdsPropID_Av
                                dwVal = CType(Marshal.PtrToStructure(wkIntPtr, GetType(Integer)), Integer)
                                pChgStr = GetPropStr(kEdsPropID_Av, dwVal)
                                iCurSel = Me.AvCmb.FindString(pChgStr)
                                Me.AvCmb.SelectedIndex = iCurSel
                                Return 0
                            Case kEdsPropID_Tv
                                dwVal = CType(Marshal.PtrToStructure(wkIntPtr, GetType(Integer)), Integer)
                                pChgStr = GetPropStr(kEdsPropID_Tv, dwVal)
                                iCurSel = Me.TvCmb.FindString(pChgStr)
                                Me.TvCmb.SelectedIndex = iCurSel
                                Return 0
                        End Select

                        Marshal.FreeHGlobal(wkIntPtr)


                    Case Else

                        GetProp()
                        Marshal.FreeHGlobal(wkIntPtr)

                        Return err

                End Select

                Return 0

            Case kEdsPropertyEvent_PropertyDescChanged
                '// EOS30D以前の機種に関してはプロパティの指定がされないため、全てのプロパティ詳細を取得し直す必要があります。
                Select Case m_CameraName

                    Case "EOS 30D"
                        '// EOS30D以降
                        Dim tmpPropDesc As EdsPropertyDesc
                        '//EdsGetPropertyDesc( theCamera, inPropID, 0, sizeof( dwVal ), &dwVal ) ;
                        Select Case inPropID
                            Case kEdsPropID_AEMode
                                Me.AEModeCmb.Items.Clear()
                                err = EdsGetPropertyDesc(theCamera, kEdsPropID_AEMode, tmpPropDesc)
                                LoadPropertyList(kEdsPropID_AEMode, Me.AEModeCmb, tmpPropDesc)


                                '// 現在の設定値再描画
                                wkIntPtr = Marshal.AllocHGlobal(4)

                                EdsGetPropertyData(theCamera, inPropID, 0, Marshal.SizeOf(dwVal), wkIntPtr)
                                dwVal = CType(Marshal.PtrToStructure(wkIntPtr, GetType(Integer)), Integer)
                                pChgStr = GetPropStr(kEdsPropID_AEMode, dwVal)
                                iCurSel = Me.AEModeCmb.FindString(pChgStr)
                                If pChgStr <> "" And iCurSel = &HFFFFFFFF Then
                                    Me.AEModeCmb.Items.Clear()
                                    iCurSel = Me.AEModeCmb.Items.Add(pChgStr)
                                    Me.AEModeCmb.SelectedIndex = iCurSel
                                Else
                                    Me.AEModeCmb.SelectedIndex = iCurSel
                                End If

                                Marshal.FreeHGlobal(wkIntPtr)
                                Return 0

                            Case kEdsPropID_ISOSpeed
                                Me.ISOSpeedCmb.Items.Clear()
                                err = EdsGetPropertyDesc(theCamera, kEdsPropID_ISOSpeed, tmpPropDesc)
                                LoadPropertyList(kEdsPropID_ISOSpeed, Me.ISOSpeedCmb, tmpPropDesc)

                                '// 現在の設定値再描画
                                wkIntPtr = Marshal.AllocHGlobal(4)

                                EdsGetPropertyData(theCamera, inPropID, 0, Marshal.SizeOf(wkIntPtr), wkIntPtr)
                                dwVal = CType(Marshal.PtrToStructure(wkIntPtr, GetType(Integer)), Integer)
                                pChgStr = GetPropStr(kEdsPropID_ISOSpeed, dwVal)
                                iCurSel = Me.ISOSpeedCmb.FindString(pChgStr)
                                Me.ISOSpeedCmb.SelectedIndex = iCurSel

                                Marshal.FreeHGlobal(wkIntPtr)
                                Return 0

                            Case kEdsPropID_Av
                                AvCmb.Items.Clear()
                                err = EdsGetPropertyDesc(theCamera, kEdsPropID_Av, tmpPropDesc)
                                LoadPropertyList(kEdsPropID_Av, Me.AvCmb, tmpPropDesc)

                                '// 現在の設定値再描画
                                wkIntPtr = Marshal.AllocHGlobal(4)

                                EdsGetPropertyData(theCamera, inPropID, 0, Marshal.SizeOf(wkIntPtr), wkIntPtr)
                                dwVal = CType(Marshal.PtrToStructure(wkIntPtr, GetType(Integer)), Integer)
                                pChgStr = GetPropStr(kEdsPropID_Av, dwVal)
                                iCurSel = Me.AvCmb.FindString(pChgStr)
                                Me.AvCmb.SelectedIndex = iCurSel

                                Marshal.FreeHGlobal(wkIntPtr)
                                Return 0

                            Case kEdsPropID_Tv
                                TvCmb.Items.Clear()
                                err = EdsGetPropertyDesc(theCamera, kEdsPropID_Tv, tmpPropDesc)
                                LoadPropertyList(kEdsPropID_Tv, Me.TvCmb, tmpPropDesc)

                                '// 現在の設定値再描画
                                wkIntPtr = Marshal.AllocHGlobal(4)

                                EdsGetPropertyData(theCamera, inPropID, 0, Marshal.SizeOf(wkIntPtr), wkIntPtr)
                                dwVal = CType(Marshal.PtrToStructure(wkIntPtr, GetType(Integer)), Integer)
                                pChgStr = GetPropStr(kEdsPropID_Tv, dwVal)
                                iCurSel = Me.TvCmb.FindString(pChgStr)
                                Me.TvCmb.SelectedIndex = iCurSel

                                Marshal.FreeHGlobal(wkIntPtr)
                                Return 0
                        End Select

                    Case Else
                        GetProp()
                        Return 0

                End Select
            Case Else
                ' それ以外
        End Select


        Return err


    End Function



    Public Function ObjectEventHandler( _
        ByVal inEvent As Integer, _
        ByVal inRef As IntPtr, _
        ByVal inContext As IntPtr) As Long

        Dim err As Integer = EDS_ERR_OK
        Dim theStream As IntPtr = IntPtr.Zero
        Dim pDirItemInfo As IntPtr
        Dim dirItemInfo As EdsDirectoryItemInfo
        Dim isStrmOpen As Boolean = False

        Dim dwVal As Integer
        Dim wkIntPtr As IntPtr
        Dim pChgStr As String
        Dim iCurSel As Integer
        Dim inPropID As Integer

        '//転送する画像の情報を取得する
        err = EdsGetDirectoryItemInfo(inRef, dirItemInfo)


        '//転送先(PC)のファイルのストリームを作成する
        If err = EDS_ERR_OK Then
            err = EdsCreateFileStream(dirItemInfo.szFileName, _
                                    EdsFileCreateDisposition.kEdsFileCreateDisposition_CreateAlways, _
                                    EdsAccess.kEdsAccess_ReadWrite, theStream)
            If err <> EDS_ERR_OK Then
                err = EdsDownloadCancel(inRef)
                Return err
            End If
        End If

        '//プログレスを設定する
        If err = EDS_ERR_OK Then
            err = EdsSetProgressCallback(theStream, AddressOf ProgressFunc, _
            EdsProgressOption.kEdsProgressOption_Periodically, IntPtr.Zero)
        End If


        '//画像をダウンロードする
        If err = EDS_ERR_OK Then
            err = EdsDownload(inRef, dirItemInfo.size, theStream)
            If err <> EDS_ERR_OK Then
                err = EdsDownloadCancel(inRef)
            Else
                err = EdsDownloadComplete(inRef)
            End If
        End If
        EdsRelease(theStream)

    End Function



    Public Function StateEventHandler( _
    ByVal inEvent As Integer, _
    ByVal inEventData As Integer, _
    ByVal inContext As IntPtr) As Long
        MessageBox.Show("StateEvent Handler START")


    End Function



    Public Function ProgressFunc(ByVal inPercent As Integer, _
     ByVal inContext As IntPtr, ByRef outCancel As Boolean) As Long
        ' 進捗率イベントハンドラ


        Console.WriteLine("Done: {0}", inPercent)
        Return EDS_ERR_OK
    End Function


#End Region


    Public Function DownloadCameraFiles(ByVal aDirRef As IntPtr) As Integer
        Dim dwCount As Integer = 0
        Dim iCnt As Integer = 0
        Dim childRef As IntPtr
        'Dim pObjectInfo As IntPtr
        Dim aObjectInfo As EdsDirectoryItemInfo
        Dim theStream As IntPtr
        Dim err As Integer = EDS_ERR_OK

        err = EdsGetChildCount(aDirRef, dwCount)
        If err <> EDS_ERR_OK Then
            Return err
        End If

        For iCnt = 0 To dwCount - 1 Step 1
            err = EdsGetChildAtIndex(aDirRef, iCnt, childRef)
            If err <> EDS_ERR_OK Then
                Return err
            End If


            err = EdsGetDirectoryItemInfo(childRef, aObjectInfo)
            'aObjectInfo = CType(Marshal.PtrToStructure(pObjectInfo, GetType(EdsDirectoryItemInfo)), EdsDirectoryItemInfo)

            If err <> EDS_ERR_OK Then
                Return err
            End If


            If aObjectInfo.isFolder = True Then
                '// FOLDER
                err = DownloadCameraFiles(childRef)
                If err <> EDS_ERR_OK Then
                    Return err
                End If
                GoTo endfor
            End If


            err = EdsCreateFileStream(aObjectInfo.szFileName, _
                EdsFileCreateDisposition.kEdsFileCreateDisposition_CreateAlways, _
                EdsAccess.kEdsAccess_ReadWrite, theStream)
            If err <> EDS_ERR_OK Then
                Return err
            End If

            err = EdsSetProgressCallback(theStream, AddressOf ProgressFunc, _
            EdsProgressOption.kEdsProgressOption_Periodically, IntPtr.Zero)
            If err <> EDS_ERR_OK Then
                Return err
            End If

            err = EdsDownload(childRef, aObjectInfo.Size, theStream) '実行に失敗。err=&h61。streamはもう取得済なのでByValにしてみた。
            If err <> EDS_ERR_OK Then
                Return err
            End If
            err = EdsDownloadComplete(childRef)

            EdsRelease(theStream)
ENDFOR:

        Next

        Return err

    End Function


#Region "Window Events"
    Private Sub TakeBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TakeBtn.Click
        '
        ' 撮影ボタン
        '
        Dim err As Integer = EDS_ERR_OK

        '/********************************************************************************************
        ' *
        ' * リモートレリーズ実施 ＞
        ' *
        ' ********************************************************************************************/

        'カメラにUIロックをかける
        err = EdsSetState(theCamera, EdsCameraState.kEdsCameraState_UILock, 0)

        '//カメラに撮影コマンドを送る
        If err = EDS_ERR_OK Then
            err = EdsSendCommand(theCamera, EdsCameraCommand.kEdsCameraCommand_TakePicture, 0)

            '//カメラのUIロックを解除する
            err = EdsSetState(theCamera, EdsCameraState.kEdsCameraState_UIUnLock, 0)

        End If

        '/********************************************************************************************
        ' *
        ' * ＜ リモートレリーズ実施
        ' *
        ' ********************************************************************************************/

    End Sub



    Private Sub ExitBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitBtn.Click
        ' 終了ボタンクリック
        '//カメラとの通信を終了する
        Dim err As Integer = EDS_ERR_OK

        If err = EDS_ERR_OK Then
            err = EdsCloseSession(theCamera)
        End If

        EdsTerminateSDK()
        isSDKLoaded = False

        'If theCamera = IntPtr.Zero Then
        err = EdsRelease(theCamera)
        theCamera = IntPtr.Zero
        'End If
        'If theCameraList = IntPtr.Zero Then
        err = EdsRelease(theCameraList)
        theCameraList = IntPtr.Zero
        'End If

        End
    End Sub

    Private Sub GetPicBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetPicBtn.Click
        ' 画像取得ボタンクリック
        Dim err As Integer = EDS_ERR_OK
        Dim dwCount As Integer
        Dim theVolumeRef As IntPtr
        Dim theDirItemRef As IntPtr
        Dim pVolumeInfo As IntPtr
        Dim aVolumeInfo As EdsVolumeInfo = New EdsVolumeInfo
        'Dim aVolumeInfo As EdsVolumeInfo
        Dim theStream As IntPtr = IntPtr.Zero
        Dim iCnt As Integer = 0
        Dim szVolumeLabel As String

        '/********************************************************************************************
        ' * 
        ' * カメラ内CFの中身の構成を取得 ＞
        ' *
        ' ********************************************************************************************/

        '//カメラにUIロックをかける
        err = EdsSetState(theCamera, EdsCameraState.kEdsCameraState_UILock, 0)

        '//Volumeの個数取得
        If err = EDS_ERR_OK Then
            err = EdsGetChildCount(theCamera, dwCount)
            If dwCount = 0 Then
                err = EDS_ERR_DEVICE_NOT_FOUND
            End If
        End If

        '//
        '// メモリカードNo.0 の内容を取得
        '//
        err = EdsGetChildAtIndex(theCamera, 0, theVolumeRef)
        If err = EDS_ERR_OK Then
            'err = EdsGetVolumeInfo(theVolumeRef, pVolumeInfo)
            'aVolumeInfo = Marshal.PtrToStructure(pVolumeInfo, GetType(EdsVolumeInfo))
            err = EdsGetVolumeInfo(theVolumeRef, aVolumeInfo)
        End If

        If err = EDS_ERR_OK Then
            err = EdsGetChildCount(theVolumeRef, dwCount)
            If err = EDS_ERR_OK Then
                '/*
                ' * CF内のファイルを全て取得
                ' */
                For iCnt = 0 To dwCount - 1
                    err = EdsGetChildAtIndex(theVolumeRef, iCnt, theDirItemRef)
                    If err = EDS_ERR_OK Then
                        err = DownloadCameraFiles(theDirItemRef)
                        If err <> EDS_ERR_OK Then
                            GoTo BREAKTHROUGH
                        End If
                    End If
                Next
            End If
        End If

BREAKTHROUGH:

        '//カメラのUIロックを解除する
        If err = EDS_ERR_OK Then
            err = EdsSetState(theCamera, EdsCameraState.kEdsCameraState_UIUnLock, 0)
        End If

        '/********************************************************************************************
        ' *
        ' * ＜ カメラ内CFのフォルダ構成を取得
        ' *
        ' ********************************************************************************************/


        'AEModeCmb.BeginUpdate()
        'AEModeCmb.Items.Add("AAA")
        'AEModeCmb.Items.Add("BBB")
        'AEModeCmb.Items.Add("CCC")
        'AEModeCmb.Items.Add("DDD")
        'AEModeCmb.EndUpdate()

    End Sub

#End Region

#Region "Initialize"
    Private Sub VBSample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '
        ' アプリ起動時処理
        '
        tableInit() '文字列変換テーブル初期化

        Dim edsErr As Integer = 0
        Dim dwCameraCount As Integer
        'Dim wkIntPtr As IntPtr
        Dim type As Integer
        Dim size As Integer

        Dim wkIntptr As IntPtr = Marshal.AllocHGlobal(256)
        'Dim wkString As String
        Dim wkStrBuilder As System.Text.StringBuilder


        edsErr = EdsInitializeSDK()
        If edsErr <> EDS_ERR_OK Then
            isSDKLoaded = False
            Return
        End If

        edsErr = EdsGetCameraList(theCameraList)
        If edsErr <> EDS_ERR_OK Then
            isSDKLoaded = False
            Return
        End If

        edsErr = EdsGetChildCount(theCameraList, dwCameraCount)
        If dwCameraCount = 0 Then
            edsErr = EDS_ERR_DEVICE_NOT_FOUND
            Return
        End If

        edsErr = EdsGetChildAtIndex(theCameraList, 0, theCamera)
        If dwCameraCount = 0 Then
            edsErr = EDS_ERR_DEVICE_NOT_FOUND
            Return
        End If

        '//Event Handlerを設定する
        'If edsErr = EDS_ERR_OK Then
        '    edsErr = EdsSetCameraEventNotification(theCamera, _
        '           AddressOf cameraEventHandler, IntPtr.Zero)
        'End If
        If edsErr = EDS_ERR_OK Then
            edsErr = EdsSetPropertyEventHandler(theCamera, kEdsPropertyEvent_All, _
                                    AddressOf PropertyEventHandler, IntPtr.Zero)
        End If

        If edsErr = EDS_ERR_OK Then
            edsErr = EdsSetObjectEventHandler(theCamera, kEdsObjectEvent_All, _
                                    AddressOf ObjectEventHandler, IntPtr.Zero)
        End If


        If edsErr = EDS_ERR_OK Then
            edsErr = EdsSetCameraStateEventHandler(theCamera, kEdsStateEvent_All, _
                                    AddressOf StateEventHandler, IntPtr.Zero)
        End If


        'カメラとの通信を開始する()
        If edsErr = EDS_ERR_OK Then
            edsErr = EdsOpenSession(theCamera)
        End If

        If edsErr = EDS_ERR_OK Then
            edsErr = EdsSendCommand(theCamera, kEdsPropID_SaveTo, EdsSaveTo.kEdsSaveTo_Host)
        End If


        If edsErr = EDS_ERR_OK Then
            wkIntptr = Marshal.AllocHGlobal(Marshal.SizeOf(m_deviceInfo))
            edsErr = EdsGetDeviceInfo(theCamera, m_deviceInfo)
        End If



        If edsErr = EDS_ERR_OK Then

            '----------------------------------------------------------------------------------
            'Avの取得はできた。
            'Dim wkInteger As Integer
            'Dim wkIntPtr2 As IntPtr = Marshal.AllocHGlobal(4)
            'Marshal.StructureToPtr(wkInteger, wkIntPtr2, False)
            'edsErr = EdsGetPropertyData(theCamera, kEdsPropID_Av, 0, 32, wkIntPtr2)
            'wkInteger = wkIntPtr2.ToInt32
            'Marshal.FreeHGlobal(wkIntPtr)
            '----------------------------------------------------------------------------------


            edsErr = EdsGetPropertySize(theCamera, kEdsPropID_ProductName, 0, type, size)
            edsErr = EdsGetPropertyData(theCamera, kEdsPropID_ProductName, 0, 32, wkIntptr)
            m_CameraName = Marshal.PtrToStringAnsi(wkIntptr)
            Marshal.FreeHGlobal(wkIntptr)

        End If


        ' 30D等、保存先空き容量を必要とするカメラの場合(現状は30Dのみ。)
        If m_CameraName = "EOS 30D" Then
            If edsErr = EDS_ERR_OK Then
                Dim stCapacity As EdsCapacity
                Dim dwSector, dwByte, dwFree As Integer
                dwSector = dwByte = dwFree = &H8FFFF            ' // 実際には計算して代入すること。
                stCapacity.bytesPerSector = dwSector            ' //1クラスタのバイト数
                stCapacity.numberOfFreeClusters = dwFree        ' //空きクラスタ数
                stCapacity.reset = True
                edsErr = EdsSetCapacity(theCamera, stCapacity)
            End If
        End If


        GetProp() 'カメラプロパティ取得

    End Sub


    Private Sub tableInit()

        g_StrValAEMode(0).val = 0
        g_StrValAEMode(0).str = "P"
        g_StrValAEMode(1).val = 1
        g_StrValAEMode(1).str = "Tv"
        g_StrValAEMode(2).val = 2
        g_StrValAEMode(2).str = "Av"
        g_StrValAEMode(3).val = 3
        g_StrValAEMode(3).str = "M"
        g_StrValAEMode(4).val = 4
        g_StrValAEMode(4).str = "Bulb"
        g_StrValAEMode(5).val = 5
        g_StrValAEMode(5).str = "自動深度優先"
        g_StrValAEMode(6).val = 6
        g_StrValAEMode(6).str = "深度優先"
        g_StrValAEMode(7).val = 7
        g_StrValAEMode(7).str = "カメラ設定登録"
        g_StrValAEMode(8).val = 8
        g_StrValAEMode(8).str = "Lock"
        g_StrValAEMode(9).val = 9
        g_StrValAEMode(9).str = "GreenMode"
        g_StrValAEMode(10).val = 10
        g_StrValAEMode(10).str = "夜景ポートレート"
        g_StrValAEMode(11).val = 11
        g_StrValAEMode(11).str = "スポーツ"
        g_StrValAEMode(12).val = 12
        g_StrValAEMode(12).str = "ポートレート"
        g_StrValAEMode(13).val = 13
        g_StrValAEMode(13).str = "風景"
        g_StrValAEMode(14).val = 14
        g_StrValAEMode(14).str = "クローズアップ"
        g_StrValAEMode(15).val = 15
        g_StrValAEMode(15).str = "ストロボ発光禁止"
        g_StrValAEMode(16).val = &HFFFFFFFF
        g_StrValAEMode(16).str = "Unknown"


        g_StrValISOSpeed(0).val = &H28
        g_StrValISOSpeed(0).str = "6"
        g_StrValISOSpeed(1).val = &H30
        g_StrValISOSpeed(1).str = "12"
        g_StrValISOSpeed(2).val = &H38
        g_StrValISOSpeed(2).str = "25"
        g_StrValISOSpeed(3).val = &H40
        g_StrValISOSpeed(3).str = "50"
        g_StrValISOSpeed(4).val = &H48
        g_StrValISOSpeed(4).str = "100"
        g_StrValISOSpeed(5).val = &H4B
        g_StrValISOSpeed(5).str = "125"
        g_StrValISOSpeed(6).val = &H4D
        g_StrValISOSpeed(6).str = "160"
        g_StrValISOSpeed(7).val = &H50
        g_StrValISOSpeed(7).str = "200"
        g_StrValISOSpeed(8).val = &H53
        g_StrValISOSpeed(8).str = "250"
        g_StrValISOSpeed(9).val = &H55
        g_StrValISOSpeed(9).str = "320"
        g_StrValISOSpeed(10).val = &H58
        g_StrValISOSpeed(10).str = "400"
        g_StrValISOSpeed(11).val = &H5B
        g_StrValISOSpeed(11).str = "500"
        g_StrValISOSpeed(12).val = &H5D
        g_StrValISOSpeed(12).str = "640"
        g_StrValISOSpeed(13).val = &H60
        g_StrValISOSpeed(13).str = "800"
        g_StrValISOSpeed(14).val = &H63
        g_StrValISOSpeed(14).str = "1000"
        g_StrValISOSpeed(15).val = &H65
        g_StrValISOSpeed(15).str = "1250"
        g_StrValISOSpeed(16).val = &H68
        g_StrValISOSpeed(16).str = "1600"
        g_StrValISOSpeed(17).val = &H70
        g_StrValISOSpeed(17).str = "3200"
        g_StrValISOSpeed(18).val = &H78
        g_StrValISOSpeed(18).str = "6400"
        g_StrValISOSpeed(19).val = &HFFFFFFFF
        g_StrValISOSpeed(19).str = ""


        g_StrValAv(0).val = &H8
        g_StrValAv(0).str = "1"
        g_StrValAv(1).val = &HB
        g_StrValAv(1).str = "1.1"
        g_StrValAv(2).val = &HC
        g_StrValAv(2).str = "1.2"
        g_StrValAv(3).val = &HD
        g_StrValAv(3).str = "1.2"
        g_StrValAv(4).val = &H10
        g_StrValAv(4).str = "1.4"
        g_StrValAv(5).val = &H13
        g_StrValAv(5).str = "1.6"
        g_StrValAv(6).val = &H14
        g_StrValAv(6).str = "1.8"
        g_StrValAv(7).val = &H15
        g_StrValAv(7).str = "1.8"
        g_StrValAv(8).val = &H18
        g_StrValAv(8).str = "2"
        g_StrValAv(9).val = &H1B
        g_StrValAv(9).str = "2.2"
        g_StrValAv(10).val = &H1C
        g_StrValAv(10).str = "2.5"
        g_StrValAv(11).val = &H1D
        g_StrValAv(11).str = "2.5"
        g_StrValAv(12).val = &H20
        g_StrValAv(12).str = "2.8"
        g_StrValAv(13).val = &H23
        g_StrValAv(13).str = "3.2"
        g_StrValAv(14).val = &H24
        g_StrValAv(14).str = "3.5"
        g_StrValAv(15).val = &H25
        g_StrValAv(15).str = "3.5"
        g_StrValAv(16).val = &H28
        g_StrValAv(16).str = "4"
        g_StrValAv(17).val = &H2B
        g_StrValAv(17).str = "4"
        g_StrValAv(18).val = &H2C
        g_StrValAv(18).str = "4.5"
        g_StrValAv(19).val = &H2D
        g_StrValAv(19).str = "5.6"
        g_StrValAv(20).val = &H30
        g_StrValAv(20).str = "5.6"
        g_StrValAv(21).val = &H33
        g_StrValAv(21).str = "6.3"
        g_StrValAv(22).val = &H34
        g_StrValAv(22).str = "6.7"
        g_StrValAv(23).val = &H35
        g_StrValAv(23).str = "7.1"
        g_StrValAv(24).val = &H38
        g_StrValAv(24).str = "8"
        g_StrValAv(25).val = &H3B
        g_StrValAv(25).str = "9"
        g_StrValAv(26).val = &H3C
        g_StrValAv(26).str = "9.5"
        g_StrValAv(27).val = &H3D
        g_StrValAv(27).str = "10"
        g_StrValAv(28).val = &H40
        g_StrValAv(28).str = "11"
        g_StrValAv(29).val = &H43
        g_StrValAv(29).str = "13"
        g_StrValAv(30).val = &H44
        g_StrValAv(30).str = "13"
        g_StrValAv(31).val = &H45
        g_StrValAv(31).str = "14"
        g_StrValAv(32).val = &H48
        g_StrValAv(32).str = "16"
        g_StrValAv(33).val = &H4B
        g_StrValAv(33).str = "18"
        g_StrValAv(34).val = &H4C
        g_StrValAv(34).str = "19"
        g_StrValAv(35).val = &H4D
        g_StrValAv(35).str = "20"
        g_StrValAv(36).val = &H50
        g_StrValAv(36).str = "22"
        g_StrValAv(37).val = &H53
        g_StrValAv(37).str = "25"
        g_StrValAv(38).val = &H54
        g_StrValAv(38).str = "27"
        g_StrValAv(39).val = &H55
        g_StrValAv(39).str = "29"
        g_StrValAv(40).val = &H58
        g_StrValAv(40).str = "32"
        g_StrValAv(41).val = &H5B
        g_StrValAv(41).str = "36"
        g_StrValAv(42).val = &H5C
        g_StrValAv(42).str = "38"
        g_StrValAv(43).val = &H5D
        g_StrValAv(43).str = "40"
        g_StrValAv(44).val = &H60
        g_StrValAv(44).str = "45"
        g_StrValAv(45).val = &H63
        g_StrValAv(45).str = "51"
        g_StrValAv(46).val = &H64
        g_StrValAv(46).str = "54"
        g_StrValAv(47).val = &H65
        g_StrValAv(47).str = "57"
        g_StrValAv(48).val = &H68
        g_StrValAv(48).str = "64"
        g_StrValAv(49).val = &H6B
        g_StrValAv(49).str = "72"
        g_StrValAv(50).val = &H6C
        g_StrValAv(50).str = "76"
        g_StrValAv(51).val = &H6D
        g_StrValAv(51).str = "80"
        g_StrValAv(52).val = &H70
        g_StrValAv(52).str = "91"
        g_StrValAv(53).val = &HFFFFFFFF
        g_StrValAv(53).str = ""

        g_StrValTv(0).val = &H10
        g_StrValTv(0).str = "30" + Chr(&H22)
        g_StrValTv(1).val = &H13
        g_StrValTv(1).str = "25" + Chr(&H22)
        g_StrValTv(2).val = &H14
        g_StrValTv(2).str = "20" + Chr(&H22)
        g_StrValTv(3).val = &H15
        g_StrValTv(3).str = "20" + Chr(&H22)
        g_StrValTv(4).val = &H18
        g_StrValTv(4).str = "15" + Chr(&H22)
        g_StrValTv(5).val = &H1B
        g_StrValTv(5).str = "13" + Chr(&H22)
        g_StrValTv(6).val = &H1C
        g_StrValTv(6).str = "10" + Chr(&H22)
        g_StrValTv(7).val = &H1D
        g_StrValTv(7).str = "10" + Chr(&H22)
        g_StrValTv(8).val = &H20
        g_StrValTv(8).str = "8" + Chr(&H22)
        g_StrValTv(9).val = &H23
        g_StrValTv(9).str = "6" + Chr(&H22)
        g_StrValTv(10).val = &H24
        g_StrValTv(10).str = "6" + Chr(&H22)
        g_StrValTv(11).val = &H25
        g_StrValTv(11).str = "5" + Chr(&H22)
        g_StrValTv(12).val = &H28
        g_StrValTv(12).str = "4" + Chr(&H22)
        g_StrValTv(13).val = &H2B
        g_StrValTv(13).str = "3" + Chr(&H22) + "2"
        g_StrValTv(14).val = &H2C
        g_StrValTv(14).str = "3" + Chr(&H22)
        g_StrValTv(15).val = &H2D
        g_StrValTv(15).str = "2" + Chr(&H22) + "5"
        g_StrValTv(16).val = &H30
        g_StrValTv(16).str = "2" + Chr(&H22)
        g_StrValTv(17).val = &H33
        g_StrValTv(17).str = "1" + Chr(&H22) + "6"
        g_StrValTv(18).val = &H34
        g_StrValTv(18).str = "1" + Chr(&H22) + "5"
        g_StrValTv(19).val = &H35
        g_StrValTv(19).str = "1" + Chr(&H22) + "3"
        g_StrValTv(20).val = &H38
        g_StrValTv(20).str = "1" + Chr(&H22)
        g_StrValTv(21).val = &H3B
        g_StrValTv(21).str = "0" + Chr(&H22) + "8"
        g_StrValTv(22).val = &H3C
        g_StrValTv(22).str = "0" + Chr(&H22) + "7"
        g_StrValTv(23).val = &H3D
        g_StrValTv(23).str = "0" + Chr(&H22) + "6"
        g_StrValTv(24).val = &H40
        g_StrValTv(24).str = "0" + Chr(&H22) + "5"
        g_StrValTv(25).val = &H43
        g_StrValTv(25).str = "0" + Chr(&H22) + "4"
        g_StrValTv(26).val = &H44
        g_StrValTv(26).str = "0" + Chr(&H22) + "3"
        g_StrValTv(27).val = &H45
        g_StrValTv(27).str = "0" + Chr(&H22) + "3"
        g_StrValTv(28).val = &H48
        g_StrValTv(28).str = "1/4"
        g_StrValTv(29).val = &H4B
        g_StrValTv(29).str = "1/5"
        g_StrValTv(30).val = &H4C
        g_StrValTv(30).str = "1/6"
        g_StrValTv(31).str = "1/6"
        g_StrValTv(31).str = "1/6"
        g_StrValTv(32).val = &H50
        g_StrValTv(32).str = "1/8"
        g_StrValTv(33).val = &H53
        g_StrValTv(33).str = "1/10"
        g_StrValTv(34).val = &H54
        g_StrValTv(34).str = "1/10"
        g_StrValTv(35).val = &H55
        g_StrValTv(35).str = "1/13"
        g_StrValTv(36).val = &H58
        g_StrValTv(36).str = "1/15"
        g_StrValTv(37).val = &H5C
        g_StrValTv(37).str = "1/20"
        g_StrValTv(38).val = &H5D
        g_StrValTv(38).str = "1/25"
        g_StrValTv(39).val = &H60
        g_StrValTv(39).str = "1/30"
        g_StrValTv(40).val = &H63
        g_StrValTv(40).str = "1/40"
        g_StrValTv(41).val = &H64
        g_StrValTv(41).str = "1/45"
        g_StrValTv(42).val = &H65
        g_StrValTv(42).str = "1/50"
        g_StrValTv(43).val = &H68
        g_StrValTv(43).str = "1/60"
        g_StrValTv(44).val = &H6B
        g_StrValTv(44).str = "1/80"
        g_StrValTv(45).val = &H6C
        g_StrValTv(45).str = "1/90"
        g_StrValTv(46).val = &H6D
        g_StrValTv(46).str = "1/100"
        g_StrValTv(47).val = &H70
        g_StrValTv(47).str = "1/125"
        g_StrValTv(48).val = &H73
        g_StrValTv(48).str = "1/160"
        g_StrValTv(49).val = &H74
        g_StrValTv(49).str = "1/180"
        g_StrValTv(50).val = &H75
        g_StrValTv(50).str = "1/200"
        g_StrValTv(51).val = &H78
        g_StrValTv(51).str = "1/250"
        g_StrValTv(52).val = &H7B
        g_StrValTv(52).str = "1/320"
        g_StrValTv(53).val = &H7C
        g_StrValTv(53).str = "1/350"
        g_StrValTv(54).val = &H7D
        g_StrValTv(54).str = "1/400"
        g_StrValTv(55).val = &H80
        g_StrValTv(55).str = "1/500"
        g_StrValTv(56).val = &H83
        g_StrValTv(56).str = "1/640"
        g_StrValTv(57).val = &H84
        g_StrValTv(57).str = "1/750"
        g_StrValTv(58).val = &H85
        g_StrValTv(58).str = "1/800"
        g_StrValTv(59).val = &H88
        g_StrValTv(59).str = "1/1000"
        g_StrValTv(60).val = &H8B
        g_StrValTv(60).str = "1/1250"
        g_StrValTv(61).val = &H8C
        g_StrValTv(61).str = "1/1500"
        g_StrValTv(62).val = &H8D
        g_StrValTv(62).str = "1/1600"
        g_StrValTv(63).val = &H90
        g_StrValTv(63).str = "1/2000"
        g_StrValTv(64).val = &H93
        g_StrValTv(64).str = "1/2500"
        g_StrValTv(65).val = &H94
        g_StrValTv(65).str = "1/3000"
        g_StrValTv(66).val = &H95
        g_StrValTv(66).str = "1/3200"
        g_StrValTv(67).val = &H98
        g_StrValTv(67).str = "1/4000"
        g_StrValTv(68).val = &H9B
        g_StrValTv(68).str = "1/5000"
        g_StrValTv(69).val = &H9C
        g_StrValTv(69).str = "1/6000"
        g_StrValTv(70).val = &H9D
        g_StrValTv(70).str = "1/6400"
        g_StrValTv(71).val = &HA0
        g_StrValTv(71).str = "1/8000"
        g_StrValTv(72).val = &HFFFFFFFF
        g_StrValTv(72).str = ""


    End Sub

#End Region


#Region "UserFunction"

    Public Function GetProp() As Integer

        Dim err As Integer = EDS_ERR_OK
        Dim tmpPropDesc As EdsPropertyDesc
        Dim dwVal As Integer
        Dim wkIntPtr As IntPtr
        Dim pChgStr As String
        Dim iCurSel As Integer
        Dim wkType As Integer
        Dim wkSize As Integer

        If m_deviceInfo.DeviceSubType = &H30 And _
             (m_CameraName <> "EOS 30D") Then
            '// 30D以前のカメラでPTPモードの時はプロパティの取得ができない。
            MessageBox.Show("この機能を使用する場合は、カメラの通信設定を「PC接続」に切替えて接続し直して下さい。")
            GetProp = -1
            Exit Function
        End If

        '// リスト項目のクリア。
        Me.AEModeCmb.Items.Clear()
        Me.ISOSpeedCmb.Items.Clear()
        Me.AvCmb.Items.Clear()
        Me.TvCmb.Items.Clear()

        '// カメラプロパティ取得
        err = EdsGetPropertyDesc(theCamera, kEdsPropID_AEMode, tmpPropDesc)
        LoadPropertyList(kEdsPropID_AEMode, Me.AEModeCmb, tmpPropDesc)

        'If tmpPropDesc.NumElements = 0 Then
        '    Return 0
        'End If

        err = EdsGetPropertyDesc(theCamera, kEdsPropID_ISOSpeed, tmpPropDesc)
        LoadPropertyList(kEdsPropID_ISOSpeed, Me.ISOSpeedCmb, tmpPropDesc)

        err = EdsGetPropertyDesc(theCamera, kEdsPropID_Av, tmpPropDesc)
        LoadPropertyList(kEdsPropID_Av, Me.AvCmb, tmpPropDesc)

        err = EdsGetPropertyDesc(theCamera, kEdsPropID_Tv, tmpPropDesc)
        LoadPropertyList(kEdsPropID_Tv, Me.TvCmb, tmpPropDesc)

        '// 現在のプロパティ値を取得

        '// ExposureProgram
        err = EdsGetPropertySize(theCamera, kEdsPropID_AEMode, 0, wkType, wkSize)
        wkIntPtr = Marshal.AllocHGlobal(4)
        err = EdsGetPropertyData(theCamera, kEdsPropID_AEMode, 0, 4, wkIntPtr)
        dwVal = CType(Marshal.PtrToStructure(wkIntPtr, GetType(Integer)), Integer)
        pChgStr = GetPropStr(kEdsPropID_AEMode, dwVal)
        iCurSel = Me.AEModeCmb.FindString(pChgStr)
        If pChgStr <> "" And iCurSel = &HFFFFFFFF Then
            iCurSel = Me.AEModeCmb.Items.Add(pChgStr)
            Me.AEModeCmb.SelectedIndex = iCurSel

        Else
            Me.AEModeCmb.SelectedIndex = iCurSel
        End If

        Marshal.FreeHGlobal(wkIntPtr)

        '// ISO Speed
        wkIntPtr = Marshal.AllocHGlobal(4)

        err = EdsGetPropertyData(theCamera, kEdsPropID_ISOSpeed, 0, 4, wkIntPtr)
        dwVal = CType(Marshal.PtrToStructure(wkIntPtr, GetType(Integer)), Integer)
        pChgStr = GetPropStr(kEdsPropID_ISOSpeed, dwVal)
        iCurSel = Me.ISOSpeedCmb.FindString(pChgStr)
        Me.ISOSpeedCmb.SelectedIndex = iCurSel

        Marshal.FreeHGlobal(wkIntPtr)



        '// Av
        wkIntPtr = Marshal.AllocHGlobal(4)

        err = EdsGetPropertyData(theCamera, kEdsPropID_Av, 0, 4, wkIntPtr)
        dwVal = CType(Marshal.PtrToStructure(wkIntPtr, GetType(Integer)), Integer)
        pChgStr = GetPropStr(kEdsPropID_Av, dwVal)
        iCurSel = Me.AvCmb.FindString(pChgStr)
        Me.AvCmb.SelectedIndex = iCurSel

        Marshal.FreeHGlobal(wkIntPtr)



        '// Tv
        wkIntPtr = Marshal.AllocHGlobal(4)

        err = EdsGetPropertyData(theCamera, kEdsPropID_Tv, 0, 4, wkIntPtr)
        dwVal = CType(Marshal.PtrToStructure(wkIntPtr, GetType(Integer)), Integer)
        pChgStr = GetPropStr(kEdsPropID_Tv, dwVal)
        iCurSel = TvCmb.FindString(pChgStr)
        TvCmb.SelectedIndex = iCurSel

        Marshal.FreeHGlobal(wkIntPtr)



        'Me.Update()
        Return EDS_ERR_OK

    End Function

    Private Sub LoadPropertyList(ByVal inPropID As Integer, ByVal inComboBox As System.Windows.Forms.ComboBox, _
    ByVal inPropertyDesc As EdsPropertyDesc)

        '// 画面上のコンボボックスにデータを表示。
        '// Descリストの値を表示用の文字列に変換する必要あり。
        '// データが1つもない場合はDisable
        Dim pChgStr As String
        Dim err As Integer
        Dim iCnt As Integer
        Dim iRightCount As Integer = 0

        For iCnt = 0 To inPropertyDesc.NumElements - 1
            pChgStr = GetPropStr(inPropID, inPropertyDesc.PropDesc(iCnt))
            If pChgStr <> Nothing Then
                err = inComboBox.Items.Add(pChgStr)
                iRightCount = iRightCount + 1
            End If
        Next
        If iRightCount = 0 Then
            inComboBox.Enabled = False '// 有効なアイテムが1つもない。
        Else
            inComboBox.Enabled = True
        End If

    End Sub


    Public Function GetPropStr(ByVal inPropID As Integer, ByVal inVal As Integer) As String

        Dim tbl As TPropStrVal()
        Dim tblCnt As Integer
        Dim iCnt As Integer
        tbl = GetPropStrValTbl(inPropID)

        tblCnt = ChkNum(inPropID)

        For iCnt = 0 To tblCnt - 1
            If tbl(iCnt).val = inVal Then
                Return tbl(iCnt).str
            End If
        Next

        Return String.Empty

    End Function


    Public Function GetPropVal(ByVal inPropID As Integer, ByVal inStr As String) As Integer
        Dim tbl As TPropStrVal()
        Dim tblCnt As Integer
        Dim iCnt As Integer

        tbl = GetPropStrValTbl(inPropID)
        tblCnt = ChkNum(inPropID)

        For iCnt = 0 To tblCnt - 1
            If tbl(iCnt).str = inStr Then
                Return tbl(iCnt).val
            End If
        Next

        Return &HFFFFFFFF

    End Function




    Public Function ChkNum(ByVal inPropID As Integer) As Integer
        Dim tbl As TPropStrVal()
        Dim iCnt As Integer = 0

        tbl = GetPropStrValTbl(inPropID)

        Do
            If tbl(iCnt).val = &HFFFFFFFF Then
                Return iCnt
            End If
            iCnt = iCnt + 1
        Loop

        Return &HFFFFFFFF

    End Function


    Public Function GetPropStrValTbl(ByVal inPropID As Integer) As TPropStrVal()

        Select Case inPropID
            Case kEdsPropID_AEMode
                Return g_StrValAEMode
            Case kEdsPropID_ISOSpeed
                Return g_StrValISOSpeed
            Case kEdsPropID_Av
                Return g_StrValAv
            Case kEdsPropID_Tv
                Return g_StrValTv
        End Select


        Return Nothing

    End Function



#End Region


    Private Sub TvCmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TvCmb.SelectedIndexChanged

        Dim err As Integer = EDS_ERR_OK
        'Dim iIndex As Integer = Me.TvCmb.SelectedIndex()
        Dim iVal As Integer
        Dim wkIntPtr As IntPtr = Marshal.AllocHGlobal(4)
        Dim buf As String

        buf = Me.TvCmb.SelectedItem
        iVal = GetPropVal(kEdsPropID_Tv, buf)

        Marshal.StructureToPtr(iVal, wkIntPtr, False)
        err = EdsSetState(theCamera, EdsCameraState.kEdsCameraState_UILock, 0)
        err = EdsSetPropertyData(theCamera, kEdsPropID_Tv, 0, 4, wkIntPtr)
        err = EdsSetState(theCamera, EdsCameraState.kEdsCameraState_UIUnLock, 0)

        Marshal.FreeHGlobal(wkIntPtr)
        '//GetProp() ;

    End Sub

    Private Sub AEModeCmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AEModeCmb.SelectedIndexChanged

        Dim err As Integer = EDS_ERR_OK
        'Dim iIndex As Integer = Me.AEModeCmb.SelectedIndex()
        Dim iVal As Integer
        Dim wkIntPtr As IntPtr = Marshal.AllocHGlobal(4)
        Dim buf As String

        buf = Me.AEModeCmb.SelectedItem
        iVal = GetPropVal(kEdsPropID_AEMode, buf)

        Marshal.StructureToPtr(iVal, wkIntPtr, False)
        err = EdsSetState(theCamera, EdsCameraState.kEdsCameraState_UILock, 0)
        err = EdsSetPropertyData(theCamera, kEdsPropID_AEMode, 0, 4, wkIntPtr)
        err = EdsSetState(theCamera, EdsCameraState.kEdsCameraState_UIUnLock, 0)

        Marshal.FreeHGlobal(wkIntPtr)

        '//GetProp() ;

    End Sub


    Private Sub ISOSpeedCmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ISOSpeedCmb.SelectedIndexChanged

        Dim err As Integer = EDS_ERR_OK
        Dim iVal As Integer
        Dim wkIntPtr As IntPtr = Marshal.AllocHGlobal(4)
        Dim buf As String

        buf = Me.ISOSpeedCmb.SelectedItem
        iVal = GetPropVal(kEdsPropID_ISOSpeed, buf)

        Marshal.StructureToPtr(iVal, wkIntPtr, False)
        err = EdsSetState(theCamera, EdsCameraState.kEdsCameraState_UILock, 0)
        err = EdsSetPropertyData(theCamera, kEdsPropID_ISOSpeed, 0, 4, wkIntPtr)
        err = EdsSetState(theCamera, EdsCameraState.kEdsCameraState_UIUnLock, 0)

        Marshal.FreeHGlobal(wkIntPtr)
        '//GetProp() ;

    End Sub


    Private Sub AvCmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvCmb.SelectedIndexChanged

        Dim err As Integer = EDS_ERR_OK
        Dim iIndex As Integer = Me.AvCmb.SelectedIndex()
        Dim iVal As Integer
        Dim wkIntPtr As IntPtr = Marshal.AllocHGlobal(4)
        Dim buf As String

        buf = Me.AvCmb.SelectedItem
        iVal = GetPropVal(kEdsPropID_Av, buf)
        Marshal.StructureToPtr(iVal, wkIntPtr, False)
        err = EdsSetState(theCamera, EdsCameraState.kEdsCameraState_UILock, 0)
        err = EdsSetPropertyData(theCamera, kEdsPropID_Av, 0, 4, wkIntPtr)
        err = EdsSetState(theCamera, EdsCameraState.kEdsCameraState_UIUnLock, 0)

        Marshal.FreeHGlobal(wkIntPtr)
        '//GetProp() ;

    End Sub

End Class

