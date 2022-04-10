// File:    AccountRepository.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:16:56 PM
// Purpose: Definition of Class AccountRepository

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Text.Json;
using System.Windows.Documents;
using TechHealth.Model;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace TechHealth.Repository
{
   public class AccountRepository
   {
      private List<User> users;
      
      public User GetByUsername(string username)
      {
            for (User u : users)
            {
                if (users.Username == username)
                {
                    return u;
                }
            }
      }
      
      public List<User> GetAll()
      {
         return users;
      }

      public void Create(Person person)
      {
            for (Person p : users)
            {
                if (p.Username == person.Username)
                {
                    return false;
                }
            }
            users.add(person);
            return true;
        }

      public bool Update(Person person)
      {
            for (Person p : users)
            {
                if (p.Username == person.Username)
                {
                    p.Address = person.Address;
                    p.Name = person.Name;
                    p.Surname = person.Surname;
                    p.Jmbg = person.Jmbg;
                    p.Address = person.Address;
                    p.Phone = person.Phone;
                    p.Employed = person.Employed;
                    p.Email = person.Email;
                    p.FullName = person.FullName;
                    return true;
                }
            }
            return false;
        }
      
      public bool Delete(string username)
      {
            for (Person p : users)
            {
                if (p.Username == username)
                {
                    users.remove(u);
                    return true;
                }
            }
            return false;
        }
      
      public bool CreateGuest(User user)
      {
            for (User u : users)
            {
                if (u.Username == user.Username)
                {
                    return false;
                }
            }
            users.add(user);
            return true;
        }
      
      public bool DeleteGuest(string userId)
      {
            for (User u : users)
            {
                if (u.Username == userId)
                {
                    users.remove(u);
                    return true;
                }
            }
            return false;
      }
      
      public bool UpdateGuest(User user)
      {
            for (User u : users)
            {
                if (u.Username == user.Username)
                {
                    u.Password = user.Password;
                    return true;
                }
            }
            return false;
        }
      
      public FileHandler fileHandler;
   
   }
}