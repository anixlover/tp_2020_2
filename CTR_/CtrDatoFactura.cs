using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;
using DAO;

namespace CTR
{
    public class CtrDatoFactura
    {
        DaoDatoFactura objDaoDatoFactura;
        public CtrDatoFactura()
        {
            objDaoDatoFactura = new DaoDatoFactura();
        }
        public void RegistrarDatoFatcura(DtoDatoFactura objDtoDatoFactura)
        {
            objDaoDatoFactura.InsertDatoFatcura(objDtoDatoFactura);
        }
        public bool RUC_Duplicado(DtoDatoFactura objDtoDatoFactura)
        {
            return objDaoDatoFactura.SelectDatoFacturaxRUC_Dni(objDtoDatoFactura);
        }
        public DataSet ListarRucs(DtoDatoFactura objDtoDatoFactura)
        {
            return objDaoDatoFactura.SelectRUCxDNI(objDtoDatoFactura);
        }
    }
}
