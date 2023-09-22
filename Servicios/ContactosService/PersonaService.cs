using Infraestructura.Datos;
using Infraestructura.Modelos;


namespace Servicios.ContactosService;

public class PersonaService 
{
    
    PersonaDatos personaDatos;
    
    public PersonaService(string cadenaConexion) 
    {
        personaDatos = new PersonaDatos(cadenaConexion);
    }
    
    public void insertPersona(PersonaModel persona)
    {
        personaDatos.insertPersona(persona);
    }
    
    public PersonaModel obtenerDatosPersona(int id)
    {
        return personaDatos.obtenerDatosPersona(id);
    }
    
    public void EditPersona(PersonaModel persona) 
    {
        personaDatos.EditPersona(persona);
    } 
    
    public PersonaModel ElimPersona(int id) 
    {
        return personaDatos.ElimPersona(id);
    }
}