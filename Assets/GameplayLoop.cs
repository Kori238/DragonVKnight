using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GameplayLoop : MonoBehaviour
{
    [SerializeField] private Dragon dragon;
    [SerializeField] private Knight knight;

    [SerializeField] private int turnDelayMS;
    [SerializeField] private Slider slider;

    public void OnSliderChanged()
    {
        turnDelayMS = (int)slider.value;
    }

    public async void Simulate()
    {
        knight.alive = true;
        dragon.alive = true;
        knight.health = knight.maxHealth;
        dragon.health = dragon.maxHealth;
        await TurnLoop();
    }

    private async Task TurnLoop()
    {
        while (true)
        {
            if (0.5 >= Random.value)
            {
                knight.Attack(dragon);
                if (!dragon.alive)
                {
                    knight.Victory();
                    return;
                }
                await Task.Delay(turnDelayMS);
                dragon.Attack(knight);
                if (!knight.alive)
                {
                    dragon.Victory();
                    return;
                }
                await Task.Delay(turnDelayMS);
            }
            else
            {
                dragon.Attack(knight);
                if (!knight.alive)
                {
                    dragon.Victory();
                    return;
                }
                await Task.Delay(turnDelayMS);
                knight.Attack(dragon);
                if (!dragon.alive)
                {
                    knight.Victory();
                    return;
                }
                await Task.Delay(turnDelayMS);
            }
        }
    }
}
