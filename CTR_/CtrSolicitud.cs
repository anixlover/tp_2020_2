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
    public class CtrSolicitud
    {
        DaoSolicitud objDaoSolicitud;
        public CtrSolicitud()
        {
            objDaoSolicitud = new DaoSolicitud();
        }
        public bool LeerSolicitudTipo(DtoSolicitud objDtoSolicitud)
        {
            return objDaoSolicitud.SelectSolicitudTipo(objDtoSolicitud);
        }
        public bool LeerSolicitudImporte(DtoSolicitud objDtoSolicitud)
        {
            return objDaoSolicitud.SelectSolicitudImporte(objDtoSolicitud);
        }
        public bool leerSolicitudDiseñoPersonal(DtoSolicitud objDtoSolicitud)
        {
            return objDaoSolicitud.SelectSolicitudDiseñoPersonalizado(objDtoSolicitud);
        }
        public DataTable MostrarPedidoPersonalizado(DtoSolicitud objDtoSolicitud)
        {
            return objDaoSolicitud.SelectSolicitudDiseñoPropio(objDtoSolicitud);
        }
        public DataTable RetornarImagenDiseñoPersonalizado(DtoSolicitud objDtoSolicitud)
        {
            return objDaoSolicitud.SelectSolicitudDiseñoPropioIMG(objDtoSolicitud);
        }

        public DataTable ListaSolicitudes()
        {
            return objDaoSolicitud.SelectSolicitudes();
        }
        public DataSet OpcionesSolicitudEstado()
        {
            return objDaoSolicitud.desplegableSolicitudEstado();
        }
        public DataTable Listar_Solicitud_tipo(string tipo)
        {
            return objDaoSolicitud.SelectSolicitudes(tipo);
        }
    }
}
