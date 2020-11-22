from authPage import AuthPageUI
from keytools import keytool
from PyQt5.QtWidgets import QApplication, QMainWindow, QMessageBox
import sys

if __name__ == "__main__":
    app = QApplication(sys.argv)

    #處理參數傳遞檔案路徑
    if(len(sys.argv) > 1):
        notepad = AuthPageUI(sys.argv[1])
    else:
        notepad = AuthPageUI("")
    
    notepad.show()
    sys.exit(app.exec_())