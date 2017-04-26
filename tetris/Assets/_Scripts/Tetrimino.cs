using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrimino : MonoBehaviour, ITickable, IControllable {
    GameManager manager;
    List<Block> blocks;
    void Start() {
        blocks = new List<Block>();
        for (int y = 0; y < 4; y++) {
            blocks.Add(new Block(0, y));
        }
    
    }

    public void MoveDown()
    {
        foreach (IControllable block in blocks) {
            block.MoveDown();
        }
    }

    public void MoveLeft()
    {
        foreach (IControllable block in blocks)
        {
            block.MoveLeft();
        }
    }

    public void MoveRight()
    {
        foreach (IControllable block in blocks)
        {
            block.MoveRight();
        }
    }

    public void Rotate()
    {
        foreach (IControllable block in blocks)
        {
            block.Rotate();
        }
    }

    public void Tick() {
        foreach (ITickable block in blocks)
        {
            block.Tick();
        }
    }
}
