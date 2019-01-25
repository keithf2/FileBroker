namespace FileBroker
{
    partial class FileBrokerService
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fsWatcher = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fsWatcher)).BeginInit();
            // 
            // fsWatcher
            // 
            this.fsWatcher.EnableRaisingEvents = true;
            this.fsWatcher.Changed += new System.IO.FileSystemEventHandler(this.fsWatcher_Changed);
            this.fsWatcher.Created += new System.IO.FileSystemEventHandler(this.fsWatcher_Changed);
            // 
            // BrokerService
            // 
            this.ServiceName = "Basic FileSystem Watcher";
            ((System.ComponentModel.ISupportInitialize)(this.fsWatcher)).EndInit();
        }

        #endregion

        private System.IO.FileSystemWatcher fsWatcher;
    }
}
