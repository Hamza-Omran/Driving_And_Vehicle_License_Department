using DVLD_Presentation_Layer.Applications.International_Driving_License;
using DVLD_Presentation_Layer.Applications.Local_Driving_License;
using DVLD_Presentation_Layer.Applications.Take_Appointment;
using DVLD_Presentation_Layer.Take_Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new frmLogin());

        }
    }
}
