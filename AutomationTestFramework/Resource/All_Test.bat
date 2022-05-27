@ECHO OFF
ECHO Auomation Execution Started.

set summaryPath=C:\Users\khurram.muslim\Source\Repos\AutomationTestFramework\AutomationTestFramework\TestSummaryReport

call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"

VSTest.Console.exe C:\Users\khurram.muslim\Source\Repos\AutomationTestFramework\AutomationTestFramework\bin\Debug\AutomationTestFramework.dll /Logger:"trx;LogFileName=C:\Users\khurram.muslim\Source\Repos\AutomationTestFramework\AutomationTestFramework\TestSummaryReport\TestSummaryReport.trx

cd C:\Users\khurram.muslim\Source\Repos\AutomationTestFramework\AutomationTestFramework\bin\Debug\

TrxToHTML.exe %summaryPath%

PAUSE