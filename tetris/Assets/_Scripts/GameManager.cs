using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float tick_delay;
    private float time_elapsed_since_tick = 0f;

    public List<ITickable> tickables;
    //public List<Grid> grids;

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
    }
	
	// Update is called once per frame
	void Update () {
        time_elapsed_since_tick += Time.deltaTime;
        
        if (time_elapsed_since_tick > tick_delay) {
            time_elapsed_since_tick = 0;
            Debug.Log("Game manager tick");
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

    void Tick() {
        foreach (ITickable tickable in tickables) {
            tickable.Tick();
        }

    }

}
