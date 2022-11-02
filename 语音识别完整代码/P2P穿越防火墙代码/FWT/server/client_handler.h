#ifndef client_handlerH
#define client_handlerH

#include "common.h"
#include "server_loop.h"
#include "init.h"
#include "protocol.h"

extern int client_handler(void *data,
	MASTER_FD* master, int what);

#endif
