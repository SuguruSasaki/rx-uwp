using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace RxUWPLibrary.UI.Extensions
{
    public static class ButtonExtensions
    {
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
