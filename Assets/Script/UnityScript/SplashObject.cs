using UnityEngine;
using System.Collections;

public class SplashObject : MonoBehaviour {
    public string nextLevel = "StartScene";
    private string videoPath = "splash.mp4";

    void Start() {
        StartCoroutine(PlayVideoCoroutine(videoPath));
    }

    IEnumerator PlayVideoCoroutine(string videoPath) {
        Handheld.PlayFullScreenMovie(videoPath, Color.black, FullScreenMovieControlMode.CancelOnInput);    
        yield return new WaitForEndOfFrame();
        // Debug.Log("Video playback completed.");
        GameKernel.actionManager.RunAction(new ActionSequence(gameObject, 
            new ActionDelay(gameObject, 0.5f), 
            new ActionCallFunc(gameObject, (object obj) => {
                    GameKernel.levelManager.ChangeLevel(
                        GameKernel.levelManager.CreateCommonLevel(nextLevel), 
                        true
                    );
                }, 
                null
            )
        ));
    }
}
