using UnityEngine;
using System.Collections;

public class MouseTracking : MonoBehaviour {
	 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		var mouse = Input.mousePosition;
		var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
		var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
		var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, angle);
	
	}
}
