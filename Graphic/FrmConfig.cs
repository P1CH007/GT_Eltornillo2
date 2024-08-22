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
    public partial class Config : Form
    {
        private MainApplication mainApplication;
        


        public Config(MainApplication mainApp, string saveTeme)
        {
            InitializeComponent();
            mainApplication = mainApp;
            temeChange(saveTeme);

            switch (saveTeme)
            {
                case "dark":
                    picBDarkSelected.Visible = true;
                    break;
                case "red":
                    picBRedSelected.Visible = true;
                    break;
                case "blue":
                    picBBlueSelected.Visible = true;
                    break;
                case "light":
                    picBLightSelected.Visible = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }


        private void picBoxDarkTeme_Click(object sender, EventArgs e)
        {
                string teme = "dark";
            temeChange(teme);
            picBDarkSelected.Visible = true;
            picBBlueSelected.Visible = false;
            picBRedSelected.Visible = false;
            picBLightSelected.Visible = false;
        }

        private void picBoxRedTeme_Click(object sender, EventArgs e)
        {
            string teme = "red";
            temeChange(teme);
            picBDarkSelected.Visible = false;
            picBBlueSelected.Visible = false;
            picBRedSelected.Visible = true;
            picBLightSelected.Visible = false;
        }

        private void picBoxBlueTeme_Click(object sender, EventArgs e)
        {
            string teme = "blue";
            temeChange(teme);
            picBDarkSelected.Visible = false;
            picBBlueSelected.Visible = true;
            picBRedSelected.Visible = false;
            picBLightSelected.Visible = false;
        }

        private void picBoxLightTeme_Click(object sender, EventArgs e)
        {
            string teme = "light";
            temeChange(teme);
            picBDarkSelected.Visible = false;
            picBBlueSelected.Visible = false;
            picBRedSelected.Visible = false;
            picBLightSelected.Visible = true;
        }

        private void temeChange(string teme)
        {
            Guna.UI2.WinForms.Guna2Panel[] mainColor = { pnlBadges, pnlDataConteiner, pnlFooter, pnlAppConfigTitle, pnlTemes, pnlAppConfigConteiner, pnlBudgetTitle };

            Guna.UI2.WinForms.Guna2Panel[] conteinerColor = { pnlConfigTitle, pnlBudgetBackground, pnlConfigBackground };

            Label[] labelsForeColor = {lblPassword, lblPhone1, lblPhone2 };
            Guna.UI2.WinForms.Guna2Button[] buttonsForeColor = { btnClean, btnContinue };


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
                    foreach (Guna2Button foreColor in buttonsForeColor)
                    {
                        foreColor.ForeColor = System.Drawing.Color.White;
                    }
                    pnlBackground.FillColor = System.Drawing.Color.Gray;
                    mainApplication.changeTeme(teme);
                    
                    break;
                    


                case "red":
                    foreach (Guna2Panel colorDark in mainColor)
                    {
                        colorDark.FillColor = 
                            System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(86)))), ((int)(((byte)(72))))); ;
                    }
                    foreach (Guna2Panel colorConteiner in conteinerColor)
                    {
                        colorConteiner.FillColor =
                           System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(46)))), ((int)(((byte)(32))))); ;
                    }
                    foreach (Label foreColor in labelsForeColor)
                    {
                        foreColor.ForeColor = System.Drawing.Color.White;
                    }
                    foreach (Guna2Button foreColor in buttonsForeColor)
                    {
                        foreColor.ForeColor = System.Drawing.Color.White;
                    }
                    pnlBackground.FillColor = 
                        System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(147)))), ((int)(((byte)(136))))); ;
                    mainApplication.changeTeme(teme);
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
                    pnlBackground.FillColor = System.Drawing.Color.LightSteelBlue;
                    mainApplication.changeTeme(teme);
                    break;


                case "light":
                    foreach (Guna2Panel colorDark in mainColor)
                    {
                        colorDark.FillColor = 
                            System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(167))))); ;
                    }
                    foreach (Guna2Panel colorConteiner in conteinerColor)
                    {
                        colorConteiner.FillColor = 
                            System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(111)))), ((int)(((byte)(106))))); ;
                    }
                    foreach (Label foreColor in labelsForeColor)
                    {
                        foreColor.ForeColor = System.Drawing.Color.White;
                    }
                    foreach (Guna2Button foreColor in buttonsForeColor)
                    {
                        foreColor.ForeColor = System.Drawing.Color.White;
                    }
                    pnlBackground.FillColor = 
                        System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(145)))), ((int)(((byte)(141))))); ;
                    mainApplication.changeTeme(teme);
                    break;

                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }



    }
}
