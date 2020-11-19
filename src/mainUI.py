import sys, os
from PyQt5.QtWidgets import QApplication, QMainWindow, QWidget
from PyQt5.QtWidgets import QPushButton, QLabel, QPlainTextEdit, QStatusBar, QToolBar
from PyQt5.QtWidgets import QVBoxLayout, QAction, QFileDialog, QMessageBox

from PyQt5.QtCore import Qt, QSize
from PyQt5.QtGui import QFontDatabase, QIcon, QKeySequence
from PyQt5.QtPrintSupport import QPrintDialog

from FileIO import *
from ConfigProcessor import Config
from keytools import keytool

#Ref: https://learndataanalysis.org/build-a-notepad-application-from-scratch-using-python-and-pyqt5/
class NotepadUI(QMainWindow):
    def __init__(self, key):
        super().__init__()
        self.userKey = key

        self.setWindowTitle("Encrypted Notepad")
        self.setWindowIcon(QIcon('assests/icon.png'))
        self.screen_width = self.geometry().width()
        self.screen_height = self.geometry().height()
        self.resize(self.screen_width, self.screen_height)

        fixedFont = QFontDatabase.systemFont(QFontDatabase.FixedFont)
        fixedFont.setPointSize(12)

        self.filterTypes = "Plain Text (*.txt);; Encrypted Text File (*.ent);; All Files (*.*)"
        self.path = None

        #檔案處理器
        self.efio = EncryptedFlieIO()
        self.fio = BasicFileIO()

        #Config處理器
        self.c = Config()

        #金鑰管理器
        self.kt = keytool()

        #Create Layout
        mainLayout = QVBoxLayout()

        container = QWidget()
        container.setLayout(mainLayout)
        self.setCentralWidget(container)
        
        #Create TextEditor
        self.mainEditor = QPlainTextEdit()
        self.mainEditor.setFont(fixedFont)
        mainLayout.addWidget(self.mainEditor)

        # stautsBar
        self.statusBar = self.statusBar()

        #Create File Menu
        file_menu = self.menuBar().addMenu("&File")

        #Actions
        openFileAction = QAction("Open File", self)
        openFileAction.setStatusTip("Open file")
        openFileAction.setShortcut(QKeySequence.Open)
        openFileAction.triggered.connect(self.OpenFile)

        newFileAction = self.__createAction(self, "New File", "new file", self.NewFile)
        newFileAction.setShortcut(QKeySequence("Ctrl+N"))

        saveFileAction = self.__createAction(self, "Save File", "save file", self.SaveFile)
        saveFileAction.setShortcut(QKeySequence.Save)

        saveFileAsAction = self.__createAction(self, "Save File As", "save file As", self.SaveAsFile)
        saveFileAsAction.setShortcut(QKeySequence("Ctrl+Shift+S"))

        #Add Action to Menu
        file_menu.addActions([newFileAction, openFileAction, saveFileAction, saveFileAsAction])

        file_menu.addSeparator()

        DecryptOpenFileAction = self.__createAction(self, "Decrypt File", "Decrypt file", self.DecryptOpen)
        EncryptSaveFileAction = self.__createAction(self, "Encrypt File", "Encrypt file", self.EncryptSave)
        EncryptSaveAsFileAction = self.__createAction(self, "Encrypt File As", "Encrypt file as", self.EncryptSaveAs)

        DecryptOpenFileAction.setShortcut(QKeySequence("Ctrl+D"))
        EncryptSaveFileAction.setShortcut(QKeySequence("Ctrl+E"))

        file_menu.addActions([DecryptOpenFileAction, EncryptSaveFileAction, EncryptSaveAsFileAction])

        # add separator
        file_menu.addSeparator()

        print_action = self.__createAction(self, 'Print File', 'Print file', self.print_file)
        print_action.setShortcut(QKeySequence.Print)
        
        file_menu.addAction(print_action)


        edit_menu = self.menuBar().addMenu('&Edit')

        # Undo, Redo Actions
        undo_action = self.__createAction(self, 'Undo', 'Undo', self.mainEditor.undo)
        undo_action.setShortcut(QKeySequence.Undo)
 
        redo_action = self.__createAction(self, 'Redo', 'Redo', self.mainEditor.redo)
        redo_action.setShortcut(QKeySequence.Redo)


        edit_menu.addActions([undo_action, redo_action])

        # Clear action
        clear_action = self.__createAction(self, 'Clear', 'Clear', self.clear_content)
        edit_menu.addAction(clear_action)

        # add separator
        edit_menu.addSeparator()

        # cut, copy, paste, select all
        cut_action = self.__createAction(self, 'Cut', 'Cut', self.mainEditor.cut)
        copy_action = self.__createAction(self, 'Copy', 'Copy', self.mainEditor.copy)
        paste_action = self.__createAction(self, 'Paste', 'Paste', self.mainEditor.paste)
        select_all_action = self.__createAction(self, 'Select All', 'Select all', self.mainEditor.selectAll)
 
        cut_action.setShortcut(QKeySequence.Cut)
        copy_action.setShortcut(QKeySequence.Copy)
        paste_action.setShortcut(QKeySequence.Paste)
        select_all_action.setShortcut(QKeySequence.SelectAll)
 
        edit_menu.addActions([cut_action, copy_action, paste_action, select_all_action])

        other_menu = self.menuBar().addMenu('&Other')

        lock_action = self.__createAction(self, 'Lock', 'Lock', self.lock())
        lock_action.setShortcut(QKeySequence("Ctrl+L"))

        other_menu.addActions([lock_action])

    def NewFile(self):
        pass

    def OpenFile(self):
        path, _ = QFileDialog.getOpenFileName(
            parent = self,
            caption = "Open File",
            directory = self.c.config["program"]["lastDir"],
            filter = self.filterTypes
        )
        text = ""
        if path:
            try:    
                text = self.fio.open(path)
            except Exception as e:
                self.dialog_message(str(e))
            else:
                self.path = path
                self.mainEditor.setPlainText(text)
                self.update_title()
                self.c.config["program"]["lastDir"] = os.path.dirname(self.path)
                self.c.update()

    def SaveFile(self):
        if self.path is None:
            self.SaveAsFile()
            pass
        else:
            try:
                text = self.mainEditor.toPlainText()
                self.fio.save(text, self.path)
            except Exception as e:  
                self.dialog_message(str(e))

    def SaveAsFile(self):
        path, _ = QFileDialog.getSaveFileName(
            self,
            'Save file as',
            self.c.config["program"]["lastDir"],
            self.filterTypes
        )                               
 
        text = self.mainEditor.toPlainText()

        if not path:
            return
        else:
            try:
                self.fio.save(text, path)
            except Exception as e:
                print(str(e))
                self.dialog_message(str(e))
            else:
                self.path = path
                self.update_title()
                self.c.config["program"]["lastDir"] = os.path.dirname(self.path)
                self.c.update()

    def __createAction(self, parent, actionName ,set_status_tip, triggered_method):
        action = QAction(actionName, parent)
        action.setStatusTip(set_status_tip)
        action.triggered.connect(triggered_method)
        return action

    def dialog_message(self, message):
        dlg = QMessageBox(self)
        dlg.setText(message)
        dlg.setIcon(QMessageBox.Critical)
        dlg.show()

    def update_title(self):
        self.setWindowTitle('{0} - EncryptedNotepad'.format(os.path.basename(self.path) if self.path else 'Untitled'))
 
    def print_file(self):
        printDialog = QPrintDialog()
        if printDialog.exec_():
            self.mainEditor.print_(printDialog.printer())

    def toggle_wrap_text(self):
        self.editor.setLineWrapMode(not self.mainEditor.lineWrapMode())
 
    def clear_content(self):
        self.mainEditor.setPlainText('')
 
    def EncryptSave(self):
        if self.path is None:
            self.EncryptSaveAs()
            pass
        else:
            try:
                text = self.mainEditor.toPlainText()
                self.efio.save(text, self.path, self.userKey)
            except Exception as e:  
                self.dialog_message(str(e))

    def EncryptSaveAs(self):
        path, _ = QFileDialog.getSaveFileName(
            self,
            'Save file as',
            self.c.config["program"]["lastDir"],
            "Encrypted Text File (*.ent);; All Files (*.*)"
        )                               
 
        text = self.mainEditor.toPlainText()

        if not path:
            return
        else:
            try:
                self.efio.save(text, path, self.userKey)
            except Exception as e:
                print(str(e))
                self.dialog_message(str(e))
            else:
                self.path = path
                self.update_title()
                self.c.config["program"]["lastDir"] = os.path.dirname(self.path)
                self.c.update()

    def DecryptOpen(self):
        path, _ = QFileDialog.getOpenFileName(
            parent = self,
            caption = "Open File",
            directory = self.c.config["program"]["lastDir"],
            filter = "Encrypted Text File (*.ent);; All Files (*.*)"
        )
        text = ""
        if path:
            try:    
                text = self.efio.open(path, self.userKey)
            except Exception as e:
                self.dialog_message(str(e))
            else:
                self.path = path
                self.mainEditor.setPlainText(text)
                self.update_title()
                self.c.config["program"]["lastDir"] = os.path.dirname(self.path)
                self.c.update()

    def lock(self):
        self.userKey = "" #delete key
        self.authWin = self.AuthPageUI()
        self.close()

 

