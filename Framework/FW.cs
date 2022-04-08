using Framework.Logging;
using NUnit.Framework;
using System;
using System.IO;


namespace Framework
{
    public class FW
    {
        public const string WORKSPACE_DIRECTORY = @"C:\Users\Ismail ALTAY\source\repos\Framework\";
        public static Logger Log => _logger ?? throw new NullReferenceException("Logger is null, set logger first!!");

        [ThreadStatic]
        public static DirectoryInfo CurrentTestDirectory;
        [ThreadStatic]
        private static Logger _logger;
        public static DirectoryInfo CreateTestResultsDirectory()
        {
            var testDirectory = WORKSPACE_DIRECTORY + "TestResults";

            if (Directory.Exists(testDirectory))
            {
                Directory.Delete(testDirectory, recursive: true);
            }

            return Directory.CreateDirectory(testDirectory);
        }

        public static void SetLogger()
        {
            lock (_setLoggerLock)
            {
                var testDirectory = WORKSPACE_DIRECTORY + "TestResults";
                var testName = TestContext.CurrentContext.Test.Name;
                var fullpath = $"{testDirectory}/{testName}";

                if (Directory.Exists(fullpath))
                {
                    CurrentTestDirectory = Directory.CreateDirectory(fullpath + TestContext.CurrentContext.Test.ID);
                }
                else
                {
                    CurrentTestDirectory = Directory.CreateDirectory(fullpath);
                }
                
                _logger = new Logger(testName, CurrentTestDirectory.FullName + "/log.txt");
            }

        }

        private static object _setLoggerLock = new object();
    }
}
