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
    public class CtrMoldura
    {
        DaoMoldura objDaoMoldura;
        public CtrMoldura()
        {
            objDaoMoldura = new DaoMoldura();
        }
        public void RegistrarMoldura(DtoMoldura objDtoMoldura)
        {
            objDaoMoldura.RegistrarMoldura(objDtoMoldura);
        }
        public void registrarImgMoldura(byte[] bytes, int id)
        {
            objDaoMoldura.RegistrarImgMoldura(bytes, id);
        }
        
    }
}
