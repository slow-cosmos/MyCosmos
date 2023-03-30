using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    PLAY,
    PAUSE
};

public class GameManage : MonoBehaviour
{
    public static GameManage Instance;
    public GameState gameState;

    void Awake()
    {
        GameManage.Instance = this;
        gameState = GameState.PLAY;
    }

    public void EditState(GameState state)
    {
        gameState = state;
    }
}
