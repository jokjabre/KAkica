using KAkica.Communication.Interfaces;
using KAkica.Communication.OwnerViewModels;
using KAkica.Domain;
using KAkica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication
{
    public static class KakicaFactory<TModel> where TModel : IKakicaModel
    {
        public static Dictionary<Type, Type> ModelResponseMap = new Dictionary<Type, Type>()
        {
            {typeof(OwnerResponse), typeof(Owner)}
        };
           

        //public static IKakicaResponse<TModel> ResponseFromModel(TModel model)
        //{

        //}
    }
}
