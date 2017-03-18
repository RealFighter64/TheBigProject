using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

	public Card[] cardArray;

	public Transform cardPrefab;
	public int initialCardAmount;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < initialCardAmount; i++) {
			cardArray = new Card[10];
			Transform tempCard = Instantiate (cardPrefab) as Transform;
			tempCard.SetParent (this.transform);
			tempCard.GetComponent<RectTransform> ().localPosition = new Vector3 (-10 + -138*i, 10);
			Card tempCardData = tempCard.GetComponent<Card> ();
			tempCardData.Init ("aisdogdfhg", "soipdfuguusoudfygusdfygoiudfgusodifg", i);
			cardArray [i] = tempCardData;
		}

	}

	void Awake() {
		
	}
}
