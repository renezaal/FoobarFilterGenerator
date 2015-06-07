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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.ExistingStringTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.artistsTextbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bitratePicker = new System.Windows.Forms.NumericUpDown();
            this.cbBitrate = new System.Windows.Forms.CheckBox();
            this.cbFilterLive = new System.Windows.Forms.CheckBox();
            this.cbFilterRemix = new System.Windows.Forms.CheckBox();
            this.OutputTextbox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bitratePicker)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.ExistingStringTextbox);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.artistsTextbox);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.OutputTextbox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(284, 306);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "If you already have an existing filter, paste it here";
            // 
            // ExistingStringTextbox
            // 
            this.ExistingStringTextbox.Location = new System.Drawing.Point(3, 16);
            this.ExistingStringTextbox.Name = "ExistingStringTextbox";
            this.ExistingStringTextbox.Size = new System.Drawing.Size(269, 20);
            this.ExistingStringTextbox.TabIndex = 6;
            this.ExistingStringTextbox.TextChanged += new System.EventHandler(this.ExistingStringTextbox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Artists (One per line)";
            // 
            // artistsTextbox
            // 
            this.artistsTextbox.AcceptsReturn = true;
            this.artistsTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.artistsTextbox.Location = new System.Drawing.Point(3, 55);
            this.artistsTextbox.Multiline = true;
            this.artistsTextbox.Name = "artistsTextbox";
            this.artistsTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.artistsTextbox.Size = new System.Drawing.Size(269, 118);
            this.artistsTextbox.TabIndex = 0;
            this.artistsTextbox.WordWrap = false;
            this.artistsTextbox.TextChanged += new System.EventHandler(this.artistsTextbox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bitratePicker);
            this.groupBox1.Controls.Add(this.cbBitrate);
            this.groupBox1.Controls.Add(this.cbFilterLive);
            this.groupBox1.Controls.Add(this.cbFilterRemix);
            this.groupBox1.Location = new System.Drawing.Point(3, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "kbps";
            // 
            // bitratePicker
            // 
            this.bitratePicker.Location = new System.Drawing.Point(131, 66);
            this.bitratePicker.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.bitratePicker.Name = "bitratePicker";
            this.bitratePicker.Size = new System.Drawing.Size(66, 20);
            this.bitratePicker.TabIndex = 5;
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
            this.cbBitrate.Location = new System.Drawing.Point(10, 66);
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
            this.cbFilterRemix.Location = new System.Drawing.Point(9, 42);
            this.cbFilterRemix.Name = "cbFilterRemix";
            this.cbFilterRemix.Size = new System.Drawing.Size(78, 17);
            this.cbFilterRemix.TabIndex = 3;
            this.cbFilterRemix.Text = "No remixes";
            this.cbFilterRemix.UseVisualStyleBackColor = true;
            this.cbFilterRemix.CheckedChanged += new System.EventHandler(this.cbFilterRemix_CheckedChanged);
            // 
            // OutputTextbox
            // 
            this.OutputTextbox.Location = new System.Drawing.Point(3, 285);
            this.OutputTextbox.Name = "OutputTextbox";
            this.OutputTextbox.ReadOnly = true;
            this.OutputTextbox.Size = new System.Drawing.Size(269, 20);
            this.OutputTextbox.TabIndex = 5;
            this.OutputTextbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OutputTextbox_MouseClick);
            // 
            // FilterGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 306);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FilterGenerator";
            this.Text = "Foobar2000 filter generator";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bitratePicker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox artistsTextbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown bitratePicker;
        private System.Windows.Forms.CheckBox cbBitrate;
        private System.Windows.Forms.CheckBox cbFilterLive;
        private System.Windows.Forms.CheckBox cbFilterRemix;
        private System.Windows.Forms.TextBox OutputTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ExistingStringTextbox;

    }
}

