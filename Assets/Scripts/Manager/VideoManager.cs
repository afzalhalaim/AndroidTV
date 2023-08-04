using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityEngine.UI;
using UISystem;
public class VideoManager : MonoBehaviour
{
    public static States appState;
    public VideoPlayer player;
    public Image progress;
    
    void Update()
    {
        if (player.frameCount > 0)
            progress.fillAmount = (float)player.frame / (float)player.frameCount;

        // back system
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

    void Back()
	{
        switch(appState)
        {
            case States.VideoMenu:
                appState = States.MainMenu;
                ViewController.Instance.ChangeScreen(ScreenName.MainScreen);
                break;
            case States.VideoPlayer:
                VideoPlayerPause();
                appState = States.VideoMenu;
                ViewController.Instance.ChangeScreen(ScreenName.VideoMenu);
                break;
		}
	}

    // seek logic
    private void SeekToPercent(float pct)
    {
        
        var frame = player.frameCount * pct;
        player.frame = (long)frame;
    }

    public void TrySeek(PointerEventData eventData)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            progress.rectTransform, eventData.position, null, out localPoint))
        {
            float pct = Mathf.InverseLerp(progress.rectTransform.rect.xMin, progress.rectTransform.rect.xMax, localPoint.x);
            SeekToPercent(pct);
        }
    }

    // video paused
    public void VideoPlayerPause()
    {
        if(player != null)
            player.Pause();
    }

    // video play
    public void VideoPlayerPlay()
    {
        if(player != null)
            player.Play();  
    }
  
}

