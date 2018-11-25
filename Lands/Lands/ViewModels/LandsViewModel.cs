using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Lands.Models;
using Lands.Services;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    public class LandsViewModel : BaseViewModel
    {
        private ApiService apiService;
        private bool isRefreshing;
        private string filter;
        private List<Land> landsList;

        private ObservableCollection<LandItemViewModel> lands;

        public ObservableCollection<LandItemViewModel> Lands
        {
            get => this.lands;
            set => SetValue(ref this.lands, value);
        }
        public bool IsRefreshing
        {
            get => this.isRefreshing;
            set => SetValue(ref this.isRefreshing, value);
        }
        public string Filter
        {
            get => this.filter;
            set
            {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }

        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLands();
        }

        private async void LoadLands()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var response = await this.apiService.GetList<Land>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            this.landsList = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel());
            this.IsRefreshing = false;
        }

        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return this.landsList.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders=l.Borders,
                CallingCodes=l.CallingCodes,
                Capital=l.Capital,
                Cioc=l.Cioc,
                Currencies=l.Currencies,
                Demonym=l.Demonym,
                Flag=l.Flag,
                Gini=l.Gini,
                Languages=l.Languages,
                Latlng=l.Latlng,
                Name=l.Name,
                NativeName=l.NativeName,
                NumericCode=l.NumericCode,
                Population=l.Population,
                Region=l.Region,
                RegionalBlocs=l.RegionalBlocs,
                Subregion=l.Subregion,
                TimeZones=l.TimeZones,
                TopLevelDomain=l.TopLevelDomain,
                Translations=l.Translations
            });
        }

        public ICommand RefreshCommand => new RelayCommand(this.LoadLands);

        public ICommand SearchCommand => new RelayCommand(this.Search);

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel());
            }
            else
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel().Where(l =>
                l.Name.ToLower().Contains(this.Filter.ToLower()) ||
                l.Capital.ToLower().Contains(this.Filter.ToLower())));
            }
        }
    }
}
