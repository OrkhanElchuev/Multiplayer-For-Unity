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

    // Handle the Quick Cancel Button functionality
    public void QuickCancel()
    {
        // When pressed disable cancel button and enable start button
        quickCancelButton.SetActive(false);
        quickStartButton.SetActive(true);
        // Leave the room
        PhotonNetwork.LeaveRoom();
    }

    // In case of failing to join a room
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join a room");
    }

    // Try to create own room
    void CreateRoom()
    {
        Debug.Log("Creating room");
        // Random number for a room name
        int randomRoomNumber = Random.Range(0, 10000);
        // Setting room configurations
        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = (byte)roomSize
        };
        // Attempt to create a new room
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOptions);
        Debug.Log(randomRoomNumber);
    }

    // In case of failing to create a new room 
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create a room, try again");
        // Try creating room again with a different random number because
        // Fail might occur if the room with generated number already exists
        CreateRoom();
    }
}
