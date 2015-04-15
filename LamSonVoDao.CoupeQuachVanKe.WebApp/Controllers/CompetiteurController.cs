﻿namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
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

    public class CompetiteurController : BaseController<Competiteur>, ICrudController<Competiteur, CompetiteurModel>
    {        
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
                EquipeSongLuyenNumero = competiteur.EquipeSongLuyenNumero,
                GradeId = (int)competiteur.Grade,
                InscriptionValidePourCoupe = competiteur.InscriptionValidePourCoupe,
                InscritPourBaiVuKhi = competiteur.InscritPourBaiVuKhi,
                InscritPourCombat = competiteur.InscritPourCombat,
                InscritPourQuyen = competiteur.InscritPourQuyen,
                InscritPourSongLuyen = competiteur.InscritPourSongLuyen,
                LicenceFFKDA = competiteur.LicenceFFKDA,
                NbAnneePratique = competiteur.NbAnneePratique,                
                Poids = competiteur.Poids,
                GenreId = (int)competiteur.Sexe,
                ValidImport = competiteur.ValidImport
            });
            return result;
        }

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
                    EquipeSongLuyenNumero = model.EquipeSongLuyenNumero,
                    Grade =  (Grade)model.GradeId,
                    InscriptionValidePourCoupe = model.InscriptionValidePourCoupe,
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
                    dbmodel.EquipeSongLuyenNumero = model.EquipeSongLuyenNumero;
                    dbmodel.Grade = (Grade)model.GradeId;
                    dbmodel.InscriptionValidePourCoupe = model.InscriptionValidePourCoupe;
                    dbmodel.InscritPourBaiVuKhi = model.InscritPourBaiVuKhi;
                    dbmodel.InscritPourCombat = model.InscritPourCombat;
                    dbmodel.InscritPourQuyen = model.InscritPourQuyen;
                    dbmodel.InscritPourSongLuyen = model.InscritPourSongLuyen;
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
    }
}