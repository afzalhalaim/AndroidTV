using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UISystem;
public class VideoOption : MonoBehaviour
{
	public VideoDatas videoData;
	public static int currentSelectedId;

	

	public void Init()
	{
		this.GetComponent<Image>().sprite = videoData.thumb;
		//this.GetComponent<Button>().onClick.AddListener(PlayVideo);
	}

	public void PlayVideo()
	{
		
		currentSelectedId = this.videoData.videoId;
		ViewController.Instance.ChangeScreen(ScreenName.VideoPlayer);
	}
}
