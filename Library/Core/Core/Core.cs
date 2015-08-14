using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Components;

namespace Core
{
    /// <summary>
    /// Manager单例类提供了一组管理游戏物件的方法
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// 表示坐标系模式的枚举型
        /// </summary>
        public enum CoordinateModes { XY, UV };
        /// <summary>
        /// 表示画面更新模式的枚举型
        /// </summary>
        public enum UpdateModes { interval, enterFrame };
        /// <summary>
        /// 表示屏幕适配方案的枚举型
        /// </summary>
        public enum ScreenResolutions { None, Stretch, Zoom };

        private static Manager _instance = null;
        private CoordinateModes _coordinateMode;
        private UpdateModes _updateMode;
        private ScreenResolutions _screenResolution;
        private List<GameObject> _pool = new List<GameObject>();
        
        private Manager()
        {
            this._coordinateMode = CoordinateModes.UV;
            this._updateMode = UpdateModes.enterFrame;
            this._screenResolution = ScreenResolutions.None;
        }

        /// <summary>
        /// 获取或设置游戏的坐标系模式
        /// </summary>
        public CoordinateModes CoordinateMode
        {
            set
            {
                this._coordinateMode = value;
            }
            get
            {
                return this._coordinateMode;
            }
        }
        /// <summary>
        /// 获取或设置游戏的画面更新模式
        /// </summary>
        public UpdateModes UpdateMode
        {
            set
            {
                this._updateMode = value;
            }
            get
            {
                return this._updateMode;
            }
        }
        /// <summary>
        /// 获取或设置游戏的屏幕适配方案
        /// </summary>
        public ScreenResolutions ScreenResolution
        {
            set
            {
                this._screenResolution = value;
            }
            get
            {
                return this._screenResolution;
            }
        }

        /// <summary>
        /// 向物件池中添加一个新的游戏物件
        /// </summary>
        /// <param name="newObject">要添加的GameObject实例</param>
        public void create_object(GameObject newObject)
        {
            this._pool.Add(newObject);
        }
        
        /// <summary>
        /// 从物件池中移除一个游戏物件
        /// </summary>
        /// <param name="index">游戏物件的顺序编号</param>
        public void remove_object(int index)
        {
            this._pool.RemoveAt(index);
        }
        
        /// <summary>
        /// 从物件池中移除一个游戏物件
        /// </summary>
        /// <param name="gameObject">一个存在于物件池中的游戏物件</param>
        public void remove_object(GameObject gameObject)
        {
            this._pool.Remove(gameObject);
        }

        public void insert_object(GameObject gameObject, int index)
        {
            this._pool.Insert(index, gameObject);
        }

        public GameObject get_object(int index)
        {
            return this._pool[index];
        }

        /// <summary>
        /// 获取Manager单例类的实例
        /// </summary>
        /// <returns>一个Manager类的实例</returns>
        public static Manager get_instance()
        {
            if (_instance == null)
                _instance = new Manager();
            return _instance;
        }
    }

    public class GameObject
    {

        public GameObject()
        {

        }
    }

    /// <summary>
    /// 表示一个二维矢量
    /// </summary>
    public struct Vector
    {
        /// <summary>
        /// 矢量的横坐标
        /// </summary>
        public double x;
        /// <summary>
        /// 矢量的纵坐标
        /// </summary>
        public double y;

        /// <summary>
        /// 构造一个新的矢量
        /// </summary>
        /// <param name="x">横坐标X</param>
        /// <param name="y">纵坐标Y</param>
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// 构造一个新的矢量
        /// </summary>
        /// <param name="vec">一个已有的矢量</param>
        public Vector(Vector vec)
        {
            this.x = vec.x;
            this.y = vec.y;
        }

        /// <summary>
        /// 获取矢量的长度（模）
        /// </summary>
        public double length
        {
            get
            {
                return Math.Sqrt(this.x * this.x + this.y * this.y);
            }
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y);
        }

        public static double operator *(Vector a, Vector b)
        {
            return a.x * b.x + a.y * b.y;
        }

        public static bool operator ==(Vector a, Vector b)
        {
            if (a.x == b.x && a.y == b.y)
                return true;
            else
                return false;
        }

        public static bool operator !=(Vector a, Vector b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
 	         return base.Equals(obj);
        }
        
        public override int GetHashCode()
        {
 	         return base.GetHashCode();
        }

        /// <summary>
        /// 获取矢量的字符串表现形式
        /// </summary>
        /// <returns>一个表示矢量的字符串，如(0, 0)</returns>
        public override string ToString()
        {
 	         return "(" + this.x + ", " + this.y + ")";
        }
    }

    namespace Components
    {
        /// <summary>
        /// 表示渲染组件的类
        /// </summary>
        public class render
        {
            private Vector position = new Vector(0, 0);
            
            public render()
            {

            }
        }

        /// <summary>
        /// 表示动画组件的类
        /// </summary>
        public class animation
        {
            
            public animation()
            {

            }
        }
    }
}
