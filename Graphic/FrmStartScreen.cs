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
    public partial class FrmStartScreen : Form
    {

        private MainApplication mp;

         public FrmStartScreen(MainApplication mainApplication, string teme, string tier)
        {
            mp = mainApplication;

            InitializeComponent();

            TemeChange(teme, tier);
            tierChanges(tier);
        }

        private void tierChanges(string tier)
        {
            if (tier == "g1")
            {
                btnProductsCenter.Enabled = false;
                btnShoppingCenter.Enabled = false;
                btnWorkersCenter.Enabled = false;
            }
            if (tier == "g2")
            {
                btnWorkersCenter.Enabled = false;
                btnSalesCenter.Enabled = false;

            }
        }

        private void TemeChange(string teme,string tier)
        {
            Guna2Panel[] mainColor = { pnlPanelConteiner, pnlStockConteiner };
            Label[] labelsForeColor = {lblDate, lblTime};
            Guna2Panel[] panelConteiner = { pnlTopList };


            switch (teme)
            {
                case "dark":
                    foreach (Guna2Panel colorDark in mainColor)
                    {
                        colorDark.FillColor =
                            System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))); ;

                        System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))); ;
                    }
                    foreach (Guna2Panel pnlColor in panelConteiner)
                    {
                        pnlColor.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84))))); ;
                    }
                    foreach (Label foreColor in labelsForeColor)
                    {
                        foreColor.ForeColor = System.Drawing.Color.White;
                    }
                    dataGridStock.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84))))); ;
                    break;


                case "red":
                    foreach (Guna2Panel colorDark in mainColor)
                    {
                        colorDark.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(46)))), ((int)(((byte)(32))))); ;
                    }
                    foreach (Guna2Panel pnlColor in panelConteiner)
                    {
                        pnlColor.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(52)))), ((int)(((byte)(77))))); ;
                    }
                    foreach (Label foreColor in labelsForeColor)
                    {
                        foreColor.ForeColor = System.Drawing.Color.White;
                    }
                    dataGridStock.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(52)))), ((int)(((byte)(77))))); ;
                    pnlBackground.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))); ;
                    break;


                case "blue":
                    foreach (Guna2Panel colorDark in mainColor)
                    {
                        colorDark.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(78)))), ((int)(((byte)(186))))); ;
                    }
                    foreach (Guna2Panel pnlColor in panelConteiner)
                    {
                        pnlColor.FillColor = System.Drawing.Color.CornflowerBlue;
                    }
                    foreach (Label foreColor in labelsForeColor)
                    {
                        foreColor.ForeColor = System.Drawing.Color.White;
                    }
                    pnlBackground.FillColor = System.Drawing.Color.LightSteelBlue;
                    dataGridStock.BackgroundColor = System.Drawing.Color.CornflowerBlue;
                    break;


                case "light":
                    foreach (Guna2Panel colorDark in mainColor)
                    {
                        colorDark.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(160)))), ((int)(((byte)(153))))); ;
                    }
                    foreach (Guna2Panel pnlColor in panelConteiner)
                    {
                        pnlColor.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(124)))), ((int)(((byte)(137))))); ;
                    }
                    foreach (Label foreColor in labelsForeColor)
                    {
                        foreColor.ForeColor = System.Drawing.Color.White;
                    }
                    pnlBackground.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(145)))), ((int)(((byte)(141))))); ;
                    dataGridStock.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(124)))), ((int)(((byte)(137))))); ;
                    break;

                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }


        private void btnSalesCenter_Click(object sender, EventArgs e)
        {
            mp.OpenPanel("btnSales");
        }

        private void btnDashboardCenter_Click(object sender, EventArgs e)
        {
            mp.OpenPanel("btnDashboard");
        }

        private void btnProductsCenter_Click(object sender, EventArgs e)
        {
            mp.OpenPanel("btnProducts");
        }

        private void btnShoppingCenter_Click(object sender, EventArgs e)
        {
            mp.OpenPanel("btnShopping");
        }

        private void btnWorkersCenter_Click(object sender, EventArgs e)
        {
            mp.OpenPanel("btnWorkers");
        }

        private void btnConfigCenter_Click(object sender, EventArgs e)
        {
            mp.OpenPanel("btnConfig");
        }
    }
}
