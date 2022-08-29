using Financiera.Data;
using Financiera.Dominio;
using System.Collections.Generic;

namespace Financiera.Logic
{
    public static class TipoDocumentoBL
    {
        public static List<TipoDocumento> Listar()
        {
            var tipoDocumentoData = new TipoDocumentoData();
            return tipoDocumentoData.Listar();
        }
    }
}
