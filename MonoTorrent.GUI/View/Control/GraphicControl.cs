using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections.Specialized;

namespace MonoTorrent.GUI.View.Control
{
    public partial class GraphicControl : UserControl
    {
        public GraphicControl()
        {
            InitializeComponent();
        }

        #region private field

        private List<double> downloadPoints = new List<double>();
        private List<double> uploadPoints = new List<double>();
        private Color clrDownTotal = Color.FromArgb(0,0,128);
        private Color clrUpTotal = Color.FromArgb(0,100,255);
        private int marge = 15;
        private Font font = new Font("Arial", 8.0f, FontStyle.Bold, GraphicsUnit.Point, 0x00);
        private float Ypercent = 0.80f;
        private int MaxPointCount = 30;
		
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            this.DrawBackGround(e.Graphics);

            this.DrawAxe(e.Graphics);
            
            this.DrawGrid(e.Graphics);

            this.DrawCurve(e.Graphics);

            base.OnPaint(e);
        }


        #region manage points

        public void AddDownloadValue(double value)
        {
            downloadPoints.Add(value);
            //to have a limited graph
            if (downloadPoints.Count > MaxPointCount)
                downloadPoints.RemoveAt(0);
        }

        public void AddUploadValue(double value)
        {
            uploadPoints.Add(value);
            //to have a limited graph
            if (uploadPoints.Count > MaxPointCount)
                uploadPoints.RemoveAt(0);
        }

        #endregion

        #region helper


        private double GetMaxSpeed()
        {
            double max = 1;
            for (int i = 0; i < downloadPoints.Count; i++)
            {
                if (downloadPoints[i] > max)
                    max = downloadPoints[i];
            }
            for (int i = 0; i < uploadPoints.Count; i++)
            {
                if (uploadPoints[i] > max)
                    max = uploadPoints[i];
            }
            return max;
        }

        public string FormatSpeedValue(double value)
        {
            if (value < 1024)
                return String.Format("{0:0.00} KB/s", value);
            if (value < 1024 * 1024)
                return String.Format("{0:0.00} MB/s", value / (1024));

            return String.Format("{0:0.00} GB/s", value / (1024 * 1024));
        }
        #endregion

        #region Draw


        private void DrawBackGround(Graphics g)
        {
            using (LinearGradientBrush background = new LinearGradientBrush(this.Bounds, Color.LightBlue, Color.LightGray, LinearGradientMode.BackwardDiagonal))
            {
                g.FillRectangle(background, marge, marge, this.Width - 2 * marge, this.Height - 2 * marge);
            }
        }

        public void DrawAxe(Graphics g)
        {
            Pen penAxe = new Pen(Color.Black, 2);
            
            //coord in control
            //--------x
            //|
            //|
            //|y

            //Y
            g.DrawLine(penAxe, marge, marge, marge, this.Height - marge);
            //Y name
            penAxe.Color = Color.Black;
            g.DrawString("Total: ", font, penAxe.Brush, marge + 5, marge + 5);
            penAxe.Color = clrDownTotal;
            g.DrawString("down", font, penAxe.Brush, marge + 60,  marge + 5);
            penAxe.Color = clrUpTotal;
            g.DrawString("up", font, penAxe.Brush, marge + 100, marge + 5);
            
            //X
            penAxe.Color = Color.Black;
            g.DrawLine(penAxe, marge, this.Height - marge, this.Width - marge, this.Height - marge);
            g.DrawString("Time", font, penAxe.Brush, this.Width - marge - 20, this.Height - marge + 2);
        }

        private void DrawGrid(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 1);

            //coord in control
            //--------x
            //|
            //|
            //|y


            double maxValue = Math.Round(GetMaxSpeed()/Ypercent, 2, MidpointRounding.AwayFromZero);

            g.DrawLine(pen, marge, marge, this.Width - marge, marge);

            g.DrawLine(pen, marge, marge + (this.Height - 2 * marge) / 3, this.Width - marge, marge + (this.Height - 2 * marge) / 3);
            string sv = FormatSpeedValue((maxValue * 2) / 3);
            g.DrawString(sv, font, pen.Brush, this.Width - marge - (sv.Length * 6), marge + (this.Height - 2 * marge) / 3 - 15);

            g.DrawLine(pen, marge, marge + ((this.Height - 2 * marge) * 2)/ 3, this.Width - marge, marge + ((this.Height - 2 * marge) * 2) / 3);
            sv = FormatSpeedValue(maxValue / 3);
            g.DrawString(sv, font, pen.Brush, this.Width - marge - (sv.Length * 6), marge + ((this.Height - 2 * marge) * 2) / 3 - 15);
            
        }

        public void DrawCurve(Graphics g)
        {
            //coord in control
            //--------x
            //|
            //|
            //|y
            Pen pen = new Pen(clrDownTotal, 2);
            float ratioY = (this.Height - 2.0f * marge) / (float)GetMaxSpeed() * Ypercent;
            float ratioX = (this.Width - 2.0f * marge) / (float)(MaxPointCount - 1);
            
            // Total download
            for(int i=0; i< downloadPoints.Count-1;i++)
            {
                g.DrawLine(pen,
                    marge + i * ratioX,
                    (float)(this.Height - marge - downloadPoints[i] * ratioY),
                    marge + (i + 1) * ratioX,
                    (float)(this.Height - marge - downloadPoints[i + 1] * ratioY));
            }

            // Total upload
            ratioY = (this.Height - 2.0f * marge) / (float)GetMaxSpeed() * 0.80f;
            pen.Color = clrUpTotal;
            for (int i = 0; i < uploadPoints.Count - 1; i++)
            {
                g.DrawLine(pen,
                    marge + i * ratioX,
                    (float)(this.Height - marge - uploadPoints[i] * ratioY),
                    marge + (i + 1) * ratioX,
                    (float)(this.Height - marge - uploadPoints[i + 1] * ratioY));
            }
        }

        #endregion
    }
}
