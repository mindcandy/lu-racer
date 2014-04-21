using UnityEngine;
using System.Collections;

public class CarLapCounter : MonoBehaviour {

	public TrackLapTrigger first;
	public TextMesh textMesh;

	TrackLapTrigger next;
	
	int _lap;

	// Use this for initialization
	void Start () {
		_lap = 0;
		SetNextTrigger(first);
		UpdateText();
	}

	// update lap counter text
	void UpdateText() {
		if (textMesh) {
			textMesh.text = string.Format("Lap {0}", _lap);		
		}
	}

	// when lap trigger is entered
	public void OnLapTrigger(TrackLapTrigger trigger) {
		if (trigger == next) {
			if (first == next) {
				_lap++;
				UpdateText();
			}
			SetNextTrigger(next);
		}
	}

	void SetNextTrigger(TrackLapTrigger trigger) {
		next = trigger.next;
		SendMessage("OnNextTrigger", next, SendMessageOptions.DontRequireReceiver);
	}
}
