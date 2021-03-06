﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class Constants
    {
        ///////////////////PLAYER CONSTANTS/////////////////////////////////
        public static float PLAYER_INPUT_HOLD_INIT_DURATION = 0.1f;
        public static float PLAYER_HORIZONTAL_SHIFT_HOLD_THRESHOLD = 0.1f;
        public static float PLAYER_HORIZONTAL_SHIFT_HOLD_LATENCY = 0.1f;
        public static float PLAYER_SOFT_DROP_HOLD_THRESHOLD = 0.1f;
        public static float PLAYER_SOFT_DROP_HOLD_LATENCY = 0.1f;


        ///////////////////GLOBAL GAME CONSTANTS////////////////////////////
        public static short GAME_WIDTH = 10;
        public static short GAME_HEIGHT = 20;
        public static string GAME_TETROMINOS = "OITLJSZ";
        public static int GAME_TETROMINO_BUFFER_SIZE = 4;

        public static int START_WIDTH = 5;
        public static int START_HEIGHT = 10;
        

        ///////////////////PREFAB PATHS/////////////////////////////////////
        public static string BLOCK_PATH = "_Prefabs/Block";
    }
}
