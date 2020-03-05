using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private List<Disease> diseases = new List<Disease>();

    public Camera _camera;

    private Environment environment;
    private Caravan caravan;
    private Event currentEvent;
    private List<Event> events = new List<Event>();
    private List<Perk> allPerks = new List<Perk>();

    private Movement movement;

    private int cooldown = 5;

    private int currentTurn = 0;
    private int chanceForDisease = 5;
    private int chanceForFlu = 70;
    private int chanceForDiarrhea = 30;
    private int chanceForPneumonia = 5;
    private bool gameOver = false;

    private bool isPaused = false;

    private List<PopupText> popupWindows = new List<PopupText>();

    private Item itemSelected = null;

    public PopupText popup;

    private void Start()
    {
        caravan = GameObject.Find("Caravan").GetComponent<Caravan>();
        movement = GameObject.Find("Caravan").GetComponent<Movement>();
        events.Add(new WolfAttack());
        events.Add(new ExtraSupplies());
        events.Add(new BanditAttack());
        events.Add(new NewJoiner());
        allPerks.Add(new ColdResistance(-1));
        allPerks.Add(new ColdResistance(1));
        allPerks.Add(new Grittiness(-1));
        allPerks.Add(new Grittiness(1));
        allPerks.Add(new Metabolism(-1));
        allPerks.Add(new Metabolism(1));
        allPerks.Add(new Alcoholic(1));
        allPerks.Add(new Alcoholic(-1));

        environment = new Environment();

    }

    public void SelectItem(Item item)
    {
        if(item is Food)
        {
            if(caravan.NumberOfFood() > 0)
            {
                itemSelected = item;
            }
        }

        else if(item is Whiskey)
        {
            if(caravan.NumberOfWhiskey() > 0)
            {
                itemSelected = item;
            }
        }
    }

    public void CheckForEvent()
    {
        if(currentTurn > 5 && CalculateEventChance() && cooldown == 0)
        {
            isPaused = true;
            var pop = Instantiate(popup, transform.position, Quaternion.identity);
            pop.gc = this;
            pop.option1.onClick.AddListener(() => HandleEvent(0));
            pop.option2.onClick.AddListener(() => HandleEvent(1));
            pop.confirmationButton.onClick.AddListener(() => DestroyPopup(pop));
            AddPopupWindows(pop);
            currentEvent = events[Random.Range(0, events.Count)];
            currentEvent.Setup(pop);
            cooldown = 5;
        }
    }

    public void HandleEvent(int i)
    {
        currentEvent.Select(i); 
    }

    public void EndEvent()
    {
        currentEvent = null;
    }

    public Disease CheckForDiseases()
    {
        var value = Random.Range(0, 100);
        if (value <= chanceForDisease)
        {
            int pickDisease = Random.Range(0, 100);
            if (pickDisease < chanceForPneumonia)
            {
                return new Pneumonia();
            }

            else if (pickDisease < chanceForDiarrhea)
            {
                return new Diarrhea();
            }

            else if (pickDisease < chanceForFlu)
            {
                return new Flu();
            }

            return null;
        }

        return null;
    }

    private bool CalculateEventChance()
    {
        var chance = Random.Range(0, 100);
        if (chance > 85)
        {
            return true;
        }

        return false;
    }

    public void InstantiatePopup(string m1, string m2)
    {
        var pop = Instantiate(popup, transform.position, Quaternion.identity);
        pop.gc = this;
        pop.confirmationButton.onClick.AddListener(() => DestroyPopup(pop));
        pop.ShowMessage(m1, m2);
        AddPopupWindows(pop);
    }

    public void InstantiateGameOverPopup(string m1, string m2)
    {
        var pop = Instantiate(popup, transform.position, Quaternion.identity);
        pop.gc = this;
        pop.confirmationButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        pop.ShowMessage(m1, m2);
        AddPopupWindows(pop);
    }

    public void DestroyPopup(PopupText pop)
    {
        Pause();
        RemovePopupWindows(pop);
        Destroy(pop.gameObject);
    }

    public Perk GetRandomPerk()
    {
        float rand = Random.Range(0.0f, 1.0f);
        if (rand <= 0.20f)
        {
            int random = Random.Range(-1, 2);
            if (random != 0)
            {
                return new ColdResistance(random);
            }
        }

        else if (rand <= 0.40f)
        {
            int random = Random.Range(-1, 2);
            if (random != 0)
            {
                return new Metabolism(random);
            }
        }

        else if (rand <= 0.60f)
        {
            int random = Random.Range(-1, 2);
            if (random != 0)
            {
                return new Alcoholic(random);
            }
        }

        else if (rand <= 0.80f)
        {
            int random = Random.Range(-1, 2);
            if (random != 0)
            {
                return new Grittiness(random);
            }
        }

        else
        {
            return null;
        }

        return null;
    }

    public void AddPopupWindows(PopupText pop)
    {
        popupWindows.Add(pop);
    }

    public void RemovePopupWindows(PopupText pop)
    {
        popupWindows.Remove(pop);
    }

    public Caravan GetCaravan()
    {
        return caravan;
    }

    public int GetCurrentTurn()
    {
        return currentTurn;
    }

    public void IncreaseCurrentTurn()
    {
        currentTurn++;
    }

    public int GetCooldown()
    {
        return cooldown;
    }

    public void ReduceCooldown()
    {
        cooldown--;
    }

    public bool GameOver()
    {
        return gameOver;
    }

    public void SetGameOver()
    {
        gameOver = true;
    }

    public Environment GetEnvironment()
    {
        return environment;
    }

    public Item GetItemSelected()
    {
        return itemSelected;
    }

    public void RemoveSelectedItem()
    {
        itemSelected = null;
    }

    public void Pause()
    {
        isPaused = !isPaused;
        movement.PauseMovement(isPaused);
    }

    public void Pause(bool status)
    {
        isPaused = status;
        movement.PauseMovement(isPaused);
    }

    public bool IsPaused()
    {
        return isPaused;
    }

    public List<PopupText> GetPopupTexts()
    {
        return popupWindows;
    }
}
