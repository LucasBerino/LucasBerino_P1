using Infraestructura.Conexiones;
using System.Data;
namespace Infraestructura.Datos;
using Infraestructura.Modelos;

public class CuentasDatos 
{
    
    private ConexionDB conexion;

    public CuentasDatos(string cadenaConexion) 
    {
        conexion = new ConexionDB(cadenaConexion);
    }
    
    public void insertCuentas(CuentasModel cuentas)
    {
        var conn = conexion.GetConexion();
        var comando = new Npgsql.NpgsqlCommand("insert into cuentas( id_cliente,nro_cuenta, fecha_alta, tipo_cuenta ,estado,saldo,nro_contrato,costo_mantenimiento,promedio_acreditacion,moneda)" +
                                               "values(@id_cliente, @nro_cuenta, @fecha_alta, @tipo_cuenta,@estado, @saldo,@nro_contrato,@costo_mantenimiento,@promedio_acreditacion,@moneda)", conn);
        comando.Parameters.AddWithValue("id_cliente", cuentas.id_cliente);
        comando.Parameters.AddWithValue("nro_cuenta", cuentas.nro_cuenta);
        comando.Parameters.AddWithValue("fecha_alta", cuentas.fecha_alta);
        comando.Parameters.AddWithValue("tipo_cuenta", cuentas.tipo_cuenta);
        comando.Parameters.AddWithValue("estado", cuentas.estado);
        comando.Parameters.AddWithValue("saldo", cuentas.saldo);
        comando.Parameters.AddWithValue("nro_contrato", cuentas.nro_contrato);
        comando.Parameters.AddWithValue("costo_mantenimiento", cuentas.costo_mantenimiento);
        comando.Parameters.AddWithValue("promedio_acreditacion", cuentas.promedio_acreditacion);
        comando.Parameters.AddWithValue("moneda", cuentas.moneda);

        comando.ExecuteNonQuery();
    }
    
    public CuentasModel obtenerDatosCuenta(int id)
    {
        var conn = conexion.GetConexion();
        var comando = new Npgsql.NpgsqlCommand($"Select * from cuentas where id_cuentas = {id}", conn);
        using var reader = comando.ExecuteReader();
        if (reader.Read())
        {
            return new CuentasModel() {
                id_cuentas = reader.GetInt32("id_cuentas"),
                id_cliente = reader.GetInt32("id_cliente"),
                nro_cuenta = reader.GetString("nro_cuenta"),
                fecha_alta = reader.GetDateTime("fecha_alta"),
                tipo_cuenta = reader.GetString("tipo_cuenta"),
                estado = reader.GetString("estado"),
                saldo = reader.GetInt32("saldo"),
                nro_contrato = reader.GetString("nro_contrato"),
                costo_mantenimiento = reader.GetInt32("costo_mantenimiento"),
                promedio_acreditacion = reader.GetString("promedio_acreditacion"),
                moneda = reader.GetString("moneda"),
            };
        }
        return null;
    }
    
    public void EditCuenta(CuentasModel cuentas) 
    {
        var conn = conexion.GetConexion();
        var comando = new Npgsql.NpgsqlCommand($"update cuentas set id_cliente = '{cuentas.id_cliente}', " +
                                               $"nro_cuenta = '{cuentas.nro_cuenta}', " +
                                               $"fecha_alta = '{cuentas.fecha_alta}', " +
                                               $"tipo_cuenta = '{cuentas.tipo_cuenta}', " +
                                               $"estado = '{cuentas.estado}', " +
                                               $"saldo = '{cuentas.saldo}', " +
                                               $"nro_contrato = '{cuentas.nro_contrato}', " +
                                               $"costo_mantenimiento = '{cuentas.costo_mantenimiento}', " +
                                               $"promedio_acreditacion = '{cuentas.promedio_acreditacion}', " +
                                               $"moneda = '{cuentas.moneda}' " +
                                               $" where id_cuentas = {cuentas.id_cuentas}", conn);
        comando.ExecuteNonQuery();
    }
    
    public CuentasModel ElimCliente(int id)
    {
        var conn = conexion.GetConexion();
        var comando = new Npgsql.NpgsqlCommand($"delete from cuentas where id_cuentas = {id}", conn);
        using var reader = comando.ExecuteReader();
        return null;
    }
    
}

