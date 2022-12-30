using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScene3 : MonoBehaviour
{
    public GameObject[] cameraList;
    int nCameras = 5;
    public Transform player;

    void checkCameraFromPlayerLocation(float x, float y, float z){
        if(x < 34 && z >110){
            disableCameras();
            cameraList[3].gameObject.SetActive(true);
        }
        else if(x > 54 && z > 110){
            disableCameras();
            cameraList[2].gameObject.SetActive(true);
        }
        else if (x < 54 && x > 34){
            if(z > 126.5){
                disableCameras();
                cameraList[0].gameObject.SetActive(true);
            }
            else if (z <= 126 && z > 110 ){
                disableCameras();
                cameraList[1].gameObject.SetActive(true);
            }
            else{
                disableCameras();
                cameraList[4].gameObject.SetActive(true);
            }
        }

    }
    void disableCameras(){
        for(int i = 0;i < nCameras;++i){
            cameraList[i].gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        disableCameras();
        cameraList[0].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // checkCameraFromPlayerLocation(player.position.x, player.position.y, player.position.z);
    }
}
