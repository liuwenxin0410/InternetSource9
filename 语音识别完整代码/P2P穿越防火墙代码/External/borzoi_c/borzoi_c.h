#ifndef borzoi_cH
#define borzoi_cH

#ifdef __cplusplus
extern "C" {
#endif

extern void eckas_dh1 (char *pkA, char *skB, char *buf);
extern int generate_pair(char *username);
extern int cmp_public_keys(char *pkA, char *pkB);
extern int aes_decrypt(char *KB, char *buf, unsigned *len);
extern int open_public_key(char *username, char *buf);
extern int open_private_key(char *username, char *buf);
extern int aes_encrypt(char *KB, char *buf, unsigned *len);

#ifdef __cplusplus
}
#endif

#define PUBLIC_KEY_LEN 216
#define PRIVATE_KEY_LEN 181
#define SYMMETRIC_KEY_LEN 16

#endif
