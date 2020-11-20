from authPage import AuthPageUI
from keytools import keytool
from PyQt5.QtWidgets import QApplication, QMainWindow, QMessageBox
import sys

if __name__ == "__main__":
    app = QApplication(sys.argv)
    notepad = AuthPageUI()
    notepad.show()
    sys.exit(app.exec_())