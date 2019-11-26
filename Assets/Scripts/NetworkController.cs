using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
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
