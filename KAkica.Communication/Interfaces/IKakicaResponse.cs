using KAkica.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.Interfaces
{
    public interface IKakicaResponse<TModel> : IKakicaViewModel<TModel>
        where TModel : IKakicaModel
    {
        IKakicaResponse<TModel> FromModel(TModel model);

        bool Success { get; set; }
        KakicaError Error { get; set; }
    }
}
