namespace SistemaInasistencias
{
    partial class FCentralizador
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVerLista = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cBoxTurnos = new System.Windows.Forms.ComboBox();
            this.cBoxCarreras = new System.Windows.Forms.ComboBox();
            this.cBoxGestiones = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGVListaCargaHoraria = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.DGCDeHoras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCAHoras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreAsignatura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCNombreAula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCAsistencia = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGCIdInasistencia = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListaCargaHoraria)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVerLista);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.cBoxTurnos);
            this.groupBox1.Controls.Add(this.cBoxCarreras);
            this.groupBox1.Controls.Add(this.cBoxGestiones);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(852, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametros de Filtración";
            // 
            // btnVerLista
            // 
            this.btnVerLista.Location = new System.Drawing.Point(529, 45);
            this.btnVerLista.Name = "btnVerLista";
            this.btnVerLista.Size = new System.Drawing.Size(75, 23);
            this.btnVerLista.TabIndex = 4;
            this.btnVerLista.Text = "&Ver";
            this.btnVerLista.UseVisualStyleBackColor = true;
            this.btnVerLista.Click += new System.EventHandler(this.btnVerLista_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(67, 44);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(121, 20);
            this.dtpFecha.TabIndex = 2;
            // 
            // cBoxTurnos
            // 
            this.cBoxTurnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTurnos.FormattingEnabled = true;
            this.cBoxTurnos.Items.AddRange(new object[] {
            "Mañana",
            "Tarde"});
            this.cBoxTurnos.Location = new System.Drawing.Point(322, 44);
            this.cBoxTurnos.Name = "cBoxTurnos";
            this.cBoxTurnos.Size = new System.Drawing.Size(121, 21);
            this.cBoxTurnos.TabIndex = 3;
            // 
            // cBoxCarreras
            // 
            this.cBoxCarreras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCarreras.FormattingEnabled = true;
            this.cBoxCarreras.Location = new System.Drawing.Point(322, 17);
            this.cBoxCarreras.Name = "cBoxCarreras";
            this.cBoxCarreras.Size = new System.Drawing.Size(282, 21);
            this.cBoxCarreras.TabIndex = 1;
            // 
            // cBoxGestiones
            // 
            this.cBoxGestiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxGestiones.FormattingEnabled = true;
            this.cBoxGestiones.Location = new System.Drawing.Point(67, 17);
            this.cBoxGestiones.Name = "cBoxGestiones";
            this.cBoxGestiones.Size = new System.Drawing.Size(121, 21);
            this.cBoxGestiones.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Turno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Carrera";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGVListaCargaHoraria);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(852, 260);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado ";
            // 
            // dtGVListaCargaHoraria
            // 
            this.dtGVListaCargaHoraria.AllowUserToAddRows = false;
            this.dtGVListaCargaHoraria.AllowUserToDeleteRows = false;
            this.dtGVListaCargaHoraria.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVListaCargaHoraria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVListaCargaHoraria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVListaCargaHoraria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCDeHoras,
            this.DGCAHoras,
            this.DGCNombreCompleto,
            this.DGCNombreAsignatura,
            this.DGCNombreAula,
            this.DGCAsistencia,
            this.DGCIdInasistencia});
            this.dtGVListaCargaHoraria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVListaCargaHoraria.Location = new System.Drawing.Point(3, 16);
            this.dtGVListaCargaHoraria.MultiSelect = false;
            this.dtGVListaCargaHoraria.Name = "dtGVListaCargaHoraria";
            this.dtGVListaCargaHoraria.RowHeadersVisible = false;
            this.dtGVListaCargaHoraria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVListaCargaHoraria.Size = new System.Drawing.Size(846, 241);
            this.dtGVListaCargaHoraria.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnReporte);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 334);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 44);
            this.panel1.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(673, 11);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReporte.Location = new System.Drawing.Point(754, 11);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(75, 23);
            this.btnReporte.TabIndex = 1;
            this.btnReporte.Text = "&Reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // DGCDeHoras
            // 
            this.DGCDeHoras.DataPropertyName = "DeHoras";
            this.DGCDeHoras.HeaderText = "De";
            this.DGCDeHoras.Name = "DGCDeHoras";
            this.DGCDeHoras.ReadOnly = true;
            this.DGCDeHoras.ToolTipText = "Hora de Ingreso";
            // 
            // DGCAHoras
            // 
            this.DGCAHoras.DataPropertyName = "AHoras";
            this.DGCAHoras.HeaderText = "A";
            this.DGCAHoras.Name = "DGCAHoras";
            this.DGCAHoras.ReadOnly = true;
            // 
            // DGCNombreCompleto
            // 
            this.DGCNombreCompleto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGCNombreCompleto.DataPropertyName = "NombreCompleto";
            this.DGCNombreCompleto.HeaderText = "Docente";
            this.DGCNombreCompleto.Name = "DGCNombreCompleto";
            this.DGCNombreCompleto.ReadOnly = true;
            // 
            // DGCNombreAsignatura
            // 
            this.DGCNombreAsignatura.DataPropertyName = "NombreAsignatura";
            this.DGCNombreAsignatura.HeaderText = "Materia";
            this.DGCNombreAsignatura.Name = "DGCNombreAsignatura";
            this.DGCNombreAsignatura.ReadOnly = true;
            this.DGCNombreAsignatura.Width = 200;
            // 
            // DGCNombreAula
            // 
            this.DGCNombreAula.DataPropertyName = "NombreAula";
            this.DGCNombreAula.HeaderText = "Aula";
            this.DGCNombreAula.Name = "DGCNombreAula";
            this.DGCNombreAula.ReadOnly = true;
            // 
            // DGCAsistencia
            // 
            this.DGCAsistencia.DataPropertyName = "Asistencia";
            this.DGCAsistencia.FalseValue = "False";
            this.DGCAsistencia.HeaderText = "?";
            this.DGCAsistencia.Name = "DGCAsistencia";
            this.DGCAsistencia.ToolTipText = "Desmarque para confirmar la inasistencia del Docente";
            this.DGCAsistencia.TrueValue = "True";
            // 
            // DGCIdInasistencia
            // 
            this.DGCIdInasistencia.HeaderText = "Tipo Inasistencia";
            this.DGCIdInasistencia.Name = "DGCIdInasistencia";
            // 
            // FCentralizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 378);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FCentralizador";
            this.Text = "Sistema de Control de Inasistencias";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVListaCargaHoraria)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cBoxTurnos;
        private System.Windows.Forms.ComboBox cBoxCarreras;
        private System.Windows.Forms.ComboBox cBoxGestiones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtGVListaCargaHoraria;
        private System.Windows.Forms.Button btnVerLista;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCDeHoras;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCAHoras;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreAsignatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCNombreAula;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCAsistencia;
        private System.Windows.Forms.DataGridViewComboBoxColumn DGCIdInasistencia;
    }
}

