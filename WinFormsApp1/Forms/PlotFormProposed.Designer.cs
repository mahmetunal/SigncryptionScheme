
namespace SigncryptionProposed.Forms
{
    partial class PlotFormProposed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlotFormProposed));
            this.comparisonPlot = new ScottPlot.FormsPlot();
            this.btnGoBackToMainPage = new System.Windows.Forms.Button();
            this.kclLogo = new System.Windows.Forms.PictureBox();
            this.fileSizeInfo = new System.Windows.Forms.Label();
            this.secondInfo = new System.Windows.Forms.Label();
            this.btnMakeComparison = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.barGraphButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.kclLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // comparisonPlot
            // 
            this.comparisonPlot.BackColor = System.Drawing.Color.Transparent;
            this.comparisonPlot.ForeColor = System.Drawing.Color.White;
            this.comparisonPlot.Location = new System.Drawing.Point(79, 140);
            this.comparisonPlot.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comparisonPlot.Name = "comparisonPlot";
            this.comparisonPlot.Size = new System.Drawing.Size(693, 452);
            this.comparisonPlot.TabIndex = 0;
            // 
            // btnGoBackToMainPage
            // 
            this.btnGoBackToMainPage.BackColor = System.Drawing.Color.Firebrick;
            this.btnGoBackToMainPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGoBackToMainPage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGoBackToMainPage.Location = new System.Drawing.Point(345, 600);
            this.btnGoBackToMainPage.Name = "btnGoBackToMainPage";
            this.btnGoBackToMainPage.Size = new System.Drawing.Size(187, 53);
            this.btnGoBackToMainPage.TabIndex = 1;
            this.btnGoBackToMainPage.Text = ConstantValuesForm.GoBackButtonTextPlotForm;
            this.btnGoBackToMainPage.UseVisualStyleBackColor = false;
            this.btnGoBackToMainPage.Click += new System.EventHandler(this.btnGoBackToMainPage_Click);
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
            this.kclLogo.TabIndex = 5;
            this.kclLogo.TabStop = false;
            // 
            // fileSizeInfo
            // 
            this.fileSizeInfo.AutoSize = true;
            this.fileSizeInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileSizeInfo.Location = new System.Drawing.Point(378, 121);
            this.fileSizeInfo.Name = "fileSizeInfo";
            this.fileSizeInfo.Size = new System.Drawing.Size(121, 28);
            this.fileSizeInfo.TabIndex = 6;
            this.fileSizeInfo.Text = ConstantValuesForm.LabelFileSizeText;
            // 
            // secondInfo
            // 
            this.secondInfo.AutoSize = true;
            this.secondInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secondInfo.Location = new System.Drawing.Point(26, 284);
            this.secondInfo.Margin = new System.Windows.Forms.Padding(0);
            this.secondInfo.Name = "secondInfo";
            this.secondInfo.Size = new System.Drawing.Size(48, 125);
            this.secondInfo.TabIndex = 7;
            this.secondInfo.Text = ConstantValuesForm.labelTimeText;
            this.secondInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMakeComparison
            // 
            this.btnMakeComparison.BackColor = System.Drawing.Color.Firebrick;
            this.btnMakeComparison.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMakeComparison.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMakeComparison.Location = new System.Drawing.Point(585, 600);
            this.btnMakeComparison.Name = "btnMakeComparison";
            this.btnMakeComparison.Size = new System.Drawing.Size(187, 53);
            this.btnMakeComparison.TabIndex = 9;
            this.btnMakeComparison.Text = ConstantValuesForm.CreateScatterGraphButtonText;
            this.btnMakeComparison.UseVisualStyleBackColor = false;
            this.btnMakeComparison.Click += new System.EventHandler(this.btnScatterGraph_Click);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.ForeColor = System.Drawing.Color.Firebrick;
            this.progressBar.Location = new System.Drawing.Point(0, 659);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(859, 29);
            this.progressBar.TabIndex = 10;
            this.progressBar.Visible = false;
            // 
            // barGraphButton
            // 
            this.barGraphButton.BackColor = System.Drawing.Color.Firebrick;
            this.barGraphButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.barGraphButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.barGraphButton.Location = new System.Drawing.Point(99, 600);
            this.barGraphButton.Name = "barGraphButton";
            this.barGraphButton.Size = new System.Drawing.Size(187, 53);
            this.barGraphButton.TabIndex = 11;
            this.barGraphButton.Text = ConstantValuesForm.CreateBarGraphButtonText;
            this.barGraphButton.UseVisualStyleBackColor = false;
            this.barGraphButton.Click += new System.EventHandler(this.barGraphButton_Click);
            // 
            // PlotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 688);
            this.Controls.Add(this.barGraphButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnMakeComparison);
            this.Controls.Add(this.secondInfo);
            this.Controls.Add(this.fileSizeInfo);
            this.Controls.Add(this.kclLogo);
            this.Controls.Add(this.btnGoBackToMainPage);
            this.Controls.Add(this.comparisonPlot);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ConstantValuesForm.PlotFormHeaderText;
            ((System.ComponentModel.ISupportInitialize)(this.kclLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScottPlot.FormsPlot comparisonPlot;
        private System.Windows.Forms.Button btnGoBackToMainPage;
        private System.Windows.Forms.PictureBox kclLogo;
        private System.Windows.Forms.Label fileSizeInfo;
        private System.Windows.Forms.Label secondInfo;
        private System.Windows.Forms.Button btnMakeComparison;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button barGraphButton;
    }
}