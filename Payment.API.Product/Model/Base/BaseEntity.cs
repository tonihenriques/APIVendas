using System;

namespace Payment.API.Product.Model.Base
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public string Uniquekey { get; set; }

        public string UsuarioInclusao { get; set; }

        public string DataInclusao { get; set; }

        public string UsuarioExclusao { get; set; }

        public string DataExclusao { get; set; }

    }
}
