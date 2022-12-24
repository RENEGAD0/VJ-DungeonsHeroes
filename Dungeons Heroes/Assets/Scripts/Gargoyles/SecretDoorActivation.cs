using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoorActivation : MonoBehaviour
{

    [SerializeField] private GameObject gargoyle1;
    [SerializeField] private GameObject gargoyle2;
    //[SerializeField] private GameObject gargoyleMovement1;
    //[SerializeField] private GameObject gargoyleMovement2;
    [SerializeField] private GameObject secretDoor;
    [SerializeField] private GameObject secretDoorWall;

     Vector3 angleVectorGargoyle1;
     Vector3 angleVectorGargoyle12;
    // Start is called before the first frame update
    void Start()
    {
        angleVectorGargoyle1.Set(0.0f, 90.0f, 0.0f);
        angleVectorGargoyle12.Set(0.0f, 270.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gargoyle1.transform.eulerAngles == angleVectorGargoyle1 && gargoyle2.transform.eulerAngles == angleVectorGargoyle12){
            secretDoor.SetActive(true);
            secretDoorWall.SetActive(false);
            //gargoyleMovement1.SetActive(false);
            //gargoyleMovement2.SetActive(false);
        }
        
    }
}
