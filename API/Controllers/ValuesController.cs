using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infra.Repository;
using Infra.Entity;
using System.Net.Http;

namespace API.Controllers
{
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    // GET api/values
    [HttpPost]
    public IEnumerable<Post> Get([FromBody] string valor)
    {
      return PostRepository.GetResults(valor);
    }
  }
}
