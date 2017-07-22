object Form1: TForm1
  Left = 192
  Top = 607
  BorderStyle = bsDialog
  Caption = 'Take Picture for Delphi'
  ClientHeight = 354
  ClientWidth = 446
  Color = clBtnFace
  Font.Charset = SHIFTJIS_CHARSET
  Font.Color = clWindowText
  Font.Height = -12
  Font.Name = #65325#65331' '#65328#12468#12471#12483#12463
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  ShowHint = True
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  PixelsPerInch = 96
  TextHeight = 12
  object SpeedButton2: TSpeedButton
    Left = 352
    Top = 232
    Width = 57
    Height = 57
    Hint = 'Release | Send Release command to Camera.'
    Caption = 'Release'
    Enabled = False
    Glyph.Data = {
      76010000424D7601000000000000760000002800000020000000100000000100
      04000000000000010000120B0000120B00001000000000000000000000000000
      800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
      FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00333333000000
      033333FFFF77777773F330000077777770333777773FFFFFF733077777000000
      03337F3F3F777777733F0797A770003333007F737337773F3377077777778803
      30807F333333337FF73707888887880007707F3FFFF333777F37070000878807
      07807F777733337F7F3707888887880808807F333333337F7F37077777778800
      08807F333FFF337773F7088800088803308073FF777FFF733737300008000033
      33003777737777333377333080333333333333F7373333333333300803333333
      33333773733333333333088033333333333373F7F33333333333308033333333
      3333373733333333333333033333333333333373333333333333}
    Layout = blGlyphTop
    NumGlyphs = 2
    OnClick = SpeedButton2Click
  end
  object StatusBar1: TStatusBar
    Left = 0
    Top = 335
    Width = 446
    Height = 19
    AutoHint = True
    Panels = <>
    ParentShowHint = False
    ShowHint = True
    SimplePanel = True
  end
  object Panel1: TPanel
    Left = 12
    Top = 144
    Width = 301
    Height = 157
    BevelOuter = bvLowered
    ParentShowHint = False
    ShowHint = True
    TabOrder = 1
    object Label1: TLabel
      Left = 44
      Top = 20
      Width = 56
      Height = 16
      Hint = 'AE Mode'
      Caption = 'AE Mode'
      Font.Charset = ANSI_CHARSET
      Font.Color = clBlack
      Font.Height = -13
      Font.Name = 'Arial'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label2: TLabel
      Left = 76
      Top = 52
      Width = 16
      Height = 16
      Hint = 'Aperture Priority Mode'
      Caption = 'Av'
      Font.Charset = ANSI_CHARSET
      Font.Color = clBlack
      Font.Height = -13
      Font.Name = 'Arial'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label3: TLabel
      Left = 76
      Top = 88
      Width = 15
      Height = 16
      Hint = 'Shutter Priority Mode'
      Caption = 'Tv'
      Font.Charset = ANSI_CHARSET
      Font.Color = clBlack
      Font.Height = -13
      Font.Name = 'Arial'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label4: TLabel
      Left = 32
      Top = 124
      Width = 68
      Height = 16
      Caption = 'ISO Speed'
      Font.Charset = ANSI_CHARSET
      Font.Color = clBlack
      Font.Height = -13
      Font.Name = 'Arial'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object AeModeComboBox: TComboBox
      Left = 108
      Top = 16
      Width = 145
      Height = 24
      Hint = '| AE Mode'
      Font.Charset = ANSI_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'Arial'
      Font.Style = []
      ItemHeight = 16
      ParentFont = False
      TabOrder = 0
      Text = 'Program AE'
      OnChange = AeModeComboBoxChange
    end
    object AvComboBox: TComboBox
      Left = 108
      Top = 48
      Width = 145
      Height = 24
      Hint = '| Aperture Priority Mode'
      Font.Charset = ANSI_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'Arial'
      Font.Style = []
      ItemHeight = 16
      ParentFont = False
      TabOrder = 1
      Text = '1'
      OnChange = AvComboBoxChange
    end
    object TvComboBox: TComboBox
      Left = 108
      Top = 84
      Width = 145
      Height = 24
      Hint = '| Shutter Priority Mode'
      Font.Charset = ANSI_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'Arial'
      Font.Style = []
      ItemHeight = 16
      ParentFont = False
      TabOrder = 2
      Text = 'Bulb'
      OnChange = TvComboBoxChange
    end
    object ISOComboBox: TComboBox
      Left = 108
      Top = 120
      Width = 145
      Height = 24
      Hint = '| ISO Speed'
      Font.Charset = ANSI_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'Arial'
      Font.Style = []
      ItemHeight = 16
      ParentFont = False
      TabOrder = 3
      Text = '6'
      OnChange = ISOComboBoxChange
    end
  end
  object Panel2: TPanel
    Left = 8
    Top = 60
    Width = 417
    Height = 49
    Hint = '| Specify folder name restoring image file from camera.'
    BevelOuter = bvLowered
    TabOrder = 2
    object Label5: TLabel
      Left = 20
      Top = 16
      Width = 77
      Height = 16
      Caption = 'Save Folder'
      Font.Charset = ANSI_CHARSET
      Font.Color = clBlue
      Font.Height = -13
      Font.Name = 'Arial'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object SpeedButton1: TSpeedButton
      Left = 368
      Top = 12
      Width = 23
      Height = 22
      Caption = '...'
      OnClick = SpeedButton1Click
    end
    object Edit1: TEdit
      Left = 108
      Top = 12
      Width = 249
      Height = 21
      Font.Charset = SHIFTJIS_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'MS UI Gothic'
      Font.Style = []
      ParentFont = False
      TabOrder = 0
      OnChange = Edit1Change
    end
  end
  object StaticText1: TStaticText
    Left = 8
    Top = 120
    Width = 102
    Height = 20
    Caption = 'Camera Setting :'
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Arial'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
  end
  object ProgressBar1: TProgressBar
    Left = 12
    Top = 308
    Width = 417
    Height = 17
    Min = 0
    Max = 100
    Smooth = True
    TabOrder = 4
  end
  object Panel3: TPanel
    Left = 0
    Top = 0
    Width = 446
    Height = 53
    Align = alTop
    BevelOuter = bvNone
    Color = clWhite
    TabOrder = 5
    object Label6: TLabel
      Left = 16
      Top = 8
      Width = 307
      Height = 15
      Caption = 'Please select save folder and modify camera settings.'
      Font.Charset = ANSI_CHARSET
      Font.Color = clWindowText
      Font.Height = -12
      Font.Name = 'Arial'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label7: TLabel
      Left = 16
      Top = 32
      Width = 382
      Height = 15
      Caption = 
        'Then press Release button.  You can also operate the camera itse' +
        'lf.'
      Font.Charset = ANSI_CHARSET
      Font.Color = clWindowText
      Font.Height = -12
      Font.Name = 'Arial'
      Font.Style = [fsBold]
      ParentFont = False
    end
  end
  object ApplicationEvents1: TApplicationEvents
    OnMessage = ApplicationEvents1Message
    Left = 400
    Top = 120
  end
end
