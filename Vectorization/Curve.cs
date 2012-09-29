using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using QuickGraph;

namespace PixelArtUpScaler.Vectorization
{
    class Curve
    {

        public ArrayList curve { get; set; }
        public Color color { get; set; }

        public Curve(ArrayList curveOfEdges, Color c)
        {
            this.curve = curveOfEdges;
            this.color = c;
        }

        public override string ToString()
        {
            return curve.ToString();
        }

        public double curveSize()
        {
            TaggedUndirectedEdge<Pixel, EdgeTag> edge = null;
            double lenght = 0;
            foreach ( var e in curve)
            {
                edge = (TaggedUndirectedEdge<Pixel, EdgeTag>)e;
                Point p1 = edge.Source.getPoint();
                Point p2 = edge.Target.getPoint();
                lenght += (Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2)));
            }
            return lenght;
            
        }

        public ArrayList curveToPoints()
        {
            ArrayList curveOfEdge = this.curve;
            ArrayList curvesOfPoints = new ArrayList();
            ArrayList curveOfPoints = new ArrayList();
            Pixel lastPoint = null;
            Pixel firstPoint = null;

            firstPoint = null;
            lastPoint = null;
            curveOfPoints = new ArrayList();
            if (curveOfEdge.Count == 1)
            {
                curveOfPoints.Add(((TaggedUndirectedEdge<Pixel, EdgeTag>)curveOfEdge[0]).Source);
                curveOfPoints.Add(((TaggedUndirectedEdge<Pixel, EdgeTag>)curveOfEdge[0]).Target);
            }
            else
            {
                for (int i = 0; i < curveOfEdge.Count; i++)
                {
                    TaggedUndirectedEdge<Pixel, EdgeTag> ed = (TaggedUndirectedEdge<Pixel, EdgeTag>)curveOfEdge[i];
                    if (i == 0)
                    {
                        firstPoint = ed.Source;
                        lastPoint = ed.Target;
                    }
                    else
                    {
                        if (i == 1)
                        {
                            if (ed.Source.Equals(firstPoint))
                            {
                                firstPoint = lastPoint;
                                lastPoint = ed.Source;

                            }
                            else if (ed.Target.Equals(firstPoint))
                            {
                                firstPoint = lastPoint;
                                lastPoint = ed.Target;
                            }
                            curveOfPoints.Add(firstPoint);
                            curveOfPoints.Add(lastPoint);


                        }
                        if (ed.Source.Equals(lastPoint))
                        {
                            lastPoint = ed.Target;
                        }
                        else
                        {
                            lastPoint = ed.Source;
                        }
                        if (i > 0)
                            curveOfPoints.Add(lastPoint);
                    }
                }
            }

            return curveOfPoints;
        }
    }


}
