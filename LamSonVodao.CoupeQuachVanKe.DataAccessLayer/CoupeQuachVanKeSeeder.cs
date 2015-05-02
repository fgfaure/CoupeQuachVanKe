namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect;
    using System.Collections.ObjectModel;
    using LamSonVoDao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
    using System.Globalization;
    using LamSonVoDao.CoupeQuachVanKe.DataAccessLayer.Resources;

    /// <summary>
    /// 
    /// </summary>
    class CoupeQuachVanKeSeeder
    {
        /// <summary>
        /// The context
        /// </summary>
        private CoupeQuachVanKeContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoupeQuachVanKeSeeder"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CoupeQuachVanKeSeeder(CoupeQuachVanKeContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Seeds this instance.
        /// </summary>
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
                        MailContact = "christophe.tranvaba@gmail.com",
                        Telephone = "00-00-00-00-00",
                        Adresse = "chez cricri",
                    }
                };

                var clienttype1 = new NetClientType
                {
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

                var clienttype4 = new NetClientType
                {
                    ClientType = "Accueil"
                };

                var netclient = new NetClient
                {
                    ClientLogInName = "Table Centrale",
                    NetClientType = clienttype1,
                    Password = "123456",
                    IsConnected = false
                };

                var typeEpreuve1 = new TypeEpreuve
                {
                    Nom = "Bai Vu Khi",
                    Description = "Enchaimenents avec armes",
                    Coupe = coupe,
                    Technique = true
                };

                var typeEpreuve2 = new TypeEpreuve
                {
                    Nom = "Bai Quyen",
                    Description = "Enchaimenents à mains nues",
                    Coupe = coupe,
                    Technique = true
                };

                var typeEpreuve3 = new TypeEpreuve
                {
                    Nom = "Song Luyen",
                    Description = "Combat préparé",
                    Coupe = coupe,
                    Technique = true
                };

                var typeEpreuve4 = new TypeEpreuve
                {
                    Nom = "Combat",
                    Description = "Combat sportif",
                    Coupe = coupe,
                    Technique = false
                };

                #region catégories de pratiquant
                var categorie1 = new CategoriePratiquant
                {
                    Nom = "Pupilles",
                    AgeMin = 8,
                    AgeMax = 9
                };

                var categorie2 = new CategoriePratiquant
                {
                    Nom = "Benjamins",
                    AgeMin = 10,
                    AgeMax = 11
                };

                var categorie3 = new CategoriePratiquant
                {
                    Nom = "Minimes",
                    AgeMin = 12,
                    AgeMax = 13
                };

                var categorie4 = new CategoriePratiquant
                {
                    Nom = "Cadets",
                    AgeMin = 14,
                    AgeMax = 15
                };

                var categorie5 = new CategoriePratiquant
                {
                    Nom = "Juniors",
                    AgeMin = 16,
                    AgeMax = 17

                };

                var categorie6 = new CategoriePratiquant
                {
                    Nom = "Séniors",
                    AgeMin = 18,
                    AgeMax = 35
                };

                var categorie7 = new CategoriePratiquant
                {
                    Nom = "Vétérans",
                    AgeMin = 36,
                    AgeMax = 75
                };
                #endregion

                #region Quyen Pupilles
                var e1 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie1,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.TousGrades,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e1.Nom = BuildName(e1);

                var e2 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie1,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.TousGrades,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e2.Nom = BuildName(e2);
                #endregion

                #region Quyen Benjamins
                var e3 = new EpreuveTechnique
                       {
                           CategoriePratiquant =categorie2,
                           GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                           GradeAutorise = DataTransferOjbect.Enumerations.Grade.TousGrades,
                           Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                           TypeEpreuve = typeEpreuve2
                       };
                e3.Nom = BuildName(e3);

                var e4 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie2,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.TousGrades,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e4.Nom = BuildName(e4);
                #endregion

                #region Quyen Minimes
                var e5 = new EpreuveTechnique
                        {
                            CategoriePratiquant =categorie3,
                            GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                            GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureBlancheA4emeCap,
                            Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                            TypeEpreuve = typeEpreuve2
                        };
                e5.Nom = BuildName(e5);
                var e6 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie3,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.Plus4emeCapACeintureMarron,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e6.Nom = BuildName(e6);
                var e7 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie3,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureBlancheA4emeCap,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e7.Nom = BuildName(e7);
                var e8 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie3,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.Plus4emeCapACeintureMarron,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e8.Nom = BuildName(e8);
                #endregion

                #region Qyuen Cadets
                var e9 = new EpreuveTechnique
                     {
                         CategoriePratiquant =categorie4,
                         GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                         GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureBlancheA4emeCap,
                         Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                         TypeEpreuve = typeEpreuve2
                     };
                e9.Nom = BuildName(e9);
                var e10 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie4,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.Plus4emeCapACeintureMarron,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e10.Nom = BuildName(e10);
                var e11 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie4,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e11.Nom = BuildName(e11);
                var e12 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie4,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureBlancheA4emeCap,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e12.Nom = BuildName(e12);
                var e13 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie4,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.Plus4emeCapACeintureMarron,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e13.Nom = BuildName(e13);
                var e14 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie4,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e14.Nom = BuildName(e14);
                #endregion

                #region Qyuen Juniors
                var e15 = new EpreuveTechnique
                       {
                           CategoriePratiquant =categorie5,
                           GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                           GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureBlancheA4emeCap,
                           Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                           TypeEpreuve = typeEpreuve2
                       };
                e15.Nom = BuildName(e15);
                var e16 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie5,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.Plus4emeCapACeintureMarron,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e16.Nom = BuildName(e16);
                var e17 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie5,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e17.Nom = BuildName(e17);
                var e18 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie5,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureBlancheA4emeCap,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e18.Nom = BuildName(e18);
                var e19 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie5,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.Plus4emeCapACeintureMarron,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e19.Nom = BuildName(e19);
                var e20 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie5,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e20.Nom = BuildName(e20);
                #endregion

                #region Qyuen Seniors
                var e21 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie6,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureBlancheA4emeCap,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e21.Nom = BuildName(e21);
                var e22 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie6,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.Plus4emeCapACeintureMarron,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e22.Nom = BuildName(e22);
                var e23 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie6,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e23.Nom = BuildName(e23);
                var e24 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie6,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureBlancheA4emeCap,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e24.Nom = BuildName(e24);
                var e25 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie6,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.Plus4emeCapACeintureMarron,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e25.Nom = BuildName(e25);
                var e26 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie6,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e26.Nom = BuildName(e26);
                #endregion

                #region Qyuen Vétérans
                var e27 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie7,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureBlancheA4emeCap,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e27.Nom = BuildName(e27);
                var e28 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie7,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.Plus4emeCapACeintureMarron,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e28.Nom = BuildName(e28);
                var e29 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie7,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e29.Nom = BuildName(e29);
                var e30 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie7,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureBlancheA4emeCap,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e30.Nom = BuildName(e30);
                var e31 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie7,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.Plus4emeCapACeintureMarron,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e31.Nom = BuildName(e31);
                var e32 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie7,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve2
                };
                e32.Nom = BuildName(e32);
                #endregion

                #region BaiVuKhi Cadets
                var v1 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie4,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.TousGrades,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve1
                };
                v1.Nom = BuildName(v1);
                var v2 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie4,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.TousGrades,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve1
                };
                v2.Nom = BuildName(v2);
                #endregion

                #region BaiVuKhi Juniors
                var v3 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie5,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.TousGrades,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve1
                };
                v3.Nom = BuildName(v3);
                var v4 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie5,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.TousGrades,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve1
                };
                v4.Nom = BuildName(v4);
                #endregion

                #region BaiVuKhi Seniors
                var v5 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie6,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.MoinsDeCeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve1
                };
                v5.Nom = BuildName(v5);
                var v6 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie6,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve1
                };
                v6.Nom = BuildName(v6);
                var v7 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie6,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.MoinsDeCeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve1
                };
                v7.Nom = BuildName(v7);
                var v8 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie6,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve1
                };
                v8.Nom = BuildName(v8);
                #endregion

                #region BaiVuKhi Vétérans
                var v9 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie7,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.MoinsDeCeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve1
                };
                v9.Nom = BuildName(v9);
                var v10 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie7,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Feminin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve1
                };
                v10.Nom = BuildName(v10);
                var v11 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie7,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.MoinsDeCeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve1
                };
                v11.Nom = BuildName(v11);
                var v12 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie7,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Masculin,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve1
                };
                v12.Nom = BuildName(v12);
                #endregion

                #region SongLuyen Cadets
                var s1 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie4,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Mixte,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.MoinsDeCeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve3
                };
                s1.Nom = BuildName(s1);
                var s2 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie4,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Mixte,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve3
                };
                s2.Nom = BuildName(s2);
                #endregion

                 #region SongLuyen Juniors
                var s3 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie5,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Mixte,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.MoinsDeCeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve3
                };
                s3.Nom = BuildName(s3);
                var s4 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie5,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Mixte,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve3
                };
                s4.Nom = BuildName(s4);
                #endregion

                 #region SongLuyen Seniors
                var s5 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie6,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Mixte,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.MoinsDeCeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve3
                };
                s5.Nom = BuildName(s5);
                var s6 = new EpreuveTechnique
                {
                    CategoriePratiquant =categorie6,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Mixte,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve3
                };
                s6.Nom = BuildName(s6);
                #endregion

                #region SongLuyen Seniors
                var s7 = new EpreuveTechnique
                {
                    CategoriePratiquant = categorie7,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Mixte,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.MoinsDeCeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve3
                };
                s7.Nom = BuildName(s7);
                var s8 = new EpreuveTechnique
                {
                    CategoriePratiquant = categorie7,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Mixte,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve3
                };
                s8.Nom = BuildName(s8);
                #endregion


                #region combats Benjamins
                var cb = new EpreuveCombat
                {
                    CategoriePratiquant = categorie2,
                    GenreCategorie = GenreEpreuve.Feminin,
                    GradeAutorise = Grade.MoinsDeCeintureNoire,
                    Statut = StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve4,
                    PoidsMini = 20,
                    PoidsMaxi = 25
                };

                #endregion


                this.context.Entry(clienttype1).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(clienttype2).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(clienttype3).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(clienttype4).State = System.Data.Entity.EntityState.Added;

                this.context.Entry(netclient).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(coupe).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(typeEpreuve1).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(typeEpreuve2).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(typeEpreuve3).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(typeEpreuve4).State = System.Data.Entity.EntityState.Added;

                this.context.Entry(categorie1).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(categorie2).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(categorie3).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(categorie4).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(categorie5).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(categorie6).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(categorie7).State = System.Data.Entity.EntityState.Added;

                this.context.Entry(e1).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e2).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e3).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e4).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e5).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e6).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e7).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e8).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e9).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e10).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e11).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e12).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e13).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e14).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e15).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e16).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e17).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e18).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e19).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e20).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e21).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e22).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e23).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e24).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e25).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e26).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e27).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e28).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e29).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e30).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e31).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(e32).State = System.Data.Entity.EntityState.Added;

                this.context.Entry(v1).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(v2).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(v3).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(v4).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(v5).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(v6).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(v7).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(v8).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(v9).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(v10).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(v11).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(v12).State = System.Data.Entity.EntityState.Added;

                this.context.Entry(s1).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(s2).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(s3).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(s4).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(s5).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(s6).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(s7).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(s8).State = System.Data.Entity.EntityState.Added;

                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                Console.WriteLine(message);
                Debug.WriteLine(message);
                throw;
            }
        }

        private string BuildName(Epreuve e2)
        {
          return  string.Format("{0} {1} {2} {3}",
                           e2.TypeEpreuve.Nom,
                           e2.CategoriePratiquant.Nom,
                           GenreEpreuves.ResourceManager.GetString(e2.GenreCategorie.ToString(),CultureInfo.InvariantCulture),
                           Grades.ResourceManager.GetString(e2.GradeAutorise.ToString()), CultureInfo.InvariantCulture);
        }
    }
}
