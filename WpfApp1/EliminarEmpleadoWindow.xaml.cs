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
    /// Lógica de interacción para EliminarEmpleadoWindow.xaml
    /// </summary>
    public partial class EliminarEmpleadoWindow : Window
    {
        private int idEmpleadoAEliminar;
        public EliminarEmpleadoWindow(int idEmpleado)
        {
            InitializeComponent();
            idEmpleadoAEliminar = idEmpleado; // Pasar el IdEmpleado desde la ventana principal
            txtIdEmpleado.Text = idEmpleado.ToString(); // Mostrar en el cuadro de texto
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "Data Source=LAB1507-03\\SQLEXPRESS;Initial Catalog=Neptuno;User ID=usuario01;Password=123456";
                using (SqlConnection connection = new SqlConnection(cadena))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("USP_EliminarEmpleado", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetro para el IdEmpleado a eliminar
                    command.Parameters.AddWithValue("@IdEmpleado", idEmpleadoAEliminar);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Empleado eliminado correctamente.");
                    this.Close(); // Cerrar la ventana de eliminación
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el empleado: " + ex.Message);
            }
        }
    }
}
