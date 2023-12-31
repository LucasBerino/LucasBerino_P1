using System.Data;
using Infraestructura.Conexiones;
namespace Infraestructura.Datos;
using Infraestructura.Modelos;

public class PersonaDatos 
{
    private ConexionDB conexion;
    public PersonaDatos(string cadenaConexion) 
    {
        conexion = new ConexionDB(cadenaConexion);
    }
    
    public void insertPersona(PersonaModel persona)
    {
        var conn = conexion.GetConexion();
        var comando = new Npgsql.NpgsqlCommand("insert into persona( id_ciudad,nombre, apellido, nro_documento,direccion,celular,email,estado)" +
                                               "values(@id_ciudad, @nombre, @apellido, @nro_documento, @direccion,@celular,@email,@estado)", conn);
        comando.Parameters.AddWithValue("id_ciudad", persona.id_ciudad);
        comando.Parameters.AddWithValue("nombre", persona.nombre);
        comando.Parameters.AddWithValue("apellido", persona.apellido);
        comando.Parameters.AddWithValue("nro_documento", persona.nro_documento);
        comando.Parameters.AddWithValue("direccion", persona.direccion);
        comando.Parameters.AddWithValue("celular", persona.celular);
        comando.Parameters.AddWithValue("email", persona.email);
        comando.Parameters.AddWithValue("estado", persona.estado);

        comando.ExecuteNonQuery();
    }
    
    public PersonaModel obtenerDatosPersona(int id) 
    {
        var conn = conexion.GetConexion();
        var comando = new Npgsql.NpgsqlCommand($"Select * from persona where id_persona = {id}", conn);
        using var reader = comando.ExecuteReader();
        if (reader.Read())
        {
            return new PersonaModel() 
            {
                id_persona = reader.GetInt32("id_persona"),
                id_ciudad = reader.GetInt32("id_ciudad"),
                nombre = reader.GetString("nombre"),
                apellido = reader.GetString("apellido"),
                nro_documento = reader.GetString("nro_documento"),
                direccion = reader.GetString("direccion"),
                celular = reader.GetString("celular"),
                email = reader.GetString("email"),
                estado = reader.GetString("estado"),
            };
        }
        return null;
    }
    
    public void EditPersona(PersonaModel persona)
    {
        var conn = conexion.GetConexion();
        var comando = new Npgsql.NpgsqlCommand($"update persona set id_ciudad = '{persona.id_ciudad}', " +
                                               $"nombre = '{persona.nombre}', " +
                                               $"apellido = '{persona.apellido}', " +
                                               $"nro_documento = '{persona.nro_documento}', " +
                                               $"direccion = '{persona.direccion}', " +
                                               $"celular = '{persona.celular}', " +
                                               $"email = '{persona.email}', " +
                                               $"estado = '{persona.estado}' " +
                                               $" where id_persona = {persona.id_persona}", conn);
        comando.ExecuteNonQuery();
    }
    
    public PersonaModel ElimPersona(int id) 
    {
        var conn = conexion.GetConexion();
        var comando = new Npgsql.NpgsqlCommand($"delete from persona where id_persona = {id}", conn);
        using var reader = comando.ExecuteReader();
        return null;
    }
}