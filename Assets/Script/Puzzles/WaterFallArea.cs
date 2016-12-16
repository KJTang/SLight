using UnityEngine;
using System.Collections;

public class WaterFallArea : MonoBehaviour {
    public Vector2 f;
    void OnTriggerStay2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.GetComponent<Rigidbody2D>());
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(f, ForceMode2D.Force);
        }
    }
}
