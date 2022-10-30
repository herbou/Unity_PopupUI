# Popup UI for your game
A powerful,Customizable, and esay-to-use Popup UI for Unity

<img src="https://www.mediafire.com/convkey/f35a/ckkdemla8fuv41z7g.jpg" alt="Popup UI" height="200" />

### Video tutorial : https://youtu.be/TL8OQ8tc-gs
<br><br>



## ■ Supporting Platforms :
- All platforms (Standalone Builds, Android, iOS, WebGl, and more..)
<br><br>
## ■ How to use?  :
### 1- Import **EasyUI_Popup** package.
⚠️ NOTE! : No need to add any prefab to the scene
### 3- Add **EasyUI.Popup** namespace in your script :
```c#
using EasyUI.Popup ;
```
### 4- Now Simply write ```Popup.Show(..)```:
```c#
// Only Text :
Popup.Show ("Hello GameDevs") ;

// Title & Text :
Popup.Show ("Message", "Hello GameDevs") ;
```

## ■ Change text styling :
```c#
Popup.Show ("Custom text color", "Hello, <color=red>This text is red</color>");
```
<img src="https://www.mediafire.com/convkey/4051/ubhdgel36ybq6kk7g.jpg" alt="Toast ui" height="150" />
for more supported style tags : <a href="https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html">Text supported styles</a>

## ■ All options popup :
```c#
void Start(){
  Popup.Show ("Popup title", "With Unity we can do anything.", "Click Me", PopupColor.Red, OnClose);
}

void OnClose(){
  Debug.Log("Red Popup closed");
}
```
<img src="https://www.mediafire.com/convkey/4b81/015cvkokcznivci7g.jpg" alt="Toast ui" height="150" />

or you can use lambda expression **=>** for the event :
```c#
void Start(){
  Popup.Show ("Popup title", "Hello world", "Click Me", PopupColor.Red,
    () => {
      Debug.Log("Red Popup closed");
    }
  );
  
  // or remove {} since we have only one line:
  // Popup.Show ("Popup title", "Hello world", "Click Me", PopupColor.Red, () => Debug.Log("Red Popup closed") );
}
```

## ■ Dismiss popup :
```c#
Popup.Dismiss();
```

## ■ All Show(..) versions :
```c#
Popup.Show (string text);

Popup.Show (string text, UnityAction onCloseAction);

Popup.Show (string title, string text);

Popup.Show (string title, string text, UnityAction onCloseAction);

Popup.Show (string title, string text, string buttonText);

Popup.Show (string title, string text, string buttonText, UnityAction onCloseAction);

Popup.Show (string title, string text, string buttonText, PopupColor buttonColor);

Popup.Show (string title, string text, string buttonText, PopupColor buttonColor, UnityAction onCloseAction);
```


<br><br>
<br>
## ❤️ Donate  
<a href="https://paypal.me/hamzaherbou" title="https://paypal.me/hamzaherbou" target="_blank"><img align="left" height="50" src="https://www.mediafire.com/convkey/72dc/iz78ys7vtfsl957zg.jpg" alt="Paypal"></a>
