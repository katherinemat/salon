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
      Client client1 = new Client("Britney", "be careful about using too much bleach", 1);
      Client client2 = new Client("Britney", "be careful about using too much bleach", 1);

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
      Client newClient = new Client("Britney", "be careful about using too much bleach", 1);
      newClient.Save();

      List<Client> result = Client.GetAll();
      List<Client> expected = new List<Client>{newClient};

      Assert.Equal(expected, result);
    }

    [Fact]
    public void SaveGetAll_OneClient_AssignIdToClient()
    {
      Client newClient = new Client("Britney", "be careful about using too much bleach", 1);
      newClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int expected = newClient.GetId();

      Assert.Equal(expected, result);
    }

    [Fact]
    public void Delete_OneClient_ClientDeleted()
    {
      Client firstClient = new Client("Mariah", "be careful about using too much bleach", 1);
      firstClient.Save();
      Client secondClient = new Client("Britney", "be careful about using too much bleach", 1);
      secondClient.Save();

      secondClient.Delete();
      List<Client> output = Client.GetAll();
      List<Client> expected = new List<Client>{firstClient};

      Assert.Equal(expected, output);
    }

    [Fact]
    public void UpdateName_OneClient_NewInfo()
    {
      Client newClient = new Client("Brit", "be careful about using too much bleach", 1);
      newClient.Save();
      string newName = "Britney";
      newClient.UpdateName(newName);

      string output = newClient.GetName();

      Assert.Equal(newName, output);
    }

    [Fact]
    public void UpdateNotes_OneClient_NewInfo()
    {
      Client newClient = new Client("Brit", "be careful about using too much bleach", 1);
      newClient.Save();
      string newNotes = "does not like choppy layers";
      newClient.UpdateNotes(newNotes);

      string output = newClient.GetNotes();

      Assert.Equal(newNotes, output);
    }

    [Fact]
    public void Find_AllClients_FoundClient()
    {
      Client client1 = new Client("Britney", "be careful about using too much bleach", 1);
      client1.Save();
      Client client2 = new Client("Christina", "be careful about using too much bleach", 1);
      client2.Save();

      Client foundClient = Client.Find(client2.GetId());
      Client expectedClient = client2;

      Assert.Equal(expectedClient, foundClient);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
