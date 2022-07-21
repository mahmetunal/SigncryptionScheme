using System;
using System.Numerics;
using System.Collections.Generic;
using SigncryptionScheme;
using SigncryptionScheme.Signcryption;
using SigncryptionScheme.Computations;
using SigncryptionScheme.Signcryption.Participants;
using SigncryptionScheme.Signcryption.Participants.Sender;
using SigncryptionScheme.Signcryption.Participants.Receiver;
using SigncryptionScheme.SDSS1.Participants.Receiver;
using SigncryptionScheme.SDSS1.Participants.Sender;
using SigncryptionScheme.SDSS2.Participants.Receiver;
using SigncryptionScheme.SDSS2.Participants.Sender;

namespace ProposedSigncryption
{
    class ProposedSigncryption
    {
        public static void Main(string[] args)
        {
            string message = "Hello World I am the king of encryption";
            string original = System.IO.File.ReadAllText("../../../../Datasets/dataset32768.txt");
            original = System.IO.File.ReadAllText("../../../../Datasets/dataset4911.txt");
            //original = System.IO.File.ReadAllText("../../../../Datasets/dataset106655.txt");
            message = original;

            long timeDifference;
            string _message;

            timeDifference = Computation.GetTimeStamp();
            Receiver Bob = new Receiver();
            Sender Alice = new Sender();
            
            Dictionary<string, byte[]> signcryptValues = Alice.MessageSigncryption(message, Bob.GetPublicKey());

            
            Console.WriteLine("Is message the same: {0}", Bob.MessageUnsigncryption(signcryptValues, out _message));
            timeDifference = Computation.GetTimeStamp() - timeDifference;
            _message = "";
            Console.WriteLine("Time difference for Signcryption Proposed: {0}", timeDifference);

            timeDifference = Computation.GetTimeStamp();

            ReceiverSDSS1 BobSDSS1 = new ReceiverSDSS1();
            SenderSDSS1 AliceSDSS1 = new SenderSDSS1();

            Dictionary<string, byte[]> signcryptValuesSDSS1 = AliceSDSS1.MessageSigncryption(message, BobSDSS1.GetPublicKey());


            Console.WriteLine("Is message the same: {0}", BobSDSS1.MessageUnsigncryption(signcryptValuesSDSS1, AliceSDSS1.GetPublicKey(), out _message));
            timeDifference = Computation.GetTimeStamp() - timeDifference;

            Console.WriteLine("Time difference for SDSS1: {0}", timeDifference);

            timeDifference = Computation.GetTimeStamp();

            ReceiverSDSS2 BobSDSS2 = new ReceiverSDSS2();
            SenderSDSS2 AliceSDSS2 = new SenderSDSS2();

            Dictionary<string, byte[]> signcryptValuesSDSS2 = AliceSDSS2.MessageSigncryption(message, BobSDSS2.GetPublicKey());


            Console.WriteLine("Is message the same: {0}", BobSDSS2.MessageUnsigncryption(signcryptValuesSDSS2, AliceSDSS2.GetPublicKey(), out _message));
            timeDifference = Computation.GetTimeStamp() - timeDifference;

            Console.WriteLine("Time difference for SDSS2: {0}", timeDifference);


        }
    }
}
