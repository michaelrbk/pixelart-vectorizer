using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows;
using System.Drawing;

namespace PixelArtUpscaler.Image
{
    public class SVGDocument
    {
        XmlWriter m_writer;
        MemoryStream m_stream;
        XmlWriterSettings settings = new XmlWriterSettings();

        public SVGDocument()
            :this((double)100, (double)100)
        {
        }

        public SVGDocument(double width, double height)
        {
            m_stream = new MemoryStream(); 
            //m_writer = XmlWriter.Create(m_stream);
            settings.Indent = true;
            settings.IndentChars = "  ";
            settings.NewLineChars = "\r\n";
            m_writer = XmlWriter.Create(m_stream, settings);

            m_writer.WriteStartDocument();
            m_writer.WriteDocType("svg", "-//W3C//DTD SVG 1.1//EN", "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd", null);
            m_writer.WriteStartElement("svg", "http://www.w3.org/2000/svg");
            m_writer.WriteAttributeString("version", "1.1");
            if (width == 100 && height == 100)
            {
                m_writer.WriteAttributeString("width", "100%");
                m_writer.WriteAttributeString("height", "100%");
            }
            else
            {
                m_writer.WriteAttributeString("width", width.ToString());
                m_writer.WriteAttributeString("height", height.ToString());
            }


        }

        public void DrawCellBorder(bool draw)
        {
            m_writer.WriteStartElement("defs");
            m_writer.WriteStartElement("style");
            m_writer.WriteAttributeString("type", "text/css");
            //Estilo das células novas
            if (draw)
                m_writer.WriteCData("polygon {stroke:rgb(0, 0, 0);stroke-miterlimit:4;stroke-dasharray:none;stroke-width:0.100}");
            else
                m_writer.WriteCData("polygon {stroke:none;}");
            m_writer.WriteEndElement();
            m_writer.WriteEndElement();
        }

        public void DrawLine(Color color,double strokeThickness, double x1, double y1,double x2,double y2)
        {
            //<line fill="LightBlue" stroke="Blue" stroke-width="1" x1="575px" y1="175px" x2="575px" y2="225px" />
            m_writer.WriteStartElement("line");
            m_writer.WriteAttributeString("stroke", Color2String(color));
            m_writer.WriteAttributeString("stroke-width", strokeThickness.ToString().Replace(",","."));
            m_writer.WriteAttributeString("x1", x1.ToString());
            m_writer.WriteAttributeString("y1", y1.ToString());
            m_writer.WriteAttributeString("x2", x2.ToString());
            m_writer.WriteAttributeString("y2", y2.ToString());
            
            m_writer.WriteEndElement();
        }

        public void DrawEllipse(Color fillColor, Color strokeColor, double strokeThickness, Point centre, double radiusX, double radiusY)
        {
            string fillOpacity = ((float)fillColor.A / 255f).ToString();

            m_writer.WriteStartElement("ellipse");
            m_writer.WriteAttributeString("cx", centre.X.ToString());
            m_writer.WriteAttributeString("cy", centre.Y.ToString());
            m_writer.WriteAttributeString("rx", radiusX.ToString());
            m_writer.WriteAttributeString("ry", radiusY.ToString());
            m_writer.WriteAttributeString("style", String.Format("fill-opacity:" + fillOpacity + ";fill:rgb({0},{1},{2});stroke:rgb(0,0,0);stroke-width:" + strokeThickness.ToString(), fillColor.R, fillColor.G, fillColor.B));

            m_writer.WriteEndElement();
        }

        public void DrawCircle(Color fillColor, Color strokeColor, double strokeThickness, double X, double Y, double radius)
        {
            //<circle fill="Blue" cx="525px" cy="25px" r="4px" />
            
            m_writer.WriteStartElement("circle");
            m_writer.WriteAttributeString("fill", Color2String(fillColor));
            m_writer.WriteAttributeString("cx", X.ToString());
            m_writer.WriteAttributeString("cy", Y.ToString());
            m_writer.WriteAttributeString("r", radius.ToString());

            m_writer.WriteEndElement();
        }

