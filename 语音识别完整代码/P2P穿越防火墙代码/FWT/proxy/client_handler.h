#ifndef client_handlerH
#define client_handlerH

#include "common.h"
#include "server_loop.h"
#include "init.h"
#include "protocol.h"
#ifdef OVER_TCP
#include "over_tcp.h"
#endif
#ifdef AUTH
#include "auth.h"
#endif

extern int client_handler(void *data, MASTER_FD* master, int what);
extern int timer_event(void*);
extern int resend_packet(CLIENT_DATA *cd, char *buff, int nsize);
extern int disconnect(CLIENT_DATA *cd);

#endif
