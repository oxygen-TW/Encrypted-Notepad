import os
import shutil
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
    bp = BatchProcessor("0000")
    encryptedFile = EncryptedFlieIO()
    bio = BasicFileIO()
    bp.decrypt("/Users/howard/Programming/Projects/Encrypted-Notepad/Test/T2", "/Users/howard/Programming/Projects/Encrypted-Notepad/Test/T2d")

