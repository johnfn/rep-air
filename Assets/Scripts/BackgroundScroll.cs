using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

	[SerializeField] private float scrollSpeedx;
	[SerializeField] private float scrollSpeedy;

	// // Scroll offset value to smoothly repeat backgrounds movement
	// public float scrollOffset;

	// Start position of background movement
	Vector2 startPos;

	// Backgrounds new position
	float newPosx;

	float newPosy;

	float width;

	float height;

	// Use this for initialization
	void Start () {
		// Getting backgrounds start position
		startPos = GetComponent<RectTransform>().anchoredPosition;
		width = GetComponent<RectTransform>().rect.width;
		height = GetComponent<RectTransform>().rect.height;
	}
	
	// Update is called once per frame
	void Update () {
		// Getting backgrounds start position
		// startPos = GetComponent<RectTransform>().anchoredPosition;
		// width = GetComponent<RectTransform>().rect.width;
		// height = GetComponent<RectTransform>().rect.height;
		
		// // Calculating new backgrounds position repeating it depending on scrollOffset
		newPosx = Mathf.Repeat (newPosx+scrollSpeedx, width*GetComponent<RectTransform>().localScale.x);
		newPosy = Mathf.Repeat (newPosy+scrollSpeedy, height*GetComponent<RectTransform>().localScale.y);


		// // Setting new position
		GetComponent<RectTransform>().anchoredPosition = startPos + Vector2.left * newPosx + Vector2.up * newPosy;
		// GetComponent<RectTransform>().anchoredPosition = newPos;

	}
}
