using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float TickDelay;
    private float time_of_last_tick;
    public List<ITickable> Tickables;
	
	void Start () {
        Tickables = new List<ITickable>();
        time_of_last_tick = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        float elapsed_time = Time.time - time_of_last_tick;

        if (elapsed_time > TickDelay) {
            time_of_last_tick = Time.time;
            Tick();
        }
	}

    void Tick() {
        foreach (ITickable tickable in Tickables) {
            tickable.Tick();
        }

    }
}
