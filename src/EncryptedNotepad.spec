# -*- mode: python ; coding: utf-8 -*-

block_cipher = None


a = Analysis(['EncryptedNotepad.py'],
             pathex=['D:\\Programming\\Projects\\Encrypted-Notepad\\src'],
             binaries=[],
             datas=[],
             hiddenimports=['pyqt5', 'pycryptodome'],
             hookspath=[],
             runtime_hooks=[],
             excludes=[],
             win_no_prefer_redirects=False,
             win_private_assemblies=False,
             cipher=block_cipher,
             noarchive=False)
pyz = PYZ(a.pure, a.zipped_data,
             cipher=block_cipher)
exe = EXE(pyz,
          a.scripts,
          a.binaries,
          a.zipfiles,
          a.datas,
          [],
          name='EncryptedNotepad',
          debug=False,
          bootloader_ignore_signals=False,
          strip=False,
          upx=True,
          upx_exclude=[],
          runtime_tmpdir=None,
          console=False , icon='assests\\icon.ico')
