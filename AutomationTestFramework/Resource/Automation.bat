@ECHO OFF
ECHO Auomation Execution Started.

set testcategory=Login
set dllpath=C:\Users\khurram.muslim\Source\Repos\AutomationTestFramework\AutomationTestFramework\bin\Debug\AutomationTestFramework.dll
set trxerpath=C:\Users\khurram.muslim\Source\Repos\AutomationTestFramework\AutomationTestFramework\bin\Debug\
set testsummaryreportPath=C:\Users\khurram.muslim\Source\Repos\AutomationTestFramework\AutomationTestFramework\TestSummaryReport\

FOR /f %%a IN ('WMIC OS GET LocalDateTime ^| FIND "."') DO SET DTS=%%a
SET filename=%testcategory%_%DTS:~0,4%%DTS:~4,2%%DTS:~6,2%%DTS:~8,2%%DTS:~10,2%%DTS:~12,2%
echo %filename%

call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"
cd %testsummaryreportPath%
md %filename%

VSTest.Console.exe  %dllpath% /TestCaseFilter:"TestCategory=%testcategory%" /Logger:"trx;LogFileName=%testsummaryreportPath%\%filename%\%filename%.trx"

cd %trxerpath%
TrxToHTML.exe %testsummaryreportPath%%filename%\

PAUSE