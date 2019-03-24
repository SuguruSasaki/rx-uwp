using System.Reactive.Subjects;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace RxUWP.UI.Extensions {

    public static class SliderExtensions {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static Subject<RangeBaseValueChangedEventArgs> rx_ValueChanged(this Slider view) {
            var subject = new Subject<RangeBaseValueChangedEventArgs>();
            view.ValueChanged += (sender, e) => {
                subject.OnNext(e);
            };
            return subject;
        }
    }
}
