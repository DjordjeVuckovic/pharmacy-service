// File:    FileHandler.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:51:58 PM
// Purpose: Definition of Class FileHandler

using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TechHealth.Repository
{
   public class FileHandler
   {
      private string filePath;
      
      public void Serialize(string path, object data)
      {
         JsonSerializer jsonSerializer = new JsonSerializer();
         StreamWriter sw = new StreamWriter(path);
         JsonWriter jsonWriter = new JsonTextWriter(sw);
         jsonSerializer.Serialize(jsonWriter, data);
         jsonWriter.Close();
         sw.Close();
      }
      
      public object Deserialize(string path,Type dataType)
      {
         JObject jObject = null;
         JsonSerializer jsonSerializer = new JsonSerializer();
         if (File.Exists(path))
         {
            StreamReader sr = new StreamReader(filePath);
            JsonReader jsonReader = new JsonTextReader(sr);
            jObject = jsonSerializer.Deserialize(jsonReader) as JObject;
            jsonReader.Close();
            sr.Close();
         }

         return jObject.ToObject(dataType);
      }
   
   }
}