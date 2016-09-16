using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BulletBro : MonoBehaviour {

    private bool neutered = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter(Collision collision) {
        if (!neutered) {
            GameObject otherGuy = collision.collider.gameObject;
            if (otherGuy.tag.Equals("EmailBrick")) {
                otherGuy.transform.parent.FindChild("EmailCanvas/Panel").GetComponent<Image>().color = new Color(0, 51, 204);
                otherGuy.AddComponent<Rigidbody>();
                otherGuy.GetComponent<Rigidbody>().isKinematic = false;
                otherGuy.GetComponent<Rigidbody>().AddForce(
                    Random.Range(-1000, -3000), Random.Range(100, 1000), Random.Range(-1000, 1000));
                otherGuy.transform.SetParent(this.transform.parent);
            }
        }
        neutered = true;
    }
}