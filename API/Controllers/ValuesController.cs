using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infra.Repository;
using Infra.Entity;

namespace API.Controllers
{
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    // GET api/values
    [HttpPost]
    public IEnumerable<Post> Get([FromBody] string value)
    {
      return PostRepository.GetResults(value);
    }
  }
}