        public void DrawRectangle(Color fillColor, Color strokeColor, double strokeThickness, double X,double Y, double width, double height)
        {
            //<rect fill="#FFFFFF" stroke="Black" stroke-width="1px" x="0px" y="0px" width="50px" height="50px" />
            m_writer.WriteStartElement("rect");
            m_writer.WriteAttributeString("x", X.ToString());
            m_writer.WriteAttributeString("y", Y.ToString());
            m_writer.WriteAttributeString("width", width.ToString());
            m_writer.WriteAttributeString("height", height.ToString());
            m_writer.WriteAttributeString("fill", Color2String(fillColor));
            m_writer.WriteAttributeString("stroke", Color2String(strokeColor));
            m_writer.WriteAttributeString("stroke-width", strokeThickness.ToString());

            m_writer.WriteEndElement();
        }

        public void DrawText(string text, double emSize, Color foreground, Point origin)
        {
            m_writer.WriteStartElement("text");
            m_writer.WriteAttributeString("x", origin.X.ToString());
            m_writer.WriteAttributeString("y", origin.Y.ToString());
            m_writer.WriteAttributeString("style", "font-size:" + emSize.ToString() + ";fill:"+ Color2String(foreground));
            m_writer.WriteString(text);

            m_writer.WriteEndElement();
        }

        public void DrawPath(Color fillColor, Color strokeColor, double strokeThickness, string data)
        {
            //string fillOpacity = ((float)fillColor.A / 255f).ToString();

            m_writer.WriteStartElement("path");
            m_writer.WriteAttributeString("d", data);
            m_writer.WriteAttributeString("fill", Color2String(fillColor));
            //m_writer.WriteAttributeString("fill", "none");
            m_writer.WriteAttributeString("stroke", Color2String(strokeColor));
            m_writer.WriteAttributeString("stroke-width", strokeThickness.ToString().Replace(",", "."));
           // m_writer.WriteAttributeString("style", "fill-opacity:" + fillOpacity + ";fill:rgb(0,0,0);stroke:rgb(0,0,0);stroke-width:" + strokeThickness.ToString());

            m_writer.WriteEndElement();
        }

        public void DrawPolygon(Color fillColor, Color strokeColor, double strokeThickness, string data)
        {
            //<polygon points="220,10 300,210 170,250 123,234"   style="fill:#lime;stroke:purple;stroke-width:1"/>

            m_writer.WriteStartElement("polygon");
            m_writer.WriteAttributeString("points", data);
            m_writer.WriteAttributeString("fill", Color2String(fillColor));
            //m_writer.WriteAttributeString("stroke", Color2String(strokeColor));
            //m_writer.WriteAttributeString("stroke-width", strokeThickness.ToString());
            //m_writer.WriteAttributeString("style", "fill-opacity:" + Color2String(fillColor) + ";fill:" + Color2String(fillColor) + ";stroke:rgb(0,0,0);stroke-width:" + strokeThickness.ToString());
            //m_writer.WriteAttributeString("style", "fill-opacity:" + Color2String(fillColor) + ";fill:" + Color2String(fillColor) + ";stroke:rgb(0, 0, 0);stroke-miterlimit:4;stroke-dasharray:none;stroke-width:0.1");
            
            m_writer.WriteEndElement();
        }

        public void StartGroup()
        {
            m_writer.WriteStartElement("g");
        }

        public void CloseGroup()
        {
            m_writer.WriteEndElement();
        }

        public void Save(string path)
        {
            m_writer.WriteEndElement();
            m_writer.WriteEndDocument();
            m_writer.Flush();
            byte[] data = m_stream.ToArray();
            File.WriteAllBytes(path, data);
            m_stream.Close();
        }

        internal string Color2String(Color c)
        {
            if (c.IsNamedColor)
            {
                return c.Name;
            }
            else
            {
                byte[] bytes = BitConverter.GetBytes(c.ToArgb());

                string sColor = "#";
                sColor += BitConverter.ToString(bytes, 2, 1);
                sColor += BitConverter.ToString(bytes, 1, 1);
                sColor += BitConverter.ToString(bytes, 0, 1);

                return sColor;
            }
        }

        internal Color String2Color(string sColor)
        {
            Color c;

            if (sColor.Length == 7 && sColor[0] == '#')
            {
                string s1 = sColor.Substring(1, 2);
                string s2 = sColor.Substring(3, 2);
                string s3 = sColor.Substring(5, 2);

                byte r = 0;
                byte g = 0;
                byte b = 0;

                try
                {
                    r = Convert.ToByte(s1, 16);
                    g = Convert.ToByte(s2, 16);
                    b = Convert.ToByte(s3, 16);
                }
                catch
                {
                }

                c = Color.FromArgb(r, g, b);
            }
            else
            {
                c = Color.FromName(sColor);
            }

            return c;
        }
    }
}