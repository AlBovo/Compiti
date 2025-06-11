using System.Windows;

namespace LibreriaClassi
{
    internal class AnimatoInAcqua : Inanimato
    {
        public void Move() { }

        public AnimatoInAcqua(Uri uri, Thickness thickness)
            : base(uri, thickness) { }
    }
}
