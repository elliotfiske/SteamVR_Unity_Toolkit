using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EmailCubeExpander : MonoBehaviour {

    public Email email;
    public bool expanded = false;
    private Transform cubeTF;

	// Use this for initialization
	void Start () {
        cubeTF = transform.FindChild("CubeBG");
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = cubeTF.position;
	}

    public void ExpandMe() {
        Text brexit = transform.FindChild("EmailCanvas/SnippetText").GetComponent<Text>();
        Canvas manvas = transform.FindChild("EmailCanvas").GetComponent<Canvas>();
        if (expanded) {
            brexit.text = email.snippet;
            manvas.GetComponent<RectTransform>().sizeDelta = new Vector2(763.7f, 187);
            brexit.GetComponent<RectTransform>().sizeDelta = new Vector2(731.7f, 155);

            transform.Translate(0, 0, 1);
        }
        else {
            brexit.text = email.body;
            GUIContent fart = new GUIContent(email.body);
            GUIStyle huh = new GUIStyle();
            float newHeight = huh.CalcHeight(fart, 731.7f);

            Transform cuber = this.transform.FindChild("CubeBG");
            Vector3 yeah = cuber.localScale;
            yeah.y = newHeight;
            cuber.localScale = yeah;

            manvas.GetComponent<RectTransform>().sizeDelta = new Vector2(763.7f, 287 + newHeight);
            brexit.GetComponent<RectTransform>().sizeDelta = new Vector2(731.7f, newHeight);
            transform.Translate(0, 0, -1);
        }

        expanded = !expanded;
    }
}
