namespace SistemaInasistencias
{
    partial class FAutenticacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAutenticacion));
            this.label5 = new System.Windows.Forms.Label();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bAceptar = new System.Windows.Forms.Button();
            this.tBContrasena = new System.Windows.Forms.TextBox();
            this.tBNombreUsuario = new System.Windows.Forms.TextBox();
            this.tBBaseDatos = new System.Windows.Forms.TextBox();
            this.tBServidor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(410, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Ingrese la información solicitada para autenticarse ante el sistema e ingresar al" +
                " mismo.\r\n";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancelar.Location = new System.Drawing.Point(335, 120);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(75, 23);
            this.bCancelar.TabIndex = 20;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bAceptar
            // 
            this.bAceptar.Location = new System.Drawing.Point(254, 120);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(75, 23);
            this.bAceptar.TabIndex = 19;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // tBContrasena
            // 
            this.tBContrasena.Location = new System.Drawing.Point(260, 78);
            this.tBContrasena.Name = "tBContrasena";
            this.tBContrasena.Size = new System.Drawing.Size(150, 20);
            this.tBContrasena.TabIndex = 18;
            this.tBContrasena.UseSystemPasswordChar = true;
            this.tBContrasena.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBNombreUsuario_KeyDown);
            // 
            // tBNombreUsuario
            // 
            this.tBNombreUsuario.Location = new System.Drawing.Point(260, 54);
            this.tBNombreUsuario.Name = "tBNombreUsuario";
            this.tBNombreUsuario.Size = new System.Drawing.Size(150, 20);
            this.tBNombreUsuario.TabIndex = 17;
            this.tBNombreUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBNombreUsuario_KeyDown);
            // 
            // tBBaseDatos
            // 
            this.tBBaseDatos.Location = new System.Drawing.Point(160, 63);
            this.tBBaseDatos.Name = "tBBaseDatos";
            this.tBBaseDatos.ReadOnly = true;
            this.tBBaseDatos.Size = new System.Drawing.Size(250, 20);
            this.tBBaseDatos.TabIndex = 16;
            this.tBBaseDatos.Visible = false;
            // 
            // tBServidor
            // 
            this.tBServidor.Location = new System.Drawing.Point(160, 37);
            this.tBServidor.Name = "tBServidor";
            this.tBServidor.ReadOnly = true;
            this.tBServidor.Size = new System.Drawing.Size(250, 20);
            this.tBServidor.TabIndex = 15;
            this.tBServidor.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Base de datos";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Servidor";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nombre de usuario (login)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // FAutenticacion
            // 
            this.AcceptButton = this.bAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancelar;
            this.ClientSize = new System.Drawing.Size(432, 169);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.tBContrasena);
            this.Controls.Add(this.tBNombreUsuario);
            this.Controls.Add(this.tBBaseDatos);
            this.Controls.Add(this.tBServidor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FAutenticacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autenticación";
            this.Load += new System.EventHandler(this.FAutenticacion_Load);
            this.Shown += new System.EventHandler(this.FAutenticacion_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.TextBox tBContrasena;
        private System.Windows.Forms.TextBox tBNombreUsuario;
        private System.Windows.Forms.TextBox tBBaseDatos;
        private System.Windows.Forms.TextBox tBServidor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}