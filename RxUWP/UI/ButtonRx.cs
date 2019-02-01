using RxUWP.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace RxUWP.UI {

    public class ButtonRx: Button {

      
        /// <summary>
        /// 
        /// </summary>
        public PublishSubject<bool> Tap { get => this._actionSubject; }


        /// <summary>
        /// 
        /// </summary>
        private PublishSubject<bool> _actionSubject = new PublishSubject<bool>();

        /// <summary>
        /// Constructor
        /// TODO: set up all events
        /// </summary>
        public ButtonRx(): base() {
            this.Tapped += this.OnButtonTapped;
            // this.Click += this.OnButtonClick;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Execute() {
            this._actionSubject.OnNext(true);
        }


        /// <summary>
        /// Tap Event Listener
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonTapped(object sender, TappedRoutedEventArgs e) {
            this.Execute();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonClick(object sender, RoutedEventArgs e) {
            this.Execute();
        }
    }
}
