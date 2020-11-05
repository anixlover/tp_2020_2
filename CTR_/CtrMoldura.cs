using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;
using DTO;

namespace CTR
{
    public class CtrMoldura
    {
        DaoMoldura objDaoMoldura;
        public CtrMoldura()
        {
            objDaoMoldura = new DaoMoldura();
        }
        public DataTable ListarMoldurasPaginaInicial(DtoTipoMoldura objDtoTipoMoldura)
        {
            return objDaoMoldura.ListarMoldurasPaginaInicial(objDtoTipoMoldura);
        }
        public void registrarImgMoldura(byte[] bytes, int id)
        {
            objDaoMoldura.RegistrarImgMoldura(bytes, id);
        }
    }
}
