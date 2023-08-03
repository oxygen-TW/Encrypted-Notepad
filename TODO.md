- [X] 主工作UI不能鎖定回到 AuthPage
- [X] Add UI icon
- [] Auto-save function
- [] Main UI drag and drop event
- [] NSIS File Association
- [] Batch Process can not preserve origin file structure 


23/8/3
目前MacOS上路徑的解決辦法為開啟時檢查appdirs有無config，若有就不複製新的過去，若沒有再複製，但這樣多出來的問題是即使程式被刪除該Config依然存在。

在想可以透過第一次啟動時Random一個亂數作為檔名辨識，但我該怎麼知道這程式是不是第一次運行呢？
目前用手動移除或用tools.oxxRemove.py暫時解決這問題，之後再想該怎麼辦。

＊＊沒有在Windows上測試過＊＊
可能可以判斷若為win就用原本的做法即可