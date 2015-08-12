using System;
using System.Collections;
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
        public enum RefreshModeEnum { Interval, EnterFrame };
        public enum CoordinateModeEnum { XY, UV };
        public enum ScreenResolutionEnum { None, Stretch, Zoom };

        private RefreshModeEnum _refreshMode = RefreshModeEnum.EnterFrame;
        private CoordinateModeEnum _coordinateMode = CoordinateModeEnum.UV;
        private ScreenResolutionEnum _screenResolution = ScreenResolutionEnum.None;
        private bool _coordinateTransform = false;
        private ArrayList _objects = new ArrayList();

        private int _mouseX;
        private int _mouseY;

        // property

        /// <summary>
        /// 获取或设置游戏的画面刷新模式
        /// </summary>
        /// <value>setting</value>
        public RefreshModeEnum RefreshMode
        {
            get
            {
                return this._refreshMode;
            }
            set
            {
                this._refreshMode = value;
            }
        }
        /// <summary>
        /// 获取或设置游戏的坐标系方案
        /// </summary>
        public CoordinateModeEnum CoordinateMode
        {
            get
            {
                return this._coordinateMode;
            }
            set
            {
                this._coordinateMode = value;
            }
        }
        /// <summary>
        /// 获取或设置游戏的屏幕适配方案
        /// </summary>
        public ScreenResolutionEnum ScreenResolution
        {
            get
            {
                return this._screenResolution;
            }
            set
            {
                this._screenResolution = value;
            }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        public bool CoordinateTransform
        {
            get
            {
                return this._coordinateTransform;
            }
            set
            {
                this._coordinateTransform = value;
            }
        }
        /// <summary>
        /// 获取或设置物件池
        /// </summary>
        public ArrayList Objects
        {
            get
            {
                return this._objects;
            }
            set
            {
                this._objects = new ArrayList(value);
            }
        }
        
        // Event
        public class ObjectSelectedEventArgs : EventArgs
        {
            
        }

        public delegate void ObjectSelectedHandler(object sender, ObjectSelectedEventArgs e);

        public event ObjectSelectedHandler ObjectSelected;

        public CoreEditor()
        {
            InitializeComponent();
        }

        public void create_object()
        {
            
        }

        private void CoreEditor_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }

    public class GameObject
    {
        public GameObject()
        {

        }
    }
}
