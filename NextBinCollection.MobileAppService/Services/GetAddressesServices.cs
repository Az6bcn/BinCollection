using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using NextBinCollection.MobileAppService.Models;

namespace NextBinCollection.MobileAppService.Services
{
    public class GetAddressesServices
    {
        public HttpClient Client { get; }

        public GetAddressesServices(HttpClient _httpClient)
        {
            _httpClient.BaseAddress = new Uri("https://api.getAddress.io");


            Client = _httpClient;
        }

        public async Task<PostcodeAddresses> GetAddressForPostCode(string postCode)
        {
            var editedAddreses = new PostcodeAddresses();
            editedAddreses.addresses = new List<string>();

            var response = await Client.GetAsync($"find/{postCode}/?api-key=");
            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();

            var result = await JsonSerializer.DeserializeAsync<PostcodeAddresses>(responseStream);
            
            foreach (var item in result.addresses)
            {
                var itemEdited = item.Replace(',', '-');

                editedAddreses.addresses.Add(itemEdited);
            }

            return editedAddreses;
        }
    }
}
