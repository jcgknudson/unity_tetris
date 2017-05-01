using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float tick_delay;
    private float time_elapsed_since_tick = 0f;

    public List<ITickable> tickables;
    public Tetromino active_tetromino;
    public bool[,] grid;
    public List<char> next_tetrominoes;

    private static GameManager instance = null;
    
    //For singleton
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    
    //Any singleton-specific code should be in Awake, init code goes in Start
    void Awake()
    {
        if (instance != null && instance != this) {
            Debug.LogError("Destroying Objet: Instance already exists.");
            Destroy(gameObject);
            return;
        } else
            instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        tickables = new List<ITickable>();
        time_elapsed_since_tick = Time.time;
        grid = new bool[Assets.Constants.GAME_WIDTH, Assets.Constants.GAME_HEIGHT];

        //Fill tetromino buffer with random tetrominoes
        for(int i = 0; i < Assets.Constants.GAME_TETROMINO_BUFFER_SIZE; i++) {

        }
    }
	
	// Update is called once per frame
	void Update () {
        time_elapsed_since_tick += Time.deltaTime;
        
        if (time_elapsed_since_tick > tick_delay) {
            time_elapsed_since_tick = 0;
            Tick();
        }

        //DEBUG AND TESTING
        if (Input.GetKeyDown(KeyCode.O)) {
            Tetromino.Create('O');
        } else if (Input.GetKeyDown(KeyCode.I)) {
            Tetromino.Create('I');
        } else if (Input.GetKeyDown(KeyCode.T)) {
            Tetromino.Create('T');
        } else if (Input.GetKeyDown(KeyCode.J)) {
            Tetromino.Create('J');
        } else if (Input.GetKeyDown(KeyCode.L)) {
            Tetromino.Create('L');
        } else if (Input.GetKeyDown(KeyCode.S)) {
            Tetromino.Create('S');
        } else if (Input.GetKeyDown(KeyCode.Z)) {
            Tetromino.Create('Z');
        }
	}
    public void SetTetromino()
    {
        foreach (Block block in active_tetromino.blocks)
        {
            grid[block.position_x, block.position_y] = true;
        }
        active_tetromino = null;
    }

    void Tick() {
        //TODO check for loss
        //TODO check for/handle completed lines
        if (active_tetromino == null) {
            active_tetromino = Tetromino.Create(Assets.Utilities.GetRandomTetromino());
            active_tetromino.Translate(Assets.Constants.START_WIDTH, Assets.Constants.START_HEIGHT);
            Debug.Log("Created new active Tet");
            foreach (Block block in active_tetromino.blocks) {
                Debug.Log(" at (" + block.position_x + ", " + block.position_y + ")");
            }
            return;
        }
        if (active_tetromino.Collided()) {
            SetTetromino();
            return;
        }
        active_tetromino.Tick();
    }

}
