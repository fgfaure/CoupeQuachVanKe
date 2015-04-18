using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
using Resources;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class VentilationController : Controller
    {
        private UnitOfWork unitOfWork;
        private Repository<EpreuveTechnique> epreuvestechniquesRepository;
        private Repository<EpreuveCombat> epreuvesCombatRepository;
        private Repository<Competiteur> competiteursRepository;
        private Repository<Participation> participationsRepository;
        private Repository<TypeEpreuve> typesEpreuvesRepository;

        public VentilationController()
        {
            this.unitOfWork = new UnitOfWork();
            this.epreuvestechniquesRepository = this.unitOfWork.Repository<EpreuveTechnique>();
            this.epreuvesCombatRepository = this.unitOfWork.Repository<EpreuveCombat>();
            this.competiteursRepository = this.unitOfWork.Repository<Competiteur>();
            this.participationsRepository = this.unitOfWork.Repository<Participation>();
            this.typesEpreuvesRepository = this.unitOfWork.Repository<TypeEpreuve>();
        }

        public ActionResult Index()
        {
            return this.View();
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


        [HttpGet]
        public JsonResult GetEpreuvesTechniquesWithCount()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var participations = participationsRepository.Read();
            var competiteurs = competiteursRepository.Read();
            var epreuvesTechniques = epreuvestechniquesRepository.Read();

            var valuedTrials = (from participation in participations
                                from comp in competiteurs
                                where comp.Id == participation.CompetiteurId
                                && participation.Epreuve != null
                                group participation by participation.EpreuveId into filteredEpreuves
                                select new
                                {
                                    EpreuveId = epreuvesTechniques.FirstOrDefault(e => e.Id == filteredEpreuves.Key).Id,
                                    Epreuve = epreuvesTechniques.FirstOrDefault(e => e.Id == filteredEpreuves.Key).Nom,
                                    Count = filteredEpreuves.Count()
                                }).ToList();
            result.Data = valuedTrials;
            return result;
        }

        [HttpGet]
        public JsonResult GetEpreuvesCombatWithCount()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var participations = participationsRepository.Read();
            var competiteurs = competiteursRepository.Read();
            var epreuvesCombat = epreuvesCombatRepository.Read();

            var valuedTrials = (from participation in participations
                                from comp in competiteurs
                                where comp.Id == participation.CompetiteurId
                                && participation.Epreuve != null
                                group participation by participation.EpreuveId into filteredEpreuves
                                select new
                                {
                                    EpreuveId = epreuvesCombat.FirstOrDefault(e => e.Id == filteredEpreuves.Key).Id,
                                    Epreuve = epreuvesCombat.FirstOrDefault(e => e.Id == filteredEpreuves.Key).Nom,
                                    Count = filteredEpreuves.Count()
                                }).ToList();
            result.Data = valuedTrials;
            return result;
        }

        [HttpPost]
        public JsonResult Competiteurs(string id)
        {
            int parsed;
            if (int.TryParse(id, out parsed))
            {
                var result = new JsonResult();
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

                var participations = participationsRepository.Read();
                var competiteurs = competiteursRepository.Read();

                IEnumerable<CompetiteurModel> competiteursEpreuve;


                competiteursEpreuve = (from competiteur in competiteurs
                                       join participation in participations on competiteur.Id equals participation.CompetiteurId
                                       where participation.EpreuveId == parsed
                                       select competiteur.ToModel()).ToList();

                result.Data = competiteursEpreuve;

                return result;
            }
            else
            {
                throw new ArgumentException("Invalid Id", "id");
            }
        }

        public JsonResult VentilationTechnique()
        {
            var epreuvestechniques = this.unitOfWork.Repository<EpreuveTechnique>().Read();
            var competiteurs = this.unitOfWork.Repository<Competiteur>();
            var participations = this.unitOfWork.Repository<Participation>();
            var typesEpreuves = this.unitOfWork.Repository<TypeEpreuve>().Read();

            foreach (var epreuve in epreuvestechniques)
            {
                epreuve.TypeEpreuve = typesEpreuves.First(tp => tp.Id == epreuve.TypeEpreuveId);
                foreach (var participation in participations.Read())
                {
                    if (epreuvestechniques.FirstOrDefault(e => e.Id == participation.EpreuveId) != null)
                        participations.Delete(participation);
                }
            }

            try
            {
                foreach (var competiteur in competiteurs.Read(c => c.InscritPourBaiVuKhi || c.InscritPourQuyen || c.InscritPourSongLuyen))
                {
                    foreach (var epreuve in epreuvestechniques.Where(e => e.TypeEpreuveId < 3))
                    {
                        if (epreuve.CategoriePratiquantId == competiteur.CategoriePratiquantId && (epreuve.GenreCategorie == GenreEpreuve.Mixte || ((int)epreuve.GenreCategorie == (int)competiteur.Sexe)))
                        {
                            if (competiteur.InscritPourBaiVuKhi && epreuve.TypeEpreuveId == 1)
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


                            if (competiteur.InscritPourQuyen && epreuve.TypeEpreuveId == 2)
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
                            //if (competiteur.InscritPourSongLuyen)
                            //{
                            //    if (epreuve.GradeAutorise == Grade.MoinsDeCeintureNoire && (competiteur.Grade == Grade.CeintureBlancheA4emeCap || competiteur.Grade == Grade.Plus4emeCapACeintureMarron))
                            //    {
                            //        participations.Create(new Participation
                            //        {
                            //            CompetiteurId = competiteur.Id,
                            //            EpreuveId = epreuve.Id,
                            //            Resultat = new Resultat()
                            //        });
                            //    }
                            //    else if (epreuve.GradeAutorise == Grade.CeintureNoire && competiteur.Grade == Grade.CeintureNoire)
                            //    {
                            //        participations.Create(new Participation
                            //        {
                            //            CompetiteurId = competiteur.Id,
                            //            EpreuveId = epreuve.Id,
                            //            Resultat = new Resultat()
                            //        });
                            //    }
                            //}
                        }
                    }
                }

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult VentilationCombat()
        {
            var epreuvesCombats = this.unitOfWork.Repository<EpreuveCombat>().Read();
            var competiteurs = this.unitOfWork.Repository<Competiteur>();
            var participations = this.unitOfWork.Repository<Participation>();
            var typesEpreuves = this.unitOfWork.Repository<TypeEpreuve>().Read();

            try
            {
                foreach (var epreuve in epreuvesCombats)
                {
                    epreuve.TypeEpreuve = typesEpreuves.First(tp => tp.Id == epreuve.TypeEpreuveId);
                    foreach (var participation in participations.Read())
                    {
                        if (epreuvesCombats.FirstOrDefault(e => e.Id == participation.EpreuveId) != null)
                            participations.Delete(participation);
                    }
                }

                foreach (var epreuve in epreuvesCombats)
                {
                    foreach (var competiteur in competiteurs.Read())
                    {
                        if (epreuve.CategoriePratiquantId == competiteur.CategoriePratiquantId && (epreuve.GenreCategorie == GenreEpreuve.Mixte || ((int)epreuve.GenreCategorie == (int)competiteur.Sexe)) && (competiteur.Poids >= epreuve.PoidsMini && competiteur.Poids < epreuve.PoidsMaxi))
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
                    }
                }

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult MergeEpreuve(IEnumerable<EpreuveModel> epreuves, string areTechs)
        {
            bool techEpreuve;

            if (bool.TryParse(areTechs, out techEpreuve))
            {

                try
                {
                    var result = new JsonResult();
                    List<Epreuve> sources = new List<Epreuve>();
                    if (techEpreuve)
                    {

                        var matches = (from epreuve in epreuves
                                       from dbItem in this.epreuvestechniquesRepository.Read()
                                       where dbItem.Id == epreuve.EpreuveId
                                       select dbItem).ToList();

                        foreach (var item in matches)
                        {
                            sources.Add(item);
                        }

                    }
                    else
                    {
                        var matches = (from epreuve in epreuves
                                       from dbItem in this.epreuvesCombatRepository.Read()
                                       where dbItem.Id == epreuve.EpreuveId
                                       select dbItem).ToList();

                        foreach (var item in matches)
                        {
                            sources.Add(item);
                        }
                    }

                    sources.OrderByDescending(m => m.CategoriePratiquantId);

                    var categoryNames = (from cat in this.unitOfWork.Repository<CategoriePratiquant>().Read()
                                         join model in sources on cat.Id equals model.CategoriePratiquantId
                                         select cat.Nom).Distinct();
                    Epreuve merged;
                    if (techEpreuve)
                    {
                        merged = new EpreuveTechnique();
                    }
                    else
                    {
                        merged = new EpreuveCombat();
                    }
                     
                    merged.IsMerged = true;
                    merged.CategoriePratiquantId = sources.First().CategoriePratiquantId;
                    var isGenreMerged = sources.GroupBy(m => m.GenreCategorie).Distinct().Count() > 1;
                    if (isGenreMerged)
                    {
                        merged.GenreCategorie = GenreEpreuve.Mixte;
                    }
                    else
                    {
                        merged.GenreCategorie = sources.First().GenreCategorie;
                    }

                    merged.GradeAutorise = sources.First().GradeAutorise;
                    merged.Statut = StatutEpreuve.Fermee;
                    merged.TypeEpreuveId = sources.First().TypeEpreuveId;

                    var genre = GenreEpreuves.ResourceManager.GetString(merged.GenreCategorie.ToString());
                    var grade = Grades.ResourceManager.GetString(merged.GradeAutorise.ToString());
                    var typeEpreuve = this.typesEpreuvesRepository.Read(sources.First().TypeEpreuveId).Nom;
                    merged.Nom = string.Format("{0} {1} {2} {3}", typeEpreuve, string.Join(" ", categoryNames.ToArray()), genre, grade);
                    if (!techEpreuve)
                    {

                        ((EpreuveCombat)merged).PoidsMaxi = sources.Cast<EpreuveCombat>().Max(e => e.PoidsMaxi);
                        ((EpreuveCombat)merged).PoidsMini = sources.Cast<EpreuveCombat>().Min(e => e.PoidsMini);
                        merged.Nom = string.Format("{0} de {1}kgs à {2}kgs", merged.Nom, ((EpreuveCombat)merged).PoidsMini, ((EpreuveCombat)merged).PoidsMaxi);
                    }

                    if (techEpreuve)
                    {
                        this.epreuvestechniquesRepository.Create(merged as EpreuveTechnique);
                    }
                    else
                    {
                        this.epreuvesCombatRepository.Create(merged as EpreuveCombat);
                    }

                    //this.repository.Create(merged);

                    var idForNewEpreuve = merged.Id;

                    var partipations = this.unitOfWork.Repository<Participation>();

                    var participationsToChange = (from participation in partipations.Read()
                                                  join model in sources
                                                  on participation.EpreuveId equals model.Id
                                                  select participation).ToList();

                    for (int i = 0; i < participationsToChange.Count(); i++)
                    {
                        participationsToChange[i].EpreuveId = idForNewEpreuve;
                        partipations.Update(participationsToChange[i]);
                    }

                    result.Data = string.Empty;
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }

            }
            else
            {
                throw new ArgumentException("Passed parameter can't be parsed to bool type", "areTechs");
            }

        }
    }
}