using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArtSelectionBoxScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    SpriteRenderer sprite;
     public Color target;
     //public List<GameObject> Selectables;
     public GameObject[] Selectabless;
     public bool isSelected;
     public bool isChoiceBox; 
     public int choiceBox;
     ArtSelectionBoxScript thisScript;
     Outline highlight;
     
     void Awake()
     {
        thisScript = this.gameObject.GetComponent<ArtSelectionBoxScript>();
        sprite = GetComponent<SpriteRenderer>();
        //Selectables.AddRange(GameObject.FindGameObjectsWithTag("Selectable"));
        
        highlight = this.gameObject.GetComponent<Outline>();
        //isSelected = !isSelected;

         
     }
 
     void Update()
     {
         Selectabless = GameObject.FindGameObjectsWithTag("Selectable");

     }
    
     public void OnPointerClick(PointerEventData eventData) // 3
     {
         //print("I was clicked");
        
        
        if (thisScript.isSelected == false){
            this.isSelected = true;
            if (thisScript.isChoiceBox){
                UnselectOtherChoiceBoxes();
            } else {
                UnselectOtherSelectionBoxes();
            }
            highlight.effectColor = new Color (target.r, target.g, target.b, .8f);
        } 
         //this.GameObject.setActive(false);
     }
     public void SetVoteChoice (int choiceBNum)
     {

     }
     public void UnselectOtherChoiceBoxes (){
        /*for (int i=0; i < Selectables.Count; i++){
            if (Selectables[i] == this.gameObject){
                Selectables[i].gameObject.GetComponent<ArtSelectionBoxScript>.isSelected = false;
                //Selectables[i].GetComponent<ArtSelectionBoxScript>.highlight.effectColor = new Color (target.r, target.g, target.b, .0f);
            }
            */
            for (int i=0; i < Selectabless.Length; i++){
                ArtSelectionBoxScript getSelectionScript = Selectabless[i].GetComponent<ArtSelectionBoxScript>();
                if (Selectabless[i] != this.gameObject){
                    if (getSelectionScript.isChoiceBox){
                       print("Unselected a Choice Box");
                        getSelectionScript.isSelected = false;
                        getSelectionScript.highlight.effectColor = new Color (target.r, target.g, target.b, .0f);
                    }
                }
        } 
     } 
     public void UnselectOtherSelectionBoxes() {
        int count = 0;
        while (count < Selectabless.Length){
                ArtSelectionBoxScript getSelectionScript = Selectabless[count].GetComponent<ArtSelectionBoxScript>();
                if (Selectabless[count] != this.gameObject){
                    if (getSelectionScript.isChoiceBox == false && getSelectionScript.isSelected){
                        print("Unselected a Selection Box");
                        getSelectionScript.isSelected = false;
                        getSelectionScript.highlight.effectColor = new Color (target.r, target.g, target.b, .0f);
                    }
                }
                count++;
            //Will figure this out soon.
        } 
        print(count);
     }

 
     public void OnDrag(PointerEventData eventData)
     {
         print("I'm being dragged!");
         target = Color.magenta;
     }
 
     public void OnPointerEnter(PointerEventData eventData)
     {
        if (!isSelected){
            highlight.effectColor = new Color (target.r, target.g, target.b, .4f);
        }
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
        if (!isSelected){
            highlight.effectColor = new Color (target.r, target.g, target.b, 0f);
        }
     }
     private bool IsMouseOverSelectable(){
        //return EventSystem.current.IsPointerOverGameobject();
        return true;
    }
 }

