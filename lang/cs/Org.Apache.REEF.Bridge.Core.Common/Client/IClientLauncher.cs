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
using Org.Apache.REEF.Tang.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Org.Apache.REEF.Bridge.Core.Common.Client
{
    /// <inheritdoc />
    /// <summary>
    /// All client launchers implement this interface. Multiple jobs can be submitted until the
    /// launcher has been disposed <see cref="T:System.IDisposable" />
    /// </summary>
    public interface IClientLauncher : IDisposable
    {
        Task<LauncherStatus> SubmitAsync(
            IConfiguration driverAppConfiguration,
            CancellationToken cancellationToken = default);
    }
}