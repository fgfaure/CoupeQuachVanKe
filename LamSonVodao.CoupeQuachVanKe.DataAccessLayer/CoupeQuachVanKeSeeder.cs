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
    using LamSonVodao.CoupeQuachVanKe.DataTransferOjbect.Enumerations;
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
					Nom = "CoupeQVK2019",
					Description = "Coupe Quach Van Kê 2019",
					Ville = "JACOU",
					CodePostal = "34830",
					Voie = "Rue Henri MOYNIER",
					Complement = "Gymnase Puigsegur",
					DateDebut = new DateTime(2019, 4, 27, 12, 0, 0),
					DateFin = new DateTime(2019, 4, 29, 18, 0, 0),
					Responsable = new ResponsableCoupe
					{
						Nom = "Tran Van Ba",
						Prenom = "Christophe",
						MailContact = "christophe.tranvaba@gmail.com",
						Telephone = "00-00-00-00-00",
						Adresse = "chez cricri",
					}
				};

                var color1 = new UIColor()
                {
                    Description = "couleur par défaut",
                    RGB_Code= "#D9E9FF",
                    Identifier = ColorConstants.DEFAULT
                };

                var color2 = new UIColor()
                {
                    Description = "couleur du premier",
                    RGB_Code = "#e75136",
                    Identifier = ColorConstants.FIRST
                };

                var color3 = new UIColor()
                {
                    Description = "couleur du second",
                    RGB_Code = "#ffc600",
                    Identifier = ColorConstants.SECOND
                };

                var color4 = new UIColor()
                {
                    Description = "couleur du troisième",
                    RGB_Code = "#3bea58",
                    Identifier = ColorConstants.THIRD
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

				var pc1 = new NetClient
				{
					ClientLogInName = "PC-Tapis1",
					NetClientType = clienttype2,
					Password = "pc1",
					IsConnected = false
				};

				var pc2 = new NetClient
				{
					ClientLogInName = "PC-Tapis2",
					NetClientType = clienttype2,
					Password = "pc2",
					IsConnected = false
				};

				var pc3 = new NetClient
				{
					ClientLogInName = "PC-Tapis3",
					NetClientType = clienttype2,
					Password = "pc3",
					IsConnected = false
				};

				var netclient3 = new NetClient
				{
					ClientLogInName = "Saisie poids",
					NetClientType = clienttype3,
					Password = "accueil",
					IsConnected = false
				};

				var netclient4 = new NetClient
				{
					ClientLogInName = "Accueil compétiteurs",
					NetClientType = clienttype4,
					Password = "accueil",
					IsConnected = false
				};

                var typeEpreuve1 = new TypeEpreuve
                {
                    Nom = "Bai Vu Khi",
                    Description = "Enchaimenents avec armes",
                    Coupe = coupe,
                    Technique = true,
                    Identifier = TypeEpreuveConstants.BAIVUKHI
				};

				var typeEpreuve2 = new TypeEpreuve
				{
					Nom = "Bai Quyen",
					Description = "Enchaimenents à mains nues",
					Coupe = coupe,
					Technique = true,
                    Identifier = TypeEpreuveConstants.BAIQUYEN
                };

				var typeEpreuve3 = new TypeEpreuve
				{
					Nom = "Song Luyen",
					Description = "Combat préparé",                    
					Coupe = coupe,
					Technique = true,
                    Identifier = TypeEpreuveConstants.SONGLUYEN
                };

                var typeEpreuve5 = new TypeEpreuve
                {
                    Nom = "Quyền Đồng Diễn avec Phân Thế",
                    Description = "Quyen synchronisé avec applications",
                    Coupe = coupe,
                    Technique = true,
                    Identifier = TypeEpreuveConstants.QUYENDONGDIEN
                };

                var typeEpreuve4 = new TypeEpreuve
				{
					Nom = "Combat",
					Description = "Combat sportif",
					Coupe = coupe,
					Technique = false,
                    Identifier = TypeEpreuveConstants.CBT
                };

				#region catégories de pratiquant
				var categorie1 = new CategoriePratiquant
				{
					Nom = "Pupilles",
					AgeMin = 8,
					AgeMax = 9,
                    Duree = 90
                };

				var categorie2 = new CategoriePratiquant
				{
					Nom = "Benjamins",
					AgeMin = 10,
					AgeMax = 11,
                    Duree = 90
                };

				var categorie3 = new CategoriePratiquant
				{
					Nom = "Minimes",
					AgeMin = 12,
					AgeMax = 13,
                    Duree = 120
                };

				var categorie4 = new CategoriePratiquant
				{
					Nom = "Cadets",
					AgeMin = 14,
					AgeMax = 15,
                    Duree = 120
                };

				var categorie5 = new CategoriePratiquant
				{
					Nom = "Juniors",
					AgeMin = 16,
					AgeMax = 17,
                    Duree = 120

                };

				var categorie6 = new CategoriePratiquant
				{
					Nom = "Séniors",
					AgeMin = 18,
					AgeMax = 35,
                    Duree = 120
                };

				var categorie7 = new CategoriePratiquant
				{
					Nom = "Vétérans",
					AgeMin = 36,
					AgeMax = 75,
                    Duree = 90
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
			   
				#region SongLuyen Cadets, Juniors, Seniors et Vétérans mixés
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

                #region Quyen Dong Dien Cadets, Juniors, Seniors et Vétérans mixés
                var qdd7 = new EpreuveTechnique
                {
                    CategoriePratiquant = categorie7,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Mixte,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.MoinsDeCeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve5
                };
                qdd7.Nom = BuildName(qdd7);
                var qdd8 = new EpreuveTechnique
                {
                    CategoriePratiquant = categorie7,
                    GenreCategorie = DataTransferOjbect.Enumerations.GenreEpreuve.Mixte,
                    GradeAutorise = DataTransferOjbect.Enumerations.Grade.CeintureNoire,
                    Statut = DataTransferOjbect.Enumerations.StatutEpreuve.Fermee,
                    TypeEpreuve = typeEpreuve5
                };
                qdd8.Nom = BuildName(qdd8);
                #endregion

                #region Combats Pupilles Masculin
                var CombatsPupillesMasculin1 = new EpreuveCombat
				{
					CategoriePratiquant = categorie1,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 25
				};
				CombatsPupillesMasculin1.Nom = BuildEpreuveName(CombatsPupillesMasculin1);

				var CombatsPupillesMasculin2 = new EpreuveCombat
				{
					CategoriePratiquant = categorie1,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 25,
					PoidsMaxi = 30
                };
				CombatsPupillesMasculin2.Nom = BuildEpreuveName(CombatsPupillesMasculin2);

				var CombatsPupillesMasculin3 = new EpreuveCombat
				{
					CategoriePratiquant = categorie1,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 30,
					PoidsMaxi = 35
                };
				CombatsPupillesMasculin3.Nom = BuildEpreuveName(CombatsPupillesMasculin3);

				var CombatsPupillesMasculin4 = new EpreuveCombat
				{
					CategoriePratiquant = categorie1,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 35,
					PoidsMaxi = 40
                };
				CombatsPupillesMasculin4.Nom = BuildEpreuveName(CombatsPupillesMasculin4);

				var CombatsPupillesMasculin5 = new EpreuveCombat
				{
					CategoriePratiquant = categorie1,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 40,
					PoidsMaxi = 45
                };
				CombatsPupillesMasculin5.Nom = BuildEpreuveName(CombatsPupillesMasculin5);

				var CombatsPupillesMasculin6 = new EpreuveCombat
				{
					CategoriePratiquant = categorie1,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 45,
					PoidsMaxi = 50
				};
				CombatsPupillesMasculin6.Nom = BuildEpreuveName(CombatsPupillesMasculin6);

				var CombatsPupillesMasculin7 = new EpreuveCombat
				{
					CategoriePratiquant = categorie1,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 50,
					PoidsMaxi = 1000
                };
				CombatsPupillesMasculin7.Nom = BuildEpreuveName(CombatsPupillesMasculin7);

				#endregion

				#region Combats Pupilles Féminin
				var CombatsPupillesFeminin1 = new EpreuveCombat
				{
					CategoriePratiquant = categorie1,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 25
                };
				CombatsPupillesFeminin1.Nom = BuildEpreuveName(CombatsPupillesFeminin1);

				var CombatsPupillesFeminin2 = new EpreuveCombat
				{
					CategoriePratiquant = categorie1,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 25,
					PoidsMaxi = 30
                };
				CombatsPupillesFeminin2.Nom = BuildEpreuveName(CombatsPupillesFeminin2);

				var CombatsPupillesFeminin3 = new EpreuveCombat
				{
					CategoriePratiquant = categorie1,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 30,
					PoidsMaxi = 35
                };
				CombatsPupillesFeminin3.Nom = BuildEpreuveName(CombatsPupillesFeminin3);

				var CombatsPupillesFeminin4 = new EpreuveCombat
				{
					CategoriePratiquant = categorie1,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 35,
					PoidsMaxi = 40
                };
				CombatsPupillesFeminin4.Nom = BuildEpreuveName(CombatsPupillesFeminin4);

				var CombatsPupillesFeminin5 = new EpreuveCombat
				{
					CategoriePratiquant = categorie1,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 40,
					PoidsMaxi = 45
                };
				CombatsPupillesFeminin5.Nom = BuildEpreuveName(CombatsPupillesFeminin5);

				var CombatsPupillesFeminin6 = new EpreuveCombat
				{
					CategoriePratiquant = categorie1,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 45,
					PoidsMaxi = 1000
                };
				CombatsPupillesFeminin6.Nom = BuildEpreuveName(CombatsPupillesFeminin6);

				#endregion

				#region Combats Benjamins Masculin
				var CombatsBenjaminsMasculin1 = new EpreuveCombat
				{
					CategoriePratiquant = categorie2,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 30
                };
				CombatsBenjaminsMasculin1.Nom = BuildEpreuveName(CombatsBenjaminsMasculin1);

				var CombatsBenjaminsMasculin2 = new EpreuveCombat
				{
					CategoriePratiquant = categorie2,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 30,
					PoidsMaxi = 35
                };
				CombatsBenjaminsMasculin2.Nom = BuildEpreuveName(CombatsBenjaminsMasculin2);

				var CombatsBenjaminsMasculin3 = new EpreuveCombat
				{
					CategoriePratiquant = categorie2,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 35,
					PoidsMaxi = 40
                };
				CombatsBenjaminsMasculin3.Nom = BuildEpreuveName(CombatsBenjaminsMasculin3);

				var CombatsBenjaminsMasculin4 = new EpreuveCombat
				{
					CategoriePratiquant = categorie2,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 40,
					PoidsMaxi = 45
                };
				CombatsBenjaminsMasculin4.Nom = BuildEpreuveName(CombatsBenjaminsMasculin4);

				var CombatsBenjaminsMasculin5 = new EpreuveCombat
				{
					CategoriePratiquant = categorie2,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 45,
					PoidsMaxi = 50
                };
				CombatsBenjaminsMasculin5.Nom = BuildEpreuveName(CombatsBenjaminsMasculin5);

				var CombatsBenjaminsMasculin6 = new EpreuveCombat
				{
					CategoriePratiquant = categorie2,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 50,
					PoidsMaxi = 55
                };
				CombatsBenjaminsMasculin6.Nom = BuildEpreuveName(CombatsBenjaminsMasculin6);

				var CombatsBenjaminsMasculin7 = new EpreuveCombat
				{
					CategoriePratiquant = categorie2,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 55,
					PoidsMaxi = 1000
                };
				CombatsBenjaminsMasculin7.Nom = BuildEpreuveName(CombatsBenjaminsMasculin7);

				#endregion

				#region Combats Benjamins Feminin
				var CombatsBenjaminsFeminin1 = new EpreuveCombat
				{
					CategoriePratiquant = categorie2,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 30
                };
				CombatsBenjaminsFeminin1.Nom = BuildEpreuveName(CombatsBenjaminsFeminin1);

				var CombatsBenjaminsFeminin2 = new EpreuveCombat
				{
					CategoriePratiquant = categorie2,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 30,
					PoidsMaxi = 35
                };
				CombatsBenjaminsFeminin2.Nom = BuildEpreuveName(CombatsBenjaminsFeminin2);

				var CombatsBenjaminsFeminin3 = new EpreuveCombat
				{
					CategoriePratiquant = categorie2,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 35,
					PoidsMaxi = 40
                };
				CombatsBenjaminsFeminin3.Nom = BuildEpreuveName(CombatsBenjaminsFeminin3);

				var CombatsBenjaminsFeminin4 = new EpreuveCombat
				{
					CategoriePratiquant = categorie2,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 40,
					PoidsMaxi = 45
                };
				CombatsBenjaminsFeminin4.Nom = BuildEpreuveName(CombatsBenjaminsFeminin4);

				var CombatsBenjaminsFeminin5 = new EpreuveCombat
				{
					CategoriePratiquant = categorie2,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 45,
					PoidsMaxi = 50
                };
				CombatsBenjaminsFeminin5.Nom = BuildEpreuveName(CombatsBenjaminsFeminin5);

				var CombatsBenjaminsFeminin6 = new EpreuveCombat
				{
					CategoriePratiquant = categorie2,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 50,
					PoidsMaxi = 1000
                };
				CombatsBenjaminsFeminin6.Nom = BuildEpreuveName(CombatsBenjaminsFeminin6);
				#endregion

				#region Combat Minimes Masculin
				var CombatsMinimesMasculin1 = new EpreuveCombat
				{
					CategoriePratiquant = categorie3,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 40
                };
				CombatsMinimesMasculin1.Nom = BuildEpreuveName(CombatsMinimesMasculin1);

				var CombatsMinimesMasculin2 = new EpreuveCombat
				{
					CategoriePratiquant = categorie3,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 40,
					PoidsMaxi = 45
                };
				CombatsMinimesMasculin2.Nom = BuildEpreuveName(CombatsMinimesMasculin2);

				var CombatsMinimesMasculin3 = new EpreuveCombat
				{
					CategoriePratiquant = categorie3,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 45,
					PoidsMaxi = 50
                };
				CombatsMinimesMasculin3.Nom = BuildEpreuveName(CombatsMinimesMasculin3);

				var CombatsMinimesMasculin4 = new EpreuveCombat
				{
					CategoriePratiquant = categorie3,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 50,
					PoidsMaxi = 55
                };
				CombatsMinimesMasculin4.Nom = BuildEpreuveName(CombatsMinimesMasculin4);

				var CombatsMinimesMasculin5 = new EpreuveCombat
				{
					CategoriePratiquant = categorie3,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 55,
					PoidsMaxi = 60
                };
				CombatsMinimesMasculin5.Nom = BuildEpreuveName(CombatsMinimesMasculin5);

				var CombatsMinimesMasculin6 = new EpreuveCombat
				{
					CategoriePratiquant = categorie3,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 60,
					PoidsMaxi = 65
                };
				CombatsMinimesMasculin6.Nom = BuildEpreuveName(CombatsMinimesMasculin6);

				var CombatsMinimesMasculin7 = new EpreuveCombat
				{
					CategoriePratiquant = categorie3,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 65,
					PoidsMaxi = 1000
                };
				CombatsMinimesMasculin7.Nom = BuildEpreuveName(CombatsMinimesMasculin7);

				#endregion

				#region Combats Minimes Feminin
				var CombatsMinimesFeminin1 = new EpreuveCombat
				{
					CategoriePratiquant = categorie3,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 40
                };
				CombatsMinimesFeminin1.Nom = BuildEpreuveName(CombatsMinimesFeminin1);

				var CombatsMinimesFeminin2 = new EpreuveCombat
				{
					CategoriePratiquant = categorie3,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 40,
					PoidsMaxi = 45
                };
				CombatsMinimesFeminin2.Nom = BuildEpreuveName(CombatsMinimesFeminin2);

				var CombatsMinimesFeminin3 = new EpreuveCombat
				{
					CategoriePratiquant = categorie3,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 45,
					PoidsMaxi = 50
                };
				CombatsMinimesFeminin3.Nom = BuildEpreuveName(CombatsMinimesFeminin3);

				var CombatsMinimesFeminin4 = new EpreuveCombat
				{
					CategoriePratiquant = categorie3,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 50,
					PoidsMaxi = 55
                };
				CombatsMinimesFeminin4.Nom = BuildEpreuveName(CombatsMinimesFeminin4);

				var CombatsMinimesFeminin5 = new EpreuveCombat
				{
					CategoriePratiquant = categorie3,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.TousGrades,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 55,
					PoidsMaxi = 1000
                };
				CombatsMinimesFeminin5.Nom = BuildEpreuveName(CombatsMinimesFeminin5);
				#endregion

				#region Combats Cadets Masculin
				var CombatsCadetsMasculin1 = new EpreuveCombat
				{
					CategoriePratiquant = categorie4,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 52
                };
				CombatsCadetsMasculin1.Nom = BuildEpreuveName(CombatsCadetsMasculin1);
				var CombatsCadetsMasculin2 = new EpreuveCombat
				{
					CategoriePratiquant = categorie4,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 52,
					PoidsMaxi = 57
                };
				CombatsCadetsMasculin2.Nom = BuildEpreuveName(CombatsCadetsMasculin2);
				var CombatsCadetsMasculin3 = new EpreuveCombat
				{
					CategoriePratiquant = categorie4,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 57,
					PoidsMaxi = 63
                };
				CombatsCadetsMasculin3.Nom = BuildEpreuveName(CombatsCadetsMasculin3);

				var CombatsCadetsMasculin4 = new EpreuveCombat
				{
					CategoriePratiquant = categorie4,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 63,
					PoidsMaxi = 70
                };
				CombatsCadetsMasculin4.Nom = BuildEpreuveName(CombatsCadetsMasculin4);

				var CombatsCadetsMasculin5 = new EpreuveCombat
				{
					CategoriePratiquant = categorie4,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 70,
					PoidsMaxi = 1000
                };
				CombatsCadetsMasculin5.Nom = BuildEpreuveName(CombatsCadetsMasculin5);

				var CombatsCadetsMasculin6 = new EpreuveCombat
				{
					CategoriePratiquant = categorie4,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 52
                };
				CombatsCadetsMasculin6.Nom = BuildEpreuveName(CombatsCadetsMasculin6);

				var CombatsCadetsMasculin7 = new EpreuveCombat
				{
					CategoriePratiquant = categorie4,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 52,
					PoidsMaxi = 57
                };
				CombatsCadetsMasculin7.Nom = BuildEpreuveName(CombatsCadetsMasculin7);

				var CombatsCadetsMasculin8 = new EpreuveCombat
				{
					CategoriePratiquant = categorie4,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 57,
					PoidsMaxi = 63
                };
				CombatsCadetsMasculin8.Nom = BuildEpreuveName(CombatsCadetsMasculin8);

				var CombatsCadetsMasculin9 = new EpreuveCombat
				{
					CategoriePratiquant = categorie4,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 63,
					PoidsMaxi = 70
                };
				CombatsCadetsMasculin9.Nom = BuildEpreuveName(CombatsCadetsMasculin9);

				var CombatsCadetsMasculin10 = new EpreuveCombat
				{
					CategoriePratiquant = categorie4,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 70,
					PoidsMaxi = 1000
                };
				CombatsCadetsMasculin10.Nom = BuildEpreuveName(CombatsCadetsMasculin10);
				#endregion

				#region Combats Cadets Féminin
				var CombatsCadetsFeminin1 = new EpreuveCombat
				{
					CategoriePratiquant = categorie4,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 47
                };
				CombatsCadetsFeminin1.Nom = BuildEpreuveName(CombatsCadetsFeminin1);

				var CombatsCadetsFeminin2 = new EpreuveCombat
				{
					CategoriePratiquant = categorie4,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 47,
					PoidsMaxi = 54
                };
				CombatsCadetsFeminin2.Nom = BuildEpreuveName(CombatsCadetsFeminin2);

				var CombatsCadetsFeminin3 = new EpreuveCombat
				{
					CategoriePratiquant = categorie4,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 54,
					PoidsMaxi = 1000
                };
				CombatsCadetsFeminin3.Nom = BuildEpreuveName(CombatsCadetsFeminin3);

				var CombatsCadetsFeminin4 = new EpreuveCombat
				{
					CategoriePratiquant = categorie4,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 47
                };
				CombatsCadetsFeminin4.Nom = BuildEpreuveName(CombatsCadetsFeminin4);

				var CombatsCadetsFeminin5 = new EpreuveCombat
				{
					CategoriePratiquant = categorie4,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 47,
					PoidsMaxi = 54
                };
				CombatsCadetsFeminin5.Nom = BuildEpreuveName(CombatsCadetsFeminin5);

				var CombatsCadetsFeminin6 = new EpreuveCombat
				{
					CategoriePratiquant = categorie4,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 54,
					PoidsMaxi = 1000
                };
				CombatsCadetsFeminin6.Nom = BuildEpreuveName(CombatsCadetsFeminin6);
				#endregion

				#region Combats Juniors Masculin
				var CombatsJuniorsMasculin1 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 55
                };
				CombatsJuniorsMasculin1.Nom = BuildEpreuveName(CombatsJuniorsMasculin1);
				var CombatsJuniorsMasculin2 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 55,
					PoidsMaxi = 61
                };
				CombatsJuniorsMasculin2.Nom = BuildEpreuveName(CombatsJuniorsMasculin2);
				var CombatsJuniorsMasculin3 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 61,
					PoidsMaxi = 68
                };
				CombatsJuniorsMasculin3.Nom = BuildEpreuveName(CombatsJuniorsMasculin3);

				var CombatsJuniorsMasculin4 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 68,
					PoidsMaxi = 76
                };
				CombatsJuniorsMasculin4.Nom = BuildEpreuveName(CombatsJuniorsMasculin4);

				var CombatsJuniorsMasculin5 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 76,
					PoidsMaxi = 1000
                };
				CombatsJuniorsMasculin5.Nom = BuildEpreuveName(CombatsJuniorsMasculin5);

				var CombatsJuniorsMasculin6 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 55
                };
				CombatsJuniorsMasculin6.Nom = BuildEpreuveName(CombatsJuniorsMasculin6);

				var CombatsJuniorsMasculin7 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 55,
					PoidsMaxi = 61
                };
				CombatsJuniorsMasculin7.Nom = BuildEpreuveName(CombatsJuniorsMasculin7);

				var CombatsJuniorsMasculin8 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 61,
					PoidsMaxi = 68
                };
				CombatsJuniorsMasculin8.Nom = BuildEpreuveName(CombatsJuniorsMasculin8);

				var CombatsJuniorsMasculin9 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 68,
					PoidsMaxi = 76
                };
				CombatsJuniorsMasculin9.Nom = BuildEpreuveName(CombatsJuniorsMasculin9);

				var CombatsJuniorsMasculin10 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 76,
					PoidsMaxi = 1000
                };
				CombatsJuniorsMasculin10.Nom = BuildEpreuveName(CombatsJuniorsMasculin10);
				#endregion

				#region Combats Juniors Feminin
				var CombatsJuniorsFeminin1 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 48
                };
				CombatsJuniorsFeminin1.Nom = BuildEpreuveName(CombatsJuniorsFeminin1);
				var CombatsJuniorsFeminin2 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 48,
					PoidsMaxi = 53
                };
				CombatsJuniorsFeminin2.Nom = BuildEpreuveName(CombatsJuniorsFeminin2);
				var CombatsJuniorsFeminin3 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 53,
					PoidsMaxi = 59
                };
				CombatsJuniorsFeminin3.Nom = BuildEpreuveName(CombatsJuniorsFeminin3);

				var CombatsJuniorsFeminin4 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 59,
					PoidsMaxi = 1000
                };
				CombatsJuniorsFeminin4.Nom = BuildEpreuveName(CombatsJuniorsFeminin4);                

				var CombatsJuniorsFeminin6 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 48
                };
				CombatsJuniorsFeminin6.Nom = BuildEpreuveName(CombatsJuniorsFeminin6);

				var CombatsJuniorsFeminin7 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 48,
					PoidsMaxi = 53
                };
				CombatsJuniorsFeminin7.Nom = BuildEpreuveName(CombatsJuniorsFeminin7);

				var CombatsJuniorsFeminin8 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 53,
					PoidsMaxi = 59
                };
				CombatsJuniorsFeminin8.Nom = BuildEpreuveName(CombatsJuniorsFeminin8);

				var CombatsJuniorsFeminin9 = new EpreuveCombat
				{
					CategoriePratiquant = categorie5,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 59,
					PoidsMaxi = 1000
                };
				CombatsJuniorsFeminin9.Nom = BuildEpreuveName(CombatsJuniorsFeminin9);                
				#endregion

				#region Combats Seniors Masculin
				var CombatsSeniorsMasculin1 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 60
                };
				CombatsSeniorsMasculin1.Nom = BuildEpreuveName(CombatsSeniorsMasculin1);
				var CombatsSeniorsMasculin2 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 60,
					PoidsMaxi = 67
                };
				CombatsSeniorsMasculin2.Nom = BuildEpreuveName(CombatsSeniorsMasculin2);
				var CombatsSeniorsMasculin3 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 67,
					PoidsMaxi = 75
                };
				CombatsSeniorsMasculin3.Nom = BuildEpreuveName(CombatsSeniorsMasculin3);

				var CombatsSeniorsMasculin4 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 75,
					PoidsMaxi = 84
                };
				CombatsSeniorsMasculin4.Nom = BuildEpreuveName(CombatsSeniorsMasculin4);

				var CombatsSeniorsMasculin5 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 84,
					PoidsMaxi = 1000
                };
				CombatsSeniorsMasculin5.Nom = BuildEpreuveName(CombatsSeniorsMasculin5);

				var CombatsSeniorsMasculin6 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 60
                };
				CombatsSeniorsMasculin6.Nom = BuildEpreuveName(CombatsSeniorsMasculin6);

				var CombatsSeniorsMasculin7 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 60,
					PoidsMaxi = 67
                };
				CombatsSeniorsMasculin7.Nom = BuildEpreuveName(CombatsSeniorsMasculin7);

				var CombatsSeniorsMasculin8 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 67,
					PoidsMaxi = 75
                };
				CombatsSeniorsMasculin8.Nom = BuildEpreuveName(CombatsSeniorsMasculin8);

				var CombatsSeniorsMasculin9 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 75,
					PoidsMaxi = 84
                };
				CombatsSeniorsMasculin9.Nom = BuildEpreuveName(CombatsSeniorsMasculin9);

				var CombatsSeniorsMasculin10 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 84,
					PoidsMaxi = 1000
                };
				CombatsSeniorsMasculin10.Nom = BuildEpreuveName(CombatsSeniorsMasculin10);
				#endregion

				#region Combats Seniors Feminin
				var CombatsSeniorsFeminin1 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 50
                };
				CombatsSeniorsFeminin1.Nom = BuildEpreuveName(CombatsSeniorsFeminin1);
				var CombatsSeniorsFeminin2 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 50,
					PoidsMaxi = 55
                };
				CombatsSeniorsFeminin2.Nom = BuildEpreuveName(CombatsSeniorsFeminin2);
				var CombatsSeniorsFeminin3 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 55,
					PoidsMaxi = 61
                };
				CombatsSeniorsFeminin3.Nom = BuildEpreuveName(CombatsSeniorsFeminin3);

				var CombatsSeniorsFeminin4 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 61,
					PoidsMaxi = 68
                };
				CombatsSeniorsFeminin4.Nom = BuildEpreuveName(CombatsSeniorsFeminin4);

				var CombatsSeniorsFeminin5 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 68,
					PoidsMaxi = 1000
                };
				CombatsSeniorsFeminin5.Nom = BuildEpreuveName(CombatsSeniorsFeminin5);

				var CombatsSeniorsFeminin6 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 50
                };
				CombatsSeniorsFeminin6.Nom = BuildEpreuveName(CombatsSeniorsFeminin6);

				var CombatsSeniorsFeminin7 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 50,
					PoidsMaxi = 55
                };
				CombatsSeniorsFeminin7.Nom = BuildEpreuveName(CombatsSeniorsFeminin7);

				var CombatsSeniorsFeminin8 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 55,
					PoidsMaxi = 61
                };
				CombatsSeniorsFeminin8.Nom = BuildEpreuveName(CombatsSeniorsFeminin8);

				var CombatsSeniorsFeminin9 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 61,
					PoidsMaxi = 68
                };
				CombatsSeniorsFeminin9.Nom = BuildEpreuveName(CombatsSeniorsFeminin9);

				var CombatsSeniorsFeminin10 = new EpreuveCombat
				{
					CategoriePratiquant = categorie6,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 68,
					PoidsMaxi = 1000
                };
				CombatsSeniorsFeminin10.Nom = BuildEpreuveName(CombatsSeniorsFeminin10);
				#endregion

				#region Combats Veterans Masculin
				var CombatsVeteransMasculin1 = new EpreuveCombat
				{
					CategoriePratiquant = categorie7,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 67
                };
				CombatsVeteransMasculin1.Nom = BuildEpreuveName(CombatsVeteransMasculin1);
				var CombatsVeteransMasculin2 = new EpreuveCombat
				{
					CategoriePratiquant = categorie7,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 67,
					PoidsMaxi = 75
                };
				CombatsVeteransMasculin2.Nom = BuildEpreuveName(CombatsVeteransMasculin2);
				var CombatsVeteransMasculin3 = new EpreuveCombat
				{
					CategoriePratiquant = categorie7,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 75,
					PoidsMaxi = 84
                };
				CombatsVeteransMasculin3.Nom = BuildEpreuveName(CombatsVeteransMasculin3);

				var CombatsVeteransMasculin4 = new EpreuveCombat
				{
					CategoriePratiquant = categorie7,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 84,
					PoidsMaxi = 1000
                };
				CombatsVeteransMasculin4.Nom = BuildEpreuveName(CombatsVeteransMasculin4);

				var CombatsVeteransMasculin6 = new EpreuveCombat
				{
					CategoriePratiquant = categorie7,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 67
                };
				CombatsVeteransMasculin6.Nom = BuildEpreuveName(CombatsVeteransMasculin6);

				var CombatsVeteransMasculin7 = new EpreuveCombat
				{
					CategoriePratiquant = categorie7,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 67,
					PoidsMaxi = 75
                };
				CombatsVeteransMasculin7.Nom = BuildEpreuveName(CombatsVeteransMasculin7);

				var CombatsVeteransMasculin8 = new EpreuveCombat
				{
					CategoriePratiquant = categorie7,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 75,
					PoidsMaxi = 84
                };
				CombatsVeteransMasculin8.Nom = BuildEpreuveName(CombatsVeteransMasculin8);

				var CombatsVeteransMasculin9 = new EpreuveCombat
				{
					CategoriePratiquant = categorie7,
					GenreCategorie = GenreEpreuve.Masculin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 84,
					PoidsMaxi = 1000
                };
				CombatsVeteransMasculin9.Nom = BuildEpreuveName(CombatsVeteransMasculin9);
				#endregion

				#region Combats Veterans Feminin
				var CombatsVeteransFeminin1 = new EpreuveCombat
				{
					CategoriePratiquant = categorie7,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 55
                };
				CombatsVeteransFeminin1.Nom = BuildEpreuveName(CombatsVeteransFeminin1);
				var CombatsVeteransFeminin2 = new EpreuveCombat
				{
					CategoriePratiquant = categorie7,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 55,
					PoidsMaxi = 61
                };
				CombatsVeteransFeminin2.Nom = BuildEpreuveName(CombatsVeteransFeminin2);
				var CombatsVeteransFeminin3 = new EpreuveCombat
				{
					CategoriePratiquant = categorie7,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 61,
					PoidsMaxi = 68
                };
				CombatsVeteransFeminin3.Nom = BuildEpreuveName(CombatsVeteransFeminin3);

				var CombatsVeteransFeminin4 = new EpreuveCombat
				{
					CategoriePratiquant = categorie7,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.MoinsDeCeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 68,
					PoidsMaxi = 1000
                };
				CombatsVeteransFeminin4.Nom = BuildEpreuveName(CombatsVeteransFeminin4);

				var CombatsVeteransFeminin6 = new EpreuveCombat
				{
					CategoriePratiquant = categorie7,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 0,
					PoidsMaxi = 55
                };
				CombatsVeteransFeminin6.Nom = BuildEpreuveName(CombatsVeteransFeminin6);

				var CombatsVeteransFeminin7 = new EpreuveCombat
				{
					CategoriePratiquant = categorie7,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 55,
					PoidsMaxi = 61
                };
				CombatsVeteransFeminin7.Nom = BuildEpreuveName(CombatsVeteransFeminin7);

				var CombatsVeteransFeminin8 = new EpreuveCombat
				{
					CategoriePratiquant = categorie7,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 61,
					PoidsMaxi = 68
                };
				CombatsVeteransFeminin8.Nom = BuildEpreuveName(CombatsVeteransFeminin8);

				var CombatsVeteransFeminin9 = new EpreuveCombat
				{
					CategoriePratiquant = categorie7,
					GenreCategorie = GenreEpreuve.Feminin,
					GradeAutorise = Grade.CeintureNoire,
					Statut = StatutEpreuve.Fermee,
					TypeEpreuve = typeEpreuve4,
					PoidsMini = 68,
					PoidsMaxi = 1000
                };
				CombatsVeteransFeminin9.Nom = BuildEpreuveName(CombatsVeteransFeminin9);
                #endregion

                this.context.Entry(color1).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(color2).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(color3).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(color4).State = System.Data.Entity.EntityState.Added;

                this.context.Entry(clienttype1).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(clienttype2).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(clienttype3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(clienttype4).State = System.Data.Entity.EntityState.Added;

				this.context.Entry(netclient).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(pc1).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(pc2).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(pc3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(netclient3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(netclient4).State = System.Data.Entity.EntityState.Added;

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

				this.context.Entry(s7).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(s8).State = System.Data.Entity.EntityState.Added;

                this.context.Entry(qdd7).State = System.Data.Entity.EntityState.Added;
                this.context.Entry(qdd8).State = System.Data.Entity.EntityState.Added;

                this.context.Entry(CombatsPupillesMasculin1).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsPupillesMasculin2).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsPupillesMasculin3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsPupillesMasculin4).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsPupillesMasculin5).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsPupillesMasculin6).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsPupillesMasculin7).State = System.Data.Entity.EntityState.Added;

				this.context.Entry(CombatsBenjaminsMasculin1).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsBenjaminsMasculin2).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsBenjaminsMasculin3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsBenjaminsMasculin4).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsBenjaminsMasculin5).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsBenjaminsMasculin6).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsBenjaminsMasculin7).State = System.Data.Entity.EntityState.Added;

				this.context.Entry(CombatsMinimesMasculin1).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsMinimesMasculin2).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsMinimesMasculin3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsMinimesMasculin4).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsMinimesMasculin5).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsMinimesMasculin6).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsMinimesMasculin7).State = System.Data.Entity.EntityState.Added;

				this.context.Entry(CombatsCadetsMasculin1).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsCadetsMasculin2).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsCadetsMasculin3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsCadetsMasculin4).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsCadetsMasculin5).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsCadetsMasculin6).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsCadetsMasculin7).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsCadetsMasculin8).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsCadetsMasculin9).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsCadetsMasculin10).State = System.Data.Entity.EntityState.Added;

				this.context.Entry(CombatsJuniorsMasculin1).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsJuniorsMasculin2).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsJuniorsMasculin3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsJuniorsMasculin4).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsJuniorsMasculin5).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsJuniorsMasculin6).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsJuniorsMasculin7).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsJuniorsMasculin8).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsJuniorsMasculin9).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsJuniorsMasculin10).State = System.Data.Entity.EntityState.Added;

				this.context.Entry(CombatsSeniorsMasculin1).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsMasculin2).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsMasculin3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsMasculin4).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsMasculin5).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsMasculin6).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsMasculin7).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsMasculin8).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsMasculin9).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsMasculin10).State = System.Data.Entity.EntityState.Added;

				this.context.Entry(CombatsVeteransMasculin1).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsVeteransMasculin2).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsVeteransMasculin3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsVeteransMasculin4).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsVeteransMasculin6).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsVeteransMasculin7).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsVeteransMasculin8).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsVeteransMasculin9).State = System.Data.Entity.EntityState.Added;

				this.context.Entry(CombatsPupillesFeminin1).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsPupillesFeminin2).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsPupillesFeminin3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsPupillesFeminin4).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsPupillesFeminin5).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsPupillesFeminin6).State = System.Data.Entity.EntityState.Added;

				this.context.Entry(CombatsBenjaminsFeminin1).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsBenjaminsFeminin2).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsBenjaminsFeminin3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsBenjaminsFeminin4).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsBenjaminsFeminin5).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsBenjaminsFeminin6).State = System.Data.Entity.EntityState.Added;

				this.context.Entry(CombatsMinimesFeminin1).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsMinimesFeminin2).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsMinimesFeminin3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsMinimesFeminin4).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsMinimesFeminin5).State = System.Data.Entity.EntityState.Added;

				this.context.Entry(CombatsCadetsFeminin1).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsCadetsFeminin2).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsCadetsFeminin3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsCadetsFeminin4).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsCadetsFeminin5).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsCadetsFeminin6).State = System.Data.Entity.EntityState.Added;               

				this.context.Entry(CombatsJuniorsFeminin1).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsJuniorsFeminin2).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsJuniorsFeminin3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsJuniorsFeminin4).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsJuniorsFeminin6).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsJuniorsFeminin7).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsJuniorsFeminin8).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsJuniorsFeminin9).State = System.Data.Entity.EntityState.Added;

				this.context.Entry(CombatsSeniorsFeminin1).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsFeminin2).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsFeminin3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsFeminin4).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsFeminin5).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsFeminin6).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsFeminin7).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsFeminin8).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsFeminin9).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsSeniorsFeminin10).State = System.Data.Entity.EntityState.Added;

				this.context.Entry(CombatsVeteransFeminin1).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsVeteransFeminin2).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsVeteransFeminin3).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsVeteransFeminin4).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsVeteransFeminin6).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsVeteransFeminin7).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsVeteransFeminin8).State = System.Data.Entity.EntityState.Added;
				this.context.Entry(CombatsVeteransFeminin9).State = System.Data.Entity.EntityState.Added;    

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

		private static string BuildEpreuveName(EpreuveCombat model)
		{
			var nom = string.Empty;

			if (model.PoidsMini == 0)
			{
				nom = string.Format("{0} {1} {2} {3} -{4} kgs", 
					model.TypeEpreuve.Nom, 
					model.CategoriePratiquant.Nom,
					GenreEpreuves.ResourceManager.GetString(model.GenreCategorie.ToString(), CultureInfo.InvariantCulture), 
					Grades.ResourceManager.GetString(model.GradeAutorise.ToString()), 
					model.PoidsMaxi);
			}
			else if (model.PoidsMaxi == 1000)
			{
				nom = string.Format("{0} {1} {2} {3} +{4} kgs",
					model.TypeEpreuve.Nom,
					model.CategoriePratiquant.Nom,
					GenreEpreuves.ResourceManager.GetString(model.GenreCategorie.ToString(), CultureInfo.InvariantCulture),
					Grades.ResourceManager.GetString(model.GradeAutorise.ToString()),
					model.PoidsMini);
			}
			else
			{
				nom = string.Format("{0} {1} {2} {3} {4} kgs à {5} kgs",
					model.TypeEpreuve.Nom,
					model.CategoriePratiquant.Nom,
					GenreEpreuves.ResourceManager.GetString(model.GenreCategorie.ToString(), CultureInfo.InvariantCulture),
					Grades.ResourceManager.GetString(model.GradeAutorise.ToString()),
					model.PoidsMini,
					model.PoidsMaxi);
			}
			return nom;
		}
	}
}
