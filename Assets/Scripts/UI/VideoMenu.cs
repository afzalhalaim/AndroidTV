using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UISystem;
public class VideoMenu : UISystem.Screen
{
    [SerializeField] Transform menuParent;
    [SerializeField] VideoOption videoOption;

    [SerializeField] VideoData videoData;
    public override void Awake()
    {
        base.Awake();
    }

    public override void Show()
    {
        VideoManager.appState = States.VideoMenu;
        GenrateMenu();
        base.Show();
    }

    void GenrateMenu()
	{
        if (menuParent.childCount > 0)
            return;

        for(int i = 0; i<videoData.videoClips.Count; i++ )
        {
            VideoOption vOption = Instantiate(videoOption, menuParent);
            vOption.videoData = videoData.videoClips[i];
            vOption.Init();
        }
	}

    public override void Hide()
    {
        base.Hide();
    }


    public override void Redraw()
    {
        base.Redraw();
    }

    public void OpenVideo()
    {
        ViewController.Instance.ChangeScreen(ScreenName.VideoPlayer);
    }

}
