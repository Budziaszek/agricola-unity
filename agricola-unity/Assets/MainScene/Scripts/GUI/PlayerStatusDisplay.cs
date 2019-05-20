﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerStatusDisplay : EventTrigger
{
    GameController gameController;
    static int id_c = 3;
    int id;

    void Start()
    {
        id = id_c;
        id_c--;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    override public void OnPointerExit(PointerEventData data)
    {
        gameController.players[gameController.activePlayer].ActualizeHealthBar();
        gameController.players[gameController.activePlayer].ActualizeHungerBar();
        gameController.players[gameController.activePlayer].ActualizeIcon();
        gameController.players[gameController.activePlayer].ActualizeAgeBar();
    }

    override public void OnPointerEnter(PointerEventData data)
    {
        gameController.players[id].ActualizeHealthBar();
        gameController.players[id].ActualizeHungerBar();
        gameController.players[id].ActualizeIcon();
        gameController.players[id].ActualizeAgeBar();
    }

}
