using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.Linq;


public class EmailLoader : MonoBehaviour {

    public GameObject emailPrefab;
    public GameObject dayPrefab;

    List<Email> emails;

	// Use this for initialization
	void Start () {

        emails = new List<Email>();

        for (int ndx = 0; ndx < 320; ndx++) {
            var text = Resources.Load("Emails/test" + ndx.ToString()) as TextAsset;
            var str = text.ToString();

            Match m = Regex.Match(str, "^(.*?)\\r\\n(.*?)\\r\\n(\\d*?)\\r\\n(.*?)\\r\\n(.*)", RegexOptions.Singleline);

            string subject = m.Groups[1].Value;
            string sender = m.Groups[2].Value;

            double date = Convert.ToDouble(m.Groups[3].Value);
            date /= 1000;

            string snippet = m.Groups[4].Value;
            string body = m.Groups[5].Value;

            Email sbemail = new Email(subject, sender, date, snippet, body);

            emails.Add(sbemail);
        }

        emails.OrderBy(email => email.receivedTime);

        Vector3 emailPosn = Vector3.zero;
        DateTime currDay = DateTime.MinValue;

        Quaternion faceFront = Quaternion.AngleAxis(0, Vector3.up);

        foreach (var sbemail in emails) {
            DateTime emailDay = sbemail.receivedTime.Date;
            if (currDay != emailDay) {
                emailPosn += new Vector3(-4.1f, 0, 0);
                emailPosn.y = 0;
                currDay = emailDay;

                GameObject newDay = GameObject.Instantiate(dayPrefab, emailPosn + new Vector3(0, 1, 0), faceFront) as GameObject;
                Text bleh = newDay.transform.FindChild("DayText").GetComponent<Text>();
                bleh.text = String.Format("{0:dddd, MMMM d}", emailDay);
            }

            GameObject newBrick = GameObject.Instantiate(emailPrefab, emailPosn, faceFront) as GameObject;

            Text subj = newBrick.transform.FindChild("EmailCanvas/SubjectText").GetComponent<Text>();
            subj.text = sbemail.subject;

            Text send = newBrick.transform.FindChild("EmailCanvas/SenderText").GetComponent<Text>();
            send.text = sbemail.sender;

            Text snipply = newBrick.transform.FindChild("EmailCanvas/SnippetText").GetComponent<Text>();
            snipply.text = sbemail.snippet;

            Text timeguy = newBrick.transform.FindChild("EmailCanvas/TimeText").GetComponent<Text>();
            timeguy.text = String.Format("{0:h:m tt}", sbemail.receivedTime);

            emailPosn += new Vector3(0, -1.1f, 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class Email {
    public string subject;
    public string sender;
    public DateTime receivedTime;
    public string snippet;
    public string body;

    public Email(string subject, string sender, double timestamp, string snippet, string body) {
        this.subject = subject;
        this.sender = sender;
        DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        this.receivedTime = dt.AddSeconds(timestamp).ToLocalTime();
        this.snippet = snippet;
        this.body = body;
    }
}