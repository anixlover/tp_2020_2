﻿using System;
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
        public DataTable listarMoldurasxusuario(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            return objDaoMolduraXUsuario.ListarMXU(objdtoMolduraxUsuario);
        }
        public void eliminarMXU(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.eliminarMXU(objdtoMolduraxUsuario);
        }
    }
}
