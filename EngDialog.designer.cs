namespace Logger
{
    partial class EngDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EngDialog));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnMSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnASave = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.TextBox10 = new System.Windows.Forms.TextBox();
            this.TextBox9 = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.TextBox6 = new System.Windows.Forms.TextBox();
            this.TextBox4 = new System.Windows.Forms.TextBox();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.PrjCombo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.rd_Last = new System.Windows.Forms.RadioButton();
            this.rd_New = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd_PIDDigital = new System.Windows.Forms.RadioButton();
            this.rd_PIDAnalog = new System.Windows.Forms.RadioButton();
            this.tmrBarcode = new System.Windows.Forms.Timer(this.components);
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.Erp1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.Panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel1.Controls.Add(this.btnMSave);
            this.Panel1.Controls.Add(this.btnClose);
            this.Panel1.Controls.Add(this.btnASave);
            this.Panel1.Location = new System.Drawing.Point(468, 191);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(156, 180);
            this.Panel1.TabIndex = 60;
            // 
            // btnMSave
            // 
            this.btnMSave.BackColor = System.Drawing.Color.Gainsboro;
            this.btnMSave.Enabled = false;
            this.btnMSave.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnMSave.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMSave.ForeColor = System.Drawing.Color.Green;
            this.btnMSave.Location = new System.Drawing.Point(9, 68);
            this.btnMSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMSave.Name = "btnMSave";
            this.btnMSave.Size = new System.Drawing.Size(136, 39);
            this.btnMSave.TabIndex = 3;
            this.btnMSave.Text = "&Start Manual";
            this.btnMSave.UseVisualStyleBackColor = false;
            this.btnMSave.Visible = false;
            this.btnMSave.Click += new System.EventHandler(this.btnMSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(9, 117);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 39);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnASave
            // 
            this.btnASave.BackColor = System.Drawing.Color.Gainsboro;
            this.btnASave.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnASave.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnASave.ForeColor = System.Drawing.Color.Green;
            this.btnASave.Location = new System.Drawing.Point(9, 19);
            this.btnASave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnASave.Name = "btnASave";
            this.btnASave.Size = new System.Drawing.Size(136, 39);
            this.btnASave.TabIndex = 1;
            this.btnASave.Text = "&Start Auto";
            this.btnASave.UseVisualStyleBackColor = false;
            this.btnASave.Click += new System.EventHandler(this.btnASave_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AllowDrop = true;
            this.checkBox1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.checkBox1.Location = new System.Drawing.Point(21, 25);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(169, 25);
            this.checkBox1.TabIndex = 56;
            this.checkBox1.Text = "Read Smoke Value";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox4_CheckedChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Algerian", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label9.Location = new System.Drawing.Point(77, 2);
            this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(380, 30);
            this.Label9.TabIndex = 55;
            this.Label9.Text = "Engine Test Parameters";
            // 
            // TextBox10
            // 
            this.TextBox10.BackColor = System.Drawing.Color.Silver;
            this.TextBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox10.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox10.ForeColor = System.Drawing.Color.Red;
            this.TextBox10.Location = new System.Drawing.Point(524, 149);
            this.TextBox10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.ReadOnly = true;
            this.TextBox10.Size = new System.Drawing.Size(42, 27);
            this.TextBox10.TabIndex = 54;
            // 
            // TextBox9
            // 
            this.TextBox9.BackColor = System.Drawing.Color.Silver;
            this.TextBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox9.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox9.ForeColor = System.Drawing.Color.Red;
            this.TextBox9.Location = new System.Drawing.Point(524, 103);
            this.TextBox9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.ReadOnly = true;
            this.TextBox9.Size = new System.Drawing.Size(98, 27);
            this.TextBox9.TabIndex = 53;
            this.TextBox9.TextChanged += new System.EventHandler(this.TextBox9_TextChanged);
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label12.Location = new System.Drawing.Point(470, 105);
            this.Label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(43, 17);
            this.Label12.TabIndex = 49;
            this.Label12.Text = "Date :";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label13.Location = new System.Drawing.Point(471, 150);
            this.Label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(40, 17);
            this.Label13.TabIndex = 48;
            this.Label13.Text = "Shift :";
            // 
            // TextBox6
            // 
            this.TextBox6.AllowDrop = true;
            this.TextBox6.BackColor = System.Drawing.Color.Gainsboro;
            this.TextBox6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox6.ForeColor = System.Drawing.Color.Maroon;
            this.TextBox6.Location = new System.Drawing.Point(166, 296);
            this.TextBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.Size = new System.Drawing.Size(227, 27);
            this.TextBox6.TabIndex = 45;
            // 
            // TextBox4
            // 
            this.TextBox4.BackColor = System.Drawing.Color.Gainsboro;
            this.TextBox4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox4.ForeColor = System.Drawing.Color.Maroon;
            this.TextBox4.Location = new System.Drawing.Point(166, 172);
            this.TextBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Size = new System.Drawing.Size(227, 27);
            this.TextBox4.TabIndex = 43;
            this.TextBox4.TextChanged += new System.EventHandler(this.TextBox4_TextChanged);
            // 
            // TextBox3
            // 
            this.TextBox3.BackColor = System.Drawing.Color.Gainsboro;
            this.TextBox3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox3.ForeColor = System.Drawing.Color.Maroon;
            this.TextBox3.Location = new System.Drawing.Point(166, 128);
            this.TextBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(227, 27);
            this.TextBox3.TabIndex = 42;
            this.TextBox3.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
            // 
            // TextBox2
            // 
            this.TextBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.TextBox2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox2.ForeColor = System.Drawing.Color.Maroon;
            this.TextBox2.Location = new System.Drawing.Point(166, 86);
            this.TextBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(227, 27);
            this.TextBox2.TabIndex = 41;
            this.TextBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            this.TextBox2.Click += new System.EventHandler(this.TextBox2_Click);
            // 
            // Label8
            // 
            this.Label8.AllowDrop = true;
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(55, 344);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(89, 17);
            this.Label8.TabIndex = 39;
            this.Label8.Text = "Select Project:";
            // 
            // Label6
            // 
            this.Label6.AllowDrop = true;
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(64, 301);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(80, 17);
            this.Label6.TabIndex = 37;
            this.Label6.Text = "Eng. Rating :";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(42, 258);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(102, 17);
            this.Label5.TabIndex = 36;
            this.Label5.Text = "Engineer Name :";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(74, 177);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(70, 17);
            this.Label4.TabIndex = 35;
            this.Label4.Text = "Chassis No:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(65, 133);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(79, 17);
            this.Label3.TabIndex = 34;
            this.Label3.Text = "Eng. Model :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(55, 91);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(89, 17);
            this.Label2.TabIndex = 33;
            this.Label2.Text = "Engine FIPNo :";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(72, 218);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(72, 17);
            this.Label1.TabIndex = 32;
            this.Label1.Text = "Engine No :";
            // 
            // PrjCombo
            // 
            this.PrjCombo.BackColor = System.Drawing.Color.Teal;
            this.PrjCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PrjCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.PrjCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PrjCombo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrjCombo.ForeColor = System.Drawing.Color.White;
            this.PrjCombo.Location = new System.Drawing.Point(166, 339);
            this.PrjCombo.Name = "PrjCombo";
            this.PrjCombo.Size = new System.Drawing.Size(225, 27);
            this.PrjCombo.TabIndex = 425;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 418);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(612, 102);
            this.groupBox2.TabIndex = 429;
            this.groupBox2.TabStop = false;
            // 
            // checkBox5
            // 
            this.checkBox5.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBox5.Location = new System.Drawing.Point(401, 24);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(189, 26);
            this.checkBox5.TabIndex = 3;
            this.checkBox5.Text = "Silincer Connected  . . . . . . . . . ";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBox4.Location = new System.Drawing.Point(211, 62);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(189, 26);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "Air Cleaner Connected . . . . . . .  . .";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBox3.Location = new System.Drawing.Point(212, 23);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(192, 26);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Cooling Fan Connected . . . . . . . . ";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBox2.Location = new System.Drawing.Point(21, 62);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(160, 26);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Radiator Connected . . . . ";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // rd_Last
            // 
            this.rd_Last.AutoSize = true;
            this.rd_Last.BackColor = System.Drawing.Color.Transparent;
            this.rd_Last.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_Last.ForeColor = System.Drawing.Color.Navy;
            this.rd_Last.Location = new System.Drawing.Point(205, 384);
            this.rd_Last.Name = "rd_Last";
            this.rd_Last.Size = new System.Drawing.Size(152, 21);
            this.rd_Last.TabIndex = 436;
            this.rd_Last.Text = "Continue with Last File";
            this.rd_Last.UseVisualStyleBackColor = false;
            // 
            // rd_New
            // 
            this.rd_New.AutoSize = true;
            this.rd_New.BackColor = System.Drawing.Color.Transparent;
            this.rd_New.Checked = true;
            this.rd_New.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_New.ForeColor = System.Drawing.Color.Navy;
            this.rd_New.Location = new System.Drawing.Point(59, 381);
            this.rd_New.Name = "rd_New";
            this.rd_New.Size = new System.Drawing.Size(115, 21);
            this.rd_New.TabIndex = 435;
            this.rd_New.TabStop = true;
            this.rd_New.Text = "Create New File";
            this.rd_New.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.textBox14);
            this.panel2.Controls.Add(this.textBox13);
            this.panel2.Controls.Add(this.textBox12);
            this.panel2.Controls.Add(this.textBox11);
            this.panel2.Controls.Add(this.textBox8);
            this.panel2.Controls.Add(this.textBox7);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(26, 581);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 89);
            this.panel2.TabIndex = 437;
            this.panel2.Visible = false;
            // 
            // textBox14
            // 
            this.textBox14.AllowDrop = true;
            this.textBox14.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.ForeColor = System.Drawing.Color.Maroon;
            this.textBox14.Location = new System.Drawing.Point(336, 185);
            this.textBox14.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(84, 27);
            this.textBox14.TabIndex = 460;
            this.textBox14.Text = "200";
            // 
            // textBox13
            // 
            this.textBox13.AllowDrop = true;
            this.textBox13.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.ForeColor = System.Drawing.Color.Maroon;
            this.textBox13.Location = new System.Drawing.Point(154, 184);
            this.textBox13.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(86, 27);
            this.textBox13.TabIndex = 459;
            this.textBox13.Text = "200";
            // 
            // textBox12
            // 
            this.textBox12.AllowDrop = true;
            this.textBox12.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.ForeColor = System.Drawing.Color.Maroon;
            this.textBox12.Location = new System.Drawing.Point(336, 124);
            this.textBox12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(84, 27);
            this.textBox12.TabIndex = 458;
            this.textBox12.Text = "500";
            this.textBox12.TextChanged += new System.EventHandler(this.textBox12_TextChanged);
            // 
            // textBox11
            // 
            this.textBox11.AllowDrop = true;
            this.textBox11.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.ForeColor = System.Drawing.Color.Maroon;
            this.textBox11.Location = new System.Drawing.Point(154, 128);
            this.textBox11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(86, 27);
            this.textBox11.TabIndex = 457;
            this.textBox11.Text = "20";
            // 
            // textBox8
            // 
            this.textBox8.AllowDrop = true;
            this.textBox8.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.ForeColor = System.Drawing.Color.Maroon;
            this.textBox8.Location = new System.Drawing.Point(154, 79);
            this.textBox8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(86, 27);
            this.textBox8.TabIndex = 456;
            this.textBox8.Text = "750";
            // 
            // textBox7
            // 
            this.textBox7.AllowDrop = true;
            this.textBox7.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.ForeColor = System.Drawing.Color.Maroon;
            this.textBox7.Location = new System.Drawing.Point(154, 26);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(86, 27);
            this.textBox7.TabIndex = 455;
            this.textBox7.Text = "100";
            // 
            // label16
            // 
            this.label16.AllowDrop = true;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(263, 191);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 17);
            this.label16.TabIndex = 454;
            this.label16.Text = "@ RPM:";
            // 
            // label15
            // 
            this.label15.AllowDrop = true;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(263, 129);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 17);
            this.label15.TabIndex = 453;
            this.label15.Text = "@ RPM:";
            // 
            // label14
            // 
            this.label14.AllowDrop = true;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(5, 193);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 17);
            this.label14.TabIndex = 452;
            this.label14.Text = "Max. Torque (Nm):";
            // 
            // label11
            // 
            this.label11.AllowDrop = true;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(13, 139);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 17);
            this.label11.TabIndex = 451;
            this.label11.Text = "Max. Power (Hp):";
            // 
            // label10
            // 
            this.label10.AllowDrop = true;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(2, 85);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 17);
            this.label10.TabIndex = 450;
            this.label10.Text = "Engine FlyUp RPM:";
            // 
            // label7
            // 
            this.label7.AllowDrop = true;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(16, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 17);
            this.label7.TabIndex = 449;
            this.label7.Text = "Engine IDle RPM:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd_PIDDigital);
            this.groupBox1.Controls.Add(this.rd_PIDAnalog);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(221, 581);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 124);
            this.groupBox1.TabIndex = 438;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PID Selection";
            this.groupBox1.Visible = false;
            // 
            // rd_PIDDigital
            // 
            this.rd_PIDDigital.AutoSize = true;
            this.rd_PIDDigital.BackColor = System.Drawing.Color.Transparent;
            this.rd_PIDDigital.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_PIDDigital.ForeColor = System.Drawing.Color.Navy;
            this.rd_PIDDigital.Location = new System.Drawing.Point(23, 78);
            this.rd_PIDDigital.Name = "rd_PIDDigital";
            this.rd_PIDDigital.Size = new System.Drawing.Size(124, 21);
            this.rd_PIDDigital.TabIndex = 437;
            this.rd_PIDDigital.Text = "PID Digital . . . . . ";
            this.rd_PIDDigital.UseVisualStyleBackColor = false;
            // 
            // rd_PIDAnalog
            // 
            this.rd_PIDAnalog.AutoSize = true;
            this.rd_PIDAnalog.BackColor = System.Drawing.Color.Transparent;
            this.rd_PIDAnalog.Checked = true;
            this.rd_PIDAnalog.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_PIDAnalog.ForeColor = System.Drawing.Color.Navy;
            this.rd_PIDAnalog.Location = new System.Drawing.Point(23, 32);
            this.rd_PIDAnalog.Name = "rd_PIDAnalog";
            this.rd_PIDAnalog.Size = new System.Drawing.Size(129, 21);
            this.rd_PIDAnalog.TabIndex = 436;
            this.rd_PIDAnalog.TabStop = true;
            this.rd_PIDAnalog.Text = "PID  Analog . . . . . ";
            this.rd_PIDAnalog.UseVisualStyleBackColor = false;
            // 
            // tmrBarcode
            // 
            this.tmrBarcode.Tick += new System.EventHandler(this.tmrBarcode_Tick);
            // 
            // TextBox1
            // 
            this.TextBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.TextBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox1.ForeColor = System.Drawing.Color.Maroon;
            this.TextBox1.Location = new System.Drawing.Point(166, 213);
            this.TextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(227, 27);
            this.TextBox1.TabIndex = 439;
            this.TextBox1.TextChanged += new System.EventHandler(this.textBox15_TextChanged_1);
            this.TextBox1.Leave += new System.EventHandler(this.textBox15_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(26, 56);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(119, 17);
            this.label17.TabIndex = 440;
            this.label17.Text = "Scan barcode here :";
            // 
            // Erp1
            // 
            this.Erp1.ContainerControl = this;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.Color.Maroon;
            this.textBox5.Location = new System.Drawing.Point(166, 253);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(227, 27);
            this.textBox5.TabIndex = 441;
            // 
            // txtbarcode
            // 
            this.txtbarcode.BackColor = System.Drawing.Color.Gainsboro;
            this.txtbarcode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbarcode.ForeColor = System.Drawing.Color.Maroon;
            this.txtbarcode.Location = new System.Drawing.Point(166, 49);
            this.txtbarcode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(360, 27);
            this.txtbarcode.TabIndex = 442;
            this.txtbarcode.Tag = "1";
            this.txtbarcode.TextChanged += new System.EventHandler(this.txtbarcode_TextChanged);
            // 
            // EngDialog
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(651, 567);
            this.ControlBox = false;
            this.Controls.Add(this.txtbarcode);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.rd_Last);
            this.Controls.Add(this.rd_New);
            this.Controls.Add(this.PrjCombo);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.TextBox10);
            this.Controls.Add(this.TextBox9);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.TextBox6);
            this.Controls.Add(this.TextBox4);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EngDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.Load += new System.EventHandler(this.EngDialog_Load);
            this.Panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnASave;
        internal System.Windows.Forms.CheckBox checkBox1;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox TextBox10;
        internal System.Windows.Forms.TextBox TextBox9;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox TextBox6;
        internal System.Windows.Forms.TextBox TextBox4;
        internal System.Windows.Forms.TextBox TextBox3;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ComboBox PrjCombo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.RadioButton rd_Last;
        private System.Windows.Forms.RadioButton rd_New;
        internal System.Windows.Forms.Button btnMSave;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.TextBox textBox14;
        internal System.Windows.Forms.TextBox textBox13;
        internal System.Windows.Forms.TextBox textBox12;
        internal System.Windows.Forms.TextBox textBox11;
        internal System.Windows.Forms.TextBox textBox8;
        internal System.Windows.Forms.TextBox textBox7;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rd_PIDAnalog;
        private System.Windows.Forms.RadioButton rd_PIDDigital;
        private System.Windows.Forms.Timer tmrBarcode;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Label label17;
        private System.Windows.Forms.ErrorProvider Erp1;
        internal System.Windows.Forms.TextBox txtbarcode;
        internal System.Windows.Forms.TextBox textBox5;
    }
}