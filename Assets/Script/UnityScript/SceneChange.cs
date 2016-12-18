using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class SceneChange : MonoBehaviour {
    public float totalTime = 0.0f;
    public string nextLevelName = "";

    private float timer = 0.0f;
    private bool isChanged = false;

	// Use this for initialization
	void Start () {
        Assert.IsTrue(nextLevelName.Length != 0);
    }
    
    // Update is called once per frame
    void Update () {
        #if UNITY_IOS || UNITY_ANDROID
        if (Input.touchCount > 0 && !isChanged) {
            isChanged = true;
            GameKernel.levelManager.ChangeLevel(
                GameKernel.levelManager.CreateCommonLevel(nextLevelName),
                true
            );
        }
        #endif
        #if UNITY_WINDOWS || UNITY_LINUX || UNITY_EDITOR
        if (Input.anyKeyDown) {
            isChanged = true;
            GameKernel.levelManager.ChangeLevel(
                GameKernel.levelManager.CreateCommonLevel(nextLevelName),
                true
            );
        }
        #endif
        // if (timer >= totalTime && !isChanged) {
        //     isChanged = true;
        //     GameKernel.levelManager.ChangeLevel(
        //         GameKernel.levelManager.CreateCommonLevel(nextLevelName),
        //         true
        //     );
        // }
        // timer += Time.deltaTime;
	}
}
