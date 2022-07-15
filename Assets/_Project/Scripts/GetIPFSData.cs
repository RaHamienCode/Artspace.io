using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetIPFSData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Code to retrieve IPFS data from Cid
    public IEnumerator getIPFS (string IPFSCid)
    {
        UnityWebRequest _www = UnityWebRequest.Get(IPFSCid);
        Debug.Log("Trying to pull data from:" + IPFSCid);
        yield return _www.SendWebRequest();
        if (_www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log ("Raw data recieved: "+ _www.downloadHandler.text);
            //processIPFSData(_www);
        } else {
            Debug.Log(_www.error);
        }
        
    }
    private void processIPFSData(string IPFSRawData)
    {
        Debug.Log (IPFSRawData);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
