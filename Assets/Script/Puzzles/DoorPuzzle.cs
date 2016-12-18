using UnityEngine;
using UnityEngine.Assertions;

public class DoorPuzzle : Puzzle {
    protected bool acting = false;
    private Vector3 Init_position;
    public Vector3 Moved_position;
    public float Move_Time = 15.0f;
    public AudioSource audio;
    void Start() {
        //sprite = transform.Find("Sprite");
        //Assert.IsNotNull(sprite);
        Init_position = transform.position;
        audio = gameObject.AddComponent<AudioSource>();
    }
    
    public override void Update() {
        base.Update();
        if (GetTrigger() && !acting) {
            OnTriggerDown();
            acting = true;
        } else if (!GetTrigger() && acting) {
            OnTriggerUp();
            acting = false;
        }
    }

    protected void OnTriggerDown() {
        AudioClip clip = Resources.Load("SoundEffect/Door") as AudioClip;
        audio.PlayOneShot(clip);
        GameKernel.actionManager.RunAction(new ActionMoveBy(gameObject, Moved_position, Move_Time));
    }

    protected void OnTriggerUp() {
        AudioClip clip = Resources.Load("SoundEffect/Door") as AudioClip;
        audio.PlayOneShot(clip);
        GameKernel.actionManager.RunAction(new ActionMoveTo(gameObject, Init_position, Move_Time));
    }
}
