using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Character
{
    public override void CriticalAttack(Character target)
    {
        target.Attacked(attack * 3);
    }
}
