using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace RxUWP.UI.Extensions {

    public static class TextBoxExtensions {

        public static Subject<string> rx_TextChanged(this TextBox tb) {
            var subject = new Subject<string>();
            tb.TextChanged += (sender, e) => {
                var textBox = sender as TextBox;
                subject.OnNext(textBox.Text);
            };
            return subject;
        }
    }
}
