/* -------------------------------
   Created by : Hamza Herbou
   hamza95herbou@gmail.com
---------------------------------- */

using UnityEngine ;
using UnityEngine.EventSystems ;
using UnityEngine.Events ;
using EasyUI.Helpers ;


namespace EasyUI.Popup {

   public enum PopupColor {
      Black,
      Red,
      Purple,
      Magenta,
      Blue,
      Green,
      Yellow,
      Orange
   }

   public static class Popup {
      public static bool _isLoaded = false ;

      private static PopupUI popupUI ;


      private static void Prepare () {
         if (!_isLoaded) {
            GameObject instance = MonoBehaviour.Instantiate (Resources.Load<GameObject> ("PopupUI")) ;
            instance.name = "[ POPUP UI ]" ;
            popupUI = instance.GetComponent <PopupUI> () ;
            _isLoaded = true ;

            CheckForEventSystem () ;
         }
      }

      private static void CheckForEventSystem () {
         // Check if there is an EventSystem in the scene (if not, add one)
         EventSystem es = MonoBehaviour.FindObjectOfType<EventSystem> () ;
         if (object.ReferenceEquals (es, null)) {
            GameObject esGameObject = new GameObject ("EventSystem") ;
            esGameObject.AddComponent <EventSystem> () ;
            esGameObject.AddComponent <StandaloneInputModule> () ;
         }
      }



      public static void Show (string text) {
         Prepare () ;
         popupUI.Show ("", text, popupUI.defaultButtonText, PopupColor.Black, null) ;
      }

      public static void Show (string text, UnityAction onCloseAction) {
         Prepare () ;
         popupUI.Show ("", text, popupUI.defaultButtonText, PopupColor.Black, onCloseAction) ;
      }

      public static void Show (string title, string text) {
         Prepare () ;
         popupUI.Show (title, text, popupUI.defaultButtonText, PopupColor.Black, null) ;
      }

      public static void Show (string title, string text, UnityAction onCloseAction) {
         Prepare () ;
         popupUI.Show (title, text, popupUI.defaultButtonText, PopupColor.Black, onCloseAction) ;
      }

      public static void Show (string title, string text, string buttonText) {
         Prepare () ;
         popupUI.Show (title, text, buttonText, PopupColor.Black, null) ;
      }

      public static void Show (string title, string text, string buttonText, UnityAction onCloseAction) {
         Prepare () ;
         popupUI.Show (title, text, buttonText, PopupColor.Black, onCloseAction) ;
      }

      public static void Show (string title, string text, string buttonText, PopupColor buttonColor) {
         Prepare () ;
         popupUI.Show (title, text, buttonText, buttonColor, null) ;
      }

      public static void Show (string title, string text, string buttonText, PopupColor buttonColor, UnityAction onCloseAction) {
         Prepare () ;
         popupUI.Show (title, text, buttonText, buttonColor, onCloseAction) ;
      }


      public static void Dismiss () {
         if (_isLoaded)
            popupUI.Dismiss () ; 
      }

   }

}
