namespace ProyectoFinalDemo
{
    partial class WelcomeForm
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
            this.listadoParques = new System.Windows.Forms.ToolStripMenuItem();
            this.busquedaParques = new System.Windows.Forms.ToolStripMenuItem();
            this.menuActividades = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoActividades = new System.Windows.Forms.ToolStripMenuItem();
            this.busquedaActividades = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.busquedaReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.admin_users = new System.Windows.Forms.ToolStripMenuItem();
            this.admin_parques = new System.Windows.Forms.ToolStripMenuItem();
            this.admin_actividades = new System.Windows.Forms.ToolStripMenuItem();
            this.admin_reportes = new System.Windows.Forms.ToolStripMenuItem();
            this.admin_catalogos = new System.Windows.Forms.ToolStripMenuItem();
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
            this.listadoParques,
            this.busquedaParques});
            this.menuParques.Enabled = false;
            this.menuParques.Name = "menuParques";
            this.menuParques.Size = new System.Drawing.Size(85, 27);
            this.menuParques.Text = "Parques";
            // 
            // listadoParques
            // 
            this.listadoParques.Name = "listadoParques";
            this.listadoParques.Size = new System.Drawing.Size(156, 22);
            this.listadoParques.Text = "Listado";
            this.listadoParques.Click += new System.EventHandler(this.listadoParques_Click);
            // 
            // busquedaParques
            // 
            this.busquedaParques.Name = "busquedaParques";
            this.busquedaParques.Size = new System.Drawing.Size(156, 22);
            this.busquedaParques.Text = "Busqueda";
            this.busquedaParques.Click += new System.EventHandler(this.busquedaParques_Click);
            // 
            // menuActividades
            // 
            this.menuActividades.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoActividades,
            this.busquedaActividades});
            this.menuActividades.Enabled = false;
            this.menuActividades.Name = "menuActividades";
            this.menuActividades.Size = new System.Drawing.Size(114, 27);
            this.menuActividades.Text = "Actividades";
            // 
            // listadoActividades
            // 
            this.listadoActividades.Name = "listadoActividades";
            this.listadoActividades.Size = new System.Drawing.Size(156, 22);
            this.listadoActividades.Text = "Listado";
            // 
            // busquedaActividades
            // 
            this.busquedaActividades.Name = "busquedaActividades";
            this.busquedaActividades.Size = new System.Drawing.Size(156, 22);
            this.busquedaActividades.Text = "Busqueda";
            // 
            // menuReportes
            // 
            this.menuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoReportes,
            this.busquedaReportes});
            this.menuReportes.Enabled = false;
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(93, 27);
            this.menuReportes.Text = "Reportes";
            // 
            // listadoReportes
            // 
            this.listadoReportes.Name = "listadoReportes";
            this.listadoReportes.Size = new System.Drawing.Size(156, 22);
            this.listadoReportes.Text = "Listado";
            // 
            // busquedaReportes
            // 
            this.busquedaReportes.Name = "busquedaReportes";
            this.busquedaReportes.Size = new System.Drawing.Size(156, 22);
            this.busquedaReportes.Text = "Busqueda";
            // 
            // menuAdmin
            // 
            this.menuAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.admin_users,
            this.admin_parques,
            this.admin_actividades,
            this.admin_reportes,
            this.admin_catalogos});
            this.menuAdmin.Enabled = false;
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Size = new System.Drawing.Size(71, 27);
            this.menuAdmin.Text = "Admin";
            // 
            // admin_users
            // 
            this.admin_users.Name = "admin_users";
            this.admin_users.Size = new System.Drawing.Size(180, 22);
            this.admin_users.Text = "Usuarios";
            this.admin_users.Click += new System.EventHandler(this.admin_users_Click);
            // 
            // admin_parques
            // 
            this.admin_parques.Name = "admin_parques";
            this.admin_parques.Size = new System.Drawing.Size(180, 22);
            this.admin_parques.Text = "Parques";
            this.admin_parques.Click += new System.EventHandler(this.admin_parques_Click);
            // 
            // admin_actividades
            // 
            this.admin_actividades.Name = "admin_actividades";
            this.admin_actividades.Size = new System.Drawing.Size(180, 22);
            this.admin_actividades.Text = "Actividades";
            this.admin_actividades.Click += new System.EventHandler(this.admin_actividades_Click);
            // 
            // admin_reportes
            // 
            this.admin_reportes.Name = "admin_reportes";
            this.admin_reportes.Size = new System.Drawing.Size(180, 22);
            this.admin_reportes.Text = "Reportes";
            this.admin_reportes.Click += new System.EventHandler(this.admin_reportes_Click);
            // 
            // admin_catalogos
            // 
            this.admin_catalogos.Name = "admin_catalogos";
            this.admin_catalogos.Size = new System.Drawing.Size(180, 22);
            this.admin_catalogos.Text = "Catalogos";
            this.admin_catalogos.Click += new System.EventHandler(this.admin_catalogos_Click);
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.SGPAMenu;
            this.Name = "WelcomeForm";
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
        private System.Windows.Forms.ToolStripMenuItem listadoParques;
        private System.Windows.Forms.ToolStripMenuItem busquedaParques;
        private System.Windows.Forms.ToolStripMenuItem listadoActividades;
        private System.Windows.Forms.ToolStripMenuItem busquedaActividades;
        private System.Windows.Forms.ToolStripMenuItem listadoReportes;
        private System.Windows.Forms.ToolStripMenuItem busquedaReportes;
        private System.Windows.Forms.ToolStripMenuItem admin_users;
        private System.Windows.Forms.ToolStripMenuItem admin_parques;
        private System.Windows.Forms.ToolStripMenuItem admin_actividades;
        private System.Windows.Forms.ToolStripMenuItem admin_reportes;
        private System.Windows.Forms.ToolStripMenuItem admin_catalogos;
    }
}

