using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] Transform interactorSource;
    float interactRange = 3;

    public void Interact()
    {
        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        if(Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out NPCManager npcManager))
            {
                npcManager.Interacted(this.gameObject);
            }
        }
    }
}
