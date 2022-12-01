using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace TP2_LABII
{
    class DiagramaBarras
    {
        const int mSupAC = 10;
        const int mIzqAC = 20;
        const int mInfAC = 40;
        const int mDerAC = 10;

        const int espacioB = 5;

        public DiagramaBarras() { }
        public void Graficar(List<int> y,
                                string[] rotulos,
                                string titulo,
                                string etiquetaHorizontal,
                                string etiquetaVertical,
                                System.Drawing.Graphics graphics,
                                int anchoAC, int altoAC)
        {
            if (graphics != null)
            {
                SolidBrush brushAC = new SolidBrush(Color.Transparent);
                Pen penAG = new System.Drawing.Pen(Color.Black);
                SolidBrush brushB = new SolidBrush(System.Drawing.Color.MediumSlateBlue);
                Pen penB = new Pen(Color.Black);
                Font fontTitulo = null;
                SolidBrush brushTitulo = new SolidBrush(Color.Black);
                SolidBrush brushVE = null;
                Font fontVE = null;
                Font fontHE = null;
                SolidBrush brushHE = null;
                Font fontB = null;
                StringFormat stringFormatB = null;
                SolidBrush brushR = null;

                try
                {
                    //pintar de blanco el area de fondo
                    int supAC = 0;
                    int izqAC = 0;
                    graphics.FillRectangle(brushAC, izqAC, supAC, anchoAC, altoAC);

                    //dibujar recuadro area grafico
                    int supAG = supAC + mSupAC;
                    int izqAG = izqAC + mIzqAC;
                    int anchoAG = anchoAC - (mIzqAC + mDerAC);
                    int altoAG = altoAC - (mSupAC + mInfAC);
                    graphics.DrawRectangle(penAG, izqAG, supAG, anchoAG, altoAG);

                    //dibujar el título
                    int supTitulo = 2;
                    int izqTitulo = 2;
                    int alturaLetra = mSupAC - 6;
                    fontTitulo = new System.Drawing.Font("Arial", alturaLetra);
                    int anchoTitulo = titulo.Length * alturaLetra;
                    izqTitulo = (anchoAC - anchoTitulo) / 2;
                    graphics.DrawString(titulo, fontTitulo, brushTitulo, izqTitulo, supTitulo);

                    //dibujar etiqueta vertical
                    //__VE ___ Vertical Etiqueta
                    /*probar esto, rota todo el graphics:*/
                    //graphics.TranslateTransform(0, altoAC);
                    //graphics.RotateTransform(270);
                    //graphics.DrawString("Hola, Mundo", fontTitulo, Brushes.Black, 0, 0);


                    int supVE = 0;
                    int izqVE = 0;
                    fontVE = new System.Drawing.Font("Arial", 16);
                    brushVE = new System.Drawing.SolidBrush(Color.Black);
                    StringFormat stringFormatVE = new StringFormat(StringFormatFlags.DirectionVertical);
                    SizeF sizefVE = graphics.MeasureString(etiquetaVertical, fontVE,

                    Int32.MaxValue, stringFormatVE);
                    supVE = (mDerAC - Convert.ToInt32(sizefVE.Width)) / 2;
                    izqVE = (altoAC - Convert.ToInt32(sizefVE.Height)) / 2;
                    graphics.DrawString(etiquetaVertical, fontVE, brushVE,
                    supVE, izqVE, stringFormatVE);

                    //dibujar etiqueta vertical
                    //__HE ___ Horizontal Etiqueta
                    int supHE = 0;
                    int izqHE = 0;
                    fontHE = new Font("Arial", 16);
                    brushHE = new SolidBrush(Color.Black);
                    StringFormat stringFormatHE = new StringFormat();
                    SizeF sizefHE = graphics.MeasureString(etiquetaHorizontal, fontHE,
                    Int32.MaxValue, stringFormatHE);
                    supHE = altoAC - (mInfAC + Convert.ToInt32(sizefHE.Height)) / 2;
                    izqHE = (anchoAC - Convert.ToInt32(sizefHE.Width)) / 2;
                    graphics.DrawString(etiquetaHorizontal, fontHE, brushHE, izqHE, supHE,
                    stringFormatHE);

                    //__R Rótulos
                    brushR = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                    if (y != null && y.Count > 0)
                    {
                        //calcular escala en y
                        double escalaY = altoAG * 1.0 / calcularMaximo(y.ToArray());
                        //calcular escala en x:
                        double escalaX = (anchoAG - espacioB * y.Count) * 1.0 / y.Count;
                        fontB = new System.Drawing.Font("Arial", 16);
                        //dibujar las barras
                        for (int i = 0; i < y.Count; i++)
                        {
                            //top,left,bottom,reight
                            //coordenada izquierda superior
                            int supB = Convert.ToInt32(supAG + altoAG - y[i] * escalaY);
                            int altoB = Convert.ToInt32(y[i] * escalaY);
                            //coordenada derecha inferior
                            int izqB = Convert.ToInt32(izqAG + i * (escalaX + espacioB) +
                            espacioB);
                            int anchoB = Convert.ToInt32(escalaX);
                            //llenando barra con color azul
                            graphics.FillRectangle(brushB, izqB, supB, anchoB, altoB);
                            //creando borde con color negro a esta barra
                            graphics.DrawRectangle(penB, izqB, supB, anchoB, altoB);
                            //dibujando rótulos
                            string rotulo = "*";

                            if (rotulos != null && i < rotulos.Length)
                                rotulo = rotulos[i];
                            int supR = supB;
                            int izqR = Convert.ToInt32(izqB + (escalaX - espacioB) / 2);
                            graphics.DrawString(rotulo, fontB, brushR, izqR, supR,
                            stringFormatB);
                        }
                    }
                }
                catch (Exception e)
                {
                }
                finally
                {
                    brushAC.Dispose();
                    penAG.Dispose();
                    brushB.Dispose();
                    penB.Dispose();
                    if (fontTitulo != null)
                        fontTitulo.Dispose();
                    brushTitulo.Dispose();
                    brushVE.Dispose();
                    fontVE.Dispose();
                    fontHE.Dispose();
                    brushHE.Dispose();
                    //fontB.Dispose();
                    brushR.Dispose();
                }
            }
            else
            {
                throw new Exception("Error al intentar dibujar el gráfico.");
            }
        }

        protected int calcularMaximo(int[] y)
        {
            int ymax = 0;
            if (y != null)
            {
                foreach (int yi in y)
                {
                    if (ymax < yi)
                    {
                        ymax = yi;
                    }
                }
            }
            return ymax;
        }
    }
}
