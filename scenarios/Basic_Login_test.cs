using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using experitestClient;

namespace Experitest
{
    [TestClass]
    public class BasicLogintest
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
            client.SetReporter("xml", "reports", "BasicLogintest");
        }

        [TestMethod]
        public void TestBasicLogintest()
        {
            client.SetDevice("adb:GT-I9195");
            client.ApplicationClearData("org.wundercar.android");
            client.Click("NATIVE", "xpath=//*[@text='Wunder']", 0, 1);
            if(client.WaitForElement("NATIVE", "xpath=//*[@text='Log in']", 0, 10000))
            {
                  // If statement
            }
            client.Click("default", "Log in", 0, 1);
            if(client.WaitForElement("NATIVE", "xpath=//*[@id='email']", 0, 10000))
            {
                  // If statement
            }
            client.Click("NATIVE", "xpath=//*[@id='email']", 0, 1);
            client.ElementSendText("NATIVE", "xpath=//*[@id='email']", 0, "tester+hamburg@wunder.org");
            client.Click("NATIVE", "xpath=//*[@id='password']", 0, 1);
            client.SendText("sharetest");
            client.CloseKeyboard();
            client.Click("NATIVE", "xpath=//*[@id='cta']", 0, 1);
            if(client.WaitForElement("NATIVE", "xpath=//*[@text='Account']", 0, 10000))
            {
                  // If statement
            }
            client.StartMultiGesture("");
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