using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace QLCafe.Presentation.Components
{
    public class RoundButton : Button
    {
        private int borderRadius = 25;

        [System.ComponentModel.Category("RoundButton")]
        [System.ComponentModel.Description("Bán kính bo góc của button")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                UpdateRegion();
                this.Invalidate();
            }
        }

        public RoundButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.FromArgb(120, 53, 111);
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            this.Size = new Size(180, 45);
            this.Cursor = Cursors.Hand;

            // Quan trọng: Set transparent cho hover effects
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void UpdateRegion()
        {
            if (this.Width <= 0 || this.Height <= 0) return;

            using (GraphicsPath path = new GraphicsPath())
            {
                int diameter = borderRadius * 2;
                diameter = Math.Min(diameter, Math.Min(this.Width, this.Height));

                path.AddArc(0, 0, diameter, diameter, 180, 90);
                path.AddArc(this.Width - diameter, 0, diameter, diameter, 270, 90);
                path.AddArc(this.Width - diameter, this.Height - diameter, diameter, diameter, 0, 90);
                path.AddArc(0, this.Height - diameter, diameter, diameter, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateRegion();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // KHÔNG gọi base.OnPaint - tự vẽ tất cả
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Vẽ nền
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            // Vẽ text
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle,
                                this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateRegion();
        }
    }
}