using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float tick_delay;
    public GameObject player;
    private float time_of_last_tick;
    public List<ITickable> tickables;
	
	void Start () {
        tickables = new List<ITickable>();
        time_of_last_tick = Time.time;
        player = new GameObject();
        player.AddComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        float elapsed_time = Time.time - time_of_last_tick;

        if (elapsed_time > tick_delay) {
            time_of_last_tick = Time.time;
            Tick();
        }
	}

    void Tick() {
        foreach (ITickable tickable in tickables) {
            tickable.Tick();
        }

    }
}
