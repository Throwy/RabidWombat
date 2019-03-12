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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStopMacro);
            this.Controls.Add(this.btnPlayMacro);
            this.Controls.Add(this.btnStopRecord);
            this.Controls.Add(this.btnStartRecord);
            this.Name = "MainForm";
            this.Text = "Rabid Wombat";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartRecord;
        private System.Windows.Forms.Button btnStopRecord;
        private System.Windows.Forms.Button btnPlayMacro;
        private System.Windows.Forms.Button btnStopMacro;
    }
}

