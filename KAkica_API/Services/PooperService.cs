using JokJaBre.Core.API;
using JokJaBre.Core.Extensions;
using JokJaBre.Core.Objects;
using KAkica.Communication.Request;
using KAkica.Communication.Response;
using KAkica.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KAkica.API.Services
{
    public class PooperService : JokJaBreService<Pooper>
    {
        public PooperService(IJokJaBreRepository<Pooper> repository) : base(repository)
        {

        }

        public async Task<bool> AddActivity(long pooperId, ActivityRequest activity)
        {
            var pooper = await m_repository.GetById(pooperId, i=> i.Include(inc => inc.Activities));
            if (pooper == null) throw ApiExceptions.NotFound($"Pooper with id {pooperId} is not found");

            var activityModel = activity.ToModel<ActivityRequest, Activity>();
            activityModel.PooperId = pooperId;

            pooper.Activities.Add(activityModel);

            return await m_repository.SaveChanges();
        }
    }
}
