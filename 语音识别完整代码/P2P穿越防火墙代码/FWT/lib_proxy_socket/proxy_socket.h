/*---------------------------------------------------------------------------*/

#ifndef proxy_socketH
#define proxy_socketH

#include "common.h"

/*---------------------------------------------------------------------------*/
#ifdef __cplusplus
extern "C" {
#endif

extern struct sockaddr_in get_server_address(void);
extern void set_server_address(struct sockaddr_in sa);

extern unsigned proxy_ping_period;

extern void set_proxy_over_tcp(unsigned over_tcp);
extern unsigned get_proxy_over_tcp(void);
extern void set_proxy_socket_functions(unsigned proxy_socket_functions);
extern unsigned get_proxy_socket_functions(void);
extern void set_username(char* anusername);

extern void proxy_set_ping_interval(unsigned seconds);
extern unsigned proxy_get_ping_interval(void);
extern int proxy_socket(int domain, int type, int protocol);
extern int proxy_bind(int  sockfd, struct sockaddr *my_addr, int *addrlen);
extern int proxy_close(int d);
extern int proxy_sendto(int s, const char *msg, size_t len, int flags, const struct sockaddr *to, int tolen);
extern int proxy_recvfrom(int  s,  char *buf,  size_t len, int flags, struct sockaddr *from, int *fromlen);
extern int proxy_select(int  n,  fd_set  *readfds,  fd_set  *writefds,
       fd_set *exceptfds, struct timeval *timeout);
extern int proxy_getsockname(int s, struct sockaddr *name, int *namelen);

#ifdef __cplusplus
}
#endif

#define SRC_PORT_MIN 40000
#define SRC_PORT_MAX 41000

#define TEST_PORT_MIN 40000
#define TEST_PORT_MAX 41000

#define OVER_TCP_TEST_TIMEOUT 5
#define OVER_TCP_TEST_TRIES 3

#define SERVER_NOT_AVAIL 2
#define NO_PROXY_AVAIL 3

extern FILE *debug;


#endif
