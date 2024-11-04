using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Cameras
{
    public class Cameras
    {
        public Transform peekSpot;
        public Transform DroneViewPos;
        public bool isDrone { get; set; }
        public Vector3 defaultPosition { get; set; }

        public Cameras(Transform peekSpot, bool isDrone, Vector3 defaultPosition, Transform droneViewPos)
        {
            this.peekSpot = peekSpot;
            this.isDrone = isDrone;
            this.DroneViewPos = droneViewPos;
            this.defaultPosition = defaultPosition;
        }

        public void ChangeCamPos(GameObject player,Transform fpvPositionObj, Transform camTransform)
        {
            if (Input.GetButtonDown("Jump"))
            {
                this.isDrone = !isDrone;
            }

            if (this.isDrone)
            {
                camTransform.position = new Vector3(
                    this.DroneViewPos.position.x,
                    this.DroneViewPos.position.y,
                    this.DroneViewPos.position.z
                );
                camTransform.eulerAngles = new Vector3(fpvPositionObj.eulerAngles.x, fpvPositionObj.eulerAngles.y, fpvPositionObj.eulerAngles.z);

            }
            else
            {
                camTransform.position = this.peekSpot.position;
                // look where drone is set angle
                camTransform.LookAt(player.transform.position);

            }

        }

    }
}
