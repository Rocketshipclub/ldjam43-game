using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour {

    public Canvas canvas;
    public Slider healthSlider;
    public Slider hungerSlider;
    public Slider warmthSlider;

    public Character character;
    public Caravan caravan;

    public TextMeshProUGUI perkText;
    public TextMeshProUGUI perkTextDesc;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI warmthText;

    public TextMeshProUGUI characterName;

    public TextMeshProUGUI daysCompletedText;

    public void Setup()
    {
        healthSlider.gameObject.SetActive(true);
        hungerSlider.gameObject.SetActive(true);
        warmthSlider.gameObject.SetActive(true);

        perkText.gameObject.SetActive(true);
        perkTextDesc.gameObject.SetActive(true);

        healthText.gameObject.SetActive(true);
        hungerText.gameObject.SetActive(true);
        warmthText.gameObject.SetActive(true);

        daysCompletedText.text = "Days survived: " + caravan.gc.GetCurrentTurn().ToString();

        canvas.enabled = true;
        healthText.text = string.Format("{0}/{1}", character.GetHealth(), character.GetMaxHealth());
        healthSlider.maxValue = character.GetMaxHealth();
        healthSlider.minValue = 0;

        hungerText.text = string.Format("{0}/{1}", character.GetHunger(), character.GetMaxHunger());
        hungerSlider.maxValue = character.GetMaxHunger();
        hungerSlider.minValue = 0;

        warmthText.text = string.Format("{0}/{1}", character.GetWarmth(), character.GetMaxWarmth());
        warmthSlider.maxValue = character.GetMaxWarmth();
        warmthSlider.minValue = 0;

        characterName.text = character.GetName();

        if (character.GetPerk() != null && character.GetPerk().IsPositive())
        {
            perkText.text = character.GetPerk().positive;
            perkTextDesc.text = character.GetPerk().descriptionPositive;
        }
        else if (character.GetPerk() != null && !character.GetPerk().IsPositive())
        {
            perkText.text = character.GetPerk().negative;
            perkTextDesc.text = character.GetPerk().descriptionNegative;
        }
        else if (character.GetPerk() == null)
        {
            perkText.text = "No perk";
            perkTextDesc.text = "";
        }
    }
    private void Update()
    {
        daysCompletedText.text = "Days survived: " + caravan.gc.GetCurrentTurn().ToString();
        if (character != null)
        {
            healthSlider.value = character.GetHealth();
            hungerSlider.value = character.GetHunger();
            warmthSlider.value = character.GetWarmth();
            healthText.text = string.Format("{0}/{1}", character.GetHealth(), character.GetMaxHealth());
            hungerText.text = string.Format("{0}/{1}", character.GetHunger(), character.GetMaxHunger());
            warmthText.text = string.Format("{0}/{1}", character.GetWarmth(), character.GetMaxWarmth());
        }
        
    }

    public void Select(Character character)
    {
        this.character = character;
        Setup();
    }
    public void Deselect()
    {
        canvas.enabled = false;
        character = null;
    }
}
