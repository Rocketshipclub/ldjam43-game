using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item {

    public int saleValue = 3;
    int foodRecovery = 20;
    public override void Use(Character user)
    {
        user.RecoverHunger(foodRecovery);
    }
}
