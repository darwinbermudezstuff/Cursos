using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataEntity;

namespace webBiblioteca.Models
{
    public class areaModels
    {
        private areaEntity area;
        private List<areaEntity> areas;
        private bool error;

        public areaEntity Area
        {
            get
            {
                return area;
            }

            set
            {
                area = value;
            }
        }

        public List<areaEntity> Areas
        {
            get
            {
                return areas;
            }

            set
            {
                areas = value;
            }
        }

        public bool Error
        {
            get
            {
                return error;
            }

            set
            {
                error = value;
            }
        }
    }
}