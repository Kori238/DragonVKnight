using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Character
{
    public override void CriticalAttack(Character target)
    {
        target.Attacked(0, true);
    }
}
