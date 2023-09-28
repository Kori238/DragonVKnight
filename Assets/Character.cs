using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Character : MonoBehaviour
{
    public string displayName;
    public int health, maxHealth, attack, defense, victoryCount;
    public float dodgeChance, criticalChance;
    public bool alive;
    public TMP_Text victoryDisplayText;

    public void Victory()
    {
        victoryCount++;
        victoryDisplayText.text = victoryCount.ToString();
    }

    public void Attack(Character target)
    {
        if (criticalChance >= Random.value) CriticalAttack(target);
        else target.Attacked(attack);
    }

    public abstract void CriticalAttack(Character target);

    public void Attacked(int value, bool executed = false)
    {
        value -= defense;
        if (dodgeChance >= Random.value) Dodge();
        else if (executed)
        {
            Debug.Log($"{displayName} was executed");
            Death();
        }
        else if (health - value <= 0)
        {
            health = 0;
            Debug.Log($"{displayName} took {health} damage");
            Death();
        }
        else
        {
            health -= value;
            Debug.Log($"{displayName} took {value} damage");
        }
    }

    public void Dodge()
    {
        Debug.Log($"{displayName} has dodged");
    }
    public void Death()
    {
        Debug.Log($"{displayName} has been defeated");
        alive = false;
    }
}
