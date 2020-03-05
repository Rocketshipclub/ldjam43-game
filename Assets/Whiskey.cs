using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whiskey : Item {

    public int saleValue = 5;
    int warmthRecovery = 25;
    public override void Use(Character user)
    {
        user.RecoverWarmth(warmthRecovery);
    }

}
