{******************************************************************************
*                                                                             *
*   PROJECT : EOS Digital Software Development Kit EDSDK                      *
*      NAME : mainUnit.pas                                                    *
*                                                                             *
*   Description: This is the Sample code to show the usage of EDSDK.          *
*                This project is for VCL for WIN32. So, Available delphi      *
*                version is Delphi6,7,8,Delphi2005, BDS2006.                  *
*                                                                             *
*******************************************************************************
*                                                                             *
*   Written and developed by Camera Design Dept.53                            *
*   Copyright Canon Inc. 2006 All Rights Reserved                             *
*                                                                             *
*******************************************************************************
*   File Update Information:                                                  *
*     DATE      Identify    Comment                                           *
*   -----------------------------------------------------------------------   *
*   06-03-22    F-001        create first version.                            *
*                                                                             *
******************************************************************************}
unit mainUnit;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, EDSDKApi, EDSDKType, EDSDKError, appmaster, ComCtrls, StdCtrls,
  Buttons, ExtCtrls, AppEvnts;

type
  TPropList = record
    PropStr : string;
    PropID : EdsUInt32;
  end;
  PPropList = ^TPropList;


  TForm1 = class(TForm)
    StatusBar1: TStatusBar;
    AeModeComboBox: TComboBox;
    Label1: TLabel;
    Panel1: TPanel;
    AvComboBox: TComboBox;
    Label2: TLabel;
    Label3: TLabel;
    TvComboBox: TComboBox;
    Label4: TLabel;
    ISOComboBox: TComboBox;
    Panel2: TPanel;
    Label5: TLabel;
    Edit1: TEdit;
    SpeedButton2: TSpeedButton;
    StaticText1: TStaticText;
    ProgressBar1: TProgressBar;
    SpeedButton1: TSpeedButton;
    Panel3: TPanel;
    Label6: TLabel;
    Label7: TLabel;
    ApplicationEvents1: TApplicationEvents;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure SpeedButton1Click(Sender: TObject);
    procedure ApplicationEvents1Message(var Msg: tagMSG;
      var Handled: Boolean);
    procedure ISOComboBoxChange(Sender: TObject);
    procedure AeModeComboBoxChange(Sender: TObject);
    procedure AvComboBoxChange(Sender: TObject);
    procedure TvComboBoxChange(Sender: TObject);
    procedure SpeedButton2Click(Sender: TObject);
    procedure Edit1Change(Sender: TObject);

  private
    { Private êÈåæ }
    FAppMaster : TAppMaster;

    procedure initAeModeCombo;
    procedure initAvCombo;
    procedure initTvCombo;
    procedure initIsoCombo;
    procedure initFolder;

    function findAeModeComboItemIndex( value : EdsUInt32 ) : Integer;
    function findTvComboItemIndex( value : EdsUInt32 ) : Integer;
    function findAvComboItemIndex( value : EdsUInt32 ) : Integer;
    function findIsoComboItemIndex( value : EdsUInt32 ) : Integer;

    function findAeModePropIndex( value : EdsUInt32 ) : Integer;
    function findAvPropIndex( value : EdsUInt32 ) : Integer;
    function findTvPropIndex( value : EdsUInt32 ) : Integer;
    function findIsoPropIndex( value : EdsUInt32 ) : Integer;

    procedure UpdatePropertyDesc( id : EdsUInt32 );
    procedure UpdateProperty( id : EdsUInt32 );

  public
    { Public êÈåæ }

  end;

