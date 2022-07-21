using System;
using System.Collections.Generic;
using SigncryptionScheme;
using SigncryptionScheme.Signcryption.Participants.Sender;
using SigncryptionScheme.Signcryption.Participants.Receiver;
using SigncryptionScheme.SDSS1.Participants.Receiver;
using SigncryptionScheme.SDSS1.Participants.Sender;
using SigncryptionScheme.SDSS2.Participants.Receiver;
using SigncryptionScheme.SDSS2.Participants.Sender;
using System.IO;

namespace ProposedSigncryption
{
    class ProposedSigncryption
    {
        public static void Main(string[] args)
        {
            
            //string message = "Hello World I am the king of encryption";
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName+@"\Datasets";
            string[] filesList = Directory.GetFiles(projectDirectory);
            
            foreach(string s in filesList)
            {
                string messageEncryptable = File.ReadAllText(s);
                Console.WriteLine("File: {0}", s.Replace(projectDirectory, ""));
                ExecuteSigncryption(messageEncryptable);
            }
        }

        private static void ExecuteSigncryption(string message)
        {
            string _message;
            long timeDifference;

            bool errorStatus = false;
            bool errorStatusSDSS1 = false;
            bool errorStatusSDSS2 = false;

            do
            {
                timeDifference = Computation.GetTimeStamp();
                Receiver Bob = new Receiver();
                Sender Alice = new Sender();
                Dictionary<string, byte[]> signcryptValues = Alice.MessageSigncryption(message, Bob.GetPublicKey());
                errorStatus = Bob.MessageUnsigncryption(signcryptValues, out _message);
            } while (!errorStatus);

            timeDifference = Computation.GetTimeStamp() - timeDifference;         

            Console.WriteLine("Time difference for Signcryption Proposed: {0}", timeDifference);

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

            Console.WriteLine("Time difference for SDSS1: {0}", timeDifference);

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

            Console.WriteLine("Time difference for SDSS2: {0}", timeDifference);
        }
    }
}
