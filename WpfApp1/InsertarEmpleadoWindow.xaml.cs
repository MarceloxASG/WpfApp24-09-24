using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para InsertarEmpleadoWindow.xaml
    /// </summary>
    public partial class InsertarEmpleadoWindow : Window
    {
        public InsertarEmpleadoWindow()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "Data Source=LAB1507-03\\SQLEXPRESS;Initial Catalog=Neptuno;User ID=usuario01;Password=123456";
                using (SqlConnection connection = new SqlConnection(cadena))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("USP_InsertarEmpleado", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros para el procedimiento almacenado
                    SqlParameter sqlParameter0 = new SqlParameter("@IdEmpleado", SqlDbType.Int);
                    sqlParameter0.Value = txtIdEmpleado.Text;

                    SqlParameter sqlParameter1 = new SqlParameter("@Apellidos", SqlDbType.VarChar, 20);
                    sqlParameter1.Value = txtApellidos.Text;

                    SqlParameter sqlParameter2 = new SqlParameter("@Nombre", SqlDbType.VarChar, 20);
                    sqlParameter2.Value = txtNombre.Text;

                    SqlParameter sqlParameter3 = new SqlParameter("@Cargo", SqlDbType.VarChar, 40);
                    sqlParameter3.Value = txtCargo.Text;

                    SqlParameter sqlParameter4 = new SqlParameter("@Tratamiento", SqlDbType.VarChar, 40);
                    sqlParameter4.Value = txtTratamiento.Text;

                    SqlParameter sqlParameter5 = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
                    sqlParameter5.Value = dtpFechaNacimiento.SelectedDate;

                    SqlParameter sqlParameter6 = new SqlParameter("@FechaContratacion", SqlDbType.Date);
                    sqlParameter6.Value = dtpFechaContratacion.SelectedDate;

                    SqlParameter sqlParameter7 = new SqlParameter("@Direccion", SqlDbType.VarChar, 60);
                    sqlParameter7.Value = txtDireccion.Text;

                    SqlParameter sqlParameter8 = new SqlParameter("@Ciudad", SqlDbType.VarChar, 15);
                    sqlParameter8.Value = txtCiudad.Text;

                    SqlParameter sqlParameter9 = new SqlParameter("@Region", SqlDbType.VarChar, 15);
                    sqlParameter9.Value = txtRegion.Text;

                    SqlParameter sqlParameter10 = new SqlParameter("@CodPostal", SqlDbType.VarChar, 10);
                    sqlParameter10.Value = txtCodPostal.Text;

                    SqlParameter sqlParameter11 = new SqlParameter("@Pais", SqlDbType.VarChar, 15);
                    sqlParameter11.Value = txtPais.Text;

                    SqlParameter sqlParameter12 = new SqlParameter("@TelDomicilio", SqlDbType.VarChar, 24);
                    sqlParameter12.Value = txtTelDomicilio.Text;

                    SqlParameter sqlParameter13 = new SqlParameter("@Extension", SqlDbType.VarChar, 4);
                    sqlParameter13.Value = txtExtension.Text;

                    SqlParameter sqlParameter14 = new SqlParameter("@Notas", SqlDbType.Text);
                    sqlParameter14.Value = txtNotas.Text;

                    SqlParameter sqlParameter15 = new SqlParameter("@Jefe", SqlDbType.Int);
                    sqlParameter15.Value = Convert.ToInt32(txtJefe.Text);

                    SqlParameter sqlParameter16 = new SqlParameter("@SueldoBasico", SqlDbType.Decimal);
                    sqlParameter16.Value = Convert.ToDecimal(txtSueldoBasico.Text);

                    // Añadir parámetros al comando
                    command.Parameters.Add(sqlParameter0);
                    command.Parameters.Add(sqlParameter1);
                    command.Parameters.Add(sqlParameter2);
                    command.Parameters.Add(sqlParameter3);
                    command.Parameters.Add(sqlParameter4);
                    command.Parameters.Add(sqlParameter5);
                    command.Parameters.Add(sqlParameter6);
                    command.Parameters.Add(sqlParameter7);
                    command.Parameters.Add(sqlParameter8);
                    command.Parameters.Add(sqlParameter9);
                    command.Parameters.Add(sqlParameter10);
                    command.Parameters.Add(sqlParameter11);
                    command.Parameters.Add(sqlParameter12);
                    command.Parameters.Add(sqlParameter13);
                    command.Parameters.Add(sqlParameter14);
                    command.Parameters.Add(sqlParameter15);
                    command.Parameters.Add(sqlParameter16);

                    // Ejecutar el comando
                    command.ExecuteNonQuery();
                    MessageBox.Show("Empleado insertado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }

}
