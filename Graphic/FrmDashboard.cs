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
    public partial class FrmDashboard : Form
    {
        public FrmDashboard(string teme)
        {
            InitializeComponent();
            TemeChange(teme);
        }

        private void TemeChange(string teme)
        {
            Guna.UI2.WinForms.Guna2Panel[] mainColor = { pnlFooter };

            Guna.UI2.WinForms.Guna2Panel[] conteinerColor = { pnlList, pnlCostPerMonth, pnlIncomePerMonth, pnlProfit };

            Guna.UI2.WinForms.Guna2Panel[] lowPanels = {pnlCostPerMonth, pnlIncomePerMonth, pnlProfit };

            Label[] labelsForeColor = { lblAmount, lblCategory, lblID, lblName, lblPrice, lblSupplier, lblTotal };



            switch (teme)
            {
                case "dark":
                    foreach (Guna2Panel colorDark in mainColor)
                    {
                        colorDark.FillColor =
                            System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))); ;
                    }
                    foreach (Guna2Panel colorConteiner in conteinerColor)
                    {
                        colorConteiner.FillColor =
                            System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84))))); ;
                    }
                    foreach (Label foreColor in labelsForeColor)
                    {
                        foreColor.ForeColor = System.Drawing.Color.White;

                    }

                    pnlList.FillColor = System.Drawing.Color.Silver; 
                    pnlBackground.FillColor = System.Drawing.Color.Gray;

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
                    foreach (Label foreColor in labelsForeColor)
                    {
                        foreColor.ForeColor = System.Drawing.Color.White;

                    }
                   
                    pnlBackground.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))); ;
                

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
                   

                    pnlBackground.FillColor = System.Drawing.Color.LightSteelBlue;
                   
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

                    pnlBackground.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(145)))), ((int)(((byte)(141))))); ;

                    break;


                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        private void pnlBackground_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
