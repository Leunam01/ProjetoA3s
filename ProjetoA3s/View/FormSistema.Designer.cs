namespace ProjetoA3s.View
{
    partial class FormSistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSistema));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAgenda = new System.Windows.Forms.DataGridView();
            this.Tutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Animal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRegistrarTutor = new System.Windows.Forms.Button();
            this.btnVerTutores = new System.Windows.Forms.Button();
            this.btnRegistrarAnimal = new System.Windows.Forms.Button();
            this.btnVerAnimais = new System.Windows.Forms.Button();
            this.btnAgendar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgenda)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SpringGreen;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 10);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(105, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sistema da Clinica Veterinária";
            // 
            // dgvAgenda
            // 
            this.dgvAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tutor,
            this.Animal,
            this.Data,
            this.Observacao});
            this.dgvAgenda.Location = new System.Drawing.Point(12, 95);
            this.dgvAgenda.Name = "dgvAgenda";
            this.dgvAgenda.Size = new System.Drawing.Size(597, 260);
            this.dgvAgenda.TabIndex = 4;
            // 
            // Tutor
            // 
            this.Tutor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tutor.HeaderText = "Tutor";
            this.Tutor.Name = "Tutor";
            this.Tutor.Width = 64;
            // 
            // Animal
            // 
            this.Animal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Animal.HeaderText = "Animal";
            this.Animal.Name = "Animal";
            this.Animal.Width = 78;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            // 
            // Observacao
            // 
            this.Observacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Observacao.HeaderText = "Observação";
            this.Observacao.Name = "Observacao";
            this.Observacao.Width = 113;
            // 
            // btnRegistrarTutor
            // 
            this.btnRegistrarTutor.Location = new System.Drawing.Point(12, 372);
            this.btnRegistrarTutor.Name = "btnRegistrarTutor";
            this.btnRegistrarTutor.Size = new System.Drawing.Size(90, 47);
            this.btnRegistrarTutor.TabIndex = 5;
            this.btnRegistrarTutor.Text = "Registrar Tutor";
            this.btnRegistrarTutor.UseVisualStyleBackColor = true;
            this.btnRegistrarTutor.Click += new System.EventHandler(this.btnRegistrarTutor_Click);
            // 
            // btnVerTutores
            // 
            this.btnVerTutores.Location = new System.Drawing.Point(12, 425);
            this.btnVerTutores.Name = "btnVerTutores";
            this.btnVerTutores.Size = new System.Drawing.Size(90, 47);
            this.btnVerTutores.TabIndex = 6;
            this.btnVerTutores.Text = "Ver tutores";
            this.btnVerTutores.UseVisualStyleBackColor = true;
            this.btnVerTutores.Click += new System.EventHandler(this.btnVerTutores_Click);
            // 
            // btnRegistrarAnimal
            // 
            this.btnRegistrarAnimal.Location = new System.Drawing.Point(519, 372);
            this.btnRegistrarAnimal.Name = "btnRegistrarAnimal";
            this.btnRegistrarAnimal.Size = new System.Drawing.Size(90, 47);
            this.btnRegistrarAnimal.TabIndex = 7;
            this.btnRegistrarAnimal.Text = "Registrar Animal";
            this.btnRegistrarAnimal.UseVisualStyleBackColor = true;
            this.btnRegistrarAnimal.Click += new System.EventHandler(this.btnRegistrarAnimal_Click);
            // 
            // btnVerAnimais
            // 
            this.btnVerAnimais.Location = new System.Drawing.Point(519, 425);
            this.btnVerAnimais.Name = "btnVerAnimais";
            this.btnVerAnimais.Size = new System.Drawing.Size(90, 47);
            this.btnVerAnimais.TabIndex = 8;
            this.btnVerAnimais.Text = "Ver Animais";
            this.btnVerAnimais.UseVisualStyleBackColor = true;
            this.btnVerAnimais.Click += new System.EventHandler(this.btnVerAnimais_Click);
            // 
            // btnAgendar
            // 
            this.btnAgendar.Location = new System.Drawing.Point(247, 372);
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Size = new System.Drawing.Size(119, 47);
            this.btnAgendar.TabIndex = 9;
            this.btnAgendar.Text = "Novo Agendamento";
            this.btnAgendar.UseVisualStyleBackColor = true;
            this.btnAgendar.Click += new System.EventHandler(this.btnAgendar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(233, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Agendamentos";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(192, 425);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(119, 47);
            this.btnExcluir.TabIndex = 11;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click_1);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Transparent;
            this.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.Location = new System.Drawing.Point(587, 10);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(34, 38);
            this.btnSair.TabIndex = 12;
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(319, 425);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(119, 47);
            this.btnAtualizar.TabIndex = 13;
            this.btnAtualizar.Text = "Atualizar tabela";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // FormSistema
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(621, 502);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAgendar);
            this.Controls.Add(this.btnVerAnimais);
            this.Controls.Add(this.btnRegistrarAnimal);
            this.Controls.Add(this.btnVerTutores);
            this.Controls.Add(this.btnRegistrarTutor);
            this.Controls.Add(this.dgvAgenda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSistema";
            this.Load += new System.EventHandler(this.FormSistema_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAgenda;
        private System.Windows.Forms.Button btnRegistrarTutor;
        private System.Windows.Forms.Button btnVerTutores;
        private System.Windows.Forms.Button btnRegistrarAnimal;
        private System.Windows.Forms.Button btnVerAnimais;
        private System.Windows.Forms.Button btnAgendar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Animal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnAtualizar;
    }
}