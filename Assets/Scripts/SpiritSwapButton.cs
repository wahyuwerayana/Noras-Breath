using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class SpiritSwapButton : MonoBehaviour
{
    public int ID;
    private Animator anim;
    public string itemName;
    public TextMeshProUGUI itemText;
    public SpiritSwapWheelController script;
    //public Image selectedItem;
    private bool selected = false;
    //public Sprite icon;
    [SerializeField]
    private float cooldownDuration;

    private Button button;
    static bool onCooldown = false;
    private static SpiritSwapButton lastSelectedButton;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        button = this.GetComponent<Button>();
    }

    
    void Update()
    {
        if(selected){
            //selectedItem.sprite = icon;
            itemText.text = itemName;
        }

        if(onCooldown){
            button.interactable = false;
        } else{
            button.interactable = true;
        }
    }

    public void Selected(){
        StartCoroutine(ChangeElement());
        IEnumerator ChangeElement(){
            onCooldown = true;
            selected = true;
            SpiritSwapWheelController.spiritID = ID;
            script.changed = false;

            float remainingCooldown = cooldownDuration;

            while(remainingCooldown > 0){
                remainingCooldown -= Time.deltaTime;
                itemText.text = remainingCooldown.ToString("F2") + "s"; 
                yield return null;
            }
            
            itemText.text = "";
            onCooldown = false;
        }
    }

    public void Deselected(){
        selected = false;
        SpiritSwapWheelController.spiritID = 0;
    }

    public void HoverEnter(){
        anim.SetBool("Hover", true);
        itemText.text = itemName;
    }
    public void HoverExit(){
        anim.SetBool("Hover", false);
        itemText.text = "";
    }
}
