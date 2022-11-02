//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "f_main.h"

//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TMainForm   *MainForm;

//---------------------------------------------------------------------------
__fastcall TMainForm::TMainForm(TComponent *Owner) :
    TForm(Owner)
{
}

//---------------------------------------------------------------------------
void __fastcall TMainForm::WndProc(TMessage &Message)
{
    if(Message.Msg == MM_WIM_DATA)
    {
        this->ProcessInput();
    }

    TForm::WndProc(Message);    //其他的消息继续传递下去
}

//---------------------------------------------------------------------------
void __fastcall TMainForm::ProcessInput(void)
{
    //  Prepare data buffer
    if(isStart)
    {
        WAVEHDR *in= &WaveHeaders[buff];
        ::waveInUnprepareHeader(hWaveIn, in, sizeof(WAVEHDR));

        //  Update views
        switch(RadioView->ItemIndex)
        {
            case 0: timethread->Process((short *)(in->lpData)); break;
            case 1: spectrumthread->Process((short *)(in->lpData)); break;
        }

        //  Send next buffer;
        buff++;
        if(buff == buffers) buff=0;
        SendHeader->dwBufferLength=WaveBufSize;
        SendHeader->dwFlags=0;
        SendHeader->dwLoops=0;
        ::waveInPrepareHeader(hWaveIn, SendHeader, sizeof(WAVEHDR));
        ::waveInAddBuffer(hWaveIn, SendHeader, sizeof(WAVEHDR));
        if(SendHeader == &WaveHeaders[buffers - 1])
            SendHeader= &WaveHeaders[0];
        else
            SendHeader++;
    }
}

//---------------------------------------------------------------------------
void __fastcall TMainForm::FormCreate(TObject *Sender)
{
    MMRESULT    res;
    char        ErrText[MAXERRORLENGTH + 1];
    buffers=8;
    buffer_size=2048;
    buff=0;
    waveFormat.wFormatTag=WAVE_FORMAT_PCM;
    waveFormat.nChannels=2;
    waveFormat.nSamplesPerSec=44100;
    waveFormat.wBitsPerSample=16;
    waveFormat.nBlockAlign=waveFormat.wBitsPerSample / 8 * waveFormat.nChannels;
    waveFormat.nAvgBytesPerSec=waveFormat.nBlockAlign * waveFormat.nSamplesPerSec;
    waveFormat.cbSize=0;
    timethread=new TimeThread(true, View, buffer_size);
    spectrumthread=new SpectrumThread(true, View, buffer_size);

    //  Audio buffers
    WaveHeaders=new WAVEHDR[buffers];
    WaveBufSize=buffer_size * waveFormat.wBitsPerSample / 8 * waveFormat.nChannels;
    for(int i=0; i < buffers; i++)
    {
        WaveHeaders[i].dwBufferLength=WaveBufSize;
        WaveHeaders[i].lpData= (char *)VirtualAlloc(0, WaveBufSize, MEM_COMMIT, PAGE_READWRITE);
    }

    if((res=waveInOpen(&hWaveIn, WAVE_MAPPER, &waveFormat, (DWORD) this->Handle, (DWORD) this, CALLBACK_WINDOW)) == MMSYSERR_NOERROR)
    {
        for(int i=0; i < buffers - 1; i++)
        {
            WaveHeaders[i].dwBufferLength=WaveBufSize;
            WaveHeaders[i].dwFlags=0;
            WaveHeaders[i].dwLoops=0;
            if((res=waveInPrepareHeader(hWaveIn, &WaveHeaders[i], sizeof(WAVEHDR))) == MMSYSERR_NOERROR)
            {
                if((res=waveInAddBuffer(hWaveIn, &WaveHeaders[i], sizeof(WAVEHDR))) != MMSYSERR_NOERROR)
                {
                    waveInGetErrorText(res, ErrText, MAXERRORLENGTH);
                    Application->MessageBox(ErrText, "waveInAddBuffer", MB_OK);
                    Application->Terminate();
                }
            }
        }

        if((res=waveInStart(hWaveIn)) == MMSYSERR_NOERROR)
        {
            SendHeader= &WaveHeaders[buffers - 1];
            buff=0;
            isStart=true;
        }
        else
        {
            waveInGetErrorText(res, ErrText, MAXERRORLENGTH);
            Application->MessageBox(ErrText, "waveInStart", MB_OK);
            Application->Terminate();
        }
    }
    else
    {
        waveInGetErrorText(res, ErrText, MAXERRORLENGTH);
        Application->MessageBox(ErrText, "waveInOpen", MB_OK);
        Application->Terminate();
    }
}

//---------------------------------------------------------------------------
void __fastcall TMainForm::FormCloseQuery(TObject *Sender, bool &CanClose)
{
    MMRESULT    res;
    isStart=false;
    timethread->Terminate();
    spectrumthread->Terminate();

    //  Closing audio device
    waveInReset(hWaveIn);
    for(int i=0; i < buffers; i++)
    {
        res=::waveInUnprepareHeader(hWaveIn, &WaveHeaders[i], sizeof(WAVEHDR));
        while(res == WAVERR_STILLPLAYING)
        {
            Sleep(200);
            res=::waveInUnprepareHeader(hWaveIn, &WaveHeaders[i], sizeof(WAVEHDR));
        }
    }

    ::waveInClose(hWaveIn);
    for(int i=0; i < buffers; i++) VirtualFree(WaveHeaders[i].lpData, 0, MEM_RELEASE);
    delete[] WaveHeaders;
    delete timethread;
    delete spectrumthread;
}

//---------------------------------------------------------------------------
void __fastcall TMainForm::ViewMouseMove(TObject *Sender, TShiftState Shift, int X, int Y)
{
    spectrumthread->SetMousePoint(X, Y);
}

//---------------------------------------------------------------------------
void __fastcall TMainForm::Label1Click(TObject *Sender)
{
    ShellExecute(Handle, "Open", "http://nowcan.yeah.net", "", NULL, 1);

}
//---------------------------------------------------------------------------

