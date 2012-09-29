using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PixelArtUpScaler.Image
{
    class ColorYUV
    {
        public static readonly ColorYUV Empty = new ColorYUV(0, 0, 0);

        private double y;
        private double u;
        private double v;

        public static bool operator ==(ColorYUV item1, ColorYUV item2)
        {
            return (
                item1.Y == item2.Y
                && item1.U == item2.U
                && item1.V == item2.V
                );
        }

        public static bool operator !=(ColorYUV item1, ColorYUV item2)
        {
            return (
                item1.Y != item2.Y
                || item1.U != item2.U
                || item1.V != item2.V
                );
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                y = (y > 1) ? 1 : ((y < 0) ? 0 : y);
            }
        }

        public double U
        {
            get
            {
                return u;
            }
            set
            {
                u = value;
                u = (u > 0.436) ? 0.436 : ((u < -0.436) ? -0.436 : u);
            }
        }

        public double V
        {
            get
            {
                return v;
            }
            set
            {
                v = value;
                v = (v > 0.615) ? 0.615 : ((v < -0.615) ? -0.615 : v);
            }
        }


        public ColorYUV(double y, double u, double v)
        {
            this.y = (y > 1) ? 1 : ((y < 0) ? 0 : y);
            this.u = (u > 0.436) ? 0.436 : ((u < -0.436) ? -0.436 : u);
            this.v = (v > 0.615) ? 0.615 : ((v < -0.615) ? -0.615 : v);
        }


        public ColorYUV(Color c)
        {

            double r = (double)c.R / 255.0;
            double g = (double)c.G / 255.0;
            double b = (double)c.B / 255.0;

            y =( 0.299 * r + 0.587 * g + 0.114 * b) *100;
            u =( -0.14713 * r - 0.28886 * g + 0.436 * b) *100;
            v =( 0.615 * r - 0.51499 * g - 0.10001 * b) *100;

        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            return (this == (ColorYUV)obj);
        }

        public override int GetHashCode()
        {
            return Y.GetHashCode() ^ U.GetHashCode() ^ V.GetHashCode();
        }

    }
}
