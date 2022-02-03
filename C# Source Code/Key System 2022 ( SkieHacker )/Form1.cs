using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Key_System_2022___SkieHacker__
{
    // What's up motherfuckers

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            /*
             * Okay, This shit make you Possible your Exploit Key Sys work 24 Hours. I wouldn't improved this further cause i'm lazy but yea just improve it to yourself. Make it better.
             * Remove this Below if you don't want your Key System being 24 Hours used. This Code similars to Panda A+ but ours is muched improvement. We Open Source this to you
             * so you can bleed your shit into money moneeeyy...
             * 
             * Oh yea credit me lol
             */
            MakeMe24HoursGay();

        }


        private async void MakeMe24HoursGay()
        {
            await Task.Delay(1500);
            if (!File.Exists(System.IO.Path.GetTempPath() + "SavedKey.temp"))
            {
                File.WriteAllText(System.IO.Path.GetTempPath() + "SavedKey.temp", "");
            }
            string PandaTech = File.ReadAllText(System.IO.Path.GetTempPath() + "SavedKey.temp");

            string[] ArrayData = new string[] { PandaTech };
            if (ArrayData[0].Contains(DateTime.Now.ToString("M-d-yyyy")))
            {
                //Textmsg.Text = "Key Readed...Valid";
                MessageBox.Show("Your Key has been Detected and Currently Valid. Entering to Panda A+");
                new Form2().Show();
                this.Close();
                return;
            }
            else if (ArrayData[0].Contains(string.Empty))
            {
                //Textmsg.Text = "Press Get Key to Obtain your Key";
            }
            else
            {
                //Textmsg.Text = "Your 24 Hours Key is no Longer Valid";
            }
        }
        private void button1_Click(object sender, EventArgs e) // Known as your fucking Login Button
        {
            string CurrentKey = textBox1.Text;
            if (new BuffedKeySys().CheckKey("https://pandatechnology.xyz/KeySystem/Panda/check.php?key=", CurrentKey))
            {
                File.WriteAllText(System.IO.Path.GetTempPath() + "SavedKey1.temp", CurrentKey); // Saves your Key
                File.WriteAllText(System.IO.Path.GetTempPath() + "SavedKey.temp", DateTime.Now.ToString("M-d-yyyy")); //Saves your Current Time lol.
                new Form2().Show();
                this.Close();
                return;
            }
            //For Developers and Beta Users
            else if (new BuffedKeySys().DevCheckKey("https://pandatechnology.xyz/KeySystem/Panda/check.php?key=", CurrentKey))
            {
                File.WriteAllText(System.IO.Path.GetTempPath() + "PandaToken.temp", CurrentKey);
                new Form2().Show();
                this.Close();
                return;
            }
            MessageBox.Show("Invalid Key or Not Recognized in the Server, If you're a Beta User. You may have an Incorrect Email or not authenticated by your Device ID.");
        }
    }
}
