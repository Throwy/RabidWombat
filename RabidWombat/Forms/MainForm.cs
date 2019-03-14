using RabidWombat.Macro;
using RabidWombat.Models;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RabidWombat.Forms
{
    public partial class MainForm : Form
    {
        private const string CONFIGURATION_FILE_PATH = "config.json";
        private readonly ConfigurationFile _config;

        private readonly MacroRecorder _recorder = new MacroRecorder();
        private readonly MacroPlayer _player = new MacroPlayer();

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int WM_HOTKEY = 0x0312;

        private enum fsModifiers : uint
        {
            Alt = 0x0001,
            Control = 0x0002,
            Shift = 0x0004,
            Windows = 0x0008,
            NoRepeat = 0x4000
        }

        public MainForm()
        {
            InitializeComponent();

            // get application settings
            if (!File.Exists(CONFIGURATION_FILE_PATH))
            {
                new ConfigurationFile().Save(CONFIGURATION_FILE_PATH);
            }
            _config = ConfigurationFile.FromFile(CONFIGURATION_FILE_PATH);

            RegisterHotKey(this.Handle, (int)Keys.Q, (int)fsModifiers.Control, Keys.Q.GetHashCode());
            RegisterHotKey(this.Handle, (int)Keys.W, (int)fsModifiers.Control, Keys.W.GetHashCode());
            RegisterHotKey(this.Handle, (int)Keys.E, (int)fsModifiers.Control, Keys.E.GetHashCode());
            RegisterHotKey(this.Handle, (int)Keys.R, (int)fsModifiers.Control, Keys.R.GetHashCode());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, (int)Keys.Q);
            UnregisterHotKey(this.Handle, (int)Keys.W);
            UnregisterHotKey(this.Handle, (int)Keys.E);
            UnregisterHotKey(this.Handle, (int)Keys.R);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY)
            {
                /* Note that the three lines below are not needed if you only want to register one hotkey.
                 * The below lines are useful in case you want to register multiple keys, which you can use a switch with the id as argument, or if you want to know which key/modifier was pressed for some particular reason. */

                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                fsModifiers modifier = (fsModifiers)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.

                MessageBox.Show("Hotkey has been pressed!");
            }
        }

        private void btnStartRecord_Click(object sender, EventArgs e)
        {
            // confirm action
            if (_recorder.CurrentMacro != null && _recorder.CurrentMacro.Events.Length > 0)
            {
                var result = MessageBox.Show("This will continue appending to your current macro, would you like to start over and clear the current macro>", "Clear macro?", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _recorder.Clear();
                }
                else if (result == DialogResult.Cancel)
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
            if (_recorder.CurrentMacro == null || _recorder.CurrentMacro.Events.Length == 0)
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
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _recorder.CurrentMacro.Save(dialog.FileName);
            }
        }

        private void btnOpenMacro_Click(object sender, EventArgs e)
        {
            // confirm action
            if (_recorder.CurrentMacro != null && _recorder.CurrentMacro.Events.Length > 0)
            {
                var result = MessageBox.Show("Are you sure you want to load this file and overwrite the current macro?", "Clear macro?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
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
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var loadedMacro = new Macro.Macro();
                loadedMacro.Load(dialog.FileName);
                _recorder.LoadMacro(loadedMacro);
            }
        }

        private void btnLoops_Click(object sender, EventArgs e)
        {
            var dialog = new LoopsDialog { Loops = _player.Repetitions };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _player.Repetitions = dialog.Loops;
            }
        }

        private void btnClearMacro_Click(object sender, EventArgs e)
        {
            // confirm action
            if (_recorder.CurrentMacro != null && _recorder.CurrentMacro.Events.Length > 0)
            {
                var result = MessageBox.Show("Are you sure you want to clear the current macro?", "Clear Macro?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _recorder.Clear();
                }
            }
        }
    }
}
