using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class MovablePuzzle : Puzzle {
    public enum MoveType {
        TO, BY
    };

    public MoveType isToOrBy = MoveType.TO;

    public Vector3 moveDist = new Vector3(0, 0, 0);
    public Vector3 backDist = new Vector3(0, 0, 0);
    public AudioSource audio;
    public float moveTime = 1.0f;
    public float backTime = 1.0f;

    private bool acting = false;

    private Vector3 originPos = new Vector3(0, 0, 0);
    private Vector3 destPos = new Vector3(0, 0, 0);

    void Start() {
        isTriggered = false;
        audio = gameObject.AddComponent<AudioSource>();
    }
    
    public override void Update() {
        base.Update();
        if (GetTrigger() && !acting) {
            acting = true;
            OnTriggerDown();
        }
        if (!GetTrigger() && acting) {
            acting = false;
            OnTriggerUp();
        }
    }

    void OnTriggerUp() {
        AudioClip clip = Resources.Load("SoundEffect/Door") as AudioClip;
        audio.PlayOneShot(clip);
        if (isToOrBy == MoveType.TO) {
            originPos = transform.position;
            destPos = backDist;
            GameKernel.actionManager.RunAction(new ActionMoveTo(gameObject, backDist, backTime));
        } else {
            if (GameKernel.actionManager.IsRunning(gameObject)) {
                Vector3 offset = destPos + backDist - transform.position;
                originPos = transform.position;
                destPos = transform.position + offset;
                GameKernel.actionManager.RunAction(new ActionMoveBy(gameObject, offset, backTime));
            } else {
                originPos = transform.position;
                destPos = transform.position + backDist;
                GameKernel.actionManager.RunAction(new ActionMoveBy(gameObject, backDist, backTime));
            }
        }
    }

    void OnTriggerDown() {
        AudioClip clip = Resources.Load("SoundEffect/Door") as AudioClip;
        Assert.IsNotNull(clip);
        audio.PlayOneShot(clip);
        if (isToOrBy == MoveType.TO) {
            originPos = transform.position;
            destPos = moveDist;
            GameKernel.actionManager.RunAction(new ActionMoveTo(gameObject, moveDist, moveTime));
        } else {
            if (GameKernel.actionManager.IsRunning(gameObject)) {
                Vector3 offset = destPos + moveDist - transform.position;
                originPos = transform.position;
                destPos = transform.position + offset;
                GameKernel.actionManager.RunAction(new ActionMoveBy(gameObject, offset, moveTime));
            } else {
                originPos = transform.position;
                destPos = transform.position + moveDist;
                GameKernel.actionManager.RunAction(new ActionMoveBy(gameObject, moveDist, moveTime));
            }
        } 
    }
}
