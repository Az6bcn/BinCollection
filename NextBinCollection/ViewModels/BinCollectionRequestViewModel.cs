using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using NextBinCollection.Models;
using Xamarin.Forms;

namespace NextBinCollection.ViewModels
{
    public class BinCollectionRequestViewModel: BaseViewModel
    {
        public IList<ManchesterCouncil> ManchesterCouncils { get; set; }

        public CouncilPostCodeRequest CouncilPostcodeRequest { get; set; }
        public PostcodeAddresses PostcodeAddresses { get; set; }
        public List<BinCollectionModel> BinCollectionDays { get; set; }

        public Command LoadAddressesCommand { get; set; }
        public Command LoadBinCollectionDaysForPostCodeAndAddress { get; set; }


        public string PostCodeText
        {
            get { return CouncilPostcodeRequest.PostCode; }

            set
            {
                CouncilPostcodeRequest.PostCode = value;
                OnPropertyChanged();
            }
        }

        public string UsersCouncilText
        {
            get { return CouncilPostcodeRequest.Council; }

            set
            {
                CouncilPostcodeRequest.Council = value;
                OnPropertyChanged();
            }
        }

        public List<String> UsersPostcodeAddresses
        {
            get { return PostcodeAddresses.addresses; }

            set
            {
                if(PostcodeAddresses.addresses != value)
                {
                    PostcodeAddresses.addresses = value;
                    OnPropertyChanged(nameof(UsersPostcodeAddresses));
                }
            }
        }

        public List<BinCollectionModel> UsersPostcodeAddressesBinCollectionDays
        {
            get { return BinCollectionDays; }

            set
            {
                if (BinCollectionDays != value)
                {
                    BinCollectionDays = value;
                    OnPropertyChanged(nameof(UsersPostcodeAddressesBinCollectionDays));
                }
            }
        }

        public BinCollectionRequestViewModel()
        {
            PostcodeAddresses = new PostcodeAddresses();
            UsersPostcodeAddresses = new List<string>();

            CouncilPostcodeRequest = new CouncilPostCodeRequest();

            BinCollectionDays = new List<BinCollectionModel>();

            var response = Task.Run(async () => await GetManchesterCouncils());
            ManchesterCouncils = response.Result;

            LoadAddressesCommand = new Command(async() => await GetAddresses());

            LoadBinCollectionDaysForPostCodeAndAddress = new Command( async() => await GetPostCodeAddressesBinCollectionDays());
        }

        public async Task<List<ManchesterCouncil>> GetManchesterCouncils()
        {
            var response = await DataStore.GetManchesterCouncils();
            return response;
        }

        public async Task GetPostCodeAddressesBinCollectionDays()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var response = await DataStore.GetBinCollectionsDaysAsync(CouncilPostcodeRequest);

                if(response != null)
                {
                    UsersPostcodeAddressesBinCollectionDays = response;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task GetAddresses()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var response = await DataStore.GetAddresses(CouncilPostcodeRequest.PostCode);

                if (response != null)
                {
                    UsersPostcodeAddresses = response.addresses;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
