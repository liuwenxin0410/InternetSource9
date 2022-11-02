// speechDoc.cpp : implementation of the CSpeechDoc class
//

#include "stdafx.h"
#include "speech.h"

#include "speechDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CSpeechDoc

IMPLEMENT_DYNCREATE(CSpeechDoc, CDocument)

BEGIN_MESSAGE_MAP(CSpeechDoc, CDocument)
	//{{AFX_MSG_MAP(CSpeechDoc)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CSpeechDoc construction/destruction

CSpeechDoc::CSpeechDoc()
{
	// TODO: add one-time construction code here

}

CSpeechDoc::~CSpeechDoc()
{
}

BOOL CSpeechDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CSpeechDoc serialization

void CSpeechDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}
}

/////////////////////////////////////////////////////////////////////////////
// CSpeechDoc diagnostics

#ifdef _DEBUG
void CSpeechDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CSpeechDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CSpeechDoc commands
