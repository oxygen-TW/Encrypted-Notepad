from FileIO import BasicFileIO, EncryptedFlieIO

class keytool(BasicFileIO):
    
    def __init__(self):
        self.keypath = "app"

    def WriteKey(self, key):
        self.save(key, self.keypath)

    def ReadKey(self):
        return self.open(self.keypath)

if __name__ == "__main__":
    k = keytool()
    print(k.ReadKey())
