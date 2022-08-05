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
            PlotForm plotForm = new PlotForm();
            plotForm.Show(this);
            this.Hide();
        }

    }
}
