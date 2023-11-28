using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuAnimations : MonoBehaviour, IPointerEnterHandler, 
                                                             IPointerExitHandler
    {
    [ SerializeField ] private TextMeshProUGUI buttonText;
    [ SerializeField ] private int hoverSize;
    [ SerializeField ] private int normalSize;
    private bool isHovered = false;
    public int transitionSpeed;

    private void Update()
        {
        if (isHovered)
            {
            // Smoothly increase the font size
            buttonText.fontSize = Mathf.Lerp( buttonText.fontSize, hoverSize, 
                                             Time.deltaTime * transitionSpeed );
            }

        else
            {
            // Smoothly decrease the font size
            buttonText.fontSize = Mathf.Lerp( buttonText.fontSize, normalSize, 
                                             Time.deltaTime * transitionSpeed );
            }

        }

    public void OnPointerEnter(PointerEventData eventData)
        {
        isHovered = true;
        }

    public void OnPointerExit(PointerEventData eventData)
        {
        isHovered = false;
        }
        
}