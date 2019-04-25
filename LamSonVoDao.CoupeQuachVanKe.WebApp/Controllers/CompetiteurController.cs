namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
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

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers.BaseController{LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Competiteur}" />
    /// <seealso cref="LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts.ICrudController{LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Competiteur, LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe.CompetiteurModel}" />
    public class CompetiteurController : BaseController<Competiteur>, ICrudController<Competiteur, CompetiteurModel>
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.Read().Select(competiteur => new CompetiteurModel
            {
                Id = competiteur.Id,                
                Nom = competiteur.Nom,
                Prenom = competiteur.Prenom,
                CategorieId = competiteur.CategoriePratiquantId,
                ClubId = competiteur.ClubId,
                DateNaissance = competiteur.DateNaissance,
                NumeroEquipe = competiteur.NumeroEquipe,
                GradeId = (int)competiteur.Grade,
                InscriptionValidePourCoupe = competiteur.InscriptionValidePourCoupe,
                InscritPourBaiVuKhi = competiteur.InscritPourBaiVuKhi,
                InscritPourCombat = competiteur.InscritPourCombat,
                InscritPourQuyen = competiteur.InscritPourQuyen,
                InscritPourSongLuyen = competiteur.InscritPourSongLuyen,
                InscritPourQuyenDongDien = competiteur.InscritPourQuyenDongDien,
                LicenceFFKDA = competiteur.LicenceFFKDA,
                NbAnneePratique = competiteur.NbAnneePratique,                
                Poids = competiteur.Poids,
                GenreId = (int)competiteur.Sexe,
                ValidImport = competiteur.ValidImport
            });
            return result;
        }

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public JsonResult Create(CompetiteurModel model)
        {
            try
            {
                var dbitem = new Competiteur
                {
                    Id = model.Id,
                    Nom = model.Nom,
                    Prenom = model.Prenom,
                    CategoriePratiquantId = model.CategorieId,
                    ClubId = model.ClubId,
                    DateNaissance = model.DateNaissance,
                    NumeroEquipe = model.NumeroEquipe,
                    Grade =  (Grade)model.GradeId,
                    InscriptionValidePourCoupe = model.InscriptionValidePourCoupe,
                    InscritPourQuyenDongDien = model.InscritPourQuyenDongDien,
                    InscritPourBaiVuKhi = model.InscritPourBaiVuKhi,
                    InscritPourCombat = model.InscritPourCombat,
                    InscritPourQuyen = model.InscritPourQuyen,
                    InscritPourSongLuyen = model.InscritPourSongLuyen,
                    LicenceFFKDA = model.LicenceFFKDA,
                    NbAnneePratique = model.NbAnneePratique,
                    Poids = model.Poids,
                    Sexe =  (Genre)model.GenreId,
                    ValidImport = true
                };

                this.repository.Create(dbitem);
                return Json(dbitem.ToModel());
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Le compétiteur est absent de la base de données - model</exception>
        public JsonResult Delete(CompetiteurModel model)
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
                    throw new ArgumentException("Le compétiteur est absent de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Le compétiteur est absent de la base de données - model</exception>
        public JsonResult Update(CompetiteurModel model)
        {
            try
            {
                var dbmodel = this.repository.Read(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    dbmodel.Nom = model.Nom;
                    dbmodel.Prenom = model.Prenom;
                    dbmodel.CategoriePratiquantId = model.CategorieId;
                    dbmodel.ClubId = model.ClubId;
                    dbmodel.DateNaissance = model.DateNaissance;
                    dbmodel.NumeroEquipe = model.NumeroEquipe;
                    dbmodel.Grade = (Grade)model.GradeId;
                    dbmodel.InscriptionValidePourCoupe = model.InscriptionValidePourCoupe;
                    dbmodel.InscritPourBaiVuKhi = model.InscritPourBaiVuKhi;
                    dbmodel.InscritPourCombat = model.InscritPourCombat;
                    dbmodel.InscritPourQuyen = model.InscritPourQuyen;
                    dbmodel.InscritPourSongLuyen = model.InscritPourSongLuyen;
                    dbmodel.InscritPourQuyenDongDien = model.InscritPourQuyenDongDien;
                    dbmodel.LicenceFFKDA = model.LicenceFFKDA;
                    dbmodel.NbAnneePratique = model.NbAnneePratique;
                    dbmodel.Poids = model.Poids;
                    dbmodel.Sexe = (Genre)model.GenreId;
                    dbmodel.ValidImport = true;
                    this.repository.Update(dbmodel);
                    return Json(model);
                }
                else
                {
                    throw new ArgumentException("Le compétiteur est absent de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Excels the save.
        /// </summary>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="base64">The base64.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ExcelSave(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    }
}