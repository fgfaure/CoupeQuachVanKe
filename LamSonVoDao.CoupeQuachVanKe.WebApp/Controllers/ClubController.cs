namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    using Excel;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers.BaseController{LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Club}" />
    /// <seealso cref="LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts.ICrudController{LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Club, LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe.ClubModel}" />
    public class ClubController : BaseController<Club>, ICrudController<Club, ClubModel>
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = this.repository.Read().OrderBy(club => club.Nom).Select(club => new ClubModel
            {
                Id = club.Id,
                Nom = club.Nom,
                NumeroAffiliation = club.NumeroAffiliation
            });
            return result;
        }

        /// <summary>
        /// Competiteurses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Invalid Id - id</exception>
        [HttpPost]
        public JsonResult Competiteurs(string id)
        {
            int parsed;
            if (int.TryParse(id, out parsed))
            {
                var result = new JsonResult();
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                result.Data = this.unitOfWork.Repository<Competiteur>().Read().Where(e => e.ClubId == parsed).OrderBy(comp => comp.Nom).Select(c => c.ToModel());
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid Id", "id");
            }

        }

        /// <summary>
        /// Responsableses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Invalid Id - id</exception>
        [HttpPost]
        public JsonResult Responsables(string id)
        {
            int parsed;
            if (int.TryParse(id, out parsed))
            {
                var result = new JsonResult();
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                result.Data = this.unitOfWork.Repository<ResponsableClub>().Read().Where(e => e.ClubId == parsed).Select(c => c.ToModel());
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid Id", "id");
            }
        }

        /// <summary>
        /// Encadrantses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Invalid Id - id</exception>
        [HttpPost]
        public JsonResult Encadrants(string id)
        {
            int parsed;
            if (int.TryParse(id, out parsed))
            {
                var result = new JsonResult();
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                result.Data = this.unitOfWork.Repository<Encadrant>().Read().Where(e => e.ClubId == parsed).Select(e => e.ToModel());
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid Id", "id");
            }
        }
        // POST: Club/Create
        // [HttpPost]
        /// <summary>
        /// Creates the specified club.
        /// </summary>
        /// <param name="club">The club.</param>
        /// <returns></returns>
        public JsonResult Create(ClubModel club)
        {
            try
            {
                var dbitem = new Club
                {
                    Nom = club.Nom,
                    NumeroAffiliation = club.NumeroAffiliation,
                    Encadrants = new List<Encadrant>(),
                    Participants = new List<Participant>(),
                };

                this.repository.Create(dbitem);
                return Json(dbitem.ToModel());

            }
            catch
            {
                throw;
            }
        }
        // [HttpPost]
        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public JsonResult Update(ClubModel model)
        {
            try
            {
                var dbmodel = this.repository.Read(m => m.Id == model.Id).First();
                dbmodel.NumeroAffiliation = model.NumeroAffiliation;
                dbmodel.Nom = model.Nom;

                this.repository.Update(dbmodel);
                return Json(dbmodel.ToModel());
            }
            catch
            {
                throw;
            }
        }
        
        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public JsonResult Delete(ClubModel model)
        {
            try
            {
                var dbItem = this.repository.Read(model.Id);
                var competiteursRepository = this.unitOfWork.Repository<Competiteur>();
                var clubName = model.Nom;
                foreach (var comp in competiteursRepository.Read().Where(c => c.ClubId == dbItem.Id))
                {
                    competiteursRepository.Delete(comp);
                }
                this.repository.Delete(dbItem);
                string clubImportFile = Path.Combine(Server.MapPath("~/App_Data/Imports"), clubName);
                if (System.IO.File.Exists(clubImportFile))
                {
                    Directory.Delete(clubImportFile, true);
                }
                
                return Json(new { success = true });
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Saves the specified files.
        /// </summary>
        /// <param name="files">The files.</param>
        /// <returns></returns>
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
                            excelReader = ExcelReaderFactory.CreateBinaryReader(stream, false, ReadOption.Loose);
                            DataSet result = excelReader.AsDataSet();

                            if (result.Tables != null && result.Tables.Count >= 3)
                            {
                                var sheetEncadrants = result.Tables[2];
                                var sheetCompetiteurs = result.Tables[1];

                                if (sheetCompetiteurs.Rows.Count > 2)
                                {
                                    var thirdRow = sheetCompetiteurs.Rows[2];
                                    string clubId = thirdRow.ItemArray[14].ToString();
                                    while (clubId.Length < 7)
                                    {
                                        clubId = "0" + clubId;
                                    }

                                    Club clubFromXLS = new Club
                                    {
                                        Nom = thirdRow.ItemArray[13].ToString(),
                                        NumeroAffiliation = clubId
                                    };
                                    ResponsableClub responsableFromXLS = new ResponsableClub
                                    {
                                        Nom = thirdRow.ItemArray[15].ToString(),
                                        Prenom = thirdRow.ItemArray[16].ToString(),
                                        Adresse = thirdRow.ItemArray[17].ToString(),
                                        Telephone = thirdRow.ItemArray[18].ToString(),
                                        MailContact = thirdRow.ItemArray[19].ToString()
                                    };

                                    if (String.IsNullOrWhiteSpace(responsableFromXLS.Telephone))
                                    {
                                        responsableFromXLS.Telephone = "00-00-00-00-00";
                                    }

                                    List<Participant> competiteursFromXLS = new List<Participant>();

                                    for (int i = 2; i < sheetCompetiteurs.Rows.Count; i++)
                                    {
                                        var localRow = sheetCompetiteurs.Rows[i];
                                        if (localRow.ItemArray[0].ToString() == string.Empty)
                                        {
                                            break;
                                        }

                                        var comp = ExcelConverterHelper.ConvertFromXLS(localRow);
                                        competiteursFromXLS.Add(comp);
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
                                                Date = new DateTime(2017, 4, 29),
                                                Matin = false,
                                                Role = Role.Arbitre
                                            });
                                        }
                                        if (ExcelConverterHelper.ConvertToBool(localRow.ItemArray[9].ToString()))
                                        {
                                            dispo.Add(new Disponibilite
                                            {
                                                Date = new DateTime(2017, 4, 30),
                                                Matin = true,
                                                Role = Role.Arbitre
                                            });
                                        }
                                        if (ExcelConverterHelper.ConvertToBool(localRow.ItemArray[10].ToString()))
                                        {
                                            dispo.Add(new Disponibilite
                                            {
                                                Date = new DateTime(2017, 4, 30),
                                                Matin = false,
                                                Role = Role.Arbitre
                                            });
                                        }
                                        if (ExcelConverterHelper.ConvertToBool(localRow.ItemArray[11].ToString()))
                                        {
                                            dispo.Add(new Disponibilite
                                            {
                                                Date = new DateTime(2017, 4, 29),
                                                Matin = false,
                                                Role = Role.Administrateur
                                            });
                                        }
                                        if (ExcelConverterHelper.ConvertToBool(localRow.ItemArray[12].ToString()))
                                        {
                                            dispo.Add(new Disponibilite
                                            {
                                                Date = new DateTime(2017, 4, 30),
                                                Matin = true,
                                                Role = Role.Administrateur
                                            });
                                        }
                                        if (ExcelConverterHelper.ConvertToBool(localRow.ItemArray[13].ToString()))
                                        {
                                            dispo.Add(new Disponibilite
                                            {
                                                Date = new DateTime(2017, 4, 30),
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
                                    clubFromXLS.Participants = competiteursFromXLS;
                                    clubFromXLS.Encadrants = encadrantsFromXLS;

                                    var teamMembers = competiteursFromXLS.Cast<Competiteur>().Where(c => (c.InscritPourSongLuyen || c.InscritPourQuyenDongDien) && c.NumeroEquipe > 0).OrderBy(c => c.NumeroEquipe);
                                    var equipes = new List<Participant>();

                                    foreach (var member in teamMembers)
                                    {
                                        var team = equipes.Cast<Equipe>().FirstOrDefault(e => e.Numero == member.NumeroEquipe);
                                        if (team == null)
                                        {
                                            var newTeam = new Equipe();
                                            newTeam.Nom = member.Nom;
                                            newTeam.Numero = member.NumeroEquipe;
                                            newTeam.Competiteurs = new List<Competiteur>();
                                            newTeam.Competiteurs.Add(member);
                                            equipes.Add(newTeam);
                                        }
                                        else
                                        {
                                            team.Nom = string.Format("{0}/{1}", team.Nom, member.Nom);
                                            team.Prenom = string.Format("{0}/{1}", team.Prenom, member.Prenom);
                                            team.TeamName = string.Format("Equipe {0}", team.Numero);
                                            team.Competiteurs.Add(member);
                                        }
                                    }

                                    if (equipes.Count > 0)
                                    {
                                        clubFromXLS.Participants = clubFromXLS.Participants.Union(equipes).ToList();
                                    }

                                    var clubFromDb = this.repository.Read(club => string.Compare(club.NumeroAffiliation, clubFromXLS.NumeroAffiliation) == 0).FirstOrDefault();
                                    if (clubFromDb == null)
                                    {
                                        //ajout
                                        this.repository.Create(clubFromXLS);
                                    }
                                    else
                                    {
                                        //mise à jour                                        
                                        this.repository.Delete(clubFromDb);
                                        this.repository.Create(clubFromXLS);
                                    }

                                    excelReader.Close();

                                    string clubDirectory = Path.Combine(Server.MapPath("~/App_Data/Imports"), clubFromXLS.Nom);
                                    if (!Directory.Exists(clubDirectory))
                                    {
                                        Directory.CreateDirectory(clubDirectory);
                                    }

                                    if (System.IO.File.Exists(Path.Combine(clubDirectory, fileName)))
                                    {
                                        System.IO.File.Delete(Path.Combine(clubDirectory, fileName));
                                    }
                                    System.IO.File.Move(physicalPath, Path.Combine(clubDirectory, fileName));
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
