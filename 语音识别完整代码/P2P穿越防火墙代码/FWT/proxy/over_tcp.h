#ifndef over_tcpH
#define over_tcpH
#include "common.h"
#include "init.h"
#include "client_handler.h"

extern int receive_over_tcp(CLIENT_DATA *cd, int nsize, struct sockaddr_in sa);
extern int send_over_tcp(CLIENT_DATA *cd, int nsize);
extern int test_over_tcp_replay(CLIENT_DATA *cd, int nsize, struct sockaddr_in sa);
extern int is_over_tcp_reply(CLIENT_DATA *cd);


#endif
