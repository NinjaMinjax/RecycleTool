# RecycleTool

A simple Windows command-line tool to send files to the **Recycle Bin**.  
For **local drives**, files are moved to the Windows Recycle Bin.  
For **network drives** (NAS, QNAP, \\UNC paths), files are deleted permanently.

---

## 🔧 Build

Make sure you have [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download) installed.

```bash
git clone https://github.com/NinjaMinjax/RecycleTool.git
cd RecycleTool
dotnet publish -c Release -r win-x64 --self-contained true

```  
The compiled executable will be in:
```
RecycleTool/bin/Release/net6.0/win-x64/publish/RecycleTool.exe
```

## 🚀 Usage

```
RecycleTool.exe "C:\path\to\file.txt"
RecycleTool.exe "Q:\network\share\file.docx"
```
* Local files → moved to Recycle Bin
* Network files (NAS/QNAP) → permanently deleted

## 📌 Notes

Network drives (QNAP, Synology, etc.) do not support Windows Recycle Bin.
This tool deletes them immediately.

If you want a "fake recycle bin" for network shares, you can fork this project and adjust the logic to move files into a custom folder.
