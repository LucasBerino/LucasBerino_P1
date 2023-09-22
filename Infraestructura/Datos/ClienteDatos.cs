using System.Data;
using Infraestructura.Conexiones;
namespace Infraestructura.Datos;
using Infraestructura.Modelos;

public class ClienteDatos 
{
    
    private ConexionDB conexion;
    
    public ClienteDatos(string cadenaConexion)
    {
        conexion = new ConexionDB(cadenaConexion);
    }
    
    public void insertCliente(ClienteModel cliente) 
    {
        var conn = conexion.GetConexion();
        var comando = new Npgsql.NpgsqlCommand("insert into cliente( id_persona, fecha_ingreso, calificacion,estado)" +
                                               "values(@id_persona, @fecha_ingreso, @calificacion, @estado)", conn);
        comando.Parameters.AddWithValue("id_persona", cliente.id_persona);
        comando.Parameters.AddWithValue("fecha_ingreso", cliente.fecha_ingreso);
        comando.Parameters.AddWithValue("calificacion", cliente.calificacion);
        comando.Parameters.AddWithValue("estado", cliente.estado);

        comando.ExecuteNonQuery();
    }
    
    public ClienteModel obtenerDatosCliente(int id)
    {
        var conn = conexion.GetConexion();
        var comando = new Npgsql.NpgsqlCommand($"Select * from cliente where id_cliente = {id}", conn);
        using var reader = comando.ExecuteReader();
        if (reader.Read())
        {
            return new ClienteModel() {
                id_cliente = reader.GetInt32("id_cliente"),
                id_persona = reader.GetInt32("id_persona"),
                fecha_ingreso = reader.GetDateTime("fecha_ingreso"),
                calificacion = reader.GetString("calificacion"),
                estado = reader.GetString("estado"),
            };
        }
        return null;
    }
    
    public void editCliente(ClienteModel cliente)
    {
        var conn = conexion.GetConexion();
        var comando = new Npgsql.NpgsqlCommand($"update cliente set id_persona = '{cliente.id_persona}', " +
                                               $"fecha_ingreso = '{cliente.fecha_ingreso}', " +
                                               $"calificacion = '{cliente.calificacion}', " +
                                               $"estado = '{cliente.estado}' " +
                                               $" where id_cliente = {cliente.id_cliente}", conn);
        comando.ExecuteNonQuery();
    }
    
    public ClienteModel ElimCliente(int id) 
    {
        var conn = conexion.GetConexion();
        var comando = new Npgsql.NpgsqlCommand($"delete from cliente where id_cliente = {id}", conn);
        using var reader = comando.ExecuteReader();
        return null;
    }
}