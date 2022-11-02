#include <fstream>
#include "borzoi.h"
#include "nist_curves.h" // Include this to use the curves recommended by NIST

#include <time.h>

#define FILENAME_BUFFER_SIZE 1024
#define KEY_SIZE 128

#include "borzoi_c.h"

void eckas_dh1 (char *pkA, char* skB, char *buf){
	OCTETSTR pA (216);
  for(unsigned i = 0; i < 216; i++){
  	pA[i] = pkA[i];
  }
	OCTETSTR sB (181);
  for(unsigned i = 0; i < 181; i++){
  	sB[i] = skB[i];
  }

	use_NIST_B_163 ();
	EC_Domain_Parameters dp = NIST_B_163;

	DER derPkA (pA);

  ECPubKey pka = derPkA.toECPubKey();
	DER derSkB (sB);
  ECPrivKey skb = derSkB.toECPrivKey();

  OCTETSTR key = ECKAS_DH1(dp, skb.s, pka.W);
  for(unsigned i = 0; i < 16; i++){
  	buf[i] = key[i];
  }

}

int rnd = 0;


int generate_pair(char *username){
	if((username == NULL)){
  	return -1;
  }
	use_NIST_B_163 ();
	EC_Domain_Parameters dp = NIST_B_163;

  if(rnd == 0){
  	srand(time(NULL));
    rnd = 1;
  }
	ECPrivKey privKeyA (dp, OS2IP(SHA1(rand())));
	ECPubKey pubKeyA (privKeyA);

	DER derS (privKeyA);
	DER derP (pubKeyA);

  char outfilename[FILENAME_BUFFER_SIZE];

  strncpy(outfilename, username, FILENAME_BUFFER_SIZE - 1);
  strncat(outfilename, ".sk", FILENAME_BUFFER_SIZE - 1 - strlen(outfilename));

	std::ofstream key_outfile (outfilename, std::ios::binary);
	if (!key_outfile) {
		std::cout << "Error can't open file!\n";
		return -1;
	}

  HexEncoder hexS = HexEncoder(derS);
	key_outfile << hexS;
	key_outfile.close();

  strncpy(outfilename, username, FILENAME_BUFFER_SIZE - 1);
  strncat(outfilename, ".pk", FILENAME_BUFFER_SIZE - 1 - strlen(outfilename));

	std::ofstream key_outfile1 (outfilename, std::ios::binary);
	if (!key_outfile1) {
		std::cout << "Error can't open file!\n";
		return -1;
	}
  HexEncoder hexP = HexEncoder(derP);
	key_outfile1 << hexP;
	key_outfile1.close();

  return 0;

}

int open_key(char *username, char *ext, char *buf){
  OCTETSTR derK_v;
  if(username != NULL){
    std::string filename(username);
    filename += ext;

    std::ifstream key_infile (filename.c_str(), std::ios::binary);

    if (key_infile) {

      char c, c1; OCTET o;
      int i = 0;
      while (key_infile.get (c1)) {
      	i++;
        if(i%2 == 1){
        	if(c1 <= '9'){
        		c = 16 * (c1 - '0');
          }
          else {
        		c = 16 * (c1 - 'a' + 10);
          }
        	continue;
        }
        if(c1 <= '9'){
          c += (c1 - '0');
        }
        else {
          c += (c1 - 'a' + 10);
        }
        c &= 0xff;
        o = (unsigned char)c;
        derK_v.push_back (o);
      }

      key_infile.close();

      for(unsigned i = 0; i < derK_v.size(); i++){
      	buf[i] = derK_v[i];
      }
		  return 0;
    }
  }
  return -1;
}

int cmp_public_keys(char *pkA, char *pkB){
  int res = 0;
  for(int i = 0; i < 216; i++){
    if(pkA[i] != pkB[i]){
      res = -1;
      break;
    }
  }
	return res;
}

int open_public_key(char *username, char *buf){
	return open_key(username, ".pk", buf);

}

int open_private_key(char *username, char *buf){
	return open_key(username, ".sk", buf);
}

int aes_encrypt(char *KB, char *buf, unsigned *len){
	OCTETSTR K (16);
  for(unsigned i = 0; i < 16; i++){
  	K[i] = KB[i];
  }
	OCTETSTR M (*len);
  for(unsigned i = 0; i < *len; i++){
  	M[i] = buf[i];
  }
	OCTETSTR C = AES_CBC_IV0_Encrypt (K, M, KEY_SIZE);
  *len = C.size();
  for(unsigned i = 0; i < *len; i++){
  	buf[i] = C[i];
  }
  return 0;
}

int aes_decrypt(char *KB, char *buf, unsigned *len){
	OCTETSTR K (16);
  for(unsigned i = 0; i < 16; i++){
  	K[i] = KB[i];
  }
	OCTETSTR C (*len);
  for(unsigned i = 0; i < *len; i++){
  	C[i] = buf[i];
  }
  try {
		OCTETSTR M = AES_CBC_IV0_Decrypt (K, C, KEY_SIZE);
	  *len = M.size();
	  for(unsigned i = 0; i < *len; i++){
  		buf[i] = M[i];
	  }
    return 0;
  }
  catch(borzoiException e){
  	return 1;
  }
}


