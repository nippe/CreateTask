Copy-Item .\CreateTask.Console\bin\Debug\* -Destination C:\Utils\CreateTask\ -Include "*.exe" -Exclude "*vshost*" -Force
Copy-Item .\CreateTask.Console\bin\Debug\* -Destination C:\Utils\CreateTask\ -Include "*.dll"  -Force
Copy-Item .\CreateTask.Console\bin\Debug\* -Destination C:\Utils\CreateTask\ -Include "*.xml"

