using DVLD_Business_Layer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    public static class clsGlobal
    {
        public static clsUsers SysUser;

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, "UsernameVal", Username, RegistryValueKind.String);
                Registry.SetValue(keyPath, "PasswordVal", Password, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                clsUtil.ExceptionLog("Could Not Copy Image.", EventLogEntryType.Error);
                return false;            
            }
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

            try
            {
                // Write the value to the Registry
                Username = Registry.GetValue(keyPath, "UsernameVal", null) as string;
                Password = Registry.GetValue(keyPath, "PasswordVal", null) as string;

                if(Username != null && Password != null)
                    return true;
                else 
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                clsUtil.ExceptionLog("Could Not Store Credentials.", EventLogEntryType.Error);
                return false;
            }

        }
    }
}
