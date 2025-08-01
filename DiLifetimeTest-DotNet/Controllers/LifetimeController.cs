using DiLifetimeTest_DotNet.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiLifetimeTest_DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LifetimeController : ControllerBase
    {

        [HttpGet("transient")]
        public IActionResult GetTransient([FromServices] ITransient transient1, [FromServices] ITransient transient2)
        {
            return Ok(new
            {
                Service1Id = transient1.GetId(),
                Service2Id = transient2.GetId(),
                Type = "Transient"
            });
        }

        [HttpGet("scoped")]
        public IActionResult GetScoped([FromServices] IScoped scoped1, [FromServices] IScoped scoped2)
        {
            return Ok(new
            {
                Service1Id = scoped1.GetId(),
                Service2Id = scoped2.GetId(),
                Type = "Scoped"
            });
        }

        [HttpGet("singleton")]
        public IActionResult GetSingleton([FromServices] ISingleton singleton1, [FromServices] ISingleton singleton2)
        {
            return Ok(new
            {
                Service1Id = singleton1.GetId(),
                Service2Id = singleton2.GetId(),
                Type = "Singleton"
            });
        }

        [HttpGet("compare")]
        public IActionResult Compare(ITransient transient1,
    ITransient transient2,
    IScoped scoped1,
    IScoped scoped2,
    ISingleton singleton1,
    ISingleton singleton2)
        {
            return Ok(new
            {
                    TransientId = $"{transient1.GetId()} - {transient2.GetId()}",
                    ScopedId = $"{scoped1.GetId()} - {scoped2.GetId()}",
                    SingletonId = $"{singleton1.GetId()} - {singleton2.GetId()}"
            });
        }
    }
}