using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UISystem;
using UnityEngine.UI;

public class VideoPlayerScreen : UISystem.Screen, IDragHandler, IPointerDownHandler
{
    [SerializeField] VideoManager videoManager;
    [SerializeField] VideoData videoData;

    [SerializeField] Sprite pause, resume;
    [SerializeField] Image playButton;

    bool isPlay;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Show()
    {
        isPlay = true;
        VideoManager.appState = States.VideoPlayer;
         videoManager.player.clip = videoData.videoClips.Find(X => X.videoId == VideoOption.currentSelectedId).clip;
        videoManager.VideoPlayerPlay();
        base.Show();
    }

    public void PlayButton()
    {
        if(isPlay) {
            isPlay = false;
            playButton.sprite = resume;
            videoManager.VideoPlayerPause();
		}
        else {
            isPlay = true;
            playButton.sprite = pause;
            videoManager.VideoPlayerPlay();
        }
    }

    //seek logic
    public void OnDrag(PointerEventData eventData)
    {
        videoManager.TrySeek(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        videoManager.TrySeek(eventData);
    }

    public override void Hide()
    {
        base.Hide();
    }
}