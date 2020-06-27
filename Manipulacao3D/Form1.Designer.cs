namespace Manipulacao3D
{
    partial class FormOBJ
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
            this.picBoxPrincipal = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnAbrirOBJ = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabVista = new System.Windows.Forms.TabPage();
            this.gbVistas = new System.Windows.Forms.GroupBox();
            this.checkBoxVistas = new System.Windows.Forms.CheckBox();
            this.picBoxFrontal = new System.Windows.Forms.PictureBox();
            this.picBoxLateral = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picBoxSuperior = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxFaces = new System.Windows.Forms.CheckBox();
            this.tabProjecao = new System.Windows.Forms.TabPage();
            this.groupBoxProjecoes = new System.Windows.Forms.GroupBox();
            this.txtD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbPerspectiva = new System.Windows.Forms.RadioButton();
            this.rbGabinete = new System.Windows.Forms.RadioButton();
            this.rbCavaleira = new System.Windows.Forms.RadioButton();
            this.rbParalela = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPrincipal)).BeginInit();
            this.tabs.SuspendLayout();
            this.tabVista.SuspendLayout();
            this.gbVistas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFrontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLateral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSuperior)).BeginInit();
            this.tabProjecao.SuspendLayout();
            this.groupBoxProjecoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBoxPrincipal
            // 
            this.picBoxPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxPrincipal.Location = new System.Drawing.Point(12, 12);
            this.picBoxPrincipal.Name = "picBoxPrincipal";
            this.picBoxPrincipal.Size = new System.Drawing.Size(582, 560);
            this.picBoxPrincipal.TabIndex = 0;
            this.picBoxPrincipal.TabStop = false;
            this.picBoxPrincipal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picBoxPrincipal_MouseClick_1);
            this.picBoxPrincipal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoxPrincipal_MouseMove);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // btnAbrirOBJ
            // 
            this.btnAbrirOBJ.Location = new System.Drawing.Point(12, 578);
            this.btnAbrirOBJ.Name = "btnAbrirOBJ";
            this.btnAbrirOBJ.Size = new System.Drawing.Size(75, 23);
            this.btnAbrirOBJ.TabIndex = 1;
            this.btnAbrirOBJ.Text = "Abrir OBJ";
            this.btnAbrirOBJ.UseVisualStyleBackColor = true;
            this.btnAbrirOBJ.Click += new System.EventHandler(this.btnAbrirOBJ_Click);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabVista);
            this.tabs.Controls.Add(this.tabProjecao);
            this.tabs.Location = new System.Drawing.Point(600, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(442, 560);
            this.tabs.TabIndex = 2;
            // 
            // tabVista
            // 
            this.tabVista.Controls.Add(this.gbVistas);
            this.tabVista.Controls.Add(this.checkBoxFaces);
            this.tabVista.Location = new System.Drawing.Point(4, 22);
            this.tabVista.Name = "tabVista";
            this.tabVista.Padding = new System.Windows.Forms.Padding(3);
            this.tabVista.Size = new System.Drawing.Size(434, 534);
            this.tabVista.TabIndex = 0;
            this.tabVista.Text = "Vistas";
            this.tabVista.UseVisualStyleBackColor = true;
            // 
            // gbVistas
            // 
            this.gbVistas.BackColor = System.Drawing.Color.Transparent;
            this.gbVistas.Controls.Add(this.checkBoxVistas);
            this.gbVistas.Controls.Add(this.picBoxFrontal);
            this.gbVistas.Controls.Add(this.picBoxLateral);
            this.gbVistas.Controls.Add(this.label3);
            this.gbVistas.Controls.Add(this.picBoxSuperior);
            this.gbVistas.Controls.Add(this.label2);
            this.gbVistas.Controls.Add(this.label1);
            this.gbVistas.Location = new System.Drawing.Point(6, 65);
            this.gbVistas.Name = "gbVistas";
            this.gbVistas.Size = new System.Drawing.Size(422, 463);
            this.gbVistas.TabIndex = 8;
            this.gbVistas.TabStop = false;
            this.gbVistas.Text = "Tipos de vista";
            // 
            // checkBoxVistas
            // 
            this.checkBoxVistas.AutoSize = true;
            this.checkBoxVistas.Location = new System.Drawing.Point(9, 19);
            this.checkBoxVistas.Name = "checkBoxVistas";
            this.checkBoxVistas.Size = new System.Drawing.Size(54, 17);
            this.checkBoxVistas.TabIndex = 6;
            this.checkBoxVistas.Text = "Vistas";
            this.checkBoxVistas.UseVisualStyleBackColor = true;
            this.checkBoxVistas.CheckedChanged += new System.EventHandler(this.checkBoxVistas_CheckedChanged);
            // 
            // picBoxFrontal
            // 
            this.picBoxFrontal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxFrontal.Location = new System.Drawing.Point(6, 55);
            this.picBoxFrontal.Name = "picBoxFrontal";
            this.picBoxFrontal.Size = new System.Drawing.Size(202, 190);
            this.picBoxFrontal.TabIndex = 0;
            this.picBoxFrontal.TabStop = false;
            // 
            // picBoxLateral
            // 
            this.picBoxLateral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxLateral.Location = new System.Drawing.Point(214, 55);
            this.picBoxLateral.Name = "picBoxLateral";
            this.picBoxLateral.Size = new System.Drawing.Size(202, 190);
            this.picBoxLateral.TabIndex = 1;
            this.picBoxLateral.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lateral";
            // 
            // picBoxSuperior
            // 
            this.picBoxSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxSuperior.Location = new System.Drawing.Point(6, 266);
            this.picBoxSuperior.Name = "picBoxSuperior";
            this.picBoxSuperior.Size = new System.Drawing.Size(202, 190);
            this.picBoxSuperior.TabIndex = 2;
            this.picBoxSuperior.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Superior";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Frontal";
            // 
            // checkBoxFaces
            // 
            this.checkBoxFaces.AutoSize = true;
            this.checkBoxFaces.Location = new System.Drawing.Point(6, 6);
            this.checkBoxFaces.Name = "checkBoxFaces";
            this.checkBoxFaces.Size = new System.Drawing.Size(92, 17);
            this.checkBoxFaces.TabIndex = 7;
            this.checkBoxFaces.Text = "Ocultar Faces";
            this.checkBoxFaces.UseVisualStyleBackColor = true;
            this.checkBoxFaces.CheckedChanged += new System.EventHandler(this.checkBoxFaces_CheckedChanged);
            // 
            // tabProjecao
            // 
            this.tabProjecao.Controls.Add(this.groupBoxProjecoes);
            this.tabProjecao.Location = new System.Drawing.Point(4, 22);
            this.tabProjecao.Name = "tabProjecao";
            this.tabProjecao.Padding = new System.Windows.Forms.Padding(3);
            this.tabProjecao.Size = new System.Drawing.Size(434, 534);
            this.tabProjecao.TabIndex = 1;
            this.tabProjecao.Text = "Projecções";
            this.tabProjecao.UseVisualStyleBackColor = true;
            // 
            // groupBoxProjecoes
            // 
            this.groupBoxProjecoes.Controls.Add(this.txtD);
            this.groupBoxProjecoes.Controls.Add(this.label4);
            this.groupBoxProjecoes.Controls.Add(this.rbPerspectiva);
            this.groupBoxProjecoes.Controls.Add(this.rbGabinete);
            this.groupBoxProjecoes.Controls.Add(this.rbCavaleira);
            this.groupBoxProjecoes.Controls.Add(this.rbParalela);
            this.groupBoxProjecoes.Location = new System.Drawing.Point(6, 20);
            this.groupBoxProjecoes.Name = "groupBoxProjecoes";
            this.groupBoxProjecoes.Size = new System.Drawing.Size(202, 134);
            this.groupBoxProjecoes.TabIndex = 0;
            this.groupBoxProjecoes.TabStop = false;
            this.groupBoxProjecoes.Text = "Projeções";
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(42, 105);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(33, 20);
            this.txtD.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "D";
            // 
            // rbPerspectiva
            // 
            this.rbPerspectiva.AutoSize = true;
            this.rbPerspectiva.Location = new System.Drawing.Point(6, 88);
            this.rbPerspectiva.Name = "rbPerspectiva";
            this.rbPerspectiva.Size = new System.Drawing.Size(81, 17);
            this.rbPerspectiva.TabIndex = 3;
            this.rbPerspectiva.Text = "Perspectiva";
            this.rbPerspectiva.UseVisualStyleBackColor = true;
            // 
            // rbGabinete
            // 
            this.rbGabinete.AutoSize = true;
            this.rbGabinete.Location = new System.Drawing.Point(6, 65);
            this.rbGabinete.Name = "rbGabinete";
            this.rbGabinete.Size = new System.Drawing.Size(68, 17);
            this.rbGabinete.TabIndex = 2;
            this.rbGabinete.Text = "Gabinete";
            this.rbGabinete.UseVisualStyleBackColor = true;
            // 
            // rbCavaleira
            // 
            this.rbCavaleira.AutoSize = true;
            this.rbCavaleira.Location = new System.Drawing.Point(6, 42);
            this.rbCavaleira.Name = "rbCavaleira";
            this.rbCavaleira.Size = new System.Drawing.Size(69, 17);
            this.rbCavaleira.TabIndex = 1;
            this.rbCavaleira.Text = "Cavaleira";
            this.rbCavaleira.UseVisualStyleBackColor = true;
            this.rbCavaleira.CheckedChanged += new System.EventHandler(this.rbCavaleira_CheckedChanged);
            // 
            // rbParalela
            // 
            this.rbParalela.AutoSize = true;
            this.rbParalela.Checked = true;
            this.rbParalela.Location = new System.Drawing.Point(6, 19);
            this.rbParalela.Name = "rbParalela";
            this.rbParalela.Size = new System.Drawing.Size(63, 17);
            this.rbParalela.TabIndex = 0;
            this.rbParalela.TabStop = true;
            this.rbParalela.Text = "Paralela";
            this.rbParalela.UseVisualStyleBackColor = true;
            // 
            // FormOBJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 613);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.btnAbrirOBJ);
            this.Controls.Add(this.picBoxPrincipal);
            this.Name = "FormOBJ";
            this.Text = "Manipulação .OBJ";
            this.Load += new System.EventHandler(this.FormOBJ_Load);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.picBoxPrincial_MouseWheel);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPrincipal)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabVista.ResumeLayout(false);
            this.tabVista.PerformLayout();
            this.gbVistas.ResumeLayout(false);
            this.gbVistas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFrontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLateral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSuperior)).EndInit();
            this.tabProjecao.ResumeLayout(false);
            this.groupBoxProjecoes.ResumeLayout(false);
            this.groupBoxProjecoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxPrincipal;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnAbrirOBJ;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabVista;
        private System.Windows.Forms.TabPage tabProjecao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBoxSuperior;
        private System.Windows.Forms.PictureBox picBoxLateral;
        private System.Windows.Forms.PictureBox picBoxFrontal;
        private System.Windows.Forms.CheckBox checkBoxVistas;
        private System.Windows.Forms.GroupBox groupBoxProjecoes;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbPerspectiva;
        private System.Windows.Forms.RadioButton rbGabinete;
        private System.Windows.Forms.RadioButton rbCavaleira;
        private System.Windows.Forms.RadioButton rbParalela;
        private System.Windows.Forms.CheckBox checkBoxFaces;
        private System.Windows.Forms.GroupBox gbVistas;
    }
}

