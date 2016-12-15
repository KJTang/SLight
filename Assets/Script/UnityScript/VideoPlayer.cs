using UnityEngine;
using System.Collections;

public class VideoPlayer : MonoBehaviour {
    void Start() {
        Handheld.PlayFullScreenMovie("splash.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
        GameKernel.actionManager.RunAction(new ActionSequence(gameObject, 
            new ActionDelay(gameObject, 13.0f), 
            new ActionCallFunc(gameObject, (object obj) => {
                    // GameKernel.levelManager.ChangeLevel(
                    //     GameKernel.levelManager.CreateCommonLevel("StartScene"), 
                    //     true
                    // );
                }, 
                null
            )
        ));
    }
}
