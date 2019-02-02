# Rx UWP

This library is an extension of each class of UWP using Reactive Extensions(.Net Rx)

## UI

+ Button
+ TextBlock
+ ScrollViewer

## Usage

### Button

```c#
// Button was Extended by ButtonExtensions class.
var button = new Button(); 

button.rx_Tap()
    .Select(x => "button tapped!!")
    .Bind(to: this._reactor.action)
    .DisposeBag(bag: this._disposeBag);

```

### TextBlock

```c#

// TextBlock was Extended by TextBlockExtensions class.
var tb = new TextBlock();

button.rx_Tap()
    .Select(x => "Hello World")
    .Bind(tb.rx_Text())
    .DisposeBag(bag: this._disposeBag);
```

### ScrollViewer

```c#
scrollView.rx_Changed()
    .Select(x => x)
    .Bind(to: subjectScroll)
    .DisposeBag(bag: this._disposeBag);

```