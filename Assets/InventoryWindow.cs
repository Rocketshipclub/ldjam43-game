using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryWindow : MonoBehaviour {

    public Canvas canvas;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI whiskeyText;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI goodsText;
    public TextMeshProUGUI perkText;
    public TextMeshProUGUI perkTextDesc;

    public Button breadButton;
    public Button whiskeyButton;

    public GameController gc;
    private Caravan caravan;

    private void Start()
    {
        breadButton.onClick.AddListener(() => gc.SelectItem(new Food()));
        breadButton.onClick.AddListener(() => CloseWindow());
        whiskeyButton.onClick.AddListener(() => gc.SelectItem(new Whiskey()));
        whiskeyButton.onClick.AddListener(() => CloseWindow());
        caravan = GameObject.Find("Caravan").GetComponent<Caravan>();
    }

    public void UpdateText()
    {
        canvas.enabled = true;
        foodText.text = string.Format("x{0}", caravan.NumberOfFood());
        whiskeyText.text = string.Format("x{0}", caravan.NumberOfWhiskey());
        goodsText.text = string.Format("x{0}", caravan.NumberOfGoods());

    }

    public void CloseWindow()
    {
        canvas.enabled = false;
    }
}
