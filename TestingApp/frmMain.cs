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
using UFFU;

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
                mFm obj = new mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                if (obj is not null)
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
                mFm obj = new mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                if (obj is not null)
                {
                    //obj.LogEntry("Testing 101", $"generate exception {ex.Message}");
                    obj.LogException("Testing 101", ex);
                }
            }
        }

        private void btnencrypt_Click(object sender, EventArgs e)
        {
            try
            {
                txtencryptresult.Text = mFm.mfmEncryption(txtsimpletext.Text);
            }
            catch (Exception ex)
            {
                mFm obj = new mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                obj.LogException("Testing 101", ex);
            }
        }

        private void btndecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                txtdecryptresult.Text = mFm.mfmDecryption(txtencryptresult.Text);
            }
            catch (Exception ex)
            {
                mFm obj = new mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                obj.LogException("Testing 101", ex);
            }
        }

        private void btnhash_Click(object sender, EventArgs e)
        {
            try
            {
                txthash160.Text = mFm.mfmGetHash(txtsimpletext.Text, mFm.mfmHashTypes.mfm160);
                txthash256.Text = mFm.mfmGetHash(txtsimpletext.Text, mFm.mfmHashTypes.mfm256);
                txthash512.Text = mFm.mfmGetHash(txtsimpletext.Text, mFm.mfmHashTypes.mfm512);
            }
            catch (Exception ex)
            {
                mFm obj = new mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                obj.LogException("Testing 101", ex);
            }
        }

        private void btnlicense_Click(object sender, EventArgs e)
        {
            try
            {
                txthardwarekey.Text = mFm.mfmGetSystemID();

            }
            catch (Exception ex)
            {
                mFm obj = new mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                obj.LogException("Testing 101", ex);
            }
        }

        private void btngenerate_Click(object sender, EventArgs e)
        {
            try
            {
                txtlicense.Text = mFm.mfmGenerateLicense(txthardwarekey.Text, new DateTime(2023, 1, 1), new DateTime(2023, 12, 31));
            }
            catch (Exception ex)
            {
                mFm obj = new mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                obj.LogException("Testing 101", ex);
            }
        }

        private void btnverify_Click(object sender, EventArgs e)
        {
            try
            {
                txtlicenseresult.Text = mFm.mfmVerifyLicense(txtlicense.Text).ToString();
            }
            catch (Exception ex)
            {
                mFm obj = new mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                obj.LogException("Testing 101", ex);
            }
        }
    }
}
