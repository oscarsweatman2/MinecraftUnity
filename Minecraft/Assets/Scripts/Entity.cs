using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Entity : MonoBehaviour
{
    [SerializeField]
    private bool m_IsWalking;
    [SerializeField]
    private float m_WalkSpeed;
    [SerializeField]
    private float m_RunSpeed;
    [SerializeField]
    private float m_TurnSpeed;
    [SerializeField]
    private float m_JumpSpeed;
    [SerializeField]
    private float m_StickToGroundForce;
    [SerializeField]
    private float m_GravityMultiplier;


    private bool m_Jump;
    private Vector2 m_Input;
    private Vector3 m_MoveDir = Vector3.zero;
    private CharacterController m_CharacterController;
    private CollisionFlags m_CollisionFlags;
    private bool m_PreviouslyGrounded;
    private bool m_Jumping;
    private IntVec3 hidelocation;

    public Gem myGem = null;

    public float hideTime = 5;
    private float currentTime = 0;

    public enum AI_State
    {
        GUARD,
        CHASE,
        HIDE
    };
    public AI_State currentState;

    void Start ()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_Jumping = false;
        currentState = AI_State.GUARD;
	}

    void checkgem()
    {
        if (myGem != null)
        {
            if (myGem.isHeld && currentState == AI_State.GUARD)
            {
                currentState = AI_State.CHASE;
            }
        }
    }
	void Update ()
    {
        checkgem();

       

        CheckForStateName();
        if (currentState == AI_State.GUARD)
        {
            Vector2 loc = Random.insideUnitCircle * 5;
            if (myGem != null)
            {
                move(new Vector3(myGem.transform.position.x + loc.x,
                              myGem.transform.position.y,
                              myGem.transform.position.z + loc.y));
            }
                Vector3 playerlocation = Player.Inst.transform.position;
                Vector3 difference = playerlocation - transform.position;
                float length = difference.magnitude;
            
            if (length < 8)
            {
                currentState = AI_State.CHASE;
            }
        }
        else if (currentState == AI_State.CHASE)
        {
            move(myGem.transform.position);

            Vector3 playerlocation = Player.Inst.transform.position;
            Vector3 difference = playerlocation - transform.position;
            float length = difference.magnitude;

            if (myGem != null)
            {
                if (length < 2 && Player.Inst.heldGems[myGem.index])
                {
                    currentState = AI_State.HIDE;

                    Player.Inst.heldGems[myGem.index] = false;
                    myGem.holder = gameObject;

                    bool searchingforlocation = true;
                    while (searchingforlocation)
                    {
                        int depth = VoxelWorld.Inst.VoxelDepth;
                        int width = VoxelWorld.Inst.VoxelWidth;
                        int choicex = (int)(Random.value * depth - 1);
                        int choicey = (int)(Random.value * width - 1);

                        IntVec3 startinglocation = new IntVec3(choicex, 0, choicey);
                        Voxel v = VoxelWorld.Inst.GetVoxel(startinglocation);

                        bool blockisvalid = true;
                        while (blockisvalid)
                        {
                            startinglocation.Y += 1;
                            if (VoxelWorld.Inst.IsVoxelWorldIndexValid(startinglocation.X, startinglocation.Y, startinglocation.Z))
                            {
                                Voxel v2 = VoxelWorld.Inst.GetVoxel(startinglocation);
                                if (v2.TypeDef.Type == VoxelType.Air)
                                {

                                    hidelocation = startinglocation;

                                    searchingforlocation = false;

                                    currentState = AI_State.HIDE;
                                    Debug.Log("found place: " + startinglocation);

                                }
                            }
                            else
                            {
                                blockisvalid = false;
                            }
                        }
                        
                        currentTime = 0;
                    }


                }
                if(!myGem.isHeld)
                {
                    currentState = AI_State.GUARD;
                }
            }
        }
        else if (currentState == AI_State.HIDE)
        {
            Vector3 hideworldlocation = new Vector3(hidelocation.X, hidelocation.Y, hidelocation.Z);

            move(hideworldlocation);

            Vector3 difference = hideworldlocation - transform.position;
            float length = difference.magnitude;

            currentTime += Time.deltaTime;

            if (length < 4 || currentTime >= hideTime)
            {
                currentState = AI_State.GUARD;
                myGem.holder = null;
                myGem.isHeld = false;
               
            }
        }

        m_PreviouslyGrounded = m_CharacterController.isGrounded;

        float voxelsDeep = VoxelWorld.Inst.ChunksDeep * VoxelWorld.Inst.ChunkVoxelSize * VoxelWorld.Inst.PhysicalVoxelSize;
        float voxelsWide = VoxelWorld.Inst.ChunksWide * VoxelWorld.Inst.ChunkVoxelSize * VoxelWorld.Inst.PhysicalVoxelSize;

        if (transform.position.x < 0)
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        if (transform.position.x > voxelsWide)
            transform.position = new Vector3(voxelsWide, transform.position.y, transform.position.z);
        if (transform.position.z < 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (transform.position.z > voxelsDeep)
            transform.position = new Vector3(transform.position.x, transform.position.y, voxelsDeep);
    }

    private void CheckForStateName()
    {
        bool isdown = Input.GetKeyDown(KeyCode.C);


        if (isdown == true)
        {
            currentState = AI_State.CHASE;
            //Debug.Log("chasing");
        }

        isdown = Input.GetKeyDown(KeyCode.G);

        if (isdown == true)
        {
            currentState = AI_State.GUARD;
            //Debug.Log("guarding");
        }
        isdown = Input.GetKeyDown(KeyCode.H);


        if (isdown == true)
        {
            currentState = AI_State.HIDE;
            //Debug.Log("hiding");
        }
    }

    private void move(Vector3 Target)
    {
        Vector3 targetPos = Target != null ? Target : Vector3.zero;
        TurnTowardTarget(targetPos);

        if (!m_PreviouslyGrounded && m_CharacterController.isGrounded)
        {
            //StartCoroutine(m_JumpBob.DoBobCycle());
            //PlayLandingSound();
            m_MoveDir.y = 0f;
            m_Jumping = false;
        }
        if (!m_CharacterController.isGrounded && !m_Jumping && m_PreviouslyGrounded)
        {
            m_MoveDir.y = 0f;
        }
    }

    private void FixedUpdate()
    {
        float speed;
        GetInput(out speed);
        // always move along the camera forward as it is the direction that it being aimed at
        Vector3 desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;

        // get a normal for the surface that is being touched to move along it
        RaycastHit hitInfo;
        Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
                           m_CharacterController.height / 2f, ~0, QueryTriggerInteraction.Ignore);
        desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

        m_MoveDir.x = desiredMove.x * speed;
        m_MoveDir.z = desiredMove.z * speed;


        if (m_CharacterController.isGrounded)
        {
            m_MoveDir.y = -m_StickToGroundForce;

            if (m_Jump)
            {
                m_MoveDir.y = m_JumpSpeed;
                //PlayJumpSound();
                m_Jump = false;
                m_Jumping = true;
            }
        }
        else
        {
            m_MoveDir += Physics.gravity * m_GravityMultiplier * Time.fixedDeltaTime;
        }
        m_CollisionFlags = m_CharacterController.Move(m_MoveDir * Time.fixedDeltaTime);

        //ProgressStepCycle(speed);
        //UpdateCameraPosition(speed);

        //m_MouseLook.UpdateCursorLock();
    }

    private void TurnTowardTarget(Vector3 target)
    {
        target.y = transform.position.y;

        Vector3 right = transform.right;

        Vector3 toTarget = target - transform.position;
        if (toTarget.magnitude <= 3.0f)
            return;

        float rightDotToTarget = Vector3.Dot(right, toTarget.normalized);

        if (rightDotToTarget > 0.01f)
            transform.Rotate(0, m_TurnSpeed * Time.deltaTime, 0);
        else if (rightDotToTarget < -0.01f)
            transform.Rotate(0, -m_TurnSpeed * Time.deltaTime, 0);
    }

    private void GetInput(out float speed)
    {
        // Read input
        float horizontal = 0.0f;// CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = 1.0f; // CrossPlatformInputManager.GetAxis("Vertical");

        bool waswalking = m_IsWalking;

#if !MOBILE_INPUT
        // On standalone builds, walk/run speed is modified by a key press.
        // keep track of whether or not the character is walking or running
        m_IsWalking = true; // !Input.GetKey(KeyCode.LeftShift);
#endif
        // set the desired speed to be walking or running
        speed = m_IsWalking ? m_WalkSpeed : m_RunSpeed;
        m_Input = new Vector2(horizontal, vertical);

        // normalize input if it exceeds 1 in combined length:
        if (m_Input.sqrMagnitude > 1)
        {
            m_Input.Normalize();
        }

        // handle speed change to give an fov kick
        // only if the player is going to a run, is running and the fovkick is to be used
        //if (m_IsWalking != waswalking && m_UseFovKick && m_CharacterController.velocity.sqrMagnitude > 0)
        //{
        //    StopAllCoroutines();
        //    StartCoroutine(!m_IsWalking ? m_FovKick.FOVKickUp() : m_FovKick.FOVKickDown());
        //}
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the Entity is colliding with something on it's side
        if ((m_CollisionFlags & CollisionFlags.CollidedSides) != 0)
        {
            if (!m_Jump)
            {
                m_Jump = true;
            }
        }

        Rigidbody body = hit.collider.attachedRigidbody;
        //dont move the rigidbody if the character is on top of it
        if (m_CollisionFlags == CollisionFlags.Below)
        {
            return;
        }

        if (body == null || body.isKinematic)
        {
            return;
        }
        body.AddForceAtPosition(m_CharacterController.velocity * 0.1f, hit.point, ForceMode.Impulse);
    }
    //private void ProgressStepCycle(float speed)
    //{
    //    if (m_CharacterController.velocity.sqrMagnitude > 0 && (m_Input.x != 0 || m_Input.y != 0))
    //    {
    //        m_StepCycle += (m_CharacterController.velocity.magnitude + (speed * (m_IsWalking ? 1f : m_RunstepLenghten))) *
    //                     Time.fixedDeltaTime;
    //    }

    //    if (!(m_StepCycle > m_NextStep))
    //    {
    //        return;
    //    }

    //    m_NextStep = m_StepCycle + m_StepInterval;

    //    PlayFootStepAudio();
    //}
}
