namespace PdfMerge
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnAddDatei = new System.Windows.Forms.Button();
            this.txtBox_Ausgabeverzeichnis = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_changeAusgVerz = new System.Windows.Forms.Button();
            this.pictBox = new System.Windows.Forms.PictureBox();
            this.btn_AusgVerzAnw = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCreateLsg = new System.Windows.Forms.Button();
            this.btn_showLV_Level = new System.Windows.Forms.Button();
            this.txtBox_Zwischenspeicher = new System.Windows.Forms.TextBox();
            this.lbl_Zwischenspeicher = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBox_Vorlage = new System.Windows.Forms.TextBox();
            this.btn_Umschalten = new System.Windows.Forms.Button();
            this.lbl_Breite = new System.Windows.Forms.Label();
            this.lbl_Hoehe = new System.Windows.Forms.Label();
            this.txtBox_Hoehe = new System.Windows.Forms.TextBox();
            this.txtBox_Breite = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(63, 188);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(1151, 250);
            this.dgv.TabIndex = 0;
            // 
            // btnAddDatei
            // 
            this.btnAddDatei.Location = new System.Drawing.Point(63, 149);
            this.btnAddDatei.Name = "btnAddDatei";
            this.btnAddDatei.Size = new System.Drawing.Size(162, 23);
            this.btnAddDatei.TabIndex = 1;
            this.btnAddDatei.Text = "Datei hinzufügen";
            this.btnAddDatei.UseVisualStyleBackColor = true;
            this.btnAddDatei.Click += new System.EventHandler(this.btnAddPdf_Click);
            // 
            // txtBox_Ausgabeverzeichnis
            // 
            this.txtBox_Ausgabeverzeichnis.Location = new System.Drawing.Point(645, 107);
            this.txtBox_Ausgabeverzeichnis.Name = "txtBox_Ausgabeverzeichnis";
            this.txtBox_Ausgabeverzeichnis.Size = new System.Drawing.Size(569, 20);
            this.txtBox_Ausgabeverzeichnis.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(507, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "AusgabeVerzeichnis";
            // 
            // btn_changeAusgVerz
            // 
            this.btn_changeAusgVerz.Location = new System.Drawing.Point(510, 23);
            this.btn_changeAusgVerz.Name = "btn_changeAusgVerz";
            this.btn_changeAusgVerz.Size = new System.Drawing.Size(234, 24);
            this.btn_changeAusgVerz.TabIndex = 5;
            this.btn_changeAusgVerz.Text = "Ausgabeverzeichnis ändern";
            this.btn_changeAusgVerz.UseVisualStyleBackColor = true;
            this.btn_changeAusgVerz.Click += new System.EventHandler(this.btn_changeAusgVerz_Click);
            // 
            // pictBox
            // 
            this.pictBox.Location = new System.Drawing.Point(63, 12);
            this.pictBox.Name = "pictBox";
            this.pictBox.Size = new System.Drawing.Size(162, 94);
            this.pictBox.TabIndex = 6;
            this.pictBox.TabStop = false;
            // 
            // btn_AusgVerzAnw
            // 
            this.btn_AusgVerzAnw.Location = new System.Drawing.Point(773, 23);
            this.btn_AusgVerzAnw.Name = "btn_AusgVerzAnw";
            this.btn_AusgVerzAnw.Size = new System.Drawing.Size(109, 23);
            this.btn_AusgVerzAnw.TabIndex = 7;
            this.btn_AusgVerzAnw.Text = "anwenden";
            this.btn_AusgVerzAnw.UseVisualStyleBackColor = true;
            this.btn_AusgVerzAnw.Visible = false;
            this.btn_AusgVerzAnw.Click += new System.EventHandler(this.btn_AusgVerzAnw_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(1108, 159);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(106, 23);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "Los";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCreateLsg
            // 
            this.btnCreateLsg.Location = new System.Drawing.Point(938, 159);
            this.btnCreateLsg.Name = "btnCreateLsg";
            this.btnCreateLsg.Size = new System.Drawing.Size(164, 23);
            this.btnCreateLsg.TabIndex = 9;
            this.btnCreateLsg.Text = "erstelle LösungsWörter";
            this.btnCreateLsg.UseVisualStyleBackColor = true;
            this.btnCreateLsg.Click += new System.EventHandler(this.btnCreateLsg_Click);
            // 
            // btn_showLV_Level
            // 
            this.btn_showLV_Level.Location = new System.Drawing.Point(408, 149);
            this.btn_showLV_Level.Name = "btn_showLV_Level";
            this.btn_showLV_Level.Size = new System.Drawing.Size(119, 23);
            this.btn_showLV_Level.TabIndex = 10;
            this.btn_showLV_Level.Text = "zeige erstellte Level";
            this.btn_showLV_Level.UseVisualStyleBackColor = true;
            this.btn_showLV_Level.Click += new System.EventHandler(this.btn_showLV_Level_Click);
            // 
            // txtBox_Zwischenspeicher
            // 
            this.txtBox_Zwischenspeicher.Location = new System.Drawing.Point(645, 81);
            this.txtBox_Zwischenspeicher.Name = "txtBox_Zwischenspeicher";
            this.txtBox_Zwischenspeicher.Size = new System.Drawing.Size(569, 20);
            this.txtBox_Zwischenspeicher.TabIndex = 11;
            // 
            // lbl_Zwischenspeicher
            // 
            this.lbl_Zwischenspeicher.AutoSize = true;
            this.lbl_Zwischenspeicher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Zwischenspeicher.Location = new System.Drawing.Point(507, 82);
            this.lbl_Zwischenspeicher.Name = "lbl_Zwischenspeicher";
            this.lbl_Zwischenspeicher.Size = new System.Drawing.Size(118, 16);
            this.lbl_Zwischenspeicher.TabIndex = 12;
            this.lbl_Zwischenspeicher.Text = "ZwischenSpeicher";
            this.lbl_Zwischenspeicher.Click += new System.EventHandler(this.label2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(507, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Vorlage";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // txtBox_Vorlage
            // 
            this.txtBox_Vorlage.Location = new System.Drawing.Point(645, 52);
            this.txtBox_Vorlage.Name = "txtBox_Vorlage";
            this.txtBox_Vorlage.Size = new System.Drawing.Size(569, 20);
            this.txtBox_Vorlage.TabIndex = 14;
            // 
            // btn_Umschalten
            // 
            this.btn_Umschalten.Location = new System.Drawing.Point(266, 10);
            this.btn_Umschalten.Name = "btn_Umschalten";
            this.btn_Umschalten.Size = new System.Drawing.Size(139, 49);
            this.btn_Umschalten.TabIndex = 15;
            this.btn_Umschalten.Text = "umschalten auf Bilderzuschnitt";
            this.btn_Umschalten.UseVisualStyleBackColor = true;
            this.btn_Umschalten.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_Breite
            // 
            this.lbl_Breite.AutoSize = true;
            this.lbl_Breite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Breite.Location = new System.Drawing.Point(263, 62);
            this.lbl_Breite.Name = "lbl_Breite";
            this.lbl_Breite.Size = new System.Drawing.Size(43, 16);
            this.lbl_Breite.TabIndex = 16;
            this.lbl_Breite.Text = "Breite";
            this.lbl_Breite.Visible = false;
            // 
            // lbl_Hoehe
            // 
            this.lbl_Hoehe.AutoSize = true;
            this.lbl_Hoehe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Hoehe.Location = new System.Drawing.Point(263, 85);
            this.lbl_Hoehe.Name = "lbl_Hoehe";
            this.lbl_Hoehe.Size = new System.Drawing.Size(49, 16);
            this.lbl_Hoehe.TabIndex = 17;
            this.lbl_Hoehe.Text = "Hoehe";
            this.lbl_Hoehe.Visible = false;
            // 
            // txtBox_Hoehe
            // 
            this.txtBox_Hoehe.Location = new System.Drawing.Point(312, 84);
            this.txtBox_Hoehe.Name = "txtBox_Hoehe";
            this.txtBox_Hoehe.Size = new System.Drawing.Size(93, 20);
            this.txtBox_Hoehe.TabIndex = 18;
            this.txtBox_Hoehe.Visible = false;
            // 
            // txtBox_Breite
            // 
            this.txtBox_Breite.Location = new System.Drawing.Point(312, 61);
            this.txtBox_Breite.Name = "txtBox_Breite";
            this.txtBox_Breite.Size = new System.Drawing.Size(93, 20);
            this.txtBox_Breite.TabIndex = 19;
            this.txtBox_Breite.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 450);
            this.Controls.Add(this.txtBox_Breite);
            this.Controls.Add(this.txtBox_Hoehe);
            this.Controls.Add(this.lbl_Hoehe);
            this.Controls.Add(this.lbl_Breite);
            this.Controls.Add(this.btn_Umschalten);
            this.Controls.Add(this.txtBox_Vorlage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_Zwischenspeicher);
            this.Controls.Add(this.txtBox_Zwischenspeicher);
            this.Controls.Add(this.btn_showLV_Level);
            this.Controls.Add(this.btnCreateLsg);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btn_AusgVerzAnw);
            this.Controls.Add(this.pictBox);
            this.Controls.Add(this.btn_changeAusgVerz);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox_Ausgabeverzeichnis);
            this.Controls.Add(this.btnAddDatei);
            this.Controls.Add(this.dgv);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnAddDatei;
        private System.Windows.Forms.TextBox txtBox_Ausgabeverzeichnis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_changeAusgVerz;
        private System.Windows.Forms.PictureBox pictBox;
        private System.Windows.Forms.Button btn_AusgVerzAnw;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCreateLsg;
        private System.Windows.Forms.Button btn_showLV_Level;
        private System.Windows.Forms.TextBox txtBox_Zwischenspeicher;
        private System.Windows.Forms.Label lbl_Zwischenspeicher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBox_Vorlage;
        private System.Windows.Forms.Button btn_Umschalten;
        private System.Windows.Forms.Label lbl_Breite;
        private System.Windows.Forms.Label lbl_Hoehe;
        private System.Windows.Forms.TextBox txtBox_Hoehe;
        private System.Windows.Forms.TextBox txtBox_Breite;
    }
}

