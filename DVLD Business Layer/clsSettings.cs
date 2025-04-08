using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsSettings
    {
        public enum enSettings { NewInternationalLicense = 2};
        public int ID { get; set; }
        public string Service { get; set; }
        public int ValidityLength { get; set; }

        private clsSettings(int ID, string Service, int ValidityLength)
        {
            this.ID = ID;
            this.Service = Service;
            this.ValidityLength = ValidityLength;
        }

        public static clsSettings Find(int ID)
        {
            string Service = "";
            int ValidityLength = 0;

            if (clsSettingsData.GetSettingByID(ID, ref Service, ref ValidityLength))
                return new clsSettings(ID, Service, ValidityLength);
            else
                return null;
        }
    }
}
