namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Helper
{
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public static class ModelToDataTransferObject
    {
        public static Competiteur ToDTO(this CompetiteurModel model)
        {
            Competiteur result = new Competiteur();
            if (model.Id != 0)
            {
                result.Id = model.Id;
            }

            result.CategoriePratiquantId = model.CategorieId; 
            result.ClubId = model.ClubId;
            result.DateNaissance = model.DateNaissance;
            result.NumeroEquipe = model.NumeroEquipe;
            result.Grade = (Grade)model.GradeId;
            result.InscriptionValidePourCoupe = model.InscriptionValidePourCoupe;
            result.InscritPourBaiVuKhi = model.InscritPourBaiVuKhi;
            result.InscritPourCombat = model.InscritPourCombat;
            result.InscritPourQuyen = model.InscritPourQuyen;
            result.InscritPourSongLuyen = model.InscritPourSongLuyen;
            result.InscritPourQuyenDongDien = model.InscritPourQuyenDongDien;
            result.LicenceFFKDA = model.LicenceFFKDA;
            result.NbAnneePratique = model.NbAnneePratique;
            result.Nom = model.Nom;
            result.Poids = model.Poids;
            result.Prenom = model.Prenom;
            result.Sexe = (Genre)model.GenreId;

            return result;
        }

        public static ResponsableClub ToDTO(this ResponsableClubModel model)
        {
            ResponsableClub result = new ResponsableClub();
            if (model.Id != 0)
            {
                result.Id = model.Id;
            }

            result.ClubId = model.ClubId;            
            result.Nom = model.Nom;            
            result.Prenom = model.Prenom;
            result.Adresse = model.Adresse;
            result.MailContact = model.MailContact;
            result.Telephone = model.Telephone;

            return result;
        }

        public static Encadrant ToDTO(this EncadrantModel model)
        {
            Encadrant result = new Encadrant();
            if (model.Id != 0)
            {
                result.Id = model.Id;
            }
            
            result.ClubId = model.ClubId;
            result.Nom = model.Nom;
            result.Prenom = model.Prenom;
            result.EstCompetiteur = model.EstCompetiteur;
            result.MailContact = model.MailContact;
            result.Sexe = (Genre)model.GenreId;
            result.TailleTenue =(TailleTenue)model.TailleTenueId;
            result.Disponibilites = ((model.DispoAdministrateur != null) ? model.DispoAdministrateur.Select(d => d.ToDTO()).ToList() : new List<Disponibilite>()).Union((model.DispoArbitre != null) ? model.DispoArbitre.Select(d => d.ToDTO()).ToList() : new List<Disponibilite>()).ToList();
            return result;
        }

        public static Disponibilite ToDTO (this DisponibiliteModel model, Role role = Role.Administrateur)
        {
            Disponibilite result = new Disponibilite();
            if (model.Id != 0)
            {
                result.Id = model.Id;
            }

            result.EncadrantId = model.EncadrantId;
            result.Date = model.Date;            
            result.Matin = model.Matin;
            if (model.Role != null)
            {
                result.Role = new EnumConverter<Role>().ConvertToEnum(model.Role);
            }
            else
            {
                result.Role = role;
            }
            return result;
        }

        public static CategoriePratiquant ToDTO (this CategoriePratiquantModel model)
        {
            CategoriePratiquant result = new CategoriePratiquant();
            if (model.Id != 0)
            {
                result.Id = model.Id;
            }
            result.Nom = model.Nom;
            result.AgeMin = model.AgeMin;
            result.AgeMax = model.AgeMax;
            
            return result;
        }

        public static Participation ToDTO(this ParticipationModel model)
        {
            Participation participation = new Participation();
            if (model.Id != 0)
            {
                participation.Id = model.Id;
            }

            participation.EpreuveId = model.EpreuveId;
            participation.ParticipantId = model.ParticipantId;           
            return participation;
        }
    }    
}