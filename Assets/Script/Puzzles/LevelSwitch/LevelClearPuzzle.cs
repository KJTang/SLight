using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
public class LevelClearPuzzle : Puzzle {
    public Transform player;

    private AudioSource audio;
	// Use this for initialization
	void Start () {
        Assert.IsNotNull(player);
        audio = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    public override void Update () {
        base.Update();
        if (GetTriggerDown())
        {
            AudioClip clip = Resources.Load("SoundEffect/成功") as AudioClip;
            audio.PlayOneShot(clip);
        }
	}
}
