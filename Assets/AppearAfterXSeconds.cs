using UnityEngine;
using System.Collections;

public class AppearAfterXSeconds : MonoBehaviour {

    public float seconds;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        seconds -= Time.deltaTime;
        if (seconds < 0) {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            GameObject.Destroy(this);
        }
    }
}
