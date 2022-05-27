@ECHO OFF
ECHO Demo Automation Executed Started

call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"

VSTest.Console.exe C:\Users\khurram.muslim\Source\Repos\AutomationTestFramework\AutomationTestFramework\bin\Debug\AutomationTestFramework.dll

PAUSE