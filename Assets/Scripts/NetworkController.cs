using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    [SerializeField] private int gameVersion;
    
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.GameVersion = gameVersion.ToString();
        // Connects to Photon master servers
        PhotonNetwork.ConnectUsingSettings();
    }

    // In case of successfull connection
    public override void OnConnectedToMaster()
    {
        // Display with which region we established connection
        Debug.Log("We are now connected to the " + PhotonNetwork.CloudRegion + " server.");
    }
}
