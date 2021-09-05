
namespace SpotifyLyrics
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SpotifyWatchDogTimer = new System.Windows.Forms.Timer(this.components);
            this.LyricBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ForceDownloadBtn = new System.Windows.Forms.Button();
            this.SongTitleEdit = new System.Windows.Forms.TextBox();
            this.ArtistEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SpotifyWatchDogTimer
            // 
            this.SpotifyWatchDogTimer.Interval = 250;
            this.SpotifyWatchDogTimer.Tick += new System.EventHandler(this.SpotifyWatchDogTimer_Tick);
            // 
            // LyricBox
            // 
            this.LyricBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LyricBox.Location = new System.Drawing.Point(12, 106);
            this.LyricBox.Multiline = true;
            this.LyricBox.Name = "LyricBox";
            this.LyricBox.ReadOnly = true;
            this.LyricBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LyricBox.Size = new System.Drawing.Size(436, 311);
            this.LyricBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ForceDownloadBtn);
            this.groupBox1.Controls.Add(this.SongTitleEdit);
            this.groupBox1.Controls.Add(this.ArtistEdit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 88);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Song";
            // 
            // ForceDownloadBtn
            // 
            this.ForceDownloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ForceDownloadBtn.FlatAppearance.BorderSize = 0;
            this.ForceDownloadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForceDownloadBtn.Location = new System.Drawing.Point(355, 22);
            this.ForceDownloadBtn.Name = "ForceDownloadBtn";
            this.ForceDownloadBtn.Size = new System.Drawing.Size(75, 52);
            this.ForceDownloadBtn.TabIndex = 4;
            this.ForceDownloadBtn.Text = "Download";
            this.ForceDownloadBtn.UseVisualStyleBackColor = true;
            this.ForceDownloadBtn.Click += new System.EventHandler(this.ForceDownloadBtn_Click);
            // 
            // SongTitleEdit
            // 
            this.SongTitleEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SongTitleEdit.Location = new System.Drawing.Point(50, 51);
            this.SongTitleEdit.Name = "SongTitleEdit";
            this.SongTitleEdit.Size = new System.Drawing.Size(299, 23);
            this.SongTitleEdit.TabIndex = 3;
            this.SongTitleEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SongTitleEdit_KeyDown);
            this.SongTitleEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SongTitleEdit_KeyPress);
            // 
            // ArtistEdit
            // 
            this.ArtistEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArtistEdit.Location = new System.Drawing.Point(50, 22);
            this.ArtistEdit.Name = "ArtistEdit";
            this.ArtistEdit.Size = new System.Drawing.Size(299, 23);
            this.ArtistEdit.TabIndex = 2;
            this.ArtistEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ArtistEdit_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Song:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Artist:";
            // 
            // MessageLabel
            // 
            this.MessageLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MessageLabel.Location = new System.Drawing.Point(0, 432);
            this.MessageLabel.Margin = new System.Windows.Forms.Padding(12);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.MessageLabel.Size = new System.Drawing.Size(460, 18);
            this.MessageLabel.TabIndex = 4;
            this.MessageLabel.Tag = "";
            this.MessageLabel.Text = "Ready";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 450);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LyricBox);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer SpotifyWatchDogTimer;
        private System.Windows.Forms.TextBox LyricBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox SongTitleEdit;
        private System.Windows.Forms.TextBox ArtistEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ForceDownloadBtn;
        private System.Windows.Forms.Label MessageLabel;
    }
}

