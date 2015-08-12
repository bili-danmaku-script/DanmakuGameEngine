using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreEditor
{   
    public partial class CoreEditor: UserControl
    {
        private int _mouseX;
        private int _mouseY;

        // Event
        public class ObjectSelectedEventArgs : EventArgs
        {

        }

        private delegate void ObjectSelectedHandler(object sender, ObjectSelectedEventArgs e);

        public event ObjectSelectedHandler ObjectSelected;

        public CoreEditor()
        {
            InitializeComponent();
        }

        private void coreEditor_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void coreEditor_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void CoreEditor_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
