using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private float checkRadius = 3f;
    [SerializeField] private LayerMask interactableLayers;

    private IInteractable currentInteractable;
    private GameObject player;


    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteractables();
        if((Input.GetKeyDown(KeyCode.E) && currentInteractable != null))
        {
            currentInteractable.OnInteract(player);
        }
    }

    private void CheckInteractables()
    {
        Collider[] colliders = Physics.OverlapSphere(player.transform.position, checkRadius, interactableLayers);       //주변 상호작용 가능한 객체 탐색   
        IInteractable clossest = null;
        float closetsDistance = float.MaxValue;

        foreach(var col in colliders)
        {
            if(col.TryGetComponent<IInteractable>(out var interactable))
            {
                float distance = Vector3.Distance(player.transform.position, col.transform.position);

                if(distance <= interactable.GetInteractionDistance() && distance < closetsDistance &&interactable.CanInteract(player))
                {
                    clossest = interactable;
                    closetsDistance = distance;
                }
            }
        }

    }

    private void UpdatePrompt()
    {
        if(currentInteractable != null)
        {
            promptText.text = $"[E]  {currentInteractable.GetInteractPrompt()}";
        }
        else
        {
            promptText.gameObject.SetActive(false);
        }
    }
}
