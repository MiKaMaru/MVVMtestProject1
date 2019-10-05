using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using Avalonia;

namespace MVVMtestProject1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string greeting;

        public string Greeting
        {
            get => greeting;
            set => greeting = value;
        }
        public ReactiveCommand<Unit, Unit> WhenChangedCommand { get; set; }

        public MainWindowViewModel()
        {
            Greeting = "Welcome to Avalonia!";
            WhenChangedCommand = ReactiveCommand.Create(() => { Console.WriteLine(Greeting); Greeting += "!"; });
        }
    }
}
