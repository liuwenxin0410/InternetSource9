#ifndef server_loopH
#define server_loopH

#include "common.h"
#include "hashmap.h"
#if !defined(WIN32) && !defined(__WIN32__)
#include <sys/sem.h>
#endif
typedef struct mAster {
	fd_set read;
	fd_set write;
	fd_set exception;
  SOCKET fdmax;
  SOCKET fdmin;
#if defined(WIN32) || defined(__WIN32__)
  CRITICAL_SECTION lock;
#else
	int lock;
#endif
} MASTER_FD;

extern int server_loop(
	int (__cdecl *client_handler)(void*, MASTER_FD*, int what),
  void *(__cdecl *get_data_item)(SOCKET, struct sockaddr_in),
  struct sockaddr_in(__cdecl *get_data_item_addr)(void *data_item),
  char *buf,
	HASHMAP *data,
  unsigned short listen_port,
  char *(__cdecl *hello)(void),
  MASTER_FD *master,
  int (__cdecl *cycle_func)(void*)
);

extern void init_master(MASTER_FD *master);
extern long now;


#define WHAT_READ 1
#define WHAT_WRITE 2
#define WHAT_EXCEPTION 3

#define MASTER_READ 1
#define MASTER_WRITE 2
#define MASTER_EXCEPTION 4
#define MASTER_DISCONNECT 8
#define MASTER_ALL (MASTER_READ | MASTER_WRITE | MASTER_EXCEPTION)
#define DISCONNECT (MASTER_ALL | MASTER_DISCONNECT)

extern void add_socket(SOCKET fd, HASHMAP *data, void *data_item, MASTER_FD *master, int flags);
extern void rm_socket(SOCKET fd, HASHMAP *data, MASTER_FD *master, int flags);
extern void print_master(MASTER_FD *master);

extern int tcp_verbose;

extern void walk_master(HASHMAP *data, void *data_item, MASTER_FD *master, int (__cdecl *walker)(void*,void*));
#endif
