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
            this.lblLoops = new System.Windows.Forms.Label();
            this.nmbrLoops = new System.Windows.Forms.NumericUpDown();
            this.btnClearMacro = new System.Windows.Forms.Button();
            this.lblDelayJitter = new System.Windows.Forms.Label();
            this.nmbrDelayJitter = new System.Windows.Forms.NumericUpDown();
            this.lblMouseJitter = new System.Windows.Forms.Label();
            this.nmbrMouseJitter = new System.Windows.Forms.NumericUpDown();
            this.lblMacroInfo = new System.Windows.Forms.Label();
            this.lstEvents = new System.Windows.Forms.ListView();
            this.colEventType = new System.Windows.Forms.ColumnHeader();
            this.colEventDetail = new System.Windows.Forms.ColumnHeader();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.nmbrLoops)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmbrDelayJitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmbrMouseJitter)).BeginInit();
            this.statusStrip1.SuspendLayout();
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
            this.btnStopRecord.Location = new System.Drawing.Point(108, 12);
            this.btnStopRecord.Name = "btnStopRecord";
            this.btnStopRecord.Size = new System.Drawing.Size(90, 25);
            this.btnStopRecord.TabIndex = 1;
            this.btnStopRecord.Text = "Stop Recording";
            this.btnStopRecord.UseVisualStyleBackColor = true;
            this.btnStopRecord.Click += new System.EventHandler(this.btnStopRecord_Click);
            // 
            // btnPlayMacro
            // 
            this.btnPlayMacro.Location = new System.Drawing.Point(12, 59);
            this.btnPlayMacro.Name = "btnPlayMacro";
            this.btnPlayMacro.Size = new System.Drawing.Size(90, 25);
            this.btnPlayMacro.TabIndex = 2;
            this.btnPlayMacro.Text = "Play";
            this.btnPlayMacro.UseVisualStyleBackColor = true;
            this.btnPlayMacro.Click += new System.EventHandler(this.btnPlayMacro_Click);
            // 
            // btnStopMacro
            // 
            this.btnStopMacro.Location = new System.Drawing.Point(108, 59);
            this.btnStopMacro.Name = "btnStopMacro";
            this.btnStopMacro.Size = new System.Drawing.Size(90, 25);
            this.btnStopMacro.TabIndex = 3;
            this.btnStopMacro.Text = "Stop Macro";
            this.btnStopMacro.UseVisualStyleBackColor = true;
            this.btnStopMacro.Click += new System.EventHandler(this.btnStopMacro_Click);
            // 
            // btnSaveMacro
            // 
            this.btnSaveMacro.Location = new System.Drawing.Point(12, 108);
            this.btnSaveMacro.Name = "btnSaveMacro";
            this.btnSaveMacro.Size = new System.Drawing.Size(90, 25);
            this.btnSaveMacro.TabIndex = 4;
            this.btnSaveMacro.Text = "Save Macro";
            this.btnSaveMacro.UseVisualStyleBackColor = true;
            this.btnSaveMacro.Click += new System.EventHandler(this.btnSaveMacro_Click);
            // 
            // btnOpenMacro
            // 
            this.btnOpenMacro.Location = new System.Drawing.Point(108, 108);
            this.btnOpenMacro.Name = "btnOpenMacro";
            this.btnOpenMacro.Size = new System.Drawing.Size(90, 25);
            this.btnOpenMacro.TabIndex = 5;
            this.btnOpenMacro.Text = "Open Macro";
            this.btnOpenMacro.UseVisualStyleBackColor = true;
            this.btnOpenMacro.Click += new System.EventHandler(this.btnOpenMacro_Click);
            //
            // lblLoops
            //
            this.lblLoops.AutoSize = true;
            this.lblLoops.Location = new System.Drawing.Point(12, 159);
            this.lblLoops.Name = "lblLoops";
            this.lblLoops.TabIndex = 6;
            this.lblLoops.Text = "Loops:";
            //
            // nmbrLoops
            //
            this.nmbrLoops.Location = new System.Drawing.Point(55, 155);
            this.nmbrLoops.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nmbrLoops.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.nmbrLoops.Name = "nmbrLoops";
            this.nmbrLoops.Size = new System.Drawing.Size(47, 23);
            this.nmbrLoops.TabIndex = 7;
            this.nmbrLoops.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nmbrLoops.ValueChanged += new System.EventHandler(this.nmbrLoops_ValueChanged);
            //
            // btnClearMacro
            // 
            this.btnClearMacro.Location = new System.Drawing.Point(108, 155);
            this.btnClearMacro.Name = "btnClearMacro";
            this.btnClearMacro.Size = new System.Drawing.Size(90, 23);
            this.btnClearMacro.TabIndex = 8;
            this.btnClearMacro.Text = "Clear Macro";
            this.btnClearMacro.UseVisualStyleBackColor = true;
            this.btnClearMacro.Click += new System.EventHandler(this.btnClearMacro_Click);
            //
            // lblDelayJitter
            //
            this.lblDelayJitter.AutoSize = true;
            this.lblDelayJitter.Location = new System.Drawing.Point(12, 190);
            this.lblDelayJitter.Name = "lblDelayJitter";
            this.lblDelayJitter.TabIndex = 9;
            this.lblDelayJitter.Text = "Delay Jitter (ms):";
            //
            // nmbrDelayJitter
            //
            this.nmbrDelayJitter.Location = new System.Drawing.Point(130, 187);
            this.nmbrDelayJitter.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.nmbrDelayJitter.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            this.nmbrDelayJitter.Name = "nmbrDelayJitter";
            this.nmbrDelayJitter.Size = new System.Drawing.Size(65, 23);
            this.nmbrDelayJitter.TabIndex = 10;
            this.nmbrDelayJitter.Value = new decimal(new int[] { 0, 0, 0, 0 });
            this.nmbrDelayJitter.ValueChanged += new System.EventHandler(this.nmbrDelayJitter_ValueChanged);
            //
            // lblMouseJitter
            //
            this.lblMouseJitter.AutoSize = true;
            this.lblMouseJitter.Location = new System.Drawing.Point(12, 216);
            this.lblMouseJitter.Name = "lblMouseJitter";
            this.lblMouseJitter.TabIndex = 11;
            this.lblMouseJitter.Text = "Mouse Jitter (px):";
            //
            // nmbrMouseJitter
            //
            this.nmbrMouseJitter.Location = new System.Drawing.Point(130, 213);
            this.nmbrMouseJitter.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.nmbrMouseJitter.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.nmbrMouseJitter.Name = "nmbrMouseJitter";
            this.nmbrMouseJitter.Size = new System.Drawing.Size(65, 23);
            this.nmbrMouseJitter.TabIndex = 12;
            this.nmbrMouseJitter.Value = new decimal(new int[] { 0, 0, 0, 0 });
            this.nmbrMouseJitter.ValueChanged += new System.EventHandler(this.nmbrMouseJitter_ValueChanged);
            //
            // lblMacroInfo
            //
            this.lblMacroInfo.AutoSize = true;
            this.lblMacroInfo.Location = new System.Drawing.Point(12, 244);
            this.lblMacroInfo.Name = "lblMacroInfo";
            this.lblMacroInfo.TabIndex = 13;
            this.lblMacroInfo.Text = "Macro Events (0):";
            //
            // lstEvents
            //
            this.lstEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEventType,
            this.colEventDetail});
            this.lstEvents.FullRowSelect = true;
            this.lstEvents.GridLines = true;
            this.lstEvents.Location = new System.Drawing.Point(12, 262);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(186, 130);
            this.lstEvents.TabIndex = 14;
            this.lstEvents.UseCompatibleStateImageBehavior = false;
            this.lstEvents.View = System.Windows.Forms.View.Details;
            //
            // colEventType
            //
            this.colEventType.Text = "Type";
            this.colEventType.Width = 90;
            //
            // colEventDetail
            //
            this.colEventDetail.Text = "Detail";
            this.colEventDetail.Width = 92;
            //
            // statusStrip1
            //
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 396);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(210, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 418);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.lblMacroInfo);
            this.Controls.Add(this.nmbrMouseJitter);
            this.Controls.Add(this.lblMouseJitter);
            this.Controls.Add(this.nmbrDelayJitter);
            this.Controls.Add(this.lblDelayJitter);
            this.Controls.Add(this.btnClearMacro);
            this.Controls.Add(this.nmbrLoops);
            this.Controls.Add(this.lblLoops);
            this.Controls.Add(this.btnOpenMacro);
            this.Controls.Add(this.btnSaveMacro);
            this.Controls.Add(this.btnStopMacro);
            this.Controls.Add(this.btnPlayMacro);
            this.Controls.Add(this.btnStopRecord);
            this.Controls.Add(this.btnStartRecord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rabid Wombat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nmbrLoops)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmbrDelayJitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmbrMouseJitter)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.Label lblLoops;
        private System.Windows.Forms.NumericUpDown nmbrLoops;
        private System.Windows.Forms.Button btnClearMacro;
        private System.Windows.Forms.Label lblDelayJitter;
        private System.Windows.Forms.NumericUpDown nmbrDelayJitter;
        private System.Windows.Forms.Label lblMouseJitter;
        private System.Windows.Forms.NumericUpDown nmbrMouseJitter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Label lblMacroInfo;
        private System.Windows.Forms.ListView lstEvents;
        private System.Windows.Forms.ColumnHeader colEventType;
        private System.Windows.Forms.ColumnHeader colEventDetail;
    }
}

