import sys, os
from PyQt5.QtWidgets import QApplication, QMainWindow, QInputDialog, QMessageBox, QAction, QLineEdit
from PyQt5.QtGui import  QKeySequence, QIcon


from mainUI import NotepadUI
from authPageUI import Ui_AuthPageUI

from EncryptedCore import convertPasspharse
from keytools import keytool

class AuthPageUI(QMainWindow, Ui_AuthPageUI):
    def __init__(self, FileArgs):
        super(AuthPageUI, self).__init__()

        self.setupUi(self)
        self.setWindowIcon(QIcon("icon.ico"))

        # 檢查檔案參數是否存在
        if not(os.path.isfile(FileArgs)) and FileArgs != "":
            self.__dialog_message("Can not open file: " + FileArgs)
            self.FileArgs = ""
        else:
            self.FileArgs = FileArgs
        #確認是否需要初始化金鑰
        kt = keytool()
        if(not(kt.checkKeyExist())):
            if(not(self.showInitKeyDialog())):
                self.__dialog_message("Can not write new key", QMessageBox.Critical)
                exit(1)

        self.AuthButton.clicked.connect(self.Authentication)
        self.PasswordEdit.setEchoMode(QLineEdit.Password)

# connect(act2, SIGNAL(triggered(bool)), act1, SIGNAL(triggered(bool)));
        act = QAction(self)
        act.setShortcut(QKeySequence("Enter"))
        act.triggered.connect(self.Authentication)
        self.addAction(act)

        self.AuthButton.clicked.connect(self.Authentication)
        self.ResetButton.clicked.connect(self.resetPassword)

    def Authentication(self):
        userInput = self.PasswordEdit.text()
        print(userInput)
        kt = keytool()
        if(kt.ReadKey(userInput) == False):
            self.PasswordEdit.setText("")
            print("Failed")
            self.__dialog_message("驗證失敗，使用者密碼輸入錯誤")
            return False

        print("ok")
        self.switchToMainPage(kt.ReadKey(userInput))

    def resetPassword(self):
        userpasswd = self.__showDialog("Reset password", "Input password")
        kt = keytool()
        if(kt.ReadKey(userpasswd) == False):
            self.__dialog_message("Failed to Auth")
            return False
        
        newPasswd = self.__showDialog("Reset password", "Input new password")
        newPasswd_again = self.__showDialog("Reset password", "Input new password again")

        if(newPasswd != newPasswd_again):
            self.__dialog_message("New password does not match")
            return False

        kt.UpdateUserPassword(userpasswd, newPasswd)
        dlg = QMessageBox(self)
        dlg.setText("Reset password success!")
        dlg.setIcon(QMessageBox.Information)
        dlg.show()
        return True

    def switchToMainPage(self, userInput):
        self.mainPage = NotepadUI(userInput, self.FileArgs)
        self.mainPage.show()
        self.close()

    def showInitKeyDialog(self):
        kt = keytool()
        warningText = "設定加密金鑰，注意! 這是用來加密文件用的金鑰，請妥善保管並千萬要記得，否則將無法解密以加密的文件"
        dlg = QMessageBox(self)
        dlg.setText(warningText)
        dlg.setIcon(QMessageBox.Warning)
        dlg.exec_()

        key = self.__showDialog("set key", "請輸入金鑰")
        keyAgain = self.__showDialog("set key", "請再次輸入金鑰")

        if(key != keyAgain):
            self.__dialog_message("金鑰輸入不一致，新增失敗", icon=QMessageBox.Critical)
            return False
        
        #Write new key
        kt.c["program"]["secretKey"] = kt.EncryptKey(key, "0000") #default user password = 0000
        kt.update()
        return True

    def __dialog_message(self, message, icon=QMessageBox.Critical):
        dlg = QMessageBox(self)
        dlg.setText(message)
        dlg.setIcon(QMessageBox.Critical)
        dlg.show()

    def __showDialog(self, title, dialogText):
        text, ok = QInputDialog.getText(self, title, dialogText)
        if ok:
            return str(text)

if __name__ == "__main__":
    app = QApplication(sys.argv)
    notepad = AuthPageUI()
    notepad.show()
    sys.exit(app.exec_())