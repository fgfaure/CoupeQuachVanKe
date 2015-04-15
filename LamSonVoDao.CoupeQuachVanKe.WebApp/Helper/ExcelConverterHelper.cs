namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Helper
{
    using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;

    internal class ExcelConverterHelper
    {
        private const string Masculin = "M";
        private const string Feminin = "F";
        private const string Mixte = "MF";
        private const string Oui = "OUI";

        private const string Cap4CN = "4ème cap à moins de Ceinture Noire";
        private const string Cap1Cap4 = "1er cap à 4ème cap";
        private const string CN = "Ceinture Noire";

        private static Repository<CategoriePratiquant> categories = new UnitOfWork().Repository<CategoriePratiquant>();

        internal static int ConvertToCategorie(string input)
        {
            DateTime result = DateTime.FromOADate(double.Parse(input));
            int age = DateTime.Now.Year - result.Year;

            int categorieid = 0;

            foreach (var cat in categories.Read())
            {
                if (age >= cat.AgeMin && age <= cat.AgeMax)
                {
                    categorieid = cat.Id;
                    break;
                }
            }     
            return categorieid;
        }

        internal static Genre ConvertToGenre(string input)
        {
            if (string.Compare(input.ToLowerInvariant(), Masculin.ToLowerInvariant(), StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return Genre.Masculin;
            }
            else
            {
                return Genre.Feminin;
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
                return Grade.NonRenseigne;
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

        internal static Competiteur ConvertFromXLS(DataRow row)
        {
            var result = new Competiteur();
            result.ValidImport = true;
            try
            {
                result.Nom = row.ItemArray[0].ToString();
                result.Prenom = row.ItemArray[1].ToString();
                result.LicenceFFKDA = row.ItemArray[6].ToString();
            }
            catch (Exception)
            {
                result.ValidImport = false;
            }
            try
            {
                result.DateNaissance = DateTime.FromOADate(double.Parse(row.ItemArray[2].ToString()));
            }
            catch (Exception)
            {
                result.ValidImport = false;
            }
            try
            {
                result.Sexe = ExcelConverterHelper.ConvertToGenre(row.ItemArray[3].ToString());
            }
            catch (Exception ex)
            {
                result.ValidImport = false;
            }
            try
            {
                result.NbAnneePratique = ExcelConverterHelper.ConvertToInt(row.ItemArray[4].ToString());
                result.EquipeSongLuyenNumero = ExcelConverterHelper.ConvertToInt(row.ItemArray[11].ToString());
                result.Poids = ExcelConverterHelper.ConvertToInt(row.ItemArray[13].ToString());
            }
            catch (Exception)
            {
                result.ValidImport = false;
            }
            try
            {
                result.Grade = ExcelConverterHelper.ConvertToGrade(row.ItemArray[5].ToString());
                if (result.Grade == Grade.NonRenseigne || result.Grade == Grade.NotSet)
                {
                    result.ValidImport = false;
                }
            }
            catch (Exception ex)
            {
                result.ValidImport = false;
            }
            try
            {
                result.InscritPourQuyen = ExcelConverterHelper.ConvertToBool(row.ItemArray[7].ToString());
                result.InscritPourBaiVuKhi = ExcelConverterHelper.ConvertToBool(row.ItemArray[8].ToString());
                result.InscritPourSongLuyen = ExcelConverterHelper.ConvertToBool(row.ItemArray[9].ToString());
                result.InscritPourCombat = ExcelConverterHelper.ConvertToBool(row.ItemArray[12].ToString());

            }
            catch (Exception)
            {
                result.ValidImport = false;
            }
            try
            {
                result.CategoriePratiquantId = ExcelConverterHelper.ConvertToCategorie(row.ItemArray[2].ToString());
                if (result.CategoriePratiquantId == 0)
                {
                    result.ValidImport = false;
                }
            }
            catch (Exception)
            {
                result.ValidImport = false;
            }
            return result;
        }
    }
}