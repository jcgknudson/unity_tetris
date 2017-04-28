using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : IControllable, ITickable {
    private GameManager manager = GameManager.Instance;
    public GameObject block;

    public Block(int x, int y) {
        //TODO: rewrite this to be relative to the GameManager's grid
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
        MoveDown();
        //TODO: add check on game manager grid
    }
}
