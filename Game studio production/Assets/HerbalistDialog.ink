EXTERNAL Event(ID)
EXTERNAL UseAction()
EXTERNAL Save(Item,Value)

VAR TimesSpokenTo = 0
VAR PartsCompleted =0
{TimesSpokenTo:
-0:->Introduction1
-1:->Introduction2
--> Introduction3
}

 //-> Part
 
 ===Introduction1===
 Hello there small one im the herbalist what do you need,
 
{PartsCompleted:
-0:->Part1
-1:->Part2
-2:-> Part3
}
 ===Introduction2===
 Here you go, i found some herbs for you
 .......
 hey, i see you looking out that window 
 its bets not to worry.
 What will be will be but we’ll still be here
{PartsCompleted:
-0:->Part1
-1:->Part2
-2:-> Part3
}
 ===Introduction3===
 Im busy make it quick
 {PartsCompleted:
-0:->Part1
-1:->Part2 
-2:->Part3 
}

===Part1===
 * Hi, could i have some herbs for my uncle Edmund
    ~PartsCompleted++
   Hmmm, with the harsh winter were having. its probably to cold for many herbs to be growing
   i guess i could have a look for you though. 
   wait here for a moment.
 * sorry nothing right now
   well dont inturpt me then

- Bye
    ->End
    
    ===Part2===
    > Gain a parcel of herbs < 
    ~Event(11)
    ~PartsCompleted++
    ~ UseAction()
    ->End
    === Part3
    get going then 
    ->End
    ===End===
    ~TimesSpokenTo++
    ~Save(0,TimesSpokenTo)
    ~Save(1,PartsCompleted)
    ->END