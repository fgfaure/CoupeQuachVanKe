namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
    using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Mvc;

    /// <summary>
    /// 
    /// </summary>
    public class QVKApiController : Controller
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private UnitOfWork unitOfWork = new UnitOfWork();

        /// <summary>
        /// The competiteurs
        /// </summary>
        private Repository<Competiteur> competiteurs;

        /// <summary>
        /// The coupes
        /// </summary>
        private Repository<Coupe> coupes;

        /// <summary>
        /// The clubs
        /// </summary>
        private Repository<Club> clubs;

        /// <summary>
        /// The encadrants
        /// </summary>
        private Repository<Encadrant> encadrants;

        /// <summary>
        /// The responsables
        /// </summary>
        private Repository<ResponsableClub> responsables;

        /// <summary>
        /// The responsable coupe
        /// </summary>
        private Repository<ResponsableCoupe> responsableCoupe;

        /// <summary>
        /// The aires
        /// </summary>
        private Repository<Aire> aires;

        /// <summary>
        /// The medecins
        /// </summary>
        private Repository<Medecin> medecins;
        /// <summary>
        /// The epreuves
        /// </summary>
        private Repository<Epreuve> epreuves;
        /// <summary>
        /// The epreuves combat
        /// </summary>
        private Repository<EpreuveCombat> epreuvesCombat;

        /// <summary>
        /// The epreuves techniques
        /// </summary>
        private Repository<EpreuveTechnique> epreuvesTechniques;
       
        /// <summary>
        /// The type epreuves
        /// </summary>
        private Repository<TypeEpreuve> typeEpreuves;

        /// <summary>
        /// The categories
        /// </summary>
        private Repository<CategoriePratiquant> categories;

        /// <summary>
        /// The clients
        /// </summary>
        private Repository<NetClient> clients;

        /// <summary>
        /// The resultats
        /// </summary>
        private Repository<Resultat> resultats;

        /// <summary>
        /// The participations
        /// </summary>
        private Repository<Participation> participations;

        /// <summary>
        /// The participants
        /// </summary>
        private Repository<Participant> participants;

        /// <summary>
        /// The participants
        /// </summary>
        private Repository<UIColor> colors;

        /// <summary>
        /// Initializes a new instance of the <see cref="QVKApiController"/> class.
        /// </summary>
        public QVKApiController()
        {
            this.competiteurs = this.unitOfWork.Repository<Competiteur>();
            this.coupes = this.unitOfWork.Repository<Coupe>();
            this.clubs = this.unitOfWork.Repository<Club>();
            this.encadrants = this.unitOfWork.Repository<Encadrant>();
            this.responsables = this.unitOfWork.Repository<ResponsableClub>();
            this.responsableCoupe = this.unitOfWork.Repository<ResponsableCoupe>();
            this.aires = this.unitOfWork.Repository<Aire>();
            this.medecins = this.unitOfWork.Repository<Medecin>();
            this.epreuves = this.unitOfWork.Repository<Epreuve>();
            this.epreuvesCombat = this.unitOfWork.Repository<EpreuveCombat>();
            this.epreuvesTechniques = this.unitOfWork.Repository<EpreuveTechnique>();
            this.typeEpreuves = this.unitOfWork.Repository<TypeEpreuve>();
            this.categories = this.unitOfWork.Repository<CategoriePratiquant>();
            this.clients = this.unitOfWork.Repository<NetClient>();
            this.participants = this.unitOfWork.Repository<Participant>();
            this.participations = this.unitOfWork.Repository<Participation>();
            this.resultats = this.unitOfWork.Repository<Resultat>();
            this.colors = this.unitOfWork.Repository<UIColor>();
        }

        /// <summary>
        /// Gets the competiteurs.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCompetiteurs()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.competiteurs.Read().Select(c => c.ToModel());
            return result;
        }

        /// <summary>
        /// Gets the coupes.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCoupes()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.coupes.Read().Select(c => c.ToModel());
            return result;
        }

        /// <summary>
        /// Gets the clubs.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetClubs()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.clubs.Read().Select(club => club.ToModel());
            return result;
        }     

        /// <summary>
        /// Gets the encadrants.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEncadrants()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.encadrants.Read().Select(encadrant => encadrant.ToModel());
            return result;
        }

        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetClients()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.clients.Read().Select(client => client.ToModel());
            return result;
        }

        /// <summary>
        /// Gets the responsables.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetResponsables()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.responsables.Read().Select(r => r.ToModel());
            return result;
        }

        /// <summary>
        /// Gets the responsable coupe.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetResponsableCoupe()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.responsableCoupe.Read().FirstOrDefault().ToModel();
            return result;
        }

        /// <summary>
        /// Gets the aires.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAires()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.aires.Read().Select(aire => aire.ToModel());
            return result;
        }

        /// <summary>
        /// Gets the medecins.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMedecins()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.medecins.Read().Select(md => md.ToModel());
            return result;
        }

        /// <summary>
        /// Gets the epreuves.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEpreuves()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.epreuves.Read().Select(epreuve => epreuve.ToModel());
            return result;
        }

        /// <summary>
        /// Gets the epreuves.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEpreuvesCombat()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.epreuvesCombat.Read().Select(ep => ep.ToModel());
            return result;
        }

        /// <summary>
        /// Gets the epreuves.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEpreuvesTechniques()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.epreuvesTechniques.Read().Select(ep => ep.ToModel());
            return result;
        }

        /////// <summary>
        /////// Gets the categories poids.
        /////// </summary>
        /////// <returns></returns>
        ////public JsonResult GetCategoriesPoids()
        ////{
        ////    var result = new JsonResult();
        ////    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        ////    result.Data = this.categoriesPoids.GetAll().Select(cat => cat.ToModel());
        ////    return result;
        ////}

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCategories()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.categories.Read().Select(c => c.ToModel()).OrderBy(cat => cat.AgeMin).ToList();
            return result;
        }

        /// <summary>
        /// Gets the grades.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetGrades()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = Enum.GetValues(typeof(Grade)).Cast<Grade>().Select(cp => new { value = cp, text = Grades.ResourceManager.GetString(cp.ToString()) });
            return result;
        }

        /// <summary>
        /// Gets the genres.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetGenres()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = Enum.GetValues(typeof(Genre)).Cast<Genre>().Select(cp => new { value = cp, text = Genres.ResourceManager.GetString(cp.ToString()) });
            return result;
        }

        /// <summary>
        /// Gets the genre epreuves.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetGenreEpreuves()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = Enum.GetValues(typeof(GenreEpreuve)).Cast<GenreEpreuve>().Select(cp => new { value = cp, text = GenreEpreuves.ResourceManager.GetString(cp.ToString()) });
            return result;
        }

        /// <summary>
        /// Gets the taille tenues.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetTailleTenues()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = Enum.GetValues(typeof(TailleTenue)).Cast<TailleTenue>().Select(cp => new { value = cp, text = cp.ToString() });
            return result;
        }

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRoles()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = Enum.GetValues(typeof(Role)).Cast<Role>().Select(cp => new { value = cp, text = Roles.ResourceManager.GetString(cp.ToString()) });
            return result;
        }

        /// <summary>
        /// Gets the statuses.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetStatuses()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = Enum.GetValues(typeof(StatutEpreuve)).Cast<StatutEpreuve>().Select(cp => new { value = cp, text = StatutEpreuves.ResourceManager.GetString(cp.ToString()) });
            return result;
        }

        /// <summary>
        /// Gets the type epreuves.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetTypeEpreuves()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.typeEpreuves.Read().Select(t => t.ToModel());
            return result;
        }

        /// <summary>
        /// Gets the type epreuves techniques.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetTypeEpreuvesTechniques()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.typeEpreuves.Read().Where(t => t.Technique).Select(t => t.ToModel());
            return result;
        }

        /// <summary>
        /// Gets the type epreuves combat.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetTypeEpreuvesCombat()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.typeEpreuves.Read().Where(t => !t.Technique).Select(t => t.ToModel());
            return result;
        }

        [System.Web.Mvc.AllowAnonymous]
        public JsonResult GetClassementClubs()
        {
            var couleurs = colors.Read();
            var goldColor = couleurs.First(c => c.Identifier == ColorConstants.FIRST).RGB_Code;
            var silverColor = couleurs.First(c => c.Identifier == ColorConstants.SECOND).RGB_Code;
            var bronzeColor = couleurs.First(c => c.Identifier == ColorConstants.THIRD).RGB_Code;
            var defaultColor = couleurs.First(c => c.Identifier == ColorConstants.DEFAULT).RGB_Code;

            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var clubs = this.clubs.Read();
            var participants = this.participants.Read();
            var resultats = this.resultats.Read();
            var participations = this.participations.Read();

           List<ScoreClub> clubsAndScore = new List<ScoreClub>();

            foreach (var club  in clubs)
            {
                var totalPoint = 0;
                foreach (var participant in club.Participants.Where(p => p.Participations != null))
                {
                    foreach (var participation in participant.Participations)
                    {
                        totalPoint += participation.Resultat.Score;
                    }
                }
                clubsAndScore.Add(new ScoreClub {
                    Id = club.Id,
                    Score = totalPoint,
                    Nom = club.Nom,
                    UserColor = defaultColor
                });
            }
            var temp = clubsAndScore.OrderByDescending(a => a.Score).Take(10).ToList();
            if (clubsAndScore.Count >= 3 )
            {
                var first = temp[0];
                var second = temp[1];
                var third = temp[2];
                first.UserColor = goldColor;
                second.UserColor = silverColor;
                third.UserColor = bronzeColor;
                temp.RemoveRange(0, 3);                
                temp.InsertRange(0, new List<ScoreClub>() { first, second, third });
            }
            else if (clubsAndScore.Count == 2)
            {
                var first = temp[0];
                var second = temp[1];                
                first.UserColor = goldColor;
                second.UserColor = silverColor;               
                temp.Clear();
                temp.InsertRange(0, new List<ScoreClub>() { first, second });
            }
            else if (clubsAndScore.Count == 1)
            {
                var first = temp[0];                
                first.UserColor = goldColor;                
                temp.Clear();
                temp.Add(first);
            }
            
            result.Data = temp;
            return result;
        }

        [System.Web.Mvc.AllowAnonymous]
        public JsonResult GetClassementClubsForToday()
        {
            var couleurs = colors.Read();
            var goldColor = couleurs.First(c => c.Identifier == ColorConstants.FIRST).RGB_Code;
            var silverColor = couleurs.First(c => c.Identifier == ColorConstants.SECOND).RGB_Code;
            var bronzeColor = couleurs.First(c => c.Identifier == ColorConstants.THIRD).RGB_Code;
            var defaultColor = couleurs.First(c => c.Identifier == ColorConstants.DEFAULT).RGB_Code;

            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var clubs = this.clubs.Read();
            var participants = this.participants.Read();
            var resultats = this.resultats.Read();
            var participations = this.participations.Read();

            List<ScoreClub> clubsAndScore = new List<ScoreClub>();

            foreach (var club in clubs)
            {
                var totalPoint = 0;
                foreach (var participant in club.Participants.Where(p => p.Participations != null))
                {
                    foreach (var participation in participant.Participations.Where(p => p.Resultat.Date.Day == DateTime.Today.Day))
                    {
                        totalPoint += participation.Resultat.Score;
                    }
                }
                clubsAndScore.Add(new ScoreClub
                {
                    Id = club.Id,
                    Score = totalPoint,
                    Nom = club.Nom,
                    UserColor = defaultColor
                });
            }
            var temp = clubsAndScore.OrderByDescending(a => a.Score).Take(10).ToList();
            if (clubsAndScore.Count >= 3)
            {
                var first = temp[0];
                var second = temp[1];
                var third = temp[2];
                first.UserColor = goldColor;
                second.UserColor = silverColor;
                third.UserColor = bronzeColor;
                temp.RemoveRange(0, 3);
                temp.InsertRange(0, new List<ScoreClub>() { first, second, third });
            }
            else if (clubsAndScore.Count == 2)
            {
                var first = temp[0];
                var second = temp[1];
                first.UserColor = goldColor;
                second.UserColor = silverColor;
                temp.Clear();
                temp.InsertRange(0, new List<ScoreClub>() { first, second });
            }
            else if (clubsAndScore.Count == 1)
            {
                var first = temp[0];
                first.UserColor = goldColor;
                temp.Clear();
                temp.Add(first);
            }

            result.Data = temp;
            return result;
        }
    }    
}
