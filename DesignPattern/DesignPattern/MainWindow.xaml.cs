﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DesignPattern.Fabrique;
using DesignPattern.Objet;
using DesignPattern.Observer;
using Wpf.Game.Simulation;

namespace DesignPattern
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SimulationJeu simulation;

        List<Image> ListImage;



        public MainWindow()
        {
            InitializeComponent();

            ShowWindow();

            ListImage = new List<Image>();
        }


        public void ShowWindow()
        {
            for (int i = 0; i < 10; i++)
            {
                Grid_Game.RowDefinitions.Add(new RowDefinition());
                Grid_Game.ColumnDefinitions.Add(new ColumnDefinition());
            }

            Grid_Game.Background.Opacity = 0.3;

            Grid_Game2.RowDefinitions.Add(new RowDefinition());
                
            for (int i = 0; i < 5; i++)
            {
                Grid_Game2.ColumnDefinitions.Add(new ColumnDefinition());
            }

            Grid_Game2.Background.Opacity = 0.3;


        }


        private readonly List<ObservateurAbstrait> observateurList = new List<ObservateurAbstrait>();

        public void Attach(ObservateurAbstrait observer)
        {
            observateurList.Add(observer);
        }

        public void Detach(ObservateurAbstrait observer)
        {
            observateurList.Remove(observer);
        }

        public void Notify()
        {
            foreach (ObservateurAbstrait o in observateurList)
            {
                o.MiseAjour();
            }
        }


        private int GetParamPlateau()
        {
            if (rb_deplacement.IsChecked == true) return 0;
            else if (rb_portail.IsChecked == true) return 1;

            return 0;
        }

        private int GetParamPdv()
        {
            if (rb_pdv_hasard.IsChecked == true) return 0;
            else if (rb_pdv_identique.IsChecked == true) return Int32.Parse(tb_pdv.Text);
            else if (rb_pdv_defaut.IsChecked == true) return 1;           

            return 0;
        }

        private int GetParamPosition()
        {
            if (rb_pos_hasard.IsChecked == true) return 0;
            else if (rb_pos_identique.IsChecked == true) return 5;
            else if (rb_pos_defaut.IsChecked == true) return 1;
            
            return 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Grid_Game.Children.Clear();
            simulation = SimulationJeu.Instance;
            simulation.Initialisation(GetParamPlateau(), GetParamPdv(), GetParamPosition());
            //simulation = new SimulationJeu(GetParamPlateau(), GetParamPdv(), GetParamPosition());

            if (GetParamPlateau() == 1)
            {
                foreach (Item i in simulation.plateaufinal.ItemList)
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
                    Grid_Game2.Children.Remove(i.Avatar);
                    Grid_Game2.Children.Add(i.Avatar);
                }
            }

            foreach (Personnage p in simulation.plateau.PersonnageList)
            {
                Image img_back = new Image();
                img_back.Source = new BitmapImage(new Uri(@"pack://application:,,/image.jpg"));
                img_back.Stretch = Stretch.Fill;

                Grid.SetRow(img_back, p.Position.row);
                Grid.SetColumn(img_back, p.Position.column);
                Grid_Game.Children.Remove(img_back);
                Grid_Game.Children.Add(img_back);

                ListImage.Add(img_back);
                p.AnalyseSituation(simulation.plateau.ItemList);
                p.PointDeVie += 20;
                Grid.SetRow(p.Avatar, p.Position.row);
                Grid.SetColumn(p.Avatar, p.Position.column);
                Grid_Game.Children.Remove(p.Avatar);
                Grid_Game.Children.Add(p.Avatar);


                foreach (Zone z in p.ZoneAcessibleList)
                {
                    Image img_za = new Image();
                    img_za.Source = new BitmapImage(new Uri(@"pack://application:,,/image.jpg"));
                    img_za.Stretch = Stretch.Fill;

                    Grid.SetRow(img_za, z.row);
                    Grid.SetColumn(img_za, z.column);
                    Grid_Game.Children.Remove(img_za);
                    Grid_Game.Children.Add(img_za);

                    ListImage.Add(img_za);
                }

                if (typeof(Fantassin) == p.GetType())
                    lbl_vie1.Content = p.PointDeVie.ToString();
                else if (typeof(Archer) == p.GetType())
                    lbl_vie2.Content = p.PointDeVie.ToString();
            }

            foreach (Item i in simulation.plateau.ItemList)
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
                Grid_Game.Children.Remove(i.Avatar);
                Grid_Game.Children.Add(i.Avatar);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Image image in ListImage)
            {
                Grid_Game.Children.Remove(image);
            }
            ListImage.Clear();

            
            foreach (Personnage p in simulation.plateau.PersonnageList)
            {              
                Observateur obs = new Observateur(p, "Passe à l'action");
                Attach(obs);
                p.Execution();
                Notify();
                Detach(obs);

                if (p.EstMort == false && p.EtatCourant is EtatEnAction)
                {
                    
                    Image img_back = new Image();
                    img_back.Source = new BitmapImage(new Uri(@"pack://application:,,/image.jpg"));
                    img_back.Stretch = Stretch.Fill;

                    p.SeDeplacer();
                    p.AnalyseSituation(simulation.plateau.ItemList);


                    Grid.SetRow(img_back, p.Position.row);
                    Grid.SetColumn(img_back, p.Position.column);
                    Grid_Game.Children.Remove(img_back);
                    Grid_Game.Children.Add(img_back);

                    ListImage.Add(img_back);

                    Grid.SetRow(p.Avatar, p.Position.row);
                    Grid.SetColumn(p.Avatar, p.Position.column);
                    Grid_Game.Children.Remove(p.Avatar);
                    Grid_Game.Children.Add(p.Avatar);

                    foreach (Zone z in p.ZoneAcessibleList)
                    {
                        foreach (Item item in simulation.plateau.ItemList)
                        {
                            if ((item.Position.column == z.column) && (item.Position.row == z.row)) continue;
                            else
                            {
                                Image img_za = new Image();
                                img_za.Source = new BitmapImage(new Uri(@"pack://application:,,/image.jpg"));
                                img_za.Stretch = Stretch.Fill;

                                Grid.SetRow(img_za, z.row);
                                Grid.SetColumn(img_za, z.column);
                                Grid_Game.Children.Remove(img_za);
                                Grid_Game.Children.Add(img_za);

                                ListImage.Add(img_za);
                            }
                        }
                    }

                    if (typeof(Fantassin) == p.GetType())
                        lbl_vie1.Content = p.PointDeVie.ToString();
                    else if (typeof(Archer) == p.GetType())
                        lbl_vie2.Content = p.PointDeVie.ToString();

                    foreach (Item i in simulation.plateau.ItemList)
                    {
                        if (i.Pris == false)
                        {
                            Grid.SetRow(i.Avatar, i.Position.row);
                            Grid.SetColumn(i.Avatar, i.Position.column);
                            Grid_Game.Children.Remove(i.Avatar);
                            Grid_Game.Children.Add(i.Avatar);
                        }
                        else
                        {
                            Grid.SetRow(i.Avatar, i.Position.row);
                            Grid.SetColumn(i.Avatar, i.Position.column);
                            Grid_Game.Children.Remove(i.Avatar);
                        }

                    }

                    if (p.ObjectifAtteint == true) MessageBox.Show("GOAL");
                    if (p.EstMort == true) MessageBox.Show(p.Nom + " est GAME OVER");
                   
                }
                
                Observateur obs2 = new Observateur(p, "Passe en attente");
                Attach(obs);
                p.Execution();
                Notify();
                Detach(obs);
            }
        }
    }
}