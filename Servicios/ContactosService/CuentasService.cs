using Infraestructura.Datos;
using Infraestructura.Modelos;

namespace Servicios.ContactosService;

public class CuentasService 
{
    
    CuentasDatos cuentasDatos;
    
    public CuentasService(string cadenaConexion) 
    {
        cuentasDatos = new CuentasDatos(cadenaConexion);
    }
    
    public void insertCuentas(CuentasModel cuentas)
    {
        cuentasDatos.insertCuentas(cuentas);
    }
    
    public CuentasModel obtenerDatosCuenta(int id) 
    {
        return cuentasDatos.obtenerDatosCuenta(id);
    }
    
    public void EditCuenta(CuentasModel cuentas) 
    {
        cuentasDatos.EditCuenta(cuentas);
    } 
    
    public CuentasModel ElimCliente(int id) 
    {
        return cuentasDatos.ElimCliente(id);
    }
    
}