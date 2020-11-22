pipenv install --skip-lock
IF "%1"=="dev" GOTO dev

:Release
echo Build command [Release]
pyinstaller -F -w EncryptedNotepad.py --hidden-import=pyqt5 --hidden-import=pycryptodome --icon=assests\icon.ico
GOTO End

:Dev
echo Build command [Dev]
pyinstaller -F EncryptedNotepad.py --hidden-import=pyqt5 --hidden-import=pycryptodome --icon=assests\icon.ico
GOTO End

:End
copy config.json dist
copy assests/icon.ico dist