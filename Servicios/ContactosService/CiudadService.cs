using Infraestructura.Datos;
using Infraestructura.Modelos;

namespace Servicios.ContactosService;

public class CiudadService 
{
    
    CiudadDatos ciudadDatos;

    public CiudadService(string cadenaConexion) 
    {
        ciudadDatos = new CiudadDatos(cadenaConexion);
    }
    
    public void insertCiudad(CiudadModel ciudad) {
        ciudadDatos.insertCiudad(ciudad);
    }
    
    public CiudadModel obtenerDatosCiudad(int id) 
    {
        return ciudadDatos.obtenerDatosCiudad(id);
    }
    
    public void EditCiudad(CiudadModel ciudad) 
    {
        ciudadDatos.EditCiudad(ciudad);
    }  
    
    public CiudadModel ElimCiudad(int id) 
    {
        return ciudadDatos.ElimCiudad(id);
    }
    
}