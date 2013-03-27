using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

public class CountryCapitals
{
   
   private string _Name;
   
   private string _Content,_Opt;
      
   
   public string Name
   {
      get
      {
         return _Name;
      }
      set
      {
         _Name = value;
      }
   }
   
   public string Content
   {
      get
      {
         return _Content;
      }
      set
      {
         _Content = value;
      }

   }
   public string Opt
   {
       get
       {
           return _Opt;
       }
       set
       {
           _Opt = value;
       }
   }
   
   public IEnumerable<CountryCapitals> GetResults(Catappdb context)
   {
       return from eachQue in context.Questions
               join eachOpt in context.Options on eachQue._id equals eachOpt.Q_id 
              where eachOpt.Q_id == 490
              select new CountryCapitals
              {
                  Name = eachQue.Name,
                  Content = eachQue.Content 
              };
    /*  return from eachQue in context.Questions
		join eachOpt in context.Options on  new { Condition0 = eachQue._id } equals  new { Condition0 = eachOpt.Q_id} 
		 where eachOpt.Q_id==490
		select new CountryCapitals  {  Name = eachQue.Name,  Content = eachQue.Content};*/
   }
}

