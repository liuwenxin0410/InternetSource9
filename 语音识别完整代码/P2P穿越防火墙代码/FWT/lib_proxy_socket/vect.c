#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include "vect.h"
#include "error_handler.h"
#if defined(WIN32) || defined(__WIN32__)
#include <string.h>
#else
#include <sys/sem.h>
#endif

void vector_connect(VECTOR *v);
void vector_disconnect(VECTOR *v);
void lock_vector(VECTOR *v);
void unlock_vector(VECTOR *v);
int upsize_vector(VECTOR *v);
void _vector_add(VECTOR *v, void* item);
void _vector_insert(VECTOR *v, void* item, unsigned i);
void _vector_delete(VECTOR *v, unsigned i);
void _print_item(VECTOR *v, void* name, char *file, int line, void* item);

VECTOR *create_vector(unsigned initial_capacity, unsigned width, int (__cdecl *cmp)(const void*, const void*)){

#if !defined(WIN32) && !defined(__WIN32__)

  	VECTOR *result = (VECTOR *)malloc(sizeof(VECTOR));
  	memset(result, 0, sizeof(VECTOR));
  	result->lock = semget(get_key(), 1, 0666 | IPC_CREAT | IPC_EXCL);
  	if(result->lock == -1){
    	handle_error(__FILE__, __LINE__);
		exit(0);
  	}
  	memset(result->flags, 0, sizeof(unsigned ) * 4);
	result->data = (char*)malloc(width * initial_capacity);
  	memset(result->data, 0, width * initial_capacity);
  	result->flags[VECTOR_CAPACITY_FLAG] = initial_capacity;

  	result->flags[VECTOR_SIZE_FLAG] = 0;
  	result->flags[VECTOR_ITEM_WIDTH_FLAG] = width;
  	result->compare = cmp;

  	return result;
#endif //#if !defined(WIN32) && !defined(__WIN32__)

#if defined(WIN32) || defined(__WIN32__)
  	VECTOR *result = (VECTOR *)malloc(sizeof(VECTOR));
  	memset(result, 0, sizeof(VECTOR));
	InitializeCriticalSection(&result->lock);
  	memset(result->flags, 0, sizeof(unsigned ) * 4);
	result->data = (char*)malloc(width * initial_capacity);
  	memset(result->data, 0, width * initial_capacity);
  	result->flags[VECTOR_CAPACITY_FLAG] = initial_capacity;

  	result->flags[VECTOR_SIZE_FLAG] = 0;
  	result->flags[VECTOR_ITEM_WIDTH_FLAG] = width;
  	result->compare = cmp;

  	return result;
#endif //#if !defined(WIN32) && !defined(__WIN32__)
}

void lock_vector(VECTOR *v){
#if !defined(WIN32) && !defined(__WIN32__)
	struct sembuf sops;
  	sops.sem_num = 0;
  	sops.sem_op = 0;
  	sops.sem_flg = 0;
	semop(v->lock, &sops, 1);
  	sops.sem_op = 1;
	semop(v->lock, &sops, 1);
#endif //#if !defined(WIN32) && !defined(__WIN32__)


#if defined(WIN32) || defined(__WIN32__)
  	EnterCriticalSection(&v->lock);
#endif //#if defined(WIN32) || defined(__WIN32__)
}

void unlock_vector(VECTOR *v){
#if !defined(WIN32) && !defined(__WIN32__)
	struct sembuf sops;
  	sops.sem_num = 0;
  	sops.sem_op = -1;
  	sops.sem_flg = 0;
	semop(v->lock, &sops, 1);
#endif //#if !defined(WIN32) && !defined(__WIN32__)

#if defined(WIN32) || defined(__WIN32__)
  	LeaveCriticalSection(&v->lock);
#endif //#if defined(WIN32) || defined(__WIN32__)
}

void delete_vector(VECTOR *v){
#if !defined(WIN32) && !defined(__WIN32__)
	struct shmid_ds buf;
  	lock_vector(v);
	free(v->data);
  	if(semctl(v->lock, IPC_RMID, 0, 0) == -1){
    	handle_error(__FILE__, __LINE__);
		exit(0);
  	}
#endif //#if !defined(WIN32) && !defined(__WIN32__)


#if defined(WIN32) || defined(__WIN32__)
  	lock_vector(v);
	free(v->data);
  	LeaveCriticalSection(&v->lock);
	DeleteCriticalSection(&v->lock);
#endif //#if defined(WIN32) || defined(__WIN32__)

}

void _vector_delete(VECTOR *v, unsigned i){
	if(i < v->flags[VECTOR_SIZE_FLAG]){
  		return;
  	}
  	if(v->flags[VECTOR_SIZE_FLAG] > i + 1){
  		memmove(
      		v->data + (i + 1) * v->flags[VECTOR_ITEM_WIDTH_FLAG],
      		v->data + i * v->flags[VECTOR_ITEM_WIDTH_FLAG],
      		(v->flags[VECTOR_SIZE_FLAG] - i - 1) * v->flags[VECTOR_ITEM_WIDTH_FLAG]
    	);
  	}
  	v->flags[VECTOR_SIZE_FLAG]--;
}

