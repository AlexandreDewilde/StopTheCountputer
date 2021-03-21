using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMethods:MonoBehaviour
{
    public Text roomNameText;

    public GameObject hammer;

    private Animator _animator;

    private Vector3 distanceRaycastFromCharacter = new Vector3(1f, 0, 0);
    public float distanceHammerHit = 2f;
    private bool isWeaponActive= false;
    private Controller controllerComponent;
    private bool isDown = false;

    void Awake()
    {
        controllerComponent = GetComponent<Controller>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (isWeaponActive &&!isDown && Input.GetMouseButtonUp(0))
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, controllerComponent.GetMousePos(), distanceHammerHit);
            _animator.Play("Hammer_hit");
            foreach (RaycastHit2D hit in hits)
            {
                Debug.Log(hit.collider.gameObject.tag);
                if (hit.collider != null && hit.collider.gameObject.tag == "malware")
                {
                    Destroy(hit.collider.gameObject);
                }
                isDown = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDown = false;
        }
    }

    public void PickWeapon(int weaponId)
    {
        if (weaponId == 1)
        {
            hammer.SetActive(true);
            isWeaponActive = true;
        }
    }

    public void DisableWeapon(int weaponId)
    {
        if (weaponId == 1)
        {
            hammer.SetActive(false);
            isWeaponActive = false;
        }
    }

    public void TellPlayerRoomName(string roomName)
    {

        roomNameText.text = roomName;

    }



}
