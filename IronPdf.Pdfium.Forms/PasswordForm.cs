using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IronPdf.Pdfium.Forms
{
    internal partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();

            UpdateEnabled();
        }

        private void _acceptButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void _password_TextChanged(object sender, EventArgs e)
        {
            UpdateEnabled();
        }

        private void UpdateEnabled()
        {
            _acceptButton.Enabled = _password.Text.Length > 0;
        }

        public string Password
        {
            get { return _password.Text; }
        }
    }
}
