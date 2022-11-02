#include "over_tcp.h"

int receive_over_tcp(CLIENT_DATA *cd, int nsize, struct sockaddr_in sa){
  int data_start;
  char tmp[1024];
  int sent, rest;
  sprintf(tmp, "%s: %d; %d\n", overTCP, cd->type.udp.client_socket, nsize + sizeof(struct sockaddr_in));
  data_start = strlen(tmp);
  memmove(buf + data_start + sizeof(struct sockaddr_in), buf, nsize);
#if defined(WIN32) || defined(__WIN32__)
  memcpy(buf, tmp, data_start);
#else
  bcopy(tmp, buf, data_start);
#endif
#if defined(WIN32) || defined(__WIN32__)
  memcpy(buf + data_start, &sa, sizeof(struct sockaddr_in));
#else
  bcopy(&sa, buf + data_start, sizeof(struct sockaddr_in));
#endif
  sent = 0;
  rest = nsize + sizeof(struct sockaddr_in) + data_start;
  while(rest > 0){
    if((nsize = send(cd->type.udp.control->sock, buf + sent, rest, 0))
  #if defined(WIN32) || defined(__WIN32__)
        !=SOCKET_ERROR
  #else
        >= 0
  #endif
    ){
      sent += nsize;
      rest -= nsize;
    }
    else {
      if(verbose){
				handle_error(__FILE__, __LINE__);
      }
    }
    if(verbose){
      printf("[%s:%d] <<< %s\n", inet_ntoa(cd->type.udp.control->addr.sin_addr), ntohs(cd->type.udp.control->addr.sin_port), buf);
    }
  }
	return 0;
}

int send_over_tcp(CLIENT_DATA *cd, int nsize){
  CLIENT_DATA *udp;
  SOCKET sock;
  int data_start;
  int len;
  int i = 0;
  char *p;
printf("[%s,%d]\n",__FILE__,__LINE__);
  if((p = strchr(buf, '\n')) == NULL){
  	return 0;
  }
  *p++ = 0;
  data_start = p - buf;
  p = tokenize_cmd(buf);
  while((p != NULL) && (i < 2)){
    switch(i){
      case 0:
        sock = atoi(p);
        break;
      case 1:
        len = atoi(p);
        break;
    }
    i++;
    p = tokenize_cmd(NULL);
  }
printf("%s,%d %s\n", __FILE__,__LINE__,buf+data_start+sizeof(struct sockaddr_in));
  udp = (CLIENT_DATA *)hashmap_get(sock_data, sock);

  if(udp != NULL){
    int pos = nsize;
    while(pos < data_start + len){
      if((nsize=recv(cd->sock, buf + pos, data_start + len - pos, 0))
#if defined(WIN32) || defined(__WIN32__)
          ==SOCKET_ERROR
#else
          < 0
#endif
      ){
        if(
#if defined(WIN32) || defined(__WIN32__)
          WSAGetLastError() == WSAECONNRESET
#else
          errno == ECONNRESET
#endif
        ){
          return 0;
        }
      }
      pos += nsize;
    }
    resend_packet(udp, buf + data_start, len);
  }
	return 0;
}

int test_over_tcp_replay(CLIENT_DATA *cd, int nsize, struct sockaddr_in sa){
  if(
    (
    nsize = sendto(cd->sock, buf, nsize, 0,
      (struct sockaddr*)&sa, sizeof(struct sockaddr_in))
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
  return 0;
}

int is_over_tcp_reply(CLIENT_DATA *cd){
  int i = 0;
  char *p = tokenize_cmd(buf);
  while((p != NULL) && (i < 1)){
    switch(i){
      case 0:
        if(strcmp(p, "Yes") == 0){
          cd->type.client.over_tcp = 1;
        }
        else {
          cd->type.client.over_tcp = 0;
        }
        break;
    }
    i++;
    p = tokenize_cmd(NULL);
  }
  if(verbose){
    printf("over TCP: %d\n", cd->type.client.over_tcp);
  }
  return 0;
}



