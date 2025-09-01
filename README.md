# RecycleTool

A simple Windows command-line tool to send files to the **Recycle Bin**.  
For **local drives**, files are moved to the Windows Recycle Bin.  
For **network drives** (NAS, QNAP, \\UNC paths), files are deleted permanently.

---

## 🔧 Build

Make sure you have [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download) installed.

```bash
git clone https://github.com/YOUR-USERNAME/RecycleTool.git
cd RecycleTool
dotnet publish -c Release -r win-x64 --self-contained true
