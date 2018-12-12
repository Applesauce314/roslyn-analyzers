﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.PointsToAnalysis
{
    using PointsToAnalysisResult = DataFlowAnalysisResult<PointsToBlockAnalysisResult, PointsToAbstractValue>;

    internal partial class PointsToAnalysis : ForwardDataFlowAnalysis<PointsToAnalysisData, PointsToAnalysisContext, PointsToAnalysisResult, PointsToBlockAnalysisResult, PointsToAbstractValue>
    {
        /// <summary>
        /// An abstract analysis domain implementation for <see cref="PointsToAnalysisData"/> tracked by <see cref="PointsToAnalysis"/>.
        /// </summary>
        private sealed class PointsToAnalysisDomain : PredicatedAnalysisDataDomain<PointsToAnalysisData, PointsToAbstractValue>
        {
            public PointsToAnalysisDomain(DefaultPointsToValueGenerator defaultPointsToValueGenerator)
                : base(new CorePointsToAnalysisDataDomain(defaultPointsToValueGenerator, PointsToAbstractValueDomainInstance))
            {
            }

            public PointsToAnalysisData MergeAnalysisDataForBackEdge(
                PointsToAnalysisData forwardEdgeAnalysisData,
                PointsToAnalysisData backEdgeAnalysisData,
                Func<PointsToAbstractValue, IEnumerable<AnalysisEntity>> getChildAnalysisEntities,
                Action<AnalysisEntity, PointsToAnalysisData> resetAbstractValue)
            {
                if (!forwardEdgeAnalysisData.IsReachableBlockData && backEdgeAnalysisData.IsReachableBlockData)
                {
                    return (PointsToAnalysisData)backEdgeAnalysisData.Clone();
                }
                else if (!backEdgeAnalysisData.IsReachableBlockData && forwardEdgeAnalysisData.IsReachableBlockData)
                {
                    return (PointsToAnalysisData)forwardEdgeAnalysisData.Clone();
                }

                Debug.Assert(forwardEdgeAnalysisData.IsReachableBlockData == backEdgeAnalysisData.IsReachableBlockData);

                var mergedCoreAnalysisData = ((CorePointsToAnalysisDataDomain)CoreDataAnalysisDomain).MergeCoreAnalysisDataForBackEdge(
                    forwardEdgeAnalysisData,
                    backEdgeAnalysisData,
                    getChildAnalysisEntities,
                    resetAbstractValue);
                return new PointsToAnalysisData(mergedCoreAnalysisData, forwardEdgeAnalysisData,
                    backEdgeAnalysisData, forwardEdgeAnalysisData.IsReachableBlockData, CoreDataAnalysisDomain,
                    forwardEdgeAnalysisData.IsLValueFlowCaptureEntity);
            }
        }
    }
}