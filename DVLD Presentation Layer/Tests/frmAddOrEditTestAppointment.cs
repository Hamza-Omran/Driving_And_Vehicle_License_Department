using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Applications.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Take_Appointment
{
    public partial class frmAddOrEditTestAppointment : Form
    {
        // Declare a delegate
        public delegate void RefreshDGVEventHandler();

        // Declare an event using the delegate
        public event RefreshDGVEventHandler Refresh;

        private int _LocalAppID = -1, _AppointmentID = -1;

        public frmAddOrEditTestAppointment(int LocalAppID, int TestTypeID)
        {
            InitializeComponent();

            ctrlSheduleTest1.Refresh += RefreshData;

            _LocalAppID = LocalAppID;
            ctrlSheduleTest1.TestTypeID = (clsTestTypes.enTestType)TestTypeID;
        }

        public frmAddOrEditTestAppointment(int LocalAppID, int TestTypeID, int AppointmentID)
        {
            InitializeComponent();

            ctrlSheduleTest1.Refresh += RefreshData;

            _LocalAppID = LocalAppID;
            _AppointmentID = AppointmentID;
            ctrlSheduleTest1.TestTypeID = (clsTestTypes.enTestType)TestTypeID;
        }

        private void frmAddOrEditTestAppointment_Load(object sender, EventArgs e)
        {
            ctrlSheduleTest1.LoadInfo(_LocalAppID, _AppointmentID);

            if (ctrlSheduleTest1.LocalAppInfo == null)
            {
                MessageBox.Show("No Application Found ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        private void RefreshData()
        {
            Refresh?.Invoke();
        }

        private void frmAddOrEditTestAppointment_Activated(object sender, EventArgs e)
        {
            ctrlSheduleTest1.DTPFocus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
