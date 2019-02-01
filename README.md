# Rx UWP

This library is an extension of each class of UWP using Reactive Extensions(.Net Rx)

## Usage

```c#

class Reactor {
    public Subject<Action> action = new Subject<Action>();
}

private Reactor _reactor = new Reactor();

this._reactor.action.Subscribe(Action => {
    Debug.WriteLine(Action);
});


button.Tap
    .Map(x => Action.didTap)
    .Bind(to: this._reactor.action)
    .DisposeBag(bag: this._disposeBag);

```
