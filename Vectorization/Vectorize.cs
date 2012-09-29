using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using QuickGraph;
using System.IO;
using QuickGraph.Algorithms.Condensation;
using System.Collections;
using PixelArtUpScaler.Image;
using QuickGraph.Algorithms.Search;
using PixelArtUpScaler.Vectorization;



namespace PixelArtUpScaler
{
    class Vectorize
    {
        //vertices - nodes
        //edges - arestas

        //Height = Altura = Y
        //Width = Largura = X

        UndirectedGraph<Pixel, TaggedUndirectedEdge<Pixel, EdgeTag>> g = new UndirectedGraph<Pixel, TaggedUndirectedEdge<Pixel, EdgeTag>>();
        UndirectedGraph<Pixel, TaggedUndirectedEdge<Pixel, EdgeTag>> ng = new UndirectedGraph<Pixel, TaggedUndirectedEdge<Pixel, EdgeTag>>();
        ArrayList curves = new ArrayList();
        ArrayList curvesC = new ArrayList();
        ArrayList curvesOfEdges = new ArrayList();

        int Height;
        int Width;
        int scale = 7;
        /*
         * p11 p12 p13
         * p21  p  p23
         * p31 p32 p33
         */
        internal String ImageToGraph(Bitmap b)
        {
            FastBitmap fb = new FastBitmap(b);
            Height = b.Height;
            Width = b.Width;


            //Le imagem orignal e adiciona vertex - nodos
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Pixel p = new Pixel(x, y, fb.GetPixel(x, y));
                    g.AddVertex(p);

                }
            }

            //Le imagem orignal e adiciona edges - arestas
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Pixel p = VertexSearch(x, y, g);

                    Pixel p11 = VertexSearch(x - 1, y - 1, g);
                    if (p11 != null && Pixel.colorIsSimilar(p11.color, p.color))
                    {
                        var e1 = new TaggedUndirectedEdge<Pixel, EdgeTag>(p, p11, new EdgeTag());
                        g.AddEdge(e1);
                        p.valence++;
                        p11.valence++;
                    }

                    Pixel p12 = VertexSearch(x, y - 1, g);
                    if (p12 != null && Pixel.colorIsSimilar(p12.color, p.color))
                    {
                        var e2 = new TaggedUndirectedEdge<Pixel, EdgeTag>(p, p12, new EdgeTag());
                        g.AddEdge(e2);
                        p.valence++;
                        p12.valence++;
                    }

                    Pixel p13 = VertexSearch(x + 1, y - 1, g);
                    if (p13 != null && Pixel.colorIsSimilar(p13.color, p.color))
                    {
                        var e3 = new TaggedUndirectedEdge<Pixel, EdgeTag>(p, p13, new EdgeTag());
                        g.AddEdge(e3);
                        p.valence++;
                        p13.valence++;
                    }

