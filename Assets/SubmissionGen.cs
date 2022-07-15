using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SubmissionGen : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite[] artImages;
    public GameObject Grid;
    public GameObject cellPrefab;
    public GameController gameController;
    // Start is called before the first frame update
    void Awake()
    {
        InstantiateArtworkData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void OnPointerClick(PointerEventData eventData) // 3
     {}
      public void OnPointerEnter(PointerEventData eventData) // 3
     {}
      public void OnPointerExit(PointerEventData eventData) // 3
     {}
    public void InstantiateArtworkData(){
        /*for (int i=0; i<gameController.ArtSubmissions.Count(); i++){
            GameObject artworkSubmit = Instantiate(cellPrefab);
            artworkSubmit.transform.SetParent(Grid.transform);
            artworkSubmit.transform.GetChild(0).GetComponent<Image>().sprite = artImages[i];
        }
        */
    }
}
