#include "common.h"
#include "authenticating.h"
#include "protocol.h"
#include "proxy_socket.h"
#include "borzoi_c.h"

int authenticating(SOCKET proxy, char *username){
	char buff[BUFFER_SIZE];
  	char buf_pk[PUBLIC_KEY_LEN];
  	char buf_sk[PRIVATE_KEY_LEN];
  	char key[SYMMETRIC_KEY_LEN];
  	int len;
  	int i;
  	int nsize;
    if(username == NULL){
  		return 1;
  	}
  	if(open_public_key(username, buf_pk) != 0){
  		return 1;
  	}
  	sprintf(buff, "%s: %s; %d\n", proxyAuth1, username, PUBLIC_KEY_LEN);
  	len = strlen(buff);
  	for(i = 0; i < PUBLIC_KEY_LEN; i++){
  		buff[len + i] = buf_pk[i];
  	}
  	if(
    	HAS_SOCKET_ERROR(
    		send(proxy, buff, len + PUBLIC_KEY_LEN, 0)
    	)
  	){
    	handle_error(__FILE__, __LINE__);
    	return 0;
  	}
  	if(
    	HAS_SOCKET_ERROR(
		    (nsize=recv(proxy, buff,
                    BUFFER_SIZE-1,0))
    	)
  	){
    	handle_error(__FILE__, __LINE__);
    	return 0;
  	}
  	// ставим завершающий ноль в конце строки
  	buff[nsize]=0;

  	if(is_command(buff, proxyAuth1)){
    	char *p;
    	int data_start;
    	unsigned i = 0;
    	int len;
    	char *proxyname;
    	int pos;
    	char randomstr[32];
	  	char *symbols = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ+=";
    	int j;
    	char b[32];
    	unsigned ln;
    	int len1 = strlen(buff);
    	if((p = strchr(buff, '\n')) == NULL){
      		return 0;
    	}
    	*p++ = 0;
    	data_start = p - buff;
	  	p = tokenize_cmd(buff);
    	while((p != NULL) && (i < 2)){
      		switch(i){
        		case 0:
          			if(!strcmp(p, "Failed")){
            			return 0;
          			}
          			if(!strcmp(p, "OK")){
            			return 1;
          			}
//          proxyname = strdup(p);
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
      		if(
		    	HAS_SOCKET_ERROR(
        		    (nsize=recv(proxy, buff + pos, data_start + len - pos, 0))
    			)
      		){
    	        if(
                	ERRNO_EQUALS(ECONNRESET)
        		){
          			return 0;
        		}
      		}
      		pos += nsize;
    	}
    	if(open_private_key(username, buf_sk) != 0){
    		return 0;
    	}
    	eckas_dh1(buff + data_start, buf_sk, key);
    	srand(time(NULL));
    	for(j = 0; j < 31; j++){
    		randomstr[j] = symbols[(int)((float)rand()*63/RAND_MAX)];
    	}
    	randomstr[31] = 0;
    	strcpy(b, randomstr);
    	ln = strlen(randomstr);
    	aes_encrypt(key, b, &ln);
		sprintf(buff, "%s: %s; %d\n", proxyAuth2, randomstr, ln);
    	len1 = strlen(buff);
    	for(i = 0; i < ln; i++){
    		buff[len1 + i] = b[i];
    	}
    	if(
	    	HAS_SOCKET_ERROR(
        		send(proxy, buff, len1 + ln, 0)
            )
    	){
    		handle_error(__FILE__, __LINE__);
      		return 0;
    	}
    	if(
	    	HAS_SOCKET_ERROR(
		        (nsize=recv(proxy, buff,
                      BUFFER_SIZE-1,0))
            )
	    ){
    	 	handle_error(__FILE__, __LINE__);
      		return 0;
	    }
    	if(is_command(buff, proxyAuth2)){
      		char *p;
	      	unsigned i = 0;
		    p = tokenize_cmd(buff);
      		while((p != NULL) && (i < 1)){
	        	switch(i){
    	      		case 0:
        	    		if(!strcmp(p, "Failed")){
            	  			return 0;
            			}
	            		if(!strcmp(p, "OK")){
    	          			return 1;
        	    		}
        		}
	        	i++;
    	    	p = tokenize_cmd(NULL);
      		}
	    }
    	return 0;
	}
	return 0;
}


