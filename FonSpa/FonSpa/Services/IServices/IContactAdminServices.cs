using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonSpa.Services.IServices
{
    public interface IContactAdminServices
    {
        long AddContact(Contact contact);
        bool Delete(int id);
        Contact GetDetail(int id);
        bool Edit(Contact contact);
    }
}