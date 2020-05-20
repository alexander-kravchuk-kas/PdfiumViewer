using IronPdf.Pdfium;
using System;
using System.Collections.Generic;
using System.ComponentModel;

#pragma warning disable 1591

namespace IronPdf.Pdfium.Forms
{
    public delegate void LinkClickEventHandler(object sender, LinkClickEventArgs e);

    public class LinkClickEventArgs : HandledEventArgs
    {
        public LinkClickEventArgs(PdfPageLink link)
        {
            Link = link;
        }

        /// <summary>
        /// Gets the link that was clicked.
        /// </summary>
        public PdfPageLink Link { get; private set; }
    }
}
