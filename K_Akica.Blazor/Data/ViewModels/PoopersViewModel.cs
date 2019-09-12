using K_Akica.Blazor.Data.Helpers;
using KAkica.Communication.Request;
using KAkica.Communication.Response;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace K_Akica.Blazor.Data.ViewModels
{
    public class PoopersViewModel
    {
        private readonly HttpClientService m_httpClientService;
        private readonly IMatToaster m_toaster;
        private readonly string m_pooperEndpoint = "Pooper";

        private int m_selectedPooperIndex = 0;

        public PoopersViewModel(HttpClientService httpClientService, IMatToaster toaster)
        {
            m_httpClientService = httpClientService;
            m_toaster = toaster;
        }


        public IEnumerable<PooperResponse> AllPoopers { get; private set; }
        public PooperResponse SelectedPooper { get; private set; }
        public bool IsLoaded => AllPoopers != null;


        public event EventHandler OnRefreshNeeded;
        public event EventHandler OnSelectionChanged;

        private void ShowMessage(string message, MessageType messageType)
        {
            m_toaster.Add(message, messageType.AsMatType(), messageType.ToString());
        }

        private async Task InspectResult<TResponse>(HttpServiceResponse<TResponse> result, string successMsg)
        {
            if (!result.Success)
            {
                ShowMessage(result.ErrorMessage, MessageType.Error);
                return;
            }
            ShowMessage(successMsg, MessageType.Success);
            await Reload();
        }

        public void ChangeSelection(PooperResponse selected)
        {
            SelectedPooper = selected;
            OnSelectionChanged?.Invoke(null, EventArgs.Empty);
        }


        public async Task Reload()
        {
            var result = await m_httpClientService.Get<IEnumerable<PooperResponse>>(m_pooperEndpoint);
            if (!result.Success)
            {
                ShowMessage(result.ErrorMessage, MessageType.Error);
                return;
            }

            AllPoopers = result.Result;
            OnRefreshNeeded?.Invoke(this, EventArgs.Empty);
        }

        public async Task CreateNew(PooperRequest request)
        {
            var result = await m_httpClientService.Post<PooperRequest, PooperResponse>(m_pooperEndpoint, request);
            await InspectResult(result, $"Pooper \"{request.Name}\" created");
        }

        public async Task DeleteSelected(/*PooperResponse pooper*/)
        {
            if(SelectedPooper == null)
            {
                ShowMessage("Nothing is selected for deletion", MessageType.Error);
            }

            var result = await m_httpClientService.Delete<long, bool>(m_pooperEndpoint, SelectedPooper.Id);
            await InspectResult(result, $"Pooper \"{SelectedPooper.Name}\" deleted");

        }
    }
}
