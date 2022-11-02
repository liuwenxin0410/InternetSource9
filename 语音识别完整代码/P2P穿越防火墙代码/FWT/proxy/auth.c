#include "auth.h"
int auth_1(CLIENT_DATA *cd, int nsize){
	char *username;
  char *p;
  int data_start;
  int i = 0;
  int len;
  int pos;
  int res = 0;
  if((p = strchr(buf, '\n')) == NULL){
  	return DISCONNECT;
  }
  *p++ = 0;
  data_start = p - buf;
  p = tokenize_cmd(buf);
  while((p != NULL) && (i < 2)){
    switch(i){
      case 0:
        username = strdup(p);
        break;
      case 1:
        len = atoi(p);
        break;
    }
    i++;
    p = tokenize_cmd(NULL);
  }
  pos = nsize;

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
        free(username);
		  	return DISCONNECT;
      }
    }
    pos += nsize;
  }
  {
    if(!has_key_pair){
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
      cd->authorized = 1;
    }
    else {
	    char local_pk[PUBLIC_KEY_LEN];
      if(open_public_key(username, local_pk) != 0){
        res = unauthorized(cd, proxyAuth1);
      }
      else {
        if(cmp_public_keys(buf + data_start, local_pk) != 0){
          res = DISCONNECT;
        }
        else {
          int len;
          int i;
          char key[SYMMETRIC_KEY_LEN];
          eckas_dh1(local_pk, private_key, key);
          memcpy(cd->key, key, SYMMETRIC_KEY_LEN);
          sprintf(buf, "%s: %s; %d\n", proxyAuth1, proxyname, PUBLIC_KEY_LEN);
          len = strlen(buf);
          for(i = 0; i < PUBLIC_KEY_LEN; i++){
            buf[len + i] = public_key[i];
          }
          if(send(cd->sock, buf, len + PUBLIC_KEY_LEN, 0)
        #if defined(WIN32) || defined(__WIN32__)
              ==SOCKET_ERROR
        #else
              < 0
        #endif
          ){
          if(verbose){
            handle_error(__FILE__, __LINE__);
          }
            res = DISCONNECT;
          }
        }
      }
    }
  }
  free(username);
  return res;
}

int auth_2(CLIENT_DATA *cd, int nsize){
	char *randomstr;
  char *p;
  int data_start;
  int i = 0;
  unsigned len;
  int pos;
  int res = 0;
  if((p = strchr(buf, '\n')) == NULL){
  	return DISCONNECT;
  }
  *p++ = 0;
  data_start = p - buf;
  p = tokenize_cmd(buf);
  while((p != NULL) && (i < 2)){
    switch(i){
      case 0:
        randomstr = strdup(p);
        break;
      case 1:
        len = atoi(p);
        break;
    }
    i++;
    p = tokenize_cmd(NULL);
  }
  pos = nsize;

  while(pos < (int)(data_start + len)){
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
        free(randomstr);
		  	return DISCONNECT;
      }
    }
    pos += nsize;
  }
  aes_decrypt(cd->key, buf + data_start, &len);
  buf[data_start + len] = 0;
  if(strcmp(randomstr, buf + data_start) == 0){
    sprintf(buf, "%s: OK\n", proxyAuth2);
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
    cd->authorized = 1;
  }
  else {
  	res = unauthorized(cd, proxyAuth2);
  }
  free(randomstr);
  return res;
}

int unauthorized(CLIENT_DATA *cd, char *command){
  sprintf(buf, "%s: Failed\n", command);
  if(send(cd->client_type == CLIENT_TYPE_UDP ? cd->type.udp.control->sock : cd->sock, buf, strlen(buf), 0)
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
  return disconnect(cd);
}

