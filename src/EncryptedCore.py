from Crypto.Cipher import AES
from Crypto.Util import Padding
from hashlib import md5, sha512
from base64 import b64encode, b64decode

#Ref https://gist.github.com/Frizz925/ac0fb026314807959db5685ac149ed67
class EncryptedCore():

    def AESCBCencrypt(self, text, key):
        # encrypting
        key = md5(key.encode('utf-8')).hexdigest().encode('utf-8')
        body = Padding.pad(text.encode('utf-8'), AES.block_size)
        iv = key[8:AES.block_size+8]

        cipher = AES.new(key, AES.MODE_CBC, iv)
        key = b64encode(key).decode('utf-8')
        body = b64encode(cipher.encrypt(body)).decode('utf-8')
        iv = b64encode(iv).decode('utf-8')

        #print("%s\t%s\t%s" % (key, body, iv))
        return (key, body, iv)

    def AESCBCdecrypt(self, text, key, iv):
        key = md5(key.encode('utf-8')).hexdigest().encode('utf-8')
        body = b64decode(text.encode('utf-8'))
        iv = b64decode(iv.encode('utf-8'))
        cipher = AES.new(key, AES.MODE_CBC, iv)

        body = Padding.unpad(cipher.decrypt(body), AES.block_size).decode('utf-8')
        return body

    def HashSHA512(self, text):
        return sha512(text.encode("utf-8")).hexdigest().encode("utf-8")

    def __pad(self, text):
        while len(text) % 16 != 0:
            text  += b' '
            return text

    def __pad_key(self, key):
        while len(key) % 16 != 0:
            key  += b' '
            return key

#Debug only
if __name__ == "__main__":
    ec = EncryptedCore()
    r = ec.AESCBCencrypt("中文", "1234678")
    ec.AESCBCdecrypt(r[1], r[0], r[2])
    print(ec.HashSHA512("123"))