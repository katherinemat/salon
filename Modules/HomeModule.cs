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
    }
  }
}
