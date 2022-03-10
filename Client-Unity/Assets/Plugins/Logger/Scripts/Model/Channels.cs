using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum Channels : uint
{
    Animation=1<<0,
    Physics=1<<1
        //.. add channels you n need
    
}
