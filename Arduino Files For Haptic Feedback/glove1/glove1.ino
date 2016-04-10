void setup() {
  // put your setup code here, to run once:
   Serial.begin(9600);
   pinMode(8,OUTPUT);
   pinMode(9,OUTPUT);
   pinMode(10,OUTPUT);


   while(!Serial)
    digitalWrite(8,LOW);
    digitalWrite(9,LOW);
    digitalWrite(10,LOW);
  
  
}


void loop () {
  char getChare = ' ';
  if (Serial.available() > 0)
  {
     getChare = Serial.read();
     
      if( getChare == '1')
        {  digitalWrite(8,HIGH);
           digitalWrite(9,HIGH);
           digitalWrite(10,HIGH);
          //delay(100);
        }
      if ( getChare == '0' )
      {
        digitalWrite(8,LOW);
        digitalWrite(9,LOW);
        digitalWrite(10,LOW);
          //delay(100);
        } 
       
  }
   
}



 



