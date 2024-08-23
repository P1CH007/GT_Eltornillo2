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

        Color mainColor = Color.FromArgb(0, 0, 0);
        Color scndColor = Color.FromArgb(0, 0, 0);
        Color trdColor = Color.FromArgb(0, 0, 0);
        Color background = Color.FromArgb(0, 0, 0);


        public Config(MainApplication mainApp, string savetheme, Color mainColor, Color scndColor, Color trdColor, Color background)
        {
            InitializeComponent();
            mainApplication = mainApp;
            this.mainColor = mainColor;
            this.scndColor = scndColor;
            this.trdColor = trdColor;
            this.background = background;
            
            themeChange(savetheme);

            switch (savetheme)
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




        private void themeChange(string theme)
        {
            Guna2Panel[] mainPanels = { pnlBadges, pnlDataConteiner, pnlFooter, pnlAppConfigTitle,
                pnlThemes, pnlAppConfigConteiner, pnlBudgetTitle, pnlFormTitle };
            Guna2Panel[] conteinerColor = { pnlConfigTitle, pnlBudgetBackground, pnlConfigBackground };
            Guna2Panel[] backgroundPanel = { pnlBackground };



            switch (theme)
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
                    foreach (Guna2Panel colorConteiner in conteinerColor)
                    {
                        colorConteiner.FillColor = scndColor;
                    }
                    foreach (Guna2Panel backgroundColor in backgroundPanel)
                    {
                        backgroundColor.FillColor = background;
                    }
                    picBDarkSelected.Visible = true;
                    picBBlueSelected.Visible = false;
                    picBRedSelected.Visible = false;
                    picBLightSelected.Visible = false;
                    picBOrangeThemeSelected.Visible = false;

                    mainApplication.changeTheme(theme ,mainColor, scndColor, trdColor, background);
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
                    foreach (Guna2Panel colorConteiner in conteinerColor)
                    {
                        colorConteiner.FillColor = scndColor;
                    }
                    foreach (Guna2Panel backgroundColor in backgroundPanel)
                    {
                        backgroundColor.FillColor = background;
                    }

                    picBDarkSelected.Visible = false;
                    picBBlueSelected.Visible = false;
                    picBRedSelected.Visible = true;
                    picBLightSelected.Visible = false;
                    picBOrangeThemeSelected.Visible = false;

                    mainApplication.changeTheme(theme, mainColor, scndColor, trdColor, background);
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
                    foreach (Guna2Panel colorConteiner in conteinerColor)
                    {
                        colorConteiner.FillColor = scndColor;
                    }
                    foreach (Guna2Panel backgroundColor in backgroundPanel)
                    {
                        backgroundColor.FillColor = background;
                    }

                    picBDarkSelected.Visible = false;
                    picBBlueSelected.Visible = true;
                    picBRedSelected.Visible = false;
                    picBLightSelected.Visible = false;
                    picBOrangeThemeSelected.Visible = false;

                    mainApplication.changeTheme(theme, mainColor, scndColor, trdColor, background);
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
                    foreach (Guna2Panel colorConteiner in conteinerColor)
                    {
                        colorConteiner.FillColor = scndColor;
                    }
                    foreach (Guna2Panel backgroundColor in backgroundPanel)
                    {
                        backgroundColor.FillColor = background;
                    }

                    picBDarkSelected.Visible = false;
                    picBBlueSelected.Visible = false;
                    picBRedSelected.Visible = false;
                    picBLightSelected.Visible = true;
                    picBOrangeThemeSelected.Visible = false;

                    mainApplication.changeTheme(theme, mainColor, scndColor, trdColor, background);
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
                    foreach (Guna2Panel colorConteiner in conteinerColor)
                    {
                        colorConteiner.FillColor = scndColor;
                    }
                    foreach (Guna2Panel backgroundColor in backgroundPanel)
                    {
                        backgroundColor.FillColor = background;
                    }

                    picBDarkSelected.Visible = false;
                    picBBlueSelected.Visible = false;
                    picBRedSelected.Visible = false;
                    picBLightSelected.Visible = false;
                    picBOrangeThemeSelected.Visible = true;

                    mainApplication.changeTheme(theme, mainColor, scndColor, trdColor, background);
                    break;

                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        private void picBDarkTheme_Click(object sender, EventArgs e)
        {
            string theme = "dark";
            themeChange(theme);
        }

        private void picBoxRedTheme_Click(object sender, EventArgs e)
        {
            string theme = "red";
            themeChange(theme);
        }

        private void picBBlueTheme_Click(object sender, EventArgs e)
        {
            string theme = "blue";
            themeChange(theme);
        }

        private void picBoxLightTheme_Click(object sender, EventArgs e)
        {
            string theme = "light";
            themeChange(theme);
        }

        private void picBOrangeTheme_Click(object sender, EventArgs e)
        {
            string theme = "orange";
            themeChange(theme);
        }
    }
}
