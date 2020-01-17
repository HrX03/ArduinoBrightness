namespace ArduinoBrightness
{
    partial class SerialPortForm
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
            this.components = new System.ComponentModel.Container();
            this.portSelector = new System.Windows.Forms.ComboBox();
            this.confirmPortButton = new System.Windows.Forms.Button();
            this.portReader = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // portSelector
            // 
            this.portSelector.FormattingEnabled = true;
            this.portSelector.Location = new System.Drawing.Point(12, 12);
            this.portSelector.Name = "portSelector";
            this.portSelector.Size = new System.Drawing.Size(121, 24);
            this.portSelector.TabIndex = 0;
            // 
            // confirmPortButton
            // 
            this.confirmPortButton.Location = new System.Drawing.Point(188, 12);
            this.confirmPortButton.Name = "confirmPortButton";
            this.confirmPortButton.Size = new System.Drawing.Size(75, 23);
            this.confirmPortButton.TabIndex = 1;
            this.confirmPortButton.Text = "Go";
            this.confirmPortButton.UseVisualStyleBackColor = true;
            this.confirmPortButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // SerialPortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 48);
            this.Controls.Add(this.confirmPortButton);
            this.Controls.Add(this.portSelector);
            this.Name = "SerialPortForm";
            this.Text = "SerialPortForm";
            this.Load += new System.EventHandler(this.SerialPortForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox portSelector;
        private System.Windows.Forms.Button confirmPortButton;
        private System.IO.Ports.SerialPort portReader;
    }
}