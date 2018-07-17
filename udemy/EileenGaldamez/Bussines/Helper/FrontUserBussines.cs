using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bussines.Helper.HelperBussines;

namespace Bussines.Helper
{
    public class FrontUserBussines
    {


        public enum RolesPermisos
        {
            #region Alumnos
            // Read (1) Add(2) Write (3) Delete (4)  
            r = 1,
            ra = 3,
            rae = 6,
            rad = 7,
            raed = 10,
            re = 4,
            red = 8,
            rd = 5,
            #endregion
        }

        public class FrontUser
        {
            public static bool TienePermiso(RolesPermisos valor)
            {
                var usuario = FrontUser.Get();
                return !usuario.Rol.Permiso.Where(x => x.PermisoID == valor)
                                   .Any();
            }

            public static Usuario Get()
            {
                return new Usuario().Obtener(SessionHelper.GetUser());
            }
        }
    }
}
