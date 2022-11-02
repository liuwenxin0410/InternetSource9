#include "client_handler.h"

unsigned nclients = 0;

int timer_disabled = 0;
long last_registration = 0;

int server_read(CLIENT_DATA *cd);
int client_write(CLIENT_DATA *cd);
int client_exception(CLIENT_DATA *cd);
int client_read(CLIENT_DATA *cd);
int client_connected(CLIENT_DATA *cd);
int client_request(CLIENT_DATA *cd);
int register_on_server(void);
int proxy_ping_reply(CLIENT_DATA *cd);
int proxy_bind_reply(CLIENT_DATA *cd);
int proxy_close_reply(CLIENT_DATA *cd);
int proxy_bound_ok_replay(CLIENT_DATA *cd, int nsize, struct sockaddr_in sa);
int receive_packet(CLIENT_DATA *cd, int nsize, struct sockaddr_in sa);

int client_handler(void *data, MASTER_FD* master, int what){
        CLIENT_DATA *cd = (CLIENT_DATA *)data;
        if(cd->step == CLIENT_LAST_STEP){
    return disconnect(cd);
  }
  cd->master = master;
  switch(what){
        case WHAT_READ:
        return client_read(cd);
        case WHAT_WRITE:
        return client_write(cd);
        case WHAT_EXCEPTION:
        return client_exception(cd);
  }
  return MASTER_ALL;

}

int master_walker(void* data, void *data1){
        CLIENT_DATA *cd = (CLIENT_DATA *)data;
        CLIENT_DATA *cd1 = (CLIENT_DATA *)data1;
  if(
        (cd->client_type == CLIENT_TYPE_CLIENT) && (cd1->type.udp.control == cd)
        || (cd->client_type == CLIENT_TYPE_UDP) && (cd->type.udp.control == cd1)
  ){
        return 1;
  }
  return 0;
}

int disconnect(CLIENT_DATA *cd){
  if(nclients > 0){
          nclients--;
  }
  last_registration = 0;
  walk_master(sock_data, cd, &master, &master_walker);
  return DISCONNECT;
}

int client_write(CLIENT_DATA *cd){
        int nsize;
        if(cd->type.client.nsize > 0){
    if(send(cd->sock, cd->type.client.buff, cd->type.client.nsize, 0) < 0){
      if(verbose){
        handle_error(__FILE__, __LINE__);
      }
    }
    else {
            if(verbose){
            printf("[%s:%d] <<< %s", inet_ntoa(cd->addr.sin_addr), ntohs(cd->addr.sin_port), cd->type.client.buff);
        }
    }
    cd->type.client.nsize = 0;
        return MASTER_WRITE;
  }
        return 0;
}

#if defined(WIN32) || defined(__WIN32__)
unsigned __stdcall
#else
void*
#endif
server_registration(void* arg){
        int nsize;
  char buff[1024];
        CLIENT_DATA *cd = (CLIENT_DATA *)arg;
  int client_addr_sz = sizeof(struct sockaddr_in);
  if(connect(cd->sock, (struct sockaddr *)&cd->addr, client_addr_sz) != 0){
    if(verbose){
        handle_error(__FILE__, __LINE__);
    }
  }
  else {
          add_socket(cd->sock, sock_data, cd, &master, MASTER_READ);
  }
  return
#if defined(WIN32) || defined(__WIN32__)
                0
#else
                NULL
#endif
        ;
}

CLIENT_DATA *server;

int register_on_server(void){
  SOCKET server_sock;

  server_sock = socket(AF_INET, SOCK_STREAM, 0);
  if(server_sock
#if defined(WIN32) || defined(__WIN32__)
      ==INVALID_SOCKET
#else
      < 0
#endif
  ){
        return 1;
  }
  server = (CLIENT_DATA *)get_client_data(server_sock, server_addr);
  server->client_type = CLIENT_TYPE_SERVER;
  server->step = CLIENT_REQUEST;
#if defined(WIN32) || defined(__WIN32__)
        {
    unsigned thid;
                _beginthreadex(NULL, 0, &server_registration, server, 0, &thid);
  }
#else
        {
        pthread_t thread;
        pthread_create(&thread, NULL, &server_registration, server);
  }
#endif
        return 0;
}


