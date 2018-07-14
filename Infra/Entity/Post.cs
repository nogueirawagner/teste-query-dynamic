using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Entity
{
  public class Post
  {
    public Guid ID { get; set; }
    public String Codigo { get; set; }
    public String Descricao { get; set; }
  }
}
