using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;



namespace DanmakuGameEngine
{
    public class CustomProfessionalRenderer:ToolStripProfessionalRenderer
    {
        private Color _color = Color.Red;
        public CustomProfessionalRenderer()
            : base()
        {
        }
        public CustomProfessionalRenderer(Color color)
            : base()
        {
            _color = color;
        }
        //获取圆角矩形区域  radius=直径
        public static GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            return path;
        }
        //渲染背景 包括menustrip背景 toolstripDropDown背景
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;//抗锯齿
            Rectangle bounds = e.AffectedBounds;
            SolidBrush lgbrush = new SolidBrush(Color.FromArgb(27,27,28));
            if (toolStrip is MenuStrip)
            {
              
            }
            else if (toolStrip is ToolStripDropDown)
            {
                GraphicsPath path = new GraphicsPath();
                Rectangle rect = new Rectangle(Point.Empty, toolStrip.Size);
                path.AddRectangle(rect);
                toolStrip.Region = new Region(path);
                g.FillPath(lgbrush, path);
                Pen pen = new Pen(Color.FromArgb(27, 27, 28));
                Pen pen1 = new Pen(Color.FromArgb(51, 51, 52));
                g.DrawLine(pen, 0, 0, toolStrip.Size.Width, 0);
                g.DrawLine(pen, 0, 1, 0, toolStrip.Size.Height);
                g.DrawLine(pen1, toolStrip.Size.Width-1, 0, toolStrip.Size.Width-1, toolStrip.Size.Height-1);
                g.DrawLine(pen1, 0, toolStrip.Size.Height-1, toolStrip.Size.Width-1, toolStrip.Size.Height-1);
            }
            else
            {
                
                base.OnRenderToolStripBackground(e);
            }
        }
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //不调用基类的方法 屏蔽掉该方法 去掉边框
        }


        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = Color.FromArgb(153, 153, 153);
            base.OnRenderArrow(e);
        }
        //渲染项 不调用基类同名方法
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            ToolStripItem item = e.Item;
            ToolStrip toolstrip = e.ToolStrip;


            //渲染顶级项
            if (toolstrip is MenuStrip)
            {
                SolidBrush lgbrush = new SolidBrush(Color.FromArgb(51,51,52));
                SolidBrush brush = new SolidBrush(Color.FromArgb(27,27,28));
                if (e.Item.Selected)
                {
                    GraphicsPath gp = GetRoundedRectPath(new Rectangle(new Point(0, 0), item.Size), 5);
                    g.FillPath(lgbrush, gp);
                }
                if (item.Pressed)
                {
                   
                    g.FillRectangle(brush, new Rectangle(Point.Empty, item.Size));
                }
            }
            //渲染下拉项
            else if (toolstrip is ToolStripDropDown)
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                SolidBrush lgbrush = new SolidBrush(Color.FromArgb(51, 51, 52));
                if (item.Selected)
                {
                    GraphicsPath gp = GetRoundedRectPath(new Rectangle(0, 0, item.Width, item.Height), 10);
                    g.FillPath(lgbrush, gp);
                }
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }



        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen1 = new Pen(Color.FromArgb(51, 51, 55));
            g.DrawLine(pen1, 3, e.Item.Height / 2, e.Item.Width, e.Item.Height / 2);
        }

        //渲染图片区域 下拉菜单左边的图片区域
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            //base.OnRenderImageMargin(e);
            //屏蔽掉左边图片竖条
        }
    }
}
