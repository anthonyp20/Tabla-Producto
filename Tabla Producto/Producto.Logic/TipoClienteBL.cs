using Financiera.Data;
using Financiera.Dominio;
using System.Collections.Generic;

namespace Financiera.Logic
{
    public static class TipoClienteBL
    {
        public static List<TipoCliente> Listar(){
            var tipoCLienteData = new TipoClienteData();
            return tipoCLienteData.Listar();
        }
    }
}
