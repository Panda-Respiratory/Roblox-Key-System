using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Key_System_2022___SkieHacker__
{
    public class BuffedKeySys
    {
        // Key System API ( Panda Architecture )
        // Pretty sure your smart than me
        // so yea improvised on your own



        public bool CheckKey(string URL, string key)
        {
            string hwid = MachineGuid();
            if (SecurityWebDebug())
            {
                MessageBox.Show("Panda has blocked your Permission to Access the Site.\nError: PandaGuard_92x40");
                return false;
            }
            string site_check = URL;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
            WebClient web = new WebClient();
            web.Proxy = null;
            if (web.DownloadString(site_check + key) != "Whitelisted") //change the site with your own site lmfao
            {
                return false;
            }
            return true;
        }

        public bool DevCheckKey(string URL, string key)
        {
            string hwid = MachineGuid();
            if (SecurityWebDebug())
            {
                MessageBox.Show("Panda has blocked your Permission to Access the Site.\nError: PandaGuard_92x40");
                return false;
            }
            string site_check = URL;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
            WebClient web = new WebClient();
            web.Proxy = null;
            if (web.DownloadString(site_check + key + "&hwid=" + hwid) != "DevMode") //change the site with your own site lmfao
            {
                return false;
            }
            return true;
        }

        //Don't complain to me about 
        private bool SecurityWebDebug()
        {
            try
            {
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.ToLower().Contains("fiddler") | process.ProcessName.ToLower().Contains("wireshark") | process.ProcessName.ToLower().Contains("charles") | process.ProcessName.ToLower().Contains("dnSpy") | process.ProcessName.ToLower().Contains("Hacker") | process.ProcessName.ToLower().Contains("ollydbg") | process.ProcessName.ToLower().Contains("HTTPDebuggerPro") | process.ProcessName.ToLower().Contains("HTTPDebuggerSvc") | process.MainWindowTitle.ToLower().Contains("fiddler") | process.MainWindowTitle.ToLower().Contains("dnSpy") | process.MainWindowTitle.ToLower().Contains("wireshark") | process.MainWindowTitle.ToLower().Contains("charles") | process.MainWindowTitle.ToLower().Contains("SoftPerfect") | process.MainWindowTitle.ToLower().Contains("ollydbg") | process.MainWindowTitle.ToLower().Contains("Hacker") | process.MainWindowTitle.ToLower().Contains("HTTPDebuggerPro") | process.MainWindowTitle.ToLower().Contains("HTTPDebuggerSvc"))
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        //Your HWID ( Machine ID ) Goes here
        public static string MachineGuid()
        {
            if (RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Cryptography") == null)
                throw new KeyNotFoundException(string.Format("Registry key not found: {0}", @"SOFTWARE\Microsoft\Cryptography"));
            if (RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Cryptography").GetValue("MachineGuid") == null)
                throw new IndexOutOfRangeException(string.Format("Index not found: {0}", "MachineGuid"));
            string myhwid = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Cryptography").GetValue("MachineGuid").ToString();
            return myhwid;
        }
    }
}
