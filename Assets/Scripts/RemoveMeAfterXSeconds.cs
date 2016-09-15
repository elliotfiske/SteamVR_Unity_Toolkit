using UnityEngine;
using System.Collections;

public class RemoveMeAfterXSeconds : MonoBehaviour {

    public double seconds;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        seconds -= Time.deltaTime;
        if (seconds < 0) {
            GameObject.Destroy(this.gameObject);
        }
	}
}