int client_exception(CLIENT_DATA *cd){
        return 0;
}

int client_read(CLIENT_DATA *cd){
  if(cd->step == CLIENT_CONNECTED){
    return client_connected(cd);
  }
  else if(cd->step == CLIENT_REQUEST){
    return client_request(cd);
  }
  else {
  }
  return 0;
}

int server_read(CLIENT_DATA *cd){
  int nsize;
        if(strcmp(buf, sHello) == 0){
                sprintf(buf, "%s: %s; %d; %d\n", registerProxy, listen_address, listen_port, nclients);
    if(send(cd->sock, buf, strlen(buf), 0) < 0){
        if(verbose){
        handle_error(__FILE__, __LINE__);
      }
    }
    else {
            if(verbose){
            printf("[%s:%d] <<< %s", inet_ntoa(cd->addr.sin_addr), ntohs(cd->addr.sin_port), buf);
        }
    }
          return 0;
  }

  else if(is_command(buf, registeredProxy)){
    int i = 0;
    char *p = tokenize_cmd(buf);
    while((p != NULL) && (i < 1)){
      switch(i){
        case 0:
                            registration_period = atoi(p);
          break;
      }
      i++;
      p = tokenize_cmd(NULL);
    }
    timer_disabled = 0;
          return MASTER_ALL;
  }
  return 0;
}

int client_connected(CLIENT_DATA *cd){
  sprintf(buf, "%s", pHello);
  if(send(cd->sock, buf, strlen(buf), 0) < 0){
    if(verbose){
        handle_error(__FILE__, __LINE__);
    }
    return MASTER_ALL;
  }
  if(verbose){
    printf("[%s:%d] <<< %s", inet_ntoa(cd->addr.sin_addr), ntohs(cd->addr.sin_port), buf);
  }
  nclients++;
  last_registration = 0;

  cd->step = CLIENT_REQUEST;
  return 0;
}

int rerecv_cmd(CLIENT_DATA *cd, char *buf, int nsize){
        char *p = strchr(buf, '\r');
  if(p != NULL){
        nsize = p - buf + 1;
  }
        nsize = recv(cd->sock, buf, nsize, 0);
  return nsize;
}

