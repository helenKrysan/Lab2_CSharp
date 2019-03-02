using Lab2_Krysan.Models;
using System;
using System.Windows;

namespace Lab2_Krysan.Tools.Managers
{
    internal static class StationManager
    {
        internal static Person CurrentPerson { get; set; }

        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }

}
