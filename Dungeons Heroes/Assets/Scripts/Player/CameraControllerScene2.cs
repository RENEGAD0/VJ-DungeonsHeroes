using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScene2 : MonoBehaviour
{
    public GameObject[] cameraList;
    int nCameras = 6;
    public Transform player;

    void checkCameraFromPlayerLocation(float x, float y, float z){
        if(x < 45 && x > 33.1){
            if(z > 53){
                disableCameras();
                cameraList[0].gameObject.SetActive(true);
            }
            else {
                disableCameras();
                cameraList[1].gameObject.SetActive(true);
            }

        }
        else if(x > 45){
            if(z > 51.5){
                disableCameras();
                cameraList[2].gameObject.SetActive(true);
            }
            else{
                disableCameras();
                cameraList[3].gameObject.SetActive(true);
            }
        }
        else if(x < 33.1){
            if(z > 51.5){
                disableCameras();
                cameraList[5].gameObject.SetActive(true);
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
        checkCameraFromPlayerLocation(player.position.x, player.position.y, player.position.z);
    }
}