int client_request(CLIENT_DATA *cd){
        int nsize;
  if(cd->client_type != CLIENT_TYPE_UDP){
    if((nsize = recv(cd->sock, buf, BUFFER_SIZE - 1, MSG_PEEK)) < 0){
        if(verbose){
                handle_error(__FILE__, __LINE__);
      }
    }
    if(nsize <= 0){
        recv(cd->sock, buf, BUFFER_SIZE - 1, 0);
      return disconnect(cd);
    }
          nsize = rerecv_cmd(cd, buf, nsize);
    buf[nsize] = 0;
    if(verbose){
//      printf("[%s,%d][%s:%d] >>> %s", __FILE__,__LINE__,inet_ntoa(cd->addr.sin_addr), ntohs(cd->addr.sin_port), buf);
    }
    if(cd->client_type == CLIENT_TYPE_SERVER){
      return server_read(cd);
    }
    else if(cd->client_type == CLIENT_TYPE_CLIENT){
      if(is_command(buf, proxyPing)){
        return proxy_ping_reply(cd);
      }
      else if(is_command(buf, proxyBind)){
        return proxy_bind_reply(cd);
      }
      else if(is_command(buf, proxyClose)){
        return proxy_close_reply(cd);
      }
      else if(is_command(buf, isOverTCP)){
#ifdef OVER_TCP
        return is_over_tcp_reply(cd);
#else
                                return 0;
#endif
      }
      else if(is_command(buf, overTCP)){
#ifdef OVER_TCP
#ifdef AUTH
                    if(!cd->authorized){
printf("[%s,%d] unauthorized\n", __FILE__,__LINE__);
                    return unauthorized(cd);
                }
#endif
        return send_over_tcp(cd, nsize);
#else
                                return 0;
#endif
      }
      else if(is_command(buf, proxyAuth1)){
#ifdef AUTH
                                return auth_1(cd, nsize);
#else
        sprintf(buf, "%s: OK\n", proxyAuth1);
        if(send(cd->sock, buf, strlen(buf), 0)
      #if defined(WIN32) || defined(__WIN32__)
            ==SOCKET_ERROR
      #else
            < 0
      #endif
        ){
          if(verbose){
            handle_error(__FILE__, __LINE__);
          }
        }
    if(verbose){
      printf("[%s,%d][%s:%d] >>> %s", __FILE__,__LINE__,inet_ntoa(cd->addr.sin_addr), ntohs(cd->addr.sin_port), buf);
    }
                                return 0;
#endif
      }
      else if(is_command(buf, proxyAuth2)){
#ifdef AUTH
                                return auth_2(cd, nsize);
#else
                                return 0;
#endif
      }
    }
  }
  else {
        struct sockaddr_in sa;
  #if defined(WIN32) || defined(__WIN32__)
    int
  #else
          unsigned
  #endif
    sz = sizeof(struct sockaddr_in);
    if((nsize = recvfrom(cd->sock, buf, BUFFER_SIZE - 1, 0, (struct sockaddr*)&sa, &sz)) < 0){
            if(verbose){
            handle_error(__FILE__, __LINE__);
      }
    }
    if(nsize <= 0){
            return disconnect(cd);
    }
    buf[nsize] = 0;
    if(verbose){
      printf("[%s:%d] >>> (%s)\n", inet_ntoa(sa.sin_addr), ntohs(sa.sin_port), buf);
    }
    if(
      (sa.sin_addr.s_addr == cd->addr.sin_addr.s_addr)
      && is_command(buf + sizeof(struct sockaddr_in), testOverTCP)
      && (((struct sockaddr_in*)buf)->sin_addr.s_addr == INADDR_NONE)

    ){
#ifdef OVER_TCP
      return test_over_tcp_replay(cd, nsize, sa);
#else
                        return 0;
#endif
    }
    else if(
      (sa.sin_addr.s_addr == cd->addr.sin_addr.s_addr)
      && is_command(buf + sizeof(struct sockaddr_in), proxyBoundOK)
      && (((struct sockaddr_in*)buf)->sin_addr.s_addr == INADDR_NONE)
    ){
        return proxy_bound_ok_replay(cd, nsize, sa);
    }
    else if(
        (sa.sin_addr.s_addr == cd->addr.sin_addr.s_addr)
        && (sa.sin_port == cd->addr.sin_port)
    ){ // from our client
#ifdef AUTH
            if(!cd->type.udp.control->authorized){
                    return unauthorized(cd, proxyAuth1);
        }
#endif
        return resend_packet(cd, buf, nsize);
    }
    else { // to our client
if(verbose){
printf("[%s,%d] %s:%d\n", __FILE__, __LINE__, inet_ntoa(sa.sin_addr), ntohs(sa.sin_port));
}
        return receive_packet(cd, nsize, sa);
    }
  }
  return 0;

}

int timer_event(void* arg){
        if(!timer_disabled){
        if((now - last_registration) > registration_period){
                timer_disabled = 1;
          last_registration = now;
                register_on_server();
    }
  }
  else {
        if((now - last_registration) > registration_timeout){
                timer_disabled = 0;
                closesocket(server->sock);
      rm_socket(server->sock, sock_data, &master, MASTER_ALL);
    }
  }
        return 0;
}

int proxy_ping_reply(CLIENT_DATA *cd){
        int nsize;

  delay(FW_DELAY_MSEC);   /* delay 10 ms */
  if(send(cd->sock, buf, strlen(buf), 0)
#if defined(WIN32) || defined(__WIN32__)
      != SOCKET_ERROR
#else
      >= 0
#endif
  ){
    if(verbose){
            printf("[%s:%d] <<< %s", inet_ntoa(cd->addr.sin_addr), ntohs(cd->addr.sin_port), buf);
    }
  }
  return 0;
}

