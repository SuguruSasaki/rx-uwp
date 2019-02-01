using RxUWP.Disposable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace RxUWP.Subject {

    public class PublishSubject<T> {

        #region Fields

        private Subject<T> _subject = new Subject<T>();
        private IObservable<object> _observable;

        #endregion


        #region Constructor

        /// <summary>
        /// Create a PublishSubject
        /// </summary>
        public PublishSubject() { }

        #endregion


        #region Method

        /// <summary>
        /// Subscribe an observer to the subject.
        /// </summary>
        /// <param name="observer"></param>
        /// <returns></returns>
        public IDisposable Subscribe(IObserver<T> observer) {
            return this._subject.Subscribe(observer);
        }

        /// <summary>
        /// Notifies all subscribed observers about the arrival of the specified element in the sequence.
        /// </summary>
        /// <param name="value"></param>
        public void OnNext(T value) {
            this._subject.OnNext(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public PublishSubject<T> Map(Func<T, object> selector) {
            this._observable = this._subject.Select(x => selector(x));
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ActionType"></typeparam>
        /// <param name="to"></param>
        /// <returns></returns>
        public PublishSubject<T> Bind<ActionType>(Subject<ActionType> to) {
            this._observable = this._observable.SelectMany(x => {
                var action = (ActionType)x;
                to.OnNext(action);
                return Observable.Return(x);
            });
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        public void DisposeBag(DisposeBag bag) {
            var token = this._observable.Subscribe(observer => {});
            bag.Collect(token);
        }

        #endregion
    }
}
