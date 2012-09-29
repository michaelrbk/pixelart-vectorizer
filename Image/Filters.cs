using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace PixelArtUpScaler
{

    public class BitmapFilter
    {

        public static Bitmap Grayscale(Bitmap b)
        {
            FastBitmap fb = new FastBitmap(b);

            for (int y = 0; y < b.Height; y++)
            {
                for (int x = 0; x < b.Width; x++)
                {
                    Color c = fb.GetPixel(x, y);
                    int luma = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                    fb.SetPixel(x, y, Color.FromArgb(luma, luma, luma));
                }
            }
            return fb.GetBitmap();
        }

        /*
        Analisando os seguintes pixeis 
        A	B	C
        D	E	F
        G	H	I

        O pixel E vai ser expandido para 4 novos

        E0	E1
        E2	E3

        */
        public static Bitmap Scale2x(Bitmap b)
        {

            Bitmap dst = new Bitmap(b.Width * 2, b.Height * 2);
            FastBitmap fdst = new FastBitmap(dst);
            FastBitmap fb = new FastBitmap(b);

            Color A, B, C, D, E, F, G, H, I = new Color();
            Color E0, E1, E2, E3 = new Color();
            int nDstCol1, nDstCol2 = 0;
            int nDstLin1, nDstLin2 = 0;
            int col1, col2, col3, lin1, lin2, lin3 = 0;

            for (int h = 0; h < b.Height; ++h)
            {
                nDstLin1 = nDstLin2 == 0 ? 0 : nDstLin2 + 1;
                nDstLin2 = nDstLin1 + 1;
                nDstCol1 = 0;
                nDstCol2 = 0;

                for (int w = 0; w < b.Width; ++w)
                {


                    col1 = w - 1 < 1 ? 0 : w - 1;
                    col2 = w;
                    col3 = w + 1 >= b.Width ? b.Width - 1 : w + 1;
                    lin1 = h - 1 < 1 ? 0 : h - 1;
                    lin2 = h;
                    lin3 = h + 1 >= b.Height ? b.Height - 1 : h + 1;

                    A = fb.GetPixel(col1, lin1);
                    B = fb.GetPixel(col2, lin1);
                    C = fb.GetPixel(col3, lin1);
                    D = fb.GetPixel(col1, lin2);
                    E = fb.GetPixel(col2, lin2);
                    F = fb.GetPixel(col3, lin2);
                    G = fb.GetPixel(col1, lin3);
                    H = fb.GetPixel(col2, lin3);
                    I = fb.GetPixel(col3, lin3);

                    E0 = D == B && B != F && D != H ? D : E;
                    E1 = B == F && B != D && F != H ? F : E;
                    E2 = D == H && D != B && H != F ? D : E;
                    E3 = H == F && D != H && B != F ? F : E;

                    /*
                    if (B != H && D != F)
                    {
                        E0 = D == B ? D : E;
                        E1 = B == F ? F : E;
                        E2 = D == H ? D : E;
                        E3 = H == F ? F : E;
                    }
                    else
                    {
                        E0 = E;
                        E1 = E;
                        E2 = E;
                        E3 = E;
                    }*/

                    nDstCol1 = nDstCol2 == 0 ? 0 : nDstCol2 + 1;
                    nDstCol2 = nDstCol1 + 1;

                    fdst.SetPixel(nDstCol1, nDstLin1, E0);
                    fdst.SetPixel(nDstCol2, nDstLin1, E1);
                    fdst.SetPixel(nDstCol1, nDstLin2, E2);
                    fdst.SetPixel(nDstCol2, nDstLin2, E3);

                }
            }

            b = fdst.GetBitmap();
            dst.Dispose();
            return b;
        }

        /*
         Analisando os seguintes pixeis 
         A	B	C
         D	E	F
         G	H	I

         O pixel E vai ser expandido para 9 novos pixeis

         E0	E1	E2
         E3	E4	E5
         E6	E7	E8

         */
        public static Bitmap Scale3x(Bitmap b)
        {

            Bitmap dst = new Bitmap(b.Width * 3, b.Height * 3);
            FastBitmap fdst = new FastBitmap(dst);

            FastBitmap fb = new FastBitmap(b);
            Color A, B, C, D, E, F, G, H, I = new Color();
            Color E0, E1, E2, E3, E4, E5, E6, E7, E8 = new Color();
            int nDstCol1 = 0, nDstCol2 = 0, nDstCol3 = 0;
            int nDstLin1 = 0, nDstLin2 = 0, nDstLin3 = 0;
            int col1, col2, col3, lin1, lin2, lin3;

            for (int h = 0; h < b.Height; ++h)
            {
                nDstLin1 = nDstLin3 == 0 ? 0 : nDstLin3 + 1;
                nDstLin2 = nDstLin1 + 1;
                nDstLin3 = nDstLin2 + 1;
                nDstCol1 = 0;
                nDstCol2 = 0;
                nDstCol3 = 0;

                for (int w = 0; w < b.Width; ++w)
                {


                    col1 = w - 1 < 1 ? 0 : w - 1;
                    col2 = w;
                    col3 = w + 1 >= b.Width ? b.Width - 1 : w + 1;
                    lin1 = h - 1 < 1 ? 0 : h - 1;
                    lin2 = h;
                    lin3 = h + 1 >= b.Height ? b.Height - 1 : h + 1;

                    A = fb.GetPixel(col1, lin1);
                    B = fb.GetPixel(col2, lin1);
                    C = fb.GetPixel(col3, lin1);
                    D = fb.GetPixel(col1, lin2);
                    E = fb.GetPixel(col2, lin2);
                    F = fb.GetPixel(col3, lin2);
                    G = fb.GetPixel(col1, lin3);
                    H = fb.GetPixel(col2, lin3);
                    I = fb.GetPixel(col3, lin3);

                    if (B != H && D != F)
                    {
                        E0 = D == B ? D : E;
                        E1 = (D == B && E != C) || (B == F && E != A) ? B : E;
                        E2 = B == F ? F : E;
                        E3 = (D == B && E != G) || (D == H && E != A) ? D : E;
                        E4 = E;
                        E5 = (B == F && E != I) || (H == F && E != C) ? F : E;
                        E6 = D == H ? D : E;
                        E7 = (D == H && E != I) || (H == F && E != G) ? H : E;
                        E8 = H == F ? F : E;
                    }
                    else
                    {
                        E0 = E;
                        E1 = E;
                        E2 = E;
                        E3 = E;
                        E4 = E;
                        E5 = E;
                        E6 = E;
                        E7 = E;
                        E8 = E;
                    }

                    nDstCol1 = nDstCol3 == 0 ? 0 : nDstCol3 + 1;
                    nDstCol2 = nDstCol1 + 1;
                    nDstCol3 = nDstCol2 + 1;

                    fdst.SetPixel(nDstCol1, nDstLin1, E0);
                    fdst.SetPixel(nDstCol2, nDstLin1, E1);
                    fdst.SetPixel(nDstCol3, nDstLin1, E2);
                    fdst.SetPixel(nDstCol1, nDstLin2, E3);
                    fdst.SetPixel(nDstCol2, nDstLin2, E4);
                    fdst.SetPixel(nDstCol3, nDstLin2, E5);
                    fdst.SetPixel(nDstCol1, nDstLin3, E6);
                    fdst.SetPixel(nDstCol2, nDstLin3, E7);
                    fdst.SetPixel(nDstCol3, nDstLin3, E8);

                }
            }

            b = fdst.GetBitmap();
            dst.Dispose();
            return b;
        }

        public static Bitmap Scale4x(Bitmap b)
        {

            Bitmap dst2 = new Bitmap(b.Width * 2, b.Height * 2);
            dst2 = Scale2x(b);

            Bitmap dst4 = new Bitmap(dst2.Width * 2, dst2.Height * 2);
            dst4 = Scale2x(dst2);
            dst2.Dispose();
            return dst4;
        }
    }
}
