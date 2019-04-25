
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
using System.Collections.Generic;
using System.Linq;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Helper
{
    public static class DataTransferObjectToModel
    {
        public static CategoriePratiquantModel ToModel(this CategoriePratiquant dto)
        {
            return new CategoriePratiquantModel()
            {
                Id = dto.Id,
                AgeMin = dto.AgeMin,
                AgeMax = dto.AgeMax,
                Duree = dto.Duree,
                Nom = dto.Nom
            };
        }

        public static ClubModel ToModel(this Club dto)
        {
            ClubModel result = new ClubModel();
            result.Id = dto.Id;
            result.Nom = dto.Nom;
            result.NumeroAffiliation = dto.NumeroAffiliation;
            return result;
        }

        public static CoupeModel ToModel(this Coupe dto)
        {
            CoupeModel result = new CoupeModel();
            result.Id = dto.Id;
            result.Nom = dto.Nom;
            result.CodePostal = dto.CodePostal;
            result.Complement = dto.Complement;
            result.DateDebut = dto.DateDebut;
            result.DateFin = dto.DateFin;
            result.Description = dto.Description;
            result.Numero = (int)dto.Numero;
            result.Ville = dto.Ville;
            result.Voie = dto.Voie;
            return result;
        }

        public static CompetiteurModel ToModel(this Competiteur dto)
        {
            CompetiteurModel result = new CompetiteurModel();
            result.Id = dto.Id;
            result.CategorieId = dto.CategoriePratiquantId;
            result.ClubId = dto.ClubId;
            result.DateNaissance = dto.DateNaissance;
            result.NumeroEquipe = dto.NumeroEquipe;
            result.GradeId = (int)dto.Grade;
            result.InscriptionValidePourCoupe = dto.InscriptionValidePourCoupe;
            result.InscritPourBaiVuKhi = dto.InscritPourBaiVuKhi;
            result.InscritPourCombat = dto.InscritPourCombat;
            result.InscritPourQuyen = dto.InscritPourQuyen;
            result.InscritPourSongLuyen = dto.InscritPourSongLuyen;
            result.InscritPourQuyenDongDien = dto.InscritPourQuyenDongDien;
            result.LicenceFFKDA = dto.LicenceFFKDA;
            result.NbAnneePratique = dto.NbAnneePratique;
            result.Nom = dto.Nom;
            result.Poids = dto.Poids;
            result.Prenom = dto.Prenom;
            result.GenreId = (int)dto.Sexe;
            result.ValidImport = dto.ValidImport;
            return result;
        }

        public static ParticipationModel ToModel(this Participation dto)
        {
            ParticipationModel result = new ParticipationModel();
            result.Id = dto.Id;
            result.EpreuveId = dto.EpreuveId;
            result.ParticipantId = dto.ParticipantId;
            result.Prenom = dto.Participant.Prenom;
            result.Nom = dto.Participant.Nom;
            return result;
        }

        public static ParticipantModel ToModel(this Participant dto)
        {
            ParticipantModel result = new ParticipantModel();
            result.Id = dto.Id;
            result.ClubId = dto.ClubId;
            result.Nom = dto.Nom;
            result.Prenom = dto.Prenom;
            return result;
        }

        public static ResponsableClubModel ToModel(this ResponsableClub dto)
        {
            ResponsableClubModel result = new ResponsableClubModel();
            result.Id = dto.Id;
            result.ClubId = dto.ClubId;
            result.Nom = dto.Nom;
            result.Prenom = dto.Prenom;
            result.Adresse = dto.Adresse;
            result.MailContact = dto.MailContact;
            result.Telephone = dto.Telephone;

            return result;
        }

        public static EncadrantModel ToModel(this Encadrant dto)
        {
            EncadrantModel result = new EncadrantModel();
            result.Id = dto.Id;
            result.ClubId = dto.ClubId;
            result.Nom = dto.Nom;
            result.Prenom = dto.Prenom;
            result.EstCompetiteur = (bool)dto.EstCompetiteur;
            result.MailContact = dto.MailContact;
            result.GenreId = (int)dto.Sexe;
            result.TailleTenueId = (int)dto.TailleTenue;
            result.DispoArbitre = (dto.Disponibilites != null ? dto.Disponibilites.Where(d => d.Role == Role.Arbitre).Select(d => d.ToModel()) : new List<DisponibiliteModel>());
            result.DispoAdministrateur = (dto.Disponibilites != null ? dto.Disponibilites.Where(d => d.Role == Role.Administrateur).Select(d => d.ToModel()) : new List<DisponibiliteModel>());
            return result;
        }

        public static DisponibiliteModel ToModel(this Disponibilite dto)
        {
            DisponibiliteModel result = new DisponibiliteModel();
            result.Id = dto.Id;
            result.EncadrantId = dto.EncadrantId;
            result.Date = dto.Date;
            result.Matin = dto.Matin;
            result.Role = dto.Role.ToString();
            return result;
        }

        public static ResponsableCoupeModel ToModel(this ResponsableCoupe dto)
        {
            ResponsableCoupeModel result = new ResponsableCoupeModel();
            result.Id = dto.Id;
            result.Adresse = dto.Adresse;
            result.MailContact = dto.MailContact;
            result.CoupeId = dto.CoupeId;
            result.Nom = dto.Nom;
            result.Prenom = dto.Prenom;
            result.Telephone = dto.Telephone;

            return result;
        }

        public static AireModel ToModel(this Aire dto)
        {
            AireModel result = new AireModel();
            result.Id = dto.Id;
            result.CoupeId = dto.CoupeId;
            result.Description = dto.Description;
            result.NetClientId = dto.NetClientId;
            if (dto.Epreuves != null && dto.Epreuves.Count() > 0)
            {
                result.EpreuveId = dto.Epreuves.FirstOrDefault().Id.ToString();
            }
            else
            {
                result.EpreuveId = string.Empty;
            }

            return result;
        }

        public static MedecinModel ToModel(this Medecin dto)
        {
            MedecinModel result = new MedecinModel();
            result.Id = dto.Id;
            result.CoupeId = dto.CoupeId;
            result.Nom = dto.Nom;
            result.Prenom = dto.Prenom;
            result.Telephone = dto.Telephone;
            result.MailContact = dto.MailContact;

            return result;
        }

        public static EpreuveTechniqueModel ToModel(this EpreuveTechnique dto)
        {
            EpreuveTechniqueModel result = new EpreuveTechniqueModel();
            result.Id = dto.Id;
            result.Nom = dto.Nom;
            result.CategorieId = dto.CategoriePratiquantId;
            result.GenreCategorieId = (int)dto.GenreCategorie;
            result.GradeAutoriseId = (int)dto.GradeAutorise;
            result.StatutId = (int)dto.Statut;
            result.TypeEpreuveId = dto.TypeEpreuveId;
            result.IsMerged = dto.IsMerged;
            return result;
        }

        public static EpreuveModel ToModel(this Epreuve dto)
        {
            EpreuveModel result = new EpreuveModel();
            result.EpreuveId = dto.Id;
            result.Epreuve = dto.Nom;
            return result;
        }

        public static EpreuveCombatModel ToModel(this EpreuveCombat dto)
        {
            EpreuveCombatModel result = new EpreuveCombatModel();
            result.Id = dto.Id;
            result.Nom = dto.Nom;
            result.CategorieId = dto.CategoriePratiquantId;
            result.GenreCategorieId = (int)dto.GenreCategorie;
            result.GradeAutoriseId = (int)dto.GradeAutorise;
            result.StatutId = (int)dto.Statut;
            result.TypeEpreuveId = dto.TypeEpreuveId;
            result.PoidsMini = dto.PoidsMini;
            result.PoidsMaxi = dto.PoidsMaxi;
            result.IsMerged = dto.IsMerged;
            return result;
        }

        public static TypeEpreuveModel ToModel(this TypeEpreuve dto)
        {
            TypeEpreuveModel result = new TypeEpreuveModel();
            result.Id = dto.Id;
            result.Description = dto.Description;
            result.Nom = dto.Nom;
            result.Technique = dto.Technique;

            return result;
        }

        public static NetClientModel ToModel(this NetClient dto)
        {
            NetClientModel result = new NetClientModel();
            result.Id = dto.Id;
            result.ClientName = dto.ClientLogInName;
            result.IsConnected = dto.IsConnected;
            result.Password = dto.Password;
            result.NetClientTypeId = dto.NetClientTypeId;
            return result;
        }

        public static ParticipationModel ToPresentielModel(this Competiteur dto, int epreuveId, bool present)
        {
            ParticipationModel result = new ParticipationModel();
            result.ParticipantId = dto.Id;
            result.CategoriePratiquantId = dto.CategoriePratiquantId;
            result.Nom = dto.Nom;
            result.Prenom = dto.Prenom;
            result.Present = present;
            result.EpreuveId = epreuveId;
            result.ClubId = dto.ClubId;
            if (dto.Club != null)
            {
                result.Club = dto.Club.Nom;
            }

            return result;
        }
    }
}