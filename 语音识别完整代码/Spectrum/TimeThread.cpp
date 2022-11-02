//---------------------------------------------------------------------------

//

// Copyright (C) 2002 Mika Söderholm.

// All Rights Reserved.

//

//---------------------------------------------------------------------------

/*
Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are
met:

1. Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
2. Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
3. All materials mentioning features or use of this software
   must display the following acknowledgement:
      This product includes software developed by Mika Söderholm.
4. Any commercial use is prohibited.

THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESS OR IMPLIED
WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
IN NO EVENT SHALL MIKA SÖDERHOLM BE LIABLE FOR
ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT
OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR
BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE,
EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

//---------------------------------------------------------------------------

//  For more information contact email: mika.soderholm@luukku.com

//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "TimeThread.h"
#pragma package(smart_init)

//---------------------------------------------------------------------------
__fastcall TimeThread::TimeThread(bool CreateSuspended, TPaintBox *in, int ic) :
    TThread(CreateSuspended)
{
    count=ic;
    view=in;
    data=new short[ic];
    busy=false;
}

/* */
__fastcall TimeThread::~TimeThread(void)
{
    delete[] data;
}

/* */
void TimeThread::Process(short *idata)
{
    if(!busy)
    {
        memcpy(data, idata, count * sizeof(short));
        Resume();
    }
}

//---------------------------------------------------------------------------
void __fastcall TimeThread::Execute(void)
{
    while(!Terminated)
    {
        FillBuffer();
    }
}

/* */
void __fastcall TimeThread::FillBuffer(void)
{
    long    leftzerolevel=(view->ClientHeight / 2 - 10) / 2;
    long    rightzerolevel=view->ClientHeight / 2 + 10 + leftzerolevel;
    double  timescale=leftzerolevel / 32768.0;
    busy=true;
    view->Canvas->Lock();
    view->Canvas->Brush->Color=clBlack;
    view->Canvas->Pen->Color=clWhite;
    view->Canvas->Rectangle(0, 0, view->ClientWidth, view->ClientHeight);
    view->Canvas->Pen->Color=clYellow;
    view->Canvas->MoveTo(0, leftzerolevel);
    view->Canvas->LineTo(view->ClientWidth, leftzerolevel);
    view->Canvas->MoveTo(0, rightzerolevel);
    view->Canvas->LineTo(view->ClientWidth, rightzerolevel);
    view->Canvas->Pen->Color=clAqua;

    double  ts=static_cast<double>(view->ClientWidth) / static_cast<double>(count);
    int     x;
    view->Canvas->MoveTo(0, leftzerolevel);
    for(int i=0; i < count - 1; i+=2)
    {
        x=i * ts;

        int y=leftzerolevel - static_cast<double>(data[i]) * timescale;
        view->Canvas->LineTo(x, y);
    }

    view->Canvas->MoveTo(0, rightzerolevel);
    for(int i=1; i < count; i+=2)
    {
        x=i * ts;

        int y=rightzerolevel - static_cast<double>(data[i]) * timescale;
        view->Canvas->LineTo(x, y);
    }

    view->Canvas->Unlock();
    busy=false;
    Suspend();
}

//---------------------------------------------------------------------------
