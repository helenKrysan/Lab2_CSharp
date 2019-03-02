﻿using Lab2_Krysan.Views;
using System;


namespace Lab2_Krysan.Tools.Navigation
{
    internal class PersonInitializationNavigationModel : BaseNavigationModel
    {
        public PersonInitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.PersonInitialization:
                    ViewsDictionary.Add(viewType, new PersonInitializationView());
                    break;
                case ViewType.Main:
                    ViewsDictionary.Add(viewType, new MainView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }

    }
}