using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using AppVenta.Dominio;
using AppVenta.Aplicaciones.Servicios;
using AppVenta.Infraestructura.Datos.Contextos;
using AppVenta.Infraestructura.Datos.Repositorios;

namespace AppVenta.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        ProductoServicio CrearServicio()
        {
            VentaContexto db = new VentaContexto();
            ProductoRepositorio repo = new ProductoRepositorio(db);
            ProductoServicio servicio = new ProductoServicio(repo);

            return servicio;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorId);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            servicio.Agregar(producto);
            return Ok("Producto agregado.");
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            producto.productoId = id;
            servicio.Editar(producto);
            return Ok("Producto modificado.");
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Producto eliminado.");
        }
    }
}
