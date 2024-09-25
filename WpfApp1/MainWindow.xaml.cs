using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int idEmpleadoSeleccionado = -1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Listar_Click(object sender, RoutedEventArgs e)
        {
            LoadDataProductos();
        }

        private void Insertar_Click(object sender, RoutedEventArgs e)
        {
            // Crear y mostrar la nueva ventana de inserción
            InsertarEmpleadoWindow insertarWindow = new InsertarEmpleadoWindow();
            insertarWindow.ShowDialog(); // ShowDialog abre la ventana como modal (bloquea la ventana principal)
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (idEmpleadoSeleccionado != -1) // Asegúrate de que se haya seleccionado un empleado
            {
                // Abrir la ventana de eliminación pasando el IdEmpleado seleccionado
                EliminarEmpleadoWindow eliminarWindow = new EliminarEmpleadoWindow(idEmpleadoSeleccionado);
                eliminarWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un empleado para eliminar.");
            }
        }

        private void LoadDataProductos()
        {
            try
            {
                // Cadena de conexión a la base de datos
                string cadena = "Data Source=LAB1507-03\\SQLEXPRESS;Initial Catalog=Neptuno;User ID=usuario01;Password=123456";

                // Crear y abrir la conexión a la base de datos
                SqlConnection connection = new SqlConnection(cadena);

                connection.Open();

                // Crear el comando para ejecutar el procedimiento almacenado
                SqlCommand command = new SqlCommand("USP_ListarEmpleados", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Cargar los datos en el DataGrid
                dgv.ItemsSource = dt.DefaultView;

                connection.Close();
            }

            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgv.SelectedItem != null)
            {
                DataRowView row = (DataRowView)dgv.SelectedItem;
                idEmpleadoSeleccionado = Convert.ToInt32(row["IdEmpleado"]); // Almacenar el IdEmpleado de la fila seleccionada
            }
        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            if (idEmpleadoSeleccionado != -1) // Verificar que se haya seleccionado una fila
            {
                // Abrir la ventana de actualización pasando el IdEmpleado seleccionado
                ActualizarEmpleadoWindow actualizarWindow = new ActualizarEmpleadoWindow(idEmpleadoSeleccionado);
                actualizarWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un empleado para actualizar.");
            }
        }
    }
}

       