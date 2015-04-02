﻿/**
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

using System;
using Org.Apache.REEF.Client.API;
using Org.Apache.REEF.Client.Local;
using Org.Apache.REEF.Driver.Bridge;
using Org.Apache.REEF.Tang.Annotations;
using Org.Apache.REEF.Tang.Implementations.Tang;
using Org.Apache.REEF.Tang.Interface;
using Org.Apache.REEF.Tang.Util;

namespace Org.Apache.REEF.Examples.HelloREEF
{
    /// <summary>
    /// A Tool that submits HelloREEFDriver for execution.
    /// </summary>
    public sealed class HelloREEF
    {
        private const string Local = "local";
        private readonly IREEFClient _reefClient;

        [Inject]
        private HelloREEF(IREEFClient reefClient)
        {
            _reefClient = reefClient;
        }

        /// <summary>
        /// Runs HelloREEF using the IREEFClient passed into the constructor.
        /// </summary>
        private void Run()
        {
            // The driver configuration contains all the needed bindings.
            var helloDriverConfiguration = DriverBridgeConfiguration.ConfigurationModule
                .Set(DriverBridgeConfiguration.OnEvaluatorRequested, GenericType<HelloDriver>.Class)
                .Set(DriverBridgeConfiguration.OnEvaluatorAllocated, GenericType<HelloDriver>.Class)
                .Set(DriverBridgeConfiguration.OnDriverStarted, GenericType<HelloDriver>.Class)
                .Build();
            // The JobSubmission contains the Driver configuration as well as the files needed on the Driver.
            var helloJobSubmission = new JobSubmission()
                .AddDriverConfiguration(helloDriverConfiguration)
                .AddGlobalAssemblyForType(typeof(HelloDriver))
                .SetJobIdentifier("HelloREEF");

            _reefClient.Submit(helloJobSubmission);
        }

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static IConfiguration GetRuntimeConfiguration(string name)
        {
            switch (name)
            {
                case Local:
                    return LocalRuntimeClientConfiguration.ConfigurationModule
                        .Set(LocalRuntimeClientConfiguration.NumberOfEvaluators, "2")
                        .Build();
                default:
                    throw new Exception("Unknown runtime: " + name);
            }
        }

        public static void Main(string[] args)
        {
            TangFactory.GetTang().NewInjector(GetRuntimeConfiguration(args[0])).GetInstance<HelloREEF>().Run();
        }
    }
}