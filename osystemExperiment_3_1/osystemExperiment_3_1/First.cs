using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osystemExperiment_3_1
{
    class First : Base
    {
        protected override bool insertArea(in Area area)
        {
            int size = m_Area.Count();
            for (int i = 0; i < size; i++)
            {
                if(m_Area[i].owner == 0 && m_Area[i].area >= area.area)
                {
                    m_Area.Insert(i++, area);
                    m_Area[i] = new Area(m_Area[i].area - area.area, m_Area[i].owner);
                    return true;
                }
            }
            return false;
        }
    }
}
