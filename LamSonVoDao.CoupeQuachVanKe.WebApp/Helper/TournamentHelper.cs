using LamSonVoDao.CoupeQuachVanKe.WebApp.Models.Coupe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace LamSonVoDao.CoupeQuachVanKe.WebApp.Helper
{
    public static class TournamentHelper
    {
        public static List<ParticipationCombatModel> BuildTree(IEnumerable<ParticipationCombatModel> shuffledCompetiteurs)
        {
            var result = new List<ParticipationCombatModel>();
            var temps = new List<ParticipationCombatModel>();
            foreach (var item in shuffledCompetiteurs.OrderBy(c => Guid.NewGuid()))
            {
                temps.Add(item);
            }
            result.Add(TournamentHelper.BuildNode(temps, true, "#ffd700", RankContest.Vainqueur));

            return result;
        }

        private static ParticipationCombatModel BuildNode(IEnumerable<ParticipationCombatModel> shuffledCompetiteurs, bool left, string color, RankContest rank)
        {
            var nextRank = (RankContest)((int)rank + 1);
            Random rnd = new Random();
            if (shuffledCompetiteurs.Count() == 2)
            {
                return new ParticipationCombatModel
                {
                    Id = rnd.Next(1, int.MaxValue),
                    Children = new List<ParticipationCombatModel>(){
                        CloneParticipant(shuffledCompetiteurs.ElementAt(0), "#0000FF", nextRank),
                        CloneParticipant(shuffledCompetiteurs.ElementAt(1), "#FF0000", nextRank),
                    },
                    Couleur = color,
                    Rank = rank
                };
            }
            if (shuffledCompetiteurs.Count() == 1)
            {
                return CloneParticipant(shuffledCompetiteurs.FirstOrDefault(), color, rank); ;
            }

            var contestantsCount = shuffledCompetiteurs.Count();

            if (contestantsCount % 2 == 0) //even
            {
                var t1 = shuffledCompetiteurs.Take(contestantsCount / 2).ToList();
                var t2 = shuffledCompetiteurs.Skip(contestantsCount / 2).ToList();
                return new ParticipationCombatModel()
                {
                    Id = rnd.Next(1, int.MaxValue),
                    Children = new List<ParticipationCombatModel>(){
                        BuildNode(t1, left, "#0000FF", nextRank),
                        BuildNode(t2, left, "#FF0000", nextRank)
                    },
                    Couleur = color,
                    Rank = rank
                };
            }
            else //odd
            {
                if (left)
                {
                    var count = (int)(contestantsCount / 2) + 1;
                    var t1 = shuffledCompetiteurs.Take(count).ToList();
                    var t2 = shuffledCompetiteurs.Skip(count).ToList();
                    return new ParticipationCombatModel()
                    {

                        Id = rnd.Next(1, int.MaxValue),
                        Children = new List<ParticipationCombatModel>()
                        {
                            BuildNode(t1, !left, "#0000FF", nextRank),
                            BuildNode(t2, !left, "#FF0000", nextRank)
                        },
                        Couleur = color,
                        Rank = rank
                    };
                }
                else
                {
                    var count = (int)(contestantsCount / 2);
                    var t1 = shuffledCompetiteurs.Take(count).ToList();
                    var t2 = shuffledCompetiteurs.Skip(count).ToList();


                    return new ParticipationCombatModel()
                    {

                        Id = rnd.Next(1, int.MaxValue),
                        Children = new List<ParticipationCombatModel>(){
                            BuildNode(t1, left, "#0000FF", nextRank),
                            BuildNode(t2, left, "#FF0000", nextRank)
                        },
                        Couleur = color,
                        Rank = rank
                    };
                }
            }
        }

        private static ParticipationCombatModel CloneParticipant(ParticipationCombatModel participationCombatModel, string color, RankContest rank)
        {
            Console.WriteLine(participationCombatModel.Nom);
            return new ParticipationCombatModel
            {
                Club = participationCombatModel.Club,
                ClubId = participationCombatModel.ClubId,
                CategoriePratiquantId = participationCombatModel.CategoriePratiquantId,
                Couleur = color,
                EpreuveId = participationCombatModel.EpreuveId,
                Id = participationCombatModel.Id,
                Nom = participationCombatModel.Nom,
                ParticipantId = participationCombatModel.ParticipantId,
                Prenom = participationCombatModel.Prenom,
                Present = participationCombatModel.Present,
                Vainqueur = null,
                Rank = rank
            };
        }

        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> items, Func<T, IEnumerable<T>> getChildren)
        {
            var stack = new Stack<T>();
            foreach (var item in items)
                stack.Push(item);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current;
                var children = getChildren(current);
                if (children != null)
                {
                    foreach (var child in children) stack.Push(child);
                }
            }
        }

        public static IEnumerable<MatchPairModel> BuildRounds(IOrderedEnumerable<ParticipationCombatModel> competiteurs, int roundNumber = 2)
        {
            var list = new List<MatchPairModel>();
            var copy = competiteurs.ToList();
            int fightNumber = 1;
            if (copy.Count == 2)
            {
                list.Add(new MatchPairModel
               {
                   Blue = copy[0],
                   Red = copy[1],
                   Rencontre = "Rencontre 1"
               });
                return list;
            }

            if (copy.Count == 3)
            {
                list.Add(new MatchPairModel
                {
                    Blue = copy[0],
                    Red = copy[1],
                    Rencontre = "Rencontre 1"
                });
                list.Add(new MatchPairModel
                {
                    Blue = copy[1],
                    Red = copy[2],
                    Rencontre = "Rencontre 2"
                });
                list.Add(new MatchPairModel
                {
                    Blue = copy[0],
                    Red = copy[2],
                    Rencontre = "Rencontre 3"
                });
                return list;
            }

            var countIsEven = copy.Count % 2 == 0;
            int neededCall = countIsEven ? copy.Count / 2 : (copy.Count - 1) / 2;

            var blues = copy.Take(neededCall).ToList();
            var reds = copy.Skip(neededCall).Take(neededCall).Reverse().ToList();
            List<ParticipationCombatModel> deadMenWaiting = new List<ParticipationCombatModel>();
            ParticipationCombatModel excluded = countIsEven ? null : copy.Last();

            for (int i = 0; i < roundNumber; i++)
            {

                //Pairing
                for (int j = 0; j < neededCall; j++)
                {
                    list.Add(new MatchPairModel
                    {
                        Blue = blues[j],
                        Red = reds[j],
                        Rencontre = string.Format("Rencontre {0}", fightNumber)
                    });
                    fightNumber++;
                }

                //Building from alone players
                if (!countIsEven)
                {
                    if (deadMenWaiting.Count == 0)
                    {
                        deadMenWaiting.Add(excluded);
                    }
                    else
                    {
                        list.Add(new MatchPairModel
                        {
                            Blue = deadMenWaiting[0],
                            Red = excluded,
                            Rencontre = string.Format("Rencontre {0}", fightNumber)
                        });
                        fightNumber++;
                        deadMenWaiting.Clear();
                    }

                    //Shifting reds and blues
                    reds.Add(excluded);
                    excluded = blues.Last();
                    blues.Insert(1, reds.First());
                    reds.RemoveAt(0);
                    blues.RemoveAt(blues.Count - 1);
                }
                else
                {
                    reds.Add(blues.Last());
                    blues.Insert(1, reds.First());
                    reds.RemoveAt(0);
                    blues.RemoveAt(blues.Count - 1);
                }
            }

            return list;
        }
    }


}