﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using TallerMecanico.Models.ViewModels;

namespace TallerMecanico.Utilidades
{
    public class Utilidades
    {
        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        internal static DataTable ConvertToDataTable(List<UsuarioVm> listaUsuarios)
        {
            throw new NotImplementedException();
        }
    }
}