#if defined(WIN32) || defined(__WIN32__)
unsigned __stdcall
#else
void*
#endif
binding(void* arg){
        int nsize;
  char buff[1024];
        CLIENT_DATA *cd = (CLIENT_DATA *)arg;
  CLIENT_DATA *control = cd->type.udp.control;
  struct sockaddr_in my_addr;
  unsigned short proxy_port;
  my_addr.sin_family = AF_INET;
  my_addr.sin_addr.s_addr = INADDR_ANY;
  for(proxy_port = PROXY_SRC_PORT_MIN; proxy_port < PROXY_SRC_PORT_MAX; proxy_port++){

    my_addr.sin_port = htons(proxy_port);
    if (bind(cd->sock,(struct sockaddr *)&my_addr,
      sizeof(struct sockaddr_in)) == 0){
      break;
    }
    if(
#if defined(WIN32) || defined(__WIN32__)
    WSAGetLastError() != WSAEADDRINUSE
#else
    errno != EADDRINUSE
#endif
    ){
      sprintf(buff, "%s: %s; %d\n", proxyBindError, error_id(), __LINE__);
            closesocket(cd->sock);
          free(cd);
      goto end;
    }
  }
  if(proxy_port == PROXY_SRC_PORT_MAX){
#if defined(WIN32) || defined(__WIN32__)
      WSASetLastError(WSAEADDRINUSE)
#else
      errno = EADDRINUSE
#endif
    ;
    sprintf(buff, "%s: %s; %d\n", proxyBindError, error_id(), __LINE__);
    closesocket(cd->sock);
    free(cd);
  }
  else {
    sprintf(buff, "%s: %d; %d; %s\n", proxyBound, cd->sock, proxy_port,
#ifdef OVER_TCP
                        "OVER_TCP=Y"
#else
                        "OVER_TCP=N"
#endif
    );
    cd->step = CLIENT_REQUEST;
    add_socket(cd->sock, sock_data, cd, &master, MASTER_READ);
  }
  end:
#if defined(WIN32) || defined(__WIN32__)
  memcpy(control->type.client.buff, buff, strlen(buff));
#else
  bcopy(buff, control->type.client.buff, strlen(buff));
#endif

  control->type.client.nsize = strlen(buff);
  add_socket(control->sock, sock_data, control, &master, MASTER_WRITE);
  return
#if defined(WIN32) || defined(__WIN32__)
                0
#else
                NULL
#endif
        ;
}

int proxy_bind_reply(CLIENT_DATA *cd){
  SOCKET client_socket;
  SOCKET sock;
  int type;
  int protocol;
  struct sockaddr_in client_sa;

  CLIENT_DATA *udp_client;
  int i = 0;
  char *p = tokenize_cmd(buf);
  while((p != NULL) && (i < 3)){
    switch(i){
      case 0:
                          client_socket = atoi(p);
        break;
      case 1:
                          type = atoi(p);
        break;
      case 2:
                          protocol = atoi(p);
        break;
    }
    i++;
    p = tokenize_cmd(NULL);
  }
  client_sa.sin_family = AF_INET;
  client_sa.sin_addr = cd->addr.sin_addr;
  client_sa.sin_port = htons(0);
  if((sock = socket(AF_INET, type, protocol))
#if defined(WIN32) || defined(__WIN32__)
    == INVALID_SOCKET
#else
    < 0
#endif
  ){
    sprintf(buf, "%s: %s; %d\n", proxyBindError, error_id(), __LINE__);
    delay(FW_DELAY_MSEC);   /* delay 10 ms */
    if(send(cd->sock, buf, strlen(buf), 0) < 0){
            if(verbose){
            handle_error(__FILE__, __LINE__);
      }
    }
    else {
            if(verbose){
            printf("[%s:%d] <<< %s", inet_ntoa(cd->addr.sin_addr), ntohs(cd->addr.sin_port), buf);
        }
    }
    return 0;
  }

  udp_client = (CLIENT_DATA *)get_client_data(sock, client_sa);
  udp_client->type.udp.control = cd;
  udp_client->type.udp.client_socket = client_socket;
  udp_client->client_type = CLIENT_TYPE_UDP;
#if defined(WIN32) || defined(__WIN32__)
        {
    unsigned thid;
                _beginthreadex(NULL, 0, &binding, udp_client, 0, &thid);
  }
#else
        {
        pthread_t thread;
        pthread_create(&thread, NULL, &binding, udp_client);
  }
#endif
  return 0;
}

