using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Stores;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc;
using MvcCookieAuthSample.Models;
using IdentityServer4.Models;

namespace MvcCookieAuthSample.Controllers
{
    public class ConsentController : Controller
    {
        private readonly IClientStore _clientStore;
        private readonly IResourceStore _resourceStore;
        private readonly IIdentityServerInteractionService _identityServerInteractionService;
        public ConsentController(
            IClientStore clientStore,
            IResourceStore resourceStore,
            IIdentityServerInteractionService identityServerInteractionService)
        {
            _clientStore = clientStore;
            _resourceStore = resourceStore;
            _identityServerInteractionService = identityServerInteractionService;
        }
        private async Task<ConsentViewModel> BuildConsentViewModel(string returnUrl)
        {
            var request =await _identityServerInteractionService.GetAuthorizationContextAsync(returnUrl);
            if (request == null)
                return null;

            var client =await _clientStore.FindEnabledClientByIdAsync(request.ClientId);
            var resources =await _resourceStore.FindEnabledResourcesByScopeAsync(request.ScopesRequested);
            return CreateConsentViewModel(request, client, resources);

        }
        private ConsentViewModel CreateConsentViewModel(AuthorizationRequest request,Client client,Resources resource)
        {
            var vm = new ConsentViewModel();
            vm.ClientName = client.ClientName;
            vm.ClientLogoUrl = client.LogoUri;
            vm.ClientUrl = client.ClientUri;
            vm.AllowRememberConsent = client.AllowRememberConsent;
            vm.IdentityScopes = resource.IdentityResources.Select(i => CreateScopeViewModel(i));
            vm.ResourceScopes = resource.ApiResources.SelectMany(i => i.Scopes).Select(x => CreateScopeViewModel(x));
            return vm;
        }
        private ScopeViewModel CreateScopeViewModel(IdentityResource identity)
        {
            return new ScopeViewModel
            {
                Name = identity.Name,
                DisplayName = identity.DisplayName,
                Required = identity.Required,
                Checked = identity.Required,
                Emphasize = identity.Emphasize,
            };
        }
        private ScopeViewModel CreateScopeViewModel(Scope scope)
        {
            return new ScopeViewModel
            {
                Name = scope.Name,
                DisplayName = scope.DisplayName,
                Required = scope.Required,
                Checked = scope.Required,
                Emphasize = scope.Emphasize,
            };
        }
        public async Task<IActionResult> Index(string returnUrl)
        {
            var model =await BuildConsentViewModel(returnUrl);
            return View(model);
        }
    }
}