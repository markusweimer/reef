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

namespace Org.Apache.REEF.Common.Telemetry
{
    public interface IMetrics
    {
        /// <summary>
        /// Creates a system metric.
        /// </summary>
        /// <typeparam name="T">Type of the metric object.</typeparam>
        /// <param name="name">Name of the metric.</param>
        /// <param name="description">Description of the metric.</param>
        /// <param name="keepUpdateHistory">whether to keep a history of updates on this metric.</param>
        /// <returns></returns>
        T CreateAndRegisterMetric<T>(string name, string description, bool keepUpdateHistory)
            where T : MetricBase, new();

        /// <summary>
        /// Method that returns the collection of metric data.
        /// </summary>
        /// <returns></returns>
        IMetricSet GetMetricsData();

        /// <summary>
        /// Extracts the metric object if it has been registered.
        /// </summary>
        /// <param name="name">Name of the metric.</param>
        /// <param name="metric">The registered metric. null if not found.</param>
        /// <returns></returns>
        bool TryGetMetric<T>(string name, out T metric)
            where T : IMetric;
    }
}