int proxy_close_reply(CLIENT_DATA *cd){
  int i = 0;
  CLIENT_DATA *udp;
  char *p = tokenize_cmd(buf);
  while((p != NULL) && (i < 1)){
    switch(i){
      case 0:
                          udp = (CLIENT_DATA *)hashmap_get(sock_data, atoi(p));
        break;
    }
    i++;
    p = tokenize_cmd(NULL);
  }
  if(udp != NULL){
    if(verbose){
      printf("close: %d\n", udp->sock);
    }
    rm_socket(udp->sock, sock_data, &master, MASTER_ALL);
  }
  return 0;
}

int proxy_bound_ok_replay(CLIENT_DATA *cd, int nsize, struct sockaddr_in sa){
  cd->addr = sa;
#ifdef AUTH
  if(!cd->type.udp.control->authorized){
    return unauthorized(cd, proxyAuth1);
        }
#endif
  delay(FW_DELAY_MSEC);   /* delay 10 ms */
  if((nsize = send(cd->type.udp.control->sock, buf + sizeof(struct sockaddr_in),
    strlen(buf + sizeof(struct sockaddr_in)), 0))
#if defined(WIN32) || defined(__WIN32__)
      != SOCKET_ERROR
#else
      >= 0
#endif
  ){
    if(verbose){
      printf("[%s:%d] <<< %s\n",
        inet_ntoa(cd->type.udp.control->addr.sin_addr),
        ntohs(cd->type.udp.control->addr.sin_port), buf + sizeof(struct sockaddr_in)
      );
    }
  }
  else {
    if(verbose){
        handle_error(__FILE__, __LINE__);
    }
  }
  return 0;
}

int resend_packet(CLIENT_DATA *cd, char *buff, int nsize){
  struct sockaddr_in sa;

#if defined(WIN32) || defined(__WIN32__)
  memcpy(&sa, buff, sizeof(struct sockaddr_in));
#else
  bcopy(buff, &sa, sizeof(struct sockaddr_in));
#endif

        if(ntohs(sa.sin_port) <= 1024){
          return 0;
  }

  nsize = sendto(cd->sock, buff + sizeof(struct sockaddr_in),
      nsize - sizeof(struct sockaddr_in), 0,
      (struct sockaddr*)&sa, sizeof(struct sockaddr_in));
  if(nsize
#if defined(WIN32) || defined(__WIN32__)
      !=SOCKET_ERROR
#else
      >= 0
#endif
  ){
    if(verbose){
      printf("[%s,%d] [%s:%d] <<< (%d)\n", __FILE__, __LINE__, inet_ntoa(sa.sin_addr), ntohs(sa.sin_port), nsize);
    }
  }
  else {
    if(verbose){
                        handle_error(__FILE__, __LINE__);
    }
  }
  return 0;
}

int receive_packet(CLIENT_DATA *cd, int nsize, struct sockaddr_in sa){
#ifdef OVER_TCP
        if(cd->type.udp.control->type.client.over_tcp){
        return receive_over_tcp(cd, nsize, sa);
  }
  else
#endif
  {
    memmove(buf + sizeof(struct sockaddr_in), buf, nsize);
#if defined(WIN32) || defined(__WIN32__)
    memcpy(buf, &sa, sizeof(struct sockaddr_in));
#else
    bcopy(&sa, buf, sizeof(struct sockaddr_in));
#endif
    if(
      (
      nsize = sendto(cd->sock, buf,
      nsize + sizeof(struct sockaddr_in)
      , 0,
        (struct sockaddr*)&cd->addr, sizeof(struct sockaddr_in))
    )
        #if defined(WIN32) || defined(__WIN32__)
        !=SOCKET_ERROR
  #else
        >= 0
  #endif
    ){
            if(verbose){
            printf("[%s:%d] <<< (%d)\n", inet_ntoa(sa.sin_addr), ntohs(sa.sin_port), nsize);
        }
    }
    else {
        if(verbose){
                                handle_error(__FILE__, __LINE__);
      }
    }
  }
  return 0;
}


