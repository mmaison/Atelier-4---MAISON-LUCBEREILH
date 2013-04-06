using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SoccerRankingLib;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace WpfFrenchChampionship.ViewModel
{
    public class MatchListViewModel : ViewModel
    {
        private ObservableCollection<Match>matches;
        private Ranking ranking;

        public ObservableCollection<Match> Matches
        {
            get
            {
                return this.matches;
            }
        }

        public MatchListViewModel(Ranking ranking)
        {
            this.matches = new ObservableCollection<Match>();
            this.ranking = ranking;
            this.ranking.NewMatchRegistered += new EventHandler<Ranking.MatchRegistrationEventArgs>(_ranking_NewMatchRegistered);
        }

       public void _ranking_NewMatchRegistered(object sender, Ranking.MatchRegistrationEventArgs e)
        {
            Match newMatch = new Match(e.NewMatch.Home, e.NewMatch.Away, e.NewMatch.HomeGoals, e.NewMatch.AwayGoals);
            this.matches.Add(newMatch);
            RaisePropertyChanged("Matches");
        }

       
    }
}