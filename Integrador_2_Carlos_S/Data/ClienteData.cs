using Microsoft.Data.SqlClient;
using Integrador_2_Carlos_S.Models;

namespace Integrador_2_Carlos_S.Data
{
    public class ClienteData
    {
        private readonly string _connectionString;

        public ClienteData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public List<Cliente> ObtenerTodos()
        {
            var clientes = new List<Cliente>();

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("SELECT Id, Nombre, Apellido, Email, Telefono, Direccion, Ciudad, CodigoPostal, FechaNacimiento, Activo, FechaRegistro FROM Clientes", connection);
            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                clientes.Add(MapearCliente(reader));
            }

            return clientes;
        }

        public Cliente? ObtenerPorId(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("SELECT Id, Nombre, Apellido, Email, Telefono, Direccion, Ciudad, CodigoPostal, FechaNacimiento, Activo, FechaRegistro FROM Clientes WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return MapearCliente(reader);
            }

            return null;
        }

        public void Crear(Cliente cliente)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "INSERT INTO Clientes (Nombre, Apellido, Email, Telefono, Direccion, Ciudad, CodigoPostal, FechaNacimiento, Activo) VALUES (@Nombre, @Apellido, @Email, @Telefono, @Direccion, @Ciudad, @CodigoPostal, @FechaNacimiento, @Activo)", connection);

            AgregarParametros(command, cliente);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public void Actualizar(Cliente cliente)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Telefono = @Telefono, Direccion = @Direccion, Ciudad = @Ciudad, CodigoPostal = @CodigoPostal, FechaNacimiento = @FechaNacimiento, Activo = @Activo WHERE Id = @Id", connection);

            command.Parameters.AddWithValue("@Id", cliente.Id);
            AgregarParametros(command, cliente);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("DELETE FROM Clientes WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            command.ExecuteNonQuery();
        }

        private void AgregarParametros(SqlCommand command, Cliente cliente)
        {
            command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
            command.Parameters.AddWithValue("@Email", cliente.Email);
            command.Parameters.AddWithValue("@Telefono", (object?)cliente.Telefono ?? DBNull.Value);
            command.Parameters.AddWithValue("@Direccion", (object?)cliente.Direccion ?? DBNull.Value);
            command.Parameters.AddWithValue("@Ciudad", (object?)cliente.Ciudad ?? DBNull.Value);
            command.Parameters.AddWithValue("@CodigoPostal", (object?)cliente.CodigoPostal ?? DBNull.Value);
            command.Parameters.AddWithValue("@FechaNacimiento", (object?)cliente.FechaNacimiento ?? DBNull.Value);
            command.Parameters.AddWithValue("@Activo", cliente.Activo);
        }

        private Cliente MapearCliente(SqlDataReader reader)
        {
            return new Cliente
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Apellido = reader.GetString(2),
                Email = reader.GetString(3),
                Telefono = reader.IsDBNull(4) ? null : reader.GetString(4),
                Direccion = reader.IsDBNull(5) ? null : reader.GetString(5),
                Ciudad = reader.IsDBNull(6) ? null : reader.GetString(6),
                CodigoPostal = reader.IsDBNull(7) ? null : reader.GetString(7),
                FechaNacimiento = reader.IsDBNull(8) ? null : reader.GetDateTime(8),
                Activo = reader.GetBoolean(9),
                FechaRegistro = reader.GetDateTime(10)
            };
        }
    }
}
