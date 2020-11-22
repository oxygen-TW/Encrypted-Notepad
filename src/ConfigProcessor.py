from FileIO import BasicFileIO
import json

class Config(BasicFileIO):
    def __init__(self):
        self.configPath = "config.json"
        self.config = {}
        self.__read()
    
    #包裝 self.config
    def load(self):
        self.__read()
        return self.config

    def update(self):
        self.__write(self.config)
        
    def __read(self):
        config = self.open(self.configPath)
        self.config = json.loads(config)

    def __write(self, configText):
        self.save(json.dumps(configText), self.configPath)

        
if __name__ == "__main__":
    c = Config()
    print(c.config["main"]["version"])
