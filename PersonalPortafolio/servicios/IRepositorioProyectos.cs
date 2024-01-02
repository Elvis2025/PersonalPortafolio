using PersonalPortafolio.Models;

namespace PersonalPortafolio.servicios
{
    public interface IRepositorioProyectos
    {
        List<ProyectoDTO> GetProyecto();
    }
}