var
  Form1: TForm1;
  
  {      all available camera setting       }
  { ----------------------------------------}
  { This sampel uses the following property }
  const AeModeProp : array[ 0..16 ] of TPropList = (
    ( PropStr: 'P' ; PropID: 0 ),
    ( PropStr: 'Tv' ; PropID: 1 ),
    ( PropStr: 'Av' ; PropID: 2 ),
    ( PropStr: 'M' ; PropID: 3 ),
    ( PropStr: 'Bulb' ; PropID: 4 ),
    ( PropStr: 'A-DEP' ; PropID: 5 ),
    ( PropStr: 'DEP' ; PropID: 6 ),
    ( PropStr: 'C' ; PropID: 7 ),
    ( PropStr: 'Lock' ; PropID: 8 ),
    ( PropStr: 'Green Mode' ; PropID: 9 ),
    ( PropStr: 'Night Portrait' ; PropID: 10 ),
    ( PropStr: 'Sports' ; PropID: 11 ),
    ( PropStr: 'Portrait' ; PropID: 12 ),
    ( PropStr: 'Landscape' ; PropID: 13 ),
    ( PropStr: 'Close Up' ; PropID: 14 ),
    ( PropStr: 'Disable Strobe' ; PropID: 15 ),
    ( PropStr: 'Unknown' ; PropID: $FFFFFFFF )
  );

  const AvProp : array[ 0..53] of TPropList = (
    ( PropStr: '1.0'; PropID: $08 ), ( PropStr: '1.1'; PropID: $0B ), ( PropStr: '1.2'; PropID: $0C ),
    ( PropStr: '1.2'; PropID: $0D ), ( PropStr: '1.4'; PropID: $10 ), ( PropStr: '1.6'; PropID: $13 ),
    ( PropStr: '1.8'; PropID: $14 ), ( PropStr: '1.8'; PropID: $15 ), ( PropStr: '2.0'; PropID: $18 ),
    ( PropStr: '2.2'; PropID: $1B ), ( PropStr: '2.5'; PropID: $1C ), ( PropStr: '2.5'; PropID: $1D ),
    ( PropStr: '2.8'; PropID: $20 ), ( PropStr: '3.2'; PropID: $23 ), ( PropStr: '3.5'; PropID: $24 ),
    ( PropStr: '3.5'; PropID: $25 ), ( PropStr: '4'  ; PropID: $28 ), ( PropStr: '4';   PropID: $2B ),
    ( PropStr: '4.5'; PropID: $2C ), ( PropStr: '5'  ; PropID: $2D ), ( PropStr: '5.6'; PropID: $30 ),
    ( PropStr: '6.3'; PropID: $33 ), ( PropStr: '6.7'; PropID: $34 ), ( PropStr: '7.1'; PropID: $35 ),
    ( PropStr: '8'  ; PropID: $38 ), ( PropStr: '9'  ; PropID: $3B ), ( PropStr: '9.5'; PropID: $3C ),
    ( PropStr: '10';  PropID: $3D ), ( PropStr: '11';  PropID: $40 ), ( PropStr: '13';  PropID: $43 ),
    ( PropStr: '13';  PropID: $44 ), ( PropStr: '14';  PropID: $45 ), ( PropStr: '16';  PropID: $48 ),
    ( PropStr: '18';  PropID: $4B ), ( PropStr: '19';  PropID: $4C ), ( PropStr: '20';  PropID: $4D ),
    ( PropStr: '22';  PropID: $50 ), ( PropStr: '25';  PropID: $53 ), ( PropStr: '27';  PropID: $54 ),
    ( PropStr: '29';  PropID: $55 ), ( PropStr: '32';  PropID: $58 ), ( PropStr: '36';  PropID: $5B ),
    ( PropStr: '38';  PropID: $5C ), ( PropStr: '40';  PropID: $5D ), ( PropStr: '45';  PropID: $60 ),
    ( PropStr: '51';  PropID: $63 ), ( PropStr: '54';  PropID: $64 ), ( PropStr: '57';  PropID: $65 ),
    ( PropStr: '64';  PropID: $68 ), ( PropStr: '72';  PropID: $6B ), ( PropStr: '76';  PropID: $6C ),
    ( PropStr: '80';  PropID: $6D ), ( PropStr: '91';  PropID: $70 ), ( PropStr: 'Unknown'; PropID: $FFFFFFFF )
  );

  const TvProp : array[ 0.. 74] of TPropList = (
    ( PropStr:'Bulb'; PropID: $0C ), ( PropStr:'30"'; PropID: $10 ), ( PropStr:'25"'; PropID: $13 ),
    ( PropStr:'20"';  PropID: $14 ), ( PropStr:'20"'; PropID: $15 ), ( PropStr:'15"'; PropID: $18 ),
    ( PropStr:'13"';  PropID: $1B ), ( PropStr:'10"'; PropID: $1C ), ( PropStr:'10"'; PropID: $1D ),
    ( PropStr:' 8"';  PropID: $20 ), ( PropStr:'6"' ; PropID: $23 ), ( PropStr:'6"' ; PropID: $24 ),
    ( PropStr:'5"';   PropID: $25 ), ( PropStr:'4"' ; PropID: $28 ), ( PropStr:'3"2'; PropID: $2B ),
    ( PropStr:'3"';   PropID: $2C ), ( PropStr:'2"5'; PropID: $2D ), ( PropStr:'2"' ; PropID: $30 ),
    ( PropStr:'1"6';  PropID: $33 ), ( PropStr:'1"5'; PropID: $34 ), ( PropStr:'1"3'; PropID: $35 ),
    ( PropStr:'1"';   PropID: $38 ), ( PropStr:'0"8'; PropID: $3B ), ( PropStr:'0"7'; PropID: $3C ),
    ( PropStr:'0"6';  PropID: $3D ), ( PropStr:'0"5'; PropID: $40 ), ( PropStr:'0"4'; PropID: $43 ),
    ( PropStr:'0"3';  PropID: $44 ), ( PropStr:'0"3'; PropID: $45 ), ( PropStr:'4';   PropID: $48 ),
    ( PropStr:'5';    PropID: $4B ), ( PropStr:'6';   PropID: $4C ), ( PropStr:'6';   PropID: $4D ),
    ( PropStr:'8';    PropID: $50 ), ( PropStr:'10';  PropID: $53 ), ( PropStr:'10';  PropID: $54 ),
    ( PropStr:'13';   PropID: $55 ), ( PropStr:'15';  PropID: $58 ), ( PropStr:'20';  PropID: $5B ),
    ( PropStr:'20';   PropID: $5C ), ( PropStr:'25';  PropID: $5D ), ( PropStr:'30';  PropID: $60 ),
    ( PropStr:'40';   PropID: $63 ), ( PropStr:'45';  PropID: $64 ), ( PropStr:'50';  PropID: $65 ),
    ( PropStr:'60';   PropID: $68 ), ( PropStr:'80';  PropID: $6B ), ( PropStr:'90';  PropID: $6C ),
    ( PropStr:'100';  PropID: $6D ), ( PropStr:'125'; PropID: $70 ), ( PropStr:'160'; PropID: $73 ),
    ( PropStr:'180';  PropID: $74 ), ( PropStr:'200'; PropID: $75 ), ( PropStr:'250'; PropID: $78 ),
    ( PropStr:'320';  PropID: $7B ), ( PropStr:'350'; PropID: $7C ), ( PropStr:'400'; PropID: $7D ),
    ( PropStr:'500';  PropID: $80 ), ( PropStr:'640'; PropID: $83 ), ( PropStr:'750'; PropID: $84 ),
    ( PropStr:'800';  PropID: $85 ), ( PropStr:'1000';PropID: $88 ), ( PropStr:'1250';PropID: $8B ),
    ( PropStr:'1500'; PropID: $8C ), ( PropStr:'1600';PropID: $8D ), ( PropStr:'2000';PropID: $90 ),
    ( PropStr:'2500'; PropID: $93 ), ( PropStr:'3000';PropID: $94 ), ( PropStr:'3200';PropID: $95 ),
    ( PropStr:'4000'; PropID: $98 ), ( PropStr:'5000';PropID: $9B ), ( PropStr:'6000';PropID: $9C ),
    ( PropStr:'6400'; PropID: $9D ), ( PropStr:'8000';PropID: $A0 ), ( PropStr:'Unknown'; PropID: $FFFFFFFF )
  );

  const IsoProp : array[0..19 ] of TPropList = (
    ( PropStr: '6'   ; PropID: $28 ),
    ( PropStr: '12'  ; PropID: $30 ),
    ( PropStr: '25'  ; PropID: $38 ),
    ( PropStr: '50'  ; PropID: $40 ),
    ( PropStr: '100' ; PropID: $48 ),
    ( PropStr: '125' ; PropID: $4B ),
    ( PropStr: '160' ; PropID: $4D ),
    ( PropStr: '200' ; PropID: $50 ),
    ( PropStr: '250' ; PropID: $53 ),
    ( PropStr: '320' ; PropID: $55 ),
    ( PropStr: '400' ; PropID: $58 ),
    ( PropStr: '500' ; PropID: $5B ),
    ( PropStr: '640' ; PropID: $5D ),
    ( PropStr: '800' ; PropID: $60 ),
    ( PropStr: '1000' ; PropID: $63 ),
    ( PropStr: '1250' ; PropID: $65 ),
    ( PropStr: '1600' ; PropID: $68 ),
    ( PropStr: '3200' ; PropID: $70 ),
    ( PropStr: '6400' ; PropID: $78 ),
    ( PropStr: 'Unknown' ; PropID: $FFFFFFFF )
  );

