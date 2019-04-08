using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 27//03/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* ### Inherited Items ###
 *  protected float Sadness_Joy;
 *  protected float SadnessMod;
 *  protected float JoyMod;
 *  
 *  protected float Anticipation_Surprise;
 *  protected float AnticipationMod;
 *  protected float SurpriseMod;
 *  
 *  protected float Disgust_Trust;
 *  protected float DisgustMod;
 *  protected float TrustMod;
 *  
 *  protected float Fear_Anger;
 *  protected float FearMod;
 *  protected float AngerMod; 
 *  
 *  public virtual void modifyEmotion(Emotion emotion, float amount)
 *  public bool currentEmotion(Emotion emotion)
 */
/* Public Functions & Variables: 
*
*/

/*Purpose: 
 *      Holds the emotions of the human. This will be used in altering the human behaviour scripts
 *To Use: 
 *      TBD
 *To Do:
 *      Properly flesh out and get working. Then research.
 */
public class HumanEmotions : EntityEmotions {
    float SJLower; float SJLowerLimit;
    float SJUpper; float SJUpperLimit;

    float ASLower; float ASLowerLimit;
    float ASUpper; float ASUpperLimit;

    float DTLower; float DTLowerLimit;
    float DTUpper; float DTUpperLimit;

    float FALower; float FALowerLimit;
    float FAUpper; float FAUpperLimit;

    //bool introversion;
    //bool extroversion;  //possibility to be both though unlikely

    public override void modifyEmotion(Emotion emotion, float amount)
    {
        float finalAmount = amount;
        if (emotion == Emotion.Sadness)
        {
            finalAmount += (amount * SadnessMod);
            Sadness_Joy -= finalAmount;
            if (Sadness_Joy < SJLowerLimit)
            {
                Sadness_Joy = SJLowerLimit;
            }
        }
        else if (emotion == Emotion.Joy)
        {
            finalAmount += (amount * JoyMod);
            Sadness_Joy += finalAmount;
            if (Sadness_Joy > SJUpperLimit)
            {
                Sadness_Joy = SJUpperLimit;
            }
        }
        else if (emotion == Emotion.Anticipation)
        {
            finalAmount += (amount * AnticipationMod);
            Anticipation_Surprise -= finalAmount;
            if (Anticipation_Surprise < ASLowerLimit)
            {
                Anticipation_Surprise = ASLowerLimit;
            }
        }
        else if (emotion == Emotion.Surprise)
        {
            finalAmount += (amount * SurpriseMod);
            Anticipation_Surprise += finalAmount;
            if (Anticipation_Surprise > ASUpperLimit)
            {
                Anticipation_Surprise = ASUpperLimit;
            }
        }
        else if (emotion == Emotion.Disgust)
        {
            finalAmount += (amount * DisgustMod);
            Disgust_Trust -= finalAmount;
            if (Disgust_Trust < DTLowerLimit)
            {
                Disgust_Trust = DTLowerLimit;
            }
        }
        else if (emotion == Emotion.Trust)
        {
            finalAmount += (amount * TrustMod);
            Disgust_Trust += finalAmount;
            if (Disgust_Trust > DTUpperLimit)
            {
                Disgust_Trust = DTUpperLimit;
            }
        }
        else if (emotion == Emotion.Fear)
        {
            finalAmount += (amount * FearMod);
            Fear_Anger -= finalAmount;
            if (Fear_Anger < FALowerLimit)
            {
                Fear_Anger = FALowerLimit;
            }
        }
        else if (emotion == Emotion.Anger)
        {
            finalAmount += (amount * AngerMod);
            Fear_Anger += finalAmount;
            if (Fear_Anger > FAUpperLimit)
            {
                Fear_Anger = FAUpperLimit;
            }
        }
    }

    public void saveHumanData(ref HumanSave save)
    {
        save.Sadness_Joy = Sadness_Joy;
        save.SadnessMod = SadnessMod;
        save.JoyMod = JoyMod;
        save.SJLower = SJLower;
        save.SJLowerLimit = SJLowerLimit;
        save.SJUpper = SJUpper;
        save.SJUpperLimit = SJUpperLimit;

        save.Anticipation_Surprise = Anticipation_Surprise;
        save.AnticipationMod = AnticipationMod;
        save.SurpriseMod = SurpriseMod;
        save.ASLower = ASLower;
        save.ASLowerLimit = ASLowerLimit;
        save.ASUpper = ASUpper;
        save.ASUpperLimit = ASUpperLimit;

        save.Disgust_Trust = Disgust_Trust;
        save.DisgustMod = DisgustMod;
        save.TrustMod = TrustMod;
        save.DTLower = DTLower;
        save.DTLowerLimit = DTLowerLimit;
        save.DTUpper = DTUpper;
        save.DTUpperLimit = DTUpperLimit;

        save.Fear_Anger = Fear_Anger;
        save.FearMod = FearMod;
        save.AngerMod = AngerMod;
        save.FALower = FALower;
        save.FALowerLimit = FALowerLimit;
        save.FAUpper = FAUpper;
        save.FAUpperLimit = FAUpperLimit;
    }
    public HumanEmotions(HumanSave load)
    {
        Sadness_Joy = load.Sadness_Joy;
        SadnessMod = load.SadnessMod;
        JoyMod = load.JoyMod;
        SJLower = load.SJLower;
        SJLowerLimit = load.SJLowerLimit;
        SJUpper = load.SJUpper;
        SJUpperLimit = load.SJUpperLimit;

        Anticipation_Surprise = load.Anticipation_Surprise;
        AnticipationMod = load.AnticipationMod;
        SurpriseMod = load.SurpriseMod;
        ASLower = load.ASLower;
        ASLowerLimit = load.ASLowerLimit;
        ASUpper = load.ASUpper;
        ASUpperLimit = load.ASUpperLimit;

        Disgust_Trust = load.Disgust_Trust;
        DisgustMod = load.DisgustMod;
        TrustMod = load.TrustMod;
        DTLower = load.DTLower;
        DTLowerLimit = load.DTLowerLimit;
        DTUpper = load.DTUpper;
        DTUpperLimit = load.DTUpperLimit;

        Fear_Anger = load.Fear_Anger;
        FearMod = load.Fear_Anger;
        AngerMod = load.AngerMod;
        FALower = load.FALower;
        FALowerLimit = load.FALowerLimit;
        FAUpper = load.FAUpper;
        FAUpperLimit = load.FAUpperLimit;
    }
    public HumanEmotions()
    {
        Sadness_Joy = 50.0f;
        SadnessMod = 0.0f;
        JoyMod = 0.0f;
        SJLower = 0.0f;
        SJLowerLimit = 0.0f;
        SJUpper = 0.0f;
        SJUpperLimit = 100.0f;

        Anticipation_Surprise = 50.0f;
        AnticipationMod = 0.0f;
        SurpriseMod = 0.0f;
        ASLower = 0.0f;
        ASLowerLimit = 100.0f;
        ASUpper = 0.0f;
        ASUpperLimit = 100.0f;

        Disgust_Trust = 50.0f;
        DisgustMod = 0.0f;
        TrustMod = 0.0f;
        DTLower = 0.0f;
        DTLowerLimit = 100.0f;
        DTUpper = 0.0f;
        DTUpperLimit = 100.0f;

        Fear_Anger = 50.0f;
        FearMod = 0.0f;
        AngerMod = 0.0f;
        FALower = 0.0f;
        FALowerLimit = 100.0f;
        FAUpper = 0.0f;
        FAUpperLimit = 100.0f;
    }
}
