using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Event {

    public string description;
    public string selectionOneText;
    public string selectionTwoText;
    public int selection;
    public PopupText popupText;

    public GameController gc;

    public Event()
    {
        gc = GameObject.Find("Main Camera").GetComponent<GameController>();
    }

    public void Setup(PopupText p)
    {
        popupText = p;
        popupText.ShowMessageWithTwoOptions(description, selectionOneText, selectionTwoText);
        LoadGraphics();
    }

    public abstract void LoadGraphics();

    public void Select(int value)
    {
        selection = value;
        Trigger();
    }

    public abstract void Trigger();
}
