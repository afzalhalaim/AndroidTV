using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace UISystem
{
    [System.Serializable]
    
    public class PopupView
    {
        public Popup popup;
        public PopupName popupName;
    }
    public class BaseUI : MonoBehaviour
    {
        [HideInInspector]
        public GameObject content;
        protected Canvas canvas;
        protected UIAnimator uiAnimator;
        protected UIAnimation uiAnimation;
        [HideInInspector]
        public CanvasGroup canvasGroup;
        public bool isActive { get; private set; }

        public virtual void Awake()
        {
            content = transform.GetChild(0).gameObject;
            //Debug.Log(transform.GetChild(0).gameObject.name);
            canvas = GetComponent<Canvas>();
            canvasGroup = content.GetComponent<CanvasGroup>();
            uiAnimator = GetComponent<UIAnimator>();
            uiAnimation = GetComponent<UIAnimation>();
        }
        public virtual void Disable()
        {
            canvas.enabled = false;//screws with the joysticks because apparently they scale (what?)// content.SetActive(false);
            isActive = false;
        }
        public virtual void Enable()
        {
            canvas.enabled = true;//screws with the joysticks because apparently they scale (what?)// content.SetActive(true);
            isActive=true;
        } 
        public virtual void Show()
        {
            if (isActive)
                return;
        
            canvasGroup.interactable = true;
            if (uiAnimator)
            {
                uiAnimator.StopHide();
                uiAnimator.StartShow();
                isActive = true;
            }
            else
            {
                Enable();
                isActive = true;
            }
            Redraw();
        }
        public virtual void Hide()
        {
            canvasGroup.interactable = false;
            if (uiAnimator)
            {
                uiAnimator.StopShow();
                uiAnimator.StartHide();
                isActive = false;
            }
            else
            {
                Disable();
                isActive = false;
            }
        }
        public virtual void Redraw()
        {
        }
        public void ShowPopups (List<PopupView> popups, int popupName) 
        {
            PopupView view = popups.Find (x => x.popupName.Equals ( (PopupName) popupName  ));
            if (view != null) 
            {
                view.popup.Show ();
              
                //Debug.Log("ShowCAlled");
            } else {
                Debug.Log ((PopupName) popupName + " Could not be found in given list");
            }
        }
        public void HidePopup(List<PopupView> popups)
        {
            for(int indexOfPopup=0;indexOfPopup<popups.Count;indexOfPopup++)
            {
                popups[indexOfPopup].popup.Disable();
            }
             
        }
    }
}