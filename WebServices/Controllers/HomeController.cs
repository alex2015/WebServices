using WebServices.Models;
using System.Web.Mvc;

namespace WebServices.Controllers
{
    public class HomeController : Controller
    {
        ReservationRepository repository = ReservationRepository.Current;
        public ViewResult Index()
        {
            return View(repository.GetAll());
        }

        public ActionResult Add(Reservation item)
        {
            if (ModelState.IsValid)
            {
                repository.Add(item);
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        public ActionResult Update(Reservation item)
        {
            if (ModelState.IsValid && repository.Update(item))
            {
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        public ActionResult Remove(int id)
        {
            if (ModelState.IsValid)
            {
                repository.Remove(id);
                return RedirectToAction("Index");
            }

            return View("Index");
        }
    }
}