using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;

namespace DataFree
{
    public class areaData : obligatorio<areaEntity>
    {
        private connection objConexion;
        private string sql = null;

        public areaData()
        {
            objConexion = connection.saberEstado();
        }

        public void crear(areaEntity obj)
        {
            try
            {      
                 string create = "insert into area(area) value ('" + obj.area + "')";
                objConexion.sen = new SqlCommand(create, objConexion.getCon());
                objConexion.getCon().Open();
                objConexion.sen.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally
            {
                objConexion.getCon().Close();
                objConexion.cerrarConexion();
            }
        }

        public void update(areaEntity obj)
        {
            try
            {
                string create = "update area set area = '" + obj.area + "' where idArea = '" + obj.area + "'";
                objConexion.sen = new SqlCommand(create, objConexion.getCon());
                objConexion.getCon().Open();
                objConexion.sen.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally
            {
                objConexion.getCon().Close();
            }
        }

        public void delete(areaEntity obj)
        {
            try
            {
                string create = "delete from area where idArea = '" + obj.idArea + "'";
                objConexion.sen = new SqlCommand(create, objConexion.getCon());
                objConexion.getCon().Open();
                objConexion.sen.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally
            {
                objConexion.getCon().Close();
            }

        }

        public void find(ref areaEntity obj) 
        {
            sql = "select * from area where idArea = '" + obj.area + "'";
            objConexion.sen = new SqlCommand(sql, objConexion.getCon());
            objConexion.getCon().Open();
            objConexion.rs = objConexion.sen.ExecuteReader();
            if (objConexion.rs.Read()) {
                obj.idArea = int.Parse(objConexion.rs[0].ToString());
                obj.area = objConexion.rs[1].ToString();                
            }
            objConexion.getCon().Close();
            objConexion.cerrarConexion();
        }

        public void findAll(ref List<areaEntity> obj)
        {
            sql = "select * from area";
            objConexion.sen = new SqlCommand(sql, objConexion.getCon());
            objConexion.getCon().Open();
            objConexion.rs = objConexion.sen.ExecuteReader();
            if (objConexion.rs.Read())
            {
                while (objConexion.rs.Read())
                {
                    obj.Add(new areaEntity()
                    {
                        idArea = int.Parse(objConexion.rs[0].ToString()),
                        area = objConexion.rs[1].ToString()
                    });
                }
            }

            objConexion.getCon().Close();
            objConexion.cerrarConexion();

        }
    } 
} 
