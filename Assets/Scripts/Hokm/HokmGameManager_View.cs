using System;
using UnityEngine;


public class HokmGameManager_View : MonoBehaviour
{
    [SerializeField] private HokmGameManager_Logic logic;

    private void Start()
    {
        logic.InitUser();

        logic.DetermineTheRuler();

        logic.Distribute5Card();

        logic.Distribute4Card();

        logic.Distribute4Card();
    }

    private void Update()
    {
        if (logic.session.state == SessionController_Hokm.GameState.Ruling)
        {
            if (Input.GetKeyDown("1"))
            {
                logic.SetSymbol(1);
            }
            else if (Input.GetKeyDown("2"))
            {
                logic.SetSymbol(2);
            }
            else if (Input.GetKeyDown("3"))
            {
                logic.SetSymbol(3);
            }
            else if (Input.GetKeyDown("4"))
            {
                logic.SetSymbol(4);
            }
        }
        else if (logic.session.state == SessionController_Hokm.GameState.AllowedToDrop)
        {
            if (Input.GetKeyDown("1"))
            {
                logic.DropOnTheGround(1);
            }
            else if (Input.GetKeyDown("2"))
            {
                logic.DropOnTheGround(2);
            }
            else if (Input.GetKeyDown("3"))
            {
                logic.DropOnTheGround(2);
            }
            else if (Input.GetKeyDown("4"))
            {
                logic.DropOnTheGround(4);
            }
            else if (Input.GetKeyDown("5"))
            {
                logic.DropOnTheGround(5);
            }
            else if (Input.GetKeyDown("6"))
            {
                logic.DropOnTheGround(6);
            }
            else if (Input.GetKeyDown("7"))
            {
                logic.DropOnTheGround(7);
            }
            else if (Input.GetKeyDown("8"))
            {
                logic.DropOnTheGround(8);
            }
            else if (Input.GetKeyDown("9"))
            {
                logic.DropOnTheGround(9);
            }
            else if (Input.GetKeyDown("0"))
            {
                logic.DropOnTheGround(10);
            }
            else if (Input.GetKeyDown("-"))
            {
                logic.DropOnTheGround(11);
            }
            else if (Input.GetKeyDown("="))
            {
                logic.DropOnTheGround(12);
            }
            else if (Input.GetKeyDown("`"))
            {
                logic.DropOnTheGround(0);
            }
        }
    }
}
