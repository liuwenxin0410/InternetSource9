//---------------------------------------------------------------------------

#ifndef protocolH
#define protocolH
//---------------------------------------------------------------------------

extern char *registerProxy;
extern char *sHello;
extern char *pHello;
extern char *isBehindFirewall;
extern char *proxyOK;
extern char *proxyPing;
extern char *isBehindFirewall_response_format;
extern char *noProxyAvailable;
extern char *proxyAuth1;
extern char *proxyAuth2;
extern char *proxyBind;
extern char *proxyBindError;
extern char *proxyBound;
extern char *proxyBoundOK;
extern char *proxyClose;
extern char *registeredProxy;
extern char *getProxy;
extern char *testOverTCP;
extern char *isOverTCP;
extern char *overTCP;

//extern char **tokenize_cmd(char *);
extern char *tokenize_cmd(char *);
extern int is_command(char *buf, char* cmd);

#endif
