using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SQLite2CEDemo
{
    public class Quest
    {
        private string _Name;

        private string _Content, _Opt;

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
        
      public IEnumerable<Quest> GetResults(Catappdb context)
        {

                
                  return  from eachQue in context.Questions
                          join eachCat in context.Question_categories on eachQue._id equals eachCat.Q_id

                        
                where eachQue._id==490
               
                   select  new  Quest()
                   {
                      Name=eachQue.Header,
                      Content=eachQue.Content,
                   
                   };
               
      }
        public IEnumerable<Quest> GetResults1(Catappdb context)
        {
            
         return from eachOpt in context.Options
         where eachOpt.Q_id==490
        select
       new Quest()
       {
          
          Opt=eachOpt.Content,
         
          
       };
        }





        //public bool a { get; set; }
    }
}