                    Pixel p21 = VertexSearch(x - 1, y, g);
                    if (p21 != null && Pixel.colorIsSimilar(p21.color, p.color))
                    {
                        var e4 = new TaggedUndirectedEdge<Pixel, EdgeTag>(p, p21, new EdgeTag());
                        g.AddEdge(e4);
                        p.valence++;
                        p21.valence++;
                    }
                }
            }

            SvgVector svg = new SvgVector();
            svg.Height = Height;
            svg.Width = Width;

            return svg.toImageSVG(g, "Graph.svg");

        }

        /*
         * Examinar blocos de 2x2 nodos para eliminar a maior quantidade de arestas, e remover cruzamentos ambiguos
         * 00 10
         * 01 11
         */
        internal String SolveAmbiguities()
        {

            for (int y = 0; y < Height - 1; y++)
            {
                for (int x = 0; x < Width - 1; x++)
                {
                    Pixel p00 = VertexSearch(x, y, g);
                    Pixel p10 = VertexSearch(x + 1, y, g);
                    Pixel p01 = VertexSearch(x, y + 1, g);
                    Pixel p11 = VertexSearch(x + 1, y + 1, g);
                    //Console.WriteLine("P= " + x + " " + y + " Valence =" + p00.valence);
                    TaggedUndirectedEdge<Pixel, EdgeTag> edge1 = null;
                    TaggedUndirectedEdge<Pixel, EdgeTag> edge2 = null;
                    g.TryGetEdge(p11, p00, out edge1);
                    g.TryGetEdge(p01, p10, out edge2);
                    if (edge1 != null)
                    {
                        if (edge2 != null)
                        {
                            //Identificada uma ambiguidade
                            if (Pixel.colorIsSimilar(p00.color, p01.color))
                            {
                                //Se as 4 cores são iguais remove todas as arestas internas
                                if (edge1 != null)
                                    g.RemoveEdge(edge1);
                                if (edge2 != null)
                                    g.RemoveEdge(edge2);
                            }

                            //Heuristica da ilha
                            else if (edge1.Source.valence == 1 || edge1.Target.valence == 1)
                            {
                                if (edge2 != null)
                                    g.RemoveEdge(edge2);
                            }
                            else if (edge2.Source.valence == 1 || edge2.Target.valence == 1)
                            {
                                if (edge1 != null)
                                    g.RemoveEdge(edge1);
                            }
                            else
                            {
                                //Heuristica da curva
                                if (edge1.Source.valence == 2 || edge1.Target.valence == 2 || edge2.Source.valence == 2 || edge2.Target.valence == 2)
                                {
                                    if (CurveSize(edge1) <= CurveSize(edge2))
                                    {
                                        if (edge1 != null)
                                            g.RemoveEdge(edge1);
                                    }
                                    else
                                    {
                                        if (edge2 != null)
                                            g.RemoveEdge(edge2);
                                    }
                                }
                                else
                                //Heuristica dos pixels sobrepostos
                                {
                                    Pixel p1 = VertexSearch(edge1.Source.x, edge1.Source.y, g);
                                    Pixel p2 = VertexSearch(edge2.Source.x, edge2.Source.y, g);
                                    //Pixel p3 = VertexSearch(edge1.Target.x, edge1.Target.y, g);
                                    //Pixel p4 = VertexSearch(edge2.Target.x, edge2.Target.y, g);
                                    Color c1 = p1.color;
                                    Color c2 = p2.color;
                                    int sumC1 = 0, sumC2 = 0;
                                    //Inicializa x e y com -4 posicoes para verificar 3 pixeis em ambas direções
                                    int xs = p1.x - 4;
                                    int ys = p1.y - 4;

                                    while (xs <= p1.x + 3)
                                    {
                                        while (ys <= p1.y + 3)
                                        {
                                            Pixel pixel = VertexSearch(x, y, g);
                                            if (pixel.color == c1)
                                                sumC1++;
                                            else
                                                if (pixel.color == c2)
                                                    sumC2++;
                                            ys++;
                                        }
                                        xs++;
                                    }
                                    //A cor em maior quantidade representa o fundo, e deve se manter os detalhes conectados
                                    if (sumC1 > sumC2) //Remove a cor em menor quantidade
                                        g.RemoveEdge(edge1);
                                    else
                                        g.RemoveEdge(edge2);

                                }
                            }
                        }
                    }

                }
            }
            SvgVector svg = new SvgVector();
            svg.Height = Height;
            svg.Width = Width;
            //svg.DrawValence = true;
            return svg.toImageSVG(g, "AmbiguitiesSolved.svg");
        }

        /*
         * Altera o formato do pixel com base nos visinhos
         */
        public String ReshapePixelCell()
        {


            foreach (var v in g.Vertices)
            {
                int x = v.x;
                int y = v.y;
                Color c = v.color;

               // foreach (var e in g.AdjacentEdges(v))
               //    Console.WriteLine("Aresta entre " + e.Source.x + "," + e.Source.y + " - " + e.Target.x + "," + e.Target.y);
                

                //TOP LEFT
                //Canto Superior Esquerdo
                /*
                if tem tl
                   -2 +2
	               +2 -2
                if o de cima tem bl
	                +2 +2
                senao   
                    0 0 
                */
                //Firt Pixel fp - Last Pixel Lp
                Pixel fP = null, p1 = null, p2 = null, p3 = null, p4 = null, lP = null, xP = null;

                if (HasEdges(x, y, x - 1, y - 1, g)) //existe uma aresta entre este pixel e o pixel superior esquerdo
                {
                    v.points.Add(new Point(x * scale - 2, y * scale + 2));
                    v.points.Add(new Point(x * scale + 2, y * scale - 2));

                    fP = GetOrAddVertex(x * scale - 2, y * scale + 2, ng);
                    p1 = GetOrAddVertex(x * scale + 2, y * scale - 2, ng);
                    AddNewEdge(fP, p1, PixelColorIs(x - 1, y - 1, g), c, ng);// se o pixel de superior esquerdo é da mesma cor ele não precisa aparecer
                }
                else if (HasEdges(x - 1, y, x, y - 1, g)) //verifica se existe uma aresta entre o pixel superior e o da esquerda
                {
                    v.points.Add(new Point(x * scale + 2, y * scale + 2));
                    fP = GetOrAddVertex(x * scale + 2, y * scale + 2, ng);
                }
                else
                {
                    v.points.Add(new Point(x * scale, y * scale));
                    fP = GetOrAddVertex(x * scale, y * scale, ng);
                }

                if (p1 != null)
                    lP = p1;
                else
                    lP = fP;

                //TOP RIGHT
                /*
                if tem tr
                    +5 -2
                    +9 +2
                if o de cima tem br
                    +5  +2
                senao   
                    +7  +0
                 */
                if (HasEdges(x, y, x + 1, y - 1, g)) //existe uma aresta entre este pixel e o pixel superior direito
                {
                    v.points.Add(new Point(x * scale + 5, y * scale - 2));
                    v.points.Add(new Point(x * scale + 9, y * scale + 2));

                    p2 = GetOrAddVertex(x * scale + 5, y * scale - 2, ng);
                    xP = GetOrAddVertex(x * scale + 9, y * scale + 2, ng);
                    AddNewEdge(p2, xP, PixelColorIs(x + 1, y - 1, g), c, ng);//se o pixel superior direito é da mesma cor ele não precisa aparecer
                }
                else if (HasEdges(x + 1, y, v.x, y - 1, g)) //verifica se existe uma aresta entre o pixel superior e o da direita
                {
                    v.points.Add(new Point(x * scale + 5, y * scale + 2));
                    p2 = GetOrAddVertex(x * scale + 5, y * scale + 2, ng);
                }
                else
                {
                    v.points.Add(new Point(x * scale + 7, y * scale));
                    p2 = GetOrAddVertex(x * scale + 7, y * scale, ng);
                }

                if (lP != null && p2 != null)
                    AddNewEdge(lP, p2, PixelColorIs(x, y - 1, g), c, ng);

                if (xP != null)
                    lP = xP;
                else
                    lP = p2;
                xP = null;


                //botton righ
                /*
                if tem br 
	                   +9 +5
	                   +5 +9
                if o de cima tem tr
	                   +5  +5
                senao  +7  +7 
                 */

                if (HasEdges(x + 1, y + 1, x, y, g)) //existe uma aresta entre este pixel e o pixel inferior direito
                {
                    v.points.Add(new Point(x * scale + 9, y * scale + 5));
                    v.points.Add(new Point(x * scale + 5, y * scale + 9));
                    p3 = GetOrAddVertex(x * scale + 9, y * scale + 5, ng);
                    xP = GetOrAddVertex(x * scale + 5, y * scale + 9, ng);
                    AddNewEdge(p3, xP, PixelColorIs(x + 1, y + 1, g), c, ng);//Se o pixel de baixo é da mesma cor esta aresta não precisa aparecer
                }
                else if (HasEdges(v.x, y + 1, x + 1, v.y, g)) //verifica se existe uma aresta entre o pixel inferior e o da direita
                {
                    v.points.Add(new Point(x * scale + 5, y * scale + 5));
                    p3 = GetOrAddVertex(x * scale + 5, y * scale + 5, ng);
                }
                else
                {
                    v.points.Add(new Point(x * scale + 7, y * scale + 7));
                    p3 = GetOrAddVertex(x * scale + 7, y * scale + 7, ng);
                }

                if (lP != null && p3 != null)
                    AddNewEdge(lP, p3, PixelColorIs(x + 1, y, g), c, ng);

                if (xP != null)
                    lP = xP;
                else
                    lP = p3;
                xP = null;


                //BOTTON LEFT
                /*
                if tem bl
                	   +2 +9
                       -2 +5
                if o de cima tem tl
                	   +2 +5
                senao  +0 +7
                 */
                if (HasEdges(x - 1, y + 1, x, y, g)) //existe uma aresta entre este pixel e o pixel inferior esquerdo
                {
                    v.points.Add(new Point(x * scale + 2, y * scale + 9));
                    v.points.Add(new Point(x * scale - 2, y * scale + 5));
                    p4 = GetOrAddVertex(x * scale + 2, y * scale + 9, ng);
                    xP = GetOrAddVertex(x * scale - 2, y * scale + 5, ng);
                    AddNewEdge(p4, xP, PixelColorIs(x - 1, y + 1, g), c, ng);//se o pixel inferior esquerdo for da mesma cor ele não precisa aparecer
                }
                else if (HasEdges(x, y + 1, x - 1, y, g)) //verifica se existe uma aresta entre o pixel inferior e o da esquerda
                {
                    v.points.Add(new Point(x * scale + 2, y * scale + 5));
                    p4 = GetOrAddVertex(x * scale + 2, y * scale + 5, ng);
                }
                else
                {
                    v.points.Add(new Point(x * scale + 0, y * scale + 7));
                    p4 = GetOrAddVertex(x * scale + 0, y * scale + 7, ng);
                }

                if (lP != null && p4 != null)
                    AddNewEdge(lP, p4, PixelColorIs(x, y + 1, g), c, ng);

                if (xP != null)
                    lP = xP;
                else
                    lP = p4;
                xP = null;

                if (lP != null && fP != null)
                    AddNewEdge(lP, fP, PixelColorIs(x - 1, y, g), c, ng);
            }
            SvgVector svg = new SvgVector();
            svg.Height = Height;
            svg.Width = Width;
            svg.scale = scale;
            svg.DrawNewCells = true;
            svg.DrawCellBorder = true;
            svg.DrawPixelArt = false;
            svg.DrawVertex = false;
            svg.DrawEdges = false;

            return svg.toImageSVG(g, "PixelReshaped.svg");
        }

        internal String DrawNewGraphEdges()
        {
            SvgVector svg = new SvgVector();
            svg.Height = Height * scale;
            svg.Width = Width * scale;
            svg.scale = 1;//scale;
            return svg.ToNewEdges(ng, "NewGraphEdges.svg");
        }


        internal String DrawNewCurves()
        {

            bool hasEdge = true;
            TaggedUndirectedEdge<Pixel, EdgeTag> firstEdge;
            TaggedUndirectedEdge<Pixel, EdgeTag> lastEdge;
            Pixel lastPoint = null;
            Pixel firstPoint = null;

            foreach (var edge in ng.Edges)
            {
                firstPoint = null;
                //localiza uma aresta visivel e que seja de valencia diferente de 2, ou seja o inicio de uma curva.
                if (edge.Tag.visible && (edge.Source.valence != 2 || edge.Target.valence != 2))
                {
                    //cria um array de pontos para esta curva
                    ArrayList curveOfEdges = new ArrayList();
                    //ir para inicio da curva, ou seja nodo com valencia != 2

                    firstEdge = edge;

                    if (firstEdge.Source.valence != 2 && firstEdge.Target.valence != 2)// curva de apenas dois pontos
                    {
                        edge.Tag.visible = false;
                        firstPoint = null;
                        curveOfEdges.Add(firstEdge);
                        curvesOfEdges.Add(curveOfEdges);
                        if (edge.Tag.colorA != Color.Beige)
                            curvesC.Add(new Curve(curveOfEdges, edge.Tag.colorA));
                        if (edge.Tag.colorB != Color.Beige)
                            curvesC.Add(new Curve(curveOfEdges, edge.Tag.colorB));

                    }
                    else
                    {
                        edge.Tag.visible = false;
                        curveOfEdges.Add(firstEdge);
                        if (firstEdge.Target.valence != 2)
                        {
                            firstPoint = firstEdge.Target;
                            lastPoint = firstEdge.Source;
                        }
                        else
                        {
                            firstPoint = firstEdge.Source;
                            lastPoint = firstEdge.Target;
                        }
                    }

                    if (firstPoint == null)
                        hasEdge = false;
                    else
                        hasEdge = true;
                    lastEdge = firstEdge;

                    while (hasEdge)//enquanto existirem mais arestas nesta curva adiciona elas
                    {
                        hasEdge = false;
                        //Obtem proxima aresta
                        foreach (var e in ng.AdjacentEdges(lastPoint))
                        {
                            if (e.Tag.visible == true)
                            {
                                e.Tag.visible = false;

                                if (e.Target.Equals(lastPoint))
                                { lastPoint = e.Source; }
                                else
                                { lastPoint = e.Target; }

                                //Se a valencia for dois a curva continua
                                if (lastPoint.valence == 2 && lastPoint != firstPoint)
                                {
                                    curveOfEdges.Add(e);
                                    hasEdge = true;
                                }
                                else
                                {
                                    hasEdge = false;
                                    curveOfEdges.Add(e);
                                    curvesOfEdges.Add(curveOfEdges);
                                    if (edge.Tag.colorA != Color.Beige)
                                        curvesC.Add(new Curve(curveOfEdges, edge.Tag.colorA));
                                    if (edge.Tag.colorB != Color.Beige)
                                        curvesC.Add(new Curve(curveOfEdges, edge.Tag.colorB));
                                }
                            }
                        }
                    }

                }


            }

            //Percorre as arestas que ficaram de fora por formarem um caminho fechado de arestas, todas com valencia 2
            foreach (var edge in ng.Edges)
            {
                ArrayList curveOfEdges = new ArrayList();
                if (edge.Tag.visible)
                {
                    firstEdge = edge;
                    edge.Tag.visible = false;
                    curveOfEdges.Add(firstEdge);
                    firstPoint = firstEdge.Source;
                    hasEdge = true;
                    lastPoint = firstEdge.Target;

                    while (hasEdge)
                    {
                        hasEdge = false;
                        //Obtem proxima aresta
                        foreach (var e in ng.AdjacentEdges(lastPoint))
                        {
                            if (e.Tag.visible == true)
                            {
                                e.Tag.visible = false;

                                if (e.Target.Equals(lastPoint))
                                { lastPoint = e.Source; }
                                else
                                { lastPoint = e.Target; }

                                if (lastPoint.valence == 2 && lastPoint != firstPoint)
                                {
                                    hasEdge = true;
                                    curveOfEdges.Add(e);
                                }
                                else
                                {
                                    hasEdge = false;
                                    curveOfEdges.Add(e);
                                    curvesOfEdges.Add(curveOfEdges);
                                    if (edge.Tag.colorA != Color.Beige)
                                        curvesC.Add(new Curve(curveOfEdges, edge.Tag.colorA));
                                    if (edge.Tag.colorB != Color.Beige)
                                        curvesC.Add(new Curve(curveOfEdges, edge.Tag.colorB));
                                }
                            }
                        }
                    }
                }
            }



            SvgVector svg = new SvgVector();
            svg.Height = Height * scale;
            svg.Width = Width * scale;
            svg.scale = 1;//scale;
            return svg.ToCurves(curvesOfEdgesToPoints(curvesOfEdges), "NewCurves.svg");
        }


        /*
         * Detectar os ciclos dentro do grafo para transforma-los em objetos coloridos
         */
        internal String DrawNewImage()
        {
            Shapes shapes = new Shapes();
            Shape shape = new Shape();
            ArrayList processedCurves = new ArrayList();

            Pixel lastPixel = null;
            Pixel firstPixel = null;
            Color color;
            bool hasCurve = true;
            foreach (Curve curve in curvesC)
            {

                Curve processingCurve = curve;
                color = processingCurve.color;
                if (!processedCurves.Contains(processingCurve))
                {
                    processedCurves.Add(processingCurve);
                    ArrayList curveArray = (ArrayList)processingCurve.curve;

                    firstPixel = getFirstPixel(curveArray);
                    lastPixel = getLastPixel(curveArray);
                    shape.Add(curve);
                    if (!firstPixel.Equals(lastPixel)) // se primeiro e ultimo são iguais, então o circuito já esta fechado
                    {
                        hasCurve = true;
                        while (hasCurve)
                        {

                            foreach (Curve newCurve in curvesC) // verifico todas as curvas procurando uma que comece ou termine com o ultimo pixel da pesquisada
                            {

                                if ((newCurve.color == color && newCurve != curve && !processedCurves.Contains(newCurve) )) // Precisa ser uma curva não processessada e com cor igual
                                {

                                    hasCurve = false;
                                    ArrayList newCurveArray = (ArrayList)newCurve.curve;
                                    TaggedUndirectedEdge<Pixel, EdgeTag> firstNewEdge = (TaggedUndirectedEdge<Pixel, EdgeTag>)newCurveArray[0];
                                    TaggedUndirectedEdge<Pixel, EdgeTag> lastNewEdge = (TaggedUndirectedEdge<Pixel, EdgeTag>)newCurveArray[newCurveArray.Count - 1];

                                    if (firstNewEdge.Source.Equals(lastPixel) || firstNewEdge.Target.Equals(lastPixel) || lastNewEdge.Target.Equals(lastPixel) || lastNewEdge.Source.Equals(lastPixel)) // se a curva analizada possui o primeiro ou ultimo pixel igual a um pixel do lastEdge // simplificado apenas para conter um dos pixeis da ultima aresta da curva
                                    {
                                        if (firstNewEdge.Source.Equals(lastPixel) || firstNewEdge.Target.Equals(lastPixel))
                                        {
                                            if (newCurveArray.Count == 1)
                                            {
                                                if (((TaggedUndirectedEdge<Pixel, EdgeTag>)newCurveArray[0]).Source.Equals(lastPixel))
                                                    lastPixel = ((TaggedUndirectedEdge<Pixel, EdgeTag>)newCurveArray[0]).Target;
                                                else
                                                    lastPixel = ((TaggedUndirectedEdge<Pixel, EdgeTag>)newCurveArray[0]).Source;
                                            }
                                            else lastPixel = getLastPixel(newCurveArray);
                                        }
                                        else
                                        {
                                            if (newCurveArray.Count == 1)
                                            {
                                                if (((TaggedUndirectedEdge<Pixel, EdgeTag>)newCurveArray[0]).Source.Equals(lastPixel))
                                                    lastPixel = ((TaggedUndirectedEdge<Pixel, EdgeTag>)newCurveArray[0]).Target;
                                                else
                                                    lastPixel = ((TaggedUndirectedEdge<Pixel, EdgeTag>)newCurveArray[0]).Source;
                                            }
                                            else
                                            {
                                                lastPixel = getFirstPixel(newCurveArray);
                                                newCurveArray.Reverse();
                                            }
                                        }


                                        processedCurves.Add(newCurve);
                                        if (!lastPixel.Equals(firstPixel))
                                        {
                                            shape.Add(newCurve);
                                            hasCurve = true;
                                            break;
                                        }
                                        else // terminou o grupo de curvas
                                        {
                                            shape.Add(newCurve);
                                            shapes.Add(shape);
                                            hasCurve = false;
                                        }


                                    }
                                }


                            }

                        }
                    }
                    else
                    {
                        shapes.Add(shape);

                    }
                    shape = new Shape();
                }

            }

            //remove shapes iguais de cores diferentes
            ArrayList remove = new ArrayList();

            foreach (Shape shapeItem in shapes)
            {
                foreach (Shape shapeItem2 in shapes)
                {
                    if (!remove.Contains(shapeItem) && !remove.Contains(shapeItem2) && shapeItem.getColor() != Color.Beige && shapeItem2.getColor() != Color.Beige)
                        if ( shapeItem.getColor() != shapeItem2.getColor() && shapeItem.isSameShape(shapeItem2) )
                        {
                            Color c = new Color();
                            //localiza o pixel de cor dentro do poligono
                            foreach (Pixel v in g.Vertices)
                            {
                                if (v.pixelInsidePolygon(shapeItem.ToPoints()))
                                {
                                    c = v.color;
                                    break;
                                }
                            }

                            if (shapeItem.getColor() == c)
                            {
                                remove.Add(shapeItem2);
                                break;
                            }else
                            if (shapeItem2.getColor() == c)
                            {
                                remove.Add(shapeItem);
                                break;
                            }

                        }
                }

            }


            foreach (Shape item in remove)
            {
                shapes.Remove(item);

            }

            //Ordena do objeto com maior area para os de menor area
            shapes.Sort();

            SvgVector svg = new SvgVector();
            svg.Height = Height * scale;
            svg.Width = Width * scale;
            svg.scale = 1;

            return svg.NewImage(g, shapes, "NewImage.svg");
        }

        private Pixel getFirstPixel(ArrayList curve)
        {
            TaggedUndirectedEdge<Pixel, EdgeTag> firstEdge = (TaggedUndirectedEdge<Pixel, EdgeTag>)curve[0];
            if (curve.Count < 2)
                return firstEdge.Source;
            else
            {
                TaggedUndirectedEdge<Pixel, EdgeTag> secondEdge = (TaggedUndirectedEdge<Pixel, EdgeTag>)curve[1];
                if (firstEdge.Source.Equals(secondEdge.Target) || firstEdge.Source.Equals(secondEdge.Source))
                    return firstEdge.Target;
                else
                    return firstEdge.Source;
            }
        }

        private Pixel getLastPixel(ArrayList curve)
        {
            TaggedUndirectedEdge<Pixel, EdgeTag> lastEdge = (TaggedUndirectedEdge<Pixel, EdgeTag>)curve[curve.Count - 1];
            if (curve.Count < 2)
                return lastEdge.Target;
            else
            {
                TaggedUndirectedEdge<Pixel, EdgeTag> beforeLastEdge = (TaggedUndirectedEdge<Pixel, EdgeTag>)curve[curve.Count - 2];
                if (lastEdge.Source.Equals(beforeLastEdge.Target) || lastEdge.Source.Equals(beforeLastEdge.Source))
                    return lastEdge.Target;
                else
                    return lastEdge.Source;
            }
        }

        private int CurveSize(TaggedUndirectedEdge<Pixel, EdgeTag> edge)
        {
            int size = 0;
            bool hasEdge = true;
            TaggedUndirectedEdge<Pixel, EdgeTag> nextEdge1 = edge; //a primeira direção do vertice
            TaggedUndirectedEdge<Pixel, EdgeTag> nextEdge2 = edge; //a segunda direção do vertice
            if (edge.Source.valence == 2 || edge.Target.valence == 2)
            {
                size++;
                while (hasEdge)
                {

                    hasEdge = false;
                    if (nextEdge1.Source.valence == 2 && !nextEdge1.Source.Equals(edge.Source))
                    {
                        size++;
                        foreach (var e in g.AdjacentEdges(nextEdge1.Source))
                        {
                            if (!e.Equals(nextEdge1))
                            {
                                nextEdge1 = e;
                                hasEdge = true;
                            }
                        }
                    }

                    if (nextEdge2.Source.valence == 2 && !nextEdge1.Source.Equals(edge.Source))
                    {
                        size++;
                        foreach (var e in g.AdjacentEdges(nextEdge2.Source))
                        {
                            if (!e.Equals(nextEdge2))
                            {
                                nextEdge2 = e;
                                hasEdge = true;
                            }
                        }
                    }
                }
            }
            return size;
        }

        private double AngleBetween2Lines(TaggedUndirectedEdge<Pixel, bool> edge1, TaggedUndirectedEdge<Pixel, bool> edge2)
        {
            double angle1 = Math.Atan2(edge1.Source.y - edge1.Target.y
                                       , edge1.Source.x - edge1.Target.x);

            double angle2 = Math.Atan2(edge2.Source.y - edge2.Target.y
                            , edge2.Source.x - edge2.Target.x);

            return angle1 - angle2;
        }

        private Color PixelColorIs(int x, int y, UndirectedGraph<Pixel, TaggedUndirectedEdge<Pixel, EdgeTag>> g)
        {
            Pixel p = VertexSearch(x, y, g);
            if (p == null)
                return Color.Beige;
            else
                return (p.color);
        }

        private bool HasEdges(int x1, int y1, int x2, int y2, UndirectedGraph<Pixel, TaggedUndirectedEdge<Pixel, EdgeTag>> graph)
        {
            if (x1 > Width - 1 || x2 > Width - 1 || x1 < 0 || x2 < 0)
                return false;
            if (y1 > Height - 1 || y2 > Height - 1 || y1 < 0 || y2 < 0)
                return false;
            TaggedUndirectedEdge<Pixel, EdgeTag> ed;
            Pixel p1 = VertexSearch(x1, y1, graph);
            Pixel p2 = VertexSearch(x2, y2, graph);
            if (graph.TryGetEdge(p1, p2, out ed))
                return graph.TryGetEdge(p1, p2, out ed);
            else
                return graph.TryGetEdge(p2, p1, out ed);
        }

        public static Pixel VertexSearch(int x, int y, UndirectedGraph<Pixel, TaggedUndirectedEdge<Pixel, EdgeTag>> graph)
        {
            return graph.Vertices.SingleOrDefault(o => o.y == y && o.x == x);
         /*       
            foreach (var v in graph.Vertices)
            {

                //if (v.ToString() == Convert.ToString(x) + "-" + Convert.ToString(y))
                if(v.x == x && v.y == y)
                    return v;
            }
            return null;
           */
        }

        public static Pixel GetOrAddVertex(int x, int y, UndirectedGraph<Pixel, TaggedUndirectedEdge<Pixel, EdgeTag>> graph)
        {
            Pixel p = VertexSearch(x, y, graph);
            if (p == null)
            {
                p = new Pixel(x, y, Color.Blue);
                graph.AddVertex(p);
            }
            return p;
        }

        private static void AddNewEdge(Pixel p1, Pixel p2, Color cA, Color cB, UndirectedGraph<Pixel, TaggedUndirectedEdge<Pixel, EdgeTag>> graph)
        {
            TaggedUndirectedEdge<Pixel, EdgeTag> e;
            TaggedUndirectedEdge<Pixel, EdgeTag> e1;
            TaggedUndirectedEdge<Pixel, EdgeTag> e2;
            bool b = !cA.Equals(cB);

            graph.TryGetEdge(p1, p2, out e1);
            graph.TryGetEdge(p2, p1, out e2);
            p1.color = cA;
            p1.colorB = cB;
            p2.color = cA;
            p2.colorB = cB;

            if (e1 == null && e2 == null && b) // adicionado o "b" para adicionar apenas arestas visiveis ao grafo
            {
                e = new TaggedUndirectedEdge<Pixel, EdgeTag>(p1, p2, new EdgeTag(cA, cB, b));
                graph.AddEdge(e);
                if (b) //conta valencia apenas se for visivel
                {
                    p1.valence++;
                    p2.valence++;
                }
            }

        }

        public ArrayList curvesOfEdgesToPoints(ArrayList newCurvesOfEdges)
        {
            ArrayList curvesOfPoints = new ArrayList();
            ArrayList curveOfPoints = new ArrayList();
            Pixel lastPoint = null;
            Pixel firstPoint = null;
            foreach (ArrayList curveOfEdge in newCurvesOfEdges) // array de curvas
            {
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
                curvesOfPoints.Add(curveOfPoints);
            }
            return curvesOfPoints;
        }

    }

}