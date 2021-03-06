﻿using System;
using System.Collections.Generic;

#pragma warning disable 1591

namespace IronPdf.Pdfium
{
    public class PdfMatch
    {
        public PdfMatch(string text, PdfTextSpan textSpan, int page)
        {
            Text = text;
            TextSpan = textSpan;
            Page = page;
        }

        public int Page { get; }

        public string Text { get; }

        public PdfTextSpan TextSpan { get; }
    }
}
