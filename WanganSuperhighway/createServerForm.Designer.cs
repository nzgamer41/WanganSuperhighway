namespace WanganSuperhighway
{
    partial class createServerForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNetworkId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGameName = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Create a Game";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "ZeroTier Network ID:";
            // 
            // textBoxNetworkId
            // 
            this.textBoxNetworkId.Location = new System.Drawing.Point(16, 79);
            this.textBoxNetworkId.Name = "textBoxNetworkId";
            this.textBoxNetworkId.Size = new System.Drawing.Size(206, 20);
            this.textBoxNetworkId.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Game Name:";
            // 
            // textBoxGameName
            // 
            this.textBoxGameName.Location = new System.Drawing.Point(16, 136);
            this.textBoxGameName.Name = "textBoxGameName";
            this.textBoxGameName.Size = new System.Drawing.Size(206, 20);
            this.textBoxGameName.TabIndex = 5;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(12, 283);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(101, 44);
            this.buttonCreate.TabIndex = 6;
            this.buttonCreate.Text = "buttonCreate";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(163, 283);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(101, 44);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "buttonStartGame";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(314, 283);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(101, 44);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // createServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 339);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxGameName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNetworkId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "createServerForm";
            this.Text = "Wangan Superhighway";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNetworkId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGameName;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonCancel;
    }
}