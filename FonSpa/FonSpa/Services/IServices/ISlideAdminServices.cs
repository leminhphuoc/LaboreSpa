using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonSpa.Services.IServices
{
    public interface ISlideAdminServices
    {
        long AddSlide(Slide slide);
        bool Delete(int id);
        Slide GetDetail(int id);
        bool Edit(Slide slide);
        bool? ChangeStatus(int id);
    }
}