using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DesignPattern.Fabrique;
using DesignPattern.Objet;
using DesignPattern.Observer;
using DesignPattern.Simulation;

namespace DesignPattern
{
    /// <summary>
    ///     Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly List<Image> _listImage;
        private readonly List<Image> _listImage2;
        private readonly List<ObservateurAbstrait> _observateurList = new List<ObservateurAbstrait>();
        private SimulationJeu _simulation;


        public MainWindow()
        {
            InitializeComponent();

            ShowWindow();

            _listImage = new List<Image>();
            _listImage2 = new List<Image>();
        }

        /// <summary>
        ///     Création des grilles de jeux
        /// </summary>
        public void ShowWindow()
        {
            //Grille principale
            for (var i = 0; i < 10; i++)
            {
                GridGame.RowDefinitions.Add(new RowDefinition());
                GridGame.ColumnDefinitions.Add(new ColumnDefinition());
            }

            GridGame.Background.Opacity = 0.3;

            //Seconde grille
            GridGame2.RowDefinitions.Add(new RowDefinition());

            for (var i = 0; i < 5; i++)
            {
                GridGame2.ColumnDefinitions.Add(new ColumnDefinition());
            }

            GridGame2.Background.Opacity = 0.3;
        }


        public void Attach(ObservateurAbstrait observer)
        {
            _observateurList.Add(observer);
        }

        public void Detach(ObservateurAbstrait observer)
        {
            _observateurList.Remove(observer);
        }

        public void Notify()
        {
            foreach (var o in _observateurList)
            {
                o.MiseAjour();
            }
        }


        private int GetParamPlateau()
        {
            if (RbDeplacement.IsChecked == true) return 0;
            if (RbPortail.IsChecked == true) return 1;

            return 0;
        }

        private int GetParamPdv()
        {
            if (RbPdvHasard.IsChecked == true) return 0;
            if (RbPdvIdentique.IsChecked == true) return Int32.Parse(TbPdv.Text);
            if (RbPdvDefaut.IsChecked == true) return 1;

            return 0;
        }

        private int GetParamPosition()
        {
            if (RbPosHasard.IsChecked == true) return 0;
            if (RbPosIdentique.IsChecked == true) return 5;
            if (RbPosDefaut.IsChecked == true) return 1;

            return 0;
        }

        /// <summary>
        ///     Bouton de chargment d'une nouvelle partie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridGame.Children.Clear();
            GridGame2.Children.Clear();
            _simulation = SimulationJeu.Instance;
            _simulation.Initialisation(GetParamPlateau(), GetParamPdv(), GetParamPosition());
            //simulation = new SimulationJeu(GetParamPlateau(), GetParamPdv(), GetParamPosition());

            if (GetParamPlateau() == 1)
            {
                foreach (var i in _simulation.Plateaufinal.ItemList)
                {
                    if (i is Goal)
                    {
                        i.Position.row = 0;
                        i.Position.column = 4;
                    }
                    else if (i is Portail)
                    {
                        i.Position.row = 0;
                        i.Position.column = 0;
                    }

                    Grid.SetRow(i.Avatar, i.Position.row);
                    Grid.SetColumn(i.Avatar, i.Position.column);
                    GridGame2.Children.Remove(i.Avatar);
                    GridGame2.Children.Add(i.Avatar);
                }
            }

            foreach (var p in _simulation.Plateau.PersonnageList)
            {
                var imgBack = new Image();
                imgBack.Source = new BitmapImage(new Uri(@"pack://application:,,/image.jpg"));
                imgBack.Stretch = Stretch.Fill;

                Grid.SetRow(imgBack, p.Position.row);
                Grid.SetColumn(imgBack, p.Position.column);
                GridGame.Children.Remove(imgBack);
                GridGame.Children.Add(imgBack);

                _listImage.Add(imgBack);
                p.AnalyseSituation(_simulation.Plateau.ItemList, 9, 9);
                p.PointDeVie += 20;

                Grid.SetRow(p.Avatar, p.Position.row);
                Grid.SetColumn(p.Avatar, p.Position.column);
                GridGame.Children.Remove(p.Avatar);
                GridGame.Children.Add(p.Avatar);


                foreach (var zoneAbstrait in p.ZoneAcessibleList)
                {
                    var z = (Zone) zoneAbstrait;
                    var imgZa = new Image();
                    imgZa.Source = new BitmapImage(new Uri(@"pack://application:,,/image.jpg"));
                    imgZa.Stretch = Stretch.Fill;

                    Grid.SetRow(imgZa, z.row);
                    Grid.SetColumn(imgZa, z.column);
                    GridGame.Children.Remove(imgZa);
                    GridGame.Children.Add(imgZa);

                    _listImage.Add(imgZa);
                }

                if (typeof (Fantassin) == p.GetType())
                    LblVie1.Content = p.PointDeVie.ToString(CultureInfo.InvariantCulture);
                else if (typeof (Archer) == p.GetType())
                    LblVie2.Content = p.PointDeVie.ToString(CultureInfo.InvariantCulture);
            }

