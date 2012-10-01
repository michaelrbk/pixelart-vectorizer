using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PixelArtUpScaler.Vectorization
{
    class EdgeTag
    {
        public bool visible { get; set; }

        public Color colorA { get; set; }
        public Color colorB { get; set; }

        public override string ToString()
        {
            return Convert.ToString(colorA) + "-" + Convert.ToString(colorB) + "-" + visible;
        }

        public EdgeTag(Color color1,Color color2, bool visible1)
        {
            colorA = color1;
            colorB = color2;
            visible = visible1;
        }

        public EdgeTag()
        {
            visible = true;
        }
    }
}