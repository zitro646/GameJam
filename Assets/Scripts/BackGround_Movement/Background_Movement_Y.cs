using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Movement_Y : MonoBehaviour
{
    [SerializeField]private Vector2 parallaxEffectMultiplier;

    Rigidbody2D rb;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeY;
    // Start is called before the first frame update
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
        rb = GetComponent<Rigidbody2D>();
        float velocityY = -1 * 250 * Time.fixedDeltaTime;
        rb.velocity = new Vector2(rb.velocity.x, velocityY);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x , deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;

        if( Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY)
        {
            float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
            transform.position = new Vector3(transform.position.x , cameraTransform.position.y + offsetPositionY);
        }
    }
}
