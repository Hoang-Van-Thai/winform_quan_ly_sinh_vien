namespace QLDSV.View
{
    partial class Sinhvien
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tim = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.texttensv = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comlop = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewsv = new System.Windows.Forms.DataGridView();
            this.save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textmasv = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewsv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tim);
            this.panel1.Controls.Add(this.close);
            this.panel1.Controls.Add(this.delete);
            this.panel1.Controls.Add(this.texttensv);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comlop);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dataGridViewsv);
            this.panel1.Controls.Add(this.save);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textmasv);
            this.panel1.Location = new System.Drawing.Point(45, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 506);
            this.panel1.TabIndex = 0;
            // 
            // tim
            // 
            this.tim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(505, 63);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(122, 40);
            this.tim.TabIndex = 11;
            this.tim.Text = "Tìm kiếm";
            this.tim.UseVisualStyleBackColor = true;
            this.tim.Click += new System.EventHandler(this.tim_Click);
            // 
            // close
            // 
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Location = new System.Drawing.Point(641, 247);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(90, 40);
            this.close.TabIndex = 10;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // delete
            // 
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.Location = new System.Drawing.Point(505, 247);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(90, 40);
            this.delete.TabIndex = 9;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // texttensv
            // 
            this.texttensv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texttensv.Location = new System.Drawing.Point(243, 121);
            this.texttensv.Name = "texttensv";
            this.texttensv.Size = new System.Drawing.Size(214, 27);
            this.texttensv.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(226, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(330, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "THÔNG TIN SINH VIÊN";
            // 
            // comlop
            // 
            this.comlop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comlop.FormattingEnabled = true;
            this.comlop.Location = new System.Drawing.Point(243, 173);
            this.comlop.Name = "comlop";
            this.comlop.Size = new System.Drawing.Size(214, 28);
            this.comlop.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tên sinh viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lớp học:";
            // 
            // dataGridViewsv
            // 
            this.dataGridViewsv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewsv.Location = new System.Drawing.Point(74, 316);
            this.dataGridViewsv.Name = "dataGridViewsv";
            this.dataGridViewsv.RowHeadersWidth = 51;
            this.dataGridViewsv.RowTemplate.Height = 24;
            this.dataGridViewsv.Size = new System.Drawing.Size(657, 175);
            this.dataGridViewsv.TabIndex = 3;
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.Location = new System.Drawing.Point(367, 247);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(90, 40);
            this.save.TabIndex = 2;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã sinh viên:";
            // 
            // textmasv
            // 
            this.textmasv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textmasv.Location = new System.Drawing.Point(243, 72);
            this.textmasv.Name = "textmasv";
            this.textmasv.Size = new System.Drawing.Size(214, 27);
            this.textmasv.TabIndex = 0;
            // 
            // Sinhvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Sinhvien";
            this.Size = new System.Drawing.Size(912, 679);
            this.Load += new System.EventHandler(this.Sinhvien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewsv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewsv;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textmasv;
        private System.Windows.Forms.TextBox texttensv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comlop;
        private System.Windows.Forms.Button tim;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button delete;
    }
}
