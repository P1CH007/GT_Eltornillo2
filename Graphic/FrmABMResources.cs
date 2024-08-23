using Entities;
using Logic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Graphic
{
    public partial class FrmABMResources : Form
    {

        Color mainColor = Color.FromArgb(0, 0, 0);
        Color scndColor = Color.FromArgb(0, 0, 0);
        Color trdColor = Color.FromArgb(0, 0, 0);
        Color background = Color.FromArgb(0, 0, 0);

        public FrmABMResources(string selected, Color mainColor, Color scndColor, Color trdColor, Color background, object entity = null)
        {
            this.mainColor = mainColor;
            this.scndColor = scndColor;
            this.trdColor = trdColor;
            this.background = background;
            InitializeComponent();
            switch (selected)
            {
                case "employee":
                    TabControlOptions.SelectedIndex = 1;
                    this.Width = 810;
                    SetupEmployeeForm(entity as Employees);
                    lblWTitle.Text = "Administrar empleado";
                    break;
                case "shop":
                    TabControlOptions.SelectedIndex = 2;
                    this.Width = 683;
                    SetupLocalForm(entity as Local);
                    lblWTitle.Text = "Administrar local";
                    break;
                case "provider":
                    TabControlOptions.SelectedIndex = 3;
                    this.Width = 598;
                    SetupSupplierForm(entity as Supplier);
                    lblWTitle.Text = "Administrar proveedor";
                    break;
                case "client":
                    TabControlOptions.SelectedIndex = 0;
                    this.Width = 598;
                    SetupClientForm(entity as Clients);
                    lblWTitle.Text = "Administrar cliente";
                    break;
                default:
                    throw new ArgumentException("Invalid selection");
            }

            RoundCorners(this, 20);
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

        private void SetupEmployeeForm(Employees employee)
        {
            if (employee != null)
            {
                // Inicializar los campos con los datos del objeto Employee
                txtEmployeeCi.Text = employee.EmployeeCi;
                txtEmployeeName.Text = employee.EmployeeName;
                txtEmployeeLastName.Text = employee.EmployeeLastName;
                txtEmployeeCity.Text = employee.City;
                txtEmployeeStreet.Text = employee.Street;
                txtEmployeeNumberSt.Text = employee.NumberSt;
                txtEmployeePhone.Text = employee.Phone;
                txtEmployeeEmail.Text = employee.Email;
                pbImgEmployee.Image = employee.ImgEmployee;
                dtpBirthDate.Value = employee.BirthDate != DateTime.MinValue ? employee.BirthDate : DateTime.Now;
                dtpDateOfAdmission.Value = employee.DateOfAdmission != DateTime.MinValue ? employee.DateOfAdmission : DateTime.Now;
                txtEmployeeUserAcc.Text = employee.UserAcc;
                txtEmployeePasswordAcc.Text = employee.PasswordAcc;
                cmbEmployeeTypeUser.Text = employee.UserType;

                btnAddEmployee.Enabled = false;
                btnModEmployee.Enabled = true;
            }
            else
            {
                btnAddEmployee.Enabled = true;
                btnModEmployee.Enabled = false;
            }
        }

        private void SetupLocalForm(Local local)
        {
            if (local != null)
            {
                // Inicializar los campos con los datos del objeto Local
                txtLocalId.Text = local.LocalID.ToString();
                txtLocalName.Text = local.LocalName;
                txtLocalCountry.Text = local.Country;
                txtLocalCity.Text = local.City;
                txtLocalStreet.Text = local.Street;
                txtLocalNumberSt.Text = local.NumberSt;
                rtxLocalServices.Text = string.Join(", ", local.Services);
                rtxLocalDescription.Text = local.Description;
                dtpOpeningTime.Value = DateTime.Today.Add(local.OpeningTime);
                dtpClosingTime.Value = DateTime.Today.Add(local.ClosingTime);

                btnAddShop.Enabled = false;
                btnModShop.Enabled = true;
            }
            else
            {
                btnAddShop.Enabled = true;
                btnModShop.Enabled = false;
            }
        }

        private void SetupSupplierForm(Supplier supplier)
        {
            if (supplier != null)
            {
                // Inicializar los campos con los datos del objeto Supplier
                txtSupplierId.Text = supplier.SupplierID.ToString();
                txtSupplierName.Text = supplier.SupplierFirstName;
                txtSupplierCountry.Text = supplier.Country;
                txtSupplierCity.Text = supplier.City;
                txtSupplierStreet.Text = supplier.Street;
                txtSupplierNumberSt.Text = supplier.NumberSt;
                txtSupplierPhone.Text = supplier.Phone;
                txtSupplierEmail.Text = supplier.Email;
                rtxSupplierTypeProducts.Text = supplier.TypeProducts;

                btnAddProvider.Enabled = false;
                btnModProvider.Enabled = true;
            }
            else
            {
                btnAddProvider.Enabled = true;
                btnModProvider.Enabled = false;
            }
        }

        private void SetupClientForm(Clients client)
        {
            if (client != null)
            {
                // Inicializar los campos con los datos del objeto Client
                txtClientCi.Text = client.ClientCi;
                txtClientName.Text = client.ClientName;
                txtClientLastName.Text = client.ClientLastName;
                dtpClientDateOfAdmission.Value = client.DateOfAdmission;
                txtClientPhone.Text = client.Phone;
                txtClientEmail.Text = client.Email;
                txtClientCity.Text = client.City;
                txtClientStreet.Text = client.Street;
                txtClientNumberSt.Text = client.NumberSt;

                btnAddClient.Enabled = false;
                btnModClient.Enabled = true;
            }
            else
            {
                btnAddClient.Enabled = true;
                btnModClient.Enabled = false;
            }
        }


        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); 
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void picBClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
        }

        private void btnSelectImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectImg = new OpenFileDialog();
            selectImg.Filter = "Imágenes|*.jpg; *.png";
            selectImg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            selectImg.Title = "Seleccionar imagen";

            if (selectImg.ShowDialog() == DialogResult.OK)
            {
                pbImgEmployee.Image = Image.FromFile(selectImg.FileName);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Capturar los datos de los campos de texto
            string employeeCi = txtEmployeeCi.Text;
            string employeeName = txtEmployeeName.Text;
            string employeeLastName = txtEmployeeLastName.Text;
            string city = txtEmployeeCity.Text;
            string street = txtEmployeeStreet.Text;
            string numberSt = txtEmployeeNumberSt.Text;
            string phone = txtEmployeePhone.Text;
            string email = txtEmployeeEmail.Text;
            DateTime birthDate = dtpBirthDate.Value;
            DateTime dateOfAdmission = dtpDateOfAdmission.Value;
            string userAcc = txtEmployeeUserAcc.Text;
            string passwordAcc = txtEmployeePasswordAcc.Text;
            string userType = cmbEmployeeTypeUser.Text;
            Image imgEmployee = pbImgEmployee.Image;

            // Crear un objeto Employees
            Employees employee = new Employees(employeeCi, employeeName, employeeLastName, city, street, numberSt, phone, email, birthDate, dateOfAdmission, userAcc, passwordAcc, userType, imgEmployee);

            // Llamar al método AddEmployee de la capa de lógica
            EmployeeDAO employeeDAO = new EmployeeDAO();
            bool isAdded = employeeDAO.AddEmployee(employee);

            if (isAdded)
            {
                MessageBox.Show("Empleado agregado exitosamente.");
                string borrar = "black";
                string typeLoad = "employee";
                FrmResources load = new FrmResources(borrar, typeLoad, mainColor, scndColor, trdColor, background);
                load.LoadEmployees();

                this.Close();
            }
            else
            {
                MessageBox.Show("Error al agregar el empleado.");
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            // Capturar los datos de los campos de texto
            string employeeCi = txtEmployeeCi.Text;
            string employeeName = txtEmployeeName.Text;
            string employeeLastName = txtEmployeeLastName.Text;
            string city = txtEmployeeCity.Text;
            string street = txtEmployeeStreet.Text;
            string numberSt = txtEmployeeNumberSt.Text;
            string phone = txtEmployeePhone.Text;
            string email = txtEmployeeEmail.Text;
            DateTime birthDate = dtpBirthDate.Value;
            DateTime dateOfAdmission = dtpDateOfAdmission.Value;
            string userAcc = txtEmployeeUserAcc.Text;
            string passwordAcc = txtEmployeePasswordAcc.Text;
            string userType = cmbEmployeeTypeUser.Text;
            Image imgEmployee = pbImgEmployee.Image;

            // Crear un objeto Employees con los datos modificados
            Employees employee = new Employees(employeeCi, employeeName, employeeLastName, city, street, numberSt, phone, email, birthDate, dateOfAdmission, userAcc, passwordAcc, userType, imgEmployee);

            // Llamar al método UpdateEmployee de la capa de lógica
            EmployeeDAO employeeDAO = new EmployeeDAO();
            bool isUpdated = employeeDAO.UpdateEmployee(employee);

            if (isUpdated)
            {
                string borrar = "black";
                MessageBox.Show("Empleado modificado exitosamente.");
                string typeLoad = "employee";
                FrmResources load = new FrmResources(borrar, typeLoad, mainColor, scndColor, trdColor, background);
                load.LoadEmployees();

                this.Close();
            }
            else
            {
                MessageBox.Show("Error al modificar el empleado.");
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnIconSelectImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectImg = new OpenFileDialog();
            selectImg.Filter = "Imágenes|*.jpg; *.png";
            selectImg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            selectImg.Title = "Seleccionar imagen";

            if (selectImg.ShowDialog() == DialogResult.OK)
            {
                pbImgEmployee.Image = Image.FromFile(selectImg.FileName);
            }
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
                    }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            // Capturar los datos de los campos de texto para clientes
            string clientCi = txtClientCi.Text;
            string clientName = txtClientName.Text;
            string clientLastName = txtClientLastName.Text;
            DateTime dateOfAdmission = dtpClientDateOfAdmission.Value;
            string phone = txtClientPhone.Text;
            string email = txtClientEmail.Text;
            string city = txtClientCity.Text;
            string street = txtClientStreet.Text;
            string numberSt = txtClientNumberSt.Text;

            // Crear un objeto Clients
            Clients client = new Clients(clientCi, clientName, clientLastName, city, street, numberSt, phone, email, dateOfAdmission);

            // Llamar al método AddClient de la capa de lógica
            ClientsDAO clientDAO = new ClientsDAO();
            bool isAdded = clientDAO.AddClient(client);

            if (isAdded)
            {
                MessageBox.Show("Cliente agregado exitosamente.");
                string typeLoad = "client";
                FrmResources load = new FrmResources("black", typeLoad, mainColor, scndColor, trdColor, background);
                load.LoadClients();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al agregar el cliente.");
            }
        }

        private void btnModClient_Click(object sender, EventArgs e)
        {
            // Capturar los datos de los campos de texto para clientes
            string clientCi = txtClientCi.Text;
            string clientName = txtClientName.Text;
            string clientLastName = txtClientLastName.Text;
            DateTime dateOfAdmission = dtpClientDateOfAdmission.Value;
            string phone = txtClientPhone.Text;
            string email = txtClientEmail.Text;
            string city = txtClientCity.Text;
            string street = txtClientStreet.Text;
            string numberSt = txtClientNumberSt.Text;

            // Crear un objeto Clients con los datos modificados
            Clients client = new Clients(clientCi, clientName, clientLastName, city, street, numberSt, phone, email, dateOfAdmission);

            // Llamar al método UpdateClient de la capa de lógica
            ClientsDAO clientDAO = new ClientsDAO();
            bool isUpdated = clientDAO.UpdateClient(client);

            if (isUpdated)
            {
                MessageBox.Show("Cliente modificado exitosamente.");
                string typeLoad = "client";
                FrmResources load = new FrmResources("black", typeLoad, mainColor, scndColor, trdColor, background);
                load.LoadClients();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al modificar el cliente.");
            }
        }

        private void btnAddProvider_Click(object sender, EventArgs e)
        {
            // Capturar los datos de los campos de texto para proveedores
            int supplierID = int.Parse(txtSupplierId.Text);
            string supplierFirstName = txtSupplierName.Text;
            string country = txtSupplierCountry.Text;
            string city = txtSupplierCity.Text;
            string street = txtSupplierStreet.Text;
            string numberSt = txtSupplierNumberSt.Text;
            string phone = txtSupplierPhone.Text;
            string email = txtSupplierEmail.Text;
            string typeProducts = rtxSupplierTypeProducts.Text;

            // Crear un objeto Supplier
            Supplier supplier = new Supplier(supplierID, supplierFirstName, country, city, street, numberSt, phone, email, typeProducts);

            // Llamar al método AddSupplier de la capa de lógica
            SupplierDAO supplierDAO = new SupplierDAO();
            bool isAdded = supplierDAO.AddSupplier(supplier);

            if (isAdded)
            {
                MessageBox.Show("Proveedor agregado exitosamente.");
                string typeLoad = "supplier";
                FrmResources load = new FrmResources("black", typeLoad, mainColor, scndColor, trdColor, background);
                load.LoadSuppliers();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al agregar el proveedor.");
            }
        }

        private void btnModProvider_Click(object sender, EventArgs e)
        {
            // Capturar los datos de los campos de texto para proveedores
            int supplierID = int.Parse(txtSupplierId.Text);
            string supplierFirstName = txtSupplierName.Text;
            string country = txtSupplierCountry.Text;
            string city = txtSupplierCity.Text;
            string street = txtSupplierStreet.Text;
            string numberSt = txtSupplierNumberSt.Text;
            string phone = txtSupplierPhone.Text;
            string email = txtSupplierEmail.Text;
            string typeProducts = rtxSupplierTypeProducts.Text;

            // Crear un objeto Supplier con los datos modificados
            Supplier supplier = new Supplier(supplierID, supplierFirstName, country, city, street, numberSt, phone, email, typeProducts);

            // Llamar al método UpdateSupplier de la capa de lógica
            SupplierDAO supplierDAO = new SupplierDAO();
            bool isUpdated = supplierDAO.UpdateSupplier(supplier);

            if (isUpdated)
            {
                MessageBox.Show("Proveedor modificado exitosamente.");
                string typeLoad = "supplier";
                FrmResources load = new FrmResources("black", typeLoad, mainColor, scndColor, trdColor, background);
                load.LoadSuppliers();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al modificar el proveedor.");
            }
        }

        private void btnAddShop_Click(object sender, EventArgs e)
        {
            // Capturar los datos de los campos de texto para locales
            int localID = int.Parse(txtLocalId.Text);
            string localName = txtLocalName.Text;
            string country = txtLocalCountry.Text;
            string city = txtLocalCity.Text;
            string street = txtLocalStreet.Text;
            string numberSt = txtLocalNumberSt.Text;
            string[] services = rtxLocalServices.Text.Split(',');
            string description = rtxLocalDescription.Text;
            TimeSpan openingTime = dtpOpeningTime.Value.TimeOfDay;
            TimeSpan closingTime = dtpClosingTime.Value.TimeOfDay;

            // Crear un objeto Local
            Local local = new Local(localID, localName, country, city, street, numberSt, services, description, openingTime, closingTime);

            // Llamar al método AddLocal de la capa de lógica
            LocalDAO localDAO = new LocalDAO();
            bool isAdded = localDAO.AddLocal(local);

            if (isAdded)
            {
                MessageBox.Show("Local agregado exitosamente.");
                string typeLoad = "local";
                FrmResources load = new FrmResources("black", typeLoad, mainColor, scndColor, trdColor, background);
                load.LoadLocal();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al agregar el local.");
            }
        }
        private void btnModShop_Click(object sender, EventArgs e)
        {
            // Capturar los datos de los campos de texto para locales
            int localID = int.Parse(txtLocalId.Text);
            string localName = txtLocalName.Text;
            string country = txtLocalCountry.Text;
            string city = txtLocalCity.Text;
            string street = txtLocalStreet.Text;
            string numberSt = txtLocalNumberSt.Text;
            string[] services = rtxLocalServices.Text.Split(',');
            string description = rtxLocalDescription.Text;
            TimeSpan openingTime = dtpOpeningTime.Value.TimeOfDay;
            TimeSpan closingTime = dtpClosingTime.Value.TimeOfDay;

            // Crear un objeto Local con los datos modificados
            Local local = new Local(localID, localName, country, city, street, numberSt, services, description, openingTime, closingTime);

            // Llamar al método UpdateLocal de la capa de lógica
            LocalDAO localDAO = new LocalDAO();
            bool isUpdated = localDAO.UpdateLocal(local);

            if (isUpdated)
            {
                MessageBox.Show("Local modificado exitosamente.");
                string typeLoad = "local";
                FrmResources load = new FrmResources("black", typeLoad, mainColor, scndColor, trdColor, background);
                load.LoadLocal();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al modificar el local.");
            }
        }
    }
}
