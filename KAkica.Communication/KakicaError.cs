using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication
{
    public class KakicaError
    {
        IEnumerable<string> Messages { get; set; } = new List<string>();
    }
}