void vector_delete(VECTOR *v, unsigned i){
  	vector_connect(v);
  	lock_vector(v);
  	_vector_delete(v, i);
  	unlock_vector(v);
  	vector_disconnect(v);
}

void vector_add(VECTOR *v, void* item){
  	vector_connect(v);
  	lock_vector(v);
  	_vector_add(v, item);
  	unlock_vector(v);
  	vector_disconnect(v);
}

int vector_bsearch(VECTOR *v, void* key, void* buf, int (__cdecl *replace)(void*, void*),
		void* new_item, int *replaced, int add){
	char *res = NULL;
  	int result;
  	vector_connect(v);
  	lock_vector(v);
  	if(replaced != NULL){
  		*replaced = 0;
  	}
  	if(v->compare != NULL){
  		if(v->flags[VECTOR_SIZE_FLAG] > 0){
			res = (char*)bsearch(key, v->data, v->flags[VECTOR_SIZE_FLAG], v->flags[VECTOR_ITEM_WIDTH_FLAG], v->compare);
    	}
    	if(res != NULL){
      		if(replace != NULL){
        		if(replace(res, new_item) == 0){
					if(replaced != NULL){
          				*replaced = 1;
          			}
        		}
      		}
      		if(buf != NULL){
		      	memcpy(buf, res, v->flags[VECTOR_ITEM_WIDTH_FLAG]);
	        }
    	  	result = 0;
	    }
    	else {
	    	result = 1;
    	  	if(add){
	        	_vector_add(v, key);
	      		if(buf != NULL){
			  	    memcpy(buf, key, v->flags[VECTOR_ITEM_WIDTH_FLAG]);
    	  		}
	      	}
    	}
  	}
  	unlock_vector(v);
  	vector_disconnect(v);
  	return result;
}

void print_item(VECTOR *v, void* name, char *file, int line, void* item){
  	vector_connect(v);
  	lock_vector(v);
  	_print_item(v, name, file, line, item);
  	unlock_vector(v);
  	vector_disconnect(v);
}

void _print_item(VECTOR *v, void* name, char *file, int line, void* item){
	int i;
	printf("%s, %d: %s: ", file, line, name);
	for(i = 0; i < (int)v->flags[VECTOR_ITEM_WIDTH_FLAG]; i++){
		printf("0x%x ", *((char*)item + i));
	}
	printf("\n");
}

void _vector_add(VECTOR *v, void* item){
  	upsize_vector(v);
  	memcpy(v->data + v->flags[VECTOR_SIZE_FLAG] * v->flags[VECTOR_ITEM_WIDTH_FLAG], item, v->flags[VECTOR_ITEM_WIDTH_FLAG]);

  	v->flags[VECTOR_SIZE_FLAG]++;
  	if(v->compare != NULL){
  		qsort(v->data, v->flags[VECTOR_SIZE_FLAG], v->flags[VECTOR_ITEM_WIDTH_FLAG], v->compare);
  	}
}

void _vector_insert(VECTOR *v, void* item, unsigned i){
  	if(i >= v->flags[VECTOR_SIZE_FLAG]){
		_vector_add(v, item);
  	}
  	else {
	  	upsize_vector(v);
    	memmove(
    		v->data + i * v->flags[VECTOR_ITEM_WIDTH_FLAG],
      		v->data + (i + 1) * v->flags[VECTOR_ITEM_WIDTH_FLAG],
      		(v->flags[VECTOR_SIZE_FLAG] - i) * v->flags[VECTOR_ITEM_WIDTH_FLAG]
        );
	  	v->flags[VECTOR_SIZE_FLAG]++;
  		memcpy(v->data + i * v->flags[VECTOR_ITEM_WIDTH_FLAG], item, v->flags[VECTOR_ITEM_WIDTH_FLAG]);
  	}
}

void vector_insert(VECTOR *v, void* item, unsigned i){
  	vector_connect(v);
  	lock_vector(v);
  	_vector_insert(v, item, i);
  	unlock_vector(v);
  	vector_disconnect(v);
}

void vector_walk(VECTOR *v, void (__cdecl *func)(void*, unsigned, unsigned, void*), void* func_data){
	int i;
  	vector_connect(v);
  	lock_vector(v);
  	for(i = 0; i < (int)v->flags[VECTOR_SIZE_FLAG]; i++){
  		if(func != NULL){
  			func(v->data + i * v->flags[VECTOR_ITEM_WIDTH_FLAG], i, v->flags[VECTOR_SIZE_FLAG], func_data);
    	}
  	}
  	unlock_vector(v);
  	vector_disconnect(v);
}

void vector_connect(VECTOR *v){
}

void vector_disconnect(VECTOR *v){
}

int upsize_vector(VECTOR *v){
  	if(v->flags[VECTOR_CAPACITY_FLAG] < (v->flags[VECTOR_SIZE_FLAG] + 1)){
    	v->flags[VECTOR_CAPACITY_FLAG] *= 2;
  		v->data = (char*)realloc(v->data, v->flags[VECTOR_ITEM_WIDTH_FLAG] * v->flags[VECTOR_CAPACITY_FLAG]);
    	return 0;
  	}
  	return 1;
}
