using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PLayerController : MonoBehaviour
{
    private bool estaTocandoElSuelo = false;
    private float speed = 10;
    
   
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb2d;
    public Text scoreText;

    

    private int scoreA = 0;
    private int scoreB = 0;
    private int scoreC = 0;
    // Start is called before the first frame update
    void Start()
    {
         sr= GetComponent<SpriteRenderer>();//obtengo el objeto spriterender de player
      //  Debug.Log("hola mundo este es un metodo que se ejecuta una vez");
        //sr.flipX = true;
        animator = GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        scoreText.text = "Moneda A: "+scoreA +"   " +"Moneda B: " +scoreB+"   "+"Moneda C: "+ scoreC;
        

         
        if(Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            run();
            
            rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
            if(Input.GetKey(KeyCode.A))
        {
            SetSlideAnimation();
        }
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            run();
            rb2d.velocity = new Vector2(-speed,rb2d.velocity.y);
            if(Input.GetKey(KeyCode.A))
        {
            SetSlideAnimation();
        }
        }
        else
        {
            SetIdleAnimation();
            rb2d.velocity = new Vector2(0,rb2d.velocity.y);
        }
        

        //cuando presiono la flecha a la derecha cambio la animacion
        //Input .GetKey(); //mientras presiono
        //Input .GetKeyUp(); //cuando suelto la tecla
        //Input .GetKeyDown();//cuando presiono por primera vez
        //sr.flipX = !sr.flipX;
        //run();
         Debug.Log("hola");
         
         if(Input.GetKeyDown(KeyCode.Space) && estaTocandoElSuelo){
             

            saltar();
            estaTocandoElSuelo = false;
           
             


            // rb2d.velocity = new Vector2(rb2d.velocity.x,10);
            
            //rb2d.AddForce(new Vector2(0,1000));

         }
         /*if(Input.GetKeyDown(KeyCode.Space)){
                rb2d.velocity = new Vector2(10,rb2d.velocity.y);
             }*/ 
        
    }
    void OnCollisionEnter2D(Collision2D other){
       // Debug.Log("Collision");
        //Debug.Log(other.gameObject.name);
        if(other.gameObject.layer == 6){
             Destroy(other.gameObject);
             scoreA ++;
        }
        if(other.gameObject.layer == 7){
             Destroy(other.gameObject);
             scoreB ++;
        }
        if(other.gameObject.layer == 8){
             Destroy(other.gameObject);
             scoreC ++;
        }
        estaTocandoElSuelo = true;
       
        /*if(other.gameObject.name == "squarename"){
             estaTocandoElSuelo = true;
        }*/
           
    }
     public void saltar(){
        var upSpeed = 80f;
        rb2d.velocity = Vector2.up * upSpeed;
        
    }
    
    public void run(){
        animator.SetInteger("Estado", 1);
    }
    public void SetJumpAnimation(){
       animator.SetInteger("Estado", 2);
    }
    public void SetIdleAnimation(){
        animator.SetInteger("Estado", 0);        
    }
    public void SetSlideAnimation(){
        animator.SetInteger("Estado", 3);        
    }
}
