
namespace DataManager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.numericUpDownAddress = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEmail = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPhone = new System.Windows.Forms.NumericUpDown();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.textBoxXML = new System.Windows.Forms.TextBox();
            this.buttonFile = new System.Windows.Forms.Button();
            this.buttonObject = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPhone)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDownAddress
            // 
            this.numericUpDownAddress.Location = new System.Drawing.Point(69, 9);
            this.numericUpDownAddress.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownAddress.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAddress.MinimumSize = new System.Drawing.Size(50, 0);
            this.numericUpDownAddress.Name = "numericUpDownAddress";
            this.numericUpDownAddress.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownAddress.TabIndex = 2;
            this.numericUpDownAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownAddress.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownEmail
            // 
            this.numericUpDownEmail.Location = new System.Drawing.Point(69, 29);
            this.numericUpDownEmail.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownEmail.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownEmail.MinimumSize = new System.Drawing.Size(50, 0);
            this.numericUpDownEmail.Name = "numericUpDownEmail";
            this.numericUpDownEmail.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownEmail.TabIndex = 3;
            this.numericUpDownEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownEmail.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownPhone
            // 
            this.numericUpDownPhone.Location = new System.Drawing.Point(69, 49);
            this.numericUpDownPhone.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownPhone.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPhone.MinimumSize = new System.Drawing.Size(50, 0);
            this.numericUpDownPhone.Name = "numericUpDownPhone";
            this.numericUpDownPhone.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownPhone.TabIndex = 4;
            this.numericUpDownPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownPhone.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(3, 9);
            this.labelAddress.MinimumSize = new System.Drawing.Size(60, 20);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(60, 20);
            this.labelAddress.TabIndex = 5;
            this.labelAddress.Text = "Address ID";
            this.labelAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(3, 29);
            this.labelEmail.MinimumSize = new System.Drawing.Size(60, 20);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(60, 20);
            this.labelEmail.TabIndex = 6;
            this.labelEmail.Text = "Email ID";
            this.labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(3, 49);
            this.labelPhone.MinimumSize = new System.Drawing.Size(60, 20);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(60, 20);
            this.labelPhone.TabIndex = 7;
            this.labelPhone.Text = "Phone ID";
            this.labelPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelAddress);
            this.panel1.Controls.Add(this.numericUpDownAddress);
            this.panel1.Controls.Add(this.buttonRandom);
            this.panel1.Controls.Add(this.numericUpDownPhone);
            this.panel1.Controls.Add(this.labelPhone);
            this.panel1.Controls.Add(this.labelEmail);
            this.panel1.Controls.Add(this.numericUpDownEmail);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 98);
            this.panel1.TabIndex = 8;
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(14, 70);
            this.buttonRandom.MaximumSize = new System.Drawing.Size(121, 60);
            this.buttonRandom.MinimumSize = new System.Drawing.Size(100, 20);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(100, 25);
            this.buttonRandom.TabIndex = 10;
            this.buttonRandom.Text = "random";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // textBoxXML
            // 
            this.textBoxXML.Location = new System.Drawing.Point(148, 12);
            this.textBoxXML.Multiline = true;
            this.textBoxXML.Name = "textBoxXML";
            this.textBoxXML.ReadOnly = true;
            this.textBoxXML.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxXML.Size = new System.Drawing.Size(387, 186);
            this.textBoxXML.TabIndex = 9;
            // 
            // buttonFile
            // 
            this.buttonFile.Enabled = false;
            this.buttonFile.Location = new System.Drawing.Point(26, 147);
            this.buttonFile.MaximumSize = new System.Drawing.Size(121, 60);
            this.buttonFile.MinimumSize = new System.Drawing.Size(100, 20);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(100, 25);
            this.buttonFile.TabIndex = 12;
            this.buttonFile.Text = "create file";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // buttonObject
            // 
            this.buttonObject.Location = new System.Drawing.Point(26, 116);
            this.buttonObject.MaximumSize = new System.Drawing.Size(121, 60);
            this.buttonObject.MinimumSize = new System.Drawing.Size(100, 20);
            this.buttonObject.Name = "buttonObject";
            this.buttonObject.Size = new System.Drawing.Size(100, 25);
            this.buttonObject.TabIndex = 11;
            this.buttonObject.Text = "create object ";
            this.buttonObject.UseVisualStyleBackColor = true;
            this.buttonObject.Click += new System.EventHandler(this.buttonObject_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(18, 178);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(119, 20);
            this.textBoxName.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 211);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.buttonObject);
            this.Controls.Add(this.textBoxXML);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "DataManager";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPhone)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownAddress;
        private System.Windows.Forms.NumericUpDown numericUpDownEmail;
        private System.Windows.Forms.NumericUpDown numericUpDownPhone;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxXML;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.Button buttonObject;
        private System.Windows.Forms.TextBox textBoxName;
    }
}

