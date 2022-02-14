
namespace Tennis
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelTennisCourt = new System.Windows.Forms.Panel();
            this.picBoxRacket = new System.Windows.Forms.PictureBox();
            this.grpBxTennis = new System.Windows.Forms.GroupBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.lblAddEnglish = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblTotalPoints = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblMisses = new System.Windows.Forms.Label();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.picBoxTennisBall = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelTennisCourt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxRacket)).BeginInit();
            this.grpBxTennis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTennisBall)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTennisCourt
            // 
            this.panelTennisCourt.BackColor = System.Drawing.SystemColors.Control;
            this.panelTennisCourt.Controls.Add(this.picBoxRacket);
            this.panelTennisCourt.Controls.Add(this.grpBxTennis);
            this.panelTennisCourt.Controls.Add(this.picBoxTennisBall);
            this.panelTennisCourt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTennisCourt.Location = new System.Drawing.Point(0, 0);
            this.panelTennisCourt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTennisCourt.Name = "panelTennisCourt";
            this.panelTennisCourt.Size = new System.Drawing.Size(1064, 779);
            this.panelTennisCourt.TabIndex = 0;
            this.panelTennisCourt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelTennisCourt_MouseClick);
            // 
            // picBoxRacket
            // 
            this.picBoxRacket.BackColor = System.Drawing.Color.Red;
            this.picBoxRacket.Location = new System.Drawing.Point(473, 615);
            this.picBoxRacket.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picBoxRacket.Name = "picBoxRacket";
            this.picBoxRacket.Size = new System.Drawing.Size(107, 12);
            this.picBoxRacket.TabIndex = 7;
            this.picBoxRacket.TabStop = false;
            // 
            // grpBxTennis
            // 
            this.grpBxTennis.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.grpBxTennis.Controls.Add(this.btnPause);
            this.grpBxTennis.Controls.Add(this.lblAddEnglish);
            this.grpBxTennis.Controls.Add(this.lblMessage);
            this.grpBxTennis.Controls.Add(this.btnStart);
            this.grpBxTennis.Controls.Add(this.btnQuit);
            this.grpBxTennis.Controls.Add(this.lblTotalPoints);
            this.grpBxTennis.Controls.Add(this.lblSpeed);
            this.grpBxTennis.Controls.Add(this.lblMisses);
            this.grpBxTennis.Controls.Add(this.trackBarSpeed);
            this.grpBxTennis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBxTennis.Location = new System.Drawing.Point(9, 672);
            this.grpBxTennis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpBxTennis.Name = "grpBxTennis";
            this.grpBxTennis.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpBxTennis.Size = new System.Drawing.Size(1047, 110);
            this.grpBxTennis.TabIndex = 6;
            this.grpBxTennis.TabStop = false;
            this.grpBxTennis.Text = "Tennis Panel";
            // 
            // btnPause
            // 
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(871, 25);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(80, 32);
            this.btnPause.TabIndex = 14;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // lblAddEnglish
            // 
            this.lblAddEnglish.AutoSize = true;
            this.lblAddEnglish.BackColor = System.Drawing.Color.Red;
            this.lblAddEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEnglish.ForeColor = System.Drawing.Color.Yellow;
            this.lblAddEnglish.Location = new System.Drawing.Point(28, 80);
            this.lblAddEnglish.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddEnglish.Name = "lblAddEnglish";
            this.lblAddEnglish.Size = new System.Drawing.Size(228, 20);
            this.lblAddEnglish.TabIndex = 13;
            this.lblAddEnglish.Tag = "";
            this.lblAddEnglish.Text = "L/R Mouse to Add English";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Yellow;
            this.lblMessage.Location = new System.Drawing.Point(317, 31);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(469, 25);
            this.lblMessage.TabIndex = 12;
            this.lblMessage.Text = "Bonus: You received a point and an Extra Miss!";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Red;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Yellow;
            this.btnStart.Location = new System.Drawing.Point(959, 23);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 32);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(959, 63);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(80, 32);
            this.btnQuit.TabIndex = 10;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblTotalPoints
            // 
            this.lblTotalPoints.AutoSize = true;
            this.lblTotalPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPoints.Location = new System.Drawing.Point(584, 65);
            this.lblTotalPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPoints.Name = "lblTotalPoints";
            this.lblTotalPoints.Size = new System.Drawing.Size(158, 39);
            this.lblTotalPoints.TabIndex = 9;
            this.lblTotalPoints.Text = "Points: 0";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(67, 59);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(132, 20);
            this.lblSpeed.TabIndex = 8;
            this.lblSpeed.Text = "Ball Speed: 20";
            // 
            // lblMisses
            // 
            this.lblMisses.AutoSize = true;
            this.lblMisses.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMisses.Location = new System.Drawing.Point(312, 66);
            this.lblMisses.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMisses.Name = "lblMisses";
            this.lblMisses.Size = new System.Drawing.Size(219, 39);
            this.lblMisses.TabIndex = 7;
            this.lblMisses.Text = "Misses: 0/10";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Location = new System.Drawing.Point(27, 23);
            this.trackBarSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBarSpeed.Maximum = 100;
            this.trackBarSpeed.Minimum = 20;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(245, 56);
            this.trackBarSpeed.TabIndex = 6;
            this.trackBarSpeed.TickFrequency = 10;
            this.trackBarSpeed.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarSpeed.Value = 20;
            this.trackBarSpeed.ValueChanged += new System.EventHandler(this.trackBarSpeed_ValueChanged);
            // 
            // picBoxTennisBall
            // 
            this.picBoxTennisBall.Image = ((System.Drawing.Image)(resources.GetObject("picBoxTennisBall.Image")));
            this.picBoxTennisBall.Location = new System.Drawing.Point(367, 170);
            this.picBoxTennisBall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picBoxTennisBall.Name = "picBoxTennisBall";
            this.picBoxTennisBall.Size = new System.Drawing.Size(67, 62);
            this.picBoxTennisBall.TabIndex = 1;
            this.picBoxTennisBall.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 779);
            this.Controls.Add(this.panelTennisCourt);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1082, 826);
            this.MinimumSize = new System.Drawing.Size(1082, 826);
            this.Name = "Form1";
            this.Text = "Tennis Game By Wasim Khamis";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelTennisCourt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxRacket)).EndInit();
            this.grpBxTennis.ResumeLayout(false);
            this.grpBxTennis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTennisBall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTennisCourt;
        private System.Windows.Forms.PictureBox picBoxTennisBall;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox grpBxTennis;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lblTotalPoints;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblMisses;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.PictureBox picBoxRacket;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblAddEnglish;
        private System.Windows.Forms.Button btnPause;
    }
}

