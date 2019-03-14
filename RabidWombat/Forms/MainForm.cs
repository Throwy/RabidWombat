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
        private readonly MacroPlayer _player = new MacroPlayer();

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
            // load and play macro
            _player.LoadMacro(_recorder.CurrentMacro);
            _player.PlayMacroAsync();
        }

        private void btnStopMacro_Click(object sender, EventArgs e)
        {
            // stop playing
            _player.CancelPlayback();
        }

        private void btnSaveMacro_Click(object sender, EventArgs e)
        {
            // check for macro to save
            if(_recorder.CurrentMacro == null || _recorder.CurrentMacro.Events.Length == 0)
            {
                MessageBox.Show("There is no macro currently recorded.", "Cannot save macro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // choose file to save to
            var dialog = new SaveFileDialog
            {
                Title = "Save Macro",
                Filter = "RabidWombat Macro Files (*.rbwt)|*.rbwt|All Files (*.*)|*.*"
            };

            //save file
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                _recorder.CurrentMacro.Save(dialog.FileName);
            }
        }

        private void btnOpenMacro_Click(object sender, EventArgs e)
        {
            // confirm action
            if(_recorder.CurrentMacro != null && _recorder.CurrentMacro.Events.Length > 0)
            {
                var result = MessageBox.Show("Are you sure you want to load this file and overwrite the current macro?", "Clear macro?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result == DialogResult.No)
                {
                    return;
                }
            }

            // browse for file
            var dialog = new OpenFileDialog
            {
                Title = "Open Macro",
                Filter = "RabidWombat Macro Files (*.rbwt)|*.rbwt|All Files (*.*)|*.*"
            };

            // load macro into recorder
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                var loadedMacro = new Macro.Macro();
                loadedMacro.Load(dialog.FileName);
                _recorder.LoadMacro(loadedMacro);
            }
        }
    }
}
