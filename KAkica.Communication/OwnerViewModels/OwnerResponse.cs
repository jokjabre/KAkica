using KAkica.Communication.Interfaces;
using KAkica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.OwnerViewModels
{
    public class OwnerResponse : IKakicaResponse<Owner>
    {
        public bool Success { get; set; }
        public KakicaError Error { get; set; }
        public Owner Model { get; set; }

        public IKakicaResponse<Owner> FromModel(Owner model)
        {
            throw new NotImplementedException();
        }
    }
}
