using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#pragma warning disable 1591

namespace IronPdf.Pdfium
{
    public class PdfBookmark
    {
        public PdfBookmark()
        {
            Children = new PdfBookmarkCollection();
        }

        public override string ToString()
        {
            return Title;
        }

        public PdfBookmarkCollection Children { get; }

        public int PageIndex { get; set; }

        public string Title { get; set; }
    }

    public class PdfBookmarkCollection : Collection<PdfBookmark>
    {
    }
}
