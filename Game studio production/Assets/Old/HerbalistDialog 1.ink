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
}
 ===Introduction2===
 Im busy make it quick
{PartsCompleted:
-0:->Part1
-1:->Part2
}
 ===Introduction3===
 WHAT???
 {PartsCompleted:
-0:->Part1
-1:->Part2  
}

===Part1===
 * Hi, could i have some herbs for my uncle Edmund
   ~ Event(0)
   ~ UseAction()
    ~PartsCompleted++
   Sure have some
   <i> Gain Bag of herbs </i>
 * sorry nothing right now
   well dont inturpt me then

- Bye
    ->End
    
    ===Part2===
    Oh its you again What do you want?
    ~ UseAction()
    ->End
    
    ===End===
    ~TimesSpokenTo++
    ~Save(0,TimesSpokenTo)
    ~Save(1,PartsCompleted)
    ->END