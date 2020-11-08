using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{

    private static int currentShip = 0;
    public SpriteRenderer spriteRenderer;
    public Sprite ship0;
    public Sprite ship1;
    public Sprite ship2;

    private void Start()
    {
        if (currentShip == 0)
        {
            spriteRenderer.sprite = ship0;
        }
        else if (currentShip == 1)
        {
            spriteRenderer.sprite = ship1;
        }
        else if (currentShip == 2)
        {
            spriteRenderer.sprite = ship2;
        }
    }


    public int GetCurrentShip()
    {
        return currentShip;
    }

    public void SetCurrentShip(int currentShip)
    {
        ShipManager.currentShip = currentShip;
    }


}
