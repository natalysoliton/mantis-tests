using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace mantis_tests
{

    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetup]

        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
               

        }
        public AccountCreationTests()
        {


            [Test]
            public void TestAccountRegistration()
            {
                AccountData account = new AccountData();
                Name = "testuser";
                PasswordDeriveBytes = "password";
                Email = "testuser@localhost.localdomain";
            };

            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);
        }
        [TestFixtureTearDown]
        public void restoreConfig();
        {
        app.Ftp.RestoreBackupFile("");
        }
}