implementation

uses shellapi, shlobj, ActiveX;

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var name : string;
begin
  initAeModeCombo;
  initAvCombo;
  initTvCombo;
  initIsoCombo;
  initFolder;
  
  FAppMaster := TAppMaster.Create( Form1.Handle );

  FAppMaster.getCameraName( name );
  StatusBar1.SimpleText := 'Camera : '+ name;

  { start to get "notify event" }
  FAppMaster.setEventCallback;

  { connect camera }
  FAppMaster.enableConnection;
  FAppMaster.saveSetting;

  if FAppMaster.getCameraObject = nil then begin
    SpeedButton1.Enabled := false;
    SpeedButton2.Enabled := false;
    AeModeComboBox.Enabled := false;
    AvComboBox.Enabled := false;
    TvComboBox.Enabled := false;
    ISOComboBOx.Enabled := false;
    Exit;
  end;

end;

procedure TForm1.FormDestroy(Sender: TObject);
begin
  FAppMaster.Free;
end;

{ ----------------------------------------------------------------------------}

{ process of handling 'select folder' button }
procedure TForm1.SpeedButton1Click(Sender: TObject);
var
  BrowseInfo: TBrowseInfo;
  FolderName, FolderPath: array[0..MAX_PATH] of Char;
  pidl: PItemIDList;
  lpMalloc: IMalloc;
begin
  if FAILED( SHGetMalloc( lpMalloc ) ) then exit;   { get shell task allocator }

  with BrowseInfo do                                { initialize TBrowseInfo structure }
  begin
    hwndOwner := Handle;
    pidlRoot := Nil;
    pszDisplayName := FolderName;
    lpszTitle := 'Select folder...';
    ulFlags := BIF_RETURNONLYFSDIRS or $0040;
    lpfn := Nil;
  end;

  pidl := SHBrowseForFolder( BrowseInfo);
  if pidl = Nil then exit;

  SHGetPathFromIDList( pidl, FolderPath );          { get full path name here! }

  Edit1.Text := FolderPath;
  FAppMaster.filePath := FolderPath;

  lpMalloc.Free(pidl);                              { release by using shell task allocator }

end;

{ process of handling new selection on each ComboBox }
procedure TForm1.ISOComboBoxChange(Sender: TObject);
var select : integer;
    prop : PPropList;
    err : EdsError;
begin
  { get ProprtyID from PropList }
  select := ISOComboBox.ItemIndex;
  prop := PPropList(ISOComboBox.Items.Objects[select]);

  err := FAppMaster.setProperty( kEdsPropID_ISOSpeed, prop^.PropID );
  if err <> EDS_ERR_OK then begin
    { show error message }
    ShowMessage( 'Cannot set new value...' );

    { set back to previous setting }
    UpdateProperty( kEdsPropID_ISOSpeed );
  end;
