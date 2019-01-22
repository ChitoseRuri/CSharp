using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace osystemExperiment_3_1
{
    struct Area
    {
        public int area;//空间大小
        public int owner;//拥有者,0是系统
        public Area(int tArea, int tOwner)
        {
            area = tArea;
            owner = tOwner;
        }
    }

    /// <summary>
    /// 算法基类
    /// </summary>
   abstract class Base
    {
        private BitmapData m_BitmapData;
        private Bitmap m_Bitmap;
        private Rectangle m_Rect;
        private int m_Height, m_Weight;
        protected List<Area> m_Area;


        public Base()
        {
            m_Area = new List<Area>();
            m_Area.Add(new Area(640, 0));//一开始有640K空间
        }

        /// <summary>
        /// 碎片整理
        /// </summary>
        private void defragmentation()
        {
            bool isOs = false;//判断上一个是不是也是系统管理的
            int size = m_Area.Count();
            for (int i = 0; i < size; i++)
            {
                if(m_Area[i].owner == 0)
                {
                    if(isOs)
                    {
                        m_Area[i - 1] = new Area(m_Area[i - 1].area + m_Area[i].area, 0);
                        m_Area.Remove(m_Area[i]);
                        i--;
                        size--;
                    }
                    else
                    {
                        isOs = true;
                    }
                }
                else
                {
                    isOs = false;
                }
            }
        }

        /// <summary>
        /// 插入算法
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        protected abstract bool insertArea(in Area area);

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="bitmap"></param>
        public void initial(in Bitmap bitmap)
        {
            m_Bitmap = bitmap;
            m_Height = bitmap.Height;
            m_Weight = bitmap.Width;
            m_Rect = new Rectangle(0, 0, m_Weight, m_Height);
        }

        /// <summary>
        /// 申请空间
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public bool apply(in Area area)
        {
            if(insertArea(in area))
            {
                refreshBitmap();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 释放空间
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public bool release(in Area area)
        {

            int size = m_Area.Count();
            for (int i = 0; i < size; i++)
            {
                if(m_Area[i].owner == area.owner)
                {
                    m_Area[i] = new Area(area.area, 0);//把空间归还         
                    refreshBitmap();
                    defragmentation();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 刷新位图
        /// </summary>
        public void refreshBitmap()
        {
            m_BitmapData = m_Bitmap.LockBits(m_Rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            unsafe
            {
                uint* pPix = (uint*)m_BitmapData.Scan0;
                int size = m_Area.Count();
                int ix, iy, ipix,itemp;
                uint color;
                for(iy = 0; iy < m_Height; iy++)
                {
                    for (ix = 0, itemp = 0; ix < size; ix++) 
                    {
                        color = (m_Area[ix].owner == 0) ? 0xff808080 : 0xff000000;
                        for (ipix = 0; ipix < m_Area[ix].area; ipix++, itemp++)
                        {
                            pPix[iy * m_Weight + itemp] = color;
                        }
                    }
                }
            }
            m_Bitmap.UnlockBits(m_BitmapData);
        }
    }
}
