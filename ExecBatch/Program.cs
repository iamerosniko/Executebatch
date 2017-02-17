using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ExecBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //do not remove @ sign
                if (File.Exists("batch.conf"))
                {
                    string conf = File.ReadAllText("batch.conf");
                    BatchCreator.createBatch(conf);
                }
                else
                {
                    MessageBox.Show("batch.conf not found. \nPlease Modify it after generating default Batch.conf");
                    StreamWriter tw = new StreamWriter(@"batch.conf");

                    tw.WriteLine(@":: FAST DEPLOYMENT SOLUTIONS BY EROS NIKO ALVAREZ");
                    tw.WriteLine(@":: CREATED ON 01/10/2017 ");
                    tw.WriteLine(@":: CHANGE <envFolder> to DEv or MOD or OPS.");
                    tw.WriteLine(@":: BY DEFAULT IT WILL GO TO DEV ENVIRONMENT IF YOU DECLARE <envFolder> INCORRECTLY.");
                    tw.WriteLine(@":: ");
                    tw.WriteLine(@":: WARNING : USE THIS BATCH FILE IF YOU IMPLEMENT FASTDEPLOY MODULE");
                    tw.WriteLine(@"::");
                    tw.WriteLine(@":: DEV -- DEVELOPER'S ENVIRONMENT ");
                    tw.WriteLine(@":: MOD -- UAT ENVIRONMENT");
                    tw.WriteLine(@":: OPS -- PRODUCTION");
                    tw.WriteLine(@"set ""envFolder=MOD""");
                    tw.WriteLine(@"set ""strPath=C:\Users\alverer\Documents\Proto-DynamicDeployment\Proto-DynamicDeployment.accdb""");
                    tw.WriteLine(@"set ""strNormal=True""");
                    tw.WriteLine(@"set ""strFolder=C:\$BIZTECH""");
                    tw.WriteLine(@"set ""strFile=%strFolder%\%EnvFolder%\Proto-DynamicDeployment.accdb""");
                    tw.Close();
                }
            }
            catch
            {
                MessageBox.Show("batch.conf not found. \nPlease Modify it after generating default Batch.conf");
                StreamWriter tw = new StreamWriter(@"batch.conf");
                
                tw.WriteLine(@":: FAST DEPLOYMENT SOLUTIONS BY EROS NIKO ALVAREZ");
                tw.WriteLine(@":: CREATED ON 01/10/2017 ");
                tw.WriteLine(@":: CHANGE <envFolder> to DEv or MOD or OPS.");
                tw.WriteLine(@":: BY DEFAULT IT WILL GO TO DEV ENVIRONMENT IF YOU DECLARE <envFolder> INCORRECTLY.");
                tw.WriteLine(@":: ");
                tw.WriteLine(@":: WARNING : USE THIS BATCH FILE IF YOU IMPLEMENT FASTDEPLOY MODULE");
                tw.WriteLine(@"::");
                tw.WriteLine(@":: DEV -- DEVELOPER'S ENVIRONMENT ");
                tw.WriteLine(@":: MOD -- UAT ENVIRONMENT");
                tw.WriteLine(@":: OPS -- PRODUCTION");
                tw.WriteLine(@"set ""envFolder=MOD""");
                tw.WriteLine(@"set ""strPath=C:\Users\alverer\Documents\Proto-DynamicDeployment\Proto-DynamicDeployment.accdb""");
                tw.WriteLine(@"set ""strNormal=True""");
                tw.WriteLine(@"set ""strFolder=C:\$BIZTECH""");
                tw.WriteLine(@"set ""strFile=%strFolder%\%EnvFolder%\Proto-DynamicDeployment.accdb""");
                tw.Close();

            }
        }
    }
}
