using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static int next_player_index = 0;
    public int this_player_index;

    //Variables used for tracking timing of player inputs

    //When a player presses and holds an input key, this is the duration 
    //the key must be held to trigger rapid movement
    public float horizontal_shift_hold_threshold;
    private float horizontal_shift_hold_threshold_timer;

    //After horizontal_shift_hold_threshold has passed, the terimino will shift left or
    //right after this amount of time
    public float horizontal_shift_hold_latency;
    private float horizontal_shift_hold_timer;

    public float soft_drop_hold_threshold;
    private float soft_drop_hold_threshold_timer;

    public float soft_drop_hold_latency;
    private float soft_drop_hold_timer;

    public float score = 0f;

    //Abstract the keycodes for multiple players
    public KeyCode player_left_input;
    public KeyCode player_right_input;
    public KeyCode player_hard_drop_input;
    public KeyCode player_soft_drop_input;
    public KeyCode player_rotate_input;

    //Object currently being controlled by the player
    public GameObject active_object;
    public IControllable active_controllable;

	// Use this for initialization
	void Start () {
        this_player_index = next_player_index++;
        
        if(this_player_index == 0) {
            player_left_input = KeyCode.LeftArrow;
            player_right_input = KeyCode.RightArrow;
            player_hard_drop_input = KeyCode.UpArrow;
            player_soft_drop_input = KeyCode.DownArrow;
            player_rotate_input = KeyCode.RightShift;
        } else if (this_player_index == 1) {
            player_left_input = KeyCode.A;
            player_right_input = KeyCode.D;
            player_hard_drop_input = KeyCode.W;
            player_soft_drop_input = KeyCode.S;
            player_rotate_input = KeyCode.Space;
        }

        active_controllable = active_object.GetComponent<Tetrimino>();
	}

    // Update is called once per frame
    void Update() {
        //Move left
        if (Input.GetKeyDown(player_left_input)) {
            active_controllable.MoveLeft();
        } else if (Input.GetKeyDown(player_right_input)) {
            active_controllable.MoveRight();
        } else if (Input.GetKeyDown(player_rotate_input)) {
            active_controllable.Rotate();
        } 
        
	}
}
