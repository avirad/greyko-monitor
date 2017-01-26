namespace GreykoMonitor
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.lbSerialPort = new System.Windows.Forms.Label();
            this.cbSerialPort = new System.Windows.Forms.ComboBox();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblSwVer = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTboiler = new System.Windows.Forms.Label();
            this.lblTset = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTdhw = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblFlame = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblThermostat = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblCHPump = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblDHWPump = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblHeater = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblTotalFeed = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblErrors = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTfume = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbSerialPort
            // 
            this.lbSerialPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSerialPort.AutoSize = true;
            this.lbSerialPort.Location = new System.Drawing.Point(251, 15);
            this.lbSerialPort.Name = "lbSerialPort";
            this.lbSerialPort.Size = new System.Drawing.Size(57, 13);
            this.lbSerialPort.TabIndex = 0;
            this.lbSerialPort.Text = "Serial port:";
            // 
            // cbSerialPort
            // 
            this.cbSerialPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerialPort.FormattingEnabled = true;
            this.cbSerialPort.Location = new System.Drawing.Point(314, 12);
            this.cbSerialPort.Name = "cbSerialPort";
            this.cbSerialPort.Size = new System.Drawing.Size(58, 21);
            this.cbSerialPort.TabIndex = 1;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 379);
            this.statusBar.Name = "statusBar";
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(384, 22);
            this.statusBar.TabIndex = 2;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "SWver:";
            // 
            // lblSwVer
            // 
            this.lblSwVer.AutoSize = true;
            this.lblSwVer.Location = new System.Drawing.Point(125, 45);
            this.lblSwVer.Name = "lblSwVer";
            this.lblSwVer.Size = new System.Drawing.Size(13, 13);
            this.lblSwVer.TabIndex = 4;
            this.lblSwVer.Text = "--";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(125, 65);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(13, 13);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date/Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(125, 125);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(13, 13);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "--";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(125, 95);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(13, 13);
            this.lblState.TabIndex = 8;
            this.lblState.Text = "--";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "State:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(77, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Tboiler:";
            // 
            // lblTboiler
            // 
            this.lblTboiler.AutoSize = true;
            this.lblTboiler.Location = new System.Drawing.Point(125, 165);
            this.lblTboiler.Name = "lblTboiler";
            this.lblTboiler.Size = new System.Drawing.Size(13, 13);
            this.lblTboiler.TabIndex = 13;
            this.lblTboiler.Text = "--";
            // 
            // lblTset
            // 
            this.lblTset.AutoSize = true;
            this.lblTset.Location = new System.Drawing.Point(125, 145);
            this.lblTset.Name = "lblTset";
            this.lblTset.Size = new System.Drawing.Size(13, 13);
            this.lblTset.TabIndex = 12;
            this.lblTset.Text = "--";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(88, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Tset:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(82, 185);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Tdhw:";
            // 
            // lblTdhw
            // 
            this.lblTdhw.AutoSize = true;
            this.lblTdhw.Location = new System.Drawing.Point(125, 185);
            this.lblTdhw.Name = "lblTdhw";
            this.lblTdhw.Size = new System.Drawing.Size(13, 13);
            this.lblTdhw.TabIndex = 15;
            this.lblTdhw.Text = "--";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(81, 205);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "Flame:";
            // 
            // lblFlame
            // 
            this.lblFlame.AutoSize = true;
            this.lblFlame.Location = new System.Drawing.Point(125, 205);
            this.lblFlame.Name = "lblFlame";
            this.lblFlame.Size = new System.Drawing.Size(13, 13);
            this.lblFlame.TabIndex = 17;
            this.lblFlame.Text = "--";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(56, 225);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 20;
            this.label16.Text = "Thermostat:";
            // 
            // lblThermostat
            // 
            this.lblThermostat.AutoSize = true;
            this.lblThermostat.Location = new System.Drawing.Point(125, 225);
            this.lblThermostat.Name = "lblThermostat";
            this.lblThermostat.Size = new System.Drawing.Size(13, 13);
            this.lblThermostat.TabIndex = 19;
            this.lblThermostat.Text = "--";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(65, 245);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "CH pump:";
            // 
            // lblCHPump
            // 
            this.lblCHPump.AutoSize = true;
            this.lblCHPump.Location = new System.Drawing.Point(125, 245);
            this.lblCHPump.Name = "lblCHPump";
            this.lblCHPump.Size = new System.Drawing.Size(13, 13);
            this.lblCHPump.TabIndex = 21;
            this.lblCHPump.Text = "--";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(53, 265);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 13);
            this.label20.TabIndex = 24;
            this.label20.Text = "DHW pump:";
            // 
            // lblDHWPump
            // 
            this.lblDHWPump.AutoSize = true;
            this.lblDHWPump.Location = new System.Drawing.Point(125, 265);
            this.lblDHWPump.Name = "lblDHWPump";
            this.lblDHWPump.Size = new System.Drawing.Size(13, 13);
            this.lblDHWPump.TabIndex = 23;
            this.lblDHWPump.Text = "--";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(77, 285);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 13);
            this.label22.TabIndex = 26;
            this.label22.Text = "Heater:";
            // 
            // lblHeater
            // 
            this.lblHeater.AutoSize = true;
            this.lblHeater.Location = new System.Drawing.Point(125, 285);
            this.lblHeater.Name = "lblHeater";
            this.lblHeater.Size = new System.Drawing.Size(13, 13);
            this.lblHeater.TabIndex = 25;
            this.lblHeater.Text = "--";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(58, 305);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(61, 13);
            this.label24.TabIndex = 28;
            this.label24.Text = "Total Feed:";
            // 
            // lblTotalFeed
            // 
            this.lblTotalFeed.AutoSize = true;
            this.lblTotalFeed.Location = new System.Drawing.Point(125, 305);
            this.lblTotalFeed.Name = "lblTotalFeed";
            this.lblTotalFeed.Size = new System.Drawing.Size(13, 13);
            this.lblTotalFeed.TabIndex = 27;
            this.lblTotalFeed.Text = "--";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(82, 325);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(37, 13);
            this.label26.TabIndex = 30;
            this.label26.Text = "Errors:";
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Location = new System.Drawing.Point(125, 325);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(13, 13);
            this.lblErrors.TabIndex = 29;
            this.lblErrors.Text = "--";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Tfume:";
            // 
            // lblTfume
            // 
            this.lblTfume.AutoSize = true;
            this.lblTfume.Location = new System.Drawing.Point(220, 205);
            this.lblTfume.Name = "lblTfume";
            this.lblTfume.Size = new System.Drawing.Size(13, 13);
            this.lblTfume.TabIndex = 31;
            this.lblTfume.Text = "--";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 401);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTfume);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.lblTotalFeed);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblHeater);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblDHWPump);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblCHPump);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblThermostat);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblFlame);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblTdhw);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTboiler);
            this.Controls.Add(this.lblTset);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSwVer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.cbSerialPort);
            this.Controls.Add(this.lbSerialPort);
            this.MinimumSize = new System.Drawing.Size(400, 440);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Greyko Monitor v1.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSerialPort;
        private System.Windows.Forms.ComboBox cbSerialPort;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSwVer;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTboiler;
        private System.Windows.Forms.Label lblTset;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTdhw;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblFlame;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblThermostat;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblCHPump;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblDHWPump;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblHeater;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblTotalFeed;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTfume;
    }
}

