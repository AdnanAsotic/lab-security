# Cryptography

Ensure

- Confidentiality (Symetric, Asymetric encryption use AES, RSA)
- Integrity (Hashing + HMAC)
- Non-Repudiation (Recipient cannot deny that he received a message - Digital Certificate)
- Authentication (SSL/TLS - Digital Certificate)

## Hashing

- One way operation
- Digital fingerprint
- Different data has different chase
- Mechanism for checking integrity of data
- Fast

### MD5

- OLD, DON'T USE !!!

### SHA

- SHA-1 (160 bit), SHA-256, SHA-512
- SHA-256 (best practice)

### Hashed Message Authentication Code (HMAC)

Technique to validate integrity of message (message hasn't been changed). 
Also authenticity can be validated as only parties with same key can calculate the right hash. 

- Integrity (message hasn't been changed) + Authenticity (message is from which it has to be)
- Code must be known by both parties

## Secure Password Storage

- Password doesn't need to be encrypted.
- Passwords should be hashed and salted !!!
- Hashed passwords can be attacked
	- Brute Force
	- Rainbow Table
- Crackstation

### Salting

- Extend password with random number (salt).
- Use new salt on each new hashing.
- Still problem as computers are faster.
- USE PASSWORD BASED KEY DERIVATION FUNCTIONS !!!
	- Password + Salt * [number of iterations - best = 50000]

### Key Derivation

## Symetric Encryption

- Two way encryption process which uses a key to produce encrypted data. (cypher text)
- Extremely Secure
- AES unbroken
- Relatively fast
- Problem is the shared key !!!

### AES, DES, Triple DES

- Use AES256
	- 32 byte Key
	- 16 byte IV
- AES
	- Very safe and not broken.
	- Pretty fast


## Asymetric Encryption

- Use at least 2048 bit.
- Public and private keys are based on prime numbers
- ? x ? = 5963

## Hybrid Encryption

- Hashed Message Authentication Code
	- Share with RSA

- Client generates AES key
- IV
- Encrypt with AES, IV
- Encrypt Session Key with Public Key
- Calculate HMAC of data and AES key
- Package of data is sent to recipient.

- Decrypt AES session key
- Recalculate HMAC

## Digital signing

A digital signature is a technique to validate the authenticity of a message. Gives authentication and non-repudiation.

- Signing with private key
- Verification with public key

### Implementation in .NET

- RSACryptoServiceProvider
- RSAPKCS1SignatureFormatter
- RSAPKC1SignatureDeformatter

1. Alice encrypts her data (symmetric or assymetric doesn't matter)
2. Alice takes hash of data
3. Alice signts the data with her private signing data => digital signature
4. Alice sends data, hash and signature to Bob
5. Bob calculates hash of encrypted data
6. Bob verifies the digital signature using the public key


## SecureString

- System.String has copies
	- not encrypted
- Use SecureString
	- only decrypted when used
