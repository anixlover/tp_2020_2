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
        public void registrarNuevaMoldura(DtoMolduraXUsuario objDtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.InsertarMolduraxUsuario(objDtoMolduraxUsuario);
        }
        public void actualizarExistencia(DtoMolduraXUsuario objDtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.actulizarExistenciaMXU(objDtoMolduraxUsuario);
        }
        public bool ExistenciaMXU(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            return objDaoMolduraXUsuario.ExistenciaMXU(objDtoMolduraXUsuario);
        }
            public DataTable listarMoldurasxusuario(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            return objDaoMolduraXUsuario.ListarMXU(objdtoMolduraxUsuario);
        }
        public DataTable ListarMoldurasXsolicitud(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            return objDaoMolduraXUsuario.ListaMoldurasSolicitud(objdtoMolduraxUsuario);
        }
        public void eliminarMXU(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.eliminarMXU(objdtoMolduraxUsuario);
        }
        public DataTable ListarSolicitudesxDNI(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            return objDaoMolduraXUsuario.SelectSolicitudesxDNI(objDtoMolduraXUsuario);
        }        
        public DataTable ListarMoldurasxDNI_y_Estado(DtoMolduraXUsuario objDtoMolduraXUsuario, int estado)
        {
            return objDaoMolduraXUsuario.SelectSolicitudesxDNI_y_Estado(objDtoMolduraXUsuario, estado);
        }
        public void obtenerMoldura(DtoMolduraXUsuario objdtoMolduraxUsuario, DtoMoldura objm, DtoTipoMoldura tm)
        {
            objDaoMolduraXUsuario.ObtenerMXU(objm, objdtoMolduraxUsuario, tm);
        }
        public void actualizarMXU(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.actualizarMXU(objdtoMolduraxUsuario);
        }
        public void actualizarMXUSol(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.actualizarMXUSol(objdtoMolduraxUsuario);
        }
        public bool obtenerMXUxCodigo(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            return objDaoMolduraXUsuario.ExistenciaMXU_x_Cod(objdtoMolduraxUsuario);
        }
    }
}
