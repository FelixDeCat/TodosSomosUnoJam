using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Screen;

public class Player : MonoBehaviour
{
    public float speed;
    public int type_cel = 3;

    public GameObject pausePanel;
    bool isPauseOn = false;
    public Rigidbody2D rb;
    public Collider2D myCol;

    public SpriteRenderer myRender;

    bool anim_control_cursor = false;
    float control_cursor = 1;

    [Range(0,50)]
    public float repel_force = 25;

    [SerializeField] Bubble myBubble;

    private void Start()
    {
        GameManager.instance.SubscribePlayer(this);
    }

    public void Build(int type_val, Vector2 pos)
    {
        type_cel = type_val;
        float size = 0;

        if (type_val == 3)
        {
            myRender.sprite = GameManager.instance.data.full_life;
            size = GameManager.instance.data.big;
            speed = GameManager.instance.data.slow_speed;
            transform.localScale = new Vector3(size, size, size);
        }
        if (type_val == 2)
        {
            myRender.sprite = GameManager.instance.data.med_life;
            size = GameManager.instance.data.medium;
            speed = GameManager.instance.data.medium_speed;
            transform.localScale = new Vector3(size, size, size);
        }
        if (type_val == 1)
        {
            myRender.sprite = GameManager.instance.data.low_life;
            size = GameManager.instance.data.small;
            speed = GameManager.instance.data.fast_speed;
            transform.localScale = new Vector3(size, size, size);
        }

        transform.position = pos;

        Vector2 dir = new Vector2(Random.Range(transform.position.x + 10, transform.position.x + 10), Random.Range(transform.position.y + 10, transform.position.y + 10)) - new Vector2(transform.position.x, transform.position.y);
        dir.Normalize();
       
        rb.AddForceAtPosition(dir *20, transform.position , ForceMode2D.Impulse);

    }
    float x_move;
    float input_horizontal = 0;
    float timer_pulse;
    void Update()
    {

        input_horizontal = Input.GetAxis("Horizontal");

        if (Mathf.Abs(input_horizontal) > 0.1f)
        {
            x_move = (speed + Time.deltaTime) * Input.GetAxis("Horizontal") * control_cursor;

            Vector2 aux = new Vector3(0,0,0);

            if (GhostFollow.instance.GetGhostTransformOrNull() != null)
            {
                Vector2 dir = GhostFollow.instance.GetGhostTransformOrNull().position - this.transform.position;
                dir.Normalize();


                aux = new Vector2(x_move + dir.x, dir.y);
            }
            else
            {
                Vector2 dir = new Vector2(transform.position.x, 7) - new Vector2(transform.position.x, transform.position.y);
                dir.Normalize();

                aux = new Vector2(x_move + dir.x, dir.y);
                
            }

            rb.velocity = Vector3.Lerp( rb.velocity ,aux, control_cursor);
        }

        if (anim_control_cursor)
        {
            if (control_cursor < 1f)
            {
                control_cursor += Time.deltaTime;
            }
            else
            {
                control_cursor = 1;
                anim_control_cursor = false;
            }
        }

        ClampToScreen(this.transform);


        if (timer_pulse < 0.2f)
        {
            timer_pulse += Time.deltaTime;
        }
        else
        {
            timer_pulse = 0;
            Vector2 randir = new Vector2(Random.Range(transform.position.x + 10, transform.position.x - 10), Random.Range(transform.position.y + 10, transform.position.y - 10)) - new Vector2(transform.position.x, transform.position.y);
            randir.Normalize();
            rb.AddForceAtPosition(randir * 25, transform.position, ForceMode2D.Force);
        }
    }

    public void Heal()
    {
        GameManager.instance.ReceiveSignalHeal(type_cel);

        //if (type_cel == 1)
        //{
        //    Build(2, this.transform.position);
        //}
        //else if (type_cel == 2)
        //{
        //    Build(3, this.transform.position);
        //}
    }

    void ClampToScreen(Transform t)
    {
        if (t.position.x >= ScreenLimits.Right_Superior.x)
        {
            t.position = new Vector2(ScreenLimits.Right_Superior.x - 0.5f, t.position.y);
        }
        if (t.position.x <= ScreenLimits.Left_Inferior.x)
        {
            t.position = new Vector2(ScreenLimits.Left_Inferior.x + 0.5f, t.position.y);
        }


        if (t.position.y >= ScreenLimits.Right_Superior.y)
        {
            t.position = new Vector2(GhostFollow.instance.GetGhostTransformOrNull().position.x, ScreenLimits.Right_Superior.y -0.5f);
        }
    }

    public void Push(bool right, float force = 10)
    {
        rb.velocity = Vector2.zero;
        control_cursor = 0;
        anim_control_cursor = true;
        Vector2 pushvector = right ? Vector2.right : Vector2.right * -1;
        rb.AddForce(pushvector * force, ForceMode2D.Impulse);
    }

    public void Divide()
    {
        if (type_cel > 1)
        {
            SoundDataBase.instance.PlayCellDivide();
            PublicEvents.instance.EVENT_OnPlayerHit();
            for (int i = 0; i < 2; i++)
            {
                var separation = GameManager.instance.data.Separation;
                var obj = GameObject.Instantiate(GameManager.GetPlayer());
                obj.transform.position = new Vector3(i == 0 ? obj.transform.position.x - separation : obj.transform.position.x + separation, obj.transform.position.y, obj.transform.position.z);
                if (type_cel == 3) obj.Build(2, this.transform.position);
                if (type_cel == 2) obj.Build(1, this.transform.position);
            }
        }
        else
        {
             SoundDataBase.instance.PlayDeathCell();
        }
        GameManager.instance.UnSubscribePlayer(this);
        Destroy(this.gameObject);
    }

    public void TurnOnBubble()
    {
        myBubble.Amplify();
    }
    public void MyCollision(bool val)
    {
        myCol.enabled = val;
    }
}
