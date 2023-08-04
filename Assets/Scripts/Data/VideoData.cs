using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "Data", menuName = "VideoData")]

public class VideoData : ScriptableObject
{
    public List<VideoDatas> videoClips = new List<VideoDatas>();
}

[System.Serializable]
public class VideoDatas
{
    public int videoId;
    public VideoClip clip;
    public Sprite thumb;
}
