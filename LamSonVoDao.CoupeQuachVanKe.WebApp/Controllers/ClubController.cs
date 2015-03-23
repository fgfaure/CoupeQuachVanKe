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

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class ClubController : Controller
    {

        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<Club> clubRepo;


        public ClubController()
        {
            this.clubRepo = this.unitOfWork.Repository<Club>();
        }

        public JsonResult GetClubs()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.clubRepo.GetAll().Select(club => new ClubModel
            {
                Id = club.Id,
                Nom = club.Nom,
                NumeroAffiliation = club.NumeroAffiliation
            });
            return result;
        }

        // GET: Club
        public ActionResult Index()
        {
            return View();
        }


        // POST: Club/Create
        [HttpPost]
        public ActionResult Create(ClubModel club)
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

                this.clubRepo.Insert(dbitem);
                return Json(club);

            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(ClubModel model)
        {
            try
            {
                var dbmodel = this.clubRepo.Get(m => m.Id == model.Id).First();
                dbmodel.NumeroAffiliation = model.NumeroAffiliation;
                dbmodel.Nom = model.Nom;

                this.clubRepo.Update(dbmodel);
                return Json(model);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(ClubModel model)
        {
            try
            {
                var dbItem = this.clubRepo.GetById(model.Id);
                this.clubRepo.Delete(dbItem);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Save(IEnumerable<HttpPostedFileBase> files)
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
                        FileStream stream = System.IO.File.Open(physicalPath, FileMode.Open, FileAccess.Read);
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


                            

                                var clubFromDb = this.clubRepo.Get(club => string.Compare(club.NumeroAffiliation, clubFromXLS.NumeroAffiliation) == 0).FirstOrDefault();
                                if (clubFromDb == null)
                                {
                                    //ajout
                                    this.clubRepo.Insert(clubFromXLS);
                                    clubFromDb = this.clubRepo.Get(club => string.Compare(club.NumeroAffiliation, clubFromXLS.NumeroAffiliation) == 0).FirstOrDefault();
                                    responsableFromXLS.ClubId = clubFromDb.Id;
                                    for (int i = 0; i < competiteursFromXLS.Count; i++)
                                    {
                                        competiteursFromXLS[i].ClubId = clubFromDb.Id;
                                    }
                                    for (int i = 0; i < encadrantsFromXLS.Count; i++)
                                    {
                                        encadrantsFromXLS[i].ClubId = clubFromDb.Id;

                                    }
                                    clubFromDb.Responsable = responsableFromXLS;
                                    clubFromDb.Competiteurs = competiteursFromXLS;
                                    clubFromDb.Encadrants = encadrantsFromXLS;
                                    this.clubRepo.Update(clubFromDb);
                                }
                                else
                                {
                                    //mise à jour
                                    clubFromDb = clubFromXLS;
                                    this.clubRepo.Update(clubFromDb);
                                }

                                // Return an empty string to signify success
                                return Content("");
                            }
                        }
                    }
                    catch (Exception)
                    {
                        if (excelReader != null)
                        {
                            excelReader.Close();
                        }
                    }
                    finally
                    {
                        if (excelReader != null)
                        {
                            excelReader.Close();
                        }
                    }

                }
            }
            return Content("");
        }

        public ActionResult Remove(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    // TODO: Verify user permissions

                    if (System.IO.File.Exists(physicalPath))
                    {
                        // The files are not actually removed in this demo
                         System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // Return an empty string to signify success
            return Content("");
        }
    }
}
