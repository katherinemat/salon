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
        List<Client> allClients = Client.GetAll();
        return View["clients.cshtml", allClients];
      };
      Get["/stylists"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };
      Get["/clients/form"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["clients_form.cshtml", allStylists];
      };
      Get["/stylists/form"] = _ => {
        return View["stylists_form.cshtml"];
      };
    }
  }
}
