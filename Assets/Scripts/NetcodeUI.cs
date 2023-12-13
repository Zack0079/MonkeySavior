using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetcodeUI : MonoBehaviour
{
    [SerializeField] private Button startHost;
   [SerializeField] private Button startClient;

    private void Awake(){

        startHost.onClick.AddListener(()=>{
            Debug.Log("HOST");
            NetworkManager.Singleton.StartServer();
            Hide();
        });
        startClient.onClick.AddListener(()=>{
            Debug.Log("CLIENT");
            NetworkManager.Singleton.StartClient();
            Hide();
        });
    }

    void Hide(){
        gameObject.SetActive(false);
    }
}
