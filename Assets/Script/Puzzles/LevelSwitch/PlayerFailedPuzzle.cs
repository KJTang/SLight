using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
public class PlayerFailedPuzzle : Puzzle {
    //    public Transform player;
    // Use this for initialization
    private AudioSource audio;
	void Start () {
        //        Assert.IsNotNull(player);
        //        isTriggered = false;
        audio = gameObject.AddComponent<AudioSource>();
    }
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
        if (GetTriggerDown())
        {
            AudioClip clip = Resources.Load("SoundEffect/失败") as AudioClip;
            audio.PlayOneShot(clip);
        }
    }
}
