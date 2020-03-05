using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupText : MonoBehaviour {

    public TextMeshProUGUI mainText;
    public Button confirmationButton;
    public TextMeshProUGUI confirmationButtonText;
    public Button option1;
    public TextMeshProUGUI option1Text;
    public Button option2;
    public TextMeshProUGUI option2Text;

    public GameController gc;

    public void ShowMessage(string message, string confirmation)
    {
        gc.Pause(true);
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        GetComponent<Canvas>().enabled = true;
        confirmationButton.gameObject.SetActive(true);
        confirmationButtonText.text = confirmation;
        mainText.text = message;
    }

    public void ShowMessageWithTwoOptions(string message, string option1, string option2)
    {
        gc.Pause(true);
        GetComponent<Canvas>().enabled = true;
        mainText.text = message;
        this.option1.gameObject.SetActive(true);
        this.option2.gameObject.SetActive(true);
        option1Text.text = option1;
        option2Text.text = option2;
    }

    public void CloseMessage()
    {
        if(gc.GetPopupTexts().Count > 1)
        {
            gc.Pause(false);
        }
        mainText.text = "";
        option1.gameObject.SetActive(false);
        option1Text.text = "";
        option2.gameObject.SetActive(false);
        option2Text.text = "";
        confirmationButton.gameObject.SetActive(false);
        confirmationButtonText.text = "";
        GetComponent<Canvas>().enabled = false;
        gc.RemovePopupWindows(this);
    }

    public void DestroyMessage()
    {
        Destroy(gameObject);
    }
}
