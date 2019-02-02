using RxUWP.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace RxUWP.UI.Extensions {

    public static class TextBlockExtensions {

        #region Rx

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tb">instance of TextBlock</param>
        /// <returns></returns>
        public static Subject<string> RxText(this TextBlock tb) {
            var subject = new Subject<string>();
            subject.Subscribe(observer => { tb.Text = observer; });
            return subject;
        }

        #endregion
    }
}
