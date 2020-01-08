using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using NextBinCollection.Models;

namespace NextBinCollection.Services
{
    public class AzureDataStore : IDataStore<ManchesterCouncil>
    {
        HttpClient client;
        IEnumerable<Item> items;
        List<ManchesterCouncil> manchesterCouncils;

        public AzureDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            items = new List<Item>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<List<ManchesterCouncil>> GetManchesterCouncils()
        {
            if (IsConnected)
            {
                var json = await client.GetStringAsync($"api/postcode/manchestercouncils");
                manchesterCouncils = await Task.Run(() => JsonConvert.DeserializeObject<List<ManchesterCouncil>>(json));
            }

            return manchesterCouncils;
        }

        public async Task<PostcodeAddresses> GetAddresses(string postCode)
        {
            PostcodeAddresses postcodeAddresses = new PostcodeAddresses();

            if (IsConnected)
            {
                var json = await client.GetStringAsync($"api/postcode/addresses/{postCode}");
                postcodeAddresses = await Task.Run(() => JsonConvert.DeserializeObject<PostcodeAddresses>(json));
            }

            return postcodeAddresses;
        }


        public async Task<List<BinCollectionModel>> GetBinCollectionsDaysAsync(CouncilPostCodeRequest request)
        {
            List<BinCollectionModel> binCollectionModels = new List<BinCollectionModel>();

            if (IsConnected)
            {
                var json = await client.GetStringAsync($"api/postcode/address/bincollection");
                binCollectionModels = await Task.Run(() => JsonConvert.DeserializeObject<List<BinCollectionModel>>(json));
            }

            return binCollectionModels;
        }
    }
}
