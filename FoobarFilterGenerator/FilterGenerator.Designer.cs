namespace FoobarFilterGenerator
{
    partial class FilterGenerator
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
            this.label3 = new System.Windows.Forms.Label();
            this.existingStringTextbox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.artistsTab = new System.Windows.Forms.TabPage();
            this.artistsTextbox = new System.Windows.Forms.TextBox();
            this.albumsTab = new System.Windows.Forms.TabPage();
            this.albumsTextbox = new System.Windows.Forms.TextBox();
            this.directoriesTab = new System.Windows.Forms.TabPage();
            this.directoriesTb = new System.Windows.Forms.TextBox();
            this.whitelistBlacklistDirsGB = new System.Windows.Forms.GroupBox();
            this.blacklistDirsRB = new System.Windows.Forms.RadioButton();
            this.whitelistDirsRB = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bitratePicker = new System.Windows.Forms.NumericUpDown();
            this.cbBitrate = new System.Windows.Forms.CheckBox();
            this.cbFilterLive = new System.Windows.Forms.CheckBox();
            this.cbFilterRemix = new System.Windows.Forms.CheckBox();
            this.outputTextbox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.artistsTab.SuspendLayout();
            this.albumsTab.SuspendLayout();
            this.directoriesTab.SuspendLayout();
            this.whitelistBlacklistDirsGB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bitratePicker)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "If you already have an existing filter, paste it here";
            // 
            // existingStringTextbox
            // 
            this.existingStringTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.existingStringTextbox.Location = new System.Drawing.Point(2, 20);
            this.existingStringTextbox.Name = "existingStringTextbox";
            this.existingStringTextbox.Size = new System.Drawing.Size(310, 20);
            this.existingStringTextbox.TabIndex = 6;
            this.existingStringTextbox.TextChanged += new System.EventHandler(this.ExistingStringTextbox_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.artistsTab);
            this.tabControl1.Controls.Add(this.albumsTab);
            this.tabControl1.Controls.Add(this.directoriesTab);
            this.tabControl1.Location = new System.Drawing.Point(2, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(310, 200);
            this.tabControl1.TabIndex = 8;
            // 
            // artistsTab
            // 
            this.artistsTab.Controls.Add(this.artistsTextbox);
            this.artistsTab.Location = new System.Drawing.Point(4, 22);
            this.artistsTab.Name = "artistsTab";
            this.artistsTab.Padding = new System.Windows.Forms.Padding(3);
            this.artistsTab.Size = new System.Drawing.Size(302, 174);
            this.artistsTab.TabIndex = 0;
            this.artistsTab.Text = "Artists";
            this.artistsTab.UseVisualStyleBackColor = true;
            // 
            // artistsTextbox
            // 
            this.artistsTextbox.AcceptsReturn = true;
            this.artistsTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artistsTextbox.Location = new System.Drawing.Point(3, 3);
            this.artistsTextbox.Multiline = true;
            this.artistsTextbox.Name = "artistsTextbox";
            this.artistsTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.artistsTextbox.Size = new System.Drawing.Size(296, 168);
            this.artistsTextbox.TabIndex = 0;
            this.artistsTextbox.WordWrap = false;
            this.artistsTextbox.TextChanged += new System.EventHandler(this.artistsTextbox_TextChanged);
            // 
            // albumsTab
            // 
            this.albumsTab.Controls.Add(this.albumsTextbox);
            this.albumsTab.Location = new System.Drawing.Point(4, 22);
            this.albumsTab.Name = "albumsTab";
            this.albumsTab.Padding = new System.Windows.Forms.Padding(3);
            this.albumsTab.Size = new System.Drawing.Size(302, 174);
            this.albumsTab.TabIndex = 1;
            this.albumsTab.Text = "Albums";
            this.albumsTab.UseVisualStyleBackColor = true;
            // 
            // albumsTextbox
            // 
            this.albumsTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.albumsTextbox.Location = new System.Drawing.Point(3, 3);
            this.albumsTextbox.Multiline = true;
            this.albumsTextbox.Name = "albumsTextbox";
            this.albumsTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.albumsTextbox.Size = new System.Drawing.Size(296, 168);
            this.albumsTextbox.TabIndex = 0;
            this.albumsTextbox.TextChanged += new System.EventHandler(this.albumsTextbox_TextChanged);
            // 
            // directoriesTab
            // 
            this.directoriesTab.Controls.Add(this.directoriesTb);
            this.directoriesTab.Controls.Add(this.whitelistBlacklistDirsGB);
            this.directoriesTab.Location = new System.Drawing.Point(4, 22);
            this.directoriesTab.Name = "directoriesTab";
            this.directoriesTab.Padding = new System.Windows.Forms.Padding(3);
            this.directoriesTab.Size = new System.Drawing.Size(302, 174);
            this.directoriesTab.TabIndex = 2;
            this.directoriesTab.Text = "Directories";
            this.directoriesTab.UseVisualStyleBackColor = true;
            // 
            // directoriesTb
            // 
            this.directoriesTb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoriesTb.Location = new System.Drawing.Point(6, 41);
            this.directoriesTb.Multiline = true;
            this.directoriesTb.Name = "directoriesTb";
            this.directoriesTb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.directoriesTb.Size = new System.Drawing.Size(290, 130);
            this.directoriesTb.TabIndex = 1;
            this.directoriesTb.TextChanged += new System.EventHandler(this.directoriesTb_TextChanged);
            // 
            // whitelistBlacklistDirsGB
            // 
            this.whitelistBlacklistDirsGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.whitelistBlacklistDirsGB.Controls.Add(this.blacklistDirsRB);
            this.whitelistBlacklistDirsGB.Controls.Add(this.whitelistDirsRB);
            this.whitelistBlacklistDirsGB.Location = new System.Drawing.Point(6, 6);
            this.whitelistBlacklistDirsGB.Name = "whitelistBlacklistDirsGB";
            this.whitelistBlacklistDirsGB.Size = new System.Drawing.Size(290, 36);
            this.whitelistBlacklistDirsGB.TabIndex = 0;
            this.whitelistBlacklistDirsGB.TabStop = false;
            // 
            // blacklistDirsRB
            // 
            this.blacklistDirsRB.AutoSize = true;
            this.blacklistDirsRB.Checked = true;
            this.blacklistDirsRB.Location = new System.Drawing.Point(120, 12);
            this.blacklistDirsRB.Name = "blacklistDirsRB";
            this.blacklistDirsRB.Size = new System.Drawing.Size(64, 17);
            this.blacklistDirsRB.TabIndex = 1;
            this.blacklistDirsRB.TabStop = true;
            this.blacklistDirsRB.Text = "Blacklist";
            this.blacklistDirsRB.UseVisualStyleBackColor = true;
            this.blacklistDirsRB.CheckedChanged += new System.EventHandler(this.blacklistDirsRB_CheckedChanged);
            // 
            // whitelistDirsRB
            // 
            this.whitelistDirsRB.AutoSize = true;
            this.whitelistDirsRB.Location = new System.Drawing.Point(6, 12);
            this.whitelistDirsRB.Name = "whitelistDirsRB";
            this.whitelistDirsRB.Size = new System.Drawing.Size(65, 17);
            this.whitelistDirsRB.TabIndex = 0;
            this.whitelistDirsRB.Text = "Whitelist";
            this.whitelistDirsRB.UseVisualStyleBackColor = true;
            this.whitelistDirsRB.CheckedChanged += new System.EventHandler(this.whitelistDirsRB_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bitratePicker);
            this.groupBox1.Controls.Add(this.cbBitrate);
            this.groupBox1.Controls.Add(this.cbFilterLive);
            this.groupBox1.Controls.Add(this.cbFilterRemix);
            this.groupBox1.Location = new System.Drawing.Point(2, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 71);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "kbps";
            // 
            // bitratePicker
            // 
            this.bitratePicker.Location = new System.Drawing.Point(130, 41);
            this.bitratePicker.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.bitratePicker.Name = "bitratePicker";
            this.bitratePicker.Size = new System.Drawing.Size(66, 20);
            this.bitratePicker.TabIndex = 5;
            this.bitratePicker.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bitratePicker.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.bitratePicker.ValueChanged += new System.EventHandler(this.bitratePicker_ValueChanged);
            // 
            // cbBitrate
            // 
            this.cbBitrate.AutoSize = true;
            this.cbBitrate.Location = new System.Drawing.Point(10, 42);
            this.cbBitrate.Name = "cbBitrate";
            this.cbBitrate.Size = new System.Drawing.Size(114, 17);
            this.cbBitrate.TabIndex = 4;
            this.cbBitrate.Text = "Use minimal bitrate";
            this.cbBitrate.UseVisualStyleBackColor = true;
            this.cbBitrate.CheckedChanged += new System.EventHandler(this.cbBitrate_CheckedChanged);
            // 
            // cbFilterLive
            // 
            this.cbFilterLive.AutoSize = true;
            this.cbFilterLive.Location = new System.Drawing.Point(10, 19);
            this.cbFilterLive.Name = "cbFilterLive";
            this.cbFilterLive.Size = new System.Drawing.Size(91, 17);
            this.cbFilterLive.TabIndex = 2;
            this.cbFilterLive.Text = "No live tracks";
            this.cbFilterLive.UseVisualStyleBackColor = true;
            this.cbFilterLive.CheckedChanged += new System.EventHandler(this.cbFilterLive_CheckedChanged);
            // 
            // cbFilterRemix
            // 
            this.cbFilterRemix.AutoSize = true;
            this.cbFilterRemix.Location = new System.Drawing.Point(131, 19);
            this.cbFilterRemix.Name = "cbFilterRemix";
            this.cbFilterRemix.Size = new System.Drawing.Size(78, 17);
            this.cbFilterRemix.TabIndex = 3;
            this.cbFilterRemix.Text = "No remixes";
            this.cbFilterRemix.UseVisualStyleBackColor = true;
            this.cbFilterRemix.CheckedChanged += new System.EventHandler(this.cbFilterRemix_CheckedChanged);
            // 
            // outputTextbox
            // 
            this.outputTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextbox.Location = new System.Drawing.Point(2, 320);
            this.outputTextbox.Name = "outputTextbox";
            this.outputTextbox.ReadOnly = true;
            this.outputTextbox.Size = new System.Drawing.Size(310, 20);
            this.outputTextbox.TabIndex = 5;
            this.outputTextbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OutputTextbox_MouseClick);
            // 
            // FilterGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 343);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.existingStringTextbox);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.outputTextbox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FilterGenerator";
            this.Text = "Foobar2000 filter generator";
            this.tabControl1.ResumeLayout(false);
            this.artistsTab.ResumeLayout(false);
            this.artistsTab.PerformLayout();
            this.albumsTab.ResumeLayout(false);
            this.albumsTab.PerformLayout();
            this.directoriesTab.ResumeLayout(false);
            this.directoriesTab.PerformLayout();
            this.whitelistBlacklistDirsGB.ResumeLayout(false);
            this.whitelistBlacklistDirsGB.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bitratePicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox artistsTextbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown bitratePicker;
        private System.Windows.Forms.CheckBox cbBitrate;
        private System.Windows.Forms.CheckBox cbFilterLive;
        private System.Windows.Forms.CheckBox cbFilterRemix;
        private System.Windows.Forms.TextBox outputTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox existingStringTextbox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage artistsTab;
        private System.Windows.Forms.TabPage albumsTab;
        private System.Windows.Forms.TextBox albumsTextbox;
        private System.Windows.Forms.TabPage directoriesTab;
        private System.Windows.Forms.TextBox directoriesTb;
        private System.Windows.Forms.GroupBox whitelistBlacklistDirsGB;
        private System.Windows.Forms.RadioButton blacklistDirsRB;
        private System.Windows.Forms.RadioButton whitelistDirsRB;

    }
}

