using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 * 1. ukol z KIV/KPG
 * Vykresleni krivky
 * @author Pavel Zelenka A16B0176P
 */
namespace KPGHomework
{
    public partial class Window : Form
    {
        private Graphics g;   // Ovladaci prvek pro kresleni 
        private Bitmap bitmap;// Reprezentace bitmapy ("papiru na kresleni")

        Homework homework;    // Trida, ve ktere budeme delat vsechny vypocty

        public Window()
        {
            // Inicializace zakladniho okna
            InitializeComponent();

            // Vytvorime novou bitmapu o velikosti naseho panelu
            this.bitmap = new Bitmap(activeCanvas.Width, activeCanvas.Height);

            // Obrazek, kteru bude vykreslen na panelu je nase bitmapa
            this.activeCanvas.Image = bitmap;

            // Rekneme ovladacimu prvku pro kresleni, na co muze kreslit (tzn. na nasi bitmapu)
            g = Graphics.FromImage(bitmap);

            // Chceme, aby se vysledna kresba vyhlazovala
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Premazeme celou Bitmapu cernou barvou
            g.Clear(Color.Black);
        }

        private void Window_Load(object sender, EventArgs e)
        {
            if (homework == null)
            {
                // Vytvorime novou instanci nasi vypocetni a vykreslovaci tridy
                homework = new Homework(g, activeCanvas);
                r_ext_textbox.Text = "100";
                r_int_textbox.Text = "60";
                d_len_textbox.Text = "100";
            }
        }

        /// <summary>
        /// Změní velikost obrázku na základě specifikované šířky a výšky.
        /// </summary>
        /// <param name="image">Obrázek, jehož velikost měníme.</param>
        /// <param name="width">Nová šířka obrázku.</param>
        /// <param name="height">Nová výška obrázku.</param>
        /// <returns>Obrázek s novou velikostí.</returns>
        public Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void Window_Resize(object sender, EventArgs e)
        {
            bitmap = ResizeImage(bitmap, activeCanvas.Width, activeCanvas.Height);
            activeCanvas.Image = bitmap;
        }

        private void activeCanvas_Click(object sender, EventArgs e)
        {

        }

        private void DrawHypotrochoidButton_Click(object sender, EventArgs e) {

        }

        /**
         * Prevede text na desetinne cislo
         * @param text textovy retezec
         * @return desetinne cislo
         */
        private double ConvertStringToDouble(String text) {
            double number = -1D;
            try {
                number = Convert.ToDouble(text);
            } catch (FormatException) {
                number = -1D;
                Console.WriteLine("Zadaná hodnota '{0}' není číslo.", text);
            } catch (OverflowException) {
                number = -1D;
                Console.WriteLine("Zadáná hodnota '{0}' je mimo požadovaný rozsah možných hodnot.", text);
            }
            return number;
        }

        /**
         * Zavola akci nakresleni kruznic
         */
        private void DrawCircleAction()
        {
            string r_ext_text = r_ext_textbox.Text;
            double r_ext_conv = ConvertStringToDouble(r_ext_text);

            string r_int_text = r_int_textbox.Text;
            double r_int_conv = ConvertStringToDouble(r_int_text);

            if (r_ext_conv <= 0) r_ext_conv = 100D;
            if (r_int_conv <= 0) r_ext_conv = 60D;

            homework.DrawCircle(r_ext_conv, r_int_conv);
        }

        /**
         * Zavola akci nakresleni hypotrochoidu
         */
        private void DrawHypotrochoidAction() {
            string r_ext_text = r_ext_textbox.Text;
            double r_ext_conv = ConvertStringToDouble(r_ext_text);

            string r_int_text = r_int_textbox.Text;
            double r_int_conv = ConvertStringToDouble(r_int_text);

            string d_len_text = d_len_textbox.Text;
            double d_len_conv = ConvertStringToDouble(d_len_text);

            if (r_ext_conv <= 0) {
                r_ext_conv = 100D;
                r_ext_textbox.Text = "100";
            }
            if (r_int_conv <= 0) {
                r_int_conv = 60D;
                r_int_textbox.Text = "60";
            }
            if (d_len_conv < 0) {
                d_len_conv = 100D;
                d_len_textbox.Text = "100";
            }

            homework.DrawHypotrochoid(r_ext_conv, r_int_conv, d_len_conv);
        }

        /**
         * Zavola akci vycisteni platna
         */
        private void ClearAction() {
            homework.Clear();
        }

        private void Draw_Hypotrochoid_Button_Click(object sender, EventArgs e) {
            DrawHypotrochoidAction();
        }

        private void Draw_Circle_Button_Click(object sender, EventArgs e) {
            DrawCircleAction();
        }

        private void Clear_Button_Click(object sender, EventArgs e) {
            ClearAction();
        }

        /*
         * =====================================================
         * ZDE SE BUDOU GENEROVAT NOVE METODY PRO OVLADACI PRVKY
         * =====================================================
         */
    }
}
