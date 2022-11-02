//---------------------------------------------------------------------------
#ifndef SpectrumThreadH
#define SpectrumThreadH

//---------------------------------------------------------------------------
#include <Classes.hpp>

//---------------------------------------------------------------------------
class SpectrumThread :
    public TThread
{
/* */
private:
    int             count;
    short           *data;
    TPaintBox       *view;
    bool            busy;
    double          *WaveR;
    double          *WaveI;
    TPoint          point;
    void __fastcall FFT(double *br, double *bi, int n, int ity);
    void __fastcall cstab(double *st, double *ct, int il, int ity);
    void __fastcall brtab(int *lbr, int il);
    void __fastcall binrv(double *bc, int il, const int *lb);
    void __fastcall fft1(double *br, double *bi, int il, const double *st, const double *ct);

/* */
protected:
    void __fastcall Execute(void);

/* */
public:
    __fastcall      SpectrumThread(bool CreateSuspended, TPaintBox *in, int ic);
    __fastcall      ~SpectrumThread(void);
    void __fastcall FillBuffer(void);
    void            Process(short *);
    void            SetMousePoint(int x, int y);
};

//---------------------------------------------------------------------------
#endif
