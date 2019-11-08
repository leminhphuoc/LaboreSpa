using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class SlideAdminRepository : ISlideAdminRepository
    {
        private FonSpaDbContext _db = null;

        public FonSpaDbContext Db { get => _db; set => _db = value; }

        public SlideAdminRepository()
        {
            _db = new FonSpaDbContext();
        }

        public Slide GetDetail(long id)
        {
            var slide = _db.Slides.Find(id);
            return slide;
        }

        public List<Slide> GetListSlide()
        {
            return _db.Slides.ToList();
        }

        public long AddSlide(Slide slide)
        {
            slide.status = false;
            slide.createdDate = DateTime.Now;
            var addSlide = _db.Slides.Add(slide);
            _db.SaveChanges();
            return addSlide.id;
        }

        public bool EditSlide(Slide slide)
        {
            var SlideEdit = _db.Slides.Where(x => x.id == slide.id).SingleOrDefault();
            SlideEdit.image = slide.image;
            SlideEdit.displayOrder = slide.displayOrder;
            SlideEdit.link = slide.link;
            SlideEdit.description = slide.description;
            SlideEdit.modifiedDate = DateTime.Now;
            SlideEdit.status = slide.status;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var slide = _db.Slides.Find(id);
            if (slide != null)
            {
                _db.Slides.Remove(slide);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.Slides.Find(id);
            accountNeedChange.status = !accountNeedChange.status;
            _db.SaveChanges();
            return accountNeedChange.status;
        }
    }
}
