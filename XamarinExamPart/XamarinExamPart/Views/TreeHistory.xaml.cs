﻿using XamarinExamPart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinExamPart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TreeHistory : ContentPage
    {
        public TreeHistory()
        {
            InitializeComponent();
            this.BindingContext = new TreeHistoryViewModel();
        }


    }
}