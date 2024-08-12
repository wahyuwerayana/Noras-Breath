using UnityEngine;
using UnityEngine.UI;

public class SpiritSwapWheelController : MonoBehaviour
{
    public Animator anim;
    private bool spiritWheelSelected = false;
    public Image selectedItem;
    public Sprite noImage;
    public static int spiritID;
    
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
            case 0:
                Debug.Log("Nothing");
                break;
            case 1:
                Debug.Log("Wind");
                break;
            case 2:
                Debug.Log("Water");
                break;
            case 3:
                Debug.Log("Forest");
                break;
            case 4:
                Debug.Log("Earth");
                break;
        }
    }
}
