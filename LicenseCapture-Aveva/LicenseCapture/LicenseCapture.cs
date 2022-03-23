using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LicenseCapture
{
    public partial class LicenseCapture : Form
    {
        public LicenseCapture()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            goliath.licensecapture.NEG.ArchiveNEG archiveNEG = new goliath.licensecapture.NEG.ArchiveNEG();
            archiveNEG.CaptureArchive();
            Close();
        }
    }
}
