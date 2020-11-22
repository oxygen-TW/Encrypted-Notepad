from Crypto.Cipher import AES
from Crypto.Util import Padding
from hashlib import md5, sha512
from base64 import b64encode, b64decode

#Ref https://gist.github.com/Frizz925/ac0fb026314807959db5685ac149ed67
def convertPasspharse(passpharse):
    passpharse = EncryptedCore.addSalt(passpharse)
    return b64encode(md5(passpharse.encode('utf-8')).hexdigest().encode('utf-8')).decode('utf-8')

class EncryptedCore():

    def AESCBCencrypt(self, text, key):
        key = self.addSalt(key)
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
        key = self.addSalt(key)
        key = md5(key.encode('utf-8')).hexdigest().encode('utf-8')
        body = b64decode(text.encode('utf-8'))
        iv = b64decode(iv.encode('utf-8'))
        cipher = AES.new(key, AES.MODE_CBC, iv)

        body = Padding.unpad(cipher.decrypt(body), AES.block_size).decode('utf-8')
        return body

    @staticmethod
    def addSalt(keypharse):
        keypharse = keypharse[::-1] #倒轉
        return "15dsaDS23@!SDAs546d" + keypharse + "45SDAsd$rEa5s" #saltA + key + saltB

    @staticmethod
    def HashSHA512(text):
        return sha512(text.encode("utf-8")).hexdigest().encode("utf-8")

#Debug only
if __name__ == "__main__":
    e = EncryptedCore()
    print(e.AESCBCencrypt("1234", "0000"))