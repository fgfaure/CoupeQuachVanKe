/// <summary>
/// 
/// </summary>
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

    /// <summary>
    /// 
    /// </summary>
    internal class ExcelConverterHelper
    {
        /// <summary>
        /// The masculin
        /// </summary>
        private const string Masculin = "M";
        /// <summary>
        /// The feminin
        /// </summary>
        private const string Feminin = "F";
        /// <summary>
        /// The mixte
        /// </summary>
        private const string Mixte = "MF";
        /// <summary>
        /// The oui
        /// </summary>
        private const string Oui = "OUI";

        /// <summary>
        /// The cap4 cn
        /// </summary>
        private const string Cap4CN = "4ème cap à moins de Ceinture Noire";
        /// <summary>
        /// The cap1 cap4
        /// </summary>
        private const string Cap1Cap4 = "1er cap à 4ème cap";
        /// <summary>
        /// From cap1 to cap4
        /// </summary>
        private const string FromCap1ToCap4 = "de 1er à 4ème cap";
        /// <summary>
        /// The cn
        /// </summary>
        private const string CN = "Ceinture Noire";

        /// <summary>
        /// The categories
        /// </summary>
        private static Repository<CategoriePratiquant> categories = new UnitOfWork().Repository<CategoriePratiquant>();

        /// <summary>
        /// Converts to categorie.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        internal static int ConvertToCategorie(DateTime birthday)
        {
            var coupes = new UnitOfWork().Repository<Coupe>().Read();
            var coupe = coupes.OrderByDescending(c => c.DateFin).FirstOrDefault();
            var year = coupe != null ? coupe.DateFin.Year : DateTime.Now.Year;

            if(coupe.DateFin.Month < 8)
            {
                --year;
            }

            //DateTime birthday = DateTime.FromOADate(double.Parse(input));

            int age = year - birthday.Year;
            var cats = categories.Read();
            int categorieid = cats.FirstOrDefault(cat => cat.AgeMin == 0 && cat.AgeMax == 0).Id;

            foreach (var cat in cats.Where(cat => cat.AgeMax !=0 && cat.AgeMin != 0))
            {
                if (age >= cat.AgeMin && age <= cat.AgeMax)
                {
                    categorieid = cat.Id;
                    break;
                }
            }     
            return categorieid;
        }

        /// <summary>
        /// Converts to genre.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Converts to grade.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        internal static Grade ConvertToGrade(string input)
        {
            if (string.Compare(input.ToLowerInvariant(), Cap1Cap4.ToLowerInvariant(), StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return Grade.CeintureBlancheA4emeCap;
            }
            else if (string.Compare(input.ToLowerInvariant(), FromCap1ToCap4.ToLowerInvariant(), StringComparison.InvariantCultureIgnoreCase) == 0)
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

        /// <summary>
        /// Converts to bool.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        internal static bool ConvertToBool(string input)
        {
            return string.Compare(input.ToLowerInvariant(),
                                    Oui.ToLowerInvariant(),
                                    StringComparison.InvariantCultureIgnoreCase) == 0;
        }

        /// <summary>
        /// Converts to taille.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Converts to int.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        internal static int ConvertToInt(string input)
        {
            if (input == string.Empty)
            {
                return 0;
            }
            else
            {
                int parsed;
                if (int.TryParse(input, out parsed))
                {
                    return parsed;
                }
                return 0;
            }
        }

        /// <summary>
        /// Converts from XLS.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns></returns>
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
                double converted = 0D;
                string column = row.ItemArray[2].ToString();
                if (double.TryParse(column, out converted)){
                    result.DateNaissance = DateTime.FromOADate(double.Parse(column));
                }
                else
                {
                    result.DateNaissance = DateTime.Parse(column);
                }
                
            }
            catch (Exception)
            {
                result.ValidImport = false;
                result.DateNaissance = DateTime.Now;
            }
            try
            {
                result.Sexe = ExcelConverterHelper.ConvertToGenre(row.ItemArray[3].ToString());
            }
            catch (Exception)
            {
                result.ValidImport = false;
            }
            try
            {
                result.NbAnneePratique = ExcelConverterHelper.ConvertToInt(row.ItemArray[4].ToString());
                result.NumeroEquipe = ExcelConverterHelper.ConvertToInt(row.ItemArray[10].ToString());
                result.Poids = ExcelConverterHelper.ConvertToInt(row.ItemArray[12].ToString());
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
            catch (Exception)
            {
                result.ValidImport = false;
            }
            try
            {
                result.InscritPourQuyen = ExcelConverterHelper.ConvertToBool(row.ItemArray[7].ToString());
                result.InscritPourBaiVuKhi = ExcelConverterHelper.ConvertToBool(row.ItemArray[8].ToString());
                result.InscritPourSongLuyen = false;
                result.InscritPourQuyenDongDien= ExcelConverterHelper.ConvertToBool(row.ItemArray[9].ToString());
                result.InscritPourCombat = ExcelConverterHelper.ConvertToBool(row.ItemArray[11].ToString());

            }
            catch (Exception)
            {
                result.ValidImport = false;
            }
            try
            {
                //result.CategoriePratiquantId = ExcelConverterHelper.ConvertToCategorie(row.ItemArray[2].ToString());
                result.CategoriePratiquantId = ExcelConverterHelper.ConvertToCategorie(result.DateNaissance);
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