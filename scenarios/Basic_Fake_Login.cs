using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using experitestClient;

namespace Experitest
{
    [TestClass]
    public class BasicFakeLogin
    {
        private string host = "localhost";
        private int port = 8889;
        private string projectBaseDirectory = "C:\\Users\\Dimitri\\workspace\\project2";
        protected Client client = null;
        
        [TestInitialize()]
        public void SetupTest()
        {
            client = new Client(host, port, true);
            client.SetProjectBaseDirectory(projectBaseDirectory);
            client.SetReporter("xml", "reports", "BasicFakeLogin");
        }

        [TestMethod]
        public void TestBasicFakeLogin()
        {
            //client.SetDevice("adb:GT-I9195");
            client.ApplicationClearData("org.wundercar.android");
            client.Click("NATIVE", "xpath=//*[@text='Wunder']", 0, 1);
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='Log in']", 0);
            client.Click("NATIVE", "xpath=//*[@text='Log in']", 0, 1);
            client.Click("NATIVE", "xpath=//*[@id='email']", 0, 1);
            client.SendText("fakelogin@login.org");
            client.Click("NATIVE", "xpath=//*[@id='password']", 0, 1);
            client.SendText("fakenewslogin");
            client.CloseKeyboard();
            client.Click("NATIVE", "xpath=//*[@id='cta']", 0, 1);
        }

        [TestCleanup()]
        public void TearDown()
        {
        // Generates a report of the test case.
        // For more information - https://docs.experitest.com/display/public/SA/Report+Of+Executed+Test
        client.GenerateReport(false);
        // Releases the client so that other clients can approach the agent in the near future. 
        client.ReleaseClient();
        }
    }
}