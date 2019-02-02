using System;
using System.Collections.Generic;
using System.Linq;
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

        #endregion
    }
}
