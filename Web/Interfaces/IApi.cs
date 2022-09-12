using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.list;

namespace Web.Interfaces
{
    public interface IApi
    {
        List<Contacts> GetContacts();
        Contacts EvolveContact(string value, string action);
    }

}
