﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the base class that handles any interaction with the enemy player or environment (hitboxes, projectiles, environmental traps, etc)
/// </summary>
public class InteractionHandler : MonoBehaviour
{

    #region const variables

    private const string HITSTUN_TRIGGER = "Hitstun";

    #endregion

    #region main variables

    public Animator Animator { get; private set; }

    public CharacterStats CharacterStats { get; private set; }

    public HashSet<InteractionHandler> CharactersHit { get; private set; }

    [SerializeField]
    private List<MoveData> CharacterMoves;

    private Dictionary<string, MoveData> CharacterMoveDict;

    private string AnimatorClipName
    {
        get
        {
            return Animator != null ? Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name : "idle";
        }
    }

    public MoveData CurrentMove
    {
        get
        {
            return Animator != null && CharacterMoveDict.ContainsKey(AnimatorClipName) ? CharacterMoveDict[AnimatorClipName] : default;
        }
    }

    #region Interaction Data

    // Has the last move we activated already hit a player
    public bool MoveHitPlayer;

    public int Hitstun;

    #endregion

    #endregion

    #region monobehaviour methods

    public void OnMoveBegin()
    {
        CharactersHit.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        CharacterStats = GetComponent<CharacterStats>();
       
       

        CharactersHit = new HashSet<InteractionHandler>();
        CharacterMoveDict = new Dictionary<string, MoveData>();
        foreach(MoveData move in CharacterMoves)
        {
            CharacterMoveDict.Add(move.MoveName, move);
        }
    }

    #endregion

    #region public methods

    public void OnHitByEnemy(Hitbox myHurtbox, Hitbox enemyHitbox, MoveData currentMove)
    {

        //TODO Get current active move from animation and command interpreter.
        //CharacterStats.OnPlayerHitByEnemy(myHurtbox, enemyHitbox, currentMove);

        if (currentMove.OnHitFrames > 0)
        {
            Hitstun += currentMove.OnHitFrames;
            Animator.SetBool(HITSTUN_TRIGGER, true);
            Animator.SetTrigger(currentMove.Magnitude.ToString());
            StartCoroutine(HandleHitstun());
        }
    }

    public void OnHitEnemy(Hitbox myHitbox, Hitbox enemyHurtbox)
    {
        //TODO Get current active move from animation and command interpreter. Pass null for now.
        //CharacterStats.OnPlayerHitEnemy(myHitbox, enemyHurtbox, CurrentMove);
        MoveHitPlayer = true;
    }

    public void OnClash(Hitbox enemyHitbox)
    {

    }

    #endregion

    #region private methods

    private IEnumerator HandleHitstun()
    {

        while (Hitstun > 0)
        {
            --Hitstun;
            yield return new WaitForEndOfFrame();
        }

        Animator.SetBool(HITSTUN_TRIGGER, false);
    }
    
    #endregion

    #region structs

    [System.Serializable]
    public struct MoveData
    {

        public string MoveName;

        public enum HitMagnitude
        {
            LightHit,
            MediumHit,
            HeavyHit
        };

        public HitMagnitude Magnitude;

        public float OnGuardDamage;
        public int OnGuardFrames;
        public Vector2 OnGuardKnockback;

        public float OnHitDamage;
        public int OnHitFrames;
        public Vector2 OnHitKnockback;

        public bool GuardBreak;

        // Allows the hitbox to register multiple hits on the opposing player in the same move.
        // Ex. A projectile may register as two hits when it connects with an opponent,
        // but a standing medium punch usually should not do the same.
        public bool AllowMultiHit;

    }
    
    #endregion
}
