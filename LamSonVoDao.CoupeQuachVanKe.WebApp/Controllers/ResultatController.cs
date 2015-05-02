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

        public JsonResult GetClubs()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.clubsRepository.Read().Select(c => c.ToModel());
            return result;
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
                        ResultatId = participation.ResultatId,
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
    }
}