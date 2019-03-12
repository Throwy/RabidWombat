using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RabidWombat
{
    public partial class MainForm : Form
    {
        private const string CONFIGURATION_FILE_PATH = "config.json";
        private readonly ConfigurationFile _config;

        public MainForm()
        {
            InitializeComponent();

            // get application settings
            if(!File.Exists(CONFIGURATION_FILE_PATH))
            {
                new ConfigurationFile().Save(CONFIGURATION_FILE_PATH);
            }
            _config = ConfigurationFile.FromFile(CONFIGURATION_FILE_PATH);
        }

        private void btnStartRecord_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnStopRecord_Click(object sender, EventArgs e)
        {
            // TODO:
        }
    }
}
