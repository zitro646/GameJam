using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Movement_X : MonoBehaviour
{
    [SerializeField]private Vector2 parallaxEffectMultiplier;

    Rigidbody2D rb;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;
    // Start is called before the first frame update
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        rb = GetComponent<Rigidbody2D>();
        float velocityX = -1 * 250 * Time.fixedDeltaTime;
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x , deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;

        if( Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
        }
    }
}
