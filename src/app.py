from uicontrol import NotepadUI
from PyQt5.QtWidgets import QApplication, QMainWindow
import sys

if __name__ == "__main__":
    app = QApplication(sys.argv)
    notepad = NotepadUI()
    notepad.show()
    sys.exit(app.exec_())