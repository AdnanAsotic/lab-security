# Security

## SSL (Secure Sockets Layer)

- Encrypt data
- Authenticate Server / Client
- Identity is verified with Certificate Authority
- Key is generated on client and sent to server by Alghorithm.

## Creating a CSR

- Open IIS
- Create Certificate Request
- Select Microsoft RSA SChannel Cryptographic Provider
- Set Bit Length to 2048
- Set File to Export to
- Save file

## Installing a SSL certificate on Windows Server 2012 R2

- Formats
    - .der
        - Binary encoded
    - .b64
        - String encoded
- .pfx
    - Contains whole certificate (private, intermediate-optional, public)
    - Needs a private key to be generated (generated with CSR)
    
- *.pem, *.crt, *.ca-bundle, *.cer, *.p7b, *.p7s
    - Contains digital certificate files
- .cer, .p7s or .p7b
    - Issued for IIS, TOMCAT, MS Exchange Server
    - PKCS #7
- .pem, .crt
    - Issued for Apache

## Process
- Generate a certificate signing request (CSR) and send to authority
- Authority signs the request and returns digital certificate.
- Install the certificate gotten from vendor 
- Certificate signing request is removed from mmc.
- Setup bindings (443)