using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IronPdf.Pdfium.Forms
{
    public class PdfFormDocument
    {
        private static PdfDocument Load(IWin32Window owner, Stream stream, string password)
        {
            try
            {
                while(true)
                {
                    try
                    {
                        return new PdfDocument(stream, password);
                    }
                    catch(PdfException ex)
                    {
                        if((owner != null) && (ex.Error == PdfError.PasswordProtected))
                        {
                            using(var form = new PasswordForm())
                            {
                                if(form.ShowDialog(owner) == DialogResult.OK)
                                {
                                    password = form.Password;
                                    continue;
                                }
                            }
                        }

                        throw;
                    }
                }
            }
            catch
            {
                stream.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Initializes a new instance of the PdfDocument class with the provided path.
        /// </summary>
        /// <param name="owner">Window to show any UI for.</param>
        /// <param name="path">Path to the PDF document.</param>
        public static PdfDocument Load(IWin32Window owner, string path)
        {
            if(owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            if(path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            return Load(owner, File.OpenRead(path), null);
        }

        /// <summary>
        /// Initializes a new instance of the PdfDocument class with the provided path.
        /// </summary>
        /// <param name="owner">Window to show any UI for.</param>
        /// <param name="stream">Stream for the PDF document.</param>
        public static PdfDocument Load(IWin32Window owner, Stream stream)
        {
            if(owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            if(stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            return Load(owner, stream, null);
        }
    }
}
