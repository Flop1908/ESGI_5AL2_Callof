using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Wpf.Game.Fabrique;

namespace Wpf.Game.Observer
{
    class Fantassin : Personnage
    {
        public Fantassin()
        {}
        public Fantassin(string _Nom, int _Vie = 200)
            : base(_Nom, _Vie)
        {
            //ComportementCombat = new ComportementApiedAvecHache();
            //ComportementEmettreUnSon = new ComportementCrier();
        }

        public override void SetAvatar()
        {
            Avatar.Source = new BitmapImage(new Uri(@"pack://application:,,/perso.png"));
            Avatar.Stretch = Stretch.Fill;
        }

    }
}
