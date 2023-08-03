import appdirs
import shutil

appWritableDir = appdirs.user_data_dir(appname='EncryptedNotepad', appauthor='oxygenStudio')
shutil.rmtree(appdirs)
