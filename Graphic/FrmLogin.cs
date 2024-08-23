using Entities;
using Guna.UI2.WinForms;
using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Graphic
{
    public partial class FrmLogin : Form
    {

        private MainApplication mainApplication;

        Color mainColor = Color.FromArgb(64, 64, 64);
        Color scndColor = Color.FromArgb(84, 84, 84);
        Color trdColor = Color.Gray;
        Color background = Color.Gray;

        private string tierL;
        private string saveTheme;

        public FrmLogin()
        {
            InitializeComponent();
            RoundCorners(this, 20);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMenssage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void btnLogIn_Click(object sender, EventArgs e)
        {
            /* 
 EmployeeDAO verifyAcc = new EmployeeDAO();

 string mail = txtGmail.Text;
 string pass = txtPassword.Text;

 Employees employee = verifyAcc.VerifyUser(mail, pass);

 if (employee != null)
 {

     mainApplication = new MainApplication(saveTeme, this, employee.EmployeeName, employee.UserType);
     mainApplication.Show();
     this.Hide();
 }
 else
 {
     FrmErrorMSG error = new FrmErrorMSG();
     error.Show();
 }


     */
            string a = "x";

            if (txtGmail.Text == "Eventas@gmail.com" && txtPassword.Text == "root" || txtGmail.Text == "Estock@gmail.com" && txtPassword.Text == "root" || txtGmail.Text == "" && txtPassword.Text == "")
            {
                mainApplication = new MainApplication(this, "userName", a, saveTheme, mainColor, scndColor, trdColor, background);
                mainApplication.Show();
                this.Hide();
            }
            else
            {
                //  FrmErrorMSG errorMSG = new FrmErrorMSG();
                // errorMSG.Show();
            }

        }

        private void exceptionManagment(TextBox textBox)
        {
            string mistake = "";
            if (textBox.Text == "")
            {
                mistake = "Hay campos vacios";
            }
            if (Regex.IsMatch(textBox.Text, "[a - zA - Z]"))
            {
                mistake = "Hay letras en campos donde solo deben haber numeros";
            }
        }


        //metodo para redondear las esquinas de la ventana cuando esta se ejecute.
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


        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMenssage(this.Handle, 0x112, 0xf012, 0);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picBoxDarkTeme_Click(object sender, EventArgs e)
        {
            string teme = "dark";
            changeTeme(teme);
            saveTheme = "dark";
        }

        private void picBoxRedTeme_Click(object sender, EventArgs e)
        {
            string teme = "red";
            changeTeme(teme);
            saveTheme = "red";
        }

        private void picBoxBlueTeme_Click(object sender, EventArgs e)
        {
            string teme = "blue";
            changeTeme(teme);
            saveTheme = "blue";
        }

        private void picBoxLightTeme_Click(object sender, EventArgs e)
        {
            string teme = "light";
            changeTeme(teme);
            saveTheme = "light";
        }

        private void picBOrangeTheme_Click(object sender, EventArgs e)
        {
            string teme = "orange";
            changeTeme(teme);
            saveTheme = "orange";
        }

        public void changeTeme(string teme)
        {

            Guna2Panel[] mainPanels = { pnlLogConteiner, pnlTemesConteiner, pnlTop };
            Guna2Panel[] conteinerPanels = { pnlTitle };



            switch (teme)
            {

                case "dark":


                    mainColor = Color.FromArgb(64, 64, 64);
                    scndColor = Color.FromArgb(84, 84, 84);
                    trdColor = Color.Gray;
                    background = Color.Gray;

                    foreach (Guna2Panel colorDark in mainPanels)
                    {
                        colorDark.FillColor = mainColor;
                    }
                    foreach (Guna2Panel conteinerColor in conteinerPanels)
                    {
                        conteinerColor.FillColor = scndColor;
                    }
                    picBDarkSelected.Visible = true;
                    picBBlueSelected.Visible = false;
                    picBRedSelected.Visible = false;
                    picBLightSelected.Visible = false;
                    picBOrangeThemeSelected.Visible = false;
                    break;

                case "red":

                    mainColor = Color.FromArgb(160, 46, 32);
                    scndColor = Color.FromArgb(218, 52, 77);
                    trdColor = Color.FromArgb(255, 192, 192);
                    background = Color.FromArgb(232, 147, 136);

                    foreach (Guna2Panel colorDark in mainPanels)
                    {

                        colorDark.FillColor = mainColor;
                    }
                    foreach (Guna2Panel conteinerColor in conteinerPanels)
                    {
                        conteinerColor.FillColor = scndColor;
                    }
                    picBDarkSelected.Visible = false;
                    picBBlueSelected.Visible = false;
                    picBRedSelected.Visible = true;
                    picBLightSelected.Visible = false;
                    picBOrangeThemeSelected.Visible = false;
                    break;

                case "blue":

                    mainColor = Color.FromArgb(56, 78, 186);
                    scndColor = Color.CornflowerBlue;
                    trdColor = Color.LightSteelBlue;
                    background = Color.LightSteelBlue;


                    foreach (Guna2Panel colorDark in mainPanels)
                    {
                        colorDark.FillColor = mainColor;
                    }
                    foreach (Guna2Panel conteinerColor in conteinerPanels)
                    {
                        conteinerColor.FillColor = scndColor;
                    }
                    picBDarkSelected.Visible = false;
                    picBBlueSelected.Visible = true;
                    picBRedSelected.Visible = false;
                    picBLightSelected.Visible = false;
                    picBOrangeThemeSelected.Visible = false;
                    break;

                case "light":
                    mainColor = Color.FromArgb(124, 160, 153);
                    scndColor = Color.FromArgb(113, 124, 137);
                    trdColor = Color.FromArgb(122, 145, 141);
                    background = Color.FromArgb(122, 145, 141);


                    foreach (Guna2Panel colorDark in mainPanels)
                    {
                        colorDark.FillColor = mainColor;
                    }
                    foreach (Guna2Panel conteinerColor in conteinerPanels)
                    {
                        conteinerColor.FillColor = scndColor;
                    }
                    picBDarkSelected.Visible = false;
                    picBBlueSelected.Visible = false;
                    picBRedSelected.Visible = false;
                    picBLightSelected.Visible = true;
                    picBOrangeThemeSelected.Visible = false;
                    break;

                case "orange":


                    mainColor = Color.FromArgb(243, 114, 44);
                    scndColor = Color.FromArgb(228, 150, 96);
                    trdColor = Color.FromArgb(230, 168, 114);
                    background = Color.FromArgb(255, 151, 112);

                    foreach (Guna2Panel colorDark in mainPanels)
                    {
                        colorDark.FillColor = mainColor;
                    }
                    foreach (Guna2Panel conteinerColor in conteinerPanels)
                    {
                        conteinerColor.FillColor = scndColor;
                    }
                    picBDarkSelected.Visible = false;
                    picBBlueSelected.Visible = false;
                    picBRedSelected.Visible = false;
                    picBLightSelected.Visible = false;
                    picBOrangeThemeSelected.Visible = true;
                    break;


                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        private void picBMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picBHidePass_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';// '\0' es el carácter nulo, que elimina el enmascaramiento.
            picBSeePass.Visible = true;
            picBHidePass.Visible = false;
        }

        private void picBSeePass_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            picBSeePass.Visible = false;
            picBHidePass.Visible = true;
        }


    }
}
