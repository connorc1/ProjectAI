using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 18/03/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *      public virtual void modifyEmotion(Emotion emotion, float amount)
 *      public bool currentEmotion(Emotion emotion)
 */


/*Purpose:
 *      Will be the base for entity emotions.
 *To Use: 
 *      Entity Emotion classes should inherit and use this class
 *To Do: 
 *      Most of this stuff shouldnt be in this class for lesser emotionally evolved creatures (MORE RESEARCH REQUIRED)
 *      MORE RESEARCH REQUIRED
 *      More detail on how to use (Likely to be a long time from now before this file is improved)
 *      Commenting and labelling (Current stage it is only implemented to stop me forgetting what I have planned while working through files)
 *Current Inspirations: 
 *      Plutchik's emotions wheel (and more general theory)
 */
public class EntityEmotions : ScriptableObject {
    protected float Sadness_Joy;
    protected float SadnessMod;
    protected float JoyMod;
    //list of items on both sides

    protected float Anticipation_Surprise;
    protected float AnticipationMod;
    protected float SurpriseMod;
    //list of items on both sides

    protected float Disgust_Trust;
    protected float DisgustMod;
    protected float TrustMod;
    //list of items on both sides

    protected float Fear_Anger;
    protected float FearMod;
    protected float AngerMod; 
    //list of items on both sides

    //Currently cannot handle emotions other than the ones listed, must create way of restricting
    //Also need to add limits
    public virtual void modifyEmotion(Emotion emotion, float amount)
    {
        float finalAmount = amount;
        if (emotion == Emotion.Sadness)
        {
            finalAmount += (amount * SadnessMod);
            Sadness_Joy -= finalAmount;
            if (Sadness_Joy < 0.0f)
            {
                Sadness_Joy = 0.0f;
            }
        }
        else if (emotion == Emotion.Joy)
        {
            finalAmount += (amount * JoyMod);
            Sadness_Joy += finalAmount;
            if (Sadness_Joy > 100.0f)
            {
                Sadness_Joy = 100.0f;
            }
        }
        else if (emotion == Emotion.Anticipation)
        {
            finalAmount += (amount * AnticipationMod);
            Anticipation_Surprise -= finalAmount;
            if (Anticipation_Surprise < 0.0f)
            {
                Anticipation_Surprise = 0.0f;
            }
        }
        else if (emotion == Emotion.Surprise)
        {
            finalAmount += (amount * SurpriseMod);
            Anticipation_Surprise += finalAmount;
            if (Anticipation_Surprise > 100.0f)
            {
                Anticipation_Surprise = 100.0f;
            }
        }
        else if (emotion == Emotion.Disgust)
        {
            finalAmount += (amount * DisgustMod);
            Disgust_Trust -= finalAmount;
            if (Disgust_Trust < 0.0f)
            {
                Disgust_Trust = 0.0f;
            }
        }
        else if (emotion == Emotion.Trust)
        {
            finalAmount += (amount * TrustMod);
            Disgust_Trust += finalAmount;
            if (Disgust_Trust > 100.0f)
            {
                Disgust_Trust = 100.0f;
            }
        }
        else if (emotion == Emotion.Fear)
        {
            finalAmount += (amount * FearMod);
            Fear_Anger -= finalAmount;
            if (Fear_Anger < 0.0f)
            {
                Fear_Anger = 0.0f;
            }
        }
        else if (emotion == Emotion.Anger)
        {
            finalAmount += (amount * AngerMod);
            Fear_Anger += finalAmount;
            if (Fear_Anger > 100.0f)
            {
                Fear_Anger = 100.0f;
            }
        }
    }

    public bool currentEmotion(Emotion emotion)
    {
        //Tiers: 10, 25, 40, 60, 75, 90
        int emInt = (int)emotion;
        //Sadness subset
        if (emInt >= 0 && emInt < 6)
        {

        }
        //Joy subset
        else if (emInt > 5 && emInt < 12)
        {

        }
        //Anticipation subset
        else if (emInt > 11 && emInt < 18)
        {

        }
        //Surprise subset
        else if (emInt > 17 && emInt < 24)
        {

        }
        //Disgust subset
        else if (emInt > 23 && emInt < 30)
        {

        }
        //Trust subset
        else if (emInt > 29 && emInt < 36)
        {

        }
        //Fear subset
        else if (emInt > 35 && emInt < 42)
        {

        }
        //Anger subset
        else if (emInt > 41 && emInt < 48)
        {

        }
        return false;
    }
}

//Current list of emotions, may be expanded or reduced with research
public enum Emotion
{
    Pensiveness, Sadness, Grief,
    Remorse, Envy, Pessimism,           //Sub Sadness
    Serenity, Joy, Ecstacy,
    Love, Guilt, Delight,               //Sub Joy
    Interest, Anticipation, Vigilance,
    Optimism, Hope, Anxiety,            //Sub Anticipation
    Distraction, Surprise, Amazement,
    Disappointment, Unbelief, Outrage,  //Sub Surprise
    Boredom, Disgust, Loathing,
    Contempt, Cynicism, Morbidness,     //Sub Disgust
    Acceptance, Trust, Admiration,
    Submission, Curiosity, Sentimentality, //Sub Trust
    Apprehension, Fear, Terror,
    Awe, Despair, Shame,                //Sub Fear
    Annoyance, Anger, Rage,
    Aggression, Pride, Dominance        //Sub Anger
}
//A copy of the emotion sliders based of of Plutchiks theory
public enum EmotionSlider { SadnessJoy, AnticipationSurprise, DisgustTrust, FearAnger }