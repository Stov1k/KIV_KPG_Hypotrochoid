using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPGHomework
{
    class Homework {

        private const int MAX_PEN_WIDTH = 5;// Sirka pera pro vykresleni objektu (usecka, kruznice,...)

        private Graphics g;                 // Ovladaci prvek pro kresleni 
        private PictureBox activeCanvas;    // Ovladaci prvek pro zobrazeni obrazku, tzv. platno

        private Timer timer = new Timer();      // Casovac
        private int tickCount;              // Pocet tiku
        private bool isRunning;             // Bezi animace nebo je pozastavena? 
        private int steps = 360;           // Pocet kroku animace (napr. pocet casti usecky)

        private int width;  // Sirka soucasne vykreslovaci oblasti
        private int height; // Vyska soucasne vykreslovaci oblasti

        private double r_external = 50;
        private double r_internal = 30;
        private double d_length = 50;

        private List<PointF> hypotrochoid_points = new List<PointF>();
        private List<PointF> external_circle_points = new List<PointF>();
        private List<PointF> centre_of_internal_circle_points = new List<PointF>();

        public Homework(Graphics g, PictureBox activeCanvas) {
            Console.WriteLine("Predmet: KIV/KPG\nUkol: Homework 1\nAutor: Pavel Zelenka A16B0176P");

            this.g = g;                       // Nastaveni prvku pro kresleni
            this.activeCanvas = activeCanvas; // Nastaveni vykreslovaciho platna

            this.isRunning = false;           // Animace nebezi

            this.width = activeCanvas.Width;     // Nastaveni aktualni sirky okna
        }

        /**
         * Vycisteni vykreslovaci oblasti
         */
        internal void Clear() {
            if(timer != null) {
                isRunning = false; // Animace nebezi
                timer.Stop();      // Zastav casovac
            }
            g.Clear(Color.Black);   // Premaz platno cernou barvou
            activeCanvas.Invalidate();  // Promitni zmeny na vykreslovaci platno

        }

        /**
         * Animace vykresleni kruznic
         * @param r_internal polomer vnitrni kruznice
         * @param r_external polomer vnejsi kruznice
         */
        internal void DrawCircle(double r_internal, double r_external) {
            if (isRunning) {   // Pokud bezi animace
                timer.Stop();       // Zastav casovac
            }

            this.external_circle_points.Clear();               // vyprazdneni seznamu bodu
            this.centre_of_internal_circle_points.Clear();     // vyprazdneni seznamu bodu
            this.steps = 360;                                  // pocet kroku
            this.r_external = r_external;                      // polomer vnejsi kruznice
            this.r_internal = r_internal;                      // polomer vnitrni kruznice

            tickCount = 0;       // Pocet tiku je nula
            isRunning = true;    // Animace bezi

            this.timer = new Timer();                                   // Inicializuj novy casovac
            this.timer.Tick += new EventHandler(DrawingCircle);   // Pri kazdem tiku spusti metodu DrawingLine

            this.timer.Interval = 1;  // 1 ms mezi kazdym tikem
            this.timer.Enabled = true;// Casovac je povolen
            this.timer.Start();       // Spust casovac
        }

        /**
         * Jeden krok vykresu kruznice
         */
        private void DrawingCircle(object sender, EventArgs e) {

            // smazani platna
            g.Clear(Color.Black);

            // uhel v tomto kroku
            double theta = GetAngle(this.tickCount, this.steps);

            // vnejsi kruznice
            double R = this.r_internal;
            PointF S = new PointF(activeCanvas.Width / 2, activeCanvas.Height / 2);

            // bod A na vnejsi kruznici
            PointF A = GetPointOnCircle(S, R, theta);

            // vnitrni kruznice
            double r = this.r_external;
            float distance_of_s = (float)((R - r) / R);
            PointF s1 = GetMidPoint(S, A, distance_of_s);     // stred vnitrni kruznice

            // uhel v dalsim kroku
            double theta2 = GetAngle(this.tickCount + 1, this.steps);

            // bod B na vnejsi kruznici (s uhlem dalsiho kroku)
            PointF B = GetPointOnCircle(S, R, theta2);

            // vnitrni kruznice
            PointF s2 = GetMidPoint(S, B, distance_of_s);    // stred vnitrni kruznice (s uhlem dalsiho kroku)

            if (this.tickCount < this.steps) {
                this.tickCount++;

                // pridani prvniho bodu vnejsi kruznice
                if (external_circle_points.Count < 1) {
                    external_circle_points.Add(A);
                }

                // pridani noveho bodu vnejsi kruznice
                external_circle_points.Add(B);

                // stetec vnejsi kruznice
                Pen ext_circle_pen = new Pen(Color.Yellow, MAX_PEN_WIDTH);

                // predchozi bod vnejsi kruznice
                PointF ext_circle_prev = new PointF();             // to vazne nejde nastavit na NULL ??? :-/
                bool ext_circle_prev_init = false;

                // propojeni bodu vnejsi kruznice
                foreach (PointF point in external_circle_points) {
                    if (!ext_circle_prev_init) {
                        ext_circle_prev = point;
                        ext_circle_prev_init = true;
                    } else {
                        g.DrawLine(ext_circle_pen, ext_circle_prev.X, ext_circle_prev.Y, point.X, point.Y);
                        ext_circle_prev = point;
                    }
                }

                // pridani prvniho bodu stredu vnitrni kruznice
                if (centre_of_internal_circle_points.Count < 1) {
                    centre_of_internal_circle_points.Add(s1);
                }

                // pridani noveho bodu stredu vnitrni kruznice
                centre_of_internal_circle_points.Add(s2);

                // stetec bodu stredu vnitrni kruznice
                Pen int_circle_pen = new Pen(Color.Aqua, MAX_PEN_WIDTH);

                // predchozi bod stredu vnitrni kruznice
                PointF int_circle_prev = new PointF();             // to vazne nejde nastavit na NULL ??? :-/
                bool int_circle_prev_init = false;

                // propojeni bodu stredu vnitrni kruznice
                foreach (PointF point in centre_of_internal_circle_points) {
                    if (!int_circle_prev_init) {
                        int_circle_prev = point;
                        int_circle_prev_init = true;
                    } else {
                        g.DrawLine(int_circle_pen, int_circle_prev.X, int_circle_prev.Y, point.X, point.Y);
                        int_circle_prev = point;
                    }
                }
            } else {
                tickCount = 0;
                this.timer.Stop();
            }

            // zakresleni zmen na platno
            activeCanvas.Invalidate();
        }

        /**
         * Animace vykresleni hypotrochoidu
         * @param r_internal polomer vnitrni kruznice
         * @param r_external polomer vnejsi kruznice
         * @param d_length delka d od stredu vnitrni kruznice
         */
        internal void DrawHypotrochoid(double r_internal, double r_external, double d_length) {
            if (isRunning) {   // Pokud bezi animace
                timer.Stop();       // Zastav casovac
            }

            this.hypotrochoid_points.Clear();   // vyprazdneni seznamu bodu
            this.steps = 3600;                  // pocet kroku
            this.r_external = r_external;       // polomer vnejsi kruznice
            this.r_internal = r_internal;       // polomer vnitrni kruznice
            this.d_length = d_length;           // delka d

            tickCount = 0;       // Pocet tiku je nula
            isRunning = true;    // Animace bezi

            this.timer = new Timer();                                   // Inicializuj novy casovac
            this.timer.Tick += new EventHandler(DrawingHypotrochoid);   // Pri kazdem tiku spusti metodu DrawingLine

            this.timer.Interval = 1;  // 1 ms mezi kazdym tikem
            this.timer.Enabled = true;// Casovac je povolen
            this.timer.Start();       // Spust casovac
        }

        /**
         * Jeden krok vykresu hypotrochoidu
         */
        private void DrawingHypotrochoid(object sender, EventArgs e) {

            // smazani platna
            g.Clear(Color.Black);

            // uhel v tomto kroku
            double theta = GetAngle(this.tickCount, this.steps);

            // vnejsi kruznice
            double R = this.r_internal;
            PointF S = new PointF(activeCanvas.Width / 2, activeCanvas.Height / 2);

            // vnitrni kruznice
            double r = this.r_external;
            float distance_of_s = (float)((R - r) / R);

            // vzdalenost od stredu vnitrni kruznice
            double d = this.d_length;

            // bod hypotrochoidy
            PointF H1 = new PointF((float)HypotrochoidX(R, r, theta, d) + S.X, (float)HypotrochoidY(R, r, theta, d) + S.Y);

            // uhel v dalsim kroku
            double theta2 = GetAngle(this.tickCount + 1, this.steps);

            // bod hypotrochoidy (s uhlem dalsiho kroku)
            PointF H2 = new PointF((float)HypotrochoidX(R, r, theta2, d) + S.X, (float)HypotrochoidY(R, r, theta2, d) + S.Y);

            if (this.tickCount < this.steps) {
                this.tickCount++;

                // pridani prvniho bodu hypotrochoidy
                if (hypotrochoid_points.Count < 1) {
                    hypotrochoid_points.Add(H1);
                }

                // pridani noveho bodu hypotrochoidy
                hypotrochoid_points.Add(H2);

                // stetec
                Pen pen = new Pen(Color.Red, MAX_PEN_WIDTH);

                // predchozi bod hypotrochoidy
                PointF prev = new PointF();             // to vazne nejde nastavit na NULL ??? :-/
                bool prev_initialized = false;

                // vykresleni vnejsi kruznice
                g.DrawLine(new Pen(Color.Yellow, 2), (int)(S.X - 3), (int)(S.Y), (int)(S.X + 3), (int)(S.Y));
                g.DrawLine(new Pen(Color.Yellow, 2), (int)(S.X), (int)(S.Y - 3), (int)(S.X), (int)(S.Y + 3));
                g.DrawEllipse(new Pen(Color.Yellow, 2), (int)(S.X-R), (int)(S.Y-R), (int)(2 *R), (int)(2 *R));

                // vnitrni kruznice
                PointF A = GetPointOnCircle(S, R, theta);
                PointF s1 = GetMidPoint(S, A, distance_of_s);     // stred vnitrni kruznice
                g.DrawLine(new Pen(Color.Aqua, 2), (int)(s1.X - 3), (int)(s1.Y), (int)(s1.X + 3), (int)(s1.Y));
                g.DrawLine(new Pen(Color.Aqua, 2), (int)(s1.X), (int)(s1.Y - 3), (int)(s1.X), (int)(s1.Y + 3));
                g.DrawEllipse(new Pen(Color.Aqua, 2), (int)(s1.X - r), (int)(s1.Y - r), (int)(2 * r), (int)(2 * r));

                // usecka ze stredu vnitrni kruznice s do noveho bodu hypotrochoidy
                g.DrawLine(new Pen(Color.LimeGreen, 2), s1.X, s1.Y, H2.X, H2.Y);

                // propojeni bodu hypotrochoidy
                foreach (PointF point in hypotrochoid_points) {
                    if(!prev_initialized) {
                        prev = point;
                        prev_initialized = true;
                    } else {
                        g.DrawLine(pen, prev.X, prev.Y, point.X, point.Y);
                        prev = point;
                    }
                }
            } else {
                tickCount = 0;
                this.timer.Stop();
            }

            activeCanvas.Invalidate();
        }

        /**
         * Vrati soradnici na ose X
         * @param R polomer vnejsi kruznice
         * @param r polomer vnitrni kruznice
         * @param theta uhel
         * @param d vzdalenost stredu vnitrni kruznice od stredu vnejsi kruznice
         * @return pozice na ose X
         */
        private double HypotrochoidX(double R, double r, double theta, double d) {
            double x0 = (R - r) * Math.Cos(theta) + d * Math.Cos(((R - r) / r) * theta);
            return x0;
        }

        /**
         * Vrati soradnici na ose Y
         * @param R polomer vnejsi kruznice
         * @param r polomer vnitrni kruznice
         * @param theta uhel
         * @param d vzdalenost stredu vnitrni kruznice od stredu vnejsi kruznice
         * @return pozice na ose Y
         */
        private double HypotrochoidY(double R, double r, double theta, double d) {
            double y0 = (R - r) * Math.Sin(theta) - d * Math.Sin(((R - r) / r) * theta);
            return y0;
            
        }

        /**
         * Prevede stupne na radiany
         * @param angle stupne
         * @return radiany
         */
        private double DegreeToRadian(double angle) {
            return Math.PI * angle / 180.0;
        }

        /**
         * Vrati uhel v radianech
         * @param current soucasna hodnota
         * @param max maximalni hodnota
         * @return uhel v radianech
         */
        private double GetAngle(int current, int max) {
            double angle = DegreeToRadian((float)current % (float)max);
            return angle;
        }

        /**
         * Vrati bod na kruznici
         * @param centre stred S
         * @param radius polomer R
         * @param theta uhel
         * @return vrati bod na kruznici
         */
        private PointF GetPointOnCircle(PointF centre, double radius, double theta) {
            float x1 = (float)(centre.X + radius * Math.Cos((float)theta));
            float y1 = (float)(centre.Y + radius * Math.Sin((float)theta));
            PointF A = new PointF(x1, y1);
            return A;
        }

        /**
         * Vrati bod mezi 2 body
         * @param object1 pozice bodu
         * @param object2 pozice bodu
         * @param percentage procentualni vzdalenost bodu od object1 k object2
         * @return bod mezi 2 body
         */
        private PointF GetMidPoint(PointF object1, PointF object2, float percentage) {
            float maxX = Math.Max(object1.X, object2.X);
            float minX = Math.Min(object1.X, object2.X);
            float maxY = Math.Max(object1.Y, object2.Y);
            float minY = Math.Min(object1.Y, object2.Y);
            float locX = 0f;
            float locY = 0f;
            if (object1.X <= object2.X && object1.Y >= object2.Y) {
                locX = minX + ((maxX - minX) * percentage);
                locY = maxY - ((maxY - minY) * percentage);
            } else if (object1.X >= object2.X && object1.Y >= object2.Y) {
                locX = maxX - ((maxX - minX) * percentage);
                locY = maxY - ((maxY - minY) * percentage);
            } else if (object1.X >= object2.X && object1.Y <= object2.Y) {
                locX = maxX - ((maxX - minX) * percentage);
                locY = minY + ((maxY - minY) * percentage);
            } else if (object1.X <= object2.X && object1.Y <= object2.Y) {
                locX = minX + ((maxX - minX) * percentage);
                locY = minY + ((maxY - minY) * percentage);
            }
            PointF midPoint = new PointF(locX, locY);
            return midPoint;
        }

        /**
         * Vrati stredni bod mezi 2 body
         * @param object1 pozice bodu
         * @param object2 pozice bodu
         * @return stredni bod mezi 2 body
         */
        private PointF GetMidPoint(PointF object1, PointF object2) {
            PointF midPoint = new PointF(0.5f * (object1.X + object2.X), 0.5f * (object1.Y + object2.Y));
            return midPoint;
        }

        /**
         * Vrati smerovy vektor
         * @param object1 pozice bodu
         * @param object2 pozice bodu
         * @return smerovy vektor
         */
        private PointF GetDirectionalVector(PointF object1, PointF object2) {
            float x1 = object1.X;
            float y1 = object1.Y;
            float x2 = object2.X;
            float y2 = object2.Y;
            // smerovy vektor
            float sx = x2 - x1;
            float sy = y2 - y1;
            PointF vector = new PointF(sx, sy);
            return vector;
        }

        /**
         * Vrati vzdalenost mezi 2 body
         * @param object1 pozice bodu
         * @param object2 pozice bodu
         * @return vzdalenost
         */
        private float GetDistance(PointF object1, PointF object2) {
            // smerovy vektor
            PointF v = GetDirectionalVector(object1, object2);
            // delka smeroveho vektoru
            float dv = (float) Math.Sqrt(v.X * v.X + v.Y * v.Y);
            // Console.WriteLine("Vzdalenost mezi body je " + dv);
            return dv;
        }

    }
}
