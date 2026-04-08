using RabidWombat.Macro;
using RabidWombat.Macro.Events;
using RabidWombat.Macro.Events.Keyboard;
using RabidWombat.Macro.Events.Mouse;
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

            lblStatus.Text = "Ready...";

            // register the hotkeys for buttons
            RegisterHotKey(this.Handle, (int)Keys.Q, (int)fsModifiers.Control, Keys.Q.GetHashCode());
            RegisterHotKey(this.Handle, (int)Keys.W, (int)fsModifiers.Control, Keys.W.GetHashCode());
            RegisterHotKey(this.Handle, (int)Keys.E, (int)fsModifiers.Control, Keys.E.GetHashCode());
            RegisterHotKey(this.Handle, (int)Keys.R, (int)fsModifiers.Control, Keys.R.GetHashCode());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // unregister all hotkeys when the form is closed
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
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                fsModifiers modifier = (fsModifiers)((int)m.LParam & 0xFFFF);
                int id = m.WParam.ToInt32();

                HandleHotkey(modifier, key);
            }
        }

        /// <summary>
        /// Handles hot key presses.
        /// </summary>
        /// <param name="modifier">The modifier key pressed.</param>
        /// <param name="key">The key pressed.</param>
        private void HandleHotkey(fsModifiers modifier, Keys key)
        {
            switch (key)
            {
                case Keys.Q:
                    if (!_recorder.IsRecording)
                    {
                        btnStartRecord.PerformClick();
                    }
                    break;
                case Keys.W:
                    if (_recorder.IsRecording)
                    {
                        btnStopRecord.PerformClick();
                    }
                    break;
                case Keys.E:
                    if (!_player.IsPlaying)
                    {
                        btnPlayMacro.PerformClick();
                    }
                    break;
                case Keys.R:
                    if (_player.IsPlaying)
                    {
                        btnStopMacro.PerformClick();
                    }
                    break;
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
                    RefreshMacroDisplay();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            // start recording
            lblStatus.Text = "Recording...";
            _recorder.StartRecording();
        }

        private void btnStopRecord_Click(object sender, EventArgs e)
        {
            // stop recording
            _recorder.StopRecording();
            lblStatus.Text = "Recording finished.";
            RefreshMacroDisplay();
        }

        private void btnPlayMacro_Click(object sender, EventArgs e)
        {
            // load and play macro
            lblStatus.Text = "Playing Macro...";
            _player.LoadMacro(_recorder.CurrentMacro);
            _player.PlayMacroAsync();
            lblStatus.Text = "Macro finished.";
        }

        private void btnStopMacro_Click(object sender, EventArgs e)
        {
            // stop playing
            lblStatus.Text = "Macro stopped.";
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
                RefreshMacroDisplay();
            }
        }

        private void nmbrLoops_ValueChanged(object sender, EventArgs e)
        {
            _player.Repetitions = (int)nmbrLoops.Value;
        }

        private void nmbrDelayJitter_ValueChanged(object sender, EventArgs e)
        {
            _player.DelayJitter = (int)nmbrDelayJitter.Value;
        }

        private void nmbrMouseJitter_ValueChanged(object sender, EventArgs e)
        {
            _player.MouseJitter = (int)nmbrMouseJitter.Value;
        }

        private void RefreshMacroDisplay()
        {
            lstEvents.Items.Clear();

            var macro = _recorder.CurrentMacro;
            if (macro == null || macro.Events == null || macro.Events.Length == 0)
            {
                lblMacroInfo.Text = "Macro Events (0):";
                return;
            }

            var events = macro.Events;
            lblMacroInfo.Text = $"Macro Events ({events.Length}):";

            lstEvents.BeginUpdate();
            foreach (var evt in events)
            {
                string type, detail;
                switch (evt)
                {
                    case MacroDelayEvent delay:
                        type = "Delay";
                        detail = $"{TimeSpan.FromTicks(delay.Delay).TotalMilliseconds:F0}ms";
                        break;
                    case MacroKeyDownEvent kd:
                        type = "Key Down";
                        detail = ((Keys)kd.VirtualKeyCode).ToString();
                        break;
                    case MacroKeyUpEvent ku:
                        type = "Key Up";
                        detail = ((Keys)ku.VirtualKeyCode).ToString();
                        break;
                    case MacroMouseMoveEvent mm:
                        type = "Mouse Move";
                        detail = $"({mm.Location.X:F0}, {mm.Location.Y:F0})";
                        break;
                    case MacroMouseDownEvent md:
                        type = "Mouse Down";
                        detail = $"{md.Button} at ({md.Location.X:F0}, {md.Location.Y:F0})";
                        break;
                    case MacroMouseUpEvent mu:
                        type = "Mouse Up";
                        detail = $"{mu.Button} at ({mu.Location.X:F0}, {mu.Location.Y:F0})";
                        break;
                    case MacroMouseWheelEvent mw:
                        type = "Mouse Wheel";
                        detail = $"delta={mw.Delta} at ({mw.Location.X:F0}, {mw.Location.Y:F0})";
                        break;
                    default:
                        type = evt.GetType().Name;
                        detail = "";
                        break;
                }
                lstEvents.Items.Add(new ListViewItem(new[] { type, detail }));
            }
            lstEvents.EndUpdate();
        }

        private void btnClearMacro_Click(object sender, EventArgs e)
        {
            // confirm action
            if (_recorder.CurrentMacro != null && _recorder.CurrentMacro.Events.Length > 0)
            {
                var result = MessageBox.Show("Are you sure you want to clear the current macro?", "Clear Macro?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    lblStatus.Text = "Macro Cleared. Ready...";
                    _recorder.Clear();
                    RefreshMacroDisplay();
                }
            }
        }
    }
}
