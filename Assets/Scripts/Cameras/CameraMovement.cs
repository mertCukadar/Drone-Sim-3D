using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Cameras;

public class CameraMovement : MonoBehaviour
{

    public Cameras cam;
    public GameObject player;
    public Transform fpvPositionObj;
    public Transform pilotPos;
    void Start()
    {
        if (fpvPositionObj == null && player == null)
        {
            // assign GameObjects in scane
            player = GameObject.Find("player");
            fpvPositionObj = player.transform.Find("FpvPoint");
            pilotPos = GameObject.Find("peekSpot").transform;

            //create cam obj
            cam = new Cameras(pilotPos ,true, fpvPositionObj.transform.position, fpvPositionObj);
            return;
        }

    }

    void Update()
    {
        cam.ChangeCamPos(player , fpvPositionObj , transform);
    }
}
