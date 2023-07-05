namespace pPatronesDiseño
{
    partial class fMenu
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBaseDatos = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAdapter = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnMediator = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBaseDatos);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(31, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1056, 213);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conexión a Bases de Datos: Patrón Adapter y Patrón Mediator";
            // 
            // btnBaseDatos
            // 
            this.btnBaseDatos.BackColor = System.Drawing.Color.Navy;
            this.btnBaseDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaseDatos.ForeColor = System.Drawing.Color.White;
            this.btnBaseDatos.Location = new System.Drawing.Point(387, 64);
            this.btnBaseDatos.Margin = new System.Windows.Forms.Padding(4);
            this.btnBaseDatos.Name = "btnBaseDatos";
            this.btnBaseDatos.Size = new System.Drawing.Size(239, 76);
            this.btnBaseDatos.TabIndex = 5;
            this.btnBaseDatos.Text = "BASE DATOS";
            this.btnBaseDatos.UseVisualStyleBackColor = false;
            this.btnBaseDatos.Click += new System.EventHandler(this.btnBaseDatos_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAdapter);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(31, 244);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1056, 213);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Patrones estructurales";
            // 
            // btnAdapter
            // 
            this.btnAdapter.BackColor = System.Drawing.Color.Navy;
            this.btnAdapter.Enabled = false;
            this.btnAdapter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdapter.ForeColor = System.Drawing.Color.White;
            this.btnAdapter.Location = new System.Drawing.Point(387, 75);
            this.btnAdapter.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdapter.Name = "btnAdapter";
            this.btnAdapter.Size = new System.Drawing.Size(239, 76);
            this.btnAdapter.TabIndex = 0;
            this.btnAdapter.Text = "ADAPTER";
            this.btnAdapter.UseVisualStyleBackColor = false;
            this.btnAdapter.Click += new System.EventHandler(this.btnAdapter_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnMediator);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(31, 464);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1056, 213);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Patrones de comportamiento";
            // 
            // btnMediator
            // 
            this.btnMediator.BackColor = System.Drawing.Color.Navy;
            this.btnMediator.Enabled = false;
            this.btnMediator.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMediator.ForeColor = System.Drawing.Color.White;
            this.btnMediator.Location = new System.Drawing.Point(387, 51);
            this.btnMediator.Margin = new System.Windows.Forms.Padding(4);
            this.btnMediator.Name = "btnMediator";
            this.btnMediator.Size = new System.Drawing.Size(239, 74);
            this.btnMediator.TabIndex = 6;
            this.btnMediator.Text = "MEDIATOR";
            this.btnMediator.UseVisualStyleBackColor = false;
            this.btnMediator.Click += new System.EventHandler(this.btnMediator_Click);
            // 
            // fMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 690);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fMenu";
            this.Text = "fMenu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdapter;
        private System.Windows.Forms.Button btnBaseDatos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnMediator;
    }
}