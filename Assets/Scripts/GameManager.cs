using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.unityLogger.Log("GameManager is null!");
            }

            return _instance;
        }
    }

    public enum GameState
    {
        Setup,
        Go,
        Reset,
        Pause,
    }

    public List<PlaceableItem> placeableItems = new List<PlaceableItem>();
    public GameState gameState = GameState.Setup;

    void Awake()
    {
        _instance = this;
    }

    public UnityEvent OnSetup;
    public UnityEvent OnGo;
    
    void Start()
    {
        placeableItems.AddRange(FindObjectsOfType<PlaceableItem>());
        Debug.Log($"Found {placeableItems.Count} placeable items.");
        SetState(GameState.Setup);
    }

    public void SetState(GameState newState)
    {
        gameState = newState;

        foreach (var placeableItem in placeableItems)
        {
            if (newState == GameState.Setup)
            {
                placeableItem.OnSetup();
            }
            else if (newState == GameState.Go)
            {
                placeableItem.OnActivate();
            }
        }
    }

    public void SetupState()
    {
        SetState(GameState.Setup);
    }

    public void GoState()
    {
        SetState(GameState.Go);
    }
}
