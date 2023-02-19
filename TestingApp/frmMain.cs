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

        private void btnInput_Click(object sender, EventArgs e)
        {
            try
            {
                if(mFm.IsAlphabet(txtInput.Text)) 
                {
                    lblOutput.Text = "alphabet";
                }
                else
                {
                    lblOutput.Text = "not a alphabet";
                }
            }
            catch (Exception ex)
            {
                mFm obj = new mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                obj.LogException("Testing 101", ex);
            }
        }

        private void btnnumber_Click(object sender, EventArgs e)
        {
            try
            {
                if (mFm.IsNumber(txtInput.Text))
                {
                    lblOutput.Text = "number";
                }
                else
                {
                    lblOutput.Text = "not a number";
                }
            }
            catch (Exception ex)
            {
                mFm obj = new mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                obj.LogException("Testing 101", ex);
            }
        }

        private void btninteger_Click(object sender, EventArgs e)
        {
            try
            {
                if (mFm.IsInteger(txtInput.Text, "16"))
                {
                    lblOutput.Text = "integer";
                }
                else
                {
                    lblOutput.Text = "not a integer";
                }
            }
            catch (Exception ex)
            {
                mFm obj = new mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                obj.LogException("Testing 101", ex);
            }
        }

        private void btndecimal_Click(object sender, EventArgs e)
        {
            try
            {
                if (mFm.IsDecimal(txtInput.Text))
                {
                    lblOutput.Text = "decimal";
                }
                else
                {
                    lblOutput.Text = "not a decimal";
                }
            }
            catch (Exception ex)
            {
                mFm obj = new mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                obj.LogException("Testing 101", ex);
            }
        }

        private void btnemail_Click(object sender, EventArgs e)
        {
            try
            {
                if (mFm.IsEmail(txtInput.Text))
                {
                    lblOutput.Text = "email";
                }
                else
                {
                    lblOutput.Text = "not a email";
                }
            }
            catch (Exception ex)
            {
                mFm obj = new mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                obj.LogException("Testing 101", ex);
            }
        }

        private void btndate_Click(object sender, EventArgs e)
        {
            try
            {
                if (mFm.IsDatetime(txtInput.Text))
                {
                    lblOutput.Text = "datetime";
                }
                else
                {
                    lblOutput.Text = "not a datetime";
                }
            }
            catch (Exception ex)
            {
                mFm obj = new mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                obj.LogException("Testing 101", ex);
            }
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            try
            {
                mFm obj = new mFm(Environment.CurrentDirectory, "TestingApp.log", true, false);
                if (obj is not null)
                {
                    obj.LogEntryByEmail("Testing 101", "testing message from generate logs.");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void radButton4_Click(object sender, EventArgs e)
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
                    obj.LogExceptionByEmail("Testing 101", ex);
                }
            }
        }
    }
}
