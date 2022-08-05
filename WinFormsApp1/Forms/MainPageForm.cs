using SigncryptionProposed.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SigncryptionProposed
{
    public partial class MainPageForm : Form
    {
        static MainPageForm mainPageFormInstance;

        public MainPageForm()
        {
            InitializeComponent();
        }

        public static MainPageForm Instance()
        {
            if (mainPageFormInstance == null)
            {
                mainPageFormInstance = new MainPageForm();
            }
            return mainPageFormInstance;
        }

        private void btnShowInformation_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(ConstantValuesForm.InfoMessageText, ConstantValuesForm.InfoMessageHeader, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            
            if(result == DialogResult.OK)
            {
                PlotFormProposed plotForm = new PlotFormProposed();
                plotForm.Show(this);
                this.Hide();
            }
            
        }

        private void executionTimeButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(ConstantValuesForm.InfoMessageText, ConstantValuesForm.InfoMessageHeader, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(result == DialogResult.OK)
            {
                PlotFormExecution plotFormExecution = new PlotFormExecution();
                plotFormExecution.Show(this);
                this.Hide();
            }

        }

        private void loopCount_ValueChanged(object sender, EventArgs e)
        {
            ConstantValuesForm.LoopCount = (int)this.loopCount.Value;
        }
    }
}
