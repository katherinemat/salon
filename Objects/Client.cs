using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Salon
{
  public class Client
  {
    private int _id;
    private string _name;

    public Client(string Name)
    {
      _name = Name;
    }
  }
}
