using LamSonVodao.CoupeQuachVanKe.DataAccessLayer;
using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace LamSonVodao.CoupeQuachVanKe.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<CoupeQuachVanKeContext>());
            using (var context = new CoupeQuachVanKeContext())
            {
                //var responsable = new ResponsableCoupe
                //{
                //    Nom = "Tran Van Ba",
                //    Prenom = "Christophe",
                //    EmailContact = "christophe.tranvaba@gmail.com",
                //    Telephone = "00-00-00-00-00",
                //    Adresse = "chez cricri"
                //};

              //  db.Responsables.Add(responsable);

                var coupe = new Coupe()
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
                        Adresse = "chez cricri"
                    }
                };

                var md = new Medecin{
                        Nom = "GALLAUX",
                        Prenom = "Jean-Pierre"
                    };

               // context.Entry(md).State = EntityState.Added;
               //// db.Coupes.Add(coupe);

                coupe.Medecins = new List<Medecin>();
                coupe.Medecins.Add(md);
                context.Entry(coupe).State = EntityState.Added;

                
                context.SaveChanges();
            }
        }
    }
}
