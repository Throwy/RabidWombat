using RabidWombat.Macro;
using RabidWombat.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace RabidWombat.Forms
{
    public partial class MainForm : Form
    {
        private const string CONFIGURATION_FILE_PATH = "config.json";
        private readonly ConfigurationFile _config;

        private readonly MacroRecorder _recorder = new MacroRecorder();

        public MainForm()
        {
            InitializeComponent();

            // get application settings
            if (!File.Exists(CONFIGURATION_FILE_PATH))
            {
                new ConfigurationFile().Save(CONFIGURATION_FILE_PATH);
            }
            _config = ConfigurationFile.FromFile(CONFIGURATION_FILE_PATH);
        }

        private void btnStartRecord_Click(object sender, EventArgs e)
        {
            // confirm action
            if(_recorder.CurrentMacro != null && _recorder.CurrentMacro.Events.Length > 0)
            {
                var result = MessageBox.Show("This will continue appending to your current macro, would you like to start over and clear the current macro>", "Clear macro?", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    _recorder.Clear();
                }
                else if(result == DialogResult.Cancel)
                {
                    return;
                }
            }

            // start recording
            _recorder.StartRecording();
        }

        private void btnStopRecord_Click(object sender, EventArgs e)
        {
            // stop recording
            _recorder.StopRecording();
        }

        private void btnPlayMacro_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnStopMacro_Click(object sender, EventArgs e)
        {
            // TODO
        }
    }
}
