using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour{

    private int health;
    private int maxHealth;
    private int hunger;
    private int maxHunger;
    private int warmth;
    private int maxWarmth;

    private string characterName;

    private int max = 130;
    private int min = 30;
    
    private Disease illness;
    private Perk perk;
    private bool isAlive = true;
    public GameController gc;
    private Caravan caravan;
    
    private int normalHungerIncrease = 2;
    private int healthDecreaseIfStatIsZero = 15;

    public CharacterUI ui;

    private void Start()
    {
        maxHealth = Random.Range(min, max);
        maxHunger = Random.Range(min, max);
        maxWarmth = Random.Range(min, max);
        health = maxHealth;
        hunger = maxHunger;
        warmth = maxWarmth;
        gc = GameObject.Find("Main Camera").GetComponent<GameController>();
        caravan = GameObject.Find("Caravan").GetComponent<Caravan>();
        characterName = CharacterNames.names[Random.Range(0, CharacterNames.names.Length)];
        ui = GameObject.Find("CharacterUI").GetComponentInChildren<CharacterUI>();
        var p = gc.GetRandomPerk();
        if(p != null)
        {
            perk = p;
        }
        isAlive = true; 
    }

    public void CheckStatus(bool resting)
    {
        if (isAlive)
        {
            RegenerateHealth();
            CalculateHunger();
            CalculateWarmth();
            CalculateIllnesses();
            if(health < 0)
            {
                health = 0;
            }
        }
    }

    public Character CheckIfDead()
    {
        if (health <= 0)
        {
            return this;
        }

        return null;
    }

    private void CalculateHunger()
    {
        hunger -= normalHungerIncrease;
        if (perk is Metabolism)
        {
            perk.Effect(ref hunger);
        }
        if (hunger <= 0)
        {
            hunger = 0;
            if(health > 0)
            {
                health -= healthDecreaseIfStatIsZero;
            }
        }
    }

    private void CalculateWarmth()
    {
        int reduction = gc.GetEnvironment().GetWeatherEffectOnWarmth();
        warmth -= reduction;

        if (perk is ColdResistance)
        {
            //perk.Effect(ref warmth, this);
            if(perk.value == 1)
            {
                warmth += perk.positiveEffect;
            }
            else if(perk.value == -1)
            {
                warmth += perk.negativeEffect;
            }
        }

        if (warmth > maxWarmth)
        {
            warmth = maxWarmth;
        }

        if (warmth <= 0)
        {
            warmth = 0;
            if(health > 0)
            {
                health -= healthDecreaseIfStatIsZero;
            }
        }
    }

    private void CalculateIllnesses()
    {
        if(illness != null)
        {
            health -= illness.effectOnHealth;
            illness.ReduceTurns();
            if (illness.turnsToLast == 0)
            {
                illness = null;
            }
        }
    }

    private void RegenerateHealth()
    {
        if(illness == null && health > 0 && health < maxHealth)
        {
            health += 1;
        }
    }

    public void Kill(string cause = "nothing")
    {
        isAlive = false;
        var reason = "";
        if(cause == "wolves")
        {
            reason = "been killed by wolves";
        }
        else if(cause == "bandits")
        {
            reason = "been killed by bandits";
        }
        else if(warmth <= 0)
        {
            reason = "frozen to death";
        }
        else if(hunger <= 0)
        {
            reason = "died of hunger";
        }
        else if (illness != null)
        {
            reason = string.Format("died of {0}", illness.diseaseName);
        }
        else
        {
            reason = "died";
        }
        var msg1 = string.Format("{0} has {1}", characterName, reason);
        var msg2 = "Rest in peace";
        gc.InstantiatePopup(msg1, msg2);
        caravan.AddNewAvailablePosition(transform.position);
        caravan.RemoveCaravanMember(this);
        Destroy(gameObject);
    }

    public void RecoverWarmth(int value)
    {
        // Very bad way don't do this
        if (perk is Alcoholic)
        {
            if (perk.value == 1)
                hunger += perk.positiveEffect;
            else if (perk.value == -1)
                health += perk.negativeEffect;
        }
        warmth += value;
        if (warmth > maxWarmth)
        {
            warmth = maxWarmth;
        }
    }

    public void RecoverHunger(int value)
    {
        if (perk is Grittiness)
        {
            //perk.Effect(ref health);
            if(perk.value == 1)
            {
                hunger += perk.positiveEffect;
            }
            else if(perk.value == -1)
            {
                hunger += perk.negativeEffect;
            }
        }

        hunger += value;

        if (hunger > maxHunger)
        {
            hunger = maxHunger;
        }
    }

    public void OnMouseDown()
    {
        if(gc.GetItemSelected() == null)
        {
            ui.Select(this);
        }

        else
        {
            gc.GetItemSelected().Use(this);
            Debug.Log("Used item");
            gc.RemoveSelectedItem();
        }
    }

    public string GetName()
    {
        return characterName;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Heal(int heal)
    {
        health += heal;
    }

    public Disease GetIllness()
    {
        return illness;
    }

    public void SetIllness(Disease illness)
    {
        this.illness = illness;
    }

    public int GetWarmth()
    {
        return warmth;
    }

    public int GetMaxWarmth()
    {
        return maxWarmth;
    }

    public void ReduceWarmth(int warmth)
    {
        this.warmth -= warmth;
    }

    public void IncreaseWarmth(int warmth)
    {
        this.warmth += warmth;
    }

    public int GetHunger()
    {
        return hunger;
    }

    public int GetMaxHunger()
    {
        return maxHunger;
    }

    public void ReduceHunger(int hunger)
    {
        this.hunger -= hunger;
    }

    public void IncreaseHunger(int hunger)
    {
        this.hunger += hunger;
    }

    public Perk GetPerk()
    {
        return perk;
    }
}
