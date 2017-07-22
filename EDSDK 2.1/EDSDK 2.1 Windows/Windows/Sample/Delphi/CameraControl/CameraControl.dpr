program CameraControl;

uses
  Forms,
  mainUnit in 'mainUnit.pas' {Form1},
  EDSDKType in 'EDSDKType.pas',
  EDSDKApi in 'EDSDKApi.pas',
  EDSDKError in 'EDSDKError.pas',
  camera in 'camera.pas',
  appmaster in 'appmaster.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.Title := 'EDSDK Sample for Delphi';
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
