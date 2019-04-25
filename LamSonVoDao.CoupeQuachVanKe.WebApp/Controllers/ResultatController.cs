using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class ResultatController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        private Repository<Club> clubsRepository;

        private Repository<Participant> participantsRepository;

        private Repository<Participation> participationsRepository;

        private Repository<Resultat> resultatsRepository;

        private Repository<Epreuve> epreuvesRepository;

        public ResultatController()
        {
            this.clubsRepository = this.unitOfWork.Repository<Club>();
            this.participantsRepository = this.unitOfWork.Repository<Participant>();
            this.participationsRepository = this.unitOfWork.Repository<Participation>();
            this.resultatsRepository = this.unitOfWork.Repository<Resultat>();
            this.epreuvesRepository = this.unitOfWork.Repository<Epreuve>();
        }

        // GET: Resultat
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEpreuves()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.epreuvesRepository.Read().Where(e => e.Statut == DataTransferOjbect.Enumerations.StatutEpreuve.Terminee).Select(c => c.ToModel());
            return result;
        }

        public JsonResult GetClubs()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.clubsRepository.Read().Select(c => c.ToModel());
            return result;
        }

        public JsonResult GetResultatsFromEpreuve(string id)
        {
            int parsed = 0;

            if (int.TryParse(id, out parsed))
            {
                if (parsed == 0)
                {
                    throw new ArgumentException("id can't be 0.");
                }

                var result = new JsonResult();
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                var epreuve = this.epreuvesRepository.Read().FirstOrDefault(c => c.Id == parsed);
                var competiteurs = this.participantsRepository.Read();
                var resultats = this.resultatsRepository.Read();
                var participations = this.participationsRepository.Read().Where(p => p.EpreuveId == epreuve.Id).Select(p => new ResultatModel {
                    EpreuveId = p.EpreuveId,
                    Epreuve = p.Epreuve.Nom,
                    ResultatId = p.Id,
                    ParticipationId = p.Id,
                    ParticipantId = p.ParticipantId,
                    Nom = p.Participant.Nom,
                    Prenom = p.Participant.Prenom,
                    Score = p.Resultat.Score,
                    Classement = p.Resultat.Classement,
                    Abandon = p.Resultat.Abandon,
                    Absence = p.Resultat.Absence,
                });

                result.Data = participations;
                return result;
            }
            else
            {
                throw new ArgumentException("id is not valid.");
            }
        }

        public JsonResult GetCompetiteursFromClub(string id)
        {
            int parsed = 0;

            if (int.TryParse(id, out parsed))
            {
                if (parsed == 0)
                {
                    throw new ArgumentException("id can't be 0.");
                }

                var result = new JsonResult();
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                var club = this.clubsRepository.Read().FirstOrDefault(c => c.Id == parsed);
                var competiteurs = this.participantsRepository.Read().Where(p => p.ClubId == club.Id);

                result.Data = competiteurs.Select(c => c.ToModel());
                return result;
            }
            else
            {
                throw new ArgumentException("id is not valid.");
            }
        }

        public JsonResult GetResultatsFromCompetiteur(string id)
        {
            int parsed = 0;

            if (int.TryParse(id, out parsed))
            {
                if (parsed == 0)
                {
                    throw new ArgumentException("id can't be 0.");
                }

                var result = new JsonResult();
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

                var resultats = this.resultatsRepository.Read();
                var epreuves = this.epreuvesRepository.Read();
                var competiteur = this.participantsRepository.Read().FirstOrDefault(p => p.Id == parsed);
                var participations = this.participationsRepository.Read().Where(p => p.ParticipantId == competiteur.Id);
                var data = new List<ResultatModel>();

                foreach (var participation in participations)
                {
                    data.Add(new ResultatModel
                    {
                        EpreuveId = participation.EpreuveId,
                        Epreuve = participation.Epreuve.Nom,
                        ResultatId = participation.Id,
                        ParticipationId = participation.Id,
                        ParticipantId = participation.ParticipantId,
                        Nom = competiteur.Nom,
                        Prenom = competiteur.Prenom,
                        Score = participation.Resultat.Score,
                        Classement = participation.Resultat.Classement,
                        Abandon = participation.Resultat.Abandon,
                        Absence = participation.Resultat.Absence,
                    });
                }

                result.Data = data;
                return result;
            }
            else
            {
                throw new ArgumentException("id is not valid.");
            }
        }

        [HttpPost]
        public JsonResult UpdateCompetiteurResultat(ResultatModel model)
        {            
            var resultats = this.resultatsRepository.Read();
            var epreuves = this.epreuvesRepository.Read();
            var participations = this.participationsRepository.Read();
            try
            {
                var dbmodel = resultats.FirstOrDefault(m => m.Id == model.ResultatId);
                if (dbmodel != null)
                {
                    dbmodel.Score = model.Score;
                    dbmodel.Classement = model.Classement;
                    this.resultatsRepository.Update(dbmodel);                                        
                    return Json(string.Empty);
                }
                throw new ArgumentException("Unknow Model");
            }
            catch
            {
                throw;
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