namespace ProyectoFinalDemo.vistas
{
    partial class GestionCatalogosForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCategorias = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCatSave = new System.Windows.Forms.Button();
            this.btnCatDel = new System.Windows.Forms.Button();
            this.tabCondiciones = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCondSave = new System.Windows.Forms.Button();
            this.btnCondDel = new System.Windows.Forms.Button();
            this.tabEstados = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEdoSave = new System.Windows.Forms.Button();
            this.btnEdoDel = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvCats = new System.Windows.Forms.DataGridView();
            this.catID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEdos = new System.Windows.Forms.DataGridView();
            this.edoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edoNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvConds = new System.Windows.Forms.DataGridView();
            this.condID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabCategorias.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabCondiciones.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tabEstados.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConds)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvCats, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvEdos, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgvConds, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 361);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(286, 174);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCategorias);
            this.tabControl1.Controls.Add(this.tabCondiciones);
            this.tabControl1.Controls.Add(this.tabEstados);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(280, 63);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCategorias
            // 
            this.tabCategorias.Controls.Add(this.tableLayoutPanel4);
            this.tabCategorias.Location = new System.Drawing.Point(4, 25);
            this.tabCategorias.Name = "tabCategorias";
            this.tabCategorias.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategorias.Size = new System.Drawing.Size(272, 34);
            this.tabCategorias.TabIndex = 0;
            this.tabCategorias.Text = "Categorias";
            this.tabCategorias.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel4.Controls.Add(this.btnCatSave, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnCatDel, 3, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(266, 28);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // btnCatSave
            // 
            this.btnCatSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCatSave.Location = new System.Drawing.Point(13, 3);
            this.btnCatSave.Name = "btnCatSave";
            this.btnCatSave.Size = new System.Drawing.Size(111, 22);
            this.btnCatSave.TabIndex = 0;
            this.btnCatSave.Text = "Guardar";
            this.btnCatSave.UseVisualStyleBackColor = true;
            this.btnCatSave.Click += new System.EventHandler(this.btnCatSave_Click);
            // 
            // btnCatDel
            // 
            this.btnCatDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCatDel.Location = new System.Drawing.Point(140, 3);
            this.btnCatDel.Name = "btnCatDel";
            this.btnCatDel.Size = new System.Drawing.Size(111, 22);
            this.btnCatDel.TabIndex = 1;
            this.btnCatDel.Text = "Eliminar";
            this.btnCatDel.UseVisualStyleBackColor = true;
            this.btnCatDel.Click += new System.EventHandler(this.btnCatDel_Click);
            // 
            // tabCondiciones
            // 
            this.tabCondiciones.Controls.Add(this.tableLayoutPanel5);
            this.tabCondiciones.Location = new System.Drawing.Point(4, 25);
            this.tabCondiciones.Name = "tabCondiciones";
            this.tabCondiciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabCondiciones.Size = new System.Drawing.Size(272, 34);
            this.tabCondiciones.TabIndex = 1;
            this.tabCondiciones.Text = "Condiciones";
            this.tabCondiciones.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 5;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel5.Controls.Add(this.btnCondSave, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnCondDel, 3, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(266, 28);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // btnCondSave
            // 
            this.btnCondSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCondSave.Location = new System.Drawing.Point(13, 3);
            this.btnCondSave.Name = "btnCondSave";
            this.btnCondSave.Size = new System.Drawing.Size(111, 22);
            this.btnCondSave.TabIndex = 0;
            this.btnCondSave.Text = "Guardar";
            this.btnCondSave.UseVisualStyleBackColor = true;
            this.btnCondSave.Click += new System.EventHandler(this.btnCondSave_Click);
            // 
            // btnCondDel
            // 
            this.btnCondDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCondDel.Location = new System.Drawing.Point(140, 3);
            this.btnCondDel.Name = "btnCondDel";
            this.btnCondDel.Size = new System.Drawing.Size(111, 22);
            this.btnCondDel.TabIndex = 1;
            this.btnCondDel.Text = "Eliminar";
            this.btnCondDel.UseVisualStyleBackColor = true;
            this.btnCondDel.Click += new System.EventHandler(this.btnCondDel_Click);
            // 
            // tabEstados
            // 
            this.tabEstados.Controls.Add(this.tableLayoutPanel6);
            this.tabEstados.Location = new System.Drawing.Point(4, 25);
            this.tabEstados.Name = "tabEstados";
            this.tabEstados.Padding = new System.Windows.Forms.Padding(3);
            this.tabEstados.Size = new System.Drawing.Size(272, 34);
            this.tabEstados.TabIndex = 2;
            this.tabEstados.Text = "Estados";
            this.tabEstados.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 5;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel6.Controls.Add(this.btnEdoSave, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnEdoDel, 3, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(266, 28);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // btnEdoSave
            // 
            this.btnEdoSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdoSave.Location = new System.Drawing.Point(13, 3);
            this.btnEdoSave.Name = "btnEdoSave";
            this.btnEdoSave.Size = new System.Drawing.Size(111, 22);
            this.btnEdoSave.TabIndex = 0;
            this.btnEdoSave.Text = "Guardar";
            this.btnEdoSave.UseVisualStyleBackColor = true;
            this.btnEdoSave.Click += new System.EventHandler(this.btnEdoSave_Click);
            // 
            // btnEdoDel
            // 
            this.btnEdoDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdoDel.Location = new System.Drawing.Point(140, 3);
            this.btnEdoDel.Name = "btnEdoDel";
            this.btnEdoDel.Size = new System.Drawing.Size(111, 22);
            this.btnEdoDel.TabIndex = 1;
            this.btnEdoDel.Text = "Eliminar";
            this.btnEdoDel.UseVisualStyleBackColor = true;
            this.btnEdoDel.Click += new System.EventHandler(this.btnEdoDel_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtNombre, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblId, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnLimpiar, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 72);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(280, 99);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNombre
            // 
            this.txtNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNombre.Location = new System.Drawing.Point(101, 32);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(176, 23);
            this.txtNombre.TabIndex = 1;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(101, 68);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 16);
            this.lblId.TabIndex = 2;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLimpiar.Location = new System.Drawing.Point(3, 71);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(92, 25);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(295, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "Listado de Categorias";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(295, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 36);
            this.label3.TabIndex = 2;
            this.label3.Text = "Listado de Estados de reportes";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(286, 36);
            this.label4.TabIndex = 3;
            this.label4.Text = "Listado de Condiciones";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvCats
            // 
            this.dgvCats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.catID,
            this.catNombre});
            this.dgvCats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCats.Location = new System.Drawing.Point(295, 39);
            this.dgvCats.Name = "dgvCats";
            this.dgvCats.Size = new System.Drawing.Size(286, 138);
            this.dgvCats.TabIndex = 4;
            this.dgvCats.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCats_CellContentClick);
            // 
            // catID
            // 
            this.catID.HeaderText = "ID";
            this.catID.Name = "catID";
            // 
            // catNombre
            // 
            this.catNombre.HeaderText = "Nombre";
            this.catNombre.Name = "catNombre";
            // 
            // dgvEdos
            // 
            this.dgvEdos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEdos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.edoID,
            this.edoNombre});
            this.dgvEdos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEdos.Location = new System.Drawing.Point(295, 219);
            this.dgvEdos.Name = "dgvEdos";
            this.dgvEdos.Size = new System.Drawing.Size(286, 139);
            this.dgvEdos.TabIndex = 5;
            this.dgvEdos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEdos_CellContentClick);
            // 
            // edoID
            // 
            this.edoID.HeaderText = "ID";
            this.edoID.Name = "edoID";
            // 
            // edoNombre
            // 
            this.edoNombre.HeaderText = "Nombre";
            this.edoNombre.Name = "edoNombre";
            // 
            // dgvConds
            // 
            this.dgvConds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.condID,
            this.condNombre});
            this.dgvConds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConds.Location = new System.Drawing.Point(3, 219);
            this.dgvConds.Name = "dgvConds";
            this.dgvConds.Size = new System.Drawing.Size(286, 139);
            this.dgvConds.TabIndex = 6;
            this.dgvConds.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConds_CellContentClick);
            // 
            // condID
            // 
            this.condID.HeaderText = "ID";
            this.condID.Name = "condID";
            // 
            // condNombre
            // 
            this.condNombre.HeaderText = "Nombre";
            this.condNombre.Name = "condNombre";
            // 
            // GestionCatalogosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GestionCatalogosForm";
            this.Text = "GestionCatalogos";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabCategorias.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tabCondiciones.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tabEstados.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCategorias;
        private System.Windows.Forms.TabPage tabCondiciones;
        private System.Windows.Forms.TabPage tabEstados;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnCatSave;
        private System.Windows.Forms.Button btnCatDel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnCondSave;
        private System.Windows.Forms.Button btnCondDel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnEdoSave;
        private System.Windows.Forms.Button btnEdoDel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvCats;
        private System.Windows.Forms.DataGridViewTextBoxColumn catID;
        private System.Windows.Forms.DataGridViewTextBoxColumn catNombre;
        private System.Windows.Forms.DataGridView dgvEdos;
        private System.Windows.Forms.DataGridViewTextBoxColumn edoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn edoNombre;
        private System.Windows.Forms.DataGridView dgvConds;
        private System.Windows.Forms.DataGridViewTextBoxColumn condID;
        private System.Windows.Forms.DataGridViewTextBoxColumn condNombre;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnLimpiar;
    }
}