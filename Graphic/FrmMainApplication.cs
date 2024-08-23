using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using Guna.UI2.WinForms;


namespace Graphic
{
    public partial class MainApplication : Form
    {
        private string saveTheme;
        private FrmLogin logIn;
        private string tier;
        private string user;


        private Color mainColor;
        private Color scndColor;
        private Color trdColor;
        private Color background;



        public MainApplication(FrmLogin login, string userName, string tierL, String theme, Color mainColor, Color scndColor, Color trdColor, Color background)
        {
            this.logIn = login;
            this.tier = tierL;
            this.user = userName;
            this.mainColor= mainColor;
            this.scndColor = scndColor;
            this.trdColor = trdColor;
            this.background = background;
            this.saveTheme = theme;
            InitializeComponent();
            changeTheme(saveTheme ,mainColor, scndColor, trdColor, background);
            //RoundCorners(this, 20);

        }

        private void tierChanges(string tier)
        {
            if (tier == "ventas")
            {
                btnProducts.Enabled = false;
                btnProductsCenter.Enabled = false;
                btnShopping.Enabled = false;
                btnShoppingCenter.Enabled = false;
                btnWorkers.Enabled = false;
                btnWorkersCenter.Enabled = false;
            }
            if (tier == "stock")
            {
                btnWorkers.Enabled = false;
                btnWorkersCenter.Enabled = false;
                btnSales.Enabled = false;
                btnSalesCenter.Enabled = false;

            }
        }

        //Esto se usa en los metodos de cerrar, arrastrar, minimizar, maximizar
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMenssage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //Metodo para redondear las esquinas (no esta en uso)
        private void RoundCorners(Form form, int radius)
        {
            // Creamos un objeto GraphicsPath para definir la forma de las esquinas redondeadas
            GraphicsPath path = new GraphicsPath();
            // Agregamos un arco para la esquina superior izquierda
            path.AddArc(0, 0, radius, radius, 180, 90);
            // Agregamos un arco para la esquina superior derecha
            path.AddArc(form.Width - radius, 0, radius, radius, 270, 90);
            // Agregamos un arco para la esquina inferior derecha
            path.AddArc(form.Width - radius, form.Height - radius, radius, radius, 0, 90);
            // Agregamos un arco para la esquina inferior izquierda
            path.AddArc(0, form.Height - radius, radius, radius, 90, 90);
            // Establecemos la región del formulario con el GraphicsPath que define las esquinas redondeadas
            form.Region = new Region(path);
        }

        //evento para poder arrastrar la ventana desde el pnlTopPanel
        private void pnlTopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMenssage(this.Handle, 0x112, 0xf012, 0);
        }

        //evento para abrir y cerrar el panel vertical donde estan los botones: productos,compras, etc
        private void picBoxCloseVeticalPanel(object sender, EventArgs e)
        {
            if (pnlVerticalPanel.Width == 252)
            {

                pnlVerticalPanel.Width = 82;

                pnlCenterPanel.Width = pnlBackground.Width - 82;
                pnlCenterPanel.Location = new Point(82, 27);

                btnConfigLeft.Visible = true;
                btnConfigBottom.Visible = false;
                btnExitLeft.Visible = true;
                btnExitBottom.Visible = false;

            }
            else if (pnlVerticalPanel.Width == 82)
            {

                pnlVerticalPanel.Width = 252;

                pnlCenterPanel.Width = pnlBackground.Width - 252;
                pnlCenterPanel.Location = new Point(252, 27);

                btnConfigLeft.Visible = false;
                btnConfigBottom.Visible = true;
                btnExitLeft.Visible = false;
                btnExitBottom.Visible = true;

            }

        }


