using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QLCafe.Presentation.Components
{
    // Simple rounded panel for modern UI cards and inputs
    public class RoundedPanel : Panel
    {
        private int _cornerRadius = 18;
        private Color _borderColor = Color.Transparent;
        private int _borderThickness = 0;

        [Category("RoundedPanel")]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = Math.Max(0, value); UpdateRegion(); Invalidate(); }
        }

        [Category("RoundedPanel")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Category("RoundedPanel")]
        public int BorderThickness
        {
            get => _borderThickness;
            set { _borderThickness = Math.Max(0, value); Invalidate(); }
        }

        public RoundedPanel()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | 
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.White;
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            UpdateRegion();
        }

        private void UpdateRegion()
        {
            if (Width <= 0 || Height <= 0) return;
            
            using (GraphicsPath path = GetRoundRectanglePath(ClientRectangle, _cornerRadius))
            {
                Region = new Region(path);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            
            // V? background
            using (GraphicsPath path = GetRoundRectanglePath(ClientRectangle, _cornerRadius))
            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            // V? border n?u có
            if (_borderThickness > 0 && _borderColor.A > 0)
            {
                // ?i?u ch?nh rectangle ?? border v? chính xác
                Rectangle borderRect = new Rectangle(
                    _borderThickness / 2,
                    _borderThickness / 2,
                    Width - _borderThickness,
                    Height - _borderThickness
                );

                using (GraphicsPath borderPath = GetRoundRectanglePath(borderRect, _cornerRadius))
                using (Pen pen = new Pen(_borderColor, _borderThickness))
                {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, borderPath);
                }
            }
            
            // G?I base.OnPaint nh?ng không v? l?i border
            base.OnPaintBackground(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Không làm gì - ?? OnPaint x? lý background
        }

        private static GraphicsPath GetRoundRectanglePath(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0 || bounds.Width <= 0 || bounds.Height <= 0)
            {
                path.AddRectangle(bounds);
                return path;
            }
            
            int d = Math.Min(radius * 2, Math.Min(bounds.Width, bounds.Height));
            Rectangle arc = new Rectangle(bounds.Location, new Size(d, d));
            
            // top-left
            path.AddArc(arc, 180, 90);
            // top-right
            arc.X = bounds.Right - d;
            path.AddArc(arc, 270, 90);
            // bottom-right
            arc.Y = bounds.Bottom - d;
            path.AddArc(arc, 0, 90);
            // bottom-left
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
