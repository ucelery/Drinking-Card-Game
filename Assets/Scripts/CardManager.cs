using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardManager : MonoBehaviour {
    public static CardManager instance = null;

    public List<string> cards = new List<string>();

    [Header("Game Objects")]
    public GameObject cardTextValue;
    public GameObject totalCardLabel;

    private TMP_InputField inputText;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
		if (instance == null) instance = this;
		else if (instance == this) Destroy(gameObject);

        inputText = cardTextValue.GetComponent<TMP_InputField>();
    }

	public void AddCard() {
        string data = inputText.text;
        string[] cardsValue = data.Split(";");

		foreach (string item in cardsValue) {
            cards.Add(item.Replace("\\n", "\n"));
        }
        
        UpdateFields();
    }

    public void ImportCards() {
        // no function yet, could'nt find a way to open text file from android file explorer
    }

    private void UpdateFields() {
        // Refresh Input Field
        inputText.text = string.Empty;

        TextMeshProUGUI totalText = totalCardLabel.GetComponent<TextMeshProUGUI>();
        totalText.text = $"{cards.Count} cards loaded";
    }

    public void Shuffle() {
        string[] cardsArr = cards.ToArray();
        for (int i = 0; i < cardsArr.Length; i++) {
            int rnd = Random.Range(0, cardsArr.Length);
            string temp;
            temp = cardsArr[rnd];
            cardsArr[rnd] = cardsArr[i];
            cardsArr[i] = temp;
        }

        cards = new List<string>(cardsArr);
    }
}
