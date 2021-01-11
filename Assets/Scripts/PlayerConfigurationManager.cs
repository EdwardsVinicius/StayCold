using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfig;

    [SerializeField]
    private int MaxPlayers = 2;
    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("SINGLETON - ");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfig = new List<PlayerConfiguration>();
        }
    }

    public void ReadyPlayer(int index)
    {
        playerConfig[index].IsReady = true;
        if(playerConfig.Count == MaxPlayers && playerConfig.All(p => p.IsReady == true))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void HandlePlayerJoin(PlayerInput playerInput)
    {
        Debug.Log("Player Joined " + playerInput.playerIndex);
        if (!playerConfig.Any(p => p.PlayerIndex == playerInput.playerIndex))
        {
            playerInput.transform.SetParent(transform);
            playerConfig.Add(new PlayerConfiguration(playerInput));
        }
    }
}

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput playerInput)
    {
        PlayerIndex = playerInput.playerIndex;
        Input = playerInput;
    }
    public PlayerInput Input { get; set; }
    public int PlayerIndex { get; set; }
    public bool IsReady { get; set; }
}
