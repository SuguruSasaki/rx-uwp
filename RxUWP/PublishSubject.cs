using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace RxUWP {

    public class PublishSubject<T> {
    
        private Subject<T> _subject = new Subject<T>();
        private IObservable<object> _observable;

        public IDisposable Subscribe(IObserver<T> observer) {
            return this._subject.Subscribe(observer);
        }

        public void OnNext(T value) {
            this._subject.OnNext(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public PublishSubject<T> Map(Func<T, object> selector) {
            this._observable = this._subject
                .Select(x => selector(x));
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
        public void DisposeBag(DisposeBag by) {
            var token = this._observable.Subscribe(observer => {});
            by.Collect(token);
        }

    }

}
