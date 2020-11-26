using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using DTO;

namespace CTR
{
    public class Ctr_Solicitud
    {
        Dao_Solicitud objDaoSolicitud;

        public Ctr_Solicitud()
        {
            objDaoSolicitud = new Dao_Solicitud();
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
