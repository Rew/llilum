//
// Copyright (c) Microsoft Corporation.    All rights reserved.
//


namespace Microsoft.Zelig.CodeGeneration.IR.CompilationSteps.Phases
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Zelig.Runtime.TypeSystem;


    [PhaseDisabled()]
    [PhaseOrdering( ExecuteAfter=typeof(PrepareForRegisterAllocation) )]
    public sealed class CollectRegisterAllocationConstraints : PhaseDriver
    {
        //
        // Constructor Methods
        //

        public CollectRegisterAllocationConstraints( Controller context ) : base ( context )
        {
        }

        //
        // Helper Methods
        //

        public override PhaseDriver Run()
        {
            PerformParallelExecutionOfPhase( false, true );

            return this.NextPhase;
        }
    }
}
