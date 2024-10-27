using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.loopPointReached += OnFinished;
    }

    void OnFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("Game");
    }
}