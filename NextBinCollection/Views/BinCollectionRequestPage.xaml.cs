using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NextBinCollection.Models;
using NextBinCollection.ViewModels;
using Xamarin.Forms;

namespace NextBinCollection.Views
{
    public partial class BinCollectionRequestPage : ContentPage
    {
        BinCollectionRequestViewModel viewModel;

        public BinCollectionRequestPage()
        {
            InitializeComponent();


            viewModel = new BinCollectionRequestViewModel();

            BindingContext = viewModel;
        }

        public void Cancel_Clicked(Object sender, EventArgs e)
        {
            // clear selection
            CouncilListPicker.SelectedItem = null;

            PostCodeEntry.Text = "";

            ResultListView.ItemsSource = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.ManchesterCouncils == null || viewModel.ManchesterCouncils.Count == 0)
            {
                var response = Task.Run(async ()=> await viewModel.GetManchesterCouncils());
            }
        }


        public void CouncilListPicker_SelectedIndexChanged(Object sender,  EventArgs e)
        {
            var picker = sender as Picker;

            var selectedIndex = picker.SelectedIndex;

            if(selectedIndex == -1) { return; }

            var selected = (ManchesterCouncil)picker.ItemsSource[selectedIndex];

            if (selected is null) { return; }

            viewModel.CouncilPostcodeRequest.SelectedCouncil = selected;
        }

        public void PostCodeEntryChanged(Object sender, TextChangedEventArgs e)
        {
            if(!String.IsNullOrEmpty(e.NewTextValue) && (!String.IsNullOrEmpty(e.OldTextValue))) {

                SendPostCodeBtn.IsVisible = true;
            }
        }

        public void SendPostCodeBtn_Clicked(Object sender, EventArgs e)
        {
            // send the post code to get its list of addresses
            viewModel.LoadAddressesCommand.Execute(null);

            PostCodeAddressPicker.IsVisible = true;

            SendPostCodeBtn.IsVisible = false;
        }

        public void PostCodeAddressPicker_SelectedIndexChanged(Object sender, EventArgs e)
        {
            var picker = sender as Picker;

            var selectedIndex = picker.SelectedIndex;

            if (selectedIndex == -1) { return; }

            var selected = (string)picker.ItemsSource[selectedIndex];

            if (string.IsNullOrEmpty(selected)) { return; }

            viewModel.CouncilPostcodeRequest.SelectedAddress = selected;

            // call council backend with post code and ddress:
            viewModel.LoadBinCollectionDaysForPostCodeAndAddress.Execute(null);
            PostCodeAddressPicker.IsVisible = false;
        }
    }
}
