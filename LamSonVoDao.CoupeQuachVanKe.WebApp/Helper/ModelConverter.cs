using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Helper
{
    public static class ModelConverter
    {
        public static ParticipationTechniqueModel ConvertToTechnique(this ParticipationModel input) 
        {
            var result = new ParticipationTechniqueModel();
            result.ParticipantId = input.ParticipantId;
            result.ClubId = input.ClubId;
            result.Club = input.Club;
            result.EpreuveId = input.EpreuveId;
            result.Nom = input.Nom;
            result.Prenom = input.Prenom;

            return result;
        }

        public static ParticipationCombatModel ConvertToCombat(this ParticipationModel input)
        {
            var result = new ParticipationCombatModel();
            result.ParticipantId = input.ParticipantId;
            result.ClubId = input.ClubId;
            result.Club = input.Club;
            result.EpreuveId = input.EpreuveId;
            result.Nom = input.Nom;
            result.Prenom = input.Prenom;
            result.Id = input.Id;
            result.Vainqueur = null;          
            return result;
        }
    }
}