using RxUWP;
using RxUWP.Disposable;
using RxUWP.UI;
using RxUWP.UI.Extensions;
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

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace Example
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        enum Action {
            didTap
        }

        class Reactor {
            public Subject<Action> action = new Subject<Action>();
        }

        private Reactor _reactor = new Reactor();

        private DisposeBag _disposeBag = new DisposeBag();

        public MainPage()
        {
            this.InitializeComponent();

            var button = new ButtonRx();
            button.Width = 100;
            button.Height = 44;
            button.Background = new SolidColorBrush(Colors.Black);

            this.Root.Children.Add(button);


            var tb = new TextBlock();
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.Text = "NO DATA";
            this.Root.Children.Add(tb);


            this._reactor.action.Subscribe(Action => {

                

                this.Frame.Navigate(typeof(IndexScene));
            });

            /*
            button
                .Tap
                .Map(x => Action.didTap)
                .Bind(to: this._reactor.action)
                .DisposeBag(bag: this._disposeBag);
                */

            button
                .Tap
                .Map(x => "Hello World")
                .Bind<string>(tb.RxText())
                .DisposeBag(bag: this._disposeBag);
           

            
        }
    }
}
