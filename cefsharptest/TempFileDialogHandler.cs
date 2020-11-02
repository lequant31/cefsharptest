using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cefsharptest
{
    public class TempFileDialogHandler : IDialogHandler
    {
        string[] _filePath;

        public TempFileDialogHandler(params string[] filePath)
        {
            _filePath = filePath;
        }
   
        public bool OnFileDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, CefFileDialogMode mode, CefFileDialogFlags flags, string title, string defaultFilePath, List<string> acceptFilters, int selectedAcceptFilter, IFileDialogCallback callback)
        {
            callback.Continue(0, _filePath.ToList());
            return true;
        }
    }
}
