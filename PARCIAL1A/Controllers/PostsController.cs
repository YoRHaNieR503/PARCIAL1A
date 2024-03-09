using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PARCIAL1A.models;

namespace PARCIAL1A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {


        private readonly Parcial1ADBContext _Parcial1ADBContext;

        public PostsController(Parcial1ADBContext parcialDBContexto)
        {
            _Parcial1ADBContext = parcialDBContexto;


        }


        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<Posts> listadoPosts = (from e in _Parcial1ADBContext.Posts select e).ToList();

            if (listadoPosts.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listadoPosts);
        }

        [HttpGet]
        [Route("GetById/{id}")]

        public IActionResult Get(int id)
        {
            Posts? post = (from e in _Parcial1ADBContext.Posts where e.Id == id select e).FirstOrDefault();

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }
        /*
        [HttpGet]
        [Route("GetById/{rol}")]

        public IActionResult Get(int rol)
        {
            usuarios? usuario = (from e in _blogDBContext.usuarios where e.rolId == rol select e).FirstOrDefault();

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarUsuario([FromBody] usuarios usuario)
        {
            try
            {

                _blogDBContext.usuarios.Add(usuario);
                _blogDBContext.SaveChanges();
                return Ok(usuario);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("actualizar/{id}")]

        public IActionResult ActualizarUsuarios(int id, [FromBody] usuarios usuariosModificar)
        {
            usuarios? usuarioActual = (from e in _blogDBContext.usuarios where e.usuarioId == id select e).FirstOrDefault();

            if (usuarioActual == null)
            {
                return NotFound();
            }

            usuarioActual.rolId = usuariosModificar.rolId;
            usuarioActual.nombreUsuario = usuariosModificar.nombreUsuario;
            usuarioActual.clave = usuariosModificar.clave;
            usuarioActual.nombre = usuariosModificar.nombre;
            usuarioActual.apellido = usuariosModificar.apellido;

            return Ok(usuariosModificar);
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]

        public IActionResult EliminarUsuarios(int id)
        {
            usuarios? usuario = (from e in _blogDBContext.usuarios where e.usuarioId == id select e).FirstOrDefault();

            if (usuario == null)
            {
                return NotFound();
            }

            _blogDBContext.usuarios.Attach(usuario);
            _blogDBContext.usuarios.Remove(usuario);
            _blogDBContext.SaveChanges();

            return Ok(usuario);
        }




    }
*/

}
