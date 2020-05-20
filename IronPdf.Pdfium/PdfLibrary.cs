using System;
using System.Collections.Generic;

namespace PdfiumViewer
{
    internal class PdfLibrary : IDisposable
    {
        private static PdfLibrary _library;
        private static readonly object _syncRoot = new object();
        private bool _disposed;

        private PdfLibrary()
        {
            NativeMethods.FPDF_AddRef();
        }

        ~PdfLibrary()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                NativeMethods.FPDF_Release();

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public static void EnsureLoaded()
        {
            lock(_syncRoot)
            {
                if(_library == null)
                {
                    _library = new PdfLibrary();
                }
            }
        }
    }
}
