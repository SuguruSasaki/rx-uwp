using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace RxUWP.Subject.Extensions {

    public static class SubjectExtensions {

        #region Method

        /// <summary>
        /// Bind to Subject<typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IDisposable Bind<T>(this Subject<T> subject, IObservable<T> obj) {
            return obj.Subscribe(observer => {
                subject.OnNext(observer);
            });
        }

        #endregion

    }
}
