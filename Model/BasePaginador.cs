using System.Web.Routing;

namespace Model
{
    public class BasePaginador
    {
        public int PaginaActual { get; set; }
        public int TotalDeRegistros { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int IdVerDetalle{ get; set; }
        public RouteValueDictionary ValoresQueryString { get; set; }
    }
}
