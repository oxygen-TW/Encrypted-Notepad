from ConfigProcessor import Config

class keytool(Config):
    
    def __init__(self):
        super().__init__()
        self.c = self.load()

    def WriteKey(self, key):
        self.c["program"]["secretKey"] = key
        self.update()

    def ReadKey(self):
        return self.c["program"]["secretKey"]

if __name__ == "__main__":
    k = keytool()
    print(k.ReadKey())
