using Infra.Data;
using Infra.Entity;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Infra.Repository
{
  public static class PostRepository
  {
    private static ContextDB Db;
    private static DbConnection Connection;

    public static IEnumerable<Post> GetResults(string frase)
    {
      var sql = GetQuery(frase);
      var posts = new List<Post>();

      using (var db = new SqlConnection(Connection.ConnectionString))
      {
        db.Open();
        var cmd = db.CreateCommand();
        cmd.CommandText = sql;
        cmd.CommandType = System.Data.CommandType.Text;
        var reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

        while (reader.Read())
        {
          posts.Add(new Post
          {
            Descricao = reader.GetString(0)
          });
        }
        return posts;
      }
    }

    private static string GetQuery(string frase)
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
