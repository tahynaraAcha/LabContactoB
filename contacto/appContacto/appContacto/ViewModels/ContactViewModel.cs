﻿namespace appContacto.ViewModels
{
    using Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ContactViewModel:BaseViewModel
    {
        #region Attributes
        private ApiService apiService;
        private ObservableCollection<Contact> contacts;
        #endregion

        #region Properties
        public ObservableCollection<Contact> Contacts
        {
            get { return this.contacts; }
            set { SetValue(ref this.contacts, value); }
        }
        #endregion

        #region Constructor
        public ContactViewModel()
        {
            this.apiService = new ApiService();
            this.LoadContacts();
        }
        #endregion

        #region Methods
        private async void LoadContacts()
        {
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Connection Error",
                    connection.Message,
                    "Accept"
                    );
                return;
            }

            var response = await this.apiService.GetList<Contact>(
                        "https://apicontactsi220.azurewebsites.net/",
                        "api/",
                        "Contacts");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "GET Contact Error",
                    response.Message,
                    "Accept"
                    );
                return;
            }

            MainViewModel mainViewModel = MainViewModel.GetInstance();
            mainViewModel.ContactList = (List<Contact>)response.Result;

            this.Contacts = new ObservableCollection<Contact>(this.ToContactView());

        }

        private IEnumerable<Contact> ToContactView()
        {
            ObservableCollection<Contact> collection = new ObservableCollection<Contact>();
            MainViewModel main = MainViewModel.GetInstance();
            foreach (var lista in main.ContactList)
            {
                Contact contacto = new Contact();
                contacto.ContactID = lista.ContactID;
                contacto.Name = lista.Name;
                contacto.Type = lista.Type;
                contacto.ContactValue=lista.ContactValue;
                collection.Add(contacto);
            }
            return collection;
        }
        #endregion

    }
}
