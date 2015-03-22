﻿using LamSonVodao.CoupeQuachVanKe.AccesPattern;
using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
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
            result.Data = this.competiteursRepo.GetAll().Select(c => new CompetiteurModel
            {
                Categorie = c.Categorie,
                ClubId = c.ClubId,
                DateNaissance = c.DateNaissance,
                Id = c.Id,
                InscriptionValidePourCoupe = c.InscriptionValidePourCoupe,
                LicenceFFKDA = c.LicenceFFKDA,
                Nom = c.Nom,
                Prenom = c.Prenom,
                Poids = c.Poids,
                Sexe = c.Sexe
            });
            return result;
        }

        [HttpGet]
        public JsonResult GetClubs()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.MaxJsonLength = Int32.MaxValue;
            result.Data = this.competiteursRepo.GetAll().Select(c => new ClubModel
            {
                Id = c.ClubId,
                Nom = c.Club.Nom
            });
            return result;
        }

        [HttpPost]
        public JsonResult UpdateCompetiteur(CompetiteurModel competiteur)
        {
            var dbItem = this.competiteursRepo.GetById(competiteur.Id);
            if (dbItem != null)
            {
                dbItem.Categorie = competiteur.Categorie;
                dbItem.DateNaissance = competiteur.DateNaissance;
                dbItem.InscriptionValidePourCoupe = competiteur.InscriptionValidePourCoupe;
                dbItem.LicenceFFKDA = competiteur.LicenceFFKDA;
                dbItem.Nom = competiteur.Nom;
                dbItem.Prenom = competiteur.Prenom;
                dbItem.Poids = competiteur.Poids;
                dbItem.Sexe = competiteur.Sexe;

                try
                {
                    this.competiteursRepo.Update(dbItem);
                    return Json(new { success = true });
                }
                catch (Exception)
                {

                    throw;
                }

            }
            return Json(new { success = false, reason = "compétiteur absent de la base." });
        }

        [HttpPost]
        public JsonResult DeleteCompetiteur(CompetiteurModel competiteur)
        {
            var dbItem = this.competiteursRepo.GetById(competiteur.Id);
            if (dbItem != null)
            {
                try
                {
                    this.competiteursRepo.Delete(dbItem);
                    return Json(new { success = true });
                }
                catch (Exception)
                {

                    throw;
                }

            }
            return Json(new { success = false, reason = "compétiteur absent de la base." });
        }

        [HttpPost]
        public JsonResult CreateCompetiteur(CompetiteurModel competiteur)
        {
            Competiteur dbItem = new Competiteur
            {                
                Categorie = competiteur.Categorie,
                ClubId = competiteur.ClubId,                
                DateNaissance = competiteur.DateNaissance,
                EquipeSongLuyen = competiteur.EquipeSongLuyen,
                Grade = competiteur.Grade,                              
                InscriptionValidePourCoupe = competiteur.InscriptionValidePourCoupe,
                InscritPourBaiVuKhi = competiteur.InscritPourBaiVuKhi,
                InscritPourCombat = competiteur.InscritPourCombat,
                InscritPourQuyen = competiteur.InscritPourQuyen,
                InscritPourSongLuyen = competiteur.InscritPourSongLuyen,                
                LicenceFFKDA = competiteur.LicenceFFKDA,
                NbAnneePratique = competiteur.NbAnneePratique,
                Nom = competiteur.Nom,
                Prenom = competiteur.Prenom,
                Poids = competiteur.Poids,                
                Sexe = competiteur.Sexe
            };

            try
            {
                this.competiteursRepo.Insert(dbItem);
                return Json(new { success = true });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}