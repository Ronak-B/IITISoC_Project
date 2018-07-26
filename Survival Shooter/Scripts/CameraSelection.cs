using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelection : MonoBehaviour {

    public Camera MainCamera1;
    public Camera TopCamera;
    bool Cswitch=false;
    
    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Cswitch = !Cswitch;
            TopCamera.gameObject.SetActive(Cswitch);
            TopCamera.enabled=Cswitch;
            MainCamera1.gameObject.SetActive(!Cswitch);
            MainCamera1.enabled = !Cswitch;
        }
        
    }
}
