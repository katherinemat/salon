using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace Salon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void OverrideEquals_TwoSameStylists_Same()
    {
      Stylist stylist1 = new Stylist("Kerry");
      Stylist stylist2 = new Stylist("Kerry");

      Assert.Equal(stylist1, stylist2);
    }

    [Fact]
    public void GetAll_DatabaseEmptyAtFirst_NoStylists()
    {
      int output = Stylist.GetAll().Count;

      Assert.Equal(0, output);
    }

    [Fact]
    public void Save_OneStylist_SavesToDatabase()
    {
      Stylist newStylist = new Stylist("Kerry");
      newStylist.Save();

      List<Stylist> result = Stylist.GetAll();
      List<Stylist> expected = new List<Stylist>{newStylist};

      Assert.Equal(expected, result);
    }

    [Fact]
    public void SaveGetAll_OneStylist_AssignIdToStylist()
    {
      Stylist newStylist = new Stylist("Kerry");
      newStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int expected = newStylist.GetId();

      Assert.Equal(expected, result);
    }

    [Fact]
    public void Delete_OneStylist_StylistDeleted()
    {
      Stylist firstStylist = new Stylist("Demi");
      firstStylist.Save();
      Stylist secondStylist = new Stylist("Kerry");
      secondStylist.Save();

      secondStylist.Delete();
      List<Stylist> output = Stylist.GetAll();
      List<Stylist> expected = new List<Stylist>{firstStylist};

      Assert.Equal(expected, output);
    }

    [Fact]
    public void UpdateName_OneStylist_NewInfo()
    {
      Stylist newStylist = new Stylist("Demi");
      newStylist.Save();
      string newName = "De'mi";
      newStylist.UpdateName(newName);

      string output = newStylist.GetName();

      Assert.Equal(newName, output);
    }

    [Fact]
    public void GetClients_OneStylist_TheirClients()
    {
      Stylist newStylist = new Stylist("Nicole");
      newStylist.Save();
      int newStylistId = newStylist.GetId();
      Client client1 = new Client("Britney", newStylistId);
      client1.Save();
      Client client2 = new Client("Christina", newStylistId);
      client2.Save();

      List<Client> expected = new List<Client>{client1, client2};
      List<Client> output = newStylist.GetClients();

      Assert.Equal(expected, output);
    }

    [Fact]
    public void Find_AllStylists_FoundStylist()
    {
      Stylist stylist1 = new Stylist("Nicole");
      stylist1.Save();
      Stylist stylist2 = new Stylist("Kerry");
      stylist2.Save();

      Stylist foundStylist = Stylist.Find(stylist2.GetId());
      Stylist expectedStylist = stylist2;

      Assert.Equal(expectedStylist, foundStylist);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
