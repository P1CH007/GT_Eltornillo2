using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic
{
    public partial class FrmErrorMSG : Form
    {
        public FrmErrorMSG()
        {

            InitializeComponent();
            RoundCorners(this, 30);
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //Esto se usa en los metodos de cerrar, arrastrar, minimizar, maximizar
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMenssage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void guna2CustomGradientPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMenssage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
