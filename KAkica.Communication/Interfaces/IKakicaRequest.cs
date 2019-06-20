using KAkica.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.Interfaces
{
    public interface IKakicaRequest<TModel> : IKakicaViewModel<TModel>
        where TModel : IKakicaModel
    {
        TModel GetModel();
        bool IsValid();
    }
}
