namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using Excel;
    using LamSonVodao.CoupeQuachVanKe.AccesPattern;
    using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;

    public class ClubController : BaseController<Club>, ICrudController<Club, ClubModel>
    {
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.GetAll().Select(club => new ClubModel
            {
                Id = club.Id,
                Nom = club.Nom,
                NumeroAffiliation = club.NumeroAffiliation
            });
            return result;
        }

      

        // POST: Club/Create
       // [HttpPost]
        public JsonResult Create(ClubModel club)
        {
            try
            {
                var dbitem = new Club
                {
                    Nom = club.Nom,
                    NumeroAffiliation = club.NumeroAffiliation,
                    Encadrants = new List<Encadrant>(),
                    Competiteurs = new List<Competiteur>(),
                };

                this.repository.Insert(dbitem);
                return Json(club);

            }
            catch
            {
                throw;
            }
        }
       // [HttpPost]
        public JsonResult Update(ClubModel model)
        {
            try
            {
                var dbmodel = this.repository.Get(m => m.Id == model.Id).First();
                dbmodel.NumeroAffiliation = model.NumeroAffiliation;
                dbmodel.Nom = model.Nom;

                this.repository.Update(dbmodel);
                return Json(model);
            }
            catch
            {
                throw;
            }
        }

        //[HttpPost]
        public JsonResult Delete(ClubModel model)
        {
            try
            {
                var dbItem = this.repository.GetById(model.Id);
                this.repository.Delete(dbItem);
                return Json(new { success = true });
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Save(IEnumerable<HttpPostedFileBase> files)
        {
            // The Name of the Upload component is "files"
            if (files != null)
            {
                foreach (var file in files)
                {
                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data/Imports"), fileName);

                    // The files are not actually saved in this demo
                    file.SaveAs(physicalPath);                    

                    IExcelDataReader excelReader = null;

                    try
                    {

                        using (FileStream stream = System.IO.File.Open(physicalPath, FileMode.Open, FileAccess.Read))
                        {                            
                            excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                            DataSet result = excelReader.AsDataSet();

                            if (result.Tables != null && result.Tables.Count == 3)
                            {
                                var sheetEncadrants = result.Tables[2];
                                var sheetCompetiteurs = result.Tables[1];


                                if (sheetCompetiteurs.Rows.Count > 2)
                                {
                                    var thirdRow = sheetCompetiteurs.Rows[2];
                                    Club clubFromXLS = new Club
                                    {
                                        Nom = thirdRow.ItemArray[14].ToString(),
                                        NumeroAffiliation = thirdRow.ItemArray[15].ToString()
                                    };
                                    ResponsableClub responsableFromXLS = new ResponsableClub
                                    {
                                        Nom = thirdRow.ItemArray[16].ToString(),
                                        Prenom = thirdRow.ItemArray[17].ToString(),
                                        Adresse = thirdRow.ItemArray[18].ToString(),
                                        Telephone = thirdRow.ItemArray[19].ToString(),
                                        EmailContact = thirdRow.ItemArray[20].ToString()
                                    };

                                    List<Competiteur> competiteursFromXLS = new List<Competiteur>();

                                    for (int i = 2; i < sheetCompetiteurs.Rows.Count; i++)
                                    {
                                        var localRow = sheetCompetiteurs.Rows[i];
                                        if (localRow.ItemArray[0].ToString() == string.Empty)
                                        {
                                            break;
                                        }

                                        competiteursFromXLS.Add(new Competiteur
                                        {
                                            Nom = localRow.ItemArray[0].ToString(),
                                            Prenom = localRow.ItemArray[1].ToString(),
                                            DateNaissance = DateTime.FromOADate(double.Parse(localRow.ItemArray[2].ToString())),
                                            Sexe = ExcelConverterHelper.ConvertToGenre(localRow.ItemArray[3].ToString()),
                                            NbAnneePratique = ExcelConverterHelper.ConvertToInt(localRow.ItemArray[4].ToString()),
                                            Grade = ExcelConverterHelper.ConvertToGrade(localRow.ItemArray[5].ToString()),
                                            LicenceFFKDA = localRow.ItemArray[6].ToString(),
                                            InscritPourQuyen = ExcelConverterHelper.ConvertToBool(localRow.ItemArray[7].ToString()),
                                            InscritPourBaiVuKhi = ExcelConverterHelper.ConvertToBool(localRow.ItemArray[8].ToString()),
                                            InscritPourSongLuyen = ExcelConverterHelper.ConvertToBool(localRow.ItemArray[9].ToString()),
                                            EquipeSongLuyen = ExcelConverterHelper.ConvertToInt(localRow.ItemArray[11].ToString()),
                                            InscritPourCombat = ExcelConverterHelper.ConvertToBool(localRow.ItemArray[12].ToString()),
                                            Poids = ExcelConverterHelper.ConvertToInt(localRow.ItemArray[13].ToString()),
                                            Categorie = ExcelConverterHelper.ConvertToCategorie(localRow.ItemArray[2].ToString())
                                        });
                                    }

                                    List<Encadrant> encadrantsFromXLS = new List<Encadrant>();
                                    for (int i = 2; i < sheetEncadrants.Rows.Count; i++)
                                    {
                                        var localRow = sheetEncadrants.Rows[i];
                                        if (localRow.ItemArray[0].ToString() == string.Empty)
                                        {
                                            break;
                                        }

                                        List<Disponibilite> dispo = new List<Disponibilite>();
                                        //colonnes 8 à 13
                                        if (ExcelConverterHelper.ConvertToBool(localRow.ItemArray[8].ToString()))
                                        {
                                            dispo.Add(new Disponibilite
                                            {
                                                Date = new DateTime(2015, 5, 16),
                                                Matin = false,
                                                Role = Role.Arbitre
                                            });
                                        }
                                        if (ExcelConverterHelper.ConvertToBool(localRow.ItemArray[9].ToString()))
                                        {
                                            dispo.Add(new Disponibilite
                                            {
                                                Date = new DateTime(2015, 5, 17),
                                                Matin = true,
                                                Role = Role.Arbitre
                                            });
                                        }
                                        if (ExcelConverterHelper.ConvertToBool(localRow.ItemArray[10].ToString()))
                                        {
                                            dispo.Add(new Disponibilite
                                            {
                                                Date = new DateTime(2015, 5, 17),
                                                Matin = false,
                                                Role = Role.Arbitre
                                            });
                                        }
                                        if (ExcelConverterHelper.ConvertToBool(localRow.ItemArray[11].ToString()))
                                        {
                                            dispo.Add(new Disponibilite
                                            {
                                                Date = new DateTime(2015, 5, 16),
                                                Matin = false,
                                                Role = Role.Administrateur
                                            });
                                        }
                                        if (ExcelConverterHelper.ConvertToBool(localRow.ItemArray[12].ToString()))
                                        {
                                            dispo.Add(new Disponibilite
                                            {
                                                Date = new DateTime(2015, 5, 17),
                                                Matin = true,
                                                Role = Role.Administrateur
                                            });
                                        }
                                        if (ExcelConverterHelper.ConvertToBool(localRow.ItemArray[13].ToString()))
                                        {
                                            dispo.Add(new Disponibilite
                                            {
                                                Date = new DateTime(2015, 5, 17),
                                                Matin = false,
                                                Role = Role.Administrateur
                                            });
                                        }

                                        encadrantsFromXLS.Add(new Encadrant
                                        {
                                            Nom = localRow.ItemArray[4].ToString(),
                                            Prenom = localRow.ItemArray[5].ToString(),
                                            MailContact = localRow.ItemArray[6].ToString(),
                                            EstCompetiteur = ExcelConverterHelper.ConvertToBool(localRow.ItemArray[7].ToString()),
                                            TailleTenue = ExcelConverterHelper.ConvertToTaille(localRow.ItemArray[14].ToString()),
                                            Sexe = ExcelConverterHelper.ConvertToGenre(localRow.ItemArray[15].ToString()),
                                            Disponibilites = dispo
                                        });
                                    }

                                    clubFromXLS.Responsable = responsableFromXLS;
                                    clubFromXLS.Competiteurs = competiteursFromXLS;
                                    clubFromXLS.Encadrants = encadrantsFromXLS;

                                    var clubFromDb = this.repository.Get(club => string.Compare(club.NumeroAffiliation, clubFromXLS.NumeroAffiliation) == 0).FirstOrDefault();
                                    if (clubFromDb == null)
                                    {
                                        //ajout
                                        this.repository.Insert(clubFromXLS);
                                    }
                                    else
                                    {
                                        //mise à jour
                                        clubFromDb = clubFromXLS;
                                        this.repository.Update(clubFromDb);
                                    }

                                    excelReader.Close();

                                    string clubDirectory = Path.Combine(Server.MapPath("~/App_Data/Imports"), clubFromXLS.Nom);
                                    if (!Directory.Exists(clubDirectory))
                                    {
                                        Directory.CreateDirectory(clubDirectory);
                                    }

                                    System.IO.File.Move(physicalPath, Path.Combine(clubDirectory, fileName));
                                    // Return an empty string to signify success                                
                                }
                            } 
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
            return Json(string.Empty);
        }
    }
}
