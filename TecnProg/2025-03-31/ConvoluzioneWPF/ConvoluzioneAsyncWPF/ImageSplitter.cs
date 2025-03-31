using System;
using System.Drawing;

namespace ConvoluzioneAsyncWPF
{
    public class ImageSplitter
    {
        public static Bitmap[] DividiInRighe(Bitmap originalImage, int numeroRighe)
        {
            int width = originalImage.Width;
            int height = originalImage.Height;
            int rowHeight = height / numeroRighe;

            Bitmap[] rows = new Bitmap[numeroRighe];

            for (int i = 0; i < numeroRighe; i++)
            {
                rows[i] = new Bitmap(width, rowHeight);

                // Calcoliamo l'altezza dell'attuale riga
                int yOffset = i * rowHeight;

                using (Graphics g = Graphics.FromImage(rows[i]))
                {
                    g.DrawImage(originalImage, new Rectangle(0, 0, width, rowHeight), 0, yOffset, width, rowHeight, GraphicsUnit.Pixel);
                }
            }

            return rows;
        }

        public static Bitmap UnisciRighe(Bitmap[] rows)
        {
            if (rows.Length == 0)
            {
                throw new ArgumentException("Non ci sono righe da unire.");
            }

            int width = rows[0].Width;
            int height = rows.Length * rows[0].Height;

            // Crea una nuova bitmap per l'immagine ricomposta
            Bitmap recomposedImage = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(recomposedImage))
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    g.DrawImage(rows[i], 0, i * rows[i].Height);
                }
            }

            return recomposedImage;
        }
    }
}