#include <stdlib.h>
#include <string.h>
#include "protocol.h"

	// "Register-proxy: <IP>; <Port>; <NumClients>\n"
char *registerProxy = "Register-proxy";

	// "Registered-proxy: <Interval>\n"
char *registeredProxy = "Registered-proxy";

char *sHello = "Peerio proxy managing server\n";
char *pHello = "Peerio proxy\n";

	// request: "Is-behind-firewall: <Test port>\n"
	// response: "Is-behind-firewall: <YES|NO>; <Proxy IP>|No-proxy-available; <Proxy Port>|0\n"
char *isBehindFirewall = "Is-behind-firewall";
char *noProxyAvailable = "No-proxy-available";
char *proxyOK = "Proxy-OK";

	// "Proxy-bind: <Socket>; <Socket type>; <Socket protocol>\n"
char *proxyBind = "Proxy-bind";

	// request: "Proxy-auth-1: <Username>; <Key size>\n<Public key>"
	// response: "Proxy-auth-1: <Proxyname>; <Key size>\n<Public key>"
	// response: "Proxy-auth-1: Failed|OK\n"
char *proxyAuth1 = "Proxy-auth-1";

	// request: "Proxy-auth-2: <Plain data>; <Ciphered data size>\n<Ciphered data>"
	// response: "Proxy-auth-2: OK|Failed\n"
char *proxyAuth2 = "Proxy-auth-2";

	// "Proxy-ping:\n"
char *proxyPing = "Proxy-ping";

	// "Proxy-bind-error: <error>; <Context>\n"
char *proxyBindError = "Proxy-bind-error";

	// "Proxy-bound: <Proxy socket>; <Proxy port>; OVER_TCP=Y|N\n"
char *proxyBound = "Proxy-bound";

	// "Proxy-bound-ok: <Proxy socket>\n"
char *proxyBoundOK = "Proxy-bound-ok";

	// "Proxy-close: <Proxy socket>\n"
char *proxyClose = "Proxy-close";

	// "Get-proxy:\n"
char *getProxy = "Get-proxy";

	// "Test-over-TCP:\n"
char *testOverTCP = "Test-over-TCP";

	// "Is-over-TCP: <Proxy socket>; YES|NO\n"
char *isOverTCP = "Is-over-TCP";

	// "Over-TCP: <Proxy socket>; <Size>\n<UDP-Data>"
char *overTCP = "Over-TCP";

char *tokenize_cmd(char *cmd){
  	char *res;
  	if(cmd != NULL){
		if(strtok(cmd, ":") == NULL){
  			return NULL;
  		}
  	}
  	res = strtok(NULL, ";\n");
  	if(res != NULL){
    	res++;
  	}
  	return res;
}

int is_command(char *buf, char* cmd){
  	char *p;
  	int l;
  	int res;
    if(strlen(buf) < strlen(cmd)){
  		return 0;
  	}
  	p = strstr(buf, cmd);
  	l = strlen(cmd);
	res = ((p != NULL) && (buf == p) && (buf[l] == ':'));
  	return res;
}

