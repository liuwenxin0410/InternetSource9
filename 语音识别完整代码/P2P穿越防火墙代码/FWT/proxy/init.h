//---------------------------------------------------------------------------

#ifndef initH
#define initH

#include <stdlib.h>
#include <string.h>
#include "common.h"
#include "error_handler.h"
#include "server_loop.h"
#include "protocol.h"
#ifdef AUTH
#include "borzoi_c.h"
#endif

extern unsigned short listen_port;
extern char *listen_address;
extern struct sockaddr_in server_addr;
extern char *program_name;
extern char *proxyname;
extern int registration_period;
extern int registration_timeout;
extern int verbose;
extern char buf[];    			// buffer for client data
extern HASHMAP *sock_data;
extern MASTER_FD master;

#define SERVER_PORT 8888
#define LISTEN_PORT 1235
#define LISTEN_ADDRESS ""
#define MAX_CLIENTS 10

#define CLIENT_CONNECTED 0
#define CLIENT_REQUEST 1
#define CLIENT_LAST_STEP 0xFF

#define CLIENT_TYPE_TIMER 1
#define CLIENT_TYPE_CLIENT 2
#define CLIENT_TYPE_SERVER 3
#define CLIENT_TYPE_UDP 4

#define PROXY_SRC_PORT_MIN 20000
#define PROXY_SRC_PORT_MAX 21000

#ifdef AUTH
	extern int has_key_pair;
	extern char public_key[];
	extern char private_key[];
#endif

extern int init(int argc, char* argv[]);
extern char *hello(void);

typedef struct clnt_data {
	SOCKET sock;
  struct sockaddr_in addr;
  int step;
  int client_type;
  MASTER_FD *master;
#ifdef AUTH
	int authorized;
  char key[SYMMETRIC_KEY_LEN];
#endif
  union cd {
  	struct client {
      char buff[64];
      int nsize;
      int over_tcp;
    } client;
    struct udp {
    	struct clnt_data *control;
			SOCKET client_socket;
    } udp;
  } type;
} CLIENT_DATA;



extern void *get_client_data(SOCKET sock, struct sockaddr_in addr);
extern struct sockaddr_in get_addr(void* client_data);
#endif
