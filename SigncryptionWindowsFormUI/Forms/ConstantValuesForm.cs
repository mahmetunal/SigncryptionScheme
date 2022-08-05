using System;
using System.Collections.Generic;
using System.Text;

namespace SigncryptionProposed.Forms
{
    public static class ConstantValuesForm
    {
        /// <summary>
        /// Constant Values for main form page 
        /// </summary>
        public static string ProducedLabelText = "Produced by Mahmut Ahmet Unal - King\'s College London MSc Cyber Security";
        public static string ComparisonLabelTextMainPage = "You can compare this signcryption scheme\n " +
            "with the Sdss1 and Sdss2 schemes\n" +
            "by clicking the button below";
        public static string MainPageHeader = "Signcryption Proposed";
        public static string ComparisonButtonTextMainPage = "Make a Comparison";
        public static string ExecutionButtonTextMainPage = "See Execution Times";
        public static string ExecutionLabelTextMainPage = "You can compare the execution times of proposed\n " +
            "signcryption scheme for each execution\n" +
            "by clicking the button below";
        /// <summary>
        /// Constant values for plot form page
        /// </summary>
        public static string PlotFormHeaderText = "Signcryption Proposed - Comparison with Sdss1 and Sdss2";
        public static string PlotFormHeaderTextChanged = "It could take a while...";
        public static string GoBackButtonTextPlotForm = "Go Back to Main Page";
        public static string LabelFileSizeText = "File Size (kb)";
        public static string labelTimeText = "T\ni\nm\ne\n(ms)";
        public static string CreateScatterGraphButtonText = "Create Scatter Graph";
        public static string CreateBarGraphButtonText = "Create Bar Graph";
        public static string labelProposedText = "Proposed";
        public static string labelSdss1Text = "SDSS1";
        public static string labelSdss2Text = "SDSS2";
        /// <summary>
        /// Constant values for plot form proposed page
        /// </summary>
        public static string PlotFormProposedHeaderText = "Signcryption Proposed - Execution Times";
        public static string PlotFormProposedHeaderTextChanged = "It could take a while...";
        public static string CompareExecutionTimesSeperately = "Make It";
        public static string labelFullExecutionTime = "Full execution Time";
        public static string labelSigncryptionPhase = "Signcryption Phase";
        public static string labelUnsigncryptionPhase = "Unsigncryption Phase";

        public static string randomNumberP = "P:";
        public static string randomNumberQ = "Q:";
        public static string randomNumberN = "N:";
        public static string randomnumberG = "G:";
        public static string senderPublicKey = "Sender PK:";
        public static string receiverPublicKey = "Receiver PK:";

        /// <summary>
        /// Common Values
        /// </summary>
        public static string[] groupNamesForBarGraph = { "5kb", "32kb", "105kb", "147kb", "313kb", "411kb", "606kb", "811kb",
                "928kb", "1055kb", "10394kb"};
        public static int LoopCount = 2;

        /// <summary>
        /// Message Box Common Strings
        /// </summary>
        public static string InfoMessageText = "This program signcrypts and then unsigncrypts all txt files in the Datasets folder. Also, " +
            "do not forget to arrange loop cpunt as processing it could take time.";
        public static string InfoMessageHeader = "Information";
    }
}
