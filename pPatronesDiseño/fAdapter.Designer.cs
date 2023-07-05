namespace pPatronesDiseño
{
    partial class fAdapter
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
            this.btnAdapter = new System.Windows.Forms.Button();
            this.grdEmpleados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdapter
            // 
            this.btnAdapter.BackColor = System.Drawing.Color.Navy;
            this.btnAdapter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdapter.ForeColor = System.Drawing.Color.White;
            this.btnAdapter.Location = new System.Drawing.Point(286, 47);
            this.btnAdapter.Name = "btnAdapter";
            this.btnAdapter.Size = new System.Drawing.Size(179, 62);
            this.btnAdapter.TabIndex = 1;
            this.btnAdapter.Text = "ADAPTER";
            this.btnAdapter.UseVisualStyleBackColor = false;
            this.btnAdapter.Click += new System.EventHandler(this.btnAdapter_Click);
            // 
            // grdEmpleados
            // 
            this.grdEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEmpleados.Location = new System.Drawing.Point(34, 155);
            this.grdEmpleados.Name = "grdEmpleados";
            this.grdEmpleados.Size = new System.Drawing.Size(742, 150);
            this.grdEmpleados.TabIndex = 2;
            // 
            // fAdapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grdEmpleados);
            this.Controls.Add(this.btnAdapter);
            this.Name = "fAdapter";
            this.Text = "fAdapter";
            ((System.ComponentModel.ISupportInitialize)(this.grdEmpleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdapter;
        private System.Windows.Forms.DataGridView grdEmpleados;
    }
}