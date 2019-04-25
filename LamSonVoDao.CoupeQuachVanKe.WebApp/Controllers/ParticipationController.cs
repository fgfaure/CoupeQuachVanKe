using LamSonVoDao.CoupeQuachVanKe.AccesPattern;
using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Contracts;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Controllers
{
    public class ParticipationController : BaseController<Participation>, ICrudController<Participation, EpreuveVentileeModel>
    {
        private Repository<Participant> participantRepository;

        public JsonResult Create(EpreuveVentileeModel model)
        {
            try
            {

                foreach (var participationModel in model.ParticipationModels)
                {
                    var dbitem = participationModel.ToDTO();
                    if (dbitem.Id == 0)
                    {
                        this.repository.Create(dbitem);
                    }
                }

                if (this.participantRepository == null)
                {
                    this.participantRepository = unitOfWork.Repository<Participant>();
                }

                this.participantRepository.Read();
                model.ParticipationModels = this.repository.Read().Where(m => m.EpreuveId == model.EpreuveId).Select(p => p.ToModel()).ToList();
                var epreuves = this.unitOfWork.Repository<Epreuve>();
                var ep = epreuves.Read(m => m.Id == model.EpreuveId).First();
                ep.Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Ouverte;
                epreuves.Update(ep);
                return Json(model);
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Delete(EpreuveVentileeModel model)
        {
            try
            {
                foreach (var participationModel in model.ParticipationModels)
                {
                    var dbmodel = this.repository.Read(m => m.ParticipantId == participationModel.ParticipantId && m.EpreuveId == participationModel.EpreuveId).First();
                    if (dbmodel != null)
                    {
                        this.repository.Delete(dbmodel);
                    }
                    else
                    {
                        throw new ArgumentException("La participation est absente de la base de données", "dbmodel");
                    }
                }
                var epreuves = this.unitOfWork.Repository<Epreuve>();
                var ep = epreuves.Read(m => m.Id == model.EpreuveId).First();
                ep.Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee;
                epreuves.Update(ep);
                return Json(model);
            }
            catch
            {
                throw;
            }
        }

        public JsonResult Get()
        {
            if (this.participantRepository == null)
            {
                this.participantRepository = unitOfWork.Repository<Participant>();
            }

            var result = new JsonResult();
            var dispo = this.participantRepository.Read();
            var local = this.repository.Read().Select(enc => enc.ToModel());
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            List<EpreuveVentileeModel> models = new List<EpreuveVentileeModel>();

            foreach (ParticipationModel model in local)
            {
                var found = models.FirstOrDefault(m => m.EpreuveId == model.EpreuveId);
                if (found == null)
                {
                    EpreuveVentileeModel epreuveVentilee = new EpreuveVentileeModel();
                    epreuveVentilee.EpreuveId = model.EpreuveId;
                    ParticipationModel participation = new ParticipationModel();
                    participation.EpreuveId = model.EpreuveId;
                    participation.Nom = model.Nom;
                    participation.ParticipantId = model.ParticipantId;
                    participation.Prenom = model.Prenom;
                    epreuveVentilee.ParticipationModels.Add(participation);
                    models.Add(epreuveVentilee);
                }
                else
                {
                    ParticipationModel participation = new ParticipationModel();
                    participation.EpreuveId = model.EpreuveId;
                    participation.Nom = model.Nom;
                    participation.ParticipantId = model.ParticipantId;
                    participation.Prenom = model.Prenom;
                    found.ParticipationModels.Add(participation);
                }
            }

            result.Data = models;
            return result;
        }

        public JsonResult Update(EpreuveVentileeModel model)
        {

            var dbs = this.repository.Read(m => m.EpreuveId == model.EpreuveId).ToDictionary(x => x.ParticipantId, x => x.EpreuveId);
            var models = model.ParticipationModels.ToDictionary(m => m.ParticipantId, m => m.EpreuveId);

            var toAdd = models.Except(dbs);
            var toRemove = dbs.Except(models);

            foreach (var participationModel in toAdd)
            {
                Participation participation = new Participation();
                participation.EpreuveId = model.EpreuveId;
                participation.ParticipantId = participationModel.Key;
                this.repository.Create(participation);
            }

            foreach (var participationModel in toRemove)
            {
                var dbmodel = this.repository.Read(db => db.EpreuveId == participationModel.Value && db.ParticipantId == participationModel.Key).First();
                if (dbmodel != null)
                {
                    this.repository.Delete(dbmodel);
                }
            }

            if (this.participantRepository == null)
            {
                this.participantRepository = unitOfWork.Repository<Participant>();
            }

            this.participantRepository.Read();
            model.ParticipationModels = this.repository.Read().Where(m => m.EpreuveId == model.EpreuveId).Select(p => p.ToModel()).ToList();
            return Json(model);
        }
    }
}