#ifndef initH
#define initH
#include "common.h"
#include "hashmap.h"
#include "arraylist.h"
#include "input_params.h"
#include "usage.h"
#include "server_loop.h"
#include "protocol.h"
#define LISTEN_PORT 8888
#define REGISTRATION_PERIOD 600

#define CLIENT_CONNECTED 0
#define CLIENT_REQUEST 1
#define CLIENT_LAST_STEP 0xFF

#define CLIENT_TYPE_UNKNOWN 0
#define CLIENT_TYPE_CLIENT 1
#define CLIENT_TYPE_PROXY 2

typedef struct client_data {
	SOCKET sock;
  struct sockaddr_in addr;
  int step;
  int client_type;
  MASTER_FD *master;
  int *fdmax;
  int legal;
  union ct {
  	struct proxy {
      int q;
    } proxy;
  	struct client {
      int tested;
      int need_proxy;
		  struct sockaddr_in proxy_addr;
		  struct sockaddr_in test_addr;
		  struct sockaddr_in *bad_proxies;
      int bp_cnt;
      SOCKET test_sock;
    } client;
  } type;
} CLIENT_DATA;

typedef struct proxy_data {
  struct sockaddr_in addr;
  int nclients;
  long last_registered;
} PROXY_DATA;

extern unsigned short listen_port;
extern char *program_name;
extern int always_proxy;
extern int verbose;
extern int registration_period;
extern HASHMAP *sock_data;
extern ARRAYLIST *proxy_data;
extern char buf[];    			// buffer for client data

extern int init(int argc, char* argv[]);
extern void *get_client_data(SOCKET sock, struct sockaddr_in addr);
extern struct sockaddr_in get_addr(void* client_data);
extern char *hello(void);

#endif
