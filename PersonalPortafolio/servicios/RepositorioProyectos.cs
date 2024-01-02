using PersonalPortafolio.Models;

namespace PersonalPortafolio.servicios
{
    public class RepositorioProyectos:IRepositorioProyectos
    {
        public List<ProyectoDTO> GetProyecto()
        {
            return new List<ProyectoDTO>() {
                new ProyectoDTO
                {
                    Titulo = "Amazon",
                    Descripcion = "E-comerce con ASP .NET Core",
                    Link = "https://amazon.com",
                    ImagenURL = "/img/amazon.png"
                },
                new ProyectoDTO
                {
                    Titulo = "New York Times",
                    Descripcion = "Paginas de Noticias en React",
                    Link = "https://nytimes.com",
                    ImagenURL = "/img/nyt.png"
                },

                new ProyectoDTO
                {
                    Titulo = "Reddit",
                    Descripcion = "Red social para copartir en comunidades",
                    Link = "https://reddit.com",
                    ImagenURL = "/img/reddit.png"
                },
                new ProyectoDTO
                {
                    Titulo = "Steam",
                    Descripcion = "Tienda en linea para comprar videosjuegos ",
                    Link = "https://store.steampowerd.com",
                    ImagenURL = "/img/steam.png"
                }



            };
        }
    }
}
