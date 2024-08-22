using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic
{
    public partial class FrmTicket : Form
    {
        public FrmTicket(string moneyPaid, string moneyReturned, string totalPrice)
        {
            InitializeComponent();
            fillTxtField(moneyPaid, moneyReturned, totalPrice);
        }

        private void fillTxtField(string moneyPaid, string moneyReturned, string totalPrice)
        {

            lblTimeV.Text = DateTime.Now.ToShortTimeString();
            lblDateV.Text = DateTime.Now.ToShortDateString();

            Random random = new Random();
            int randomNumber = random.Next(0, 999999);
            lblNumTicketV.Text = randomNumber.ToString();

            lblMoneyPaidV.Text = moneyPaid;
            lblMoneyReturnedV.Text = moneyReturned;
            lblTotalPriceV.Text = totalPrice;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
        }

        private void pnlTopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMenssage(this.Handle, 0x112, 0xf012, 0);
        }

        //Esto se usa en los metodos de cerrar, arrastrar, minimizar, maximizar
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMenssage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void pnlTopPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
