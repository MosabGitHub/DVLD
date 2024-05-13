using DVLD.Application;
using DVLD;
using DVLD.test;
using DVLD.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Application.localDrivingApplication;
using DVLD.General;
using DVLD.NewFolder1;
using DVLD.Drivers;
using DVLD.Licenses;
using DVLD.Application.DetainAndReleaseApplication.DetainApplications;
using DVLD.Application.DetainAndReleaseApplication.ReleaseApplication;

namespace DVLD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            // Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new login());
        }
    }
}
