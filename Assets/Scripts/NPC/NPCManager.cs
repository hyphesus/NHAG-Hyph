using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    [SerializeField] string nameOfItemToLookFor;
    [SerializeField] string questText;
    [SerializeField] string postQuestText;
    [SerializeField] Canvas canvas;
    TMPro.TextMeshProUGUI text;
    InventoryManager inventoryManager;
    bool questDone = false;
    bool dancing = false;
    Vector3 defaultPos;
    private void Awake()
    {
        defaultPos = transform.position;
        canvas.enabled = false;
        text = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        text.text = questText;
    }
    private void Update()
    {
        if (dancing)
        {
            float newY = Mathf.Sin(Time.time * 10);
            transform.position = new Vector3(transform.position.x, defaultPos.y + Mathf.Abs(newY) * 0.5f, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            canvas.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            canvas.enabled = false;
        }
    }
    public void Interacted(GameObject interactor)
    {
        if (questDone)
            return;
        if (inventoryManager == null)
            inventoryManager = interactor.GetComponent<InventoryManager>();

        if (inventoryManager.hasItem)
        {
            if (inventoryManager.currentItem == nameOfItemToLookFor)
            {
                //does happy dance
                text.text = postQuestText;
                GetComponentInChildren<TextResizer>().SetSize();
                StartCoroutine(HappyDance());
                questDone = true;
                inventoryManager.EmptyQuestInventory();
            }
            else
                Debug.Log("Wrong item");
        }
    }
    IEnumerator HappyDance()
    {
        dancing = true;
        yield return new WaitForSeconds(1.2f);
        dancing = false;
        transform.position = defaultPos;
    }
}

