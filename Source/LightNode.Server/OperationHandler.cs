﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace LightNode.Server
{
    internal class OperationHandler
    {
        public string MethodName { get; set; }

        public ParameterInfo[] Arguments { get; set; }

        public Type ReturnType { get; set; }

        public HandlerBodyType HandlerBodyType { get; set; }

        // MethodCache Delegate => environment, arguments, returnType

        public Func<IDictionary<string, object>, object[], object> MethodFuncBody { get; set; }

        public Func<IDictionary<string, object>, object[], Task> MethodAsyncFuncBody { get; set; }

        public Action<IDictionary<string, object>, object[]> MethodActionBody { get; set; }

        public Func<IDictionary<string, object>, object[], Task> MethodAsyncActionBody { get; set; }
    }

    internal enum HandlerBodyType
    {
        // 0 is invalid

        Func = 1,
        AsyncFunc = 2,
        Action = 3,
        AsyncAction = 4
    }
}