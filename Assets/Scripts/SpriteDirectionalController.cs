using UnityEngine;

public class SpriteDirectionalController : MonoBehaviour
{
    public float BackAngle = 65f;
    public float SideAngle  = 155f; 

    public Transform ParentTransform; 

    public Animator Animator; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ParentTransform = GetComponentInParent<Transform>(); 
        Animator = GetComponent<Animator>();
    }


    private void LateUpdate()
    {
        var camera = GameManager.Instance.GetSceneCamera(); 

        Vector3 forwardCamera = new Vector3(camera.transform.forward.x, 0f, camera.transform.forward.z);

        float signedAngle = Vector3.SignedAngle(ParentTransform.forward, forwardCamera, Vector3.up);

        Vector2 animationDirection;// = new Vector2(0f, 0f); 

        float angle = Mathf.Abs(signedAngle);

        if (angle < BackAngle)
        {
            //back animation
            animationDirection = new Vector2(0, 1f);
        }
        else if (angle < SideAngle)
        {
            if (signedAngle <0)
            {
                animationDirection = new Vector2(-1f, 0f);
            }
            else
            {
                //side animation, right. 
                animationDirection = new Vector2(1f, 0f); 
            }

        }
        else
        {
            //show front animation
            animationDirection = new Vector2(0f, 1f); 
        }

        Animator.SetFloat("MoveX", animationDirection.x);
        Animator.SetFloat("MoveY", animationDirection.y);    
    }
}
