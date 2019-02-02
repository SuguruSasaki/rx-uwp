using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace RxUWP.Subject {

    public static class SubjectExtensions {

        public static IDisposable Bind<ActionType>(this Subject<ActionType> subject, IObservable<ActionType> obj) {
            return obj.Subscribe(observer => {
                subject.OnNext(observer);
            });
        }


      
    }
}
