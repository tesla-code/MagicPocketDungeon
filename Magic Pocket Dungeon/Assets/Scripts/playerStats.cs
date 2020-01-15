using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStats : entity
{
    public Texture2D heartTexture;
    public Texture2D orbTexture;
    public Texture2D lifeTexture;
    public int maxHP = 3;
    public int maxLives = 3;

    private int OrbCount;
    private int LifeCount;
    //the total orbs collected throughout the game, tallied up after each level. displayed on the world map.
    public int totalOrbs;
    //the orbs carried from level to level, your actual orb count. Upon overworld visits and gameovers, make this your current orbs. Upon regular deaths add collected orbs and make that your currents orbs
    public int REALOrbs;
    //the current orbs OBTAINED in a level, since last checkpoint. gets added to totalorbs after a level is beat. DOES NOT COUNT ALREADY COLLECTED ORBS. Only add per checkpoint.
    private int checkpointOrbs;
    //collected orbs is reset per level, orbcount isn't.
    private int collectedOrbs;
    // Start is called before the first frame update
    void Start()
    {
        OrbCount = 0;
        REALOrbs = OrbCount;
        LifeCount = 3;
        //Healthbar/hearts
        HP = 3;
    }
    //orbs
    public void IncreaseOrbs() {
        ++OrbCount;
        ++collectedOrbs;
    }
    public void DecreaseOrbs() {
        --OrbCount;
    }
    public void DeadOrbReset(){
        //reset the orb count to what you had at your last checkpoint.
        OrbCount = checkpointOrbs;
    }
    public void GameOverQuitOrbReset(){
        //reset the orb count to what you had when you went in.
        OrbCount = REALOrbs;
        checkpointOrbs = 0;
        collectedOrbs = 0;
    }
    //used on the map to tally your collection
    public void TallyOrbs(){
        //add the collected orbs to your total
        totalOrbs += checkpointOrbs;
        //set your realorbs to be whatever you had when you finished the level
        REALOrbs = OrbCount;
        checkpointOrbs = 0;
        collectedOrbs = 0;
    }
    //set the collected orbs per 'checkpoint'
    public void SetCollectedOrbs()
    {
        //I need sleep 
        checkpointOrbs = OrbCount;
    }
    public int GetTotalOrbs()
    {
        return totalOrbs + collectedOrbs;
    }

    //lives
    public int GetOrbs() {
        return OrbCount;

    }
    public void IncreaseLives() {
        ++LifeCount;
    }
    public void DecreaseLives() {
        --LifeCount;
    }
    public int GetLives() {
        return LifeCount;
    }
    public int GetMaxLives()
    {
        return maxLives;
    }
    //HP
    public void IncreaseHP() {
        ++HP;
    }
    public int GetHP() {
        return HP;
    }
    public int GetMaxHP()
    {
        return maxHP;
    }

    void OnGUI() {
        for (int i = 1; i <= HP; i++) {
            GUI.DrawTexture(new Rect((i * 50), 20, 50, 50), heartTexture);
        }
        GUI.DrawTexture(new Rect(20, 60, 50, 50), orbTexture);
        GUI.Label(new Rect(80, 70, 50, 50), GetOrbs().ToString());
        GUI.DrawTexture(new Rect(20, 90, 50, 50), lifeTexture);
        GUI.Label(new Rect(80, 100, 50, 50), GetLives().ToString());
    }
}
