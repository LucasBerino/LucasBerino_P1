using Infraestructura.Datos;
using Infraestructura.Modelos;

namespace Servicios.ContactosService;

public class ClienteService 
{
    
    ClienteDatos clienteDatos;

    public ClienteService(string cadenaConexion)
    {
        clienteDatos = new ClienteDatos(cadenaConexion);
    }
    
    public void insertCliente(ClienteModel cliente)
    {
        clienteDatos.insertCliente(cliente);
    }
    
    public ClienteModel obtenerDatosCliente(int id) 
    {
        return clienteDatos.obtenerDatosCliente(id);
    }

    public void editCliente(ClienteModel cliente) 
    {
        clienteDatos.editCliente(cliente);
    } 
    
    public ClienteModel ElimCliente(int id) 
    {
        return clienteDatos.ElimCliente(id);
    }
}