        //evento para cerrar la app desde la imagen picBoxClose
        private void picBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //evento para maximizar la app desde la imagen picBoxMax
        private void picBoxMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            picBoxMax.Visible = false;
            picBoxSMin.Visible = true;

        }

        //evento para minimizar pero no al 100% la app desde la imagen picBoxSMin la S es de semi minimize
        private void picBoxSMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            picBoxSMin.Visible = false;
            picBoxMax.Visible = true;
        }

        //evento para minimizar la app desde la imagen picBoxMin
        private void picBoxMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //evento para abrir el form hijo StartStcreen desde la imagen picBNameLogo
        private void picBNameLogo_Click(object sender, EventArgs e)
        {
            Form newForm = new FrmStartScreen(this, saveTheme, tier);
            openFormInPanel(newForm);
            closeButtonsAnimation();
        }
        private void picBlogo_Click(object sender, EventArgs e)
        {
            Form newForm = new FrmStartScreen(this, saveTheme, tier);
            openFormInPanel(newForm);
            closeButtonsAnimation();
        }

        private void closeButtonsAnimation()
        {
            Guna2Button[] b = { btnCalendar, btnConfigBottom, btnConfigLeft, btnDashboard, btnProducts, btnSales, btnShopping, btnWorkers };

            foreach (Guna2Button buttons in b)
            {
                buttons.BorderThickness = 0;
                buttons.Font = new Font(buttons.Font.FontFamily, 12);
            }
        }
        /*
         * metodo utilizado para abrir forms hijos dentro del panel pnlCenterPanel, comprueba si hay paneles abiertos, si
         * hay algun panel abierto lo cierra. Tambien recolecta los residuos que quedan al cerrar forms de esta manera
         */
        private void openFormInPanel(Form sonForm)
        {
            Guna2Panel[] cPanels = { pnlPanelConteiner, pnlStockConteiner, pnlTitle };
            foreach (Guna2Panel panels in cPanels)
            {
                panels.Dispose();
            }

            // Verificar si hay algún control en el pnlCenterPanel
            if (this.pnlCenterPanel.Controls.Count > 0)
            {
                // Obtener el control actual en el panel
                Control currentControl = this.pnlCenterPanel.Controls[0];
                // Remover el control del panel
                this.pnlCenterPanel.Controls.Remove(currentControl);
                // Destruir el control si es un formulario
                currentControl.Dispose();
            }

            // Configurar el nuevo formulario para que no sea un formulario de nivel superior
            sonForm.TopLevel = false;
            // Ajustar el formulario para que se acople al tamaño del panel
            sonForm.Dock = DockStyle.Fill;
            this.pnlCenterPanel.Controls.Add(sonForm);
            // Establecer el formulario como el control actual del panel
            this.pnlCenterPanel.Tag = sonForm;
            sonForm.Show();
            // Forzar la recolección de basura
            GC.Collect();
        }


        //Metodo que es llamado desde el form startScreen para darle funcionalidad a sus botones
        public void OpenPanel(string button)
        {
            switch (button)
            {
                case "btnProducts":
                    btnProducts.PerformClick();
                    break;
                case "btnSales":
                    btnSales.PerformClick();
                    break;
                case "btnDashboard":
                    btnDashboard.PerformClick();
                    break;
                case "btnShopping":
                    btnShopping.PerformClick();
                    break;
                case "btnWorkers":
                    btnWorkers.PerformClick();
                    break;
                case "btnConfig":
                    btnConfigBottom.PerformClick();
                    break;

                default:
                    break;

            }

        }

        //Metodo donde se le da estilo "animaciones" a los botones dentro de el form mainApplication
        private void animation(string classOpen, Guna2Button pressed, Guna2Button a1, Guna2Button a2, Guna2Button a3, Guna2Button a4, Guna2Button a5, Guna2Button a6)
        {

            pressed.Font = new Font(pressed.Font.FontFamily, 18);
            a1.Font = new Font(a1.Font.FontFamily, 12);
            a2.Font = new Font(a2.Font.FontFamily, 12);
            a3.Font = new Font(a3.Font.FontFamily, 12);
            a4.Font = new Font(a4.Font.FontFamily, 12);
            a5.Font = new Font(a5.Font.FontFamily, 12);
            a6.Font = new Font(a6.Font.FontFamily, 12);

            pressed.BorderThickness = 1;
            a1.BorderThickness = 0;
            a2.BorderThickness = 0;
            a3.BorderThickness = 0;
            a4.BorderThickness = 0;
            a5.BorderThickness = 0;
            a6.BorderThickness = 0;

            switch (classOpen)
            {
                case "products":
                    Form formProducts = new FrmProducts(mainColor, scndColor, trdColor, background);
                    openFormInPanel(formProducts);
                    break;

                case "sales":
                    Form formSales = new FrmMakeSale(mainColor, scndColor, trdColor, background);
                    openFormInPanel(formSales);
                    break;

                case "dashboard":
                    Form formDashboard = new FrmDashboard(mainColor, scndColor, trdColor, background);
                    openFormInPanel(formDashboard);
                    break;

                case "shopping":
                    Form formShopping = new FrmShopping(mainColor, scndColor, trdColor, background);
                    openFormInPanel(formShopping);
                    break;

                case "workers":
                    Form formWorkers = new FrmResources(saveTheme, "all", mainColor, scndColor, trdColor, background);
                    openFormInPanel(formWorkers);
                    break;

                case "config":
                    Form formWorkers1 = new Config(this, saveTheme, mainColor, scndColor, trdColor, background);
                    openFormInPanel(formWorkers1);
                    btnConfigBottom.BorderThickness = 1;
                    btnConfigLeft.BorderThickness = 1;
                    break;

            }

        }

        

        /*
         * Eventos de click en los botones para abrir los forms hijos
         * 
        */
        private void btnProducts_Click(object sender, EventArgs e)
        {
            animation("products", btnProducts, btnSales, btnDashboard, btnShopping, btnWorkers, btnConfigBottom, btnConfigLeft);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            animation("sales", btnSales, btnProducts, btnDashboard, btnShopping, btnWorkers, btnConfigBottom, btnConfigLeft);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            animation("dashboard", btnDashboard, btnProducts, btnSales, btnShopping, btnWorkers, btnConfigBottom, btnConfigLeft);
        }

        private void btnShopping_Click(object sender, EventArgs e)
        {
            animation("shopping", btnShopping, btnProducts, btnSales, btnDashboard, btnWorkers, btnConfigBottom, btnConfigLeft);
        }

        private void btnWorkers_Click(object sender, EventArgs e)
        {
            animation("workers", btnWorkers, btnProducts, btnSales, btnDashboard, btnShopping, btnConfigBottom, btnConfigLeft);
        }

        private void btnConfigLeft_Click(object sender, EventArgs e)
        {
            animation("config", btnConfigBottom, btnProducts, btnSales, btnDashboard, btnShopping, btnWorkers, btnConfigLeft);
        }

        private void btnConfigBottom_Click(object sender, EventArgs e)
        {
            animation("config", btnConfigLeft, btnProducts, btnSales, btnDashboard, btnShopping, btnWorkers, btnConfigBottom);
        }


        /*
         * Metodo que se encarga del cambio de tema en el form mainApplication, este tambien guarda que tema esta en uso dentro dentro de
         * la variable privada saveTeme, variable que se le pasa al ejecutar el resto de forms hijos haciendo que tenga efecto
         * el cambio de tema en estos.
         */
        public void changeTheme(string theme, Color color1, Color color2, Color color3, Color background)
        {
            saveTheme = theme;
            Guna2Panel[] mainColor = { pnlPanelConteiner, pnlStockConteiner, pnlTopPanel, pnlVerticalConteiner };
            Guna2Panel[] conteinerColor = { pnlTopList };
            Guna2Panel[] backgroundColor = { pnlBackground, pnlCenterPanel };
            Guna2Button[] buttonsForeColor = { btnProducts, btnSales, btnDashboard, btnShopping, btnWorkers, btnCalendar };

            foreach (Guna2Panel darkColor in mainColor)
            {
                darkColor.FillColor = color1;
            }
            foreach (Guna2Panel secondColor in conteinerColor)
            {
                secondColor.FillColor = color2;
            }
            foreach (Guna2Panel backColor in backgroundColor)
            {
                backColor.FillColor = background;
            }

            this.mainColor = color1;
            this.scndColor = color2;
            this.trdColor = color3;
            this.background = background;

        }

        //evento donde se le da atcualizacion constante a las etiquetas time y date para que estas se ajusten automaticamente
        private void dataTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }


        /*
         * Eventos de click en los botones centrales al inicio de la sesion.
         */
        private void btnProductsCenter_click(object sender, EventArgs e)
        {
            btnProducts.PerformClick();
        }

        private void btnSalesCenter_Click(object sender, EventArgs e)
        {
            btnSales.PerformClick();
        }

        private void btnDashboardCenter_Click(object sender, EventArgs e)
        {
            btnDashboard.PerformClick();
        }

        private void btnShoppingCenter_Click(object sender, EventArgs e)
        {
            btnShopping.PerformClick();
        }

        private void btnWorkersCenter_Click(object sender, EventArgs e)
        {
            btnWorkers.PerformClick();
        }

        private void btnConfigCenter_Click(object sender, EventArgs e)
        {
            btnConfigBottom.PerformClick();
        }

        private void btnExitBottom_Click(object sender, EventArgs e)
        {
            logIn.changeTeme(saveTheme);
            this.Close();
            logIn.Show();
            GC.Collect();


        }

        private void btnExitLeft_Click(object sender, EventArgs e)
        {
            logIn.changeTeme(saveTheme);
            this.Close();
            logIn.Show();
            GC.Collect();

        }

        private void pnlVerticalConteiner_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlTopList_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


