using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Helper
{
    internal class ExcelConverterHelper
    {
        private const string Masculin = "M";
        private const string Feminin = "F";
        private const string Mixte = "MF";
        private const string Oui = "OUI";

        private const string Cap4CN = "4ème cap à moins de Ceinture Noire";
        private const string Cap1Cap4 = "1er cap à 4ème cap";
        private const string CN = "Ceinture Noire";

        internal static CategoriePratiquant ConvertToCategorie(string input)
        {
            DateTime result = DateTime.FromOADate(double.Parse(input));
            int age = DateTime.Now.Year - result.Year;
            CategoriePratiquant categorie = CategoriePratiquant.NotSet;
            switch (age)
            {
                case 8:
                case 9:
                    categorie = CategoriePratiquant.Pupilles;
                    break;
                case 10:
                case 11:
                    categorie = CategoriePratiquant.Benjamins;
                    break;
                case 12:
                case 13:
                    categorie = CategoriePratiquant.Minimes;
                    break;
                case 15:
                case 14:
                    categorie = CategoriePratiquant.Cadets;
                    break;
                case 16:
                case 17:
                    categorie = CategoriePratiquant.Juniors;
                    break;
                case 18:
                case 35:
                    categorie = CategoriePratiquant.Seniors;
                    break;
                default:
                    categorie = CategoriePratiquant.Veterans;
                    break;
            }
            return categorie;
        }

        internal static Genre ConvertToGenre(string input)
        {
            if (string.Compare(input.ToLowerInvariant(), Masculin.ToLowerInvariant(), StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return Genre.Masculin;
            }
            else if (string.Compare(input.ToLowerInvariant(), Feminin.ToLowerInvariant(), StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return Genre.Feminin;
            }
            else
            {
                return Genre.Mixte;
            }
        }

        internal static Grade ConvertToGrade(string input)
        {
            if (string.Compare(input.ToLowerInvariant(), Cap1Cap4.ToLowerInvariant(), StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return Grade.CeintureBlancheA4emeCap;
            }
            else if (string.Compare(input.ToLowerInvariant(), Cap4CN.ToLowerInvariant(), StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return Grade.Plus4emeCapACeintureMarron;
            }
            else if (string.Compare(input.ToLowerInvariant(), CN.ToLowerInvariant(), StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return Grade.CeintureNoire;
            }
            else
            {
                return Grade.NotSet;
            }
        }

        internal static bool ConvertToBool(string input)
        {
            return string.Compare(input.ToLowerInvariant(),
                                    Oui.ToLowerInvariant(),
                                    StringComparison.InvariantCultureIgnoreCase) == 0;
        }

        internal static TailleTenue ConvertToTaille(string input)
        {
            switch (input.ToLowerInvariant())
            {
                case "s":
                    return TailleTenue.S;

                case "m":
                    return TailleTenue.M;

                case "l":
                    return TailleTenue.L;

                case "xl":
                    return TailleTenue.XL;

                default:
                    return TailleTenue.XXL;
            }
        }

        internal static int ConvertToInt(string input)
        {
            if (input == string.Empty)
            {
                return 0;
            }
            else
            {
                return int.Parse(input);
            }
        }
    }
}