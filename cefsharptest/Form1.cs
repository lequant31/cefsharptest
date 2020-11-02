using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace cefsharptest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeChromium();
        }

        public ChromiumWebBrowser chromeBrowser;

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();

            settings.CefCommandLineArgs.Add("enable-media-stream", "1");

            Cef.Initialize(settings);

            chromeBrowser = new ChromiumWebBrowser("https://chat.zalo.me/");

            this.Controls.Add(chromeBrowser);

            chromeBrowser.DialogHandler = new TempFileDialogHandler();

            chromeBrowser.Dock = DockStyle.Fill;
        }

        private class TempFileDialogHandler : IDialogHandler
        {
            private string[] _filePath;

            public TempFileDialogHandler(params string[] filePath)
            {
                _filePath = filePath;
            }

            //private void RunFileDialogToolStripMenuItemClick(object sender, EventArgs e)
            //{
            //    //var control = GetCurrentTabControl();
            //    //if (control != null)
            //    //{
            //    chromeBrowser.GetBrowserHost().RunFileDialog(CefFileDialogMode.Open, "Open", null, new List<string> { "*.*" }, 0, new RunFileDialogCallback());
            //    //}
            //}
            public bool OnFileDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, CefFileDialogMode mode, CefFileDialogFlags flags, string title, string defaultFilePath, List<string> acceptFilters, int selectedAcceptFilter, IFileDialogCallback callback)
            {
                callback.Continue(0, _filePath.ToList());
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chromeBrowser.DialogHandler = new TempFileDialogHandler(@"C:\Users\LeQuan\Pictures\Capture.PNG");
            string script = string.Format("document.getElementsByClassName('tooltip btn fa fa-chatbar-icon-photo iup-image')[0].click()");
            chromeBrowser.EvaluateScriptAsync(script);
        }
    }
}