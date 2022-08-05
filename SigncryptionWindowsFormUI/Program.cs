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


        }
    }
}
