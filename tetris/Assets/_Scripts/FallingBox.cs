using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBox : MonoBehaviour, IControllable {
    public void MoveDown()
    {
        Vector3 pos = this.transform.position;
        pos.y -= 1;
        this.transform.position = pos;
    }

    public void MoveLeft()
    {
        Vector3 pos = this.transform.position;
        pos.x -= 1;
        this.transform.position = pos;
    }

    public void MoveRight()
    {
        Vector3 pos = this.transform.position;
        pos.x += 1;
        this.transform.position = pos;
    }

    public void Rotate()
    {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
