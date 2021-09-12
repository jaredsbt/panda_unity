using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float rotSpeed = 1f;
    public Transform target, player, shooter;
    float mouseX, mouseY;

    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        //makes it so the camera can be rotated and not be dictated by screen size
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * rotSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotSpeed;

        //Mathf.Clamp prevents camera from backflipping
        mouseY = Mathf.Clamp(mouseY, -35f, 60);

        transform.LookAt(target);

        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        player.rotation = Quaternion.Euler(0, mouseX, 0);

        //allows shooter to be aimed with mouse rotation
        shooter.rotation = Quaternion.Euler(mouseY, mouseX, 0);

        if (pc.isDead == true)
        {
            //brings back cursor for potential game over UI
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
