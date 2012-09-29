using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace PixelArtUpScaler.Vectorization
{
    class Shape : ArrayList, IComparable<Shape>
    {

        public Color getColor()
        {
            return ((Curve)this[0]).color;
        }
        

        public int CompareTo(Shape otherShape)
        {
            double sizeShapeA = 0;
            double sizeShapeB = 0;
            /*
            foreach (Curve curve in this)
            {
                sizeShapeA += curve.curveSize();
            }

            foreach (Curve otherCurve in otherShape)
            {
                sizeShapeB += otherCurve.curveSize();
            }
            
            if (sizeShapeA > sizeShapeB)
                return -1;
            if (sizeShapeA < sizeShapeB)
                return 1;
            else
                return 0;*/
            sizeShapeA = this.PolygonArea();
            sizeShapeB = otherShape.PolygonArea();
            if (sizeShapeA > sizeShapeB)
                return -1;
            if (sizeShapeA < sizeShapeB)
                return 1;
            else
                return 0;
        }

        public bool isSameShape(Shape otherShape)
        {
            if (this.Count != otherShape.Count)
                return false;

            Curve curve = null;
            Curve otherCurve = null;
            for (int i = 0; i < this.Count; i++)
            {
                curve = ((Curve)this[i]);
                otherCurve = ((Curve)otherShape[i]);
                if (curve.curve != otherCurve.curve)
                    return false;
            }

            return true;
        }

        public ArrayList ToPoints()
        {
            ArrayList shapeOfPoints = new ArrayList();
            ArrayList points = new ArrayList();
            Pixel lastPoint = null;

            for (int i = 0; i < this.Count; i++)
            {

                points = ((Curve)this[i]).curveToPoints();
                if (i != 0 && !points[0].Equals(lastPoint)) // Corrige curvas que possa estar no sentido errado
                    points.Reverse();

                lastPoint = (Pixel)points[points.Count - 1];
                shapeOfPoints.AddRange(points);
            }

            return shapeOfPoints;
        }


        /*
         * //  Public-domain function by Darel Rex Finley, 2006.

            double polygonArea(double *X, double *Y, int points) {
              double  area=0. ;
              int     i, j=points-1  ;
              for (i=0; i<points; i++) {
                area+=(X[j]+X[i])*(Y[j]-Y[i]); j=i; }
              return area*.5; }
         */

        double PolygonArea()
        {
            ArrayList points = new ArrayList(this.ToPoints());
            int i, j = points.Count - 1;

            double area = 0;


            for (i = 0; i < points.Count; i++)
            {

                area += (((Pixel)points[j]).x + ((Pixel)points[i]).x) * (((Pixel)points[j]).y - ((Pixel)points[i]).y);
                j = i;
                //area -= ((Pixel)points[i]).y * ((Pixel)points[j]).x;
            }

            area = area / 2;
            return (area < 0 ? -area : area);
        }

    }
}
