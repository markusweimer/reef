/*
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
package org.apache.reef.wake.impl;

import org.apache.reef.wake.EventHandler;

import javax.inject.Inject;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * A logging event handler.
 *
 * @param <T> type
 */
public class LoggingEventHandler<T> implements EventHandler<T> {
  private static final Logger LOG = Logger.getLogger(LoggingEventHandler.class.getName());

  @Inject
  public LoggingEventHandler() {
  }

  /**
   * Logs the event.
   *
   * @param value an event
   */
  @Override
  public void onNext(final T value) {
    LOG.log(Level.FINE, "{0}", value);
  }

}
