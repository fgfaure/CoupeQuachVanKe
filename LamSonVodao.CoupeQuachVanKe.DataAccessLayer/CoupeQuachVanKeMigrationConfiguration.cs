using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamSonVodao.CoupeQuachVanKe.DataAccessLayer;

namespace LamSonVodao.CoupeQuachVanKe.DataAccessLayer
{
    public class CoupeQuachVanKeMigrationConfiguration : DbMigrationsConfiguration<CoupeQuachVanKeContext>
    {
        public CoupeQuachVanKeMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

#if DEBUG
        protected override void Seed(CoupeQuachVanKeContext context)
        {
            //besoin de créer le seeder
            //Console.WriteLine("seed");
          new CoupeQuachVanKeSeeder(context).Seed();
        }
    }
#endif
}
