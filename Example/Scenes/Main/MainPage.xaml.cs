using RxUWP;
using RxUWP.Disposable;
using RxUWP.UI;
using RxUWP.UI.Extensions;
using RxUWP.Subject;
using RxUWP.Observable;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading;
using RxUWP.Observable.Extensions;

namespace Example
{
    
    public sealed partial class MainPage : Page
    {
      
        class Reactor {
            public Subject<string> action = new Subject<string>();
        }

        private Reactor _reactor = new Reactor();

        private DisposeBag _disposeBag = new DisposeBag();

        public MainPage()
        {
            this.InitializeComponent();

            var button = new Button();
            button.Width = 100;
            button.Height = 44;
            button.Background = new SolidColorBrush(Colors.Black);

            this.Root.Children.Add(button);



            var tb = new TextBlock();
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.Text = "NO DATA";
            this.Root.Children.Add(tb);


            this._reactor.action
                .Select(x => x)
                .Bind(to: tb.rx_Text())
                .DisposeBag(bag: this._disposeBag);



            this._reactor.action.OnNext("Test done");


            this._reactor.action.Subscribe(Action => {
                Debug.WriteLine("********");
                //this.Frame.Navigate(typeof(IndexScene));
            });

            button.rx_Tap()
                .Select(x => "button tapped!!")
                .Bind(to: this._reactor.action)
                .DisposeBag(bag: this._disposeBag);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e) {
            base.OnNavigatingFrom(e);
            this._disposeBag.Dispose();
        }
    }
}
