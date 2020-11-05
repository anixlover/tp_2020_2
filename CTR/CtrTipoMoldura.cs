using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAO;
using DTO;

namespace CTR
{
    public class CtrTipoMoldura
    {
        DaoTipoMoldura objDaoTipoMoldura;
        public CtrTipoMoldura()
        {
            objDaoTipoMoldura = new DaoTipoMoldura();
        }
        public DataSet OpcionesTipoMoldura()
        {
            return objDaoTipoMoldura.ListarTipoMoldura();
        }
    }
}
