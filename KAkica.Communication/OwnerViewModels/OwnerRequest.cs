using KAkica.Communication.Interfaces;
using KAkica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.OwnerViewModels
{
    public class OwnerRequest : IKakicaRequest<Owner>
    {
        public Owner GetModel()
        {
            return null;
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
