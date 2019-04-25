namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{

    using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class EncadrantController : BaseController<Encadrant>, ICrudController<Encadrant, EncadrantModel>
    {
        private Repository<Disponibilite> disponibilitesRepository;

        public JsonResult GetDates()
        {
            var result = new JsonResult();            
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new List<DisponibiliteModel>(){
                new DisponibiliteModel
                {
                    Date = new DateTime(2019,04,27),
                    Matin = false
                },
                new DisponibiliteModel
                {
                    Date = new DateTime(2019,04,28),
                    Matin = true
                },
                new DisponibiliteModel
                {
                    Date = new DateTime(2019,04,28),
                    Matin = false
                }
            };
            return result;
        }

        public JsonResult Get()
        {
            if (this.disponibilitesRepository == null)
            {
                this.disponibilitesRepository = this.unitOfWork.Repository<Disponibilite>();
            }
            var result = new JsonResult();
            var dispo = this.disponibilitesRepository.Read();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.Read().Select(enc => enc.ToModel());
            return result;
        }

        public JsonResult Create(EncadrantModel model)
        {
            try
            {
                var dbitem = model.ToDTO();
                this.repository.Create(dbitem);
                return Json(dbitem.ToModel());
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Delete(EncadrantModel model)
        {
            try
            {
                var dbmodel = this.repository.Read(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    this.repository.Delete(dbmodel);
                    return Json(model);
                }
                else
                {
                    throw new ArgumentException("L'encadrant est absent de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Update(EncadrantModel model)
        {

            if (this.disponibilitesRepository == null)
            {
                this.disponibilitesRepository = this.unitOfWork.Repository<Disponibilite>();
            }
            var dispo = this.disponibilitesRepository.Read();

            var dbmodel = this.repository.Read(m => m.Id == model.Id).First();
            if (dbmodel != null)
            {
                dbmodel.ClubId = model.ClubId;
                dbmodel.Nom = model.Nom;
                dbmodel.EstCompetiteur = model.EstCompetiteur;
                dbmodel.MailContact = model.MailContact;
                dbmodel.Prenom = model.Prenom;
                dbmodel.TailleTenue = (TailleTenue)model.TailleTenueId;
                dbmodel.Sexe = (Genre)model.GenreId;
                if (dbmodel.Disponibilites != null && dbmodel.Disponibilites.Count > 0)
                {
                    for (int i = dbmodel.Disponibilites.Count - 1; i >= 0; i--)
                    {
                        disponibilitesRepository.Delete(dbmodel.Disponibilites.ElementAt(i));
                    }
                }
                dbmodel.Disponibilites = new List<Disponibilite>();
                if (model.DispoAdministrateur != null)
                {
                    foreach (var disponibilite in model.DispoAdministrateur)
                    {
                        dbmodel.Disponibilites.Add(disponibilite.ToDTO(Role.Administrateur));
                    }
                }
                if (model.DispoArbitre != null)
                {
                    foreach (var disponibilite in model.DispoArbitre)
                    {
                        dbmodel.Disponibilites.Add(disponibilite.ToDTO(Role.Arbitre));
                    }
                }
                this.repository.Update(dbmodel);
                return Json(dbmodel.ToModel());
            }
            else
            {
                throw new ArgumentException("L'encadrant est absent de la base de données", "model");
            }
        }

        [HttpPost]
        public ActionResult ExcelSave(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    }
}