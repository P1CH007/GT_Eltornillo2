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

        public FrmProducts(string teme)
        {
            InitializeComponent();
            TemeChange(teme);

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

        private void TemeChange(string teme)
        {
            Guna2Panel[] mainColor = { pnlFooterConteiner, pnlOpenAndCloseList, pnlDataBackground, pnlData1, pnlData2, pnlData3, pnlButtonConteiner }; 
            Guna2Panel[] conteinerColor = { pnlConteiner, pnlTopList, pnlListConteiner};
            Guna2Panel[] lightColor = {pnlBackground, pnlListConteiner, pnlList };
            Guna2Button[] buttonsForeColor = { btnClean, btnAddProduct };
            Label[] labelsForeColor = {  lblA2, lblA3, lblAmount, lblName, lblPrice, lblSupplier, lblUbication};

            switch (teme)
            {
                case "dark":
                    foreach (Guna2Panel colorDark in mainColor)
                    {
                        colorDark.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))); ; 

                    }
                    foreach (Guna2Panel colorConteiner in conteinerColor)
                    {
                        colorConteiner.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84))))); ;

                    }

                    foreach (Guna2Panel lightColors in lightColor)
                    {
                        lightColors.FillColor =
                            System.Drawing.Color.Gray;
                    }

                    pnlMenuConteiner.FillColor = System.Drawing.Color.Gray;

                    break;


                case "red":
                    foreach (Guna2Panel colorDark in mainColor)
                    {
                        colorDark.FillColor = System.Drawing.Color.IndianRed;
                    }
                    foreach (Guna2Panel colorConteiner in conteinerColor)
                    {
                        colorConteiner.FillColor =
                            System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))); ;
                    }
                    foreach (Guna2Panel lightColors in lightColor)
                    {
                        lightColors.FillColor = 
                            System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))); ;
                    }

                    pnlMenuConteiner.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))); ;

                    break;


                case "blue":
                    foreach (Guna2Panel colorDark in mainColor)
                    {
                        colorDark.FillColor = System.Drawing.Color.RoyalBlue;
                    }
                    foreach (Guna2Panel colorConteiner in conteinerColor)
                    {
                        colorConteiner.FillColor = System.Drawing.Color.CornflowerBlue;
                    }
                    foreach (Label foreColor in labelsForeColor)
                    {
                        foreColor.ForeColor = System.Drawing.Color.White;

                    }
                    foreach (Guna2Button foreColor in buttonsForeColor)
                    {
                        foreColor.ForeColor = System.Drawing.Color.White;

                    }
                    foreach (Guna2Panel lightColors in lightColor)
                    {
                        lightColors.FillColor = System.Drawing.Color.LightSteelBlue;
                    }


                   
                    break;


                case "light":
                    foreach (Guna2Panel colorDark in mainColor)
                    {
                        colorDark.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(120)))), ((int)(((byte)(114))))); ; 
                    }
                    foreach (Guna2Panel colorConteiner in conteinerColor)
                    {
                        colorConteiner.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(167))))); ;
                    }
                    foreach (Label foreColor in labelsForeColor)
                    {
                        foreColor.ForeColor = System.Drawing.Color.White;

                    }
                    foreach (Guna2Button foreColor in buttonsForeColor)
                    {
                        foreColor.ForeColor = System.Drawing.Color.White;

                    }
                    foreach (Guna2Panel lightColors in lightColor)
                    {
                        lightColors.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(145)))), ((int)(((byte)(141))))); ;
                    }

                    break;


                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }



    }
}
 