/// <copyright file="AireService.cs" company="ITESOFT">
/// Copyright (c) 2015 All Right Reserved
/// <author>fgf</author>
/// </copyright>

namespace LamSonVodao.CoupeQuachVanKe.AccesPattern.AccessServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LamSonVodao.CoupeQuachVanKe.AccesPattern.AccessServiceContracts;
    using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;


    public class AireService : IAireService
    {
        public IEnumerable<Aire> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Aire> Get(Func<Aire, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Aire GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Aire entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Aire entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Aire entity)
        {
            throw new NotImplementedException();
        }
    }
}
