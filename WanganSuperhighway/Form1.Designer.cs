namespace WanganSuperhighway
{
    partial class Form1
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
            this.listBoxServerBrowser = new System.Windows.Forms.ListBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxServerBrowser
            // 
            this.listBoxServerBrowser.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxServerBrowser.FormattingEnabled = true;
            this.listBoxServerBrowser.ItemHeight = 19;
            this.listBoxServerBrowser.Location = new System.Drawing.Point(13, 13);
            this.listBoxServerBrowser.Name = "listBoxServerBrowser";
            this.listBoxServerBrowser.Size = new System.Drawing.Size(965, 384);
            this.listBoxServerBrowser.TabIndex = 0;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(13, 413);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(154, 48);
            this.buttonCreate.TabIndex = 1;
            this.buttonCreate.Text = "buttonCreate";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(819, 413);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(154, 48);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "buttonConnect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(422, 413);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(155, 48);
            this.buttonSettings.TabIndex = 3;
            this.buttonSettings.Text = "buttonSettings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 469);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.listBoxServerBrowser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxServerBrowser;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonSettings;
    }
}

