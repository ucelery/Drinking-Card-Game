using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardController : MonoBehaviour {
	public GameObject cardValueObj;
	public GameObject cardNoObj;

	private TextMeshProUGUI cardNoText;
	private TextMeshProUGUI cardValueText;
	private int cardIndex = 0;
	
	private void Start() {
		cardNoText = cardNoObj.GetComponent<TextMeshProUGUI>();
		cardValueText = cardValueObj.GetComponent<TextMeshProUGUI>();
		UpdateValues();
	}

	public void NextCard() {
		if (cardIndex >= CardManager.instance.cards.Count - 1) cardIndex = 0;
		else cardIndex++;

		UpdateValues();
	}

	public void PrevCard() {
		if (cardIndex <= 0) cardIndex = CardManager.instance.cards.Count - 1;
		else cardIndex--;

		UpdateValues();
	}

	private void UpdateValues() {
		cardNoText.text = $"{cardIndex + 1}/{CardManager.instance.cards.Count}";
		cardValueText.text = CardManager.instance.cards[cardIndex];
	}

	public void ShuffleNextCards() {
		List<string> cardsCopy = new List<string>(CardManager.instance.cards);
		List<string> firstNCards = GetFirstNCards(cardsCopy, cardIndex + 1);
		cardsCopy.RemoveRange(0, cardIndex + 1);

		string[] cardsArr = cardsCopy.ToArray();
		for (int i = 0; i < cardsArr.Length; i++) {
			int rnd = Random.Range(0, cardsArr.Length);
			string temp;
			temp = cardsArr[rnd];
			cardsArr[rnd] = cardsArr[i];
			cardsArr[i] = temp;
		}

		cardsCopy = new List<string>(cardsArr);
		firstNCards.AddRange(cardsCopy);
		CardManager.instance.cards = firstNCards;
	}

	private List<string> GetFirstNCards(List<string> list, int n) {
		return list.GetRange(0, n);
	}

	private void GenerateCardText(string cardData) {
		string newData = string.Empty;
		string[] newLines = cardData.Split("\n");
		foreach (string item in newLines) {

		}
	}
}
