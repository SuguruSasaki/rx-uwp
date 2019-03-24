using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace RxUWP.UI.Extensions {

    public static class GridExtensions {    

        /// <summary>
        /// Rective Wrapper for Tapped.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static Subject<bool> rx_TapPointer(this Grid grid) {
            var subject = new Subject<bool>();
            grid.PointerExited += (sender, e) => {
                subject.OnNext(true);
            };
            return subject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static Subject<bool> rx_Tap(this Grid grid) {
            var subject = new Subject<bool>();
            grid.Tapped += (sender, e) => {
                subject.OnNext(true);
            };
            return subject;
        }
    }
}
