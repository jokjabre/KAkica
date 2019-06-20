using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Domain
{
    public interface IKakicaModel
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
