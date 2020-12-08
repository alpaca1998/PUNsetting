using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView PV;
    public GameObject myAvator;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoint.Length);
        if (PV.IsMine)
        {
           myAvator =  PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerAvator"), 
               GameSetup.GS.spawnPoint[spawnPicker].position, GameSetup.GS.spawnPoint[spawnPicker].rotation, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
