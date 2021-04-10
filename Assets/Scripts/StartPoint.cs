using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class StartPoint: MonoBehaviour
{
    public Transform startPoint;

    public GameObject[] multiplayer;
    public GameObject singleplayer;

    public GameObject gambiarraBox;

    //PlayerInputManager inputManager;

    //public PlayerInput Input;

    public bool isMultiplayer = true;
    void Awake()
    {
        //inputManager = GetComponent<PlayerInputManager>();

        //if (isMultiplayer)
        //{
        //    foreach (GameObject g in multiplayer)
        //    {
        //        Instantiate(g, startPoint);
        //    }

        //}
        //else
        //{
        //    Instantiate(singleplayer, startPoint);
        //}

        //Gambiarra activate

        if(PlayerPrefs.HasKey("Mode"))
        {
            isMultiplayer = bool.Parse(PlayerPrefs.GetString("Mode"));
        } 

        Instantiate(gambiarraBox, new Vector3(-70, 17, -15), Quaternion.identity);

        if (isMultiplayer)
        {

            var gamepadCount = Joystick.all.Count;
            if (gamepadCount >= 2)
            {
                var p1 = PlayerInput.Instantiate(multiplayer[0], controlScheme: "Gamepad", pairWithDevice: Joystick.all[0]);
                var p2 = PlayerInput.Instantiate(multiplayer[1], controlScheme: "Gamepad", pairWithDevice: Joystick.all[1]);
            }
            else if (gamepadCount == 1)
            {
                var p1 = PlayerInput.Instantiate(multiplayer[1], controlScheme: "Gamepad", pairWithDevice: Joystick.all[0]);
                var p2 = PlayerInput.Instantiate(multiplayer[0], controlScheme: "Keyboard", pairWithDevice: Keyboard.current);
            }
            else
            {
                var p1 = PlayerInput.Instantiate(multiplayer[0], controlScheme: "RightKeyboard", pairWithDevice: Keyboard.current);
                var p2 = PlayerInput.Instantiate(multiplayer[1], controlScheme: "LeftKeyboard", pairWithDevice: Keyboard.current);
            }

            multiplayer[0].transform.position = new Vector3 (startPoint.position.x+4, startPoint.position.y, startPoint.position.z);
            multiplayer[1].transform.position = new Vector3(startPoint.position.x-4, startPoint.position.y, startPoint.position.z);

        }
        else
        {
            //Gambiarra activate
            Instantiate(gambiarraBox, new Vector3(-70, 30, -15), Quaternion.identity);
            var gamepadCount = Joystick.all.Count;
            if (gamepadCount >= 1)
            {
                PlayerInput.Instantiate(singleplayer, controlScheme: "Gamepad", pairWithDevice: Joystick.all[0]);
            }
            else
            {
                PlayerInput.Instantiate(singleplayer, controlScheme: "Keyboard", pairWithDevice: Keyboard.current);
            }

            singleplayer.transform.position = startPoint.position;
        }
    }

    public void Reset()
    {
        singleplayer.transform.position = startPoint.position;
    }

    //void OnPlayerJoined(PlayerInput input)
    //{
    //    //if (multiplayer[0] == null)
    //    //{
    //    //    multiplayer[0] = input.gameObject;
    //    //    inputManager.playerPrefab = multiplayer[1];
    //    //}
    //    //else
    //    //{
    //    //    multiplayer[1] = input.gameObject;
    //    //}
    //    multiplayer[0] = input.gameObject;
    //    inputManager.playerPrefab = multiplayer[1];
    //}
}