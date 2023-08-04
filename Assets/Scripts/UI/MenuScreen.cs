using UnityEngine;
using UnityEngine.UI;
using UISystem;

public class MenuScreen : UISystem.Screen
{

    public override void Awake()
    {
        base.Awake();
    }

    public override void Show()
    {
        VideoManager.appState = States.MainMenu;

        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }
    

    public override void Redraw()
    {
        base.Redraw();
    }

    public void VideoMenu()
    {
        ViewController.Instance.ChangeScreen(ScreenName.VideoMenu);
    }

}
