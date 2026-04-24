namespace ProyectoFinalDemo
{
    partial class Form1
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
            this.SGPAMenu = new System.Windows.Forms.MenuStrip();
            this.menuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.user_login = new System.Windows.Forms.ToolStripMenuItem();
            this.user_logout = new System.Windows.Forms.ToolStripMenuItem();
            this.user_register = new System.Windows.Forms.ToolStripMenuItem();
            this.menuParques = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busquedaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuActividades = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.misReportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parquesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actividadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.condicionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.SGPAMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.SGPAMenu, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 311);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // SGPAMenu
            // 
            this.SGPAMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SGPAMenu.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SGPAMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.SGPAMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuarios,
            this.menuParques,
            this.menuActividades,
            this.menuReportes,
            this.menuAdmin});
            this.SGPAMenu.Location = new System.Drawing.Point(0, 0);
            this.SGPAMenu.Name = "SGPAMenu";
            this.SGPAMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.SGPAMenu.Size = new System.Drawing.Size(584, 31);
            this.SGPAMenu.TabIndex = 0;
            this.SGPAMenu.Text = "Menu";
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.user_login,
            this.user_logout,
            this.user_register});
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(82, 27);
            this.menuUsuarios.Text = "Usuario";
            // 
            // user_login
            // 
            this.user_login.Name = "user_login";
            this.user_login.Size = new System.Drawing.Size(186, 22);
            this.user_login.Text = "Iniciar sesion";
            this.user_login.Click += new System.EventHandler(this.user_login_Click);
            // 
            // user_logout
            // 
            this.user_logout.Name = "user_logout";
            this.user_logout.Size = new System.Drawing.Size(186, 22);
            this.user_logout.Text = "Cerrar sesion";
            this.user_logout.Click += new System.EventHandler(this.user_logout_Click);
            // 
            // user_register
            // 
            this.user_register.Name = "user_register";
            this.user_register.Size = new System.Drawing.Size(186, 22);
            this.user_register.Text = "Registro";
            this.user_register.Click += new System.EventHandler(this.user_register_Click);
            // 
            // menuParques
            // 
            this.menuParques.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoToolStripMenuItem,
            this.busquedaToolStripMenuItem});
            this.menuParques.Name = "menuParques";
            this.menuParques.Size = new System.Drawing.Size(85, 27);
            this.menuParques.Text = "Parques";
            this.menuParques.Enabled = false;
            // 
            // listadoToolStripMenuItem
            // 
            this.listadoToolStripMenuItem.Name = "listadoToolStripMenuItem";
            this.listadoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.listadoToolStripMenuItem.Text = "Listado";
            // 
            // busquedaToolStripMenuItem
            // 
            this.busquedaToolStripMenuItem.Name = "busquedaToolStripMenuItem";
            this.busquedaToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.busquedaToolStripMenuItem.Text = "Busqueda";
            // 
            // menuActividades
            // 
            this.menuActividades.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoToolStripMenuItem1,
            this.buscarToolStripMenuItem});
            this.menuActividades.Name = "menuActividades";
            this.menuActividades.Size = new System.Drawing.Size(114, 27);
            this.menuActividades.Text = "Actividades";
            this.menuActividades.Enabled = false;
            // 
            // listadoToolStripMenuItem1
            // 
            this.listadoToolStripMenuItem1.Name = "listadoToolStripMenuItem1";
            this.listadoToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.listadoToolStripMenuItem1.Text = "Listado";
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.buscarToolStripMenuItem.Text = "Buscar";
            // 
            // menuReportes
            // 
            this.menuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.misReportesToolStripMenuItem,
            this.listadoToolStripMenuItem2});
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(93, 27);
            this.menuReportes.Text = "Reportes";
            this.menuReportes.Enabled = false;
            // 
            // misReportesToolStripMenuItem
            // 
            this.misReportesToolStripMenuItem.Name = "misReportesToolStripMenuItem";
            this.misReportesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.misReportesToolStripMenuItem.Text = "Listado";
            // 
            // listadoToolStripMenuItem2
            // 
            this.listadoToolStripMenuItem2.Name = "listadoToolStripMenuItem2";
            this.listadoToolStripMenuItem2.Size = new System.Drawing.Size(156, 22);
            this.listadoToolStripMenuItem2.Text = "Busqueda";
            // 
            // menuAdmin
            // 
            this.menuAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.parquesToolStripMenuItem,
            this.actividadesToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.categoriasToolStripMenuItem,
            this.estadosToolStripMenuItem,
            this.condicionesToolStripMenuItem});
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Size = new System.Drawing.Size(71, 27);
            this.menuAdmin.Text = "Admin";
            this.menuAdmin.Enabled = false;
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // parquesToolStripMenuItem
            // 
            this.parquesToolStripMenuItem.Name = "parquesToolStripMenuItem";
            this.parquesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.parquesToolStripMenuItem.Text = "Parques";
            // 
            // actividadesToolStripMenuItem
            // 
            this.actividadesToolStripMenuItem.Name = "actividadesToolStripMenuItem";
            this.actividadesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.actividadesToolStripMenuItem.Text = "Actividades";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.categoriasToolStripMenuItem.Text = "Categorias";
            // 
            // estadosToolStripMenuItem
            // 
            this.estadosToolStripMenuItem.Name = "estadosToolStripMenuItem";
            this.estadosToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.estadosToolStripMenuItem.Text = "Estados";
            // 
            // condicionesToolStripMenuItem
            // 
            this.condicionesToolStripMenuItem.Name = "condicionesToolStripMenuItem";
            this.condicionesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.condicionesToolStripMenuItem.Text = "Condiciones";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.SGPAMenu;
            this.Name = "Form1";
            this.Text = "Sistema de Gestion de Parques y Areas verdes";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.SGPAMenu.ResumeLayout(false);
            this.SGPAMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip SGPAMenu;
        private System.Windows.Forms.ToolStripMenuItem menuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem menuParques;
        private System.Windows.Forms.ToolStripMenuItem menuActividades;
        private System.Windows.Forms.ToolStripMenuItem menuReportes;
        private System.Windows.Forms.ToolStripMenuItem menuAdmin;
        private System.Windows.Forms.ToolStripMenuItem user_login;
        private System.Windows.Forms.ToolStripMenuItem user_logout;
        private System.Windows.Forms.ToolStripMenuItem user_register;
        private System.Windows.Forms.ToolStripMenuItem listadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem busquedaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem misReportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parquesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actividadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem condicionesToolStripMenuItem;
    }
}

