using UnityEngine;

public class InitiateIsland : MonoBehaviour
{
    public GameObject[] islandPrefab;
    public Transform[] islandPlaceholder;
    [SerializeField]
    private CameraControl cameraControlScript;
    
    void Start()
    {
        cameraControlScript.targetFocus = new Transform[4];
        for(int i = 0; i < 4; i++){
            GameObject newIsland = Instantiate(islandPrefab[Random.Range(0, islandPrefab.Length)], islandPlaceholder[i].position, islandPlaceholder[i].rotation);
            newIsland.transform.parent = GameObject.Find("Island Parent").transform;
            newIsland.name = "Island " + (i+1);
            cameraControlScript.targetFocus[i] = newIsland.transform.Find("Lookat");
        }
    }
}
