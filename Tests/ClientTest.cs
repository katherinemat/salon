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
      Client client1 = new Client("Britney", 1);
      Client client2 = new Client("Britney", 1);

      Assert.Equal(client1, client2);
    }

    [Fact]
    public void GetAll_DatabaseEmptyAtFirst_NoClients()
    {
      int output = Client.GetAll().Count;

      Assert.Equal(0, output);
    }

    [Fact]
    public void Save_OneClient_SavesToDatabase()
    {
      Client newClient = new Client("Britney", 1);
      newClient.Save();

      List<Client> result = Client.GetAll();
      List<Client> expected = new List<Client>{newClient};

      Assert.Equal(expected, result);
    }

    [Fact]
    public void SaveGetAll_OneClient_AssignIdToClient()
    {
      Client newClient = new Client("Britney", 1);
      newClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int expected = newClient.GetId();

      Assert.Equal(expected, result);
    }

    [Fact]
    public void Delete_OneClient_ClientDeleted()
    {
      Client firstClient = new Client("Mariah", 1);
      firstClient.Save();
      Client secondClient = new Client("Britney", 1);
      secondClient.Save();

      secondClient.Delete();
      List<Client> output = Client.GetAll();
      List<Client> expected = new List<Client>{firstClient};

      Assert.Equal(expected, output);
    }

    [Fact]
    public void UpdateName_OneClient_NewInfo()
    {
      Client newClient = new Client("Brit", 1);
      newClient.Save();
      string newName = "Britney";
      newClient.UpdateName(newName);

      string output = newClient.GetName();

      Assert.Equal(newName, output);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
