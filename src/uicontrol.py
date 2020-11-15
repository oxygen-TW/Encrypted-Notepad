import sys, os
from PyQt5.QtWidgets import QApplication, QMainWindow, QWidget
from PyQt5.QtWidgets import QPushButton, QLabel, QPlainTextEdit, QStatusBar, QToolBar
from PyQt5.QtWidgets import QVBoxLayout, QAction, QFileDialog, QMessageBox

from PyQt5.QtCore import Qt, QSize
from PyQt5.QtGui import QFontDatabase, QIcon, QKeySequence
from PyQt5.QtPrintSupport import QPrintDialog

class NotepadUI(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Encrypted Notepad")
        self.screen_width = self.geometry().width()
        self.screen_height = self.geometry().height()
        self.resize(self.screen_width, self.screen_height)

        fixedFont = QFontDatabase.systemFont(QFontDatabase.FixedFont)
        fixedFont.setPointSize(12)

        self.filterTypes = "Plain Text (*.txt);; Encrypted Text File (*.ent);; All Files (*.*)"
        self.path = None

        #Create Layout
        mainLayout = QVBoxLayout()

        container = QWidget()
        container.setLayout(mainLayout)
        self.setCentralWidget(container)
        
        #Create TextEditor
        self.mainEditor = QPlainTextEdit()
        self.mainEditor.setFont(fixedFont)
        mainLayout.addWidget(self.mainEditor)

        #Create File Menu
        file_menu = self.menuBar().addMenu("&File")

        #Actions
        openFileAction = QAction("Open File", self)
        openFileAction.setStatusTip("Open file")
        openFileAction.setShortcut(QKeySequence.Open)
        openFileAction.triggered.connect(lambda : print("open file"))

        saveFileAction = self.__createAction(self, "Save File", "save file", lambda : print("Save"))
        saveFileAction.setShortcut(QKeySequence.Save)
        file_menu.addActions([openFileAction, saveFileAction])

    def OpenFile(self):
        path, _ = QFileDialog.getOpenFileName(
            parent = self,
            caption = "Open File",
            dictionary = "",
            filter = self.filterTypes
        )
    def __createAction(self, parent, actionName ,set_status_tip, triggered_method):
        action = QAction(actionName, parent)
        action.setStatusTip(set_status_tip)
        action.triggered.connect(triggered_method)
        return action
