using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tetromino : IControllable, ITickable {
    public List<Block> blocks;

    public static Tetromino Create(char tetrominoType)
    {
        Tetromino tetromino = new Tetromino();

        switch (tetrominoType) {
            case 'O':
                for (int x = 0; x < 2; x++) {
                    for (int y = 0; y < 2; y++)
                        tetromino.blocks.Add(new Block(x, y));
                }
                break;
            case 'I':
                for (int y = 0; y < 4; y++)
                    tetromino.blocks.Add(new Block(0, y));
                break;
            case 'T':
                for (int x = 0; x < 3; x++)
                    tetromino.blocks.Add(new Block(x, 0));
                tetromino.blocks.Add(new Block(1, 1));
                break;
            case 'J':
                for (int y = 0; y < 3; y++)
                    tetromino.blocks.Add(new Block(1, y));
                tetromino.blocks.Add(new Block(0, 2));
                break;
            case 'L':
                for (int y = 0; y < 3; y++)
                    tetromino.blocks.Add(new Block(0, y));
                tetromino.blocks.Add(new Block(1, 2));
                break;
            case 'S':
                tetromino.blocks.Add(new Block(0, 1));
                tetromino.blocks.Add(new Block(1, 1));
                tetromino.blocks.Add(new Block(1, 0));
                tetromino.blocks.Add(new Block(2, 0));
                break;
            case 'Z':
                tetromino.blocks.Add(new Block(0, 0));
                tetromino.blocks.Add(new Block(1, 0));
                tetromino.blocks.Add(new Block(1, 1));
                tetromino.blocks.Add(new Block(2, 1));
                break;
            default:
                throw new ArgumentException("Unrecognized tetromino character");
        }
        return tetromino;
    }

    public Tetromino()
    {
        blocks = new List<Block>();
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

    public bool Collided() {
        foreach (Block block in blocks) {
            if (block.Collided()) {
                return true;
            }
        }
        return false;
    }

    public void Translate(int x, int y){
        foreach(Block block in blocks)
        {
            block.Translate(x, y);
        }
    }

    public void Tick() {
        foreach (ITickable block in blocks)
        {
            block.Tick();
        }
    }
}
