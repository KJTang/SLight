using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class BackGroundMove : MonoBehaviour {
    public Transform reference; 
    public float multiple = 5;
    private float reference_change;
    private float reference_position;
    // Use this for initialization
    void Start () {
        Assert.IsNotNull(reference);
        reference_position = reference.position.x;
	}
	
	// Update is called once per frame
	void Update () {
    
        transform.position += new Vector3(reference_change / multiple, 0, 0);
        reference_position = reference.position.x;
    }
}
