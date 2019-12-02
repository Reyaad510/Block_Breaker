using UnityEngine;

public class Ball : MonoBehaviour
{

    // config parameters

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    // [SerializeField] AudioClip[] ballSounds;
    [SerializeField] AudioClip ballSound;
    [SerializeField] float randomFactor = 0.2f;

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached component references
    // DO this when using more than once or GetComponent alot for every frame so dont have to search for it every frame
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;


    // Start is called before the first frame update
    void Start()
    {
        // giving distance between ball and paddle. Postion of ball minus position of paddle x1,y1 - x2,y2
        paddleToBallVector = transform.position - paddle1.transform.position;

        // Telling engine go and find Audiosource component once and saying this is what is is
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // bool used bcuz if not then when you left click the ball wont launch off paddle
        // Saying if false then the ball will be locked to paddle and you can left click to launch the ball
        // When left click hasStarted will be true meaning ball cant be locked to paddle and cant left click to launch ball anymore
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // prevents ball from going horizontal for years
        Vector2 velocityTweak = new Vector2(
            Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));

        // If hasStarted is true then play the audio sound for when the ball collides to anything
        // Fixes bug where audio will play when ball rests on paddle due to game saying it is colliding with it. Will only make sound after ball launches
        if (hasStarted)
        {
           
            // UnityEngine bcuz there are different Random can be using so we are using UnityEngine Random
            // AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            AudioClip clip = ballSound;
            // PlayOneShot means will play an audio piece whole way through even if another audio starts playing\
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}


