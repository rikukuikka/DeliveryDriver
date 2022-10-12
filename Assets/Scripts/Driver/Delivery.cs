using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField]
    Color32 _hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField]
    Color32 _noPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField]
    private bool _hasPackage = false;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !_hasPackage)
        {
            Debug.Log("Picked up " + other.transform.name);
            _hasPackage = true;
            Destroy(other.gameObject);
            _spriteRenderer.color = _hasPackageColor;
        }
        else if (other.tag == "Customer" && _hasPackage)
        {
            Debug.Log("Delivered package");
            _hasPackage = false;
            _spriteRenderer.color = _noPackageColor;
        }
    }
}
