using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	public float scaleFactor;
	public float speedOfGrowth;

	private string _name;
	private string _description;
	private int _manaCost;

	private Text nameText;
	private Text descriptionText;
	private Text manaCostText;

	public string Name {
		get {
			return this._name;
		}
		set {
			_name = value;
			UpdateCardInformation ();
		}
	}

	public string Description {
		get {
			return this._description;
		}
		set {
			_description = value;
			UpdateCardInformation ();
		}
	}

	public int ManaCost {
		get {
			return this._manaCost;
		}
		set {
			_manaCost = value;
			UpdateCardInformation ();
		}
	}

	private float currentScaleFactor = 1;
	private bool currentlyMouseOver = false;
	public bool ready = false;

	private RectTransform rectTransform;

	// Use this for initialization
	void Start () {
		rectTransform = GetComponent<RectTransform> ();
		nameText = transform.FindChild ("Name").GetComponent<Text> ();
		descriptionText = transform.FindChild ("Description").GetComponent<Text> ();
		manaCostText = transform.FindChild ("Mana Cost").GetComponent<Text> ();
	}

	public void Init (string name, string description, int manaCost) {
		if (ready) {
			_name = name;
			_description = description;
			_manaCost = manaCost;
			UpdateCardInformation ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		rectTransform.localScale = new Vector3 (currentScaleFactor, currentScaleFactor, currentScaleFactor);
		if (currentlyMouseOver) {
			if (currentScaleFactor < scaleFactor) {
				currentScaleFactor += speedOfGrowth;
			}
		} else {
			if (currentScaleFactor > 1) {
				currentScaleFactor -= speedOfGrowth;
			}
		}
	}

	void UpdateCardInformation() {
		nameText.text = _name;
		descriptionText.text = _description;
		manaCostText.text = _manaCost.ToString();
		Debug.Log (nameText.text);
	}

	public void OnPointerEnter(PointerEventData eventData) {
		currentlyMouseOver = true;
	}

	public void OnPointerExit(PointerEventData eventData) {
		currentlyMouseOver = false;
	}
}
