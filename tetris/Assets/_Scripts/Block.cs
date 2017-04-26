using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : IControllable, ITickable {

    public GameObject block;

    public Block(int x, int y) {
        block = GameObject.CreatePrimitive(PrimitiveType.Cube);
        block.transform.position = new Vector3(x, y, 0);
    }
    public void MoveDown()
    {
        block.transform.Translate(0, -1, 0);
    }

    public void MoveLeft()
    {
        block.transform.Translate(-1, 0, 0);
    }

    public void MoveRight()
    {
        block.transform.Translate(1, 0, 0);
    }

    public void Rotate()
    {
        throw new NotImplementedException();
    }

    public void Tick() {
        block.transform.Translate(0, -1, 0);
    }
}
