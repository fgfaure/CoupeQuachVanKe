using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;

namespace LamSonVodao.CoupeQuachVanKe.DataAccessLayer
{
    class CoupeQuachVanKeSeeder
    {
        private CoupeQuachVanKeContext context;

        public CoupeQuachVanKeSeeder(CoupeQuachVanKeContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            try
            {
                

                    Coupe coupe = new Coupe()
                    {
                        Nom = "CoupeQVK2015",
                        Description = "Coupe Quach Van Kê 2015",
                        NombreTapis = 4,
                        Ville = "JACOU",
                        CodePostal = "34830",
                        Voie = "Rue Henri MOYNIER",
                        Complement = "Gymnase Puigsegur",
                        DateDebut = new DateTime(2015, 5, 16, 12, 0, 0),
                        DateFin = new DateTime(2015, 5, 17, 18, 0, 0),
                        Responsable = new ResponsableCoupe
                        {
                            Nom = "Tran Van Ba",
                            Prenom = "Christophe",
                            EmailContact = "christophe.tranvaba@gmail.com",
                            Telephone = "00-00-00-00-00",
                            Adresse = "chez cricri",

                        }
                    };

                    var clienttype1 = new NetClientType{
                        ClientType = "Table Centrale"
                    };

                    var clienttype2 = new NetClientType
                    {
                        ClientType = "Table Satelitte"
                    };

                    var clienttype3 = new NetClientType
                    {
                        ClientType = "Saisie"
                    };

                    this.context.Entry(clienttype1).State = System.Data.Entity.EntityState.Added;
                    this.context.Entry(clienttype2).State = System.Data.Entity.EntityState.Added;
                    this.context.Entry(clienttype3).State = System.Data.Entity.EntityState.Added;

                    this.context.Entry(coupe).State = System.Data.Entity.EntityState.Added;

                    this.context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                Console.WriteLine(message);
                Debug.WriteLine(message);
                throw ex;
            }
        }
    }
}
