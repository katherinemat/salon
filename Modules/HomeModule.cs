using Nancy;
using System;
using System.Collections.Generic;

namespace Salon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/clients"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        var allClients = Client.GetAll();
        model.Add("clients", allClients);
        var allStylists = Stylist.GetAll();
        model.Add("stylists", allStylists);
        return View["clients.cshtml", model];
      };
      Post["/clients/new"] = _ => {
        string newName = Request.Form["name"];
        string newNotes = Request.Form["notes"];
        int newStylistId = Request.Form["stylist-id"];
        Client newClient = new Client(newName, newNotes, newStylistId);
        newClient.Save();

        Dictionary<string, object> model = new Dictionary<string, object>{};
        var allClients = Client.GetAll();
        model.Add("clients", allClients);
        var allStylists = Stylist.GetAll();
        model.Add("stylists", allStylists);
        return View["clients.cshtml", model];
      };
      Get["/stylists"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };
      Post["/stylists/new"] = _ => {
        string newName = Request.Form["name"];
        Stylist newStylist = new Stylist(newName);
        newStylist.Save();

        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };
      Get["/stylist/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        var foundStylist = Stylist.Find(parameters.id);
        model.Add("stylist", foundStylist);
        var foundStylistClients = foundStylist.GetClients();
        model.Add("clients", foundStylistClients);
        return View["stylist.cshtml", model];
      };
      Get["/client/edit/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        var foundClient = Client.Find(parameters.id);
        model.Add("client", foundClient);
        var foundClientStylist = Stylist.Find(foundClient.GetStylistId());
        model.Add("stylist", foundClientStylist);
        var allStylists = Stylist.GetAll();
        model.Add("stylists", allStylists);
        return View["client_edit.cshtml", model];
      };
      Patch["client/edit/{id}"] = parameters => {
        Client foundClient = Client.Find(parameters.id);
        string newName = Request.Form["client-name"];
        string newNotes = Request.Form["client-notes"];
        int newStylistId = Request.Form["client-stylist"];
        if (newName != "")
        {
          foundClient.UpdateName(newName);
        }
        if (newNotes != "")
        {
          foundClient.UpdateNotes(newNotes);
        }
        if (newStylistId != null)
        {
          foundClient.UpdateStylistId(newStylistId);
        }
        Dictionary<string, object> model = new Dictionary<string, object>{};
        var updatedClient = Client.Find(parameters.id);
        model.Add("client", updatedClient);
        var foundStylist = Stylist.Find(updatedClient.GetStylistId());
        model.Add("stylist", foundStylist);
        var allStylists = Stylist.GetAll();
        model.Add("stylists", allStylists);
        return View["client_edit.cshtml", model];
      };
      Delete["client/{id}/deleted"] = parameters => {
        Client deletedClient = Client.Find(parameters.id);
        deletedClient.Delete();

        Dictionary<string, object> model = new Dictionary<string, object>{};
        var allClients = Client.GetAll();
        model.Add("clients", allClients);
        var allStylists = Stylist.GetAll();
        model.Add("stylists", allStylists);
        return View["clients.cshtml", model];
      };
    }
  }
}
