import sys, os
from PyQt5.QtWidgets import QApplication, QMainWindow, QInputDialog, QMessageBox, QAction
from PyQt5.QtGui import  QKeySequence


from mainUI import NotepadUI
from authPageUI import Ui_AuthPageUI

from EncryptedCore import convertPasspharse
from keytools import keytool

class AuthPageUI(QMainWindow, Ui_AuthPageUI):
    def __init__(self):
        super(AuthPageUI, self).__init__()

        self.setupUi(self)
        self.AuthButton.clicked.connect(self.Authentication)

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
        if(kt.ReadKey() != convertPasspharse(userInput)):
            self.PasswordEdit.setText("")
            print("Failed")
            return False

        print("ok")
        self.switchToMainPage(userInput)

    def resetPassword(self):
        userpasswd = self.__showDialog("Reset password", "Input password")
        kt = keytool()
        if(kt.ReadKey() != convertPasspharse(userpasswd)):
            self.__dialog_message("Failed to Auth")
            return False
        
        newPasswd = self.__showDialog("Reset password", "Input new password")
        newPasswd_again = self.__showDialog("Reset password", "Input new password again")

        if(newPasswd != newPasswd_again):
            self.__dialog_message("New password does not match")
            return False

        newPasswd = convertPasspharse(newPasswd)
        kt.WriteKey(newPasswd)
        dlg = QMessageBox(self)
        dlg.setText("Reset password success!")
        dlg.setIcon(QMessageBox.Information)
        dlg.show()
        return True

    def switchToMainPage(self, userInput):
        self.mainPage = NotepadUI(userInput)
        self.mainPage.show()
        self.close()

    def __dialog_message(self, message):
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