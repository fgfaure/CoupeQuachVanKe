namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using LamSonVoDao.CoupeQuachVanKe.DataAccessLayer;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class EpreuveTechniqueController : BaseController<EpreuveTechnique>, ICrudController<EpreuveTechnique, EpreuveTechniqueModel>
    {
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.GetAll().Select(et => et.ToModel());
            return result;
        }

        public JsonResult Create(EpreuveTechniqueModel model)
        {
            try
            {
                var dbitem = new EpreuveTechnique
                {
                    CategoriePratiquant = (CategoriePratiquant)model.CategorieId,
                    GenreCategorie = (GenreEpreuve)model.GenreCategorieId,
                    GradeAutorise = (Grade)model.GradeAutoriseId,
                    Statut = StatutEpreuve.Fermee,
                    TypeEpreuveId = model.TypeEpreuveId
                };

                this.repository.Insert(dbitem);
                return Json(model);

            }
            catch
            {
                throw;
            }
        }

        public JsonResult Delete(EpreuveTechniqueModel model)
        {
            try
            {
                var dbmodel = this.repository.Get(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    this.repository.Delete(dbmodel);
                    return Json(model);
                }
                else
                {
                    throw new ArgumentException("L'epreuve technique est absente de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Update(EpreuveTechniqueModel model)
        {
            try
            {
                var dbmodel = this.repository.Get(m => m.Id == model.Id).First();
                if (dbmodel != null)
                {
                    dbmodel.CategoriePratiquant = (CategoriePratiquant)model.CategorieId;                    
                    dbmodel.GenreCategorie = (GenreEpreuve)model.GenreCategorieId;
                    dbmodel.GradeAutorise = (Grade)model.GradeAutoriseId;                    
                    dbmodel.Statut = StatutEpreuve.Fermee;
                    dbmodel.TypeEpreuveId = model.TypeEpreuveId;

                    this.repository.Update(dbmodel);
                    return Json(model);
                }
                else
                {
                    throw new ArgumentException("L'epreuve technique est absente de la base de données", "model");
                }
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Ventilation()
        {
            var epreuvestechniques = this.repository.GetAll();
            var competiteurs = this.unitOfWork.Repository<Competiteur>().GetAll();
            var resultatsRepo = this.unitOfWork.Repository<Resultat>();

            foreach (var resultat in resultatsRepo.GetAll())
            {
                resultatsRepo.Delete(resultat);
            }
            try
            {
                foreach (var competiteur in competiteurs.Where(c => c.InscritPourBaiVuKhi || c.InscritPourQuyen || c.InscritPourSongLuyen))
                {
                    foreach (var epreuve in epreuvestechniques)
                    {
                        if (epreuve.CategoriePratiquant == competiteur.Categorie && (epreuve.GenreCategorie == GenreEpreuve.Mixte || ((int)epreuve.GenreCategorie == (int)competiteur.Sexe)))
                        {
                            if (competiteur.InscritPourBaiVuKhi)
                            {
                                if (epreuve.GradeAutorise == Grade.TousGrades)
                                {
                                    resultatsRepo.Insert(new Resultat
                                    {
                                        EpreuveId = epreuve.Id,
                                        CompetiteurId = competiteur.Id
                                    });
                                }
                                else if (epreuve.GradeAutorise == Grade.MoinsDeCeintureNoire && (competiteur.Grade == Grade.CeintureBlancheA4emeCap || competiteur.Grade == Grade.Plus4emeCapACeintureMarron))
                                {
                                     resultatsRepo.Insert(new Resultat
                                    {
                                        EpreuveId = epreuve.Id,
                                        CompetiteurId = competiteur.Id
                                    });
                                }
                            }

                            if (competiteur.InscritPourQuyen)
                            {
                                if (epreuve.GradeAutorise == Grade.TousGrades)
                                {
                                     resultatsRepo.Insert(new Resultat
                                    {
                                        EpreuveId = epreuve.Id,
                                        CompetiteurId = competiteur.Id
                                    });
                                }
                                else if (epreuve.GradeAutorise == competiteur.Grade)
                                {
                                    resultatsRepo.Insert(new Resultat
                                    {
                                        EpreuveId = epreuve.Id,
                                        CompetiteurId = competiteur.Id
                                    });
                                }
                            }

                            if (competiteur.InscritPourSongLuyen)
                            {
                                if (epreuve.GradeAutorise == Grade.MoinsDeCeintureNoire && (competiteur.Grade == Grade.CeintureBlancheA4emeCap || competiteur.Grade == Grade.Plus4emeCapACeintureMarron))
                                {
                                    resultatsRepo.Insert(new Resultat
                                    {
                                        EpreuveId = epreuve.Id,
                                        CompetiteurId = competiteur.Id
                                    });
                                }
                                else if (epreuve.GradeAutorise == Grade.CeintureNoire && competiteur.Grade == Grade.CeintureNoire)
                                {
                                     resultatsRepo.Insert(new Resultat
                                    {
                                        EpreuveId = epreuve.Id,
                                        CompetiteurId = competiteur.Id
                                    });
                                }
                            }
                        }
                    }
                }
                var result = new JsonResult();
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                result.Data = new {};
                return result;
              
            }
            catch (Exception)
            {                
                throw;
            }
        }

        private IEnumerable<Competiteur> GetCompetiteurs(IEnumerable<Competiteur> competiteurs, List<Resultat> list)
        {
             var comps = new List<Competiteur>();

            foreach (var resultat in list)
            {
                comps.Add(competiteurs.First(c => c.Id == resultat.CompetiteurId));
            }

            return comps;
        }       
    }
}