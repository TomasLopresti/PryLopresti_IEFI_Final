namespace PryLopresti_IEFI_Final
{
    partial class frmTareasAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTareasAdmin));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliminarLugar = new System.Windows.Forms.Button();
            this.dgvLugares = new System.Windows.Forms.DataGridView();
            this.btnAgregrarLugar = new System.Windows.Forms.Button();
            this.txtLugares = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminarTarea = new System.Windows.Forms.Button();
            this.dgvTareas = new System.Windows.Forms.DataGridView();
            this.txtTareas = new System.Windows.Forms.TextBox();
            this.btnAgregrarTarea = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLugares)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBox2.Controls.Add(this.btnEliminarLugar);
            this.groupBox2.Controls.Add(this.dgvLugares);
            this.groupBox2.Controls.Add(this.btnAgregrarLugar);
            this.groupBox2.Controls.Add(this.txtLugares);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox2.Location = new System.Drawing.Point(304, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 354);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agregar Lugar:";
            // 
            // btnEliminarLugar
            // 
            this.btnEliminarLugar.Location = new System.Drawing.Point(204, 54);
            this.btnEliminarLugar.Name = "btnEliminarLugar";
            this.btnEliminarLugar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarLugar.TabIndex = 7;
            this.btnEliminarLugar.Text = "Eliminar";
            this.btnEliminarLugar.UseVisualStyleBackColor = true;
            this.btnEliminarLugar.Click += new System.EventHandler(this.btnEliminarLugar_Click);
            // 
            // dgvLugares
            // 
            this.dgvLugares.AllowUserToAddRows = false;
            this.dgvLugares.AllowUserToDeleteRows = false;
            this.dgvLugares.AllowUserToResizeColumns = false;
            this.dgvLugares.AllowUserToResizeRows = false;
            this.dgvLugares.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLugares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLugares.Location = new System.Drawing.Point(6, 51);
            this.dgvLugares.MultiSelect = false;
            this.dgvLugares.Name = "dgvLugares";
            this.dgvLugares.ReadOnly = true;
            this.dgvLugares.RowHeadersVisible = false;
            this.dgvLugares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLugares.Size = new System.Drawing.Size(192, 271);
            this.dgvLugares.TabIndex = 6;
            this.dgvLugares.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLugares_CellClick);
            // 
            // btnAgregrarLugar
            // 
            this.btnAgregrarLugar.Location = new System.Drawing.Point(204, 25);
            this.btnAgregrarLugar.Name = "btnAgregrarLugar";
            this.btnAgregrarLugar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregrarLugar.TabIndex = 7;
            this.btnAgregrarLugar.Text = "Agregar";
            this.btnAgregrarLugar.UseVisualStyleBackColor = true;
            this.btnAgregrarLugar.Click += new System.EventHandler(this.btnAgregrarLugar_Click);
            // 
            // txtLugares
            // 
            this.txtLugares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLugares.Location = new System.Drawing.Point(6, 25);
            this.txtLugares.Name = "txtLugares";
            this.txtLugares.Size = new System.Drawing.Size(192, 20);
            this.txtLugares.TabIndex = 1;
            this.txtLugares.TextChanged += new System.EventHandler(this.txtLugares_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBox1.Controls.Add(this.btnEliminarTarea);
            this.groupBox1.Controls.Add(this.dgvTareas);
            this.groupBox1.Controls.Add(this.txtTareas);
            this.groupBox1.Controls.Add(this.btnAgregrarTarea);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(5, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 354);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Tarea:";
            // 
            // btnEliminarTarea
            // 
            this.btnEliminarTarea.Location = new System.Drawing.Point(205, 52);
            this.btnEliminarTarea.Name = "btnEliminarTarea";
            this.btnEliminarTarea.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarTarea.TabIndex = 6;
            this.btnEliminarTarea.Text = "Eliminar";
            this.btnEliminarTarea.UseVisualStyleBackColor = true;
            this.btnEliminarTarea.Click += new System.EventHandler(this.btnEliminarTarea_Click);
            // 
            // dgvTareas
            // 
            this.dgvTareas.AllowUserToAddRows = false;
            this.dgvTareas.AllowUserToDeleteRows = false;
            this.dgvTareas.AllowUserToResizeColumns = false;
            this.dgvTareas.AllowUserToResizeRows = false;
            this.dgvTareas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTareas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTareas.Location = new System.Drawing.Point(6, 48);
            this.dgvTareas.MultiSelect = false;
            this.dgvTareas.Name = "dgvTareas";
            this.dgvTareas.ReadOnly = true;
            this.dgvTareas.RowHeadersVisible = false;
            this.dgvTareas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTareas.Size = new System.Drawing.Size(192, 271);
            this.dgvTareas.TabIndex = 5;
            this.dgvTareas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTareas_CellClick);
            // 
            // txtTareas
            // 
            this.txtTareas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTareas.Location = new System.Drawing.Point(6, 22);
            this.txtTareas.Name = "txtTareas";
            this.txtTareas.Size = new System.Drawing.Size(192, 20);
            this.txtTareas.TabIndex = 0;
            this.txtTareas.TextChanged += new System.EventHandler(this.txtTareas_TextChanged);
            // 
            // btnAgregrarTarea
            // 
            this.btnAgregrarTarea.Location = new System.Drawing.Point(204, 22);
            this.btnAgregrarTarea.Name = "btnAgregrarTarea";
            this.btnAgregrarTarea.Size = new System.Drawing.Size(75, 23);
            this.btnAgregrarTarea.TabIndex = 4;
            this.btnAgregrarTarea.Text = "Agregar";
            this.btnAgregrarTarea.UseVisualStyleBackColor = true;
            this.btnAgregrarTarea.Click += new System.EventHandler(this.btnAgregrarTarea_Click);
            // 
            // frmTareasAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(603, 366);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTareasAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga De Datos";
            this.Load += new System.EventHandler(this.frmTareasAdmin_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLugares)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEliminarLugar;
        private System.Windows.Forms.DataGridView dgvLugares;
        private System.Windows.Forms.Button btnAgregrarLugar;
        private System.Windows.Forms.TextBox txtLugares;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEliminarTarea;
        private System.Windows.Forms.DataGridView dgvTareas;
        private System.Windows.Forms.TextBox txtTareas;
        private System.Windows.Forms.Button btnAgregrarTarea;
    }
}