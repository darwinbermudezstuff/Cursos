using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;
using DataFree;

namespace Bussines
{
    public class areaBussines
    {
        private bool error;
        private areaData areadatos = new areaData();

        public bool crear(areaEntity area)
        {
            if(area.area == "")
            {
                areadatos.crear(area);
                error = true;
            }
            else
            {
                error = false;
            }

            return error;
        }

        public bool getArea(ref areaEntity areaRef)
        {
                areadatos.find(ref areaRef);
                error = true;

            return error;
        }

        public bool getArea(ref List<areaEntity> areaRef)
        {
            areadatos.findAll(ref areaRef);
            error = true;

            return error;
        }
    }
}