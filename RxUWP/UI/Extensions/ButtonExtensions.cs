using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace RxUWP.UI.Extensions {

    public static class ButtonExtensions {

        #region Method

        /// <summary>
        /// Rective Wrapper for Tapped.
        /// </summary>
        /// <param name="btn">Windows.UI.Xaml.Controls.Button</param>
        /// <returns></returns>
        public static Subject<bool> rx_Tap(this Button btn) {
            var subject = new Subject<bool>();
            btn.Tapped += (sender, e) => {
                subject.OnNext(true);
            };
            return subject;
        }

        /// <summary>
        /// Reactive Wrapper for TapPointerExited
        /// </summary>
        /// <param name="btn"></param>
        /// <returns></returns>
        public static Subject<bool> rx_TapPointer(this Button btn) {
            var subject = new Subject<bool>();
            btn.PointerExited += (sender, e) => {
                subject.OnNext(true);
            };
            return subject;
        }

        /// <summary>
        /// Reactive Wrapper for check active.
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public static IObservable<bool> rx_IsActive(this Button btn, bool isActive) {
            if(!isActive) {
                btn.IsHitTestVisible = false;
                btn.Opacity = 0.3;
            } else {
                btn.IsHitTestVisible = true;
                btn.Opacity = 1.0;
            }
            return System.Reactive.Linq.Observable.Return<bool>(isActive);
        }


        #endregion
    }
}
