using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using System.Collections.Generic;
public class WatProducerPuzzle : Puzzle {

    Transform sprite;
    private Vector3 Init_position;

    public List<float> pos;
    public List<float> time;
    static int count = 0;
    void Start()
    {
        Init_position = transform.position;
        sprite = transform.Find("Sprite");
        Assert.IsNotNull(sprite);

    }

    public override void Update()
    {
        base.Update();
        if (GetTriggerDown())
        {
            if (pos.Count > 0)
            {
                count++;
                OnTriggerDown(pos[0],time[0]);
            }

        }
        else if (GetTriggerUp())
        {
            OnTriggerUp();
        }
    }

    void OnTriggerDown(float posx,float timex)
    {
        GameKernel.actionManager.RunAction(new ActionSequence(gameObject,
            new ActionMoveTo(sprite.gameObject, new Vector3(sprite.position.x, posx, sprite.position.z), timex),
            new ActionCallFunc(sprite.gameObject, (object obj) =>
            {
                if (count < pos.Count)
                {
                    count++;
                    OnTriggerDown(pos[count - 1], time[count - 1]);
                }
            })
        )
        );
    }

    void OnTriggerUp()
    {
        GameKernel.actionManager.RunAction(new ActionMoveTo(sprite.gameObject, Init_position, 0.1f));
    }
}
