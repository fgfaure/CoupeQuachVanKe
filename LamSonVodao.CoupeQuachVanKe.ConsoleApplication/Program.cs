namespace LamSonVoDao.CoupeQuachVanKe.ConsoleApplication
{
    using LamSonVoDao.CoupeQuachVanKe.DataAccessLayer;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Helper;
    using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //using (var context = new CoupeQuachVanKeContext())
            //{
            //    var coupe = new Coupe()
            //    {
            //        Nom = "CoupeQVK2015",
            //        Description = "Coupe Quach Van Kê 2015",
            //        NombreTapis = 4,
            //        Ville = "JACOU",
            //        CodePostal = "34830",
            //        Voie = "Rue Henri MOYNIER",
            //        Complement = "Gymnase Puigsegur",
            //        DateDebut = new DateTime(2015, 5, 16, 12, 0, 0),
            //        DateFin = new DateTime(2015, 5, 17, 18, 0, 0),
            //        Responsable = new ResponsableCoupe
            //        {
            //            Nom = "Tran Van Ba",
            //            Prenom = "Christophe",
            //            MailContact = "christophe.tranvaba@gmail.com",
            //            Telephone = "00-00-00-00-00",
            //            Adresse = "chez cricri"
            //        }
            //    };

            //    var md = new Medecin
            //    {
            //        Nom = "GALLAUX",
            //        Prenom = "Jean-Pierre"
            //    };

            //    coupe.Medecins = new List<Medecin>();
            //    coupe.Medecins.Add(md);
            //    context.Entry(coupe).State = EntityState.Added;


            //    context.SaveChanges();
            //}

            int count;
            
            string input = Console.ReadLine(); 
            
            if (!int.TryParse(input, out count))
            {
                count = 1;
            }

            var list = new List<ParticipationCombatModel>();

            for (int i = 1; i < count+1; i++)
            {
                list.Add(new ParticipationCombatModel
                {
                    Club = "Club "+(i),
                    ClubId = i,
                    Couleur = (i % 2 == 0)? "#0000FF" : "#FF0000" ,
                    EpreuveId = 1004,
                    Id = i,
                    Nom = "Nom "+i,
                    ParticipantId = i,
                    Prenom = "Prenom "+i,                    
                });
            }

           var source = list.OrderBy(a => Guid.NewGuid());

            var tree = TreeHelper.BuildTree(source);

            Console.ReadLine();
        }
    }
}