end;

procedure TForm1.AeModeComboBoxChange(Sender: TObject);
var select : integer;
    prop : PPropList;
    err : EdsError;
begin
  { get ProprtyID from PropList }
  select := AeModeComboBox.ItemIndex;
  prop := PPropList(AeModeComboBox.Items.Objects[select]);

  err := FAppMaster.setProperty( kEdsPropID_AeMode, prop^.PropID );
  if err <> EDS_ERR_OK then begin
    { show error message }
    ShowMessage( 'Cannot set new value...' );

    { set back to previous setting }
    UpdateProperty( kEdsPropID_AeMode );
  end;
end;

procedure TForm1.AvComboBoxChange(Sender: TObject);
var select : integer;
    prop : PPropList;
    err : EdsError;
begin
 { get ProprtyID from PropList }
  select := AvComboBox.ItemIndex;
  prop := PPropList(AvComboBox.Items.Objects[select]);

  err := FAppMaster.setProperty( kEdsPropID_Av, prop^.PropID );
  if err <> EDS_ERR_OK then begin
    { show error message }
    ShowMessage( 'Cannot set new value...' );

    { set back to previous setting }
    UpdateProperty( kEdsPropID_Av );
  end;
end;

procedure TForm1.TvComboBoxChange(Sender: TObject);
var select : integer;
    prop : PPropList;
    err : EdsError;
begin
 { get ProprtyID from PropList }
  select := TvComboBox.ItemIndex;
  prop := PPropList(TvComboBox.Items.Objects[select]);

  err := FAppMaster.setProperty( kEdsPropID_Tv, prop^.PropID );
  if err <> EDS_ERR_OK then begin
    { show error message }
    ShowMessage( 'Cannot set new value...' );

    { set back to previous setting }
    UpdateProperty( kEdsPropID_Tv );
  end;
end;

{ process of handling 'Release' button }
procedure TForm1.SpeedButton2Click(Sender: TObject);
var err : EdsError;
begin
  { send command }
  err := FAppMaster.takePicture;
  if err <> EDS_ERR_OK then begin
    StatusBar1.SimpleText := 'Failed to take picture...';
  end;
end;

{ process of handling file path to save picture }
procedure TForm1.Edit1Change(Sender: TObject);
begin
  if Edit1.Text <> '' then
    SpeedButton2.Enabled := true;

end;

{----------------------------------------------------------------------------}
{    Message Hook Procedure :        Delphi6 later!!!                        }
{----------------------------------------------------------------------------}
procedure TForm1.ApplicationEvents1Message(var Msg: tagMSG;
  var Handled: Boolean);
var err: EdsError;
begin
  Handled := false;
  Case Msg.message of
    WM_USER+1: { Property Event occurred }
      begin
        if Msg.wParam = kEdsPropertyEvent_PropertyChanged then
          // get property
          begin
            FAppMaster.getProperty( Msg.lParam );
            UpdateProperty( Msg.lParam );
            Handled := true;
          end;

        if Msg.wParam = kEdsPropertyEvent_PropertyDescChanged then
          // get property desc
          begin
            FAppMaster.getPropertyDesc( Msg.lParam );
            UpdatePropertyDesc( Msg.lParam );
            Handled := true;
          end;
      end;

    WM_USER+2: { Object Event occurred }
      begin
        err:= FAppMaster.getImageData( EdsBaseRef(Msg.lParam), Edit1.Text );
        if err <> EDS_ERR_OK then
          StatusBar1.SimpleText := 'Download error occurred!';

        Handled := true;
      end;

    WM_USER+3: { Progress callback event }
      begin
        ProgressBar1.Position := Msg.wParam;
        if ProgressBar1.Position = 100 then begin
          Sleep(500);
          ProgressBar1.Position := 0;
        end;
        Handled := true;
      end;

  end;

end;

{------------------------------------------------------------------}
{                  Private Procedures / Functions                  }
{------------------------------------------------------------------}

{ process of handling to get new property data }
procedure TForm1.UpdateProperty( id: EdsUInt32 );
var  index : integer;
     value : EdsUInt32;
begin
  { get value from data in TCamera object }
  value := FAppMaster.getCameraObject.getPropertyUInt32( id );
  Case id of
    kEdsPropID_AEMode:
      begin
        index := findAeModeComboItemIndex( value );
        AeModeComboBox.ItemIndex := index;
      end;
    kEdsPropID_Tv:
      begin
        index := findTvComboItemIndex( value );
        TvComboBox.ItemIndex := index;
      end;
    kEdsPropID_Av:
      begin
        index := findAvComboItemIndex( value );
        AvComboBox.ItemIndex := index;
      end;
    kEdsPropID_ISOSpeed:
      begin
        index := findIsoComboItemIndex( value );
        IsoComboBox.ItemIndex := index;
      end;
  end;
end;

{ process of handling to get new property description data }
procedure TForm1.UpdatePropertyDesc( id: EdsUInt32 );
var desc : EdsPropertyDesc;
    i, j, k, temp : integer;
    current, val  : EdsUInt32;
begin
  { get desc from data in TCamera object }
  desc := FAppMaster.getCameraObject.getPropertyDesc( id );

  current := $FFFFFFFF; { default : "Unknown" }

  Case id of
    kEdsPropID_AEMode:
      begin
        { save current AE Mode setting }
        temp := AeModeComboBox.ItemIndex;
        if temp <> -1 then
          current := PPropList( AeModeComboBox.Items.Objects[ temp ] )^.PropID;

        { refill available AeMode value }
        for i := 0  to desc.numElements -1 do begin
          val := desc.propDesc[i];
          j := findAeModePropIndex( val );
          AeModeComboBox.Items.AddObject( AeModeProp[j].PropStr, @TvProp[j] );
        end;
        { re-set current setting }
        k := findAeModeComboItemIndex( current );
        AeModeComboBox.ItemIndex := k;
      end;

    kEdsPropID_Tv:
      begin
        { save current Tv value }
        if TvComboBox.Enabled then begin
          temp := TvComboBox.ItemIndex;
          if temp <> -1 then
            current := PPropList( TvComboBox.Items.Objects[ temp ] )^.PropID;
          TvComboBox.Clear;
        end;

        { refill available Tv value }
        for i := 0  to desc.numElements -1 do begin
          val := desc.propDesc[i];
          j := findTvPropIndex( val );
          TvComboBox.Items.AddObject( TvProp[j].PropStr, @TvProp[j] );
        end;
        { re-set current setting }
        k := findTvComboItemIndex( current );
        TvComboBox.ItemIndex := k;
      end;

    kEdsPropID_Av:
      begin
        { save current Av setting }
        if AvComboBox.Enabled then begin
          temp := AvComboBox.ItemIndex;
          if temp <> -1 then
            current := PPropList( AvComboBox.Items.Objects[ temp ] )^.PropID;
          AvComboBox.Clear;
        end;

        { refill available Av value }
        for i := 0  to desc.numElements -1 do begin
          val := desc.propDesc[i];
          j := findAvPropIndex( val );
          AvComboBox.Items.AddObject( AvProp[j].PropStr, @AvProp[j] );
        end;

        { re-set current setting }
        k := findAvComboItemIndex( current );
        AvComboBox.ItemIndex := k;
      end;

    kEdsPropID_IsoSpeed:
      begin
        { save current ISO setting }
        if IsoComboBox.Enabled then begin
          temp := IsoComboBox.ItemIndex;
          if temp <> -1 then
            current := PPropList( IsoComboBox.Items.Objects[ temp ] )^.PropID;
          IsoComboBox.Clear;
        end;

        { refill available ISO value }
        for i := 0  to desc.numElements -1 do begin
          val := desc.propDesc[i];
          j := findIsoPropIndex( val );
          IsoComboBox.Items.AddObject( IsoProp[j].PropStr, @IsoProp[j] );
        end;

        if IsoComboBox.Enabled then begin
          k := findIsoComboItemIndex( current );
          IsoComboBox.ItemIndex := k;
        end;
      end;
  end;
end;


{ process of initializing screen compornents }
procedure TForm1.initFolder;
begin
  Edit1.Text := ExtractFilePath( Application.ExeName );
end;

procedure TForm1.initAeModeCombo;
var i : integer;
begin
  AeModeComboBox.Tag := kEdsPropID_AEMode;
  for i := 0 to 16 do
    AeModeComboBox.Items.AddObject( AeModeProp[i].PropStr, @AeModeProp[i] );

  AeModeComboBox.ItemIndex := 16;
end;

procedure TForm1.initAvCombo;
var i : integer;
begin
  AvComboBox.Tag := kEdsPropID_Av;
  for i := 0 to 53 do
    AvComboBox.Items.AddObject( AvProp[i].PropStr, @AvProp[i] );

  AvComboBox.ItemIndex := 53;
end;

procedure TForm1.initTvCombo;
var i : integer;
begin
  TvComboBox.Tag := kEdsPropID_Tv;
  for i := 0 to 74 do begin
    TvComboBox.Items.AddObject( TvProp[i].PropStr, @TvProp[i] );
  end;

  TvComboBox.ItemIndex := 74;
end;

procedure TForm1.initIsoCombo;
var i : integer;
begin
  IsoComboBox.Tag := kEdsPropID_ISOSpeed;
  for i := 0 to 19 do
    IsoComboBox.Items.AddObject( IsoProp[i].PropStr, @IsoProp[i] );

  IsoComboBox.ItemIndex := 19;
end;


{ process of geting index number from Property combobox using property id }
function TForm1.findAeModeComboItemIndex(value: EdsUInt32): Integer;
var i : integer;
begin
  for i := 0 to AeModeComboBox.Items.Count-1 do begin
    if PPropList( AeModeComboBox.Items.Objects[i])^.PropID = value then
      Break;
  end;
  Result := i;
end;

function TForm1.findTvComboItemIndex(value: EdsUInt32): Integer;
var i : integer;
begin
  for i := 0 to TvComboBox.Items.Count-1 do begin
    if PPropList( TvComboBox.Items.Objects[i])^.PropID = value then
      Break
  end;
  Result := i;
end;

function TForm1.findAvComboItemIndex(value: EdsUInt32): Integer;
var i : integer;
begin
  for i := 0 to AvComboBox.Items.Count-1 do begin
    if PPropList( AvComboBox.Items.Objects[i])^.PropID = value then
      Break;
  end;
  Result := i;
end;

function TForm1.findIsoComboItemIndex(value: EdsUInt32): Integer;
var i : integer;
begin
  for i := 0 to IsoComboBox.Items.Count-1 do begin
    if PPropList( IsoComboBox.Items.Objects[i])^.PropID = value then
      Break;
  end;
  Result := i;
end;

{ process of finding index number in TPropList array }
function TForm1.findAeModePropIndex(value: EdsUInt32): integer;
var i : integer;
begin
  Result := 16;
  for i := 0 to 16 do begin
    if AeModeProp[i].PropID = value then
      Result := i
  end;
end;

function TForm1.findAvPropIndex( value: EdsUInt32): integer;
var i : integer;
begin
  Result := 53;
  for i := 0 to 53 do begin
    if AvProp[i].PropID = value then
      Result := i
  end;
end;

function TForm1.findTvPropIndex(value: EdsUInt32): integer;
var i : integer;
begin
  Result := 74;
  for i := 0 to 74 do begin
    if TvProp[i].PropID = value then
      Result := i
  end;
end;

function TForm1.findIsoPropIndex(value: EdsUInt32): integer;
var i : integer;
begin
  Result := 19;
  for i := 0 to 19 do begin
    if IsoProp[i].PropID = value then
      Result := i;
  end;
end;

end.
