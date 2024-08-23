using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic
{
    public partial class FrmShopping : Form
    {
        public FrmShopping(Color mainColor, Color scndColor, Color trdColor, Color background)
        {
            InitializeComponent();
            TemeChange(mainColor, scndColor, trdColor,background);
        }

        private void TemeChange(Color color1, Color color2, Color color3, Color background)
        {

            Guna2Panel[] mainColor = { pnlDataConteiner, pnlTopList, pnlFormTitle };
            Guna2Panel[] conteinerColor = { pnlButtonConteiner, pnlDataBackgroundScndLayer };
            Guna2Panel[] lightColor = { };
            Guna2Panel[] backgroundColor = { pnlBackground};

            foreach (Guna2Panel darkColor in mainColor)
            {
                darkColor.FillColor = color1;
            }
            foreach (Guna2Panel secondColor in conteinerColor)
            {
                secondColor.FillColor = color2;
            }
            foreach (Guna2Panel lightColors in lightColor)
            {
                lightColors.FillColor = color3;
            }
            foreach (Guna2Panel backColor in backgroundColor)
            {
                backColor.FillColor = background;
            }

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void btnClean_Click(object sender, EventArgs e)
        {

        }
    }
}
