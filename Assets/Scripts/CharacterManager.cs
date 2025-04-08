using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public NaveData nave_data;

    [Header("Nave UI")]
    public Image img_nave;

    public Text txt_health;
    public Text txt_move_speed;
    public Text txt_speed;

    [Header("Nave UI")]
    public Button btn_prev;
    public Button btn_next;

    private int index;
    private void Start()
    {
        index = 0;

        SetData(index);
        SetButtons();
    }
    private void SetData(int index)
    {
        var dto = nave_data.naves[index];
        img_nave.sprite = dto.imagen;
        img_nave.SetNativeSize();

        txt_health.text = $"Vida: { dto.health_max}";
        txt_move_speed.text = $"Manejo: {dto.move_speed}";
        txt_speed.text = $"Velocidad: {dto.speed}";

        GameManager.Instance.SetNaveDTO(dto);
    }

    public void OnClick(string id)
    {
        switch (id)
        {
            case "prev":
                if(index > 0)
                {
                    index--;
                    SetData(index);
                    SetButtons();
                }
                break;

            case "next":
                if (index < nave_data.naves.Count -1)
                {
                    index++;
                    SetData(index);
                    SetButtons();
                }
                break;

            case "play":
                SceneManager.LoadScene("Game");
                break;
        }
    }

    private void SetButtons()
    {
        btn_prev.interactable = (index > 0);
        btn_next.interactable = (index < nave_data.naves.Count - 1);
    }
} 
