using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
public class SpecialDoorPuzzle : DoorPuzzle {
    public Puzzle p1, p2, p3;
    Sprite sp1,sp2,sp3;
    // Use this for initialization
    private SpriteRenderer rer;
	void Start () {
        Assert.IsNotNull(p1);
        Assert.IsNotNull(p2);
        Assert.IsNotNull(p3);
        rer = gameObject.GetComponent<SpriteRenderer>();
        Texture2D texture2d = (Texture2D)Resources.Load("LevelA3_Image/Puz2");
        sp1 = Sprite.Create(texture2d, rer.sprite.textureRect, new Vector2(0.5f, 0.5f));
        texture2d = (Texture2D)Resources.Load("LevelA3_Image/Puz3");
        sp2 = Sprite.Create(texture2d, rer.sprite.textureRect, new Vector2(0.5f, 0.5f));
        texture2d = (Texture2D)Resources.Load("LevelA3_Image/Puz");
        sp3 = Sprite.Create(texture2d, rer.sprite.textureRect, new Vector2(0.5f, 0.5f));
    }
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
        if (p1.GetTriggerDown())
        {
            rer.sprite = sp1;
        }
        if (p2.GetTriggerDown())
        {
            rer.sprite = sp2;
        }
        if (p3.GetTriggerDown())
        {
            rer.sprite = sp3;
        }

    }
}
