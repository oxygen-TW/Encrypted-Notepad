from FileIO import *

mode = input("Read(0)/Save(1): ")
if(mode != "0" and mode != "1"):
    exit(1)

key = input("Input key-> ")
path = input("file name->")
eFio = EncryptedFlieIO()

if(mode == "1"):
    text = input("Input text->")
    eFio.save(text, path, key)
elif(mode == "0"):
    print(eFio.open(path, key))
