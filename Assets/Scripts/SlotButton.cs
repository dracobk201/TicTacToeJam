using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotButton : MonoBehaviour
{
    [SerializeField]
    private Slot targetSlot;
    [SerializeField]
    private Image spriteSlot;
    [SerializeField]
    private IntReference ActivePlayer;
    [SerializeField]
    private List<Sprite> XSprites;
    [SerializeField]
    private List<Sprite> OSprites;

    public void MarkSlot()
    {
        Debug.Log("Botón presionado.");
        if (!targetSlot.state.Equals(SlotState.Null))
            return;
        if (ActivePlayer.Value == 1)
        {
            int index = Random.Range(0, XSprites.Count - 1);
            spriteSlot.sprite = XSprites[index];
            targetSlot.state = SlotState.X;
            ActivePlayer.Value = 2;
            Debug.Log("Es X.");
        }
        else if (ActivePlayer.Value == 2)
        {
            int index = Random.Range(0, OSprites.Count - 1);
            spriteSlot.sprite = OSprites[index];
            targetSlot.state = SlotState.O;
            ActivePlayer.Value = 1;
            Debug.Log("Es O.");
        }
    }
}
