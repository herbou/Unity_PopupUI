using UnityEngine ;
using EasyUI.Popup ;

public class Demo : MonoBehaviour {
   [TextArea (5, 20)]public string longText ;

   //Buttons
   public void Button1 () {
      Popup.Show ("Hello GameDevs :)") ;
   }

   public void Button2 () {
      Popup.Show ("Title", longText) ;
   }

   public void Button3 () {
      Popup.Show ("Error", "Invalid email or password!", "OK", PopupColor.Red) ;
   }

   public void Button4 () {
      Popup.Show ("Success", "Your account updated successfully.", "OK", PopupColor.Green) ;
   }

   public void Button5 () {
      Popup.Show ("Event test", "When you close this popup a message will show.", "Close Me", PopupColor.Magenta,
         () => {
            Debug.Log ("Magenta popup is closed") ;
         }
      ) ;
   }

  
}
