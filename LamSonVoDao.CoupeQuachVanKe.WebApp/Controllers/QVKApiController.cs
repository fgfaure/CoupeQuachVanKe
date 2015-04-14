namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
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
        /// The epreuves combat
        /// </summary>
        private Repository<EpreuveCombat> epreuvesCombat;
        /// <summary>
        /// The epreuves techniques
        /// </summary>
        private Repository<EpreuveTechnique> epreuvesTechniques;
        /////// <summary>
        /////// The categories poids
        /////// </summary>
        ////private Repository<CategoriePoids> categoriesPoids;

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
            this.epreuvesCombat = this.unitOfWork.Repository<EpreuveCombat>();
            this.epreuvesTechniques = this.unitOfWork.Repository<EpreuveTechnique>();
            ////this.categoriesPoids = this.unitOfWork.Repository<CategoriePoids>();
            this.typeEpreuves = this.unitOfWork.Repository<TypeEpreuve>();
            this.categories = this.unitOfWork.Repository<CategoriePratiquant>();
            this.clients = this.unitOfWork.Repository<NetClient>();
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
            result.Data = this.categories.Read().Select(c => c.ToModel()).ToList();
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

        public JsonResult GetStatuses()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = Enum.GetValues(typeof(StatutEpreuve)).Cast<StatutEpreuve>().Select(cp => new { value = cp, text = StatutEpreuves.ResourceManager.GetString(cp.ToString()) });
            return result;
        }

        public JsonResult GetTypeEpreuves()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.typeEpreuves.Read().Select(t => t.ToModel());
            return result;
        }

        public JsonResult GetTypeEpreuvesTechniques()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.typeEpreuves.Read().Where(t => t.Technique).Select(t => t.ToModel());
            return result;
        }

        public JsonResult GetTypeEpreuvesCombat()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.typeEpreuves.Read().Where(t => !t.Technique).Select(t => t.ToModel());
            return result;
        }
    }
}
