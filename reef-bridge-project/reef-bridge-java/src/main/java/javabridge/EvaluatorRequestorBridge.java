/**
 * Copyright (C) 2013 Microsoft Corporation
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *         http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package javabridge;

import com.microsoft.reef.driver.evaluator.EvaluatorRequest;
import com.microsoft.reef.driver.evaluator.EvaluatorRequestor;

import java.util.logging.Level;
import java.util.logging.Logger;

public class EvaluatorRequestorBridge {
    private static final Logger LOG = Logger.getLogger(EvaluatorRequestorBridge.class.getName());

    // accumulate how many evaluators have been submitted through this instance
    // of EvaluatorRequestorBridge
    private int clrEvaluatorsNumber;

    private EvaluatorRequestor jevaluatorRequestor;

    public EvaluatorRequestorBridge(EvaluatorRequestor evaluatorRequestor)
    {
        jevaluatorRequestor = evaluatorRequestor;
        clrEvaluatorsNumber = 0;
    }

    public void submit( final int evaluatorsNumber, final int memory)
    {
      clrEvaluatorsNumber += evaluatorsNumber;
       EvaluatorRequest request = EvaluatorRequest.newBuilder()
                .setNumber(evaluatorsNumber)
                .setMemory(memory)
                .build();
        LOG.log(Level.INFO, "========= submitting " + evaluatorsNumber);
        jevaluatorRequestor.submit(request);
    }

    public int getEvaluatorNumber() {
        return clrEvaluatorsNumber;
    }
}