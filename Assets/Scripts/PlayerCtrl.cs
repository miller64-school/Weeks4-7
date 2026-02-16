using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public SpriteRenderer sprite;

    bool facingLeft = true; // Initialize that the player is facing left when they beign

    public void Shoot()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie"); // Find everything tagged Zombie
        // I had no idea what tags were until I looked them up and it's like what the hell why haven't I been using these earlier
        GameObject closest = null;
        float best = Mathf.Infinity; // Raycast to the closest target
        
        foreach (GameObject z in zombies) // Do this for every GameObject tagged Zombie, z for zombie
        {
            float distX = z.transform.position.x - transform.position.x;
            
            if ((facingLeft && distX < 0) || (!facingLeft && distX > 0)) // This is to give the flip button a use
            {
                float dist = Mathf.Abs(distX); // I have no idea what I'm doing
                if (dist < best)
                {
                    best = dist;
                    closest = z;
                }
            }
        }

        if (closest != null)
            Destroy(closest); // Destroy the closest object, "shoot the zombie" basically
    }

    public void Turn()
    {
        facingLeft = !facingLeft; // Always invert the facingLeft criteria
        sprite.flipX = !sprite.flipX; // Flip the sprite if the button gets pressed
    }

    public void Move(float x)
{
    transform.position = new Vector3(x, transform.position.y, transform.position.z);
        // The slider value is set between -5 and 5 so no fancy math has to be done here
        // Also it's very weird using vectors after spending so long not using them
}

}
