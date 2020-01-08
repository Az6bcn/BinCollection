using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NextBinCollection.Models;

namespace NextBinCollection.Services
{
    public interface IDataStore<T>
    {
        Task<List<Models.ManchesterCouncil>> GetManchesterCouncils();
        Task<PostcodeAddresses> GetAddresses(string postCode);
        Task<List<BinCollectionModel>> GetBinCollectionsDaysAsync(CouncilPostCodeRequest request);
    }
}
