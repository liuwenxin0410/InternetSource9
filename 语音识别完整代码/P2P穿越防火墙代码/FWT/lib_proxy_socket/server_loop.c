#include "server_loop.h"

void set_sockets(MASTER_FD *master, fd_set *read_fds,  fd_set *write_fds,  fd_set *exc_fds);

int tcp_verbose = 0;
long now;

void init_master(MASTER_FD *master){
  	FD_ZERO(&master->read);    						// clear the master and temp sets
  	FD_ZERO(&master->write);    						// clear the master and temp sets
  	FD_ZERO(&master->exception);    						// clear the master and temp sets
  	master->fdmax = 0;
  	master->fdmin = 0;
}

int server_loop(
	int (__cdecl *client_handler)(void*, MASTER_FD*, int what),
  	void *(__cdecl *get_data_item)(SOCKET, struct sockaddr_in),
  	struct sockaddr_in(__cdecl *get_data_item_addr)(void *data_item),
  	char *buf,
	HASHMAP *data,
  	unsigned short listen_port,
  	char *(__cdecl *hello)(void),
  	MASTER_FD *master,
  	int (__cdecl *cycle_func)(void*)
){

  	fd_set read_fds, write_fds, exc_fds; 								// temp file descriptor list for select()
  	struct sockaddr_in myaddr;     	// server address
  	struct sockaddr_in remoteaddr; 	// client address
  	SOCKET listener;     							// listening socket descriptor
  	SOCKET newfd;        							// newly accept()ed socket descriptor
  	int nbytes;
  	int yes=1;        							// for setsockopt() SO_REUSEADDR, below
#if defined(WIN32) || defined(__WIN32__)
  	int addrlen;
#else
  	unsigned addrlen;
#endif
  	int i, j;
  	struct timeval timeout;

  	// get the listener
  	if (
    	SOCKET_IS_INVALID(
    		(listener = socket(AF_INET, SOCK_STREAM, 0))
    	)
  	) {
	    if(tcp_verbose){
  	    	handle_error(__FILE__, __LINE__);
      	}
      	exit(1);
  	}

  	if (setsockopt(listener, SOL_SOCKET, SO_REUSEADDR, (const char*)&yes, sizeof(int)) != 0) {
	    if(tcp_verbose){
      		handle_error(__FILE__, __LINE__);
      	}
      	exit(1);
  	}

  	// bind
  	myaddr.sin_family = AF_INET;
  	myaddr.sin_addr.s_addr = INADDR_ANY;
  	myaddr.sin_port = htons(listen_port);
  	memset(&(myaddr.sin_zero), '\0', 8);
  	if (bind(listener, (struct sockaddr *)&myaddr, sizeof(myaddr)) != 0) {
	    if(tcp_verbose){
      		handle_error(__FILE__, __LINE__);
      	}
      	exit(1);
  	}

  	// listen
  	if (listen(listener, 100) != 0) {
	    if(tcp_verbose){
      		handle_error(__FILE__, __LINE__);
      	}
      	exit(1);
  	}

  	if(tcp_verbose){
  		if(hello != NULL){
    		char *hi = hello();
  			printf("%s\n", hi);
      		free(hi);
    	}
  	}

  	// add the listener to the master set
if(tcp_verbose){printf("[%s,%d]\n", __FILE__, __LINE__);}
  	add_socket(listener, NULL, NULL, master, MASTER_READ);

  	// main loop
  	for(;;) {
  		int res;
    	unsigned int i;
    	void *data_item = NULL;

		set_sockets(master, &read_fds,  &write_fds,  &exc_fds);
    	timeout.tv_sec = SELECT_TIMEOUT_SEC;
    	timeout.tv_usec = SELECT_TIMEOUT_USEC;
//print_master(master);
    	res = select(master->fdmax + 1, &read_fds, &write_fds, &exc_fds, &timeout);
    	now = time(NULL);
    	if(cycle_func != NULL){
      		cycle_func(NULL);
    	}
    	if (res < 0) {
	    	if(tcp_verbose){
	      		handle_error(__FILE__, __LINE__);
      		}
      		if (listen(listener, 100) != 0) {
			    if(tcp_verbose){
    	      	handle_error(__FILE__, __LINE__);
          	}
          	exit(1);
      	}

      	init_master(master);
		  	add_socket(listener, NULL, NULL, master, MASTER_READ);
      		continue;
    	}
    	if(res == 0){
    		continue;
    	}
        for(i = master->fdmin; i <= master->fdmax; i++){
    		if(FD_ISSET(i, &exc_fds)){
        		if(i != listener){
        	  		data_item = hashmap_get(data, i);
          			if(data_item != NULL){
            		int res = client_handler(data_item, master, WHAT_EXCEPTION);
	            	if(res > 0){ // close connection
    	       	   		if((res & MASTER_DISCONNECT) == MASTER_DISCONNECT){
        	        		if(tcp_verbose){
            	      			printf("- [%s:%d]\n", inet_ntoa(get_data_item_addr(data_item).sin_addr), ntohs(get_data_item_addr(data_item).sin_port));
                			}
              			}
	              		rm_socket(i, data, master, res);
    	        	}
        	  	}
	        }
    	}
    	if(FD_ISSET(i, &read_fds)){
        	if(i == listener){
          		addrlen = sizeof(struct sockaddr_in);
          		newfd = accept(listener, (struct sockaddr*)&remoteaddr, &addrlen);
          		if(
			    	SOCKET_IS_INVALID(
            		    newfd
    				)
          		){
					if(tcp_verbose){
			      		handle_error(__FILE__, __LINE__);
            		}
          		}
          		else {
            		data_item = get_data_item(newfd, remoteaddr);
if(tcp_verbose){printf("[%s,%d]\n", __FILE__, __LINE__);}
            		add_socket(newfd, data, data_item, master, MASTER_READ);
            		if(tcp_verbose){
              			printf("+ [%s:%d]\n", inet_ntoa(remoteaddr.sin_addr), ntohs(remoteaddr.sin_port));
            		}
          		}
        	}
        	else {
          		data_item = hashmap_get(data, i);
        	}
            if(data_item != NULL){
          		int res = client_handler(data_item, master, WHAT_READ);
          		if(res > 0){ // close connection
            		if((res & MASTER_DISCONNECT) == MASTER_DISCONNECT){
              			if(tcp_verbose){
                        	printf("- [%s:%d]\n", inet_ntoa(get_data_item_addr(data_item).sin_addr), ntohs(get_data_item_addr(data_item).sin_port));
              			}
            		}
            		rm_socket(i, data, master, res);
          		}
          		else if(res == -1){
				    if(tcp_verbose){
			      		handle_error(__FILE__, __LINE__);
            		}
          		}
            }
      	}
    	if(FD_ISSET(i, &write_fds)){
        	if(i != listener){
          		data_item = hashmap_get(data, i);
          		if(data_item != NULL){
            		int res = client_handler(data_item, master, WHAT_WRITE);
            		if(res > 0){ // close connection
              			if((res & MASTER_DISCONNECT) == MASTER_DISCONNECT){
                			if(tcp_verbose){
                  				printf("- [%s:%d]\n", inet_ntoa(get_data_item_addr(data_item).sin_addr), ntohs(get_data_item_addr(data_item).sin_port));
                			}
              			}
              			rm_socket(i, data, master, res);
            		}
          		}
        	}
      	}
    }
  }

}

void lock_master(MASTER_FD *master){
#if defined(WIN32) || defined(__WIN32__)
  	EnterCriticalSection(&master->lock);
#else
	struct sembuf sops;
  	sops.sem_num = 0;
  	sops.sem_op = 0;
  	sops.sem_flg = 0;
	semop(master->lock, &sops, 1);
  	sops.sem_op = 1;
	semop(master->lock, &sops, 1);
#endif
}

void unlock_master(MASTER_FD *master){
#if defined(WIN32) || defined(__WIN32__)
  	LeaveCriticalSection(&master->lock);
#else
	struct sembuf sops;
  	sops.sem_num = 0;
  	sops.sem_op = -1;
  	sops.sem_flg = 0;
	semop(master->lock, &sops, 1);
//  master->locked = 0;
#endif
}

void set_sockets(MASTER_FD *master, fd_set *read_fds,  fd_set *write_fds,  fd_set *exc_fds){
  	lock_master(master);
  	*read_fds = master->read; // copy it
	*write_fds = master->write; // copy it
	*exc_fds = master->exception; // copy it
  	unlock_master(master);
}

void add_socket(SOCKET fd, HASHMAP *data, void *data_item, MASTER_FD *master, int flags){
  	lock_master(master);
  	if((data != NULL) && (data_item != NULL)){
  		void *tmp = hashmap_get(data, fd);
        if(tmp == NULL){
  			hashmap_put(data, fd, data_item);
        }
  	}
  	if((flags & MASTER_READ) == MASTER_READ){
	  	FD_SET(fd, &master->read);
  	}
  	if((flags & MASTER_WRITE) == MASTER_WRITE){
	  	FD_SET(fd, &master->write);
  	}
  	if((flags & MASTER_EXCEPTION) == MASTER_EXCEPTION){
	  	FD_SET(fd, &master->exception);
  	}
  	if(master->fdmin == 0){
  		master->fdmin = fd;
  	}
  	else {
    	if(master->fdmin > fd){
      		master->fdmin = fd;
    	}
  	}
  	if(master->fdmax < fd){
    	master->fdmax = fd;
  	}
	if(tcp_verbose){
		printf("[%s, %d]\n", __FILE__, __LINE__);
		print_master(master);
		hashmap_print(data, NULL);
	}
  	unlock_master(master);
}

void calc_min_max(MASTER_FD *master){
  	SOCKET max, min, j;
  	max = 0;
  	min = 0;
  	for(j = master->fdmin; j <= master->fdmax; j++){
    	if(
      		FD_ISSET(j, &master->read)
      		|| FD_ISSET(j, &master->write)
      		|| FD_ISSET(j, &master->exception)
    	){
    	  	if(min == 0){
        		min = j;
	      	}
    	  	else {
        		if(min > j){
          			min = j;
	        	}
    	  	}
      		if(max < j){
	        	max = j;
    	  	}
	    }
  	}
  	master->fdmax = max;
  	master->fdmin = min;
}

void rm_socket(SOCKET fd, HASHMAP *data, MASTER_FD *master, int flags){
  	unsigned j;
  	SOCKET max, min;
  	lock_master(master);
  	if((flags & MASTER_READ) == MASTER_READ){
	  	FD_CLR(fd, &master->read);
  	}
  	if((flags & MASTER_WRITE) == MASTER_WRITE){
	  	FD_CLR(fd, &master->write);
  	}
  	if((flags & MASTER_EXCEPTION) == MASTER_EXCEPTION){
	  	FD_CLR(fd, &master->exception);
  	}
  	if(
  		!FD_ISSET(fd, &master->read)
    	&& !FD_ISSET(fd, &master->write)
    	&& !FD_ISSET(fd, &master->exception)
  	){
    	closesocket(fd);
    	if(data != NULL){
	    	void *data_item = hashmap_remove(data, fd);
      		if(data_item != NULL){
      			free(data_item);
      		}
    	}
    	calc_min_max(master);
  	}
	if(tcp_verbose){
		printf("[%s, %d]\n", __FILE__, __LINE__);
		print_master(master);
		hashmap_print(data, NULL);
	}
  	unlock_master(master);
}

void walk_master(HASHMAP *data, void *data_item, MASTER_FD *master, int (__cdecl *walker)(void*,void*)){
  	unsigned j;
  	int removed = 0;
	if(walker == NULL){
  		return;
  	}
  	lock_master(master);
  	for(j = master->fdmin; j <= master->fdmax; j++){
  		if(FD_ISSET(j, &master->read) || FD_ISSET(j, &master->write) || FD_ISSET(j, &master->exception)){
	    	void *data_item1 = hashmap_get(data, j);
		  	if(data_item1 != NULL){
      			if(walker(data_item, data_item1) != 0){
          			removed = 1;
printf("[%s,%d] %d\n", __FILE__,__LINE__, j);
			    	closesocket(j);
          			data_item1 = hashmap_remove(data, j);
          			if(data_item1 != NULL){
            			free(data_item1);
          			}
        		}
      		}
    	}
  	}
  	if(removed){
    	calc_min_max(master);
  	}
  	unlock_master(master);
}

void print_master(MASTER_FD *master){
  	unsigned j;
  	printf("read: ");
  	for(j = master->fdmin; j <= master->fdmax; j++){
  		if(FD_ISSET(j, &master->read)){
        	printf("%d ", j);
    	}
  	}
  	printf("\nwrite: ");
  	for(j = master->fdmin; j <= master->fdmax; j++){
  		if(FD_ISSET(j, &master->write)){
	  		printf("%d ", j);
    	}
  	}
  	printf("\nexception: ");
  	for(j = master->fdmin; j <= master->fdmax; j++){
  		if(FD_ISSET(j, &master->exception)){
	  		printf("%d ", j);
    	}
  	}
  	printf("\nfdmin: %d, fdmax: %d\n", master->fdmin, master->fdmax);
}


