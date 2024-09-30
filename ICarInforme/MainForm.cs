using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer;
using CrystalDecisions.Windows.Forms;
using System.Collections.Specialized;
using CrystalDecisions.ReportAppServer.Prompting;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.Web.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Controls;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Xml.Linq;
using CrystalDecisions.Shared;
using System.Windows.Documents;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;



namespace ICarInformes
{
    public struct Informe
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Fichero { get; set; }
    }

    public enum ParameterType
    {
        CON,
        Edit,
        Date
    }

    public struct Parameter
    {
        public ParameterType ParameterType { get; set; } // 
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public partial class fMain : Form
    {
        private string ReportConnectionString = string.Empty;
        private string AutonetConnectionString = string.Empty;
        private string ReportDirectory = string.Empty;
        private bool OverrideParameterDB = false;

        private int InformeActual = 0;
        private List<Parameter> parameters;

        public fMain()
        {
            InitializeComponent();
        }

        private string GetCurrentUser()
        {
            // UserPrincipal currentUser = UserPrincipal.Current;
            // string username = currentUser.Name;
            
            string username = System.Windows.Forms.SystemInformation.UserName;
            
            return username;
        }

        private Informe GetDataInforme(int IdInformes)
        {
            string parametros = "SELECT idInformes AS Id, Descripcion AS Informe, Report AS Fichero FROM [dbo].[Informes] WHERE idInformes = @idInformes";
            SqlCommand query = new SqlCommand(parametros);
            query.Parameters.Add("@idInformes", SqlDbType.Int).Value = IdInformes;
            Informe informe = new Informe();

            try
            {
                DataTable dt = GetData(query);
                informe.Id = int.Parse(dt.Rows[0]["Id"].ToString().Trim());
                informe.Descripcion = dt.Rows[0]["Informe"].ToString().Trim();
                informe.Fichero = dt.Rows[0]["Fichero"].ToString().Trim();
            }
            catch {
                informe.Id = 0;
                informe.Descripcion = String.Empty;
                informe.Fichero = String.Empty;
            }
            return informe;
        }

        private string GetRazonEmpresa()
        {
            SqlCommand query = new SqlCommand("SELECT Razon FROM tgEmpresa");
            string RazonSocial = String.Empty;
            string defaultValue = "Grupo de Concesionarios de Toyota en Canarias";
            try
            {
                DataTable dt = GetData(query, AutonetConnectionString);
                RazonSocial = dt!=null ? dt.Rows[0]["Razon"].ToString().Trim() : defaultValue;
            }
            catch
            {
                RazonSocial = defaultValue;
            }
            return RazonSocial;
        }

        private void CargarConfiguracion()
        {
            try
            {
                ReportDirectory = ConfigurationManager.AppSettings["ReportDirectory"];
                AutonetConnectionString = ConfigurationManager.AppSettings["AutonetConnectionString"];
                ReportConnectionString = ConfigurationManager.AppSettings["ReportConnectionString"];
                OverrideParameterDB = (ConfigurationManager.AppSettings["OverrideParameterDB"] == "true");
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Error leyendo la configuración del programa. Claves: [ReportDirectory,AutonetConnectionString,ReportConnectionString].", "Error leyendo la configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            ReportDirectory = Path.Combine(ReportDirectory, String.Empty);
            ReportDirectory = ReportDirectory + "\\";
        }

        private void PopulateReports(int parentId, System.Windows.Forms.TreeNode treeNode, string usuario)
        {
            string Descripcion = String.Empty;
            int IdInforme = 0;

            string hijos = "SELECT AI.idInformes AS IdInforme, I.Descripcion AS Descripcion, I.Report AS Report FROM [dbo].[RelArbolInformes] AI INNER JOIN [dbo].[RelUsuarioArbol] UA ON AI.IdArbol=UA.IdArbol INNER JOIN [dbo].[Informes] I ON AI.idInformes=I.idInformes WHERE UA.Usuario = @Usuario AND AI.IdArbol=@IdArbol ORDER BY AI.Orden";
            SqlCommand query = new SqlCommand(hijos);
            query.Parameters.Add("@Usuario", SqlDbType.NVarChar, 25).Value = usuario;
            query.Parameters.Add("@IdArbol", SqlDbType.Int).Value = parentId;

            DataTable dt = GetData(query);

            foreach (DataRow row in dt.Rows)
            {
                Descripcion = row["Descripcion"].ToString();
                IdInforme = Convert.ToInt32(row["IdInforme"].ToString());
                System.Windows.Forms.TreeNode child = new System.Windows.Forms.TreeNode
                {
                    Text = Descripcion,
                    Tag = IdInforme,
                    ImageKey = "report"
                };
                treeNode.Nodes.Add(child);
            }
        }

        private void AddDatePicker(string title, string variable)
        {
            System.Windows.Forms.GroupBox groupBox = new System.Windows.Forms.GroupBox
            {
                Text = title,
                Height = 50,
                Dock = DockStyle.Top,
                Tag = "FECHA"
            };

            System.Windows.Forms.DateTimePicker datePicker = new System.Windows.Forms.DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                MinDate = new DateTime(1980, 1, 1),
                Dock = DockStyle.Fill,
                Tag = variable
            };
            groupBox.Controls.Add(datePicker);
            flpParametros.Controls.Add(groupBox);
        }

        private void AddTextBox(string title, string variable)
        {
            System.Windows.Forms.GroupBox groupBox = new System.Windows.Forms.GroupBox
            {
                Text = title,
                Height = 50,
                Dock = DockStyle.Top,
                Tag = "EDIT"
            };

            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox
            {
                Dock = DockStyle.Fill,
                Tag = variable
            };
            groupBox.Controls.Add(textBox);
            flpParametros.Controls.Add(groupBox);
        }

        private void AddComboBox(string title, string variable, string consulta, bool conTodos)
        {
            System.Windows.Forms.GroupBox groupBox = new System.Windows.Forms.GroupBox
            {
                Text = title,
                Height = 50,
                Dock = DockStyle.Top,
                Tag = "CON"
            };

            System.Windows.Forms.ComboBox comboBox = new System.Windows.Forms.ComboBox
            {
                Dock = DockStyle.Fill,
                Tag = variable,
                DataSource = GetData(new SqlCommand(consulta), AutonetConnectionString, conTodos),
                DisplayMember = "descrip",
                ValueMember = "CODIGO",
                DropDownStyle = ComboBoxStyle.DropDownList
            };

 
            groupBox.Controls.Add(comboBox);
            flpParametros.Controls.Add(groupBox);
        }

        private void ClearParameterPanel()
        {
            InformeActual = 0;
            SetVerInformeButtonState(false);
            while (flpParametros.Controls.Count > 0)
            {
                System.Windows.Forms.Control control = flpParametros.Controls[0];
                flpParametros.Controls.Remove(control);
                control.Dispose();
            }
        }


        private void CargarParametros(int idInformes)
        {
            ClearParameterPanel();

            string parametros = "SELECT P.Descripcion AS Descripcion, P.Nombre AS Nombre, P.idTipoParametros AS Tipo, P.Consulta AS Consulta, ConTodos AS ConTodos FROM [dbo].[Parametros] P INNER JOIN [dbo].[Informes] I ON I.idInformes = P.idInformes WHERE P.idInformes = @idInformes ORDER BY p.Orden";
            SqlCommand query = new SqlCommand(parametros);
            query.Parameters.Add("@idInformes", SqlDbType.Int).Value = idInformes;

            DataTable dt = GetData(query);
            foreach (DataRow row in dt.Rows)
            {
                string Descripcion = row["Descripcion"].ToString().Trim();
                string Nombre = row["Nombre"].ToString().Trim();
                string Tipo = row["Tipo"].ToString().Trim();
                string Consulta = row["Consulta"] as string ?? string.Empty;
                bool ConTodos = false;
                try
                {
                    ConTodos = (bool)row["ConTodos"];
                }
                catch {
                    ConTodos = false;
                }
                if (OverrideParameterDB) {
                    Consulta = Consulta.Replace("Autonet.", GetDatabaseName(AutonetConnectionString) + ".");
                }

                if (Tipo.ToUpper().Equals("FECHA")) // Fecha
                    AddDatePicker(Descripcion, Nombre);
                if (Tipo.ToUpper().Equals("EDIT")) // Edit
                    AddTextBox(Descripcion, Nombre);
                if (Tipo.ToUpper().Equals("CON")) // CON
                    AddComboBox(Descripcion, Nombre, Consulta, ConTodos);
            }
            SetVerInformeButtonState(true);
        }

        private void PopulateTreeView(int parentId, System.Windows.Forms.TreeNode treeNode, string usuario)
        {
            string Descripcion;
            int IdArbol;

            string hijos = "SELECT A.IdArbol AS IdArbol, Descripcion, Rama, Nivel, IdPadre, EsHoja FROM [dbo].[Arbol] A INNER JOIN [dbo].[RelUsuarioArbol] UA ON UA.IdArbol = A.IdArbol WHERE ISNULL(IdPadre, 0) = @IdPadre AND UA.Usuario = @Usuario";
            SqlCommand query = new SqlCommand(hijos);
            query.Parameters.Add("@Usuario", SqlDbType.NVarChar, 25).Value = usuario;
            query.Parameters.Add("@IdPadre", SqlDbType.Int).Value = parentId;

            DataTable dt = GetData(query);
            if (dt == null) return;
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    Descripcion = row["Descripcion"].ToString();
                    IdArbol = Convert.ToInt32(row["IdArbol"].ToString());
                    System.Windows.Forms.TreeNode child = new System.Windows.Forms.TreeNode
                    {
                        Text = Descripcion,
                        Tag = IdArbol
                    };

                    if (treeNode == null)
                    {
                        tvInformes.Nodes.Add(child);
                    }
                    else
                    {
                        treeNode.Nodes.Add(child);
                    }

                    PopulateTreeView(IdArbol, child, usuario);
                    PopulateReports(IdArbol, child, usuario);
                }
            }
            catch {
                System.Windows.Forms.MessageBox.Show("Error leyendo la información de los menús y sus asignaciones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }


        private DataTable GetData(SqlCommand query, string cs = null, bool conTodos = false)
        {
             DataTable dt = new DataTable();

            string connectionString;
            if (cs != null)
            {
                connectionString = cs; // use alternate cs
            }
            else {
                connectionString = ReportConnectionString; // Use default report cs
            }
            try
            {
                if (conTodos == true) {
                    dt.Columns.Add("descrip", typeof(string));
                    dt.Columns.Add("CODIGO", typeof(string));
                    DataRow row = dt.NewRow();
                    row["descrip"] = "TODOS";
                    row["CODIGO"] = "%";
                    dt.Rows.Add(row);
                }
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        query.CommandType = CommandType.Text;
                        query.Connection = con;
                        sda.SelectCommand = query;
                        sda.Fill(dt);
                    }
                    return dt;
                }
            }
            catch {
                return null;
            }
        }

        private void RecargarInformes()
        {
            ClearParameterPanel();
            SetVerInformeButtonState(false);

            string usuario = GetCurrentUser();
            tvInformes.Nodes.Clear();
            PopulateTreeView(0, null, usuario);
        }

        private void tsbRecargar_Click(object sender, EventArgs e)
        {
            RecargarInformes();
        }

        private void SalirDeLaAplicacion()
        {
            System.Windows.Forms.Application.Exit();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            SalirDeLaAplicacion();
        }

        private void tvInformes_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var hitTest = e.Node.TreeView.HitTest(e.Location);
            if (hitTest.Location == TreeViewHitTestLocations.PlusMinus) return;
            if (e.Node.ImageKey == "report")
            {
                if (int.TryParse(e.Node.Tag.ToString(), out int id))
                {
                    CargarParametros(id);
                    InformeActual = id;
                }
                else {
                    ClearParameterPanel();
                }
            }
            else {
                e.Node.Toggle();
                ClearParameterPanel();
            }
        }

        private void SetVerInformeButtonState(bool state)
        {
            bVerInforme.Enabled = state;
            tsbVerInforme.Enabled = state;
            tsmiVerInforme.Enabled = state;
        }

        private void tsmiRecargar_Click(object sender, EventArgs e)
        {
            RecargarInformes();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            CargarConfiguracion();
            RecargarInformes();
        }

        List<Parameter> GetReportParameters()
        {
            // Rescue parameter values!
            parameters = new List<Parameter>();
            ParameterType pt = ParameterType.Edit;
            for (int i = 0; i < flpParametros.Controls.Count; i++)
            {
                // Control grControl = flpParametros.Controls[0]; // groupbox (Tag=Type:FECHA, CON, EDIT)
                // Control valControl = flpParametros.Controls[0].Controls[0]; // EditBox, Combo or Datepciker.
                // string varName = valControl.Tag.ToString().Trim(); // var name : @FechaIni
                string varName;
                string value;

                if (flpParametros.Controls[i].Controls[0] is System.Windows.Forms.TextBox textBox)
                {
                    pt = ParameterType.Edit;
                    varName = textBox.Tag.ToString().Trim();
                    value = textBox.Text;
                }
                else if (flpParametros.Controls[i].Controls[0] is System.Windows.Forms.ComboBox comboBox)
                {
                    pt = ParameterType.CON;
                    varName = comboBox.Tag.ToString().Trim();
                    // string name = comboBox.Text;

                    if (comboBox.SelectedValue != null)
                    {
                        value = comboBox.SelectedValue.ToString().Trim();
                    }
                    else
                    {
                        value = "%";
                    }
                }
                else if (flpParametros.Controls[i].Controls[0] is System.Windows.Forms.DateTimePicker dateTimePicker)
                {
                    pt = ParameterType.Date;
                    varName = dateTimePicker.Tag.ToString().Trim();
                    DateTime dateTimePickerValue = dateTimePicker.Value;
                    string user = Environment.UserName;
                    if (user.Equals("mr_ji")) {
                        value = dateTimePickerValue.ToString("yyyy-MM-dd"); // Format: 2023-03-15
                    }
                    else {
                        value = dateTimePickerValue.ToString("dd-MM-yyyy"); // Format: 2023-03-15
                    }
                }
                else
                {
                    SetVerInformeButtonState(false);
                    ClearParameterPanel();
                    return null;
                }
                parameters.Add(new Parameter { ParameterType = pt, Name = varName, Value = value });
            }

            return parameters;
        }

        private void OpenReport(string reportConnectionString)
        {
            if (0 == InformeActual)
            {
                SetVerInformeButtonState(false);
                return;
            }
            Informe informe = GetDataInforme(InformeActual);
            if (informe.Id == 0 && informe.Fichero == String.Empty && informe.Descripcion == String.Empty)
            {
                System.Windows.Forms.MessageBox.Show("No se ha podido leer la información del Informe actual (ID: " + InformeActual + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //////////////////////////////////////////////////////
            //System.Windows.Forms.MessageBox.Show("Informe actual (ID: " + InformeActual + ")\nDescripción: " + informe.Descripcion + "\nFichero: '" + informe.Fichero + "'", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //////////////////////////////////////////////////////

            string reportFile = ReportDirectory + informe.Fichero;
            if (!File.Exists(reportFile))
            {
                System.Windows.Forms.MessageBox.Show("No se encuentra el archivo del informe seleccionado ('" + reportFile + "'). Revise el fichero de configuración.", "Error de lectura de fichero", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            parameters = GetReportParameters();
            if (null == parameters)
            {
                SetVerInformeButtonState(false);
                return;
            }

            // Create the report
            ReportDocument myDataReport = new ReportDocument();
            myDataReport.Load(reportFile);
            myDataReport.Refresh();
            // Set the parameters to the report
            foreach (var parameter in parameters) {
                if (parameter.ParameterType == ParameterType.CON || parameter.Name.Contains("Codigo"))
                {
                    // Value is a Code (long integer)
                    // myDataReport.SetParameterValue(parameter.Name, long.Parse(parameter.Value));
                    myDataReport.SetParameterValue(parameter.Name, parameter.Value.ToString().Trim());
                } else if (parameter.ParameterType == ParameterType.Date || parameter.Name.Contains("Fecha")) {
                    // Value is a date:
                    myDataReport.SetParameterValue(parameter.Name, parameter.Value.ToString().Replace('/', '-'));
                }
                else
                {
                    // Value is a string (Textbox)
                    myDataReport.SetParameterValue(parameter.Name, parameter.Value.ToString().Trim());
                }
            }
            // Create the window form
            Form fReport = new Form
            {
                Icon = Icon.FromHandle(((Bitmap)ilMain.Images[0]).GetHicon()),
                Height = 720,
                Width = 1280
            };
            // Create Crystal Report Vierew and assign report
            CrystalReportViewer crv1 = new CrystalReportViewer
            {
                Dock = DockStyle.Fill,
                ToolPanelView = ToolPanelViewType.None,
                ReportSource = myDataReport,
                ReuseParameterValuesOnRefresh = true
            };
            if (OverrideParameterDB)
            {
                ConnectionInfo connectionInfo = new ConnectionInfo
                {
                    ServerName = GetServerName(ReportConnectionString),
                    DatabaseName = GetDatabaseName(ReportConnectionString),
                    UserID = GetUserName(ReportConnectionString),
                    Password = GetPasswordName(ReportConnectionString),
                    // AllowCustomConnection = true,
                    IntegratedSecurity = false
                };

                // Create login data
                TableLogOnInfo logOnInfoData = new TableLogOnInfo
                {
                    ConnectionInfo = connectionInfo
                };
                // Apply login data to report
                foreach (CrystalDecisions.CrystalReports.Engine.Table table in myDataReport.Database.Tables)
                {
                    table.ApplyLogOnInfo(logOnInfoData);
                    table.LogOnInfo.ConnectionInfo = connectionInfo;
                    table.LogOnInfo.ReportName = table.LogOnInfo.TableName;
                }
                // TableLogOnInfos logOnInfos = crv1.LogOnInfo;
                foreach (TableLogOnInfo logOnInfo in crv1.LogOnInfo)
                {
                    logOnInfo.ConnectionInfo = connectionInfo;
                }
            }

            
            fReport.Controls.Add(crv1);
            // myDataReport.Refresh();
            fReport.Show();
         }

        private string ExtractKeyword(string input, string name)
        {
            string[] pairs = input.Split(';');
            foreach (string pair in pairs)
            {
                string[] keyValue = pair.Split('=');
                if (keyValue.Length == 2 && keyValue[0].Trim() == name)
                {
                    return keyValue[1].Trim();
                }
            }
            return String.Empty; // Default value
        }

        private string GetServerName(string input)
        {
            // "Data Source='HAL9000';Initial Catalog=ICarInforme_TYN;User ID=icaragent;Password=toyicaragentota;Persist Security Info=True;"
            return ExtractKeyword(input, "Data Source").Replace("'", "").Trim();
        }

        private string GetDatabaseName(string input)
        {
            // "Data Source='HAL9000';Initial Catalog=ICarInforme_TYN;User ID=icaragent;Password=toyicaragentota;Persist Security Info=True;"
            return ExtractKeyword(input, "Initial Catalog").Replace("'", "").Trim();
        }

        private string GetUserName(string input)
        {
            // "Data Source='HAL9000';Initial Catalog=ICarInforme_TYN;User ID=icaragent;Password=toyicaragentota;Persist Security Info=True;"
            return ExtractKeyword(input, "User ID").Replace("'", "").Trim();
        }

        private string GetPasswordName(string input)
        {
            // "Data Source='HAL9000';Initial Catalog=ICarInforme_TYN;User ID=icaragent;Password=toyicaragentota;Persist Security Info=True;"
            return ExtractKeyword(input, "Password").Replace("'", "").Trim();
        }

        private void bVerInforme_Click(object sender, EventArgs e)
        {
            OpenReport(ReportConnectionString);
        }

        private void tsmiSalir_Click(object sender, EventArgs e)
        {
            SalirDeLaAplicacion();
        }

        private string GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Version version = assembly.GetName().Version;
            return $"Version {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }


        private void tsmiAcercaDe_Click(object sender, EventArgs e)
        {
            About about = new About
            {
                VersionText = GetVersion(),
                DescriptionText = "Programa de soporte para ver los informes de I'Car reealizados en Crystal Reports.",
                CompanyNameText = GetRazonEmpresa(),
                CopyrightText = "2024 © Valper Soluciones y Mantenimientos S.L."
            };
            about.ShowDialog();
            
        }
    }
}
