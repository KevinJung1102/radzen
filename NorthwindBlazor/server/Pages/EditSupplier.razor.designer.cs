﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using NorthwindBlazor.Models.Northwind;

namespace NorthwindBlazor.Pages
{
    public partial class EditSupplierComponent : ComponentBase
    {
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }
        [Inject]
        protected NorthwindService Northwind { get; set; }


        [Parameter]
        protected string SupplierID { get; set; }

        protected RadzenContent content1;

        protected RadzenLabel closeLabel;

        protected RadzenButton closeButton;

        protected RadzenTemplateForm<Supplier> form0;

        protected RadzenLabel label2;

        protected RadzenTextBox companyName;

        protected RadzenRequiredValidator companyNameRequiredValidator;

        protected RadzenLabel label3;

        protected RadzenTextBox contactName;

        protected RadzenLabel label4;

        protected RadzenTextBox contactTitle;

        protected RadzenLabel label5;

        protected RadzenTextBox address;

        protected RadzenLabel label6;

        protected RadzenTextBox city;

        protected RadzenLabel label7;

        protected RadzenTextBox region;

        protected RadzenLabel label8;

        protected RadzenTextBox postalCode;

        protected RadzenLabel label9;

        protected RadzenTextBox country;

        protected RadzenLabel label10;

        protected RadzenTextBox phone;

        protected RadzenLabel label11;

        protected RadzenTextBox fax;

        protected RadzenLabel label12;

        protected RadzenTextBox homePage;

        protected RadzenButton button2;

        protected RadzenButton button3;

        bool _canEdit;
        protected bool canEdit
        {
            get
            {
                return _canEdit;
            }
            set
            {
                if(_canEdit != value)
                {
                    _canEdit = value;
                    Invoke(() => { StateHasChanged(); });
                }
            }
        }

        Supplier _supplier;
        protected Supplier supplier
        {
            get
            {
                return _supplier;
            }
            set
            {
                if(_supplier != value)
                {
                    _supplier = value;
                    Invoke(() => { StateHasChanged(); });
                }
            }
        }

        protected override async Task OnInitAsync()
        {
            await Task.Run(Load);
        }

        protected async void Load()
        {
            canEdit = true;

            var northwindGetSupplierBySupplierIdResult = await Northwind.GetSupplierBySupplierId(int.Parse(SupplierID));
                supplier = northwindGetSupplierBySupplierIdResult;
        }

        protected async void CloseButtonClick(UIMouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async void Form0Submit(Supplier args)
        {
            var northwindUpdateSupplierResult = await Northwind.UpdateSupplier(int.Parse(SupplierID), supplier);
                DialogService.Close(supplier);
        }

        protected async void Button3Click(UIMouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
