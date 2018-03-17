﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindOtherPortal : MonoBehaviour {

    public bool portales = false;

    public GameObject otherP;

	// Use this for initialization
	void Start () {
        if(this.tag == "PortalA")
        {
            GameObject roomChange = GameObject.FindGameObjectWithTag("OriginalRoomChange");
            GameObject roomChangeCopy = GameObject.Instantiate(roomChange, 
                transform.position + GameObject.FindGameObjectWithTag("OriginalRoom").GetComponent<CopyRoom>().pos, 
                Quaternion.Euler(GameObject.FindGameObjectWithTag("OriginalRoom").GetComponent<CopyRoom>().rot));
            roomChangeCopy.tag = "CopyRoomChange";
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("PortalB") && !this.GetComponent<StepThroughPortal>().otherPortal)
        {
            portales = true;
            if (this.tag == "PortalB")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+120);

                otherP = GameObject.FindGameObjectWithTag("PortalA");
            }
            if (this.tag == "PortalA")
            {
                otherP = GameObject.FindGameObjectWithTag("PortalB");
            }
            this.GetComponent<StepThroughPortal>().otherPortal = otherP.transform;
            this.GetComponent<PortalView>().pointB = otherP.transform;
        }
    }
}