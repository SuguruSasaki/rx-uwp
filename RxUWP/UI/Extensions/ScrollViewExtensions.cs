using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace RxUWP.UI.Extensions {

    public static class ScrollViewExtensions {

        /// <summary>
        /// Rective Wrapper for ViewChanged.
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static Subject<ScrollViewer> rx_Changed(this ScrollViewer view) {
            var subject = new Subject<ScrollViewer>();
            view.ViewChanged += (sender, e) => {
                var scrollView = sender as ScrollViewer;
                subject.OnNext(scrollView);
            };
            return subject;
        }

    }
}
