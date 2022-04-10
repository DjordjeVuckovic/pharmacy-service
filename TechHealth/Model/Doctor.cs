
using System;

namespace TechHealth.Model
{
   
   public class Doctor : Person
   {
      public string ToString()
      {
         return Name +" "+ Surname;
      }
   }
}