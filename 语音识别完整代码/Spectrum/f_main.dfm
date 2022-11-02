object MainForm: TMainForm
  Left = 172
  Top = 114
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = #27874#24418'/'#39057#35889
  ClientHeight = 476
  ClientWidth = 834
  Color = clBlack
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnCloseQuery = FormCloseQuery
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object View: TPaintBox
    Left = 8
    Top = 8
    Width = 817
    Height = 401
    Color = clBlack
    Font.Charset = ANSI_CHARSET
    Font.Color = clWhite
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentColor = False
    ParentFont = False
    OnMouseMove = ViewMouseMove
  end
  object Label1: TLabel
    Left = 712
    Top = 456
    Width = 113
    Height = 13
    Cursor = crHandPoint
    Caption = 'http://nowcan.yeah.net'
    Color = clBlack
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clAqua
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentColor = False
    ParentFont = False
    OnClick = Label1Click
  end
  object RadioView: TRadioGroup
    Left = 8
    Top = 424
    Width = 177
    Height = 41
    Caption = #26597#30475' '#27874#24418'/'#39057#35889
    Columns = 2
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clLime
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ItemIndex = 0
    Items.Strings = (
      #27874#24418
      #39057#35889)
    ParentFont = False
    TabOrder = 0
  end
end
