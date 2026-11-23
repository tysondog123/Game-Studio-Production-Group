EXTERNAL Event(ID)
EXTERNAL CheckLocked(ID)
EXTERNAL UseAction()
EXTERNAL Save(Item,Value)

VAR TimesSpokenTo = 0
VAR PartsCompleted =0
VAR Locked =0
{TimesSpokenTo:
-0:->Introduction1
--> Introduction2

}

 //-> Part
 
 ===Introduction1===
 Oh hi champ.
 
{PartsCompleted:
-0:->Part1
-1:->Part2
}
 ===Introduction2===
 {PartsCompleted:
 -2: ->Introduction3
}
 Come on then, the mess wont clean itself.
{PartsCompleted:
-0:->Part1
-1:->Part2
}
 ===Introduction3===
 You done upstairs already
->Part3

===Part1===
i was wondering could you help me clean up some of the tables and rooms in here, its a bit of a mess and i quite busy?

 * Ofcourse
   ~ Event(4)
   ~ UseAction()
   ~PartsCompleted++
     Thanks
 * sorry not right now
     Oh come on, do it for me
     ** Okay
         i knew i could trust you
        
     

-->End
    
 ===Part2===
 ~ CheckLocked(5)
 {Locked:
 -0: -> P2locked
 -1: -> P2Unlocked
 }
 ===P2locked
    * Okay
      ->End
 ===P2Unlocked
    * Ive already cleand the tables, im going to go upstairs now
       oh, look at that you have
       great Job
      ~Event(6)
      ~PartsCompleted++
-->End
===Part3
~CheckLocked(7)
{Locked:
-0: ->P3Locked
-1: ->P3Unlocked
}

===P3Locked
* no not yet
  oh, whats the hold up then?
  ->End
===P3Unlocked
  * no, not yet
      oh, whats the hold up then?
      ->End
  * Yes, Im done
         Wonderfull, could i just ask  or one more thing.
         could you go to the herbalist to pick up some herbs for my cider im running low
             **Ofcourse 
             
             **No
                 Come on stop joking with me.
                  ***okay 
      
-Brilliant, thanks 
~Event(9)
~PartsCompleted++
->End
    
    ===End===
    ~TimesSpokenTo++
    ~Save(0,TimesSpokenTo)
    ~Save(1,PartsCompleted)
    ->END