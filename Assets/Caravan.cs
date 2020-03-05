using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caravan : MonoBehaviour
{
    private List<Character> caravanMembers = new List<Character>();
    private List<Vector2> memberPositions = new List<Vector2>();
    public List<GameObject> characterPrefabs = new List<GameObject>();
    private Inventory inventory = new Inventory();
    public GameController gc;
    private int morale;
    private int funds;
    private bool resting = false;
    private Movement movement;

    void Start()
    {
        movement = GetComponent<Movement>();

        inventory.AddMultiple(new Food(), 15);
        inventory.AddMultiple(new Whiskey(), 15);
        inventory.AddMultiple(new Goods(), 5);
        InitializeCaravan();
    }

    public void ModifyCaravanRestStatus(bool status)
    {
        resting = status;
    }

    public Inventory OpenInventory()
    {
        return inventory;
    }

    public List<Character> GetCaravanMembers()
    {
        return caravanMembers;
    }

    public void RemoveCaravanMember(Character character)
    {
        caravanMembers.Remove(character);
    }

    public void AddCaravanMember()
    {
        var pos = memberPositions[0];
        var _character = Instantiate(characterPrefabs[Random.Range(0, characterPrefabs.Count)], pos, Quaternion.identity);
        caravanMembers.Add(_character.GetComponent<Character>());
        memberPositions.RemoveAt(0);
    }

    public void InitializeCaravan()
    {
        var initialCharacters = FindObjectsOfType<Character>();
        foreach(Character c in initialCharacters)
        {
            Debug.Log("New member added to caravan");
            caravanMembers.Add(c);
        }
        
    }

    public void AddNewAvailablePosition(Vector2 pos)
    {
        memberPositions.Add(pos);
    }

    public void ProcessTurn(bool turn)
    {
        if (!gc.IsPaused())
        {
            List<Character> deadCharacters = new List<Character>();
            gc.CheckForEvent();
            foreach (Character character in caravanMembers)
            {
                var dead = character.CheckIfDead();
                if (dead != null)
                {
                    deadCharacters.Add(dead);
                }
                else
                {
                    character.CheckStatus(turn);
                    //Debug.Log(string.Format("{0} has {1} health, {2} hunger and {3} warmth", character.characterName, character.health, character.hunger, character.warmth));
                    Disease disease = gc.CheckForDiseases();
                    if (disease != null && character.GetIllness() == null)
                    {
                        character.SetIllness(disease);
                        gc.InstantiatePopup(string.Format("{0} is suffering from {1}", character.GetName(), disease.diseaseName), "Worrying");
                    }
                }
            }
            foreach(var dead in deadCharacters)
            {
                caravanMembers.Remove(dead);
                dead.Kill();
            }

            if (gc.GetCooldown() > 0)
                gc.ReduceCooldown();

            gc.IncreaseCurrentTurn();
        }
    }

    private void Update()
    {
        if(caravanMembers.Count == 0 && !gc.GameOver())
        {
            Debug.Log("Game over!");
            gc.SetGameOver();
            gc.InstantiateGameOverPopup("Game over!", "New caravan");
        }
    }

    private void OnMouseDown()
    {
        if(!gc.IsPaused())
        {
            var inventory = GameObject.Find("Bag").GetComponent<InventoryWindow>();
            inventory.UpdateText();
        }
    }

    public int NumberOfFood()
    {
        return inventory.GetNumberOfStored(new Food());
    }

    public int NumberOfWhiskey()
    {
        return inventory.GetNumberOfStored(new Whiskey());
    }

    public int NumberOfGoods()
    {
        return inventory.GetNumberOfStored(new Goods());
    }

    public void RemoveFood()
    {
        inventory.RemoveItem(new Food());
    }

    public void RemoveWhiskey()
    {
        inventory.RemoveItem(new Whiskey());
    }
}