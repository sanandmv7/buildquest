using System.Collections;
using System.Collections.Generic;
using MoralisWeb3ApiSdk;
using Moralis.Platform.Objects;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public InputController inputController { get; private set; }
    [SerializeField] TextMesh playerWalletAddress;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        inputController = GetComponentInChildren<InputController>();
        SetPlayerAddress();
    }

    private async void SetPlayerAddress(){
        var user = await MoralisInterface.GetUserAsync();
        if (user != null)
        {
            string addr = user.authData["moralisEth"]["id"].ToString();
            playerWalletAddress.text = string.Format("{0}...{1}", addr.Substring(0, 6), addr.Substring(addr.Length - 3, 3));
            playerWalletAddress.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
