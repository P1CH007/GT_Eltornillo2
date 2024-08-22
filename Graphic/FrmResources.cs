using Entities;
using Guna.UI2.WinForms;
using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic
{
    public partial class FrmResources : Form
    {
        private string selected = "client";

        public FrmResources(string theme, string load)
        {
            InitializeComponent();           

            
            if (load == "all")
            {
                
                LoadEmployees();
                LoadClients();
                LoadSuppliers();
                LoadLocal();
            }
            else
            {
                
                switch (load)
                {
                    case "employee":
                        
                        LoadEmployees();
                        break;
                    case "client":
                        
                        LoadClients();
                        break;
                    case "supplier":
                        
                        LoadSuppliers();
                        break;
                    case "local":
                        
                        LoadLocal();
                        break;
                    default:
                        throw new ArgumentException("Invalid value for load");
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Implementación del botón si es necesario
        }

        private void btnDelEmployee_Click(object sender, EventArgs e)
        {
            // Implementación del botón si es necesario
        }

        public void LoadEmployees()
        {
            // Verificar si el DataGridView está inicializado
            if (dgvWorkers == null)
            {
                MessageBox.Show("El DataGridView 'dgvWorkers' no está inicializado.");
                return;
            }

            EmployeeDAO employeeDAO = new EmployeeDAO();
            List<Employees> employees = employeeDAO.GetEmployees();

            // Limpiar filas existentes
            dgvWorkers.Rows.Clear();

            // Construir la ruta relativa a las imágenes desde el directorio del proyecto
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string editImagePath = Path.Combine(projectDirectory, "Graphic", "img", "editEmployee.png");
            string deleteImagePath = Path.Combine(projectDirectory, "Graphic", "img", "deleteEmployee.png");

            // Verificar si los archivos existen
            if (!File.Exists(editImagePath))
            {
                MessageBox.Show($"La imagen de edición no se encontró en la ruta: {editImagePath}");
                return;
            }

            if (!File.Exists(deleteImagePath))
            {
                MessageBox.Show($"La imagen de eliminación no se encontró en la ruta: {deleteImagePath}");
                return;
            }

            // Cargar las imágenes y redimensionarlas
            Image editEmployeeImage = Image.FromFile(editImagePath);
            Image deleteEmployeeImage = Image.FromFile(deleteImagePath);
            Image resizedEditImage = ResizeImage(editEmployeeImage, 40, 40); // Ajusta el tamaño según sea necesario
            Image resizedDeleteImage = ResizeImage(deleteEmployeeImage, 40, 40); // Ajusta el tamaño según sea necesario

            // Agregar columnas de imagen si no existen


            // Ajustar el alto de las filas
            dgvWorkers.RowTemplate.Height = 50; // Ajusta la altura de las filas según sea necesario

            // Establecer el modo de ajuste automático de columnas





            // Agregar filas al DataGridView
            foreach (var employee in employees)
            {
                dgvWorkers.Rows.Add(employee.EmployeeCi, employee.EmployeeName, employee.EmployeeLastName, employee.Phone, employee.Email,
                    employee.City, employee.Street, employee.NumberSt, employee.UserType, resizedEditImage, resizedDeleteImage);
            }

            //MessageBox.Show("Empleados cargados exitosamente.");
        }

        public void LoadClients()
        {
            
            // Verificar si el DataGridView está inicializado
            if (dgvClients == null)
            {
                MessageBox.Show("El DataGridView 'dgvClients' no está inicializado.");
                return;
            }

            ClientsDAO ClientsDAO = new ClientsDAO();
            List<Clients> clients = ClientsDAO.GetClients();

            // Limpiar filas existentes
            dgvClients.Rows.Clear();

            // Construir la ruta relativa a las imágenes desde el directorio del proyecto
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string editImagePath = Path.Combine(projectDirectory, "Graphic", "img", "editEmployee.png");
            string deleteImagePath = Path.Combine(projectDirectory, "Graphic", "img", "deleteEmployee.png");

            // Verificar si los archivos existen
            if (!File.Exists(editImagePath))
            {
                MessageBox.Show($"La imagen de edición no se encontró en la ruta: {editImagePath}");
                return;
            }

            if (!File.Exists(deleteImagePath))
            {
                MessageBox.Show($"La imagen de eliminación no se encontró en la ruta: {deleteImagePath}");
                return;
            }

            // Cargar las imágenes y redimensionarlas
            Image editEmployeeImage = Image.FromFile(editImagePath);
            Image deleteEmployeeImage = Image.FromFile(deleteImagePath);
            Image resizedEditImage = ResizeImage(editEmployeeImage, 40, 40); // Ajusta el tamaño según sea necesario
            Image resizedDeleteImage = ResizeImage(deleteEmployeeImage, 40, 40); // Ajusta el tamaño según sea necesario




            // Ajustar el alto de las filas
            dgvClients.RowTemplate.Height = 50; // Ajusta la altura de las filas según sea necesario

            // Establecer el modo de ajuste automático de columnas





            // Agregar filas al DataGridView
            foreach (var client in clients)
            {
                dgvClients.Rows.Add(client.ClientCi, client.ClientName, client.ClientLastName, client.Phone, client.Email,
                    client.City, client.Street, client.NumberSt, resizedEditImage, resizedDeleteImage);
            }

            //MessageBox.Show("Clientes cargados exitosamente.");
        }

        public void LoadLocal()
        {
            // Verificar si el DataGridView está inicializado
            if (dgvLocal == null)
            {
                MessageBox.Show("El DataGridView 'dgvLocal' no está inicializado.");
                return;
            }

            LocalDAO localDAO = new LocalDAO();
            List<Local> locals = localDAO.GetLocals();

            // Limpiar filas existentes
            dgvLocal.Rows.Clear();

            // Construir la ruta relativa a las imágenes desde el directorio del proyecto
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string editImagePath = Path.Combine(projectDirectory, "Graphic", "img", "editEmployee.png");
            string deleteImagePath = Path.Combine(projectDirectory, "Graphic", "img", "deleteEmployee.png");

            // Verificar si los archivos existen
            if (!File.Exists(editImagePath))
            {
                MessageBox.Show($"La imagen de edición no se encontró en la ruta: {editImagePath}");
                return;
            }

            if (!File.Exists(deleteImagePath))
            {
                MessageBox.Show($"La imagen de eliminación no se encontró en la ruta: {deleteImagePath}");
                return;
            }

            // Cargar las imágenes y redimensionarlas
            Image editLocalImage = Image.FromFile(editImagePath);
            Image deleteLocalImage = Image.FromFile(deleteImagePath);
            Image resizedEditImage = ResizeImage(editLocalImage, 40, 40); // Ajusta el tamaño según sea necesario
            Image resizedDeleteImage = ResizeImage(deleteLocalImage, 40, 40); // Ajusta el tamaño según sea necesario

            // Ajustar el alto de las filas
            dgvLocal.RowTemplate.Height = 50; // Ajusta la altura de las filas según sea necesario

            // Establecer el modo de ajuste automático de columnas
            dgvLocal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Agregar filas al DataGridView
            foreach (var local in locals)
            {
                dgvLocal.Rows.Add(local.LocalID, local.LocalName, local.OpeningTime.ToString(@"hh\:mm"), local.ClosingTime.ToString(@"hh\:mm"), local.Services,
                    local.Country, local.City, local.Street, local.NumberSt, resizedEditImage, resizedDeleteImage);
            }

            // MessageBox.Show("Locales cargados exitosamente.");
        }

        public void LoadSuppliers()
        {
            // Verificar si el DataGridView está inicializado
            if (dgvSuppliers == null)
            {
                MessageBox.Show("El DataGridView 'dgvSuppliers' no está inicializado.");
                return;
            }

            SupplierDAO supplierDAO = new SupplierDAO();
            List<Supplier> suppliers = supplierDAO.GetSuppliers();

            // Limpiar filas existentes
            dgvSuppliers.Rows.Clear();

            // Construir la ruta relativa a las imágenes desde el directorio del proyecto
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string editImagePath = Path.Combine(projectDirectory, "Graphic", "img", "editEmployee.png");
            string deleteImagePath = Path.Combine(projectDirectory, "Graphic", "img", "deleteEmployee.png");

            // Verificar si los archivos existen
            if (!File.Exists(editImagePath))
            {
                MessageBox.Show($"La imagen de edición no se encontró en la ruta: {editImagePath}");
                return;
            }

            if (!File.Exists(deleteImagePath))
            {
                MessageBox.Show($"La imagen de eliminación no se encontró en la ruta: {deleteImagePath}");
                return;
            }

            // Cargar las imágenes y redimensionarlas
            Image editSupplierImage = Image.FromFile(editImagePath);
            Image deleteSupplierImage = Image.FromFile(deleteImagePath);
            Image resizedEditImage = ResizeImage(editSupplierImage, 40, 40); // Ajusta el tamaño según sea necesario
            Image resizedDeleteImage = ResizeImage(deleteSupplierImage, 40, 40); // Ajusta el tamaño según sea necesario

            // Ajustar el alto de las filas
            dgvSuppliers.RowTemplate.Height = 50; // Ajusta la altura de las filas según sea necesario

            // Establecer el modo de ajuste automático de columnas
            dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Agregar filas al DataGridView
            foreach (var supplier in suppliers)
            {
                dgvSuppliers.Rows.Add(supplier.SupplierID, supplier.SupplierFirstName, supplier.Country, supplier.City, supplier.Email,
                   supplier.Phone, supplier.Street, supplier.NumberSt, resizedEditImage, resizedDeleteImage);
            }

            // MessageBox.Show("Proveedores cargados exitosamente.");
        }



        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmABMResources addEmployeeForm = new FrmABMResources(selected);
            addEmployeeForm.Show();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            TCOptions.SelectedTab = tpAddClient;
            btnAdd.Text = "Agregar cliente";
            selected = "client";

            buttonsThickness(btnClient, btnEmployee, btnProvider, btnCommerce);
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            TCOptions.SelectedTab = tpAddEmployee;
            btnAdd.Text = "Agregar empleado";
            selected = "employee";

            buttonsThickness(btnEmployee, btnClient, btnProvider, btnCommerce);
        }

        private void btnProvider_Click(object sender, EventArgs e)
        {
            TCOptions.SelectedTab = tpAddProvider;
            btnAdd.Text = "Agregar proveedor";
            selected = "provider";

            buttonsThickness(btnProvider, btnClient, btnEmployee, btnCommerce);
        }

        private void btnCommerce_Click(object sender, EventArgs e)
        {
            TCOptions.SelectedTab = tpAddShop;
            btnAdd.Text = "Agregar local";
            selected = "shop";

            buttonsThickness(btnCommerce, btnClient, btnEmployee, btnProvider);
        }

        private void buttonsThickness(Guna2Button selected, Guna2Button a1, Guna2Button a2, Guna2Button a3)
        {
            selected.BorderThickness = 2;
            a1.BorderThickness = 0;
            a2.BorderThickness = 0;
            a3.BorderThickness = 0;
        }

        private void dgvWorkers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvWorkers.Columns["employeeEdit"] != null && e.ColumnIndex == dgvWorkers.Columns["employeeEdit"].Index)
                {
                    string employeeCi = dgvWorkers.Rows[e.RowIndex].Cells["employeeCi"]?.Value?.ToString();

                    if (string.IsNullOrEmpty(employeeCi))
                    {
                        MessageBox.Show("No se encontró la cédula del empleado.");
                        return;
                    }

                    EmployeeDAO employeeDAO = new EmployeeDAO();
                    Employees employee = employeeDAO.GetEmployeeByCi(employeeCi);

                    if (employee != null) 
                    {
                        FrmABMResources addEmployeeForm = new FrmABMResources(selected, employee);
                        addEmployeeForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Empleado no encontrado.");
                    }
                }
                else if (dgvWorkers.Columns["employeeDelete"] != null && e.ColumnIndex == dgvWorkers.Columns["employeeDelete"].Index)
                {
                    string employeeCi = dgvWorkers.Rows[e.RowIndex].Cells["employeeCi"]?.Value?.ToString();
                    string employeeName = dgvWorkers.Rows[e.RowIndex].Cells["employeeName"]?.Value?.ToString();

                    if (string.IsNullOrEmpty(employeeCi) || string.IsNullOrEmpty(employeeName))
                    {
                        MessageBox.Show("No se encontró la cédula o el nombre del empleado.");
                        return;
                    }

                    DialogResult result = MessageBox.Show($"¿Está seguro de que desea eliminar al empleado {employeeName} con cédula {employeeCi}?", "Confirmar eliminación", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        EmployeeDAO DAO = new EmployeeDAO();
                        bool isDeleted = DAO.DeleteEmployee(employeeCi);

                        if (isDeleted)
                        {
                            //MessageBox.Show("Empleado eliminado exitosamente.");
                            LoadEmployees();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el empleado.");
                        }
                    }
                }
            }
        }

        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Manejo de la acción de edición de cliente
                if (dgvClients.Columns["clientEdit"] != null && e.ColumnIndex == dgvClients.Columns["clientEdit"].Index)
                {
                    // Obtener el CI del cliente de la celda correspondiente
                    string clientCi = dgvClients.Rows[e.RowIndex].Cells["clientCi"]?.Value?.ToString();

                    if (string.IsNullOrEmpty(clientCi))
                    {
                        MessageBox.Show("CI de cliente inválido o no encontrado.");
                        return;
                    }

                    // Obtener los detalles del cliente usando el CI
                    ClientsDAO clientDAO = new ClientsDAO();
                    Clients client = clientDAO.GetClientByCi(clientCi);

                    if (client != null)
                    {
                        // Abrir el formulario de adición/modificación de cliente
                        FrmABMResources addClientForm = new FrmABMResources(selected, client);
                        addClientForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Cliente no encontrado.");
                    }
                }
                // Manejo de la acción de eliminación de cliente
                else if (dgvClients.Columns["clientDelete"] != null && e.ColumnIndex == dgvClients.Columns["clientDelete"].Index)
                {
                    string clientCi = dgvClients.Rows[e.RowIndex].Cells["clientCi"]?.Value?.ToString();
                    string clientName = dgvClients.Rows[e.RowIndex].Cells["clientName"]?.Value?.ToString();

                    if (string.IsNullOrEmpty(clientCi) || string.IsNullOrEmpty(clientName))
                    {
                        MessageBox.Show("No se encontró el CI o el nombre del cliente.");
                        return;
                    }

                    DialogResult result = MessageBox.Show($"¿Está seguro de que desea eliminar al cliente {clientName} con CI {clientCi}?", "Confirmar eliminación", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        ClientsDAO clientDAO = new ClientsDAO();
                        bool isDeleted = clientDAO.DeleteClient(clientCi);

                        if (isDeleted)
                        {
                            // Cliente eliminado exitosamente
                            LoadClients(); // Método para recargar los datos de los clientes
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el cliente.");
                        }
                    }
                }
            }
        }


        private void dgvSuppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
               
                // Manejo de la acción de edición de proveedor
                if (dgvSuppliers.Columns["supplierEdit"] != null && e.ColumnIndex == dgvSuppliers.Columns["supplierEdit"].Index)
                {
                    

                    // Obtener el ID del proveedor de la celda correspondiente
                    int supplierId;
                    bool isParsed = int.TryParse(dgvSuppliers.Rows[e.RowIndex].Cells["supplierId"]?.Value?.ToString(), out supplierId);

                    if (!isParsed || supplierId <= 0)
                    {
                        MessageBox.Show("ID de proveedor inválido o no encontrado.");
                        return;
                    }

                    // Obtener los detalles del proveedor usando el ID
                    SupplierDAO supplierDAO = new SupplierDAO();
                    Supplier supplier = supplierDAO.GetSupplierById(supplierId);

                    if (supplier != null)
                    {
                        // Abrir el formulario de adición/modificación de proveedor
                        FrmABMResources addSupplierForm = new FrmABMResources(selected, supplier);
                        addSupplierForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Proveedor no encontrado.");
                    }
                }
                // Manejo de la acción de eliminación de proveedor
                else if (dgvSuppliers.Columns["supplierDelete"] != null && e.ColumnIndex == dgvSuppliers.Columns["supplierDelete"].Index)
                {
                    
                    string supplierIdStr = dgvSuppliers.Rows[e.RowIndex].Cells["supplierId"]?.Value?.ToString();
                    string supplierName = dgvSuppliers.Rows[e.RowIndex].Cells["supplierName"]?.Value?.ToString();

                    if (string.IsNullOrEmpty(supplierIdStr) || string.IsNullOrEmpty(supplierName))
                    {
                        MessageBox.Show("No se encontró el ID o el nombre del proveedor.");
                        return;
                    }

                    int supplierId;
                    bool isParsed = int.TryParse(supplierIdStr, out supplierId);

                    if (!isParsed || supplierId <= 0)
                    {
                        MessageBox.Show("ID de proveedor inválido.");
                        return;
                    }

                    DialogResult result = MessageBox.Show($"¿Está seguro de que desea eliminar al proveedor {supplierName} con ID {supplierId}?", "Confirmar eliminación", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        SupplierDAO supplierDAO = new SupplierDAO();
                        bool isDeleted = supplierDAO.DeleteSupplier(supplierId);

                        if (isDeleted)
                        {
                            //MessageBox.Show("Proveedor eliminado exitosamente.");
                            LoadSuppliers(); // Método para recargar los datos de los proveedores
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el proveedor.");
                        }
                    }
                }
            }
        }

        private void dgvLocal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                
                // Manejo de la acción de edición de local
                if (dgvLocal.Columns["localEdit"] != null && e.ColumnIndex == dgvLocal.Columns["localEdit"].Index)
                {
                    

                    // Obtener el ID del local de la celda correspondiente
                    int localId;
                    bool isParsed = int.TryParse(dgvLocal.Rows[e.RowIndex].Cells["localId"]?.Value?.ToString(), out localId);

                    if (!isParsed || localId <= 0)
                    {
                        MessageBox.Show("ID de local inválido o no encontrado.");
                        return;
                    }

                    // Obtener los detalles del local usando el ID
                    LocalDAO localDAO = new LocalDAO();
                    Local local = localDAO.GetLocalById(localId);

                    if (local != null)
                    {
                        // Abrir el formulario de adición/modificación de local
                        FrmABMResources addLocalForm = new FrmABMResources(selected, local);
                        addLocalForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Local no encontrado.");
                    }
                }
                // Manejo de la acción de eliminación de local
                else if (dgvLocal.Columns["localDelete"] != null && e.ColumnIndex == dgvLocal.Columns["localDelete"].Index)
                {
                    
                    string localIdStr = dgvLocal.Rows[e.RowIndex].Cells["localId"]?.Value?.ToString();
                    string localName = dgvLocal.Rows[e.RowIndex].Cells["localName"]?.Value?.ToString();

                    if (string.IsNullOrEmpty(localIdStr) || string.IsNullOrEmpty(localName))
                    {
                        MessageBox.Show("No se encontró el ID o el nombre del local.");
                        return;
                    }

                    int localId;
                    bool isParsed = int.TryParse(localIdStr, out localId);

                    if (!isParsed || localId <= 0)
                    {
                        MessageBox.Show("ID de local inválido.");
                        return;
                    }

                    DialogResult result = MessageBox.Show($"¿Está seguro de que desea eliminar el local {localName} con ID {localId}?", "Confirmar eliminación", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {

                        
                        LocalDAO localDAO = new LocalDAO();
                        bool isDeleted = localDAO.DeleteLocal(localId);

                        if (isDeleted)
                        {
                            // MessageBox.Show("Local eliminado exitosamente.");
                            LoadLocal(); // Método para recargar los datos de los locales
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el local.");
                        }
                    }
                }
            }
        }

        private void pnlHeaderConteiner_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
