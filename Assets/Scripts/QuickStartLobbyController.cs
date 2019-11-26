using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    // Button to  create and join a game
    [SerializeField]
    private GameObject quickStartButton;
    // Button to stop searching for a game to join
    [SerializeField]
    private GameObject quickCancelButton;
    // Set the number of players in the room at one time
    [SerializeField]
    private int roomSize;

    // In case of successfull connection
    public override void OnConnectedToMaster()
    {
        // Load the same scene (For all clients) as master client has loaded 
        PhotonNetwork.AutomaticallySyncScene = true;
        // Make Quick Start Button active 
        quickStartButton.SetActive(true);
    }

    // Handle the Quick Start Button functionality
    public void QuickStart()
    {
        // When pressed disable start button and enable cancel button
        quickStartButton.SetActive(false);
        quickCancelButton.SetActive(true);
        // Try to join an existing room
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Quick Start");
    }

    // In case of failing to join a room
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join a room");
    }
}
