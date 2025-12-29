# VirusAntivirus — Simple Antivirus Scanner (C# Console App)

**VirusAntivirus** is a simple **C# console-based antivirus application** that scans files in a selected directory and detects known viruses using **MD5 hash signatures**.
The project is designed for **educational purposes** to demonstrate how basic antivirus logic works.

---

## Features

* 🛡️ Folder scanning (recursive)
* 🔍 Virus detection using **MD5 hash signatures**
* 📄 Clean / Infected file reporting
* 🚨 Colored console alerts for detected threats
* 🧪 Supports **EICAR test virus** for safe testing
* 📊 Scan summary (total files & infected files)

---

## Technologies Used

* **C#**
* **.NET Console Application**
* **System.IO** (file & directory scanning)
* **System.Security.Cryptography** (MD5 hashing)

---

## How It Works

1. The user selects a directory to scan.
2. Each file is read and converted into an **MD5 hash**.
3. The hash is compared against a predefined **virus signature database**.
4. If a match is found, the file is reported as **infected**.
5. If no match is found, the file is marked as **clean**.

> ⚠️ This project uses **signature-based detection only** (no real-time protection).

---

## Virus Detection Method

* Signature-based detection
* Hash algorithm: **MD5**
* Virus signatures are stored in a dictionary inside the code.

Example signature:

```
EICAR-Test-File (Standard)
MD5: 44d88612fea8a8f36de82e1278abbb03
```

---

## Project Structure

```
VirusAntivirus/
│
├── Program.cs
├── VirusAntivirus.csproj
│
├── eicar.txt      // Test virus file (safe)
├── clean.txt      // Clean test file
└── bin / obj
```

### File Descriptions

* **Program.cs**
  Contains the main antivirus logic, directory scanning, and MD5 hash comparison.

* **eicar.txt**
  Standard antivirus test file used to safely simulate virus detection.

* **clean.txt**
  A clean file used to verify false-positive behavior.

---

## How to Run

1. Open the project in **Visual Studio**.
2. Build the project.
3. Run the application.
4. Choose:

   ```
   1 - Scan Folder
   2 - Exit
   ```
5. Enter the folder path you want to scan.
6. View scan results directly in the console.

---

## Sample Output

```
[TEHLİKE] Virus Detected: eicar.txt -> EICAR-Test-File (Standard)
[TEMİZ] clean.txt

Scan Completed
Total Files: 2
Detected Viruses: 1
```

---

## Limitations

* Uses **hardcoded virus signatures**
* No real-time protection
* No heuristic or behavioral analysis
* MD5 is used for learning purposes (not secure for real antivirus systems)

---

## Educational Purpose

This project is intended for:

* University assignments
* Learning basic antivirus logic
* Understanding file hashing
* Practicing directory traversal in C#

❗ **Not intended for real-world security use**

---

## Future Improvements

* Use SHA-256 instead of MD5
* Load virus signatures from external database/file
* Quarantine infected files
* GUI version (WPF / WinForms)
* Real-time monitoring
* Logging scan results to a file

---

## Author

**Abdullah Ali**
Software Engineering Student

قل لي مباشرة وسأجهزه لك 👌
