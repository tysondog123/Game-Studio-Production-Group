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
 Oh hi champ i was wondering could you help me with something, ive run out of herbs could you run to the herbalist quickly to grab me some?
 
{PartsCompleted:
-0:->Part1
-1:->Part2
}
 ===Introduction2===
 {PartsCompleted:
 -2: ->Introduction3
}
 Oh welcome back did you get those herbs yet
{PartsCompleted:
-0:->Part1
-1:->Part2
}
 ===Introduction3===
 i dont have anything else for you to do toady
->End

===Part1===
 * Ofcourse
   ~ Event(98)
   ~ UseAction()
   ~PartsCompleted++
     Thanks
 * sorry not right now
     Oh come on, do it for me
     ** Okay
         i knew i could trust you
        
     

- Be carefull
    ->End
    
 ===Part2===
 ~ CheckLocked(0)
 {Locked:
 -0: -> P2locked
 -1: -> P2Unlocked
 }
 ===P2locked
    * no
      oh okay well let me know when you have
      ->End
 ===P2Unlocked
    * yes
       great thanks alot
      ~Event(97)
      ~PartsCompleted++
    * no
      oh okay well let me know when you have
-->End
    
    ===End===
    ~TimesSpokenTo++
    ~Save(0,TimesSpokenTo)
    ~Save(1,PartsCompleted)
    ->END