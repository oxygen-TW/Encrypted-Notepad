import sys, os
from PyQt5.QtWidgets import QApplication, QMainWindow, QWidget
from PyQt5.QtWidgets import QPushButton, QLabel, QPlainTextEdit, QStatusBar, QToolBar
from PyQt5.QtWidgets import QLineEdit, QHBoxLayout

from PyQt5.QtCore import Qt, QSize
from PyQt5.QtGui import QFontDatabase, QIcon, QKeySequence
from PyQt5.QtPrintSupport import QPrintDialog

from mainUI import NotepadUI
from authPageUI import Ui_AuthPageUI

from EncryptedCore import convertPasspharse
from keytools import keytool

class AuthPageUI(QMainWindow, Ui_AuthPageUI):
    def __init__(self):
        super(AuthPageUI, self).__init__()

        self.setupUi(self)
        self.AuthButton.clicked.connect(self.Authentication)
        self.AuthButton.setShortcut(QKeySequence("Return"))
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
        print("reset")

    def switchToMainPage(self, userInput):
        self.mainPage = NotepadUI(userInput)
        self.mainPage.show()
        self.close()

if __name__ == "__main__":
    app = QApplication(sys.argv)
    notepad = AuthPageUI()
    notepad.show()
    sys.exit(app.exec_())