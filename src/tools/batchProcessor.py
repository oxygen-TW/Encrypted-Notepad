import os
import shutil
import sys
import argparse
from FileIO import EncryptedFlieIO, BasicFileIO
from keytools import keytool

class BatchProcessor(keytool, BasicFileIO):
    """
    Batch encrypt/decrypt files.
    """
    def __init__(self, userPassword):
        super().__init__()
        self.key = self.ReadKey(userPassword)
        self.encryptedFile = EncryptedFlieIO()
        print(self.key)

    def _fileTraversal(self, directory: str, extension: str) -> list:
        """
        Return all files with specific extension under directory and sub-directory
        """
        return [os.path.join(dirpath, f)
            for dirpath, _, files in os.walk(directory)
            for f in files if f.endswith(extension)]

    def encrypt(self, inputDir:str, outputDir:str):
        files = self._fileTraversal(inputDir, ".txt")

        for file in files:
            tmpText = self.open(file)
            outputFile = os.path.join(outputDir, os.path.basename(file).split('.')[0]+".ent")
            self.encryptedFile.save(tmpText, outputFile, self.key)

    def decrypt(self, inputDir:str, outputDir:str):

        files = self._fileTraversal(inputDir, ".ent")

        for file in files:
            tmpText = self.encryptedFile.open(file, self.key)
            outputFile = os.path.join(outputDir, os.path.basename(file).split('.')[0]+".txt")
            self.save(tmpText, outputFile)

if(__name__ == "__main__"):
    parser = argparse.ArgumentParser(description='Batch processor of EncryptedNotepad')
    parser.add_argument("-i", "--input", help="The folder path you want to process.",
                    type=str, required=True)
    parser.add_argument("-o", "--output", help="The destination folder path.",
                    type=str, required=True)
    parser.add_argument("-p", "--password", help="Your user password.",
                    type=str, required=True)
    parser.add_argument('-e', action='store_true', help="Encrypt mode.")
    parser.add_argument('-d', action='store_true', help="Decrypt mode.")

    args = parser.parse_args()

    if(not(args.e ^ args.d)):
        print("You must choose ONE mode.")
        exit(1)

    inputPath = args.input
    outputPath = args.output
    userPassword = args.password

    cmd = ""

    while(cmd.upper() != "Y" and cmd.upper() != "N"):
        cmd = input(f"Are you sure you want to process all files in {inputPath} and save to {outputPath}?(Y/N)")

    if(cmd.upper() == "N"):
        sys.exit(0)
    
    batch = BatchProcessor(userPassword)

    try:
        if(args.e):
            batch.encrypt(inputPath, outputPath)
        else:
            batch.decrypt(inputPath, outputPath)
    except Exception as e:
        print(str(e))
        print("Password is not valid.")
        sys.exit(1)
    
    print("Done!")
    
    
