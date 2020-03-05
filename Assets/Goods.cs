using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goods : Item {

    public new int value = 5;
    public override void Use(Character user)
    {
        Debug.Log("Can't use this item!");
    }
}
