using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MVVMtestProject1.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MVVMtestProject1.Views
{
    public class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public TextBox tb1 => this.FindControl<TextBox>("tb1");
        public Button btn1 => this.FindControl<Button>("btn1");

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            this.WhenActivated(disposables =>
            {
                this.Bind(ViewModel, vm => vm.Greeting, v => v.tb1.Text).DisposeWith(disposables);
                this.BindCommand(ViewModel, vm => vm.WhenChangedCommand, v => v.btn1).DisposeWith(disposables);
            });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
