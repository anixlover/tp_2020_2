using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

using DAO;
using DTO;

namespace CTR
{
    class CtrMolduraXUsuario
    {
        DaoMolduraxUsuario objDaoSXM;

        public CtrMolduraxUsuario()
        {
            objDaoSXM = new DaoMolduraxUsuario();
        }

        public void registrarNuevaMoldura(DtoMolduraxUsuario objDtoMolduraxUsuario)
        {
            objDaoSXM.InsertarMolduraxUsuario(objDtoMolduraxUsuario);
        }
    }
}
