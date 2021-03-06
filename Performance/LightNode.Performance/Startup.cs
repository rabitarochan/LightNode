﻿using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightNode.Performance
{
    public class Startup
    {
        public void Configuration(IAppBuilder appa)
        {
            appa.UseLightNode(new LightNode.Server.LightNodeOptions(Server.AcceptVerbs.Get | Server.AcceptVerbs.Post,
                new LightNode.Formatter.JsonNetContentFormatter()));
        }
    }

    public class Perf : LightNode.Server.LightNodeContract
    {
        public MyClass Echo(string name, int x, int y)
        {
            return new MyClass { Name = name, Sum = x + y };
        }
    }

    public class MyClass
    {
        public string Name { get; set; }
        public int Sum { get; set; }
    }
}