namespace TestingApp
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtsimpletext = new Telerik.WinControls.UI.RadTextBoxControl();
            this.btnencrypt = new Telerik.WinControls.UI.RadButton();
            this.txtencryptresult = new Telerik.WinControls.UI.RadTextBoxControl();
            this.btndecrypt = new Telerik.WinControls.UI.RadButton();
            this.txtdecryptresult = new Telerik.WinControls.UI.RadTextBoxControl();
            this.btnhash = new Telerik.WinControls.UI.RadButton();
            this.txthash160 = new Telerik.WinControls.UI.RadTextBoxControl();
            this.txthash256 = new Telerik.WinControls.UI.RadTextBoxControl();
            this.txthash512 = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.btnlicense = new Telerik.WinControls.UI.RadButton();
            this.txthardwarekey = new Telerik.WinControls.UI.RadTextBoxControl();
            this.txtlicense = new Telerik.WinControls.UI.RadTextBoxControl();
            this.btngenerate = new Telerik.WinControls.UI.RadButton();
            this.txtlicenseresult = new Telerik.WinControls.UI.RadTextBoxControl();
            this.btnverify = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsimpletext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnencrypt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtencryptresult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btndecrypt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdecryptresult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnhash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txthash160)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txthash256)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txthash512)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnlicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txthardwarekey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btngenerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlicenseresult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnverify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(108, 72);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 24);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "Generate Log";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(108, 102);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(110, 24);
            this.radButton2.TabIndex = 1;
            this.radButton2.Text = "Generate Exception";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(54, 144);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(27, 18);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "Text";
            // 
            // txtsimpletext
            // 
            this.txtsimpletext.Location = new System.Drawing.Point(115, 140);
            this.txtsimpletext.Name = "txtsimpletext";
            this.txtsimpletext.Size = new System.Drawing.Size(292, 22);
            this.txtsimpletext.TabIndex = 3;
            // 
            // btnencrypt
            // 
            this.btnencrypt.Location = new System.Drawing.Point(115, 168);
            this.btnencrypt.Name = "btnencrypt";
            this.btnencrypt.Size = new System.Drawing.Size(110, 24);
            this.btnencrypt.TabIndex = 4;
            this.btnencrypt.Text = "Encrypt";
            this.btnencrypt.Click += new System.EventHandler(this.btnencrypt_Click);
            // 
            // txtencryptresult
            // 
            this.txtencryptresult.Location = new System.Drawing.Point(413, 140);
            this.txtencryptresult.Name = "txtencryptresult";
            this.txtencryptresult.Size = new System.Drawing.Size(292, 22);
            this.txtencryptresult.TabIndex = 5;
            // 
            // btndecrypt
            // 
            this.btndecrypt.Location = new System.Drawing.Point(413, 168);
            this.btndecrypt.Name = "btndecrypt";
            this.btndecrypt.Size = new System.Drawing.Size(110, 24);
            this.btndecrypt.TabIndex = 6;
            this.btndecrypt.Text = "Decrypt";
            this.btndecrypt.Click += new System.EventHandler(this.btndecrypt_Click);
            // 
            // txtdecryptresult
            // 
            this.txtdecryptresult.Location = new System.Drawing.Point(413, 198);
            this.txtdecryptresult.Name = "txtdecryptresult";
            this.txtdecryptresult.Size = new System.Drawing.Size(292, 22);
            this.txtdecryptresult.TabIndex = 7;
            // 
            // btnhash
            // 
            this.btnhash.Location = new System.Drawing.Point(231, 168);
            this.btnhash.Name = "btnhash";
            this.btnhash.Size = new System.Drawing.Size(110, 24);
            this.btnhash.TabIndex = 8;
            this.btnhash.Text = "Hash";
            this.btnhash.Click += new System.EventHandler(this.btnhash_Click);
            // 
            // txthash160
            // 
            this.txthash160.Location = new System.Drawing.Point(115, 226);
            this.txthash160.Name = "txthash160";
            this.txthash160.Size = new System.Drawing.Size(590, 22);
            this.txthash160.TabIndex = 9;
            // 
            // txthash256
            // 
            this.txthash256.Location = new System.Drawing.Point(115, 254);
            this.txthash256.Name = "txthash256";
            this.txthash256.Size = new System.Drawing.Size(590, 22);
            this.txthash256.TabIndex = 10;
            // 
            // txthash512
            // 
            this.txthash512.Location = new System.Drawing.Point(115, 282);
            this.txthash512.Name = "txthash512";
            this.txthash512.Size = new System.Drawing.Size(590, 22);
            this.txthash512.TabIndex = 11;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(54, 230);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(51, 18);
            this.radLabel2.TabIndex = 12;
            this.radLabel2.Text = "hash 160";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(54, 258);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(51, 18);
            this.radLabel3.TabIndex = 13;
            this.radLabel3.Text = "hash 265";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(54, 286);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(51, 18);
            this.radLabel4.TabIndex = 14;
            this.radLabel4.Text = "hash 512";
            // 
            // btnlicense
            // 
            this.btnlicense.Location = new System.Drawing.Point(115, 310);
            this.btnlicense.Name = "btnlicense";
            this.btnlicense.Size = new System.Drawing.Size(110, 24);
            this.btnlicense.TabIndex = 15;
            this.btnlicense.Text = "Hardware Key";
            this.btnlicense.Click += new System.EventHandler(this.btnlicense_Click);
            // 
            // txthardwarekey
            // 
            this.txthardwarekey.Location = new System.Drawing.Point(231, 312);
            this.txthardwarekey.Name = "txthardwarekey";
            this.txthardwarekey.Size = new System.Drawing.Size(474, 22);
            this.txthardwarekey.TabIndex = 16;
            // 
            // txtlicense
            // 
            this.txtlicense.Location = new System.Drawing.Point(231, 342);
            this.txtlicense.Name = "txtlicense";
            this.txtlicense.Size = new System.Drawing.Size(474, 22);
            this.txtlicense.TabIndex = 18;
            // 
            // btngenerate
            // 
            this.btngenerate.Location = new System.Drawing.Point(115, 340);
            this.btngenerate.Name = "btngenerate";
            this.btngenerate.Size = new System.Drawing.Size(110, 24);
            this.btngenerate.TabIndex = 17;
            this.btngenerate.Text = "Generate License";
            this.btngenerate.Click += new System.EventHandler(this.btngenerate_Click);
            // 
            // txtlicenseresult
            // 
            this.txtlicenseresult.Location = new System.Drawing.Point(231, 372);
            this.txtlicenseresult.Name = "txtlicenseresult";
            this.txtlicenseresult.Size = new System.Drawing.Size(474, 22);
            this.txtlicenseresult.TabIndex = 20;
            // 
            // btnverify
            // 
            this.btnverify.Location = new System.Drawing.Point(115, 370);
            this.btnverify.Name = "btnverify";
            this.btnverify.Size = new System.Drawing.Size(110, 24);
            this.btnverify.TabIndex = 19;
            this.btnverify.Text = "Verify License";
            this.btnverify.Click += new System.EventHandler(this.btnverify_Click);
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 579);
            this.Controls.Add(this.txtlicenseresult);
            this.Controls.Add(this.btnverify);
            this.Controls.Add(this.txtlicense);
            this.Controls.Add(this.btngenerate);
            this.Controls.Add(this.txthardwarekey);
            this.Controls.Add(this.btnlicense);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txthash512);
            this.Controls.Add(this.txthash256);
            this.Controls.Add(this.txthash160);
            this.Controls.Add(this.btnhash);
            this.Controls.Add(this.txtdecryptresult);
            this.Controls.Add(this.btndecrypt);
            this.Controls.Add(this.txtencryptresult);
            this.Controls.Add(this.btnencrypt);
            this.Controls.Add(this.txtsimpletext);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMain";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Testing UFFU";
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsimpletext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnencrypt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtencryptresult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btndecrypt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdecryptresult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnhash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txthash160)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txthash256)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txthash512)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnlicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txthardwarekey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btngenerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlicenseresult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnverify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBoxControl txtsimpletext;
        private Telerik.WinControls.UI.RadButton btnencrypt;
        private Telerik.WinControls.UI.RadTextBoxControl txtencryptresult;
        private Telerik.WinControls.UI.RadButton btndecrypt;
        private Telerik.WinControls.UI.RadTextBoxControl txtdecryptresult;
        private Telerik.WinControls.UI.RadButton btnhash;
        private Telerik.WinControls.UI.RadTextBoxControl txthash160;
        private Telerik.WinControls.UI.RadTextBoxControl txthash256;
        private Telerik.WinControls.UI.RadTextBoxControl txthash512;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadButton btnlicense;
        private Telerik.WinControls.UI.RadTextBoxControl txthardwarekey;
        private Telerik.WinControls.UI.RadTextBoxControl txtlicense;
        private Telerik.WinControls.UI.RadButton btngenerate;
        private Telerik.WinControls.UI.RadTextBoxControl txtlicenseresult;
        private Telerik.WinControls.UI.RadButton btnverify;
    }
}