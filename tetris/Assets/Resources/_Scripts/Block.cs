using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : IControllable, ITickable {
    private GameManager manager = GameManager.Instance;
    public int position_x;
    public int position_y;

    public static GameObject block_prefab = (GameObject)Resources.Load(Assets.Constants.BLOCK_PATH);
    private GameObject this_block;
    public Block(int x, int y) {
        //TODO: rewrite this to be relative to the GameManager's grid
        Debug.Log(Assets.Constants.BLOCK_PATH);
        this_block = GameObject.Instantiate(block_prefab);

        position_x = x;
        position_y = y;
        this_block.transform.position = new Vector3(x, y, 0);
    }

    public void MoveDown()
    {
        this_block.transform.Translate(0, -1, 0);
        position_y += -1;
    }

    public void MoveLeft()
    {
        this_block.transform.Translate(-1, 0, 0);
        position_x += -1;
    }

    public void MoveRight()
    {
        this_block.transform.Translate(1, 0, 0);
        position_x += 1;
    }

    public void Rotate()
    {
        throw new NotImplementedException();
    }

    public void Translate(int x, int y) {
        position_x += x;
        position_y += y;
        this_block.transform.Translate((float)x, (float)y, 0);
    }
    public bool Collided() {
        //Handle collision with ground
        if (position_y < 1)
        {
            return true;
        }
        //Handle collision with other cubes
        if (manager.grid[position_x, position_y - 1])
        {
            return true;
        }
        return false;

    }

    public void Tick() {
        MoveDown();
    }
}
