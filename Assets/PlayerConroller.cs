using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerConroller : MonoBehaviour
{
    [SerializeField] private Player player;

    [Space]

    [SerializeField] private TextMeshProUGUI posX;
    [SerializeField] private TextMeshProUGUI posY;
    [SerializeField] private TextMeshProUGUI posZ;

    [Space]

    [SerializeField] private TextMeshProUGUI playerHealth;
    [SerializeField] private TextMeshProUGUI playerLevel;

    void Update()
    {
        ChangePos();
        ChangeUiText();
    }

    void ChangePos() // change the object position with time
    {
        gameObject.transform.position += new Vector3(0.1f * Time.deltaTime,0.1f * Time.deltaTime,0.1f * Time.deltaTime);
    }

    #region UI
    private void ChangeUiText() // change ui text to the data given
    {
        posX.text = player.transform.position.x.ToString("0.00");
        posY.text = player.transform.position.y.ToString("0.00");
        posZ.text = player.transform.position.z.ToString("0.00");

        playerHealth.text = player.health.ToString();
        playerLevel.text = player.level.ToString();
    }

    

    #endregion
}
