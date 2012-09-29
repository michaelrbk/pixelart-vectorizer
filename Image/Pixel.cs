using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using PixelArtUpScaler.Image;
using System.Collections;

namespace PixelArtUpScaler 
{
    public class Pixel 
    {
        public int x { get; set; }
        public int y { get; set; }
        public int valence { get; set; }
        public Color color { get; set; }
        public Color colorB { get; set; }

       
        public List<Point> points = new List<Point>();

        public override string ToString()
        {
            return Convert.ToString(x)+"-"+Convert.ToString(y);
        }

        public Pixel(int x1, int y1, Color color1)
        {
            x = x1;
            y = y1;
            color = color1;
        }
        
        public Point getPoint()
        {
            return new Point(x, y);
        }

        public static bool colorIsDiferent(Color c1, Color c2)
        {
            return !colorIsSimilar(c1, c2);
        }

        internal static bool colorIsSimilar(Color c1, Color c2)
        {

            ColorYUV yuv1 = new ColorYUV(c1);
            ColorYUV yuv2 = new ColorYUV(c2);

            /* Alterado para simplificar, pois os degrades não serão implementados
            if ((Math.Abs(yuv1.Y - yuv2.Y) <= 48) &&
                (Math.Abs(yuv1.U - yuv2.U) <= 7) &&
                (Math.Abs(yuv1.V - yuv2.V) <= 6))*/

            if (c1 == c2)
                return true;
            else
                return false;
        }




        //  Globals which should be set before calling this function:
        //
        //  int    polySides  =  how many corners the polygon has
        //  float  polyX[]    =  horizontal coordinates of corners
        //  float  polyY[]    =  vertical coordinates of corners
        //  float  x, y       =  point to be tested
        //
        //  (Globals are used in this example for purposes of speed.  Change as
        //  desired.)
        //
        //  The function will return YES if the point x,y is inside the polygon, or
        //  NO if it is not.  If the point is exactly on the edge of the polygon,
        //  then the function may return YES or NO.
        //
        //  Note that division by zero is avoided because the division is protected
        //  by the "if" clause which surrounds it.

        //Source http://alienryderflex.com/polygon/
        internal bool pixelInsidePolygon(ArrayList polygons)
        {
            int i, j = polygons.Count - 1;
            bool oddNodes = false;
            Pixel v = null;
            Pixel p = null;
            int Y = 0;
            int X = 0;

            for (i = 0; i < polygons.Count; i++)
            {
                v = (Pixel)polygons[i];
                p = (Pixel)polygons[j];

                //Correção para ajustes de escala e posição relativa central do pixel
                Y = y * 7 + 7 / 2;
                X = x * 7 + 7 / 2;

                if (v.y < Y && p.y >= Y
                || p.y < Y && v.y >= Y)
                {
                    if (v.x + (Y - v.y) / (p.y - v.y) * (p.x - v.y) < X)
                    {
                        oddNodes = !oddNodes;
                    }
                }
                j = i;
            }

            return oddNodes;
        }

    }
}
