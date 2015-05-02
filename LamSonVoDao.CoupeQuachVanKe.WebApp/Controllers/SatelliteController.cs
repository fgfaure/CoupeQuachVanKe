namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using CoupeQuachVanKe.WebApp.Helper;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;

    public class SatelliteController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        private Repository<Club> clubs;
        private Repository<Competiteur> competiteurs;
        private Repository<Participation> participations;
        private Repository<Resultat> resultats;
        private Repository<Epreuve> epreuves;
        private Repository<EpreuveTechnique> epreuvesTechniques;
        private Repository<EpreuveCombat> epreuvesCombat;
        private Repository<Aire> aires;
        private Repository<NetClient> clients;
        private Repository<Encadrant> encadrants;
        private Repository<Encadrement> encadrements;
        private Repository<TypeEpreuve> types;

        public SatelliteController()
        {
            this.clubs = this.unitOfWork.Repository<Club>();
            this.competiteurs = this.unitOfWork.Repository<Competiteur>();
            this.participations = this.unitOfWork.Repository<Participation>();
            this.resultats = this.unitOfWork.Repository<Resultat>();
            this.epreuves = this.unitOfWork.Repository<Epreuve>();
            this.epreuvesTechniques = this.unitOfWork.Repository<EpreuveTechnique>();
            this.epreuvesCombat = this.unitOfWork.Repository<EpreuveCombat>();
            this.types = this.unitOfWork.Repository<TypeEpreuve>();
            this.aires = this.unitOfWork.Repository<Aire>();
            this.clients = this.unitOfWork.Repository<NetClient>();
            this.encadrants = this.unitOfWork.Repository<Encadrant>();
            this.encadrements = this.unitOfWork.Repository<Encadrement>();
        }

        // GET: Satellite
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetEpreuve()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            var log = this.Request.GetOwinContext().Authentication.User.Claims.First().Value;
            var epreuves = this.epreuves.Read();
            var types = this.types.Read();

            var client = this.clients.Read(c => string.Compare(c.ClientLogInName, log, false) == 0).FirstOrDefault();
            if (client != null)
            {
                var aire = this.aires.Read().FirstOrDefault(a => a.Id == client.AireId);
                if (aire.Epreuves != null)
                {
                    var epreuve = aire.Epreuves.Where(e => e.Statut == StatutEpreuve.Assignee).FirstOrDefault();
                    if (epreuve != null)
                    {
                        if (epreuve.TypeEpreuve.Technique)
                        {
                            result.Data = new { foundContest = true, epreuveId = epreuve.Id, technique = true };
                        }
                        else
                        {
                            result.Data = new { foundContest = true, epreuveId = epreuve.Id, technique = false };
                        }
                    }
                    else
                    {
                        result.Data = new { foundContest = false, epreuveId = "" };
                    }
                }
                else
                {
                    result.Data = new { foundContest = false, epreuveId = "" };
                }
            }
            else
            {
                throw new ArgumentException("Unknow client");
            }

            return result;
        }

        public ActionResult EpreuveTechnique()
        {
            var log = this.Request.GetOwinContext().Authentication.User.Claims.First().Value;
            var epreuves = this.epreuves.Read();
            var types = this.types.Read();

            var client = this.clients.Read(c => string.Compare(c.ClientLogInName, log, false) == 0).FirstOrDefault();
            if (client != null)
            {
                var epreuve = this.aires.Read(a => a.Id == client.AireId).FirstOrDefault().Epreuves.FirstOrDefault(e => e.Statut == StatutEpreuve.Assignee);
                if (epreuve != null)
                {
                    this.ViewBag.ContestName = epreuve.Nom;
                    epreuve.Statut = StatutEpreuve.Prete;
                    this.epreuves.Update(epreuve);

                }
            }
            return View("EpreuveTechnique");
        }

        public ActionResult EpreuveCombat()
        {
            var log = this.Request.GetOwinContext().Authentication.User.Claims.First().Value;
            var epreuves = this.epreuves.Read();
            var types = this.types.Read();

            var client = this.clients.Read(c => string.Compare(c.ClientLogInName, log, false) == 0).FirstOrDefault();
            if (client != null)
            {
                var epreuve = this.aires.Read(a => a.Id == client.AireId).FirstOrDefault().Epreuves.FirstOrDefault(e => e.Statut == StatutEpreuve.Assignee);
                if (epreuve != null)
                {
                    this.ViewBag.ContestName = epreuve.Nom;
                    epreuve.Statut = StatutEpreuve.Prete;
                    this.epreuves.Update(epreuve);

                }
            }
            return View();
        }

        public JsonResult GetPresentiel()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            this.resultats.Read();
            var log = this.Request.GetOwinContext().Authentication.User.Claims.First().Value;
            var epreuves = this.epreuves.Read();
            var types = this.types.Read();

            var client = this.clients.Read(c => string.Compare(c.ClientLogInName, log, false) == 0).FirstOrDefault();
            if (client != null)
            {
                var epreuve = this.aires.Read(a => a.Id == client.AireId).FirstOrDefault().Epreuves.FirstOrDefault();

                if (epreuve != null && epreuve.Id != 0)
                {
                    var participationsForThisContest = this.participations.Read().Where(p => p.EpreuveId == epreuve.Id);
                    var clubs = this.clubs.Read();
                    var competiteurs = this.competiteurs.Read(c => (from participation in participationsForThisContest
                                                                    select participation.ParticipantId).Contains(c.Id));

                    result.Data = competiteurs.Select(c => c.ToPresentielModel(epreuve.Id, !participationsForThisContest.FirstOrDefault(p => p.ParticipantId == c.Id).Resultat.Absence)).ToList();
                }
            }
            return result;
        }

        [HttpPost]
        public JsonResult TerminerEpreuve(IEnumerable<ParticipationTechniqueModel> resultats)
        {
            var result = new JsonResult();
            var dbResultats = this.resultats.Read();
            try
            {
                foreach (var resultat in resultats)
                {
                    var dbitem = this.participations.Read().FirstOrDefault(p => p.ParticipantId == resultat.ParticipantId);
                    if (dbitem != null)
                    {
                        int score = 0;

                        if (string.IsNullOrEmpty(resultat.Score2))
                        {
                            score = int.Parse(resultat.Score1);
                        }
                        else
                        {
                            score = int.Parse(resultat.Score2);
                        }
                        dbitem.Resultat.Score = score;
                        dbitem.Resultat.Classement = int.Parse(resultat.Classement);

                        this.participations.Update(dbitem);
                    }
                }

                var epreuveId = resultats.First().EpreuveId;
                var epreuve = this.epreuvesTechniques.Read().FirstOrDefault(e => e.Id == epreuveId);

                if (epreuve != null)
                {
                    epreuve.Statut = StatutEpreuve.Terminee;
                    this.epreuvesTechniques.Update(epreuve);
                }

            }
            catch (Exception)
            {

                throw;
            }
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new { Uri = new UrlHelper(Request.RequestContext).Action("Index", "Satellite") };
            return result;
        }

        [HttpPost]
        public JsonResult UpdatePresentielTechnique(IEnumerable<ParticipationModel> participations, IEnumerable<EncadrantModel> encadrants)
        {
            this.resultats.Read();
            bool inError = false;
            try
            {
                var epreuveId = participations.First().EpreuveId;
                foreach (var participation in participations)
                {
                    var participationCompetiteur = this.participations.Read(p => p.EpreuveId == participation.EpreuveId && p.ParticipantId == participation.ParticipantId).FirstOrDefault();

                    if (participationCompetiteur != null)
                    {
                        participationCompetiteur.Resultat.Absence = !participation.Present;
                    }
                    else
                    {
                        inError = true;
                    }

                }
                var encadrements = this.unitOfWork.Repository<Encadrement>();

                foreach (var encadrant in encadrants)
                {
                    var dbItem = this.encadrements.Read(e => e.EncadrantId == encadrant.Id).FirstOrDefault();
                    if (dbItem == null)
                    {
                        encadrements.Create(new Encadrement
                        {
                            EpreuveId = epreuveId,
                            EncadrantId = encadrant.Id,
                            Role = encadrant.Role == "Arbitre" ? Role.Arbitre : Role.Administrateur
                        });
                    }
                    else
                    {
                        dbItem.EncadrantId = encadrant.Id;
                        dbItem.EpreuveId = epreuveId;
                        dbItem.Role = encadrant.Role == "Arbitre" ? Role.Arbitre : Role.Administrateur;
                        encadrements.Update(dbItem);
                    }

                }

                if (!inError)
                {
                    var result = new JsonResult();
                    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    result.Data = participations.Where(p => p.Present).Select(p => p.ConvertToTechnique());
                    var epreuve = this.epreuvesTechniques.Read().FirstOrDefault(e => e.Id == epreuveId);

                    if (epreuve != null)
                    {
                        epreuve.Statut = StatutEpreuve.EnCours;
                        this.epreuvesTechniques.Update(epreuve);
                    }
                    return result;
                }
                else
                {
                    throw new ArgumentException("oups !!");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public JsonResult UpdatePresentielCombat(IEnumerable<ParticipationModel> participations, IEnumerable<EncadrantModel> encadrants)
        {
            this.resultats.Read();
            bool inError = false;
            try
            {
                var epreuveId = participations.First().EpreuveId;
                foreach (var participation in participations)
                {
                    var participationCompetiteur = this.participations.Read(p => p.EpreuveId == participation.EpreuveId && p.ParticipantId == participation.ParticipantId).FirstOrDefault();

                    if (participationCompetiteur != null)
                    {
                        participationCompetiteur.Resultat.Absence = !participation.Present;
                    }
                    else
                    {
                        inError = true;
                    }

                }
                var encadrements = this.unitOfWork.Repository<Encadrement>();

                foreach (var encadrant in encadrants)
                {
                    var dbItem = this.encadrements.Read(e => e.EncadrantId == encadrant.Id).FirstOrDefault();
                    if (dbItem == null)
                    {
                        encadrements.Create(new Encadrement
                        {
                            EpreuveId = epreuveId,
                            EncadrantId = encadrant.Id,
                            Role = encadrant.Role == "Arbitre" ? Role.Arbitre : Role.Administrateur
                        });
                    }
                    else
                    {
                        dbItem.EncadrantId = encadrant.Id;
                        dbItem.EpreuveId = epreuveId;
                        dbItem.Role = encadrant.Role == "Arbitre" ? Role.Arbitre : Role.Administrateur;
                        encadrements.Update(dbItem);
                    }

                }

                if (!inError)
                {
                    var result = new JsonResult();
                    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    var competiteurs = participations.Where(p => p.Present).Select(p => p.ConvertToCombat()).OrderBy(c => Guid.NewGuid());
                    //var connexions = BuildConnections(competiteurs);

                    var tree = TreeHelper.BuildTree(competiteurs);
                    //result.Data = new { competiteurs = shapes, connexions = connexions };
                    result.Data = new { competiteurs = tree, count = competiteurs.Count() };
                    var epreuve = this.epreuvesCombat.Read().FirstOrDefault(e => e.Id == epreuveId);

                    if (epreuve != null)
                    {
                        epreuve.Statut = StatutEpreuve.EnCours;
                        this.epreuvesCombat.Update(epreuve);
                    }
                    return result;
                }
                else
                {
                    throw new ArgumentException("oups !!");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public JsonResult TerminerEpreuveCombat(IEnumerable<ParticipationCombatModel> resultats)
        {
            var result = new JsonResult();
            var flatten = resultats.Flatten(node => node.Children).Where(node => node.Classement != null);
            var dbResultats = this.resultats.Read();
            try
            {
                foreach (var resultat in flatten)
                {
                    var dbitem = this.participations.Read().FirstOrDefault(p => p.ParticipantId == resultat.ParticipantId && p.EpreuveId == resultat.EpreuveId);
                    if (dbitem != null)
                    {
                        int classement = 0;

                        if (!string.IsNullOrEmpty(resultat.Classement))
                        {
                            classement = int.Parse(resultat.Classement);
                        }
                       
                        dbitem.Resultat.Score = BuildScore(classement);
                        dbitem.Resultat.Classement = classement;

                        this.participations.Update(dbitem);
                    }
                }

                var epreuveId = resultats.First().EpreuveId;
                var epreuve = this.epreuvesCombat.Read().FirstOrDefault(e => e.Id == epreuveId);

                if (epreuve != null)
                {
                    epreuve.Statut = StatutEpreuve.Terminee;
                    this.epreuvesCombat.Update(epreuve);
                }

            }
            catch (Exception)
            {

                throw;
            }
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new { Uri = new UrlHelper(Request.RequestContext).Action("Index", "Satellite") };
            return result;
        }

        private int BuildScore(int classement)
        {
            switch (classement)
            {
                case 1:
                    return 3;
                case 2:
                    return 2;
                case 3:
                    return 1;
                default:
                    return 0;
            }
        }        
    }
}