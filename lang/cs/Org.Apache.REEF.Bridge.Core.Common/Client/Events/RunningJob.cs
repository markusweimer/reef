﻿// Licensed to the Apache Software Foundation (ASF) under one
// or more contributor license agreements.  See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership.  The ASF licenses this file
// to you under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in compliance
// with the License.  You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.

using Org.Apache.REEF.Common.Client;

namespace Org.Apache.REEF.Bridge.Core.Common.Client.Events
{
    internal sealed class RunningJob : IRunningJob
    {
        private readonly IClientService _clientService;

        public RunningJob(IClientService clientService, string jobId)
        {
            _clientService = clientService;
            Id = jobId;
        }

        public string Id { get; }

        public void Dispose()
        {
            _clientService.Close();
        }

        public void Dispose(byte[] message)
        {
            _clientService.Close(message);
        }

        public void Send(byte[] message)
        {
            _clientService.Send(message);
        }
    }
}