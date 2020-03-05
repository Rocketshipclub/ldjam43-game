using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item {

    public int value;
    public abstract void Use(Character user);
}
