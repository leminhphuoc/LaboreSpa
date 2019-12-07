using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonSpa.Services.IClientServices
{
    public interface IAboutServices
    {
        About GetAbout(int id);
        List<About> GetAbouts();
    }
}
