using Photon.Pun;
using UnityEngine;

public class QuickStartRoomController : MonoBehaviourPunCallbacks
{
    // Number for the build index to the multiplay scene
    [SerializeField] private int multiplayerSceneIndex;

    // Adding callback targer    
    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    // Removing callback target
    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    // In case of successfully joining or creating a room
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        StartGame();
    }

    // Function for loading into the multiplayer scene
    private void StartGame()
    {
        // Check if we are master client
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Starting Game");
            // Due to AutoSyncScene all players who join the room will also
            // be loaded into the multiplayer scene
            PhotonNetwork.LoadLevel(multiplayerSceneIndex);
        }
    }
}
