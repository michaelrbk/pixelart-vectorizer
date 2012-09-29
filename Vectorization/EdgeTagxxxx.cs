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

        public Color color { get; set; }

        public override string ToString()
        {
            return Convert.ToString(color) + "-" + visible;
        }

        public EdgeTag(Color color1, bool visible1)
        {
            color = color1;
            visible = visible1;
        }
    }
}