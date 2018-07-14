using System;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
  class Program
  {
    static void Main(string[] args)
    {
      var frase = "melancia ou ovo e abacate";
      var sql = GetQuery(frase);
      Console.WriteLine(sql);
      Console.ReadKey();
    }

    public static string GetQuery(string frase)
    {
      var tokens = frase.Split(" ");
      StringBuilder sql = new StringBuilder();
      sql.Append("SELECT * FROM Post Where ");

      foreach (var token in tokens)
      {
        if (token == "e")
          sql.Append(string.Format(" AND "));
        else if (token == "ou")
          sql.Append(string.Format(" OR "));
        else
          sql.Append(string.Format("Descricao LIKE '%{0}%'", token));
      }
      return sql.ToString();
    }
  }
}
