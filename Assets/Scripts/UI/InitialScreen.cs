using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UISystem;

public class InitialScreen : MonoBehaviour
{
    bool isTvOn = false;

    //Tv on off logic
    public void TvOnOff()
    {
        if (isTvOn) {
            VideoManager.appState = States.TvOff;

            ViewController.Instance.HideScreen(ScreenName.MainScreen);
            ViewController.Instance.HideScreen(ScreenName.VideoMenu);
            ViewController.Instance.HideScreen(ScreenName.VideoPlayer);

        } else
        {
            VideoManager.appState = States.MainMenu;

            ViewController.Instance.ChangeScreen(ScreenName.MainScreen);
        }
        isTvOn = !isTvOn;
    }

}