            foreach (var i in _simulation.Plateau.ItemList)
            {
                if (i is Goal)
                {
                    i.Position.row = 8;
                    i.Position.column = 8;
                }
                else if (i is PotionVie)
                {
                    i.Position.row = 4;
                    i.Position.column = 5;
                }

                Grid.SetRow(i.Avatar, i.Position.row);
                Grid.SetColumn(i.Avatar, i.Position.column);
                GridGame.Children.Remove(i.Avatar);
                GridGame.Children.Add(i.Avatar);
            }
        }

        /// <summary>
        ///     Bouton de tour suivant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Mise à jour des images du plateau
            foreach (var image in _listImage)
            {
                GridGame.Children.Remove(image);
            }
            _listImage.Clear();
            
            foreach (var image in _listImage2)
            {
                GridGame2.Children.Remove(image);
            }
            _listImage2.Clear();

            foreach (var p in _simulation.Plateaufinal.PersonnageList)
            {
                
                // Changement d'état et observer
                var obs = new Observateur(p, "Passe à l'action");
                Attach(obs);
                p.Execution();
                Notify();
                Detach(obs);

                if (p.EstMort == false && p.EtatCourant is EtatEnAction)
                {
                    //traitement visuel xaml
                    var imgBack = new Image();
                    imgBack.Source = new BitmapImage(new Uri(@"pack://application:,,/image.jpg"));
                    imgBack.Stretch = Stretch.Fill;

                    p.SeDeplacer();
                    bool verif = p.AnalyseSituation(_simulation.Plateaufinal.ItemList, 0, 4);


                    Grid.SetRow(imgBack, p.Position.row);
                    Grid.SetColumn(imgBack, p.Position.column);
                    GridGame2.Children.Remove(imgBack);
                    GridGame2.Children.Add(imgBack);

                    _listImage2.Add(imgBack);

                    Grid.SetRow(p.Avatar, p.Position.row);
                    Grid.SetColumn(p.Avatar, p.Position.column);
                    GridGame2.Children.Remove(p.Avatar);
                    GridGame2.Children.Add(p.Avatar);

                    //Mise à jour des zones accessible
                    foreach (var zoneAbstrait in p.ZoneAcessibleList)
                    {
                        var z = (Zone)zoneAbstrait;
                        foreach (var item in _simulation.Plateaufinal.ItemList)
                        {
                            if ((item.Position.column == z.column) && (item.Position.row == z.row)) continue;
                            var imgZa = new Image();
                            imgZa.Source = new BitmapImage(new Uri(@"pack://application:,,/image.jpg"));
                            imgZa.Stretch = Stretch.Fill;

                            Grid.SetRow(imgZa, z.row);
                            Grid.SetColumn(imgZa, z.column);
                            GridGame2.Children.Remove(imgZa);
                            GridGame2.Children.Add(imgZa);

                            _listImage2.Add(imgZa);
                        }
                    }

                    //Mise à jour des points de vie
                    if (typeof(Chevalier) == p.GetType())
                        LblVie1.Content = p.PointDeVie.ToString(CultureInfo.InvariantCulture);
                    else if (typeof(Archer) == p.GetType())
                        LblVie2.Content = p.PointDeVie.ToString(CultureInfo.InvariantCulture);

                    foreach (var i in _simulation.Plateaufinal.ItemList)
                    {
                        if (i.Pris == false)
                        {
                            Grid.SetRow(i.Avatar, i.Position.row);
                            Grid.SetColumn(i.Avatar, i.Position.column);
                            GridGame2.Children.Remove(i.Avatar);
                            GridGame2.Children.Add(i.Avatar);
                        }
                        else
                        {
                            Grid.SetRow(i.Avatar, i.Position.row);
                            Grid.SetColumn(i.Avatar, i.Position.column);
                            GridGame2.Children.Remove(i.Avatar);
                        }
                    }

                    if (p.ObjectifAtteint) MessageBox.Show("GOAL");
                    if (p.EstMort) MessageBox.Show(p.Nom + " est GAME OVER");
                }

                Attach(obs);
                p.Execution();
                Notify();
                Detach(obs);
            }
            
            //Mise à jour des personnages
            foreach (var p in _simulation.Plateau.PersonnageList)
            {
                // Changement d'état et observer
                var obs = new Observateur(p, "Passe à l'action");
                Attach(obs);
                p.Execution();
                Notify();
                Detach(obs);

                if (p.EstMort == false && p.EtatCourant is EtatEnAction)
                {
                    //traitement visuel xaml
                    var imgBack = new Image();
                    imgBack.Source = new BitmapImage(new Uri(@"pack://application:,,/image.jpg"));
                    imgBack.Stretch = Stretch.Fill;
                    bool verif = false;
                    p.SeDeplacer();
                    verif = p.AnalyseSituation(_simulation.Plateau.ItemList, 9, 9);

                    

                    Grid.SetRow(imgBack, p.Position.row);
                    Grid.SetColumn(imgBack, p.Position.column);
                    GridGame.Children.Remove(imgBack);
                    GridGame.Children.Add(imgBack);

                    _listImage.Add(imgBack);

                    Grid.SetRow(p.Avatar, p.Position.row);
                    Grid.SetColumn(p.Avatar, p.Position.column);
                    GridGame.Children.Remove(p.Avatar);
                    GridGame.Children.Add(p.Avatar);

                    //Mise à jour des zones accessible
                    foreach (var zoneAbstrait in p.ZoneAcessibleList)
                    {
                        var z = (Zone) zoneAbstrait;
                        foreach (var item in _simulation.Plateau.ItemList)
                        {
                            if ((item.Position.column == z.column) && (item.Position.row == z.row)) continue;
                            var imgZa = new Image();
                            imgZa.Source = new BitmapImage(new Uri(@"pack://application:,,/image.jpg"));
                            imgZa.Stretch = Stretch.Fill;

                            Grid.SetRow(imgZa, z.row);
                            Grid.SetColumn(imgZa, z.column);
                            GridGame.Children.Remove(imgZa);
                            GridGame.Children.Add(imgZa);

                            _listImage.Add(imgZa);
                        }
                    }

                    //Mise à jour des points de vie
                    if (typeof (Chevalier) == p.GetType())
                        LblVie1.Content = p.PointDeVie.ToString(CultureInfo.InvariantCulture);
                    else if (typeof (Archer) == p.GetType())
                        LblVie2.Content = p.PointDeVie.ToString(CultureInfo.InvariantCulture);

                    foreach (var i in _simulation.Plateau.ItemList)
                    {
                        if (i.Pris == false)
                        {
                            Grid.SetRow(i.Avatar, i.Position.row);
                            Grid.SetColumn(i.Avatar, i.Position.column);
                            GridGame.Children.Remove(i.Avatar);
                            GridGame.Children.Add(i.Avatar);
                        }
                        else
                        {
                            Grid.SetRow(i.Avatar, i.Position.row);
                            Grid.SetColumn(i.Avatar, i.Position.column);
                            GridGame.Children.Remove(i.Avatar);
                        }
                    }

                    if (p.ObjectifAtteint) MessageBox.Show("GOAL");
                    if (p.EstMort) MessageBox.Show(p.Nom + " est GAME OVER");

                    if (verif)
                    {
                        p.Position = (Zone)_simulation.Plateaufinal.GetZoneList()[0];
                        _simulation.Plateaufinal.PersonnageList.Add(p);
                        _simulation.Plateau.PersonnageList.Remove(p);
                        

                        Grid.SetRow(p.Avatar, p.Position.row);
                        Grid.SetColumn(p.Avatar, p.Position.column);
                        GridGame.Children.Remove(p.Avatar);
                        GridGame2.Children.Add(p.Avatar);
                        p.AnalyseSituation(_simulation.Plateaufinal.ItemList, 0, 4);
                        
                        Attach(obs);
                        p.Execution();
                        Notify();
                        Detach(obs);
                        break;
                    }
                }

                Attach(obs);
                p.Execution();
                Notify();
                Detach(obs);
            }
        }
    }
}