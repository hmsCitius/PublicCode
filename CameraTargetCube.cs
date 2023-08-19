using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTargetCube : MonoBehaviour
{
    public Transform FollowCube;



    private void LateUpdate()
    {
        if (GameObject.Find("FollowCube"))
        {
            FollowCube = GameObject.Find("FollowCube").transform;
            GetComponent<CinemachineVirtualCamera>().Follow = FollowCube.transform;
        }
        


        

    }

}
