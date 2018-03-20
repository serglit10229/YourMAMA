using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonNetworkManager : Photon.PunBehaviour {

    [SerializeField] private Text connectText;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject lobbyCamera;


    // Use this for initialization
    private void Start ()
    {
        PhotonNetwork.ConnectUsingSettings("0.1"); //Set game version
	}

    public virtual void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("New", null, null); //Join create room if doesn't exists
    }

    public virtual void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(player.name, spawnPoint.position, spawnPoint.rotation, 0);
        lobbyCamera.SetActive(false);
    }

    // Update is called once per frame
    private void Update ()
    {
        connectText.text = PhotonNetwork.connectionStateDetailed.ToString();
	}
}
