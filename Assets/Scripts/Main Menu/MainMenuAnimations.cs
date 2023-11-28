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

    void Update()
        {
        // Check if the text is being hovered on by the mouse
        if ( isHovered )
            {
            // Smoothly increase the font size
            buttonText.fontSize = Mathf.Lerp( buttonText.fontSize, hoverSize, 
                                             Time.deltaTime * transitionSpeed );
            }

        // Otherwise, assume the text is not being hovered on by the mouse
        else
            {
            // Smoothly decrease the font size
            buttonText.fontSize = Mathf.Lerp( buttonText.fontSize, normalSize, 
                                             Time.deltaTime * transitionSpeed );
            }

        }

    // Mouse Enter Function
    public void OnPointerEnter( PointerEventData eventData )
        {
        // Set flag to true
        isHovered = true;
        }

    // Mouse Exit Function
    public void OnPointerExit( PointerEventData eventData )
        {
        // Set flag to false
        isHovered = false;
        }
        
}