﻿using UnityEngine;
using System.Collections;

public class EndDoorState : MonoBehaviour {

 
        public float speed = 30.0f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * speed);

        }
}
