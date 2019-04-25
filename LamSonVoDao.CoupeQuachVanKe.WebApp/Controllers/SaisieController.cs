namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class SaisieController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<Competiteur> competiteursRepo;

        public SaisieController()
        {
            this.competiteursRepo = this.unitOfWork.Repository<Competiteur>();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCompetiteurs()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.MaxJsonLength = Int32.MaxValue;
            var competiteurs = this.competiteursRepo.Read();
            result.Data = competiteurs.Where(c => c.InscritPourCombat).Select(c => new CompetiteurModel
            {
                CategorieId = c.CategoriePratiquantId,
                ClubId = c.ClubId,
                DateNaissance = c.DateNaissance,
                Id = c.Id,
                InscriptionValidePourCoupe = c.InscriptionValidePourCoupe,
                LicenceFFKDA = c.LicenceFFKDA,
                Nom = c.Nom,
                Prenom = c.Prenom,
                Poids = c.Poids,
                GenreId = (int)c.Sexe,
                NbPesee = c.NbPesee
            });

            return result;
        }

        [HttpGet]
        public JsonResult GetClubs()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.MaxJsonLength = Int32.MaxValue;
            result.Data = this.competiteursRepo.Read().Select(c => new ClubModel
            {
                Id = c.ClubId,
                Nom = c.Club.Nom
            });
            return result;
        }

        [HttpPost]
        public JsonResult UpdateCompetiteur(CompetiteurModel competiteur)
        {
            var dbItem = this.competiteursRepo.Read(competiteur.Id);
            if (dbItem != null)
            {
                dbItem.CategoriePratiquantId = competiteur.CategorieId;               
                dbItem.InscriptionValidePourCoupe = competiteur.InscriptionValidePourCoupe;
                dbItem.Poids = competiteur.Poids;               
                dbItem.NbPesee += 1;

                try
                {
                    this.competiteursRepo.Update(dbItem);
                    return Json(dbItem.ToModel());
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, reason = ex.Message });
                }

            }
            return Json(new { success = false, reason = "compétiteur absent de la base." });
        }
    }
}