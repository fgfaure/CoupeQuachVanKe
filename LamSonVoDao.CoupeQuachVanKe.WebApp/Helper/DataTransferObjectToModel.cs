using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Helper
{
    public static class DataTransferObjectToModel
    {
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
            result.NombreTapis = dto.NombreTapis;
            result.Numero = dto.Numero;
            result.Ville = dto.Ville;
            result.Voie = dto.Voie;            
            return result;
        }

        public static CompetiteurModel ToModel(this Competiteur dto)
        {
            CompetiteurModel result = new CompetiteurModel();
            result.Id = dto.Id;
            result.CategorieId = (int)dto.Categorie;
            result.ClubId = dto.ClubId;
            result.DateNaissance = dto.DateNaissance;
            result.EquipeSongLuyen = dto.EquipeSongLuyen;
            result.GradeId = (int)dto.Grade;
            result.InscriptionValidePourCoupe = dto.InscriptionValidePourCoupe;
            result.InscritPourBaiVuKhi = dto.InscritPourBaiVuKhi;
            result.InscritPourCombat = dto.InscritPourCombat;
            result.InscritPourQuyen = dto.InscritPourQuyen;
            result.InscritPourSongLuyen = dto.InscritPourSongLuyen;
            result.LicenceFFKDA = dto.LicenceFFKDA;
            result.NbAnneePratique = dto.NbAnneePratique;
            result.Nom = dto.Nom;
            result.Poids = dto.Poids;
            result.Prenom = dto.Prenom;
            result.GenreId = (int)dto.Sexe;

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
            result.EstCompetiteur = dto.EstCompetiteur;
            result.MailContact = dto.MailContact;
            result.GenreId = (int)dto.Sexe;
            result.TailleTenueId = (int)dto.TailleTenue;
            result.Disponibilites = (dto.Disponibilites != null ? dto.Disponibilites.Select(d => d.ToModel()) : new List<DisponibiliteModel>());
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
            result.CategorieId = (int)dto.CategoriePratiquant;
            result.GenreCategorieId = (int)dto.GenreCategorie;
            result.GradeAutoriseId = (int)dto.GradeAutorise;
            result.StatutId = (int)dto.Statut;
            result.TypeEpreuveId = dto.TypeEpreuveId;

            return result;
        }

        public static EpreuveCombatModel ToModel(this EpreuveCombat dto)
        {
            EpreuveCombatModel result = new EpreuveCombatModel();
            result.Id = dto.Id;
            result.CategorieId = (int)dto.CategoriePratiquant;            
            result.GenreCategorieId = (int)dto.GenreCategorie;
            result.GradeAutoriseId = (int)dto.GradeAutorise;
            result.StatutId = (int)dto.Statut;
            result.TypeEpreuveId = dto.TypeEpreuve.Id;
            result.PoidsMini = dto.PoidsMini;
            result.PoidsMaxi = dto.PoidsMaxi;

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

    }
}