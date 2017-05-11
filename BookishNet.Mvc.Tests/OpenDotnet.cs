using System;
using System.Diagnostics;
using System.IO;
using Microsoft.DotNet.InternalAbstractions;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace BookishNet.Mvc.Tests
{
    [TestFixture]
    public abstract class OpenDotnet
    {
        [SetUp]
        public void TestInitialize()
        {
            // Start IISExpress
            StartDotnet();

            // Start Selenium drivers
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
        }


        [TearDown]
        public void TestCleanup()
        {
            // Ensure IISExpress is stopped
            if (_dotnetProcess.HasExited == false)
                _dotnetProcess.Kill();

            // Stop all Selenium drivers
            ChromeDriver.Quit();
        }

        private readonly string _applicationName;
        private Process _dotnetProcess;

        protected OpenDotnet(string applicationName)
        {
            _applicationName = applicationName;
        }


        protected ChromeDriver ChromeDriver { get; set; }


        private void StartDotnet()
        {
            var applicationPath = GetApplicationPath(_applicationName);
            var programFiles = Environment.GetEnvironmentVariable("ProgramFiles");

            _dotnetProcess = new Process
            {
                StartInfo =
                {
                    FileName = programFiles + "\\dotnet\\dotnet.exe",
                    Arguments = string.Format("/path:\"{0}", applicationPath)
                }
            };
            _dotnetProcess.Start();
        }


        private string GetApplicationPath(string applicationName)
        {
            var solutionFolder =
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(Path.GetDirectoryName(ApplicationEnvironment.ApplicationBasePath))));

            return Path.Combine(solutionFolder, applicationName);
        }
    }
}