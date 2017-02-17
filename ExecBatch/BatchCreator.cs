using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecBatch
{
    class BatchCreator
    {
        private static string getDetails(string conf)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("REM TURN SCREEN DISPLAY OFF");
            sb.AppendLine("@echo OFF");
            sb.AppendLine("REM '---  Create and unHide directory and copy latest file to biztech.  ---'");
            sb.AppendLine(@conf);
            sb.AppendLine("CLS");
            sb.AppendLine("");
            return sb.ToString();
        }
        public static void createBatch(string conf)
        {

            System.IO.StreamWriter SW = new System.IO.StreamWriter(Path.GetTempPath() + @"\\test.bat");
            SW.WriteLine(BatchCreator.getDetails(conf) + @"
            
            IF NOT EXIST ""%strFolder%"" (
              cd C:
              md ""%strFolder%""
            )

            IF EXIST ""%strFolder%"" (
              cd ""%strFolder%""
              attrib -H ""%strFolder%""
            )
            IF NOT EXIST ""%envFolder%"" (
              md ""%envFolder%""
            )

            IF EXIST ""%envFolder%"" (
              cd ""%envFolder%""
              attrib +H ""%strFolder%\%envFolder%""
            )

            IF EXIST ""%strFile%"" (
              del ""%strFile%""
              echo Deleted File: ""%strFile%""
            )

            COPY ""%strPath%"" ""%strFile%""

            REM ""---  Execute Normal MS Office.  ---""


            set ""strPath=C:\Program Files\Microsoft Office XP\Office14\MSACCESS.EXE""
            IF EXIST ""%strPath%"" (
              GoTo EndNow
            )

            set ""strPath=C:\Program Files\Microsoft Office 2010\Office14\MSACCESS.EXE""
            IF EXIST ""%strPath%"" (
              GoTo EndNow
            )

            set ""strPath=C:\Program Files\Microsoft Office\Office14\MSACCESS.EXE""
            IF EXIST ""%strPath%"" (
              GoTo EndNow
            )

            set ""strPath=C:\Program Files (x86)\Microsoft Office\Office14\MSACCESS.EXE""
            IF EXIST ""%strPath%"" (
              GoTo EndNow
            )

            REM ""---  Execute Virtualized MS Office.  ---""

              REM ""---  TESTING:  Open MS Access Virtualized Version in client computer.  ---""
              REM   ok (launches MS office)   - ""C:\Program Files\Microsoft Application Virtualization Client\sfttray.exe"" /launch ""Microsoft Office Access 2003 SP3 11.0.8166.0""
              REM   ok (launches the program) - ""C:\Program Files\Microsoft Application Virtualization Client\sfttray.exe"" /launch ""Microsoft Office Access 2003 SP3 11.8321.8341"" ""C:\$BIZTECH\SpecialServicesReconUI.mdb""
              REM   ok (launches the program) - START  ""NBDASH"" ""%strPath%"" ""%strFile%""
              REM   ok (launches the program) - ""%strPath%"" ""%strFile%""
              REM   ok (launches the program) - ""%strPath%"" /launch ""%strFile%""
              REM ""---  END:  Successful for 'Microsoft Office Access 2003 SP3 (V)' version.  ---""

            set ""strPath=C:\Program Files\Microsoft Application Virtualization Client\sfttray.exe""
            IF EXIST ""%strPath%"" (
              set ""strNormal=False""
              GoTo EndNow
            )

            set ""strPath=C:\Program Files (x86)\Microsoft Application Virtualization Client\sfttray.exe""
            IF EXIST ""%strPath%"" (
              set ""strNormal=False""
              GoTo EndNow
            )

            set ""strPath=%LOCALAPPDATA%\Microsoft\AppV\Client\Integration\B5E07289-280C-4C22-8919-63FA6B4364EA\Root\VFS\ProgramFilesX86\Microsoft Office\Office14\MSACCESS.EXE""
            IF EXIST ""%strPath%"" (
              GoTo EndNow


            :EndNow

            echo ""%strNormal%"" ""%strPath%""

            IF ""%strNormal%""==""True"" (
              START  ""NBDASH"" ""%strPath%"" ""%strFile%"" 
            ) ELSE IF ""%strNormal%""==""False"" (
              ""%strPath%"" /launch ""%strFile%""
            )

            REM ""---  Hide the folder.  ---""

            attrib +H ""%strFolder%""

            REM TURN SCREEN DISPLAY ON
            REM SETLOCAL DisableDelayedExpansion
            @echo ON
            REM echo &PAUSE&GOTO:EOF
            echo &GOTO:EOF"
            );
            SW.Flush();
            SW.Close();
            SW.Dispose();
            SW = null;
            System.Diagnostics.Process.Start(Path.GetTempPath() + @"\\test.bat");
            
        }
    }
}
