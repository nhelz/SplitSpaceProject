using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerOnContact : MonoBehaviour
{
    //Transform of the other portal this portal teleports the player to
    public Transform otherPortalTransform;
    //Bool to check if the player was just teleported into the other portal--if this is true, then the portal should ignore this collision (otherwise the player would infinitely teleport back and forth)
    private bool justTeleported = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player entered the portal and DID NOT just teleport there, meaning they actually walked into the portal willingly, then set their position to the other portal and set justTeleported on that other portal to true
        if (collision.gameObject.CompareTag("Player") && !justTeleported)
        {
            collision.gameObject.transform.position = otherPortalTransform.position;
            otherPortalTransform.gameObject.TryGetComponent<TeleportPlayerOnContact>(out TeleportPlayerOnContact otherPortal);
            otherPortal.justTeleported = true;
        }
    }

    //If the player walks out of this portal, set justTeleported to false. Now they can walk back in the portal and teleport away fine.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && justTeleported)
        {
            justTeleported = false;
        }
    }
}
