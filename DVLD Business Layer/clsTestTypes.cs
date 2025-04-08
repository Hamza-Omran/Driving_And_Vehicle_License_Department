using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer
{
    public class clsTestTypes
    {
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };


        public enTestType ID { set; get; }

        public string TestTypeTitle { set; get; }

        public string TestTypeDescription { set; get; }

        public float TestTypeFees { set; get; }

        private clsTestTypes(enTestType ID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            this.ID = ID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }

        public bool Save()
        {
            return clsTestTypesData.UpdateTestType((int)this.ID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }

        public static DataTable GetAll()
        {
            return clsTestTypesData.GetAllTestTypes();
        }

        public static clsTestTypes Find(enTestType ID)
        {
            string TestTypeTitle = "";
            string TestTypeDescription = "";
            float TestFees = 0;

            if (clsTestTypesData.Find((int)ID, ref TestTypeTitle, ref TestTypeDescription, ref TestFees))
                return new clsTestTypes(ID, TestTypeTitle, TestTypeDescription, TestFees);
            else
                return null;
        }
    }
}


