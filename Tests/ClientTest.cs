using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace Salon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void OverrideEquals_TwoSameClients_Same()
    {
      Client client1 = new Client("Britney");
      Client client2 = new Client("Britney");

      Assert.Equal(client1, client2);
    }
    [Fact]
    public void GetAll_DatabaseEmptyAtFirst_NoClients()
    {
      int output = Client.GetAll().Count;

      Assert.Equal(0, output);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
