using UnityEngine;
using UnityEngine.UI;

public class SpiritSwapWheelController : MonoBehaviour
{
    public Animator anim;
    private bool spiritWheelSelected = false;
    public Image selectedItem;
    public Sprite noImage;
    public static int spiritID;

    public bool changed = false;
    
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift)){
            spiritWheelSelected = true;
        } else{
            spiritWheelSelected = false;
        }

        if(spiritWheelSelected){
            anim.SetBool("OpenSpiritWheel", true);
        } else{
            anim.SetBool("OpenSpiritWheel", false);
        }

        switch(spiritID){
            case 1:
                if(!changed){
                    Debug.Log("Wind");
                    changed = true;
                }
                break;
            case 2:
                if(!changed){
                    Debug.Log("Water");
                    changed = true;
                }
                break;
            case 3:
                if(!changed){
                    Debug.Log("Forest");
                    changed = true;
                }
                break;
            case 4:
                if(!changed){
                    Debug.Log("Earth");
                    changed = true;
                }
                break;
        }
    }
}
