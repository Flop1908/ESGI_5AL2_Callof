using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DesignPattern.Fabrique;

namespace DesignPattern.Objet
{
    public abstract class Item
    {
        public int Potion { get; set; }
        public Image Avatar;
        public Zone Position { get; set; }
        public bool Pris;

        public Item()
        {
            Avatar = new Image();
            Position = new Zone();
            Pris = false;
        }

        public virtual void SetAvatar(string img)
        {

        }

    }
}
