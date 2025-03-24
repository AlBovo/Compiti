using System;
using System.Drawing;

namespace ConvoluzioneAsyncWPF
{
    public class ImageSplitter
    {
        public static Bitmap[] DividiQuadranti(Bitmap originalImage)
        {
            int width = originalImage.Width;
            int height = originalImage.Height;

            // Calcoliamo le dimensioni dei quadranti
            int halfWidth = width / 2;
            int halfHeight = height / 2;

            // Creiamo i quadranti
            Bitmap[] quadrants = new Bitmap[4];
            quadrants[0] = new Bitmap(halfWidth, halfHeight); // Quadrante in alto a sinistra
            quadrants[1] = new Bitmap(halfWidth, halfHeight); // Quadrante in alto a destra
            quadrants[2] = new Bitmap(halfWidth, halfHeight); // Quadrante in basso a sinistra
            quadrants[3] = new Bitmap(halfWidth, halfHeight); // Quadrante in basso a destra

            // Copiamo i dati dall'immagine originale nei rispettivi quadranti
            using (Graphics g0 = Graphics.FromImage(quadrants[0]))
            {
                g0.DrawImage(originalImage, new Rectangle(0, 0, halfWidth, halfHeight), 0, 0, halfWidth, halfHeight, GraphicsUnit.Pixel);
            }

            using (Graphics g1 = Graphics.FromImage(quadrants[1]))
            {
                g1.DrawImage(originalImage, new Rectangle(0, 0, halfWidth, halfHeight), halfWidth, 0, halfWidth, halfHeight, GraphicsUnit.Pixel);
            }

            using (Graphics g2 = Graphics.FromImage(quadrants[2]))
            {
                g2.DrawImage(originalImage, new Rectangle(0, 0, halfWidth, halfHeight), 0, halfHeight, halfWidth, halfHeight, GraphicsUnit.Pixel);
            }

            using (Graphics g3 = Graphics.FromImage(quadrants[3]))
            {
                g3.DrawImage(originalImage, new Rectangle(0, 0, halfWidth, halfHeight), halfWidth, halfHeight, halfWidth, halfHeight, GraphicsUnit.Pixel);
            }

            return quadrants;
        }

        public static Bitmap UnisciQuadranti(Bitmap[] quadrants)
        {
            // Assumiamo che i quadranti siano stati divisi correttamente (4 quadranti)
            if (quadrants.Length != 4)
            {
                throw new ArgumentException("Sono necessari esattamente 4 quadranti.");
            }

            int halfWidth = quadrants[0].Width;
            int halfHeight = quadrants[0].Height;

            // Crea una nuova bitmap per l'immagine ricomposta
            Bitmap recomposedImage = new Bitmap(halfWidth * 2, halfHeight * 2);

            // Copia i quadranti nella posizione corretta
            using (Graphics g = Graphics.FromImage(recomposedImage))
            {
                g.DrawImage(quadrants[0], 0, 0); // Quadrante in alto a sinistra
                g.DrawImage(quadrants[1], halfWidth, 0); // Quadrante in alto a destra
                g.DrawImage(quadrants[2], 0, halfHeight); // Quadrante in basso a sinistra
                g.DrawImage(quadrants[3], halfWidth, halfHeight); // Quadrante in basso a destra
            }

            return recomposedImage;
        }
    }

}
