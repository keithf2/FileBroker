# FileBroker
Example of using FileSystemWatcher in a Windows Service

Installation instructions:

This assumes you have .NET framework installed.

From the project, copy contents of bin\Debug to C:\FileBrokerService\ folder.

Go to a DOS prompt (open as administrator):

C:\ cd C:\Windows\Microsoft.NET\Framework\v4.0.30319

C:\Windows\Microsoft.NET\Framework\v4.0.30319>Installutil C:\FileBrokerService\FileBroker.exe
Microsoft (R) .NET Framework Installation utility Version 4.7.2558.0
Copyright (C) Microsoft Corporation.  All rights reserved.


Running a transacted installation.

Beginning the Install phase of the installation.
See the contents of the log file for the C:\FileBrokerService\FileBroker.exe assembly's progress.
The file is located at C:\FileBrokerService\FileBroker.InstallLog.
Installing assembly 'C:\FileBrokerService\FileBroker.exe'.
Affected parameters are:
   logtoconsole =
   logfile = C:\FileBrokerService\FileBroker.InstallLog
   assemblypath = C:\FileBrokerService\FileBroker.exe
Installing service Basic FileSystem Watcher...
Service Basic FileSystem Watcher has been successfully installed.
Creating EventLog source Basic FileSystem Watcher in log Application...

The Install phase completed successfully, and the Commit phase is beginning.
See the contents of the log file for the C:\FileBrokerService\FileBroker.exe assembly's progress.
The file is located at C:\FileBrokerService\FileBroker.InstallLog.
Committing assembly 'C:\FileBrokerService\FileBroker.exe'.
Affected parameters are:
   logtoconsole =
   logfile = C:\FileBrokerService\FileBroker.InstallLog
   assemblypath = C:\FileBrokerService\FileBroker.exe

The Commit phase completed successfully.

The transacted install has completed.

C:\Windows\Microsoft.NET\Framework\v4.0.30319>
