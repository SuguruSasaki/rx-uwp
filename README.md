# Rx UWP

This library is an extension of each class of UWP using Reactive Extensions(.Net Rx)

## Usage

### Button

```c#

var button = new ButtonRx();

button.Tap
    .Map(x => Action.didTap)
    .Bind(to: this._reactor.action)
    .DisposeBag(bag: this._disposeBag);

```

### TextBlock

```c#
var tb = new TextBlock();

button
    .Tap
    .Map(x => "Hello World")
    .Bind<string>(tb.RxText())
    .DisposeBag(bag: this._disposeBag);
```