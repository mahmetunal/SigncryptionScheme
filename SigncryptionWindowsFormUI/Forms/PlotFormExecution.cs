using ScottPlot;
using SigncryptionScheme;
using SigncryptionScheme.Signcryption.Participants.Receiver;
using SigncryptionScheme.Signcryption.Participants.Sender;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SigncryptionProposed.Forms
{
    public partial class PlotFormExecution : Form
    {
        public PlotFormExecution()
        {
            InitializeComponent();
        }

        private void btnGoBackToMainPage_Click(object sender, EventArgs e)
        {
            this.exeComparisonPlot.Dispose();
            MainPageForm.Instance().Show();
            this.Dispose();
        }

        private static bool ExecuteSigncryptionProposed(string message)
        {
            Receiver Bob = new Receiver();
            Sender Alice = new Sender();

            Dictionary<string, byte[]> signcryptValues = Alice.MessageSigncryption(message, Bob.GetPublicKey());
            return Bob.MessageUnsigncryption(signcryptValues, out string _message);
        }

        private List<List<double>> ExecuteSigncryption()
        {
            var ProgressBar = this.progressBar;
            this.Text = ConstantValuesForm.PlotFormProposedHeaderTextChanged;
            var ComparisonPlot = this.exeComparisonPlot;

            ProgressBar.Visible = true;
            ComparisonPlot.Reset();

            long timeDifferenceFull;
            long timeDifferenceSign = 0;
            long timeDifferenceUnsign = 0;
            List<double> timeDiffFullExec = new List<double>();
            List<double> timeDiffSign = new List<double>();
            List<double> timeDiffUnsign = new List<double>();

            List<long> timeDifferencelistPropFullExec = new List<long>();
            List<long> timeDifferencelistSigncryption = new List<long>();
            List<long> timeDifferencelistUnsigncryption = new List<long>();

            List<List<double>> resultList = new List<List<double>>();

            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + @"\Datasets";
            string[] filesList = Directory.GetFiles(projectDirectory);

            ProgressBar.Minimum = 1;
            ProgressBar.Maximum = filesList.Length;
            ProgressBar.Value = 1;
            ProgressBar.Step = 1;

            foreach (string s in filesList)
            {
                string message = File.ReadAllText(s);
                for (int i = 0; i <= ConstantValuesForm.LoopCount; i++)
                {

                    bool errorStatus = false;

                    timeDifferenceFull = Computation.GetTimeStamp();
                    Receiver Bob = new Receiver();
                    Sender Alice = new Sender();
                    timeDifferenceSign = Computation.GetTimeStamp();

                    Dictionary<string, byte[]> signcryptValues = Alice.MessageSigncryption(message, Bob.GetPublicKey());
                    timeDifferenceSign = Computation.GetTimeStamp() - timeDifferenceSign;

                    timeDifferenceUnsign = Computation.GetTimeStamp();
                    errorStatus = Bob.MessageUnsigncryption(signcryptValues, out string _message);
                    timeDifferenceUnsign = Computation.GetTimeStamp() - timeDifferenceUnsign;

                    timeDifferenceFull = Computation.GetTimeStamp() - timeDifferenceFull;

                    timeDifferencelistPropFullExec.Add(timeDifferenceFull);
                    timeDifferencelistSigncryption.Add(timeDifferenceSign);
                    timeDifferencelistUnsigncryption.Add(timeDifferenceUnsign);
                }

                long totalProp = timeDifferencelistPropFullExec.Sum() / timeDifferencelistPropFullExec.Count;
                long totalSignExec = timeDifferencelistSigncryption.Sum() / timeDifferencelistSigncryption.Count;
                long totalUnsignExec = timeDifferencelistUnsigncryption.Sum() / timeDifferencelistUnsigncryption.Count;

                timeDiffFullExec.Add((double)totalProp / 10000);
                timeDiffSign.Add((double)totalSignExec / 10000);
                timeDiffUnsign.Add((double)totalUnsignExec / 10000);

                ProgressBar.PerformStep();
            }

            resultList.Add(timeDiffFullExec);
            resultList.Add(timeDiffSign);
            resultList.Add(timeDiffUnsign);

            this.Text = ConstantValuesForm.PlotFormProposedHeaderText;
            ProgressBar.Value = 1;
            ProgressBar.Visible = false;

            return resultList;
        }

        private void PlotFormExecution_Load(object sender, EventArgs e)
        {

        }

        private void barGraphButton_Click(object sender, EventArgs e)
        {
            List<List<double>> TimeListArray = ExecuteSigncryption();

            string[] seriesNames = { ConstantValuesForm.labelFullExecutionTime, ConstantValuesForm.labelSigncryptionPhase, ConstantValuesForm.labelUnsigncryptionPhase };

            double[] signcryptionProposedArray = TimeListArray[0].ToArray();
            double[] signcryptionPhaseArray = TimeListArray[1].ToArray();
            double[] unsigncryptionPhaseArray = TimeListArray[2].ToArray();

            double[] errorSeries = new double[11];

            double[][] valuesBySeries = { signcryptionProposedArray, signcryptionPhaseArray, unsigncryptionPhaseArray };
            double[][] errorsBySeries = { errorSeries, errorSeries, errorSeries };

            exeComparisonPlot.Plot.AddBarGroups(ConstantValuesForm.groupNamesForBarGraph, seriesNames, valuesBySeries, errorsBySeries);
            exeComparisonPlot.Plot.Legend(location: Alignment.UpperRight);

            exeComparisonPlot.Plot.SetAxisLimits(yMin: 0);
            exeComparisonPlot.Refresh();
        }
    }
}
