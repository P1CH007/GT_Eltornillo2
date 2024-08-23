using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Graphic
{
    public partial class FrmProducts : Form
    {
        private Boolean open = false;
        private bool confirmOpen = false;

        public FrmProducts(Color color1, Color color2, Color color3, Color background)
        {
            InitializeComponent();
            TemeChange(color1, color2, color3, background);

            timerResChanges.Start();
        }


        private void picBoxShowList_Click(object sender, EventArgs e)
        {
            timerOpenAndClose.Start();
        }


        private void timerOpenAndClose_Tick(object sender, EventArgs e)
        {
            int condition = pnlMenuConteiner.Width - 50;

            if (open)
            {
                if (pnlListConteiner.Width > 39)
                {
                    confirmOpen = false;
                    pnlListConteiner.Width = pnlListConteiner.Width - 40;
                }
                else
                {
                    timerOpenAndClose.Stop();
                    open = false;
                }
            }
            else
            {

                if (pnlListConteiner.Width < condition)
                {
                    confirmOpen = true;
                    pnlListConteiner.Width = pnlListConteiner.Width + 40;
                }
                else
                {
                    timerOpenAndClose.Stop();
                    open = true;
                }
            }
        }

        private void timerResChanges_Tick(object sender, EventArgs e)
        {
            int condition = pnlMenuConteiner.Width - 50;

            if (confirmOpen)
            {
                if (pnlListConteiner.Width < condition)
                {
                    pnlListConteiner.Width = pnlListConteiner.Width + 40;
                }
            }

            if (pnlListConteiner.Width > pnlMenuConteiner.Width)
            {
                pnlListConteiner.Width = pnlListConteiner.Width - 40;
            }

        }


        private void TemeChange(Color color1, Color color2, Color color3, Color background)
        {

            Guna2Panel[] mainColor = { pnlFormTitle, pnlFooterConteiner, pnlOpenAndCloseList, pnlDataBackground, pnlData1, pnlData2, pnlData3, pnlButtonConteiner };
            Guna2Panel[] conteinerColor = { pnlConteiner, pnlTopList, pnlListConteiner };
            Guna2Panel[] lightColor = { pnlBackground, pnlListConteiner, pnlList };
            Guna2Panel[] backgroundColor = { pnlMenuConteiner };

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



    }
}
 