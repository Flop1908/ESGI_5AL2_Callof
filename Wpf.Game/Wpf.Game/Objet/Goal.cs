using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Wpf.Game.Objet
{
    class Goal : Item
    {
        public override void SetAvatar()
        {
            Avatar.Source = new BitmapImage(new Uri(@"pack://application:,,/goal.jpg"));
            Avatar.Stretch = Stretch.Fill;

        }
    }
}
