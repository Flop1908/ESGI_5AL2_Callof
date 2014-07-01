using System.Windows.Controls;
using DesignPattern.Fabrique;

namespace DesignPattern.Objet
{
    /// <summary>
    /// Classe représentant les items du jeu
    /// </summary>
    public abstract class Item
    {
        public Image Avatar;
        public bool Pris;

        public Item()
        {
            Avatar = new Image();
            Position = new Zone();
            Pris = false;
        }

        public int Potion { get; set; }
        public Zone Position { get; set; }

        public virtual void SetAvatar(string img)
        {
        }
    }
}