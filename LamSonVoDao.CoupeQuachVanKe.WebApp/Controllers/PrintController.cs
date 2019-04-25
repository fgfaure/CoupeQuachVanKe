using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class PrintController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        private Repository<Participant> participantsRepository;

        private Repository<Participation> participationsRepository;

        private Repository<CategoriePratiquant> categorieRepository;

        private Repository<Club> clubsRepository;

        private Repository<Epreuve> epreuvesRepository;

        private Repository<TypeEpreuve> typesRepository;

        public PrintController()
        {
            this.participantsRepository = this.unitOfWork.Repository<Participant>();
            this.participationsRepository = this.unitOfWork.Repository<Participation>();
            this.clubsRepository = this.unitOfWork.Repository<Club>();
            this.epreuvesRepository = this.unitOfWork.Repository<Epreuve>();
            this.typesRepository = this.unitOfWork.Repository<TypeEpreuve>();
            this.categorieRepository = this.unitOfWork.Repository<CategoriePratiquant>();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCompetiteursForEpreuve(string id)
        {
            int parsed;

            if (int.TryParse(id, out parsed) && parsed > 0)
            {
                var typesEpreuves = this.typesRepository.Read();
                var participations = this.participationsRepository.Read();
                var epreuves = this.epreuvesRepository.Read();
                var clubs = this.clubsRepository.Read();
                var participants = this.participantsRepository.Read();

                var dbItem = epreuves.FirstOrDefault(e => e.Id == parsed);
                if (dbItem != null)
                {
                    var participantsIds = dbItem.Participations.Select(p => p.ParticipantId);

                    var participantsEpreuve = participants.Where(e => participantsIds.Contains(e.Id)).Select(p => new
                    {
                        Nom = string.Format("    {0}    ", p.Nom),
                        Prenom = string.Format("    {0}    ",p.Prenom),
                        Club = string.Format("    {0}    ",p.Club.Nom),
                        Present = string.Format("    ")
                    }).ToList();

                    var result = new JsonResult();
                    result.Data = participantsEpreuve;
                    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    return result;
                }
            }
            throw new ArgumentException("invalid epreuve id");
        }

        public JsonResult GetEpreuves()
        {
            var typesEpreuves = this.typesRepository.Read();
            var participations = this.participationsRepository.Read();
            var categories = this.categorieRepository.Read();
            var epreuves = this.epreuvesRepository.Read();
            var chosenEpreuves = epreuves.Where(e => e.Participations != null && e.Participations.Count() > 0 && e.Statut == StatutEpreuve.Ouverte).Select(e =>
                new
                {
                    EpreuveId = e.Id,
                    NomEpreuve = e.Nom,
                    TypeEpreuve = e.TypeEpreuve.Nom,
                    Categorie = e.CategoriePratiquant.Nom,
                    AgeMin = e.CategoriePratiquant.AgeMin
                }).OrderBy(l => l.AgeMin).ToList();
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = chosenEpreuves;
            return result;
        }

        [HttpPost]
        public ActionResult ExcelSave(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    }
}