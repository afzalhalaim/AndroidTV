   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace UISystem {

    public class ViewController : MonoBehaviour 
    {
        public static ViewController Instance;
        Screen currentView;
        Screen previousView;
        [SerializeField] ScreenName initScreen;
        [SerializeField] List<ScreenView> screens = new List<ScreenView> ();
        [SerializeField] List<PopupView> popups = new List<PopupView> ();
        [SerializeField] NavBar navBar;
        [SerializeField] Popup toast;
        [System.Serializable]

        public struct ScreenView {
            public Screen screen;
            public ScreenName screenName;
            public bool hasNavBar;
        }

        [System.Serializable]
        public struct PopupView {
            public Popup popup;
            public PopupName popupName;
        }
        void Awake () {
            Instance = this;
             
        }
        void Start () => Init ();

        public void ShowPopup (PopupName popupName) {
            popups[GetPopupIndex (popupName)].popup.Show ();
            
        }

        public void HidePopup (PopupName popupName) {
               popups[GetPopupIndex (popupName)].popup.Hide ();
        }

        public void ShowToast (string description, float delay = 3) {
            toast.Fill (description);
            toast.Show ();
        }

        public void ChangeScreen (ScreenName screen) {
            if (currentView != null) {
                previousView = currentView;
                previousView.Hide ();

                currentView = screens[GetScreenIndex (screen)].screen;

                currentView.Show ();
            } else {
                Debug.Log(GetScreenIndex(screen) +" -- " +screen);
                currentView = screens[GetScreenIndex (screen)].screen;
                currentView.Show ();
            }
        }
        public void HideScreen (ScreenName screen) {
            currentView.Hide ();

        }
        public void HideSelectedScreen (ScreenName screen) {
            currentView = screens[GetScreenIndex (screen)].screen;
            currentView.Hide ();
        }
        void Update () {
            if (Input.GetKeyDown (KeyCode.Escape)) {
                for (int i = 0; i < popups.Count; i++) {
                    if (popups[i].popup.isActive) {
                        popups[i].popup.Hide ();
                        return;
                    }
                }
            }
        }

        int GetScreenIndex (ScreenName screen) {
            return screens.FindIndex (
                delegate (ScreenView screenView) {
                    return screenView.screenName.Equals (screen);
                });
        }

        int GetPopupIndex (PopupName popup) {
            return popups.FindIndex (
                delegate (PopupView popupView) {
                    return popupView.popupName.Equals (popup);
                });
        }

        public void RedrawView () => currentView.Redraw ();

        private void Init () {
            for (int indexOfScreen = 0; indexOfScreen < screens.Count; indexOfScreen++) {
                screens[indexOfScreen].screen.Disable ();
            }
            for (int indexOfpopup = 0; indexOfpopup < popups.Count; indexOfpopup++) {
                Debug.Log(indexOfpopup);
                popups[indexOfpopup].popup.Disable ();
            }

            if (initScreen != ScreenName.None) {
                ChangeScreen (initScreen);
            }
            // popups[GetPopupIndex(PopupName.LoadingPopup)].popup.Show();
        }

        public void DisableScreen()
        {
            for(int i = 0; i < screens.Count ; i++)
            {
                screens[i].screen.gameObject.GetComponent<GraphicRaycaster>().enabled = false;
            }
        }
        public void EnableScreen()
        {
            for(int i = 0; i < screens.Count ; i++)
            {
                 screens[i].screen.gameObject.GetComponent<GraphicRaycaster>().enabled = true;
            }
        }
 
        // public void ShowPopup(string title, string description)
        // {
        //     toast.Show(title, description);
        // }

        // public void HidePopup()
        // {
        //     toast.Hide();
        // }

        // ViewManager.Instance.GetViewComponent<ViewHunting>().ToggleChipsPopup(true);
        public T GetScreen<T> (ScreenName sName) => (T) screens[GetScreenIndex (sName)].screen.GetComponent<T> ();
        public T GetPopup<T> (PopupName sName) => (T) popups[GetPopupIndex (sName)].popup.GetComponent<T> ();
    }
}