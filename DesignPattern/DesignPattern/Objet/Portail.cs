using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DesignPattern.Objet
{
    public class Portail : Item
    {
        public override void SetAvatar(string img)
        {
            Avatar.Source = new BitmapImage(new Uri(@"pack://application:,,/" + img));
            Avatar.Stretch = Stretch.Fill;
        }
    }
}