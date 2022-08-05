
namespace SigncryptionProposed.Forms
{
    partial class PlotFormExecution
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlotFormExecution));
            this.barGraphButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.secondInfo = new System.Windows.Forms.Label();
            this.fileSizeInfo = new System.Windows.Forms.Label();
            this.kclLogo = new System.Windows.Forms.PictureBox();
            this.btnGoBackToMainPage = new System.Windows.Forms.Button();
            this.exeComparisonPlot = new ScottPlot.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)(this.kclLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // barGraphButton
            // 
            this.barGraphButton.BackColor = System.Drawing.Color.Firebrick;
            this.barGraphButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.barGraphButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.barGraphButton.Location = new System.Drawing.Point(201, 599);
            this.barGraphButton.Name = "barGraphButton";
            this.barGraphButton.Size = new System.Drawing.Size(187, 53);
            this.barGraphButton.TabIndex = 18;
            this.barGraphButton.Text = "Create Bar Graph";
            this.barGraphButton.UseVisualStyleBackColor = false;
            this.barGraphButton.Click += new System.EventHandler(this.barGraphButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.ForeColor = System.Drawing.Color.Firebrick;
            this.progressBar.Location = new System.Drawing.Point(0, 678);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(859, 29);
            this.progressBar.TabIndex = 17;
            this.progressBar.Visible = false;
            // 
            // secondInfo
            // 
            this.secondInfo.AutoSize = true;
            this.secondInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secondInfo.Location = new System.Drawing.Point(26, 284);
            this.secondInfo.Margin = new System.Windows.Forms.Padding(0);
            this.secondInfo.Name = "secondInfo";
            this.secondInfo.Size = new System.Drawing.Size(48, 125);
            this.secondInfo.TabIndex = 16;
            this.secondInfo.Text = "T\ni\nm\ne\n(ms)";
            this.secondInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fileSizeInfo
            // 
            this.fileSizeInfo.AutoSize = true;
            this.fileSizeInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileSizeInfo.Location = new System.Drawing.Point(378, 121);
            this.fileSizeInfo.Name = "fileSizeInfo";
            this.fileSizeInfo.Size = new System.Drawing.Size(121, 28);
            this.fileSizeInfo.TabIndex = 15;
            this.fileSizeInfo.Text = "File Size (kb)";
            // 
            // kclLogo
            // 
            this.kclLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kclLogo.BackgroundImage")));
            this.kclLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.kclLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.kclLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("kclLogo.InitialImage")));
            this.kclLogo.Location = new System.Drawing.Point(0, 0);
            this.kclLogo.Name = "kclLogo";
            this.kclLogo.Size = new System.Drawing.Size(859, 107);
            this.kclLogo.TabIndex = 14;
            this.kclLogo.TabStop = false;
            // 
            // btnGoBackToMainPage
            // 
            this.btnGoBackToMainPage.BackColor = System.Drawing.Color.Firebrick;
            this.btnGoBackToMainPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGoBackToMainPage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGoBackToMainPage.Location = new System.Drawing.Point(452, 599);
            this.btnGoBackToMainPage.Name = "btnGoBackToMainPage";
            this.btnGoBackToMainPage.Size = new System.Drawing.Size(187, 53);
            this.btnGoBackToMainPage.TabIndex = 13;
            this.btnGoBackToMainPage.Text = "Go Back to Main Page";
            this.btnGoBackToMainPage.UseVisualStyleBackColor = false;
            this.btnGoBackToMainPage.Click += new System.EventHandler(this.btnGoBackToMainPage_Click);
            // 
            // exeComparisonPlot
            // 
            this.exeComparisonPlot.BackColor = System.Drawing.Color.Transparent;
            this.exeComparisonPlot.ForeColor = System.Drawing.Color.White;
            this.exeComparisonPlot.Location = new System.Drawing.Point(79, 140);
            this.exeComparisonPlot.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.exeComparisonPlot.Name = "exeComparisonPlot";
            this.exeComparisonPlot.Size = new System.Drawing.Size(693, 452);
            this.exeComparisonPlot.TabIndex = 12;
            // 
            // PlotFormExecution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 707);
            this.Controls.Add(this.barGraphButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.secondInfo);
            this.Controls.Add(this.fileSizeInfo);
            this.Controls.Add(this.kclLogo);
            this.Controls.Add(this.btnGoBackToMainPage);
            this.Controls.Add(this.exeComparisonPlot);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlotFormExecution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Signcryption Proposed - Execution Times";
            this.Load += new System.EventHandler(this.PlotFormExecution_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kclLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button barGraphButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label secondInfo;
        private System.Windows.Forms.Label fileSizeInfo;
        private System.Windows.Forms.PictureBox kclLogo;
        private System.Windows.Forms.Button btnGoBackToMainPage;
        private ScottPlot.FormsPlot exeComparisonPlot;
    }
}