using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PARCIAL1A.models;

namespace PARCIAL1A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedaPersonalizadaController : ControllerBase
    {
        private readonly Parcial1ADBContext _parcial1ADBContext;

        public BusquedaPersonalizadaController (Parcial1ADBContext Parcial1ADBContexto)
        {
            _parcial1ADBContext = Parcial1ADBContexto;

        }


        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get(string nombre)
        {
            List<Libros> listadoLibros = (from e in _parcial1ADBContext.Libros 
                                          join au in _parcial1ADBContext.AutorLibro
                                          on e.Id equals au.LibroId
                                          join auto in _parcial1ADBContext.Autores
                                          on au.AutorId equals auto.Id
                                          where auto.Nombre == nombre
                                          select e).ToList();



            if (listadoLibros.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listadoLibros);
        }
    }

}
