using System.Data;

namespace Main.Cross.Common
{
  public interface IConnectionFactory
  {

    IDbConnection GetConnection { get; }

  }
}
