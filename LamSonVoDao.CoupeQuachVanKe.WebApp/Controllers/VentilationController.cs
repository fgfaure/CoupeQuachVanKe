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
using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class VentilationController : Controller
    {
        private UnitOfWork unitOfWork;
        private Repository<EpreuveTechnique> epreuvestechniquesRepository;
        private Repository<EpreuveCombat> epreuvesCombatRepository;
        private Repository<Competiteur> competiteursRepository;
        private Repository<Equipe> equipesRepository;
        private Repository<Participation> participationsRepository;
        private Repository<TypeEpreuve> typesEpreuvesRepository;
        private Repository<Participant> participantsRepository;

        public VentilationController()
        {
            this.unitOfWork = new UnitOfWork();
            this.epreuvestechniquesRepository = this.unitOfWork.Repository<EpreuveTechnique>();
            this.epreuvesCombatRepository = this.unitOfWork.Repository<EpreuveCombat>();
            this.competiteursRepository = this.unitOfWork.Repository<Competiteur>();
            this.equipesRepository = this.unitOfWork.Repository<Equipe>();
            this.participantsRepository = this.unitOfWork.Repository<Participant>();
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
            var clubs = this.unitOfWork.Repository<Club>().Read();
            var participations = participationsRepository.Read();
            var participants = this.participantsRepository.Read();
            var epreuvesCombat = epreuvesCombatRepository.Read();
            for (int i = 0; i < epreuvesCombat.Count(); i++)
            {
                epreuvesCombat.ElementAt(i).TypeEpreuve = this.unitOfWork.Repository<TypeEpreuve>().Read(epreuvesCombat.ElementAt(i).TypeEpreuveId);
            }

            var temp = (from participation in participations
                        join comp in participants on participation.ParticipantId equals comp.Id into comp_join
                        join ep in epreuvesCombat on participation.EpreuveId equals ep.Id into ep_join
                        from competiteur in comp_join
                        from epreuve in ep_join
                        where epreuve.Id == participation.EpreuveId && competiteur.Id == participation.ParticipantId
                        group new { participation, competiteur, epreuve } by new
                        {
                            participation.EpreuveId,
                            epreuve = epreuve.Nom,
                            competiteur.Nom,
                            competiteur.Prenom,
                            ((Competiteur)competiteur).Poids,
                            Club = competiteur.Club.Nom,
                            ClubId = competiteur.Club.Id
                        }
                            into g
                        orderby g.Key.EpreuveId ascending
                        select new
                        {
                            epreuveId = g.Key.EpreuveId,
                            epreuve = g.Key.epreuve,
                            nom = g.Key.Nom,
                            prenom = g.Key.Prenom,
                            poids = g.Key.Poids,
                            club = g.Key.Club,
                            clubId = g.Key.ClubId
                        }).ToList();

            result.Data = temp;
            return result;
        }

        public JsonResult GetInscriptionTechnique()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var clubs = this.unitOfWork.Repository<Club>().Read();
            var participations = participationsRepository.Read();
            var participants = this.participantsRepository.Read();
            var epreuvesTechniques = epreuvestechniquesRepository.Read();
            for (int i = 0; i < epreuvesTechniques.Count(); i++)
            {
                epreuvesTechniques.ElementAt(i).TypeEpreuve = this.unitOfWork.Repository<TypeEpreuve>().Read(epreuvesTechniques.ElementAt(i).TypeEpreuveId);
            }
            var temp = (from participation in participations
                        join participant in participants on participation.ParticipantId equals participant.Id into comp_join
                        join ep in epreuvesTechniques on participation.EpreuveId equals ep.Id into ep_join
                        from competiteur in comp_join
                        from epreuve in ep_join
                        where epreuve.Id == participation.EpreuveId && competiteur.Id == participation.ParticipantId
                        group new { participation, competiteur, epreuve } by new
                        {
                            participation.EpreuveId,
                            epreuve = epreuve.Nom,
                            competiteur.Nom,
                            competiteur.Prenom,
                            ClubId = competiteur.ClubId,
                            Club = competiteur.Club.Nom
                        }
                            into g
                        orderby g.Key.EpreuveId ascending
                        select new
                        {
                            epreuveId = g.Key.EpreuveId,
                            epreuve = g.Key.epreuve,
                            nom = g.Key.Nom,
                            prenom = g.Key.Prenom,
                            club = g.Key.Club,
                            clubId = g.Key.ClubId
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
            var participants = participantsRepository.Read();
            var epreuvesTechniques = epreuvestechniquesRepository.Read();

            var valuedTrials = (from participation in participations
                                from comp in participants
                                where comp.Id == participation.ParticipantId
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
                                where comp.Id == participation.ParticipantId
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
                                       join participation in participations on competiteur.Id equals participation.ParticipantId
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
            var typesEpreuves = this.unitOfWork.Repository<TypeEpreuve>().Read();
            var epreuvestechniques = this.unitOfWork.Repository<EpreuveTechnique>().Read();
            var participants = this.participantsRepository.Read();
            var participations = this.unitOfWork.Repository<Participation>();

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
                var competiteursTechniques = participants.OfType<Competiteur>().Where(c => c.InscritPourBaiVuKhi || c.InscritPourQuyen || c.InscritPourSongLuyen || c.InscritPourQuyenDongDien).ToList();
                foreach (var competiteur in competiteursTechniques)
                {
                    foreach (var epreuve in epreuvestechniques.Where(e => e.TypeEpreuveId < 3 && e.Statut != StatutEpreuve.Exclue))
                    {
                        var competiteurBoundToEpreuve = false;
                        if (epreuve.CategoriePratiquantId == competiteur.CategoriePratiquantId && (epreuve.GenreCategorie == GenreEpreuve.Mixte || ((int)epreuve.GenreCategorie == (int)competiteur.Sexe)))
                        {
                            if (competiteur.InscritPourQuyen && epreuve.TypeEpreuve.Identifier == TypeEpreuveConstants.BAIQUYEN)
                            {
                                if (epreuve.GradeAutorise == Grade.TousGrades)
                                {
                                    competiteurBoundToEpreuve = true;
                                    this.participationsRepository.Create(new Participation
                                    {
                                        ParticipantId = competiteur.Id,
                                        EpreuveId = epreuve.Id,
                                        Resultat = new Resultat()
                                        {
                                            Date = DateTime.Now
                                        }
                                    });
                                }
                                else if (epreuve.GradeAutorise == Grade.MoinsDeCeintureNoire && (competiteur.Grade == Grade.CeintureBlancheA4emeCap || competiteur.Grade == Grade.Plus4emeCapACeintureMarron))
                                {
                                    competiteurBoundToEpreuve = true;
                                    this.participationsRepository.Create(new Participation
                                    {
                                        ParticipantId = competiteur.Id,
                                        EpreuveId = epreuve.Id,
                                        Resultat = new Resultat()
                                        {
                                            Date = DateTime.Now
                                        }
                                    });
                                }
                                else if (epreuve.GradeAutorise == competiteur.Grade)
                                {
                                    competiteurBoundToEpreuve = true;
                                    this.participationsRepository.Create(new Participation
                                    {
                                        ParticipantId = competiteur.Id,
                                        EpreuveId = epreuve.Id,
                                        Resultat = new Resultat()
                                        {
                                            Date = DateTime.Now
                                        }
                                    });
                                }
                            }

                            if (competiteur.InscritPourBaiVuKhi && epreuve.TypeEpreuve.Identifier == TypeEpreuveConstants.BAIVUKHI)
                            {
                                competiteurBoundToEpreuve = true;
                                if (epreuve.GradeAutorise == Grade.TousGrades)
                                {
                                    this.participationsRepository.Create(new Participation
                                    {
                                        ParticipantId = competiteur.Id,
                                        EpreuveId = epreuve.Id,
                                        Resultat = new Resultat()
                                        {
                                            Date = DateTime.Now
                                        }
                                    });
                                }
                                else if (epreuve.GradeAutorise == Grade.MoinsDeCeintureNoire && (competiteur.Grade == Grade.CeintureBlancheA4emeCap || competiteur.Grade == Grade.Plus4emeCapACeintureMarron))
                                {
                                    competiteurBoundToEpreuve = true;
                                    this.participationsRepository.Create(new Participation
                                    {
                                        ParticipantId = competiteur.Id,
                                        EpreuveId = epreuve.Id,
                                        Resultat = new Resultat()
                                        {
                                            Date = DateTime.Now
                                        }
                                    });
                                }
                                else if (epreuve.GradeAutorise == competiteur.Grade)
                                {
                                    competiteurBoundToEpreuve = true;
                                    this.participationsRepository.Create(new Participation
                                    {
                                        ParticipantId = competiteur.Id,
                                        EpreuveId = epreuve.Id,
                                        Resultat = new Resultat()
                                        {
                                            Date = DateTime.Now
                                        }
                                    });
                                }
                            }
                        }
                        if (competiteurBoundToEpreuve)
                        {
                            epreuve.Statut = StatutEpreuve.Ouverte;
                            epreuvestechniquesRepository.Update(epreuve);
                        }
                    }
                }

                var equipes = participants.OfType<Equipe>().ToList();
                foreach (var equipe in equipes)
                {
                    foreach (var epreuve in epreuvestechniques.Where(e => e.TypeEpreuve.Identifier == TypeEpreuveConstants.QUYENDONGDIEN))
                    {
                        var competiteurBoundToEpreuve = false;
                        var membres = equipe.Competiteurs;
                        var hasBlackBelt = membres.Select(m => m.Grade).Contains(Grade.CeintureNoire);

                        if (membres.First().InscritPourQuyenDongDien && hasBlackBelt && epreuve.GradeAutorise == Grade.CeintureNoire)
                        {
                            this.participationsRepository.Create(new Participation
                            {
                                ParticipantId = equipe.Id,
                                EpreuveId = epreuve.Id,
                                Resultat = new Resultat()
                                {
                                    Date = DateTime.Now
                                }
                            });
                            competiteurBoundToEpreuve = true;
                        }
                        else if (membres.First().InscritPourQuyenDongDien && !hasBlackBelt && epreuve.GradeAutorise == Grade.MoinsDeCeintureNoire)
                        {
                            this.participationsRepository.Create(new Participation
                            {
                                ParticipantId = equipe.Id,
                                EpreuveId = epreuve.Id,
                                Resultat = new Resultat()
                                {
                                    Date = DateTime.Now
                                }
                            });
                            competiteurBoundToEpreuve = true;
                        }

                        if (competiteurBoundToEpreuve)
                        {
                            epreuve.Statut = StatutEpreuve.Ouverte;
                            epreuvestechniquesRepository.Update(epreuve);
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

                foreach (var epreuve in epreuvesCombats.Where(e => e.Statut != StatutEpreuve.Exclue))
                {
                    bool competiteurBoundToEpreuve = false;
                    foreach (var competiteur in competiteurs.Read().Where(c => c.InscritPourCombat))
                    {
                        if (epreuve.CategoriePratiquantId == competiteur.CategoriePratiquantId && (epreuve.GenreCategorie == GenreEpreuve.Mixte || ((int)epreuve.GenreCategorie == (int)competiteur.Sexe)) && (competiteur.Poids >= epreuve.PoidsMini && competiteur.Poids < epreuve.PoidsMaxi))
                        {
                            if (epreuve.GradeAutorise == Grade.TousGrades)
                            {
                                competiteurBoundToEpreuve = true;
                                participations.Create(new Participation
                                {
                                    ParticipantId = competiteur.Id,
                                    EpreuveId = epreuve.Id,
                                    Resultat = new Resultat()
                                    {
                                        Date = DateTime.Now
                                    }
                                });
                            }
                            else if (epreuve.GradeAutorise == Grade.MoinsDeCeintureNoire && (competiteur.Grade == Grade.CeintureBlancheA4emeCap || competiteur.Grade == Grade.Plus4emeCapACeintureMarron))
                            {
                                competiteurBoundToEpreuve = true;
                                participations.Create(new Participation
                                {
                                    ParticipantId = competiteur.Id,
                                    EpreuveId = epreuve.Id,
                                    Resultat = new Resultat()
                                    {
                                        Date = DateTime.Now
                                    }
                                });
                            }
                            else if (epreuve.GradeAutorise == competiteur.Grade)
                            {
                                competiteurBoundToEpreuve = true;
                                participations.Create(new Participation
                                {
                                    ParticipantId = competiteur.Id,
                                    EpreuveId = epreuve.Id,
                                    Resultat = new Resultat()
                                    {
                                        Date = DateTime.Now
                                    }
                                });
                            }
                        }
                    }

                    if (competiteurBoundToEpreuve)
                    {
                        epreuve.Statut = StatutEpreuve.Ouverte;
                        epreuvesCombatRepository.Update(epreuve);
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
        public JsonResult VentilationEpreuve(string id)
        {
            int parsed;

            if (int.TryParse(id, out parsed) && parsed > 0)
            {
                var epreuves = this.unitOfWork.Repository<Epreuve>();
                var participants = this.unitOfWork.Repository<Participant>();
                var participations = this.unitOfWork.Repository<Participation>();
                var typesEpreuves = this.unitOfWork.Repository<TypeEpreuve>().Read();

                var epreuve = epreuves.Read().FirstOrDefault(e => e.Id == parsed);

                if (epreuve != null)
                {
                    bool competiteurBoundToEpreuve = false;

                    foreach (var participation in participations.Read().Where(p => p.EpreuveId == parsed))
                    {
                        participations.Delete(participation);
                    }

                    if (epreuve.TypeEpreuve.Technique)
                    {
                        foreach (var participant in participants.Read().OfType<Competiteur>())
                        {
                            Competiteur competiteur = (Competiteur)participant;
                            if (epreuve.CategoriePratiquantId == competiteur.CategoriePratiquantId && (epreuve.GenreCategorie == GenreEpreuve.Mixte || ((int)epreuve.GenreCategorie == (int)competiteur.Sexe)))
                            {
                                if (competiteur.InscritPourQuyen && epreuve.TypeEpreuve.Identifier == TypeEpreuveConstants.BAIQUYEN)
                                {
                                    if (epreuve.GradeAutorise == Grade.TousGrades)
                                    {
                                        competiteurBoundToEpreuve = true;
                                        participations.Create(new Participation
                                        {
                                            ParticipantId = competiteur.Id,
                                            EpreuveId = epreuve.Id,
                                            Resultat = new Resultat()
                                            {
                                                Date = DateTime.Now
                                            }
                                        });
                                    }
                                    else if (epreuve.GradeAutorise == Grade.MoinsDeCeintureNoire && (competiteur.Grade == Grade.CeintureBlancheA4emeCap || competiteur.Grade == Grade.Plus4emeCapACeintureMarron))
                                    {
                                        competiteurBoundToEpreuve = true;
                                        participations.Create(new Participation
                                        {
                                            ParticipantId = competiteur.Id,
                                            EpreuveId = epreuve.Id,
                                            Resultat = new Resultat()
                                            {
                                                Date = DateTime.Now
                                            }
                                        });
                                    }
                                    else if (epreuve.GradeAutorise == competiteur.Grade)
                                    {
                                        competiteurBoundToEpreuve = true;
                                        participations.Create(new Participation
                                        {
                                            ParticipantId = competiteur.Id,
                                            EpreuveId = epreuve.Id,
                                            Resultat = new Resultat()
                                            {
                                                Date = DateTime.Now
                                            }
                                        });
                                    }
                                }


                                if (competiteur.InscritPourBaiVuKhi && epreuve.TypeEpreuve.Identifier == TypeEpreuveConstants.BAIVUKHI)
                                {
                                    if (epreuve.GradeAutorise == Grade.TousGrades)
                                    {
                                        competiteurBoundToEpreuve = true;
                                        participations.Create(new Participation
                                        {
                                            ParticipantId = competiteur.Id,
                                            EpreuveId = epreuve.Id,
                                            Resultat = new Resultat()
                                            {
                                                Date = DateTime.Now
                                            }
                                        });
                                    }
                                    else if (epreuve.GradeAutorise == Grade.MoinsDeCeintureNoire && (competiteur.Grade == Grade.CeintureBlancheA4emeCap || competiteur.Grade == Grade.Plus4emeCapACeintureMarron))
                                    {
                                        competiteurBoundToEpreuve = true;
                                        participations.Create(new Participation
                                        {
                                            ParticipantId = competiteur.Id,
                                            EpreuveId = epreuve.Id,
                                            Resultat = new Resultat()
                                            {
                                                Date = DateTime.Now
                                            }
                                        });
                                    }
                                    else if (epreuve.GradeAutorise == competiteur.Grade)
                                    {
                                        competiteurBoundToEpreuve = true;
                                        participations.Create(new Participation
                                        {
                                            ParticipantId = competiteur.Id,
                                            EpreuveId = epreuve.Id,
                                            Resultat = new Resultat()
                                            {
                                                Date = DateTime.Now
                                            }
                                        });
                                    }
                                }
                            }
                        }

                        if (epreuve.TypeEpreuve.Identifier == TypeEpreuveConstants.QUYENDONGDIEN)
                        {
                            foreach (var equipe in participants.Read().OfType<Equipe>())
                            {
                                var membres = equipe.Competiteurs;
                                var hasBlackBelt = membres.Select(m => m.Grade).Contains(Grade.CeintureNoire);

                                if (membres.First().InscritPourQuyenDongDien && hasBlackBelt && epreuve.GradeAutorise == Grade.CeintureNoire)
                                {
                                    competiteurBoundToEpreuve = true;
                                    participations.Create(new Participation
                                    {
                                        ParticipantId = equipe.Id,
                                        EpreuveId = parsed,
                                        Resultat = new Resultat()
                                        {
                                            Date = DateTime.Now
                                        }
                                    });
                                }
                                else if (membres.First().InscritPourQuyenDongDien && !hasBlackBelt && epreuve.GradeAutorise == Grade.MoinsDeCeintureNoire)
                                {
                                    competiteurBoundToEpreuve = true;
                                    participations.Create(new Participation
                                    {
                                        ParticipantId = equipe.Id,
                                        EpreuveId = parsed,
                                        Resultat = new Resultat()
                                        {
                                            Date = DateTime.Now
                                        }
                                    });
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (var competiteur in participants.Read().Cast<Competiteur>().Where(c => c.InscritPourCombat))
                        {
                            if (epreuve.CategoriePratiquantId == competiteur.CategoriePratiquantId && (epreuve.GenreCategorie == GenreEpreuve.Mixte || ((int)epreuve.GenreCategorie == (int)competiteur.Sexe)) && (competiteur.Poids >= ((EpreuveCombat)epreuve).PoidsMini && competiteur.Poids < ((EpreuveCombat)epreuve).PoidsMaxi))
                            {
                                if (epreuve.GradeAutorise == Grade.TousGrades)
                                {
                                    competiteurBoundToEpreuve = true;
                                    participations.Create(new Participation
                                    {
                                        ParticipantId = competiteur.Id,
                                        EpreuveId = epreuve.Id,
                                        Resultat = new Resultat()
                                        {
                                            Date = DateTime.Now
                                        }
                                    });
                                }
                                else if (epreuve.GradeAutorise == Grade.MoinsDeCeintureNoire && (competiteur.Grade == Grade.CeintureBlancheA4emeCap || competiteur.Grade == Grade.Plus4emeCapACeintureMarron))
                                {
                                    competiteurBoundToEpreuve = true;
                                    participations.Create(new Participation
                                    {
                                        ParticipantId = competiteur.Id,
                                        EpreuveId = epreuve.Id,
                                        Resultat = new Resultat()
                                        {
                                            Date = DateTime.Now
                                        }
                                    });
                                }
                                else if (epreuve.GradeAutorise == competiteur.Grade)
                                {
                                    competiteurBoundToEpreuve = true;
                                    participations.Create(new Participation
                                    {
                                        ParticipantId = competiteur.Id,
                                        EpreuveId = epreuve.Id,
                                        Resultat = new Resultat()
                                        {
                                            Date = DateTime.Now
                                        }
                                    });
                                }
                            }
                        }
                    }

                    if (competiteurBoundToEpreuve)
                    {
                        epreuve.Statut = StatutEpreuve.Ouverte;
                        epreuves.Update(epreuve);
                    }
                    else
                    {
                        epreuve.Statut = StatutEpreuve.Fermee;
                        epreuves.Update(epreuve);
                    }
                    var result = new JsonResult();
                    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    result.Data = new { success = true };
                    return result;
                }
            }

            throw new ArgumentException("id can't be parsed");
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
                            item.Statut = StatutEpreuve.Exclue;
                            this.epreuvestechniquesRepository.Update(item);
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
                            item.Statut = StatutEpreuve.Exclue;
                            this.epreuvesCombatRepository.Update(item);
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

                    merged.GradeAutorise =   mergeGrades(sources);
                    merged.Statut = StatutEpreuve.Ouverte;
                    merged.TypeEpreuveId = sources.First().TypeEpreuveId;

                    var genre = GenreEpreuves.ResourceManager.GetString(merged.GenreCategorie.ToString());
                    var grade = Grades.ResourceManager.GetString(merged.GradeAutorise.ToString());
                    var typeEpreuve = this.typesEpreuvesRepository.Read(sources.First().TypeEpreuveId).Nom;
                    merged.Nom = string.Format("{0} {1} {2} {3}", typeEpreuve, string.Join(" ", categoryNames.ToArray()), genre, grade);
                    if (!techEpreuve)
                    {
                        ((EpreuveCombat)merged).PoidsMaxi = sources.Cast<EpreuveCombat>().Max(e => e.PoidsMaxi);
                        ((EpreuveCombat)merged).PoidsMini = sources.Cast<EpreuveCombat>().Min(e => e.PoidsMini);
                        merged.Nom = BuildEpreuveName(sources.First().CategoriePratiquant.Nom, typeEpreuve, genre, grade, ((EpreuveCombat)merged).PoidsMini, ((EpreuveCombat)merged).PoidsMaxi);

                        //merged.Nom = string.Format("{0} de {1}kgs à {2}kgs", merged.Nom, ((EpreuveCombat)merged).PoidsMini, ((EpreuveCombat)merged).PoidsMaxi);
                    }

                    if (techEpreuve)
                    {
                        this.epreuvestechniquesRepository.Create(merged as EpreuveTechnique);
                    }
                    else
                    {
                        this.epreuvesCombatRepository.Create(merged as EpreuveCombat);
                    }

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

        private Grade mergeGrades(List<Epreuve> sources)
        {
            var orderedGrades = sources.OrderBy(s => s.GradeAutorise).Select( s  => s.GradeAutorise).ToList();
            Grade merged = Grade.NotSet;
            var first = orderedGrades.First();
            var last = orderedGrades.Last();

            if (first == Grade.CeintureBlancheA4emeCap && last == Grade.Plus4emeCapACeintureMarron)
            {
                merged = Grade.MoinsDeCeintureNoire;
            }
            else if (first == Grade.MoinsDeCeintureNoire && last == Grade.CeintureNoire)
            {
                merged = Grade.TousGrades;
            }
            else if(first == Grade.CeintureBlancheA4emeCap && last == Grade.CeintureNoire)
            {
                merged = Grade.TousGrades;
            }
            else
            {
                merged = sources.First().GradeAutorise;
            }
            return merged;
        }

        [HttpPost]
        public ActionResult ExcelSave(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        private static string BuildEpreuveName(string categorie, string typeEpreuve, string genre, string grade, float poidsMini, float poidsMaxi)
        {
            var nom = string.Empty;
            if (poidsMini == 0 && poidsMaxi == 1000)
            {
                nom = string.Format("{0} {1} {2} {3} tous poids confondus", typeEpreuve, categorie, genre, grade, poidsMaxi);
            }
            else if (poidsMini == 0 && poidsMaxi != 1000)
            {
                nom = string.Format("{0} {1} {2} {3} -{4} kgs", typeEpreuve, categorie, genre, grade, poidsMaxi);
            }
            else if (poidsMini != 0 && poidsMaxi == 1000)
            {
                nom = string.Format("{0} {1} {2} {3} +{4} kgs", typeEpreuve, categorie, genre, grade, poidsMini);
            }
            else
            {
                nom = string.Format("{0} {1} {2} {3} de {4}kgs à {5}kgs", typeEpreuve, categorie, genre, grade, poidsMini, poidsMaxi);
            }
            return nom;
        }
    }
}