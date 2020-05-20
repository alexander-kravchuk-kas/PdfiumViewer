using System;
using System.Collections.Generic;

namespace IronPdf.Pdfium
{
    public delegate void PdfiumResolveEventHandler(object sender, PdfiumResolveEventArgs e);

    public class PdfiumResolveEventArgs : EventArgs
    {
        public string PdfiumFileName { get; set; }
    }
}
