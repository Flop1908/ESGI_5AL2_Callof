using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;



namespace Wpf.Game.Observer
{
    class Archer : Personnage
    {
        public Archer()
        {}

        public Archer(string _Nom, int _Vie = 150)
            : base(_Nom, _Vie)
        {
            //ComportementCombat = new ComportementApiedAvecHache();
            //ComportementEmettreUnSon = new ComportementCrier();
        }

        public override void SetAvatar()
        {
            Avatar.Source = new BitmapImage(new Uri(@"pack://application:,,/archer.png"));
            Avatar.Stretch = Stretch.Fill;
        }
    }
}
