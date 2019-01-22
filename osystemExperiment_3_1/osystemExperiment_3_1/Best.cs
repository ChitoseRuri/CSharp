using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osystemExperiment_3_1
{
    class Best : Base
    {
        protected override bool insertArea(in Area area)
        {
            int size = m_Area.Count();
            int targetIndex = -1;
            int minArea = int.MaxValue;
            for (int i = 0; i < size; i++)
            {
                if(m_Area[i].owner == 0 && m_Area[i].area >= area.area && m_Area[i].area < minArea)
                {
                    targetIndex = i;
                    minArea = m_Area[i].area;
                }
            }
            if(targetIndex != -1)
            {
                m_Area.Insert(targetIndex++, area);
                m_Area[targetIndex] = new Area(m_Area[targetIndex].area - area.area, m_Area[targetIndex].owner);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
