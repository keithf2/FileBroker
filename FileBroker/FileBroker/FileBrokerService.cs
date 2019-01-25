#define TRACE 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FileBroker
{
    public partial class FileBrokerService : ServiceBase
    {
        private System.Timers.Timer _timer;
        public FileBrokerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _timer = new System.Timers.Timer();
            _timer.Interval = getInterval();
            _timer.Elapsed += new ElapsedEventHandler(this.Timer_ElapsedEventHandler);
            _timer.Enabled = true;
            _timer.Start();
            System.Diagnostics.Trace.WriteLine("Service Started");
            Trace.Flush();
        }

        protected override void OnStop()
        {
            _timer.Enabled = false;
            _timer.Stop();
            System.Diagnostics.Trace.WriteLine("Service Stopped");
            Trace.Flush();
        }

        private void fsWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            fsWatcher.EnableRaisingEvents = false;
            ProcessFiles();
            fsWatcher.EnableRaisingEvents = true;
        }

        private void Timer_ElapsedEventHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Enabled = false;
            _timer.Stop();
            _timer.Interval = getInterval();
            ProcessFiles();
            _timer.Enabled = true;
            _timer.Start();
        }

        private double getInterval()
        {
            double interval = 10000;

            string _interval = null;

            try
            {
                _interval = System.Configuration.ConfigurationManager.AppSettings["Broker.TimerInterval"];
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Interval is not configured:" + ex);
                Trace.Flush();
                _interval = "10000";
            }
            if (_interval != null || _interval.Length >= 0)
            {
                try
                {
                    interval = double.Parse(_interval);
                }
                catch (Exception exc)
                {
                    System.Diagnostics.Trace.WriteLine("Interval is not configured:" + exc);
                    Trace.Flush();
                    interval = 10000;
                }
            }

            System.Diagnostics.Trace.WriteLine("Interval: " + interval.ToString());
            Trace.Flush();

            return interval;
        }

        private void ProcessFiles()
        {
            //this example just moves a file from one folder to another folder.

            string filePath = "C:/incoming/";
            string filePath2 = "C:/outgoing/";

            try
            {

                if (filePath != null && filePath.Length > 0 && Directory.Exists(filePath) && filePath2 != null && filePath2.Length > 0 && Directory.Exists(filePath2))
                {
                    var txtFiles = Directory.EnumerateFiles(filePath);
                    foreach (string currentFile in txtFiles)
                    {
                        // wait for file to become available, or 30 seconds, which ever comes first.  
                        WaitForFile(currentFile, 30000);
                        string fileName = currentFile.Substring(filePath.Length);
                        System.Diagnostics.Trace.WriteLine("FileSystem Watcher Event: Found File:" + currentFile);
                        Trace.Flush();
                        Directory.Move(currentFile, Path.Combine(filePath2, fileName));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("ProcessFiles Exception: " + ex.Message);
                Trace.Flush();
            }
        }

        public static bool IsFileReady(string filename)
        {
            // If the file can be opened for exclusive access it means that the file
            // is no longer locked by another process.
            try
            {
                using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return inputStream.Length > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void WaitForFile(string filename, int milliseconds)
        {
            //This will lock the execution until the file is ready
            //built in timer will limit the wait.

            var time = Stopwatch.StartNew();

            while (!IsFileReady(filename) && time.ElapsedMilliseconds < milliseconds) { }
        }
    }
}
