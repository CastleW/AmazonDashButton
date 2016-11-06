namespace AmazonDashUI
{
    /// <summary>
    /// The Main Form for this application
    /// </summary>
    public partial class MainForm
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
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.allowAnyButton = new System.Windows.Forms.RadioButton();
            this.specificButton = new System.Windows.Forms.RadioButton();
            this.specificButtonToAllow = new System.Windows.Forms.TextBox();
            this.webPageToOpen = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lastButtonDetected = new System.Windows.Forms.TextBox();
            this.useOnlyThisButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            this.playChime = new System.Windows.Forms.RadioButton();
            this.openThisWebPage = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // allowAnyButton
            // 
            this.allowAnyButton.AutoSize = true;
            this.allowAnyButton.Location = new System.Drawing.Point(6, 19);
            this.allowAnyButton.Name = "allowAnyButton";
            this.allowAnyButton.Size = new System.Drawing.Size(119, 17);
            this.allowAnyButton.TabIndex = 2;
            this.allowAnyButton.TabStop = true;
            this.allowAnyButton.Text = "React to any button";
            this.allowAnyButton.UseVisualStyleBackColor = true;
            this.allowAnyButton.CheckedChanged += new System.EventHandler(this.allowAnyButton_CheckedChanged);
            // 
            // specificButton
            // 
            this.specificButton.AutoSize = true;
            this.specificButton.Location = new System.Drawing.Point(6, 42);
            this.specificButton.Name = "specificButton";
            this.specificButton.Size = new System.Drawing.Size(140, 17);
            this.specificButton.TabIndex = 3;
            this.specificButton.TabStop = true;
            this.specificButton.Text = "React to only this button";
            this.specificButton.UseVisualStyleBackColor = true;
            this.specificButton.CheckedChanged += new System.EventHandler(this.specificButton_CheckedChanged);
            // 
            // specificButtonToAllow
            // 
            this.specificButtonToAllow.Location = new System.Drawing.Point(150, 41);
            this.specificButtonToAllow.Name = "specificButtonToAllow";
            this.specificButtonToAllow.Size = new System.Drawing.Size(201, 20);
            this.specificButtonToAllow.TabIndex = 4;
            this.specificButtonToAllow.TextChanged += new System.EventHandler(this.specificButtonToAllow_TextChanged);
            // 
            // webPageToOpen
            // 
            this.webPageToOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webPageToOpen.Location = new System.Drawing.Point(5, 67);
            this.webPageToOpen.Name = "webPageToOpen";
            this.webPageToOpen.Size = new System.Drawing.Size(346, 20);
            this.webPageToOpen.TabIndex = 9;
            this.webPageToOpen.TextChanged += new System.EventHandler(this.webPageToOpen_TextChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(131, 46);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(28, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Test";
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // lastButtonDetected
            // 
            this.lastButtonDetected.Location = new System.Drawing.Point(117, 16);
            this.lastButtonDetected.Name = "lastButtonDetected";
            this.lastButtonDetected.ReadOnly = true;
            this.lastButtonDetected.Size = new System.Drawing.Size(183, 20);
            this.lastButtonDetected.TabIndex = 12;
            // 
            // useOnlyThisButton
            // 
            this.useOnlyThisButton.Location = new System.Drawing.Point(306, 15);
            this.useOnlyThisButton.Name = "useOnlyThisButton";
            this.useOnlyThisButton.Size = new System.Drawing.Size(45, 23);
            this.useOnlyThisButton.TabIndex = 13;
            this.useOnlyThisButton.Text = "Use";
            this.useOnlyThisButton.UseVisualStyleBackColor = true;
            this.useOnlyThisButton.Click += new System.EventHandler(this.UseOnlyThisButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Last button detected";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // notifyIcon2
            // 
            this.notifyIcon2.Text = "notifyIcon2";
            this.notifyIcon2.Visible = true;
            // 
            // playChime
            // 
            this.playChime.AutoSize = true;
            this.playChime.Location = new System.Drawing.Point(5, 19);
            this.playChime.Name = "playChime";
            this.playChime.Size = new System.Drawing.Size(76, 17);
            this.playChime.TabIndex = 6;
            this.playChime.Text = "Play chime";
            this.playChime.UseVisualStyleBackColor = true;
            this.playChime.CheckedChanged += new System.EventHandler(this.playChime_CheckedChanged);
            // 
            // openThisWebPage
            // 
            this.openThisWebPage.AutoSize = true;
            this.openThisWebPage.Location = new System.Drawing.Point(5, 42);
            this.openThisWebPage.Name = "openThisWebPage";
            this.openThisWebPage.Size = new System.Drawing.Size(120, 17);
            this.openThisWebPage.TabIndex = 7;
            this.openThisWebPage.Text = "Open this web page";
            this.openThisWebPage.UseVisualStyleBackColor = true;
            this.openThisWebPage.CheckedChanged += new System.EventHandler(this.openThisWebPage_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.allowAnyButton);
            this.groupBox1.Controls.Add(this.specificButtonToAllow);
            this.groupBox1.Controls.Add(this.specificButton);
            this.groupBox1.Location = new System.Drawing.Point(7, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 66);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Amazon Dash Button";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.playChime);
            this.groupBox2.Controls.Add(this.openThisWebPage);
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.webPageToOpen);
            this.groupBox2.Location = new System.Drawing.Point(7, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 93);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action to take";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.useOnlyThisButton);
            this.groupBox3.Controls.Add(this.lastButtonDetected);
            this.groupBox3.Location = new System.Drawing.Point(7, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(359, 45);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Diagnostics";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 213);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "Amazon Dash Button";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton allowAnyButton;
        private System.Windows.Forms.RadioButton specificButton;
        private System.Windows.Forms.TextBox specificButtonToAllow;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox lastButtonDetected;
        private System.Windows.Forms.Button useOnlyThisButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox webPageToOpen;
        private System.Windows.Forms.NotifyIcon notifyIcon2;
        private System.Windows.Forms.RadioButton openThisWebPage;
        private System.Windows.Forms.RadioButton playChime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

