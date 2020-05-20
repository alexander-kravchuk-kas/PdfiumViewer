using System;
using System.Collections.Generic;
using System.Drawing;

#pragma warning disable 1591

namespace IronPdf.Pdfium
{
    public struct PdfRectangle : IEquatable<PdfRectangle>
    {
        public static readonly PdfRectangle Empty = new PdfRectangle();
        // _page is offset by 1 so that Empty returns an invalid rectangle.
        private readonly int _page;

        public PdfRectangle(int page, RectangleF bounds)
        {
            _page = page + 1;
            Bounds = bounds;
        }

        public static bool operator !=(PdfRectangle left, PdfRectangle right)
        {
            return !left.Equals(right);
        }
        public static bool operator ==(PdfRectangle left, PdfRectangle right)
        {
            return left.Equals(right);
        }

        public bool Equals(PdfRectangle other)
        {
            return
                Page == other.Page &&
                Bounds == other.Bounds;
        }

        public override bool Equals(object obj)
        {
            return
                obj is PdfRectangle &&
                Equals((PdfRectangle)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Page * 397 ^ Bounds.GetHashCode();
            }
        }

        public RectangleF Bounds { get; }

        public bool IsValid
        {
            get { return _page != 0; }
        }

        public int Page
        {
            get { return _page - 1; }
        }
    }
}
