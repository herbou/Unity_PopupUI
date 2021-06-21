/* -------------------------------
   Created by : Hamza Herbou
   hamza95herbou@gmail.com
---------------------------------- */

using UnityEngine ;
using System.Collections ;
using UnityEngine.UI ;
using EasyUI.Popup ;
using UnityEngine.Events ;


namespace EasyUI.Helpers {

   public class PopupUI : MonoBehaviour {
      [Header ("UI References :")]
      [SerializeField] private GraphicRaycaster uiCanvasGraphicRaycaster ;
      [SerializeField] private CanvasGroup uiCanvasGroup ;
      [SerializeField] private GameObject uiHeader ;
      [SerializeField] private Text uiTitle ;
      [SerializeField] private Text uiText ;
      [SerializeField] private Image uiButtonImage ;
      [SerializeField] private Text uiButtonText ;
      private Button uiButton ;

      [Header ("Popup Colors :")]
      [SerializeField] private Color[] colors ;

      [Header ("Popup Fade Duration :")]
      [Range (.1f, .8f)] [SerializeField] private float fadeInDuration = .3f ;
      [Range (.1f, .8f)] [SerializeField] private float fadeOutDuration = .3f ;

      [Space]
      public int maxTextLength = 200 ;
      public string defaultButtonText = "CLOSE" ;

      private UnityAction onCloseAction ;


      void Awake () {
         uiCanvasGroup.alpha = 0f ;
         uiCanvasGroup.interactable = false ;
         uiCanvasGraphicRaycaster.enabled = false ;

         uiButton = uiButtonImage.GetComponent < Button> () ;
         uiButton.onClick.RemoveAllListeners () ;
         uiButton.onClick.AddListener (() => {
            if (onCloseAction != null) {
               onCloseAction.Invoke () ;
               onCloseAction = null ;
            }
               
            StartCoroutine (FadeOut (fadeOutDuration)) ;
         }) ;
      }

      public void Show (string title, string text, string buttonText, PopupColor color, UnityAction action) {
         if (string.IsNullOrEmpty (title.Trim ()))
            uiHeader.SetActive (false) ;
         else {
            uiHeader.SetActive (true) ;
            uiTitle.text = title ;
         }

         uiText.text = (text.Length > maxTextLength) ? text.Substring (0, maxTextLength) + "..." : text ;

         uiButtonText.text = buttonText ;

         Color c = colors [ (int)color ] ; 
         Color ct = c ;
         ct.a = .75f ;
         uiTitle.color = ct ;
         uiButtonImage.color = c ;

         onCloseAction = action ;

         Dismiss () ;
         StartCoroutine (FadeIn (fadeInDuration)) ;
      }

      private IEnumerator FadeIn (float duration) {
         uiCanvasGraphicRaycaster.enabled = true ;
         yield return Fade (uiCanvasGroup, 0f, 1f, duration) ;
         uiCanvasGroup.interactable = true ;
      }

      private IEnumerator FadeOut (float duration) {
         yield return Fade (uiCanvasGroup, 1f, 0f, duration) ;
         uiCanvasGroup.interactable = false ;
         uiCanvasGraphicRaycaster.enabled = false ;
      }

      private IEnumerator Fade (CanvasGroup cGroup, float startAlpha, float endAlpha, float duration) {
         float startTime = Time.time ;
         float alpha = startAlpha ;

         if (duration > 0f) {
            //Anim start
            while (alpha != endAlpha) {
               alpha = Mathf.Lerp (startAlpha, endAlpha, (Time.time - startTime) / duration) ;
               cGroup.alpha = alpha ;

               yield return null ;
            }
         }

         cGroup.alpha = endAlpha ;
      }

      public void Dismiss () {
         StopAllCoroutines () ;
         uiCanvasGroup.alpha = 0f ;
         uiCanvasGroup.interactable = false ;
         uiCanvasGraphicRaycaster.enabled = false ;
      }

      private void OnDestroy () {
         EasyUI.Popup.Popup._isLoaded = false ;
      }
   }

}
