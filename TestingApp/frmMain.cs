using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace TestingApp
{
    public partial class frmMain : Telerik.WinControls.UI.RadForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                UFFU.mFm obj = new UFFU.mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                if(obj is not null)
                {
                    obj.LogEntry("Testing 101", "testing message from generate logs.");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("baray hi dash ho.");
            }
            catch (Exception ex)
            {
                UFFU.mFm obj = new UFFU.mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                if (obj is not null)
                {
                    //obj.LogEntry("Testing 101", $"generate exception {ex.Message}");
                    obj.LogException("Testing 101", ex);
                }
            }
        }
    }
}
