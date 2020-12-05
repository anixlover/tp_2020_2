using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DAO;
using DTO;

namespace CTR
{
    public class CtrMolduraXUsuario
    {
        DaoMolduraXUsuario objDaoMolduraXUsuario;
        public CtrMolduraXUsuario()
        {
            objDaoMolduraXUsuario = new DaoMolduraXUsuario();
        }
        public DataTable ListarMoldurasXUsuario(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            return objDaoMolduraXUsuario.ListaMoldurasSolicitud(objDtoMolduraXUsuario);
        }
        public DataTable ListarSolicitudesxDNI(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            return objDaoMolduraXUsuario.SelectSolicitudesxDNI(objDtoMolduraXUsuario);
        }
        public DataTable ListarMoldurasxDNI_y_Estado(DtoMolduraXUsuario objDtoMolduraXUsuario, int estado)
        {
            return objDaoMolduraXUsuario.SelectSolicitudesxDNI_y_Estado(objDtoMolduraXUsuario, estado);
        }
    }
}
