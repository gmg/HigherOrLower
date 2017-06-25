using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HigherOrLower : MonoBehaviour {

	// Use this for initialization
	public Text TitleText;
	public Text SubtitleText;
	public Text CurrentNumberText;
	public Button HigherButton;
	public Button LowerButton;
	
	int currentNumber;
	int nextNumber;

	void Start () {
		nextNumber = Random.Range(1,10);
		NewNumber();
	}

	public void GuessHigher() {
		if (nextNumber > currentNumber) {
			NewNumber();
		} else {
			CurrentNumberText.text = ":(";
			StartCoroutine(GameOver());
		}
	}

	public void GuessLower() {
		if (nextNumber < currentNumber) {
			NewNumber();
		} else {
			CurrentNumberText.text = ":(";
			StartCoroutine(GameOver());			
		}
	}

	void NewNumber () {
		currentNumber = nextNumber;
		do {
			nextNumber = Random.Range(1,10);
		} while (currentNumber == nextNumber);
		CurrentNumberText.text = currentNumber.ToString();
	}

	IEnumerator GameOver(){
		HigherButton.enabled = false;
		LowerButton.enabled = false;
		TitleText.text = "WRONG!";
		SubtitleText.text = "The next number was "+nextNumber.ToString();
		yield return new WaitForSeconds(3);
		HigherButton.enabled = true;
		LowerButton.enabled = true;
		TitleText.text = "Higher or Lower";
		SubtitleText.text = "Can you guess the next number?";
		NewNumber();
	}
}
