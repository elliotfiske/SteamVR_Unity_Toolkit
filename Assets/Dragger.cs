using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Dragger : MonoBehaviour {

    public Transform emails;

    private List<Vector2> last3;

    // Use this for initialization
    void Start() {
        last3 = new List<Vector2>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void What(BaseEventData e) {
        //Debug.Log("OKAY: " + e);
        PointerEventData point = (PointerEventData)e;
        emails.Translate(point.delta / 100);
        //emails.Translate()

        last3.Insert(0, point.delta);
        if (last3.Count > 10) {
            last3.RemoveAt(10);
        }
    }

    public void StopDrag(BaseEventData e) {
        PointerEventData point = (PointerEventData)e;

        Debug.Log("OKAY: " + e);

        /// take avg
        Vector2 avgVector = Vector2.zero;

        foreach (Vector2 vec in last3) {
            avgVector += vec;
        }

        avgVector /= last3.Count;

     //   if (Mathf.Abs(avgVector.x) > 2 && Mathf.Abs(avgVector.y) > 2) {
            float x = Mathf.Pow(Mathf.Abs(avgVector.x), 0.1f) * Mathf.Sign(avgVector.x);
            float y = Mathf.Pow(Mathf.Abs(avgVector.y), 0.1f) * Mathf.Sign(avgVector.y);
            emails.gameObject.GetComponent<EmailLoader>().velocity = new Vector2(x, y) * 0.3f;
        // }
        last3.Clear();

    }

}
