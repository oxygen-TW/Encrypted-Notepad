# Encrypted-Notepad

**加密記事本專案**
<br/>
**Encrypted-Notepad Project 2017-2020**

![image](https://oxygentw.net/files/logo.png)
 
## How to download?
- Visit our release https://github.com/oxygen-TW/Encrypted-Notepad/releases
- SourceForge: https://sourceforge.net/projects/encryption-notepad/

## How to install?
1. Download Encrypted Notepad.
2. Uncompress the ZIP file.
3. Run Setup.exe
4. When first use this software,you have to set you KEY that use for encrypt your file.
5. After KEY setting,You should change the default USER PASSWORD,the default password is ```0000```.
6. Enjoy it!

## Structure of Encryption core
![image](https://github.com/oxygen-TW/Encrypted-Notepad/blob/master/doc/img/Cross-Encryption-core-v2.0.png?raw=true)

## Module tool

### BatchProcessor(*Testing*)
```                                   
usage: batchProcessor.py [-h] -i INPUT -o OUTPUT -p PASSWORD [-e] [-d]

Batch processor of EncryptedNotepad

options:
  -h, --help            show this help message and exit
  -i INPUT, --input INPUT
                        The folder path you want to process.
  -o OUTPUT, --output OUTPUT
                        The destination folder path.
  -p PASSWORD, --password PASSWORD
                        Your user password.
  -e                    Encrypt mode.
  -d                    Decrypt mode.
```
## Developer
1. `conda install pyCryptodome PyQt`
2. `python EncryptedNotepad.py`
