using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBehavior : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;
    [SerializeField] private Color _highlightColor = Color.black;
    
    private Renderer _currentRenderer;
    
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out var hitInfo, 100))
        {
            Renderer hitRenderer = hitInfo.collider.gameObject.GetComponent<Renderer>();
            
            if (_layer.value != 2)
            {
                if (_currentRenderer != hitRenderer)
                {
                    if (_currentRenderer != null)
                    {
                        _currentRenderer.material.color = Color.white;
                    }

                    _currentRenderer = hitRenderer;
                    _currentRenderer.material.color = _highlightColor;
                }
            }
        }
        else
        {
            if (_currentRenderer != null)
            {
                _currentRenderer.material.color = Color.white;
                _currentRenderer = null;
            }
        }
    }
}
