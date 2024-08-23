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
    public partial class FrmMakeSale : Form
    {
        private string step = "1";
        private float totalPrice = 0;
        private float moneyPaid = 0;
        private float totalWithDiscount;
        private float totalWithShip;

        Color mainColor = Color.FromArgb(0, 0, 0);
        Color scndColor = Color.FromArgb(0, 0, 0);
        Color trdColor = Color.FromArgb(0, 0, 0);
        Color background = Color.FromArgb(0, 0, 0);

        public FrmMakeSale(Color mainColor, Color scndColor, Color trdColor, Color background)
        {
            InitializeComponent();
            timerResChanges.Start();
            TemeChange(mainColor, scndColor, trdColor, background);

            this.mainColor = mainColor;
            this.scndColor = scndColor;
            this.trdColor = trdColor;
            this.background = background;
        }




        private void btnNext_Click(object sender, EventArgs e)
        {
            int xLocation = this.Width;

            if (step == "2")
            {
                pnlStep2.Location = new Point(5000, 88);
                dataGridProducts.Location = new Point(5000, 88);
                pnlStep3.Location = new Point(0, 88);
                separatorStep3.FillColor = Color.White;
                btnStep3.BorderColor = Color.White;
                btnStep3.ForeColor = Color.White;
                separatorStep2.FillColor = Color.White;
                btnStep2.BorderColor = Color.White;
                btnStep2.ForeColor = Color.White;

                step = "3";
            }

            if (step == "1")
            {
                dataGridProducts.Location = new Point(5000, 88);
                pnlStep2.Location = new Point(0, 88);
                pnlStep3.Location = new Point(5000, 88);

                separatorStep2.FillColor = Color.White;
                btnStep2.BorderColor = Color.White;
                btnStep2.ForeColor = Color.White;

                separatorStep3.FillColor = Color.Gray;
                btnStep3.BorderColor = Color.Gray;
                btnStep3.ForeColor = Color.Gray;

                step = "2";
            }



        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            int xLocation = this.Width;

            if (step == "2")
            {
                dataGridProducts.Location = new Point(0, 88);
                pnlStep2.Location = new Point(5000, 88);
                pnlStep3.Location = new Point(5000, 88);

                separatorStep2.FillColor = Color.Gray;
                btnStep2.BorderColor = Color.Gray;
                btnStep2.ForeColor = Color.Gray;

                btnStep3.BorderColor = Color.Gray;
                btnStep3.ForeColor = Color.Gray;
                separatorStep3.FillColor = Color.Gray;

                step = "1";
            }
            if (step == "3")
            {
                dataGridProducts.Location = new Point(5000, 88);
                pnlStep2.Location = new Point(0, 88);
                pnlStep3.Location = new Point(5000, 88);

                separatorStep2.FillColor = Color.White;
                btnStep2.BorderColor = Color.White;
                btnStep2.ForeColor = Color.White;

                separatorStep3.FillColor = Color.Gray;
                btnStep3.BorderColor = Color.Gray;
                btnStep3.ForeColor = Color.Gray;

                step = "2";
            }
        }

        private void btnStep1_Click(object sender, EventArgs e)
        {
            step = "2";
            btnBack.PerformClick();
            
        }

        private void btnStep2_Click(object sender, EventArgs e)
        {
            step = "1";
            btnNext.PerformClick();
        }

        private void btnStep3_Click(object sender, EventArgs e)
        {
            step = "2";
            btnNext.PerformClick();
        }

        private void MakeSale_Load(object sender, EventArgs e)
        {
            showDataInDataGrid();
        }


        private void refreshValues(string action, string value)
        {
            int articles = int.Parse(lblArticleV.Text);

            float floatValue = float.Parse(value);
            float floatTotalPrice = float.Parse(lblTotalV.Text);

            switch (action)
            {
                case "add":
                    //Agregar 1 articulo al los articulos totales
                    articles = articles + 1;
                    lblArticleV.Text = articles.ToString();

                    //Agregar el costo del producto al costo total 
                    float totalAdd = floatValue + floatTotalPrice;
                    lblTotalV.Text = totalAdd.ToString();
                    totalPrice = totalAdd;

                    break;
                case "del":
                    //eliminar 1 articulo al los articulos totales
                    articles = articles - 1;
                    lblArticleV.Text = articles.ToString();

                    //Eliminar el costo del producto al costo total 
                    float totalDel = floatTotalPrice - floatValue;
                    lblTotalV.Text = totalDel.ToString();
                    totalPrice = totalDel;

                    break;
                case "discount":
                    //Crear el descuento y aplicarlo
                    float discountPercentage = floatValue / 100;
                    float discount = totalPrice * discountPercentage;
                    totalWithDiscount = totalPrice - discount;
                    lblDiscountV.Text = discount.ToString();
                    lblTotalV.Text = totalWithDiscount.ToString();

                    break;
                case "ship":
                    //Agregar el valor de envio
                    lblShipV.Text = floatValue.ToString();
                    totalWithShip = totalPrice + floatValue;
                    
                    lblTotalV.Text = totalWithShip.ToString();
                    break;
            }
        }

        private void comboBoxShip_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxShip.Text == "0")
            {
                refreshValues("ship", "0");
            }
            if (comboBoxShip.Text == "140")
            {
                refreshValues("ship", "140");
            }
            if (comboBoxShip.Text == "240")
            {
                refreshValues("ship", "240");
            }
        }

        private void comboBoxDiscount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxDiscount.Text == "0%")
            {
                refreshValues("discount", "0");
            }
            if (comboBoxDiscount.Text == "5%")
            {
                refreshValues("discount", "5");
            }
            if (comboBoxDiscount.Text == "7%")
            {
                refreshValues("discount", "7");
            }
        }

        private void showDataInDataGrid()
        {

            //En la linea de debajo debera cambiar la ruta, por favor preste atencion al formato de esta, sino el programa no funcionará correctamente.
            string way = @"C:\Users\samio\source\repos\GT_ElTornillo v2.9.49 - v5.15\Graphic\Resources\";
            //Esto es una referencia de como se debera ver @"C:\Users\Pepe\source\repos\El Tornillo - 1erEntrega\Graphic\Resources\"

            Image imgHammer = Image.FromFile(way + "MartilloDeUna.jpg");
            Image imgHammer2 = Image.FromFile(way + "MartilloDeBola.jpg");
            Image imgScrewdriver = Image.FromFile(way + "DestornilladorPlano.jpeg");
            Image imgPhillipsScrewdriver = Image.FromFile(way + "DestornilladorDeEstrella.png");
            Image imgAdjustableSpanner = Image.FromFile(way + "LlaveInglesaAjustable.jpg");
            Image imgPipeWrench = Image.FromFile(way + "LlaveDeTubo.jpg");
            Image imgAllenWrench = Image.FromFile(way + "LlaveAllen.jpg");
            Image imgHandSaw = Image.FromFile(way + "SierraDeMano.jpg");
            Image imgHacksaw = Image.FromFile(way + "SierraParaMetales.jpg");
            Image imgCarpenterSaw = Image.FromFile(way + "SerruchoDeCarpintero.jpg");
            Image imgAdd = Image.FromFile(way + "AddProduct.png");
            Image imgDel = Image.FromFile(way + "DelProduct.png");

            object[] row1 = { 1, "Martillo de uña", "H. Manual", "Acero forjado, 450g, agarre goma", imgHammer, 368, imgAdd, "0", imgDel };
            object[] row2 = { 2, "Martillo de bola", "H. Manual", "Acero al carbono, 225g, agarre madera", imgHammer2, 360, imgAdd, "0", imgDel };
            object[] row3 = { 3, "Destornillador plano", "H. Manual", "Acero al cromo-vanadio, 1/8 pulgadas (3 mm)", imgScrewdriver, 100, imgAdd, "0", imgDel };
            object[] row4 = { 4, "Destornillador de estrella", "H. Manual", "Especificaciones 10x20cm2 x 4", imgPhillipsScrewdriver, 139, imgAdd, "0", imgDel };
            object[] row5 = { 5, "Llave inglesa ajustable", "H. Manual", "Acero al cromo-vanadio", imgAdjustableSpanner, 440, imgAdd, "0", imgDel };
            object[] row6 = { 6, "Llave de tubo", "H. Manual", "Acero al cromo-vanadio, 48 dientes", imgPipeWrench, 532, imgAdd, "0", imgDel };
            object[] row7 = { 7, "Llave Allen", "H. Manual", "acero endurecido, 50 mm", imgAllenWrench, 170, imgAdd, "0", imgDel };
            object[] row8 = { 8, "Sierra de mano", "H. Manual", "Acero al carbono, mango plástico", imgHandSaw, 280, imgAdd, "0", imgDel };
            object[] row9 = { 9, "Sierra para metales", "H. Manual", "Acero de alta velocidad, 300 mm", imgHacksaw, 620, imgAdd, "0", imgDel };
            object[] row10 = { 10, "Serrucho de carpintero", "H. Manual", "Acero al carbono, 600 mm", imgCarpenterSaw, 329, imgAdd, "0", imgDel };


            dataGridProducts.Rows.Add(row1);
            dataGridProducts.Rows.Add(row2);
            dataGridProducts.Rows.Add(row3);
            dataGridProducts.Rows.Add(row4);
            dataGridProducts.Rows.Add(row5);
            dataGridProducts.Rows.Add(row6);
            dataGridProducts.Rows.Add(row7);
            dataGridProducts.Rows.Add(row8);
            dataGridProducts.Rows.Add(row9);
            dataGridProducts.Rows.Add(row10);

        }

        private void dataGridProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentValue = 0;

            // Agregar 1 a la cantidad
            if (this.dataGridProducts.Columns[e.ColumnIndex].Name == "ColumnImageAdd")
            {
                string savedPrice = dataGridProducts.CurrentRow.Cells[5].Value.ToString();



                if (dataGridProducts.CurrentRow.Cells[7].Value != null && int.TryParse(dataGridProducts.CurrentRow.Cells[7].Value.ToString(), out currentValue))
                {
                    int newValue = currentValue + 1;
                    dataGridProducts.CurrentRow.Cells[7].Value = newValue;
                }

                refreshValues("add", savedPrice);
            }

            // Eliminar 1 a la cantidad
            if (this.dataGridProducts.Columns[e.ColumnIndex].Name == "ColumnImageDel")
            {
                if (dataGridProducts.CurrentRow.Cells[7].Value != null && int.TryParse(dataGridProducts.CurrentRow.Cells[7].Value.ToString(), out currentValue))
                {

                    if (currentValue > 0)
                    {
                        string savedPrice = dataGridProducts.CurrentRow.Cells[5].Value.ToString();
                        int newValue = currentValue - 1;
                        dataGridProducts.CurrentRow.Cells[7].Value = newValue;


                        refreshValues("del", savedPrice);
                    }

                }

            }
        }

        private void timerResChanges_Tick(object sender, EventArgs e)
        {
            dataGridProducts.Width = this.Width;
            pnlStep3.Width = this.Width;
        }

        
                private void txtMoneyPaid_TextChanged(object sender, EventArgs e)
                {
                    float moneyPaid;
                    float floatTotalPrice = float.Parse(lblTotalV.Text);
                    if (float.TryParse(txtMoneyPaid.Text, out moneyPaid))
                    {

                        float moneyReturn = moneyPaid - floatTotalPrice;
                        lblMoneyReturnedV.Text = moneyReturn.ToString("F1");

                        if (moneyReturn >= 0)
                        {
                            lblMoneyReturnedV.ForeColor = Color.Green;

                        }
                        if (moneyReturn < 0)
                        {
                            lblMoneyReturnedV.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        lblMoneyReturnedV.Text = "";
                    }


                }

                private void btnShowTicket_Click(object sender, EventArgs e)
                {
                    Form ticket = new FrmTicket(txtMoneyPaid.Text, lblMoneyReturnedV.Text, totalPrice.ToString());
                    ticket.Show();
                }


        private void comboBoxIsRegistred_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxIsRegistred.Text == "Si")
            {
                pnlRegister.Visible = false;
            }
            if (comboBoxIsRegistred.Text == "No")
            {
                pnlRegister.Visible = true;
            }
        }

        private void btnRegisterClient_Click(object sender, EventArgs e)
        {
            FrmABMResources addEmployeeForm = new FrmABMResources("client", mainColor, scndColor, trdColor, background);
            addEmployeeForm.Show();
        }

        private void pnlRegister_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBCash_Click(object sender, EventArgs e)
        {
            lblPaymentMethod.Text = "Efectivo";
            checkBCredit.Checked = false;
            checkBDebit.Checked = false;

            pnlCashMethod.FillColor = Color.DimGray;
            pnlDebitMethod.FillColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))); ;
            pnlCreditMethod.FillColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))); ;


            txtFulName.Enabled = false;
            txtCvv.Enabled = false;
            dateTimePickerExpiration.Enabled = false;
            txtCardNumber.Enabled = false;
            txtDues.Enabled = false;
        }

        private void checkBCredit_Click(object sender, EventArgs e)
        {
            lblPaymentMethod.Text = "Tarjeta de crédito";
            checkBCash.Checked = false;
            checkBDebit.Checked = false;

            pnlCashMethod.FillColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))); ;
            pnlDebitMethod.FillColor = Color.DimGray;
            pnlCreditMethod.FillColor = Color.DimGray;

            txtFulName.Enabled = true;
            txtCvv.Enabled = true;
            dateTimePickerExpiration.Enabled = true;
            txtCardNumber.Enabled = true;
            txtDues.Enabled = true;

        }

        private void checkBDebit_Click(object sender, EventArgs e)
        {
            lblPaymentMethod.Text = "Tarjeta de débito";
            checkBCredit.Checked = false;
            checkBCash.Checked = false;

            pnlCashMethod.FillColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))); ;
            pnlDebitMethod.FillColor = Color.DimGray;
            pnlCreditMethod.FillColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))); ;

            txtFulName.Enabled = true;
            txtCvv.Enabled = true;
            dateTimePickerExpiration.Enabled = true;
            txtCardNumber.Enabled = true;
            txtDues.Enabled = false;
        }















        
          private void TemeChange(Color color1, Color color2, Color color3, Color background)
          {
            Guna2Panel[] mainColor = { pnlFooter, pnlNextStep, pnlStepBack, pnlSteps, pnlClientData, pnlFormTitle,
                pnlMoney, pnlRegister, pnlSaleData, pnlPayBackground, pnlPayButtons, pnlPayMethod, pnlPayMethodTitle };
            Guna2Panel[] conteinerColor = { pnlTotal, pnlArticle, pnlDiscount, pnlShip};
            Guna2Panel[] lightColor = {  };
            Guna2Panel[] backgroundColor = { pnlStep2, pnlStep3, pnlBackground };

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

            /*
            DataGridViewCellStyle rowStyleDark = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.Gray,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84))))),
                SelectionForeColor = Color.White
            };

            DataGridViewCellStyle headerStyleDark = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)((byte)(64)))),
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
            };

            DataGridViewCellStyle rowStyleRed = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))),
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
                SelectionForeColor = Color.Black
            };

            DataGridViewCellStyle headerStyleRed = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.IndianRed,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
            };

            DataGridViewCellStyle rowStyleBlue = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.LightSteelBlue,
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = System.Drawing.Color.CornflowerBlue,
                SelectionForeColor = Color.White
            };

            DataGridViewCellStyle headerStyleBlue = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.RoyalBlue,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
            };

            DataGridViewCellStyle rowStyleLight = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(145)))), ((int)(((byte)(141))))),
                ForeColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(167))))),
                SelectionForeColor = Color.White
            };

            DataGridViewCellStyle headerStyleLight = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(120)))), ((int)(((byte)(114))))),
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))))
            };

            */

        }
         
         
    }
}
