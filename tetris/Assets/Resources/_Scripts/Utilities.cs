using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class Utilities
    {
        public static Random rng = new Random(System.DateTime.Now.Millisecond);

        public static char GetRandomTetromino()
        {
            int tetromino_str_sz = Constants.GAME_TETROMINOS.Length;
            char random_tetromino = Constants.GAME_TETROMINOS[
                rng.Next(0, tetromino_str_sz)];

            return random_tetromino;
        }
    }
}