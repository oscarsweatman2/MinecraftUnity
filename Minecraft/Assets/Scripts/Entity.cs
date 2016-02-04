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

    private Transform crystal;

    private bool m_Jump;
    private Vector2 m_Input;
    private Vector3 m_MoveDir = Vector3.zero;
    private CharacterController m_CharacterController;
    private CollisionFlags m_CollisionFlags;
    private bool m_PreviouslyGrounded;
    private bool m_Jumping;
    private IntVec3 hidelocation;

    public Transform Target;

    enum AI_State
    {
        GUARD,
        CHASE,
        HIDE
    };
    private AI_State currentState;

    void Start ()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_Jumping = false;
        currentState = AI_State.GUARD;
        crystal = null;
	}
	
	void Update ()
    {
        if(crystal == null)
        {
            crystal = Player.Inst.transform;
        }

        CheckForStateName();
        if (currentState == AI_State.GUARD)
        {
            Vector2 loc = Random.insideUnitCircle * 5;

            move(new Vector3(crystal.position.x + loc.x,
                            crystal.position.y,
                            crystal.position.z + loc.y));
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
            move(Target.position);

            Vector3 playerlocation = Player.Inst.transform.position;
            Vector3 difference = playerlocation - transform.position;
            float length = difference.magnitude;

            if (length < 2)
            {
                currentState = AI_State.HIDE;
                bool searchingforlocation = true;
                while (searchingforlocation)
                {
                    int depth = VoxelWorld.Inst.VoxelDepth;
                    int width = VoxelWorld.Inst.VoxelWidth;
                    int choicex = Random.RandomRange(0, depth - 1);
                    int choicey = Random.RandomRange(0, width - 1);
                    
                    IntVec3 startinglocation = new IntVec3(choicex, 0, choicey);
                    Voxel v = VoxelWorld.Inst.GetVoxel(startinglocation);

                    bool blockisvalid = true;
                    while (blockisvalid)
                    {
                        startinglocation.Y += 1;
                        if(VoxelWorld.Inst.IsVoxelWorldIndexValid(startinglocation.X, startinglocation.Y, startinglocation.Z))
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
                }


            }
        }
        else if (currentState == AI_State.HIDE)
        {
            Vector3 hideworldlocation = new Vector3(hidelocation.X, hidelocation.Y, hidelocation.Z);

            move(hideworldlocation);

            Vector3 difference = hideworldlocation - transform.position;
            float length = difference.magnitude;

            if (length < 4)
            {
                currentState = AI_State.GUARD;
            }
        }

        m_PreviouslyGrounded = m_CharacterController.isGrounded;

        
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

        // the jump state needs to read here to make sure it is not missed
        if (!m_Jump)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 2))
            {
                if (hitInfo.collider is BoxCollider)
                {
                    Voxel voxel = VoxelWorld.Inst.GetVoxelFromCollider(hitInfo.collider as BoxCollider);

                    if (voxel != null)
                    {
                        m_Jump = true;
                    }
                }
            }
        }
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
