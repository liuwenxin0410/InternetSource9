//---------------------------------------------------------------------------
#ifndef f_mainH
#define f_mainH

//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <mmsystem.h>
#include <ExtCtrls.hpp>
#include "SpectrumThread.h"
#include "TimeThread.h"

//---------------------------------------------------------------------------
class TMainForm :
    public TForm
{
__published:    // IDE-managed Components
    TPaintBox       *View;
    TRadioGroup     *RadioView;
    TLabel *Label1;
    void __fastcall FormCreate(TObject *Sender);
    void __fastcall FormCloseQuery(TObject *Sender, bool &CanClose);
    void __fastcall ViewMouseMove(TObject *Sender, TShiftState Shift, int X, int Y);
    void __fastcall Label1Click(TObject *Sender);

/* */
private:    // User declarations
    void __fastcall WndProc(TMessage &Message);
    void __fastcall ProcessInput(void);
    HWAVEIN         hWaveIn;
    WAVEHDR         *WaveHeaders;
    WAVEFORMATEX    waveFormat;

    int             buff;
    int             buffers;
    int             buffer_size;
    int             WaveBufSize;
    WAVEHDR         *SendHeader;
    bool            isStart;
    TimeThread      *timethread;
    SpectrumThread  *spectrumthread;

/* */
public: // User declarations
    __fastcall      TMainForm(TComponent *Owner);
};

//---------------------------------------------------------------------------
extern PACKAGE TMainForm    *MainForm;

//---------------------------------------------------------------------------
#endif
