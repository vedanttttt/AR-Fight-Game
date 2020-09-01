using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamecontrol : MonoBehaviour
{

    public Animator animator;
    public Transform my3DModel;
    public Transform MyPauseButton;


    public Transform attack_point;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 40;

    // Use this for initialization
    void Start()
    {
        animator = my3DModel.GetComponent<Animator>();
    }

    public void playAnim()
    {
        animator.Play("elbow_punch", -1, 0f);
    }

    public void playKick()
    {
        animator.Play("roundhouse_kick", -1, 0f);
    }
    public void playpunch()
    {
        animator.Play("rifle_punch", -1, 0f);
    }
    public void playkick1()
    {
        animator.Play("zombie_kick", -1, 0f);
    }
    public void playstab()
    {
        animator.Play("stabbing", -1, 0f);
    }
    public void playmelee()
    {
        animator.Play("stand_melee", -1, 0f);
    }
    public void playcompasso()
    {
        animator.Play("compasso", -1, 0f);
    }
    public void playsweep()
    {
        animator.Play("leg_sweep", -1, 0f);
    }
    public void playmelee1()
    {
        animator.Play("melee", -1, 0f);
    }
    public void playdagger()
    {
        animator.Play("dagger_stab", -1, 0f);
    }
    public void playarmada()
    {
        animator.Play("armada", -1, 0f);
    }




    public void warrok_defend()
    {
        Attack1();
    }

    void Attack1()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attack_point.position, attackRange, enemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attack_point == null)
            return;

        Gizmos.DrawWireSphere(attack_point.position, attackRange);
    }







    public void pauseAnim()
    {
        animator.speed = 0;
        MyPauseButton.GetComponentInChildren<Text>().text = "RESUME";
        Button btn = MyPauseButton.GetComponent<Button>();
        btn.onClick.AddListener(resumeAnim);
    }

    void resumeAnim()
    {
        MyPauseButton.GetComponentInChildren<Text>().text = "PAUSE";
        animator.speed = 1;
        Button btn = MyPauseButton.GetComponent<Button>();
        btn.onClick.AddListener(pauseAnim);
    }


}