// speechView.cpp : implementation of the CSpeechView class
//

#include "stdafx.h"
#include "speech.h"

#include "speechDoc.h"
#include "speechView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CSpeechView

IMPLEMENT_DYNCREATE(CSpeechView, CView)

BEGIN_MESSAGE_MAP(CSpeechView, CView)
	//{{AFX_MSG_MAP(CSpeechView)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG_MAP
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, CView::OnFilePrintPreview)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CSpeechView construction/destruction

CSpeechView::CSpeechView()
{
	// TODO: add construction code here

}

CSpeechView::~CSpeechView()
{
}

BOOL CSpeechView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

/////////////////////////////////////////////////////////////////////////////
// CSpeechView drawing

void CSpeechView::OnDraw(CDC* pDC)
{
	CSpeechDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	// TODO: add draw code for native data here
}

/////////////////////////////////////////////////////////////////////////////
// CSpeechView printing

BOOL CSpeechView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CSpeechView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CSpeechView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

/////////////////////////////////////////////////////////////////////////////
// CSpeechView diagnostics

#ifdef _DEBUG
void CSpeechView::AssertValid() const
{
	CView::AssertValid();
}

void CSpeechView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CSpeechDoc* CSpeechView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CSpeechDoc)));
	return (CSpeechDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CSpeechView message handlers
