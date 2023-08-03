import os
import sys
import appdirs
from FileIO import BasicFileIO
import json

import os
import appdirs
import shutil

class Config(BasicFileIO):
    def __init__(self):
        
        # Get the user-specific writable directory for your app (cross-platform)
        appWritableDir = appdirs.user_data_dir(appname='EncryptedNotepad', appauthor='oxygenStudio')
        
        os.makedirs(appWritableDir, exist_ok=True)
        
        # Destination path in the app's writable directory
        configDestinationPath = os.path.join(appWritableDir, 'config.json')
        # print(configDestinationPath)

        # Check if the config file already exists in the writable directory
        if not os.path.exists(configDestinationPath):
            if getattr(sys, 'frozen', False):
                # this is a Pyinstaller bundle
                root_path = sys._MEIPASS
            else:
                # normal python process
                root_path = os.getcwd()

            # Assume your config.py is located in the same directory as your script
            configSourcePath = os.path.join(root_path, 'config.json')
            
            # Copy the config file to the writable directory
            shutil.copyfile(configSourcePath, configDestinationPath)

        # Now you can proceed with loading your config file
        self.configPath = configDestinationPath

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
