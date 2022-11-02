#include <stdio.h>
#include "borzoi_c.h"

int main(int argc, char* argv[])
{
  int i;

  if(argc < 2){
  	printf("Usage: %s username [...]\n", argv[0]);
  }
  for(i = 1; i <= argc; i++){
		generate_pair(argv[i]);
  }
	return 0;
}
//---------------------------------------------------------------------------
