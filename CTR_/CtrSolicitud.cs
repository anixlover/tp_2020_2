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
        public void Actualizar_a_EstadoRevisiónPago(DtoSolicitud objDtoSolicitud)
        {
            objDaoSolicitud.UpdateEstadoSolicitud_RevisióPago(objDtoSolicitud);
        }
        public string HayPago(DtoSolicitud objsol)
        {
            return objDaoSolicitud.SelectSolicitudPago(objsol);
        }
        public bool leerSolicitudTipo(DtoSolicitud objsol)
        {
            return objDaoSolicitud.SelectSolicitudTipo(objsol);
        }
        public bool LeerSolicitud(DtoSolicitud objsol)
        {
            return objDaoSolicitud.SelectSolicitud(objsol);
        }
        public DataTable ListaMolduras(DtoSolicitud objsol)
        {
            return objDaoSolicitud.ListaMoldurasSolicitud(objsol);
        }
        public DataTable ListaMoldurasxDiseñoPropio (DtoSolicitud objsol)
        {
            return objDaoSolicitud.ListaMoldurasSolicitudXDiseñoPropio(objsol);
        }
        public DataTable ListarSolicittudesDiseñoPropioEvaluar()
        {
            return objDaoSolicitud.SelectSolicitudesDiseñoPropio_Clientes();
        }
        public void AsignarFecha_e_Importe(DtoSolicitud objsol)
        {
            objDaoSolicitud.UpdateSolicitudFecha_RevisionFecha(objsol);
        }
        public void Rechazar(DtoSolicitud objsol)
        {
            objDaoSolicitud.UpdateEstadoSolicitud_Rechazado(objsol);
        }
        public void Actualizar_Estado_Solicitud(DtoSolicitud objDtoSolicitud)
        {
            objDaoSolicitud.Actualizar_Estado_SolicitudX1(objDtoSolicitud);
        }
        public void RegistrarSolicitud_LD(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolicitud_LD(objsolicitud);
        }
        public void MandarObservacion(DtoSolicitud objsolicitud) 
        {
            objDaoSolicitud.UpdateEstadoSolicitud_Observacion(objsolicitud);
        }
    }
}
