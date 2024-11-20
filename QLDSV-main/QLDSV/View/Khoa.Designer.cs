namespace QLDSV.View
{
    partial class Khoa
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
            this.timkiem = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtten = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewkhoa = new System.Windows.Forms.DataGridView();
            this.txtma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewkhoa)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.timkiem);
            this.panel1.Controls.Add(this.close);
            this.panel1.Controls.Add(this.delete);
            this.panel1.Controls.Add(this.save);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtten);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dataGridViewkhoa);
            this.panel1.Controls.Add(this.txtma);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(41, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 506);
            this.panel1.TabIndex = 0;
            // 
            // timkiem
            // 
            this.timkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timkiem.Location = new System.Drawing.Point(498, 91);
            this.timkiem.Name = "timkiem";
            this.timkiem.Size = new System.Drawing.Size(106, 38);
            this.timkiem.TabIndex = 10;
            this.timkiem.Text = "Tìm kiếm";
            this.timkiem.UseVisualStyleBackColor = true;
            this.timkiem.Click += new System.EventHandler(this.timkiem_Click);
            // 
            // close
            // 
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Location = new System.Drawing.Point(562, 226);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(106, 38);
            this.close.TabIndex = 9;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // delete
            // 
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.Location = new System.Drawing.Point(389, 226);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(106, 38);
            this.delete.TabIndex = 8;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click_1);
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.Location = new System.Drawing.Point(226, 226);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(106, 38);
            this.save.TabIndex = 7;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(220, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "QUẢN LÝ KHOA";
            // 
            // txtten
            // 
            this.txtten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtten.Location = new System.Drawing.Point(196, 157);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(258, 27);
            this.txtten.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên khoa:";
            // 
            // dataGridViewkhoa
            // 
            this.dataGridViewkhoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewkhoa.Location = new System.Drawing.Point(39, 285);
            this.dataGridViewkhoa.Name = "dataGridViewkhoa";
            this.dataGridViewkhoa.RowHeadersWidth = 51;
            this.dataGridViewkhoa.RowTemplate.Height = 24;
            this.dataGridViewkhoa.Size = new System.Drawing.Size(629, 205);
            this.dataGridViewkhoa.TabIndex = 3;
            // 
            // txtma
            // 
            this.txtma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtma.Location = new System.Drawing.Point(196, 99);
            this.txtma.Name = "txtma";
            this.txtma.Size = new System.Drawing.Size(258, 27);
            this.txtma.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khoa:";
            // 
            // Khoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Khoa";
            this.Size = new System.Drawing.Size(792, 565);
            this.Load += new System.EventHandler(this.Khoa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewkhoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button timkiem;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtten;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewkhoa;
        private System.Windows.Forms.TextBox txtma;
        private System.Windows.Forms.Label label1;
    }
}
