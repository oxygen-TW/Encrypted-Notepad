from ConfigProcessor import Config
from EncryptedCore import EncryptedCore
from PyQt5.QtWidgets import QApplication, QMainWindow, QInputDialog, QMessageBox, QAction

class keytool(Config, EncryptedCore):
    
    def __init__(self):
        super().__init__()
        self.c = self.load()

    def WriteKey(self, key, userPassword):
        self.c["program"]["secretKey"] = self.EncryptKey(key, userPassword)
        self.update()

    def ReadKey(self, userPassword):
        e, iv = self.c["program"]["secretKey"].split("::")
        try:
            dkey = self.AESCBCdecrypt(e, userPassword, iv)
        except Exception as identifier:
            print(str(identifier))
            return False
        
        return dkey

    def UpdateUserPassword(self, userPassword):
        self.WriteKey(self.c["program"]["secretKey"], userPassword)
        
    def EncryptKey(self, key, userPassword):
        EntKey = self.AESCBCencrypt(key, userPassword)
        return EntKey[1]+"::"+EntKey[2]
        
    def checkKeyExist(self):
        return self.c["program"]["secretKey"] != ""

    def __dialog_message(self, Qw, message, icon):
        dlg = QMessageBox(Qw)
        dlg.setText(message)
        dlg.setIcon(icon)
        dlg.show()

    def __showDialog(self, title, dialogText):
        text, ok = QInputDialog.getText(self, title, dialogText)
        if ok:
            return str(text)

if __name__ == "__main__":
    k = keytool()
    print(k.EncryptKey("1234", "0000"))
    #print(k.DecryptKey("0000"))
