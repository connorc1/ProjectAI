using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 27/03/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* ### Inherited Items ###
 *  protected int setStage;
 */
/* Public Functions & Variables: 
 *
 */

//
public class HumanPsyche : EntityPsyche {
    protected HumanEmotions emotions;
    //List<ArcheTypes> archetypes, figure out how to best approach

    public void getBehaviour()
    {

    }

    public void saveHumanData(ref HumanSave save)
    {
        emotions.saveHumanData(ref save);
        save.setStage = setStage;
    }
    public HumanPsyche(HumanSave load)
    {
        emotions = new HumanEmotions(load);
        setStage = load.setStage;
    }
    public HumanPsyche()
    {
        emotions = new HumanEmotions();
        setStage = -1;
    }
}
