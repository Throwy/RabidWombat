namespace RabidWombat.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartRecord = new System.Windows.Forms.Button();
            this.btnStopRecord = new System.Windows.Forms.Button();
            this.btnPlayMacro = new System.Windows.Forms.Button();
            this.btnStopMacro = new System.Windows.Forms.Button();
            this.btnSaveMacro = new System.Windows.Forms.Button();
            this.btnOpenMacro = new System.Windows.Forms.Button();
            this.btnLoops = new System.Windows.Forms.Button();
            this.btnClearMacro = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStartRecord
            // 
            this.btnStartRecord.Location = new System.Drawing.Point(12, 12);
            this.btnStartRecord.Name = "btnStartRecord";
            this.btnStartRecord.Size = new System.Drawing.Size(90, 25);
            this.btnStartRecord.TabIndex = 0;
            this.btnStartRecord.Text = "Record";
            this.btnStartRecord.UseVisualStyleBackColor = true;
            this.btnStartRecord.Click += new System.EventHandler(this.btnStartRecord_Click);
            // 
            // btnStopRecord
            // 
            this.btnStopRecord.Location = new System.Drawing.Point(12, 43);
            this.btnStopRecord.Name = "btnStopRecord";
            this.btnStopRecord.Size = new System.Drawing.Size(90, 25);
            this.btnStopRecord.TabIndex = 1;
            this.btnStopRecord.Text = "Stop Recording";
            this.btnStopRecord.UseVisualStyleBackColor = true;
            this.btnStopRecord.Click += new System.EventHandler(this.btnStopRecord_Click);
            // 
            // btnPlayMacro
            // 
            this.btnPlayMacro.Location = new System.Drawing.Point(12, 97);
            this.btnPlayMacro.Name = "btnPlayMacro";
            this.btnPlayMacro.Size = new System.Drawing.Size(90, 25);
            this.btnPlayMacro.TabIndex = 2;
            this.btnPlayMacro.Text = "Play";
            this.btnPlayMacro.UseVisualStyleBackColor = true;
            this.btnPlayMacro.Click += new System.EventHandler(this.btnPlayMacro_Click);
            // 
            // btnStopMacro
            // 
            this.btnStopMacro.Location = new System.Drawing.Point(12, 128);
            this.btnStopMacro.Name = "btnStopMacro";
            this.btnStopMacro.Size = new System.Drawing.Size(90, 25);
            this.btnStopMacro.TabIndex = 3;
            this.btnStopMacro.Text = "Stop Macro";
            this.btnStopMacro.UseVisualStyleBackColor = true;
            this.btnStopMacro.Click += new System.EventHandler(this.btnStopMacro_Click);
            // 
            // btnSaveMacro
            // 
            this.btnSaveMacro.Location = new System.Drawing.Point(12, 185);
            this.btnSaveMacro.Name = "btnSaveMacro";
            this.btnSaveMacro.Size = new System.Drawing.Size(90, 25);
            this.btnSaveMacro.TabIndex = 4;
            this.btnSaveMacro.Text = "Save Macro";
            this.btnSaveMacro.UseVisualStyleBackColor = true;
            this.btnSaveMacro.Click += new System.EventHandler(this.btnSaveMacro_Click);
            // 
            // btnOpenMacro
            // 
            this.btnOpenMacro.Location = new System.Drawing.Point(12, 216);
            this.btnOpenMacro.Name = "btnOpenMacro";
            this.btnOpenMacro.Size = new System.Drawing.Size(90, 25);
            this.btnOpenMacro.TabIndex = 5;
            this.btnOpenMacro.Text = "Open Macro";
            this.btnOpenMacro.UseVisualStyleBackColor = true;
            this.btnOpenMacro.Click += new System.EventHandler(this.btnOpenMacro_Click);
            // 
            // btnLoops
            // 
            this.btnLoops.Location = new System.Drawing.Point(12, 298);
            this.btnLoops.Name = "btnLoops";
            this.btnLoops.Size = new System.Drawing.Size(90, 23);
            this.btnLoops.TabIndex = 6;
            this.btnLoops.Text = "Loops";
            this.btnLoops.UseVisualStyleBackColor = true;
            this.btnLoops.Click += new System.EventHandler(this.btnLoops_Click);
            // 
            // btnClearMacro
            // 
            this.btnClearMacro.Location = new System.Drawing.Point(12, 415);
            this.btnClearMacro.Name = "btnClearMacro";
            this.btnClearMacro.Size = new System.Drawing.Size(90, 23);
            this.btnClearMacro.TabIndex = 7;
            this.btnClearMacro.Text = "Clear Macro";
            this.btnClearMacro.UseVisualStyleBackColor = true;
            this.btnClearMacro.Click += new System.EventHandler(this.btnClearMacro_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(419, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnClearMacro);
            this.Controls.Add(this.btnLoops);
            this.Controls.Add(this.btnOpenMacro);
            this.Controls.Add(this.btnSaveMacro);
            this.Controls.Add(this.btnStopMacro);
            this.Controls.Add(this.btnPlayMacro);
            this.Controls.Add(this.btnStopRecord);
            this.Controls.Add(this.btnStartRecord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Rabid Wombat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartRecord;
        private System.Windows.Forms.Button btnStopRecord;
        private System.Windows.Forms.Button btnPlayMacro;
        private System.Windows.Forms.Button btnStopMacro;
        private System.Windows.Forms.Button btnSaveMacro;
        private System.Windows.Forms.Button btnOpenMacro;
        private System.Windows.Forms.Button btnLoops;
        private System.Windows.Forms.Button btnClearMacro;
        private System.Windows.Forms.TextBox textBox1;
    }
}

