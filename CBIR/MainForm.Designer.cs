namespace CBIR
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
            this.button1 = new System.Windows.Forms.Button();
            this.queryImagePictureBox = new System.Windows.Forms.PictureBox();
            this.mostSimilarImagePictureBox = new System.Windows.Forms.PictureBox();
            this.panel = new System.Windows.Forms.FlowLayoutPanel();
            this.resultsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pathLabel = new System.Windows.Forms.Label();
            this.changeFolderButton = new System.Windows.Forms.Button();
            this.similarityProgressBar = new System.Windows.Forms.ProgressBar();
            this.similarityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.queryImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostSimilarImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // queryImagePictureBox
            // 
            this.queryImagePictureBox.Location = new System.Drawing.Point(12, 87);
            this.queryImagePictureBox.Name = "queryImagePictureBox";
            this.queryImagePictureBox.Size = new System.Drawing.Size(271, 230);
            this.queryImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.queryImagePictureBox.TabIndex = 1;
            this.queryImagePictureBox.TabStop = false;
            // 
            // mostSimilarImagePictureBox
            // 
            this.mostSimilarImagePictureBox.Location = new System.Drawing.Point(289, 87);
            this.mostSimilarImagePictureBox.Name = "mostSimilarImagePictureBox";
            this.mostSimilarImagePictureBox.Size = new System.Drawing.Size(308, 230);
            this.mostSimilarImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mostSimilarImagePictureBox.TabIndex = 2;
            this.mostSimilarImagePictureBox.TabStop = false;
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(137, 6);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(460, 62);
            this.panel.TabIndex = 3;
            // 
            // resultsPanel
            // 
            this.resultsPanel.Location = new System.Drawing.Point(12, 323);
            this.resultsPanel.Name = "resultsPanel";
            this.resultsPanel.Size = new System.Drawing.Size(585, 139);
            this.resultsPanel.TabIndex = 4;
            // 
            // pathLabel
            // 
            this.pathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(171, 71);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(28, 13);
            this.pathLabel.TabIndex = 7;
            this.pathLabel.Text = "path";
            // 
            // changeFolderButton
            // 
            this.changeFolderButton.Location = new System.Drawing.Point(12, 6);
            this.changeFolderButton.Name = "changeFolderButton";
            this.changeFolderButton.Size = new System.Drawing.Size(119, 23);
            this.changeFolderButton.TabIndex = 8;
            this.changeFolderButton.Text = "Change folder";
            this.changeFolderButton.UseVisualStyleBackColor = true;
            this.changeFolderButton.Click += new System.EventHandler(this.changeFolderButton_Click);
            // 
            // similarityProgressBar
            // 
            this.similarityProgressBar.Location = new System.Drawing.Point(12, 61);
            this.similarityProgressBar.Name = "similarityProgressBar";
            this.similarityProgressBar.Size = new System.Drawing.Size(87, 23);
            this.similarityProgressBar.TabIndex = 9;
            // 
            // similarityLabel
            // 
            this.similarityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.similarityLabel.Location = new System.Drawing.Point(105, 61);
            this.similarityLabel.Name = "similarityLabel";
            this.similarityLabel.Size = new System.Drawing.Size(41, 23);
            this.similarityLabel.TabIndex = 10;
            this.similarityLabel.Text = "99%";
            this.similarityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 471);
            this.Controls.Add(this.similarityLabel);
            this.Controls.Add(this.similarityProgressBar);
            this.Controls.Add(this.changeFolderButton);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.resultsPanel);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.mostSimilarImagePictureBox);
            this.Controls.Add(this.queryImagePictureBox);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Content-based Image Retrieval";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.queryImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostSimilarImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox queryImagePictureBox;
        private System.Windows.Forms.PictureBox mostSimilarImagePictureBox;
        private System.Windows.Forms.FlowLayoutPanel panel;
        private System.Windows.Forms.FlowLayoutPanel resultsPanel;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Button changeFolderButton;
        private System.Windows.Forms.ProgressBar similarityProgressBar;
        private System.Windows.Forms.Label similarityLabel;
    }
}

