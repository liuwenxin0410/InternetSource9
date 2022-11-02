//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop

//---------------------------------------------------------------------------
USEFORM("f_main.cpp", MainForm);

//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
    try
    {
        Application->Initialize();
        Application->Title = "²¨ÐÎ¡¢ÆµÆ×";
         Application->CreateForm(__classid(TMainForm), &MainForm);
        Application->Run();
    }

    catch(Exception & exception)
    {
        Application->ShowException(&exception);
    }

    catch(...)
    {
        try
        {
            throw Exception("");
        }

        catch(Exception & exception)
        {
            Application->ShowException(&exception);
        }
    }

    return 0;
}

//---------------------------------------------------------------------------
