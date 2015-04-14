using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class VentilationController : Controller
    {
        private UnitOfWork unitOfWork;
        private Repository<EpreuveTechnique> epreuvestechniquesRepository;
        private Repository<EpreuveCombat> epreuvesCombatRepository;
        private Repository<Competiteur> competiteursRepository;
        private Repository<Participation> participationsRepository;


        public VentilationController()
        {
            this.unitOfWork = new UnitOfWork();
            epreuvestechniquesRepository = this.unitOfWork.Repository<EpreuveTechnique>();
            epreuvesCombatRepository = this.unitOfWork.Repository<EpreuveCombat>();
            competiteursRepository = this.unitOfWork.Repository<Competiteur>();
            participationsRepository = this.unitOfWork.Repository<Participation>();
        }

        // GET: Ventilation
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetInscriptionCombat()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var participations = participationsRepository.Read();
            var competiteurs = competiteursRepository.Read();
            var epreuvesCombat = epreuvesCombatRepository.Read();
            for (int i = 0; i < epreuvesCombat.Count(); i++)
            {
                epreuvesCombat.ElementAt(i).TypeEpreuve = this.unitOfWork.Repository<TypeEpreuve>().Read(epreuvesCombat.ElementAt(i).TypeEpreuveId);
            }

            var temp = (from participation in participations
                        join comp in competiteurs on participation.CompetiteurId equals comp.Id into comp_join
                        join ep in epreuvesCombat on participation.EpreuveId equals ep.Id into ep_join
                        from competiteur in comp_join
                        from epreuve in ep_join 
                        where epreuve.Id == participation.EpreuveId && competiteur.Id == participation.CompetiteurId
                        group new { participation, competiteur, epreuve } by new
                        {
                            participation.EpreuveId,
                            epreuve = epreuve.Nom,
                            competiteur.Nom,
                            competiteur.Prenom
                        }
                            into g
                            orderby g.Key.EpreuveId ascending
                            select new
                            {
                                epreuveId = g.Key.EpreuveId,
                                epreuve = g.Key.epreuve,
                                nom = g.Key.Nom,
                                prenom = g.Key.Prenom
                            }).ToList();

            result.Data = temp;
            return result;
        }

        public JsonResult GetInscriptionTechnique()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var participations = participationsRepository.Read();
            var competiteurs = competiteursRepository.Read();
            var epreuvesTechniques = epreuvestechniquesRepository.Read();
            for (int i = 0; i < epreuvesTechniques.Count(); i++)
            {
                epreuvesTechniques.ElementAt(i).TypeEpreuve = this.unitOfWork.Repository<TypeEpreuve>().Read(epreuvesTechniques.ElementAt(i).TypeEpreuveId);
            }
            var temp = (from participation in participations
                        join comp in competiteurs on participation.CompetiteurId equals comp.Id into comp_join
                        join ep in epreuvesTechniques on participation.EpreuveId equals ep.Id into ep_join
                        from competiteur in comp_join
                        from epreuve in ep_join
                        where epreuve.Id == participation.EpreuveId && competiteur.Id == participation.CompetiteurId
                        group new { participation, competiteur, epreuve } by new
                        {
                            participation.EpreuveId,
                            epreuve = epreuve.Nom,
                            competiteur.Nom,
                            competiteur.Prenom
                        }
                            into g
                            orderby g.Key.EpreuveId ascending
                            select new
                            {
                                epreuveId = g.Key.EpreuveId,
                                epreuve = g.Key.epreuve,
                                nom = g.Key.Nom,
                                prenom = g.Key.Prenom
                            }).ToList();

            result.Data = temp;
            return result;
        }

        public JsonResult VentilationCombat()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return result;
        }

        public JsonResult VentilationTechnique()
        {
            var epreuvestechniques = this.unitOfWork.Repository<EpreuveTechnique>().Read();
            var competiteurs = this.unitOfWork.Repository<Competiteur>();
            var participations = this.unitOfWork.Repository<Participation>();

            foreach (var participation in participations.Read())
            {
                participations.Delete(participation);
            }

            try
            {
                foreach (var competiteur in competiteurs.Read(c => c.InscritPourBaiVuKhi || c.InscritPourQuyen || c.InscritPourSongLuyen))
                {
                    foreach (var epreuve in epreuvestechniques)
                    {
                        if (epreuve.CategoriePratiquantId == competiteur.CategoriePratiquantId && (epreuve.GenreCategorie == GenreEpreuve.Mixte || ((int)epreuve.GenreCategorie == (int)competiteur.Sexe)))
                        {
                            if (competiteur.InscritPourBaiVuKhi)
                            {
                                if (epreuve.GradeAutorise == Grade.TousGrades)
                                {
                                    participations.Create(new Participation
                                    {
                                        CompetiteurId = competiteur.Id,
                                        EpreuveId = epreuve.Id,
                                        Resultat = new Resultat()
                                    });
                                }
                                else if (epreuve.GradeAutorise == Grade.MoinsDeCeintureNoire && (competiteur.Grade == Grade.CeintureBlancheA4emeCap || competiteur.Grade == Grade.Plus4emeCapACeintureMarron))
                                {
                                    participations.Create(new Participation
                                    {
                                        CompetiteurId = competiteur.Id,
                                        EpreuveId = epreuve.Id,
                                        Resultat = new Resultat()
                                    });
                                }
                            }


                            if (competiteur.InscritPourQuyen)
                            {
                                if (epreuve.GradeAutorise == Grade.TousGrades)
                                {
                                    participations.Create(new Participation
                                    {
                                        CompetiteurId = competiteur.Id,
                                        EpreuveId = epreuve.Id,
                                        Resultat = new Resultat()
                                    });
                                }
                                else if (epreuve.GradeAutorise == competiteur.Grade)
                                {
                                    participations.Create(new Participation
                                    {
                                        CompetiteurId = competiteur.Id,
                                        EpreuveId = epreuve.Id,
                                        Resultat = new Resultat()
                                    });
                                }
                            }

                            if (competiteur.InscritPourSongLuyen)
                            {
                                if (epreuve.GradeAutorise == Grade.MoinsDeCeintureNoire && (competiteur.Grade == Grade.CeintureBlancheA4emeCap || competiteur.Grade == Grade.Plus4emeCapACeintureMarron))
                                {
                                    participations.Create(new Participation
                                    {
                                        CompetiteurId = competiteur.Id,
                                        EpreuveId = epreuve.Id,
                                        Resultat = new Resultat()
                                    });
                                }
                                else if (epreuve.GradeAutorise == Grade.CeintureNoire && competiteur.Grade == Grade.CeintureNoire)
                                {
                                    participations.Create(new Participation
                                    {
                                        CompetiteurId = competiteur.Id,
                                        EpreuveId = epreuve.Id,
                                        Resultat = new Resultat()
                                    });
                                }
                            }
                        }
                    }
                }

                //var result = new JsonResult();
                //result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

                //var temp = (from participation in participations.Read()
                //            join comp in competiteurs.Read() on participation.CompetiteurId equals comp.Id into comp_join
                //            join ep in epreuvestechniques on participation.EpreuveId equals ep.Id into ep_join
                //            from competiteur in comp_join
                //            from epreuve in ep_join
                //            where epreuve.Id == participation.EpreuveId && competiteur.Id == participation.CompetiteurId
                //            group new { participation, competiteur, epreuve } by new
                //            {
                //                participation.EpreuveId,
                //                epreuve = epreuve.Nom,
                //                competiteur.Nom,
                //                competiteur.Prenom
                //            }
                //                into g
                //                orderby g.Key.EpreuveId ascending
                //                select new
                //                {
                //                    epreuveId = g.Key.EpreuveId,
                //                    epreuve = g.Key.epreuve,
                //                    nom = g.Key.Nom,
                //                    prenom = g.Key.Prenom
                //                }).ToList();


                //result.Data = temp;

                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });                
            }
        }
    }
}