using PersonalPortafolio.Models;

namespace PersonalPortafolio.servicios
{
    public interface ISevicioEmail
    {
        void Enviar(ContactoDTO contactoDto);
    }
}
