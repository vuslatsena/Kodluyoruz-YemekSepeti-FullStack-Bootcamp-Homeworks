using System;

namespace CleanCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

#region Boolean Expressions
//example
if (health < 5){
    isHurt = true;
}else{
    isHurt = false;
}
       
// Rest of your game's the code goes here
      
if(isHurt){
    playerStatus = "You're badly hurt!";
}else{
    playerStatus = "You're cool dude";
}
//If we have an if statement with only one line of code in the decision, 
//we can remove the curly braces.

if (health < 5) isHurt = true;
else isHurt = false;
//The rest of your game's code goes here
if(isHurt) playerStatus = "You're badly hurt!";
else playerStatus = "You're cool dude";
#endregion Boolean Expressions

#region  Be Positive
//Choose positive expressions
if(!isNotUser) // not optional

if(isUser)// optional
#endregion Be Positive

#region Ternary IF
//Here we show you the promotion
//if the Employe's working hours are more than 60 hours.
int promotion;

if (employee.workhour > 50)
{
  promotion = 5000;
}
else
{
  promotion = 2500;
}

//clean code version
int promotion = employee.workhour > 50 ? 5000 : 2500;

#endregion Ternary IF

#region StronglyType
//Use strongly type, not stringly type
if(movieType =="Horror"){}

if(MovieType == movieType.Horror){}
#endregion StronglyType


        }
    }
}
