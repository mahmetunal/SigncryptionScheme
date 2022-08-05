using System;
using System.Collections.Generic;
using SigncryptionProposed;
using SigncryptionProposed.Signcryption.Participants.Sender;
using SigncryptionProposed.Signcryption.Participants.Receiver;
using SigncryptionProposed.SDSS1.Participants.Receiver;
using SigncryptionProposed.SDSS1.Participants.Sender;
using SigncryptionProposed.SDSS2.Participants.Receiver;
using SigncryptionProposed.SDSS2.Participants.Sender;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SigncryptionProposed
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainPageForm.Instance());
            

            

            string message = "Hello World I am the king of encryption";
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + @"\Datasets";
            string[] filesList = Directory.GetFiles(projectDirectory);

            /*
            foreach (string s in filesList)
            {
                ExecuteSigncryptionSDSS1(message);
                ExecuteSigncryptionSDSS2(message);
            }
            */


            foreach (string s in filesList)
            {
                string messageEncryptable = File.ReadAllText(s);
                Console.WriteLine("File: {0}", s.Replace(projectDirectory, ""));
                ExecuteSigncryption(messageEncryptable);
            }

        }

        private static void ExecuteSigncryptionSDSS1(string message)
        {

            ReceiverSDSS1 BobSDSS1 = new ReceiverSDSS1();
            SenderSDSS1 AliceSDSS1 = new SenderSDSS1();

            Dictionary<string, byte[]> signcryptValuesSDSS1 = AliceSDSS1.MessageSigncryption(message, BobSDSS1.GetPublicKey());
            bool errorStatusSDSS1 = BobSDSS1.MessageUnsigncryption(signcryptValuesSDSS1, AliceSDSS1.GetPublicKey(), out string _message);
            //Console.WriteLine("SDSS1: Is message the same?: {0} \nmessage: {1}", errorStatusSDSS1, _message);
            Console.WriteLine("SDSS1: Is message the same?: {0}", errorStatusSDSS1);
        }

        private static void ExecuteSigncryptionSDSS2(string message)
        {

            ReceiverSDSS1 BobSDSS2 = new ReceiverSDSS1();
            SenderSDSS1 AliceSDSS2 = new SenderSDSS1();

            Dictionary<string, byte[]> signcryptValuesSDSS2 = AliceSDSS2.MessageSigncryption(message, BobSDSS2.GetPublicKey());
            bool errorStatusSDSS1 = BobSDSS2.MessageUnsigncryption(signcryptValuesSDSS2, AliceSDSS2.GetPublicKey(), out string _message);
            Console.WriteLine("SDSS2: Is message the same?: {0}", errorStatusSDSS1);
        }

        private static void ExecuteSigncryption(string message)
        {
            string _message;
            long timeDifference;

            bool errorStatus = false;
            bool errorStatusSDSS1 = false;
            bool errorStatusSDSS2 = false;
            List<long> timeDifferencelistProp = new List<long>();
            List<long> timeDifferencelist1 = new List<long>();
            List<long> timeDifferencelist2 = new List<long>();


            for (int i = 0; i <= 100; i++)
            {
                do
                {
                    timeDifference = Computation.GetTimeStamp();
                    Receiver Bob = new Receiver();
                    Sender Alice = new Sender();
                    try
                    {
                        Dictionary<string, byte[]> signcryptValues = Alice.MessageSigncryption(message, Bob.GetPublicKey());
                        errorStatus = Bob.MessageUnsigncryption(signcryptValues, out _message);
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
                    ReceiverSDSS1 BobSDSS1 = new ReceiverSDSS1();
                    SenderSDSS1 AliceSDSS1 = new SenderSDSS1();
                    try
                    {
                        Dictionary<string, byte[]> signcryptValuesSDSS1 = AliceSDSS1.MessageSigncryption(message, BobSDSS1.GetPublicKey());
                        errorStatusSDSS1 = BobSDSS1.MessageUnsigncryption(signcryptValuesSDSS1, AliceSDSS1.GetPublicKey(), out _message);
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
                    ReceiverSDSS2 BobSDSS2 = new ReceiverSDSS2();
                    SenderSDSS2 AliceSDSS2 = new SenderSDSS2();
                    try
                    {
                        Dictionary<string, byte[]> signcryptValuesSDSS2 = AliceSDSS2.MessageSigncryption(message, BobSDSS2.GetPublicKey());
                        errorStatusSDSS2 = BobSDSS2.MessageUnsigncryption(signcryptValuesSDSS2, AliceSDSS2.GetPublicKey(), out _message);
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
            long totalSdss1 = timeDifferencelist1.Sum() / timeDifferencelistProp.Count;
            long totalSdss2 = timeDifferencelist2.Sum() / timeDifferencelistProp.Count;
            /**
            timeDifferencelist2.Sort();
            timeDifferencelist1.Sort();
            timeDifferencelistProp.Sort();
            */

            Console.WriteLine("Time difference for Signcryption Proposed: {0}", totalProp);
            Console.WriteLine("Time difference for SDSS1: {0}", totalSdss1);
            Console.WriteLine("Time difference for SDSS2: {0}", totalSdss2);
        }
    }
}
