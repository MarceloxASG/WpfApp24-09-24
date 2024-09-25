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
    /// Lógica de interacción para ActualizarEmpleadoWindow.xaml
    /// </summary>
    public partial class ActualizarEmpleadoWindow : Window
    {
        public ActualizarEmpleadoWindow(int IdEmpleado)
        {
            InitializeComponent();
            CargarDatosEmpleado(IdEmpleado);
        }

        private void CargarDatosEmpleado(int IdEmpleado)
        {
            try
            {
                string cadena = "Data Source=LAB1507-03\\SQLEXPRESS;Initial Catalog=Neptuno;User ID=usuario01;Password=123456";
                using (SqlConnection connection = new SqlConnection(cadena))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM Empleados WHERE IdEmpleado = @IdEmpleado", connection);
                    command.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtApellidos.Text = reader["Apellidos"].ToString();
                        txtNombre.Text = reader["Nombre"].ToString();
                        txtCargo.Text = reader["Cargo"].ToString();
                        txtTratamiento.Text = reader["Tratamiento"].ToString();
                        dtpFechaNacimiento.SelectedDate = Convert.ToDateTime(reader["FechaNacimiento"]);
                        dtpFechaContratacion.SelectedDate = Convert.ToDateTime(reader["FechaContratacion"]);
                        txtDireccion.Text = reader["Direccion"].ToString();
                        txtCiudad.Text = reader["Ciudad"].ToString();
                        txtRegion.Text = reader["Region"].ToString();
                        txtCodPostal.Text = reader["CodPostal"].ToString();
                        txtPais.Text = reader["Pais"].ToString();
                        txtTelDomicilio.Text = reader["TelDomicilio"].ToString();
                        txtExtension.Text = reader["Extension"].ToString();
                        txtNotas.Text = reader["Notas"].ToString();
                        txtJefe.Text = reader["Jefe"].ToString();
                        txtSueldoBasico.Text = reader["SueldoBasico"].ToString();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del empleado: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "Data Source=LAB1507-03\\SQLEXPRESS;Initial Catalog=Neptuno;User ID=usuario01;Password=123456";
                using (SqlConnection connection = new SqlConnection(cadena))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("USP_ActualizarEmpleado", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros para el procedimiento almacenado (incluye el IdEmpleado para identificar qué empleado actualizar)
                    SqlParameter sqlParameter1 = new SqlParameter("@IdEmpleado", SqlDbType.Int);
                    sqlParameter1.Value = Convert.ToInt32(txtIdEmpleado.Text);

                    SqlParameter sqlParameter2 = new SqlParameter("@Apellidos", SqlDbType.VarChar, 20);
                    sqlParameter2.Value = txtApellidos.Text;

                    SqlParameter sqlParameter3 = new SqlParameter("@Nombre", SqlDbType.VarChar, 20);
                    sqlParameter3.Value = txtNombre.Text;

                    SqlParameter sqlParameter4 = new SqlParameter("@Cargo", SqlDbType.VarChar, 40);
                    sqlParameter4.Value = txtCargo.Text;

                    SqlParameter sqlParameter5 = new SqlParameter("@Tratamiento", SqlDbType.VarChar, 40);
                    sqlParameter5.Value = txtTratamiento.Text;

                    SqlParameter sqlParameter6 = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
                    sqlParameter6.Value = dtpFechaNacimiento.SelectedDate;

                    SqlParameter sqlParameter7 = new SqlParameter("@FechaContratacion", SqlDbType.Date);
                    sqlParameter7.Value = dtpFechaContratacion.SelectedDate;

                    SqlParameter sqlParameter8 = new SqlParameter("@Direccion", SqlDbType.VarChar, 60);
                    sqlParameter8.Value = txtDireccion.Text;

                    SqlParameter sqlParameter9 = new SqlParameter("@Ciudad", SqlDbType.VarChar, 15);
                    sqlParameter9.Value = txtCiudad.Text;

                    SqlParameter sqlParameter10 = new SqlParameter("@Region", SqlDbType.VarChar, 15);
                    sqlParameter10.Value = txtRegion.Text;

                    SqlParameter sqlParameter11 = new SqlParameter("@CodPostal", SqlDbType.VarChar, 10);
                    sqlParameter11.Value = txtCodPostal.Text;

                    SqlParameter sqlParameter12 = new SqlParameter("@Pais", SqlDbType.VarChar, 15);
                    sqlParameter12.Value = txtPais.Text;

                    SqlParameter sqlParameter13 = new SqlParameter("@TelDomicilio", SqlDbType.VarChar, 24);
                    sqlParameter13.Value = txtTelDomicilio.Text;

                    SqlParameter sqlParameter14 = new SqlParameter("@Extension", SqlDbType.VarChar, 4);
                    sqlParameter14.Value = txtExtension.Text;

                    SqlParameter sqlParameter15 = new SqlParameter("@Notas", SqlDbType.Text);
                    sqlParameter15.Value = txtNotas.Text;

                    SqlParameter sqlParameter16 = new SqlParameter("@Jefe", SqlDbType.Int);
                    sqlParameter16.Value = Convert.ToInt32(txtJefe.Text);

                    SqlParameter sqlParameter17 = new SqlParameter("@SueldoBasico", SqlDbType.Decimal);
                    sqlParameter17.Value = Convert.ToDecimal(txtSueldoBasico.Text);

                    // Añadir parámetros al comando
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
                    command.Parameters.Add(sqlParameter17);

                    // Ejecutar el comando para actualizar
                    command.ExecuteNonQuery();
                    MessageBox.Show("Empleado actualizado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el empleado: " + ex.Message);
            }
        }
    }
}
