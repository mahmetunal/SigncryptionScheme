using ScottPlot;
using SigncryptionScheme;
using SigncryptionScheme.SDSS1.Participants.Receiver;
using SigncryptionScheme.SDSS1.Participants.Sender;
using SigncryptionScheme.Signcryption.Participants.Receiver;
using SigncryptionScheme.Signcryption.Participants.Sender;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SigncryptionProposed.Forms
{
    public partial class PlotFormProposed : Form
    {   
        public PlotFormProposed()
        {
            InitializeComponent();
        }

        private void btnGoBackToMainPage_Click(object sender, EventArgs e)
        {
            this.comparisonPlot.Dispose();
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

        private static bool ExecuteSigncryptionSDSS1(string message)
        {

            ReceiverSDSS1 BobSDSS1 = new ReceiverSDSS1();
            SenderSDSS1 AliceSDSS1 = new SenderSDSS1();

            Dictionary<string, byte[]> signcryptValuesSDSS1 = AliceSDSS1.MessageSigncryption(message, BobSDSS1.GetPublicKey());
            return BobSDSS1.MessageUnsigncryption(signcryptValuesSDSS1, AliceSDSS1.GetPublicKey(), out string _message);
        }

        private static bool ExecuteSigncryptionSDSS2(string message)
        {

            ReceiverSDSS1 BobSDSS2 = new ReceiverSDSS1();
            SenderSDSS1 AliceSDSS2 = new SenderSDSS1();

            Dictionary<string, byte[]> signcryptValuesSDSS2 = AliceSDSS2.MessageSigncryption(message, BobSDSS2.GetPublicKey());
            return BobSDSS2.MessageUnsigncryption(signcryptValuesSDSS2, AliceSDSS2.GetPublicKey(), out string _message);
        }

        private List<List<double>> ExecuteSigncryption()
        {
            var ProgressBar = this.progressBar;
            var Header = this.Text = ConstantValuesForm.PlotFormHeaderTextChanged;
            var ComparisonPlot = this.comparisonPlot;

            ProgressBar.Visible = true;
            ComparisonPlot.Reset();

            long timeDifference;

            bool errorStatus = false;
            bool errorStatusSDSS1 = false;
            bool errorStatusSDSS2 = false;

            List<double> timeDiffProp = new List<double>();
            List<double> timeDiffSdss1 = new List<double>();
            List<double> timeDiffSdss2 = new List<double>();

            List<long> timeDifferencelistProp = new List<long>();
            List<long> timeDifferencelist1 = new List<long>();
            List<long> timeDifferencelist2 = new List<long>();

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
                    do
                    {
                        timeDifference = Computation.GetTimeStamp();
                        try
                        {
                            errorStatus = ExecuteSigncryptionProposed(message);
                        }
                        catch
                        {
                            errorStatus = false;
                        }

                    } while (!errorStatus);

                    timeDifference = Computation.GetTimeStamp() - timeDifference;
                    timeDifferencelistProp.Add(timeDifference);

                    do
                    {

                        timeDifference = Computation.GetTimeStamp();

                        try
                        {
                            errorStatusSDSS1 = ExecuteSigncryptionSDSS1(message);                        
                        }
                        catch
                        {
                            errorStatusSDSS1 = false;
                        }

                    } while (!errorStatusSDSS1);

                    timeDifference = Computation.GetTimeStamp() - timeDifference;
                    timeDifferencelist1.Add(timeDifference);

                    do
                    {
                        timeDifference = Computation.GetTimeStamp();
                        try
                        {
                            errorStatusSDSS2 = ExecuteSigncryptionSDSS2(message);
                        }
                        catch
                        {
                            errorStatusSDSS2 = false;
                        }

                    } while (!errorStatusSDSS2);

                    timeDifference = Computation.GetTimeStamp() - timeDifference;
                    timeDifferencelist2.Add(timeDifference);
                }

                long totalProp = timeDifferencelistProp.Sum() / timeDifferencelistProp.Count;
                long totalSdss1 = timeDifferencelist1.Sum() / timeDifferencelist1.Count;
                long totalSdss2 = timeDifferencelist2.Sum() / timeDifferencelist2.Count;

                timeDiffProp.Add((double)totalProp / 10000);
                timeDiffSdss1.Add((double)totalSdss1 / 10000);
                timeDiffSdss2.Add((double)totalSdss2 / 10000);

                ProgressBar.PerformStep();
            }

            resultList.Add(timeDiffProp);
            resultList.Add(timeDiffSdss1);
            resultList.Add(timeDiffSdss2);

            this.Text = ConstantValuesForm.PlotFormHeaderText;
            ProgressBar.Value = 1;
            ProgressBar.Visible = false;

            return resultList;
        }

        private void btnScatterGraph_Click(object sender, EventArgs e)
        {
            
            List<List<double>> TimeListArray = ExecuteSigncryption();

            double[] signcryptionProposedArray = TimeListArray[0].ToArray();
            double[] sdss1Array = TimeListArray[1].ToArray();
            double[] sdss2Array = TimeListArray[2].ToArray();

            double[] FileSizes = new double[] {5, 32, 105, 147, 313, 411, 606, 811, 928, 1055, 10394 };

            var sp1 = this.comparisonPlot.Plot.AddScatter(signcryptionProposedArray, FileSizes, label: ConstantValuesForm.labelProposedText);
            sp1.MarkerShape = ScottPlot.MarkerShape.openCircle;
            var sp2 = this.comparisonPlot.Plot.AddScatter(sdss1Array, FileSizes, label: ConstantValuesForm.labelSdss1Text);
            sp2.MarkerShape = ScottPlot.MarkerShape.filledSquare;
            var sp3 = this.comparisonPlot.Plot.AddScatter(sdss2Array, FileSizes, label: ConstantValuesForm.labelSdss2Text);
            sp3.MarkerShape = ScottPlot.MarkerShape.filledDiamond;
            var legend = comparisonPlot.Plot.Legend();
            comparisonPlot.Refresh();
            legend.FontSize = 10;
        }

        private void barGraphButton_Click(object sender, EventArgs e)
        {
            List<List<double>> TimeListArray = ExecuteSigncryption();
            
            string[] seriesNames = { ConstantValuesForm.labelProposedText, ConstantValuesForm.labelSdss1Text, ConstantValuesForm.labelSdss2Text };

            double[] signcryptionProposedArray = TimeListArray[0].ToArray();
            double[] sdss1Array = TimeListArray[1].ToArray();
            double[] sdss2Array = TimeListArray[2].ToArray();

            double[] errorSeries = new double[11];

            double[][] valuesBySeries = { signcryptionProposedArray, sdss1Array, sdss2Array };
            double[][] errorsBySeries = { errorSeries, errorSeries, errorSeries };

            comparisonPlot.Plot.AddBarGroups(ConstantValuesForm.groupNamesForBarGraph, seriesNames, valuesBySeries, errorsBySeries);
            comparisonPlot.Plot.Legend(location: Alignment.UpperRight);
            
            comparisonPlot.Plot.SetAxisLimits(yMin: 0);
            comparisonPlot.Refresh();

        }
    }
}
