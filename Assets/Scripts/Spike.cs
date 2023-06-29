using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    void activateSpikeTrap()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
    }

    void deactivateSpikeTrap()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

}
