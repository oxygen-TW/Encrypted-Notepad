from EncryptedCore import EncryptedCore
from base64 import b64encode, b64decode

class EncryptedFlieIO(EncryptedCore):

    def __init__(self):  
        pass

    def save(self, text, path, key):
        with open(path, "w") as f:
            t = super().AESCBCencrypt(text, key)
            etext = t[1]
            iv = t[2]
            print("e={} iv={}".format(etext, iv))
            text = etext+"::"+iv
            f.write(text)
            f.close()
        return True

    def open(self, path, key):
        with open(path, "r") as f:
            etext = f.read()
            f.close()
            t = etext.split("::")
            print("e={} iv={}".format(t[0], t[1]))
            text = super().AESCBCdecrypt(t[0], key, t[1])
            return text
        

class BasicFileIO():
    def save(self, text, path):
        with open(path, "w") as f:
            f.write(text)
            f.close()

    def open(self, path):
        with open(path, "r") as f:
            text = f.read()
            f.close()
            return text


if __name__ == "__main__":
    fio = EncryptedFlieIO()
    fio.save("測試", "test.txt", "13")
    print(fio.open("test.txt", "13"))