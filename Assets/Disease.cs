using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disease {

    public int effectOnHealth;
    // Just means if disease can end by itself
    public bool isLethal;
    public int turnsToLast;
    public string diseaseName;

    public void ReduceTurns()
    {
        turnsToLast--;
    }
    
}
