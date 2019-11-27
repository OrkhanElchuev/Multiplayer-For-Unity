using Photon.Pun;
using System.IO;
using UnityEngine;

// This script will be added to any multiplayer scene
public class GameSetupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Create a player object with a network for each player
        // who load into the multiplayer scene
        CreatePlayer();
    }

    // Handle player creation process
    private void CreatePlayer()
    {
        Debug.Log("Creating a player");
        // Passing string location to the prefab that needs to be instantiated
        // Position and rotation are defined for instantiation
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"),
        Vector3.zero, Quaternion.identity);
    }
}
