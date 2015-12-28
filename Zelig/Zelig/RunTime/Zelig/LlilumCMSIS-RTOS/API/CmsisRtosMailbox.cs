﻿//
// Copyright (c) Microsoft Corporation.    All rights reserved.
//

namespace Microsoft.Zelig.LlilumOSAbstraction.CmsisRtos
{
    using System;
    using System.Collections;
    using Microsoft.Zelig.Runtime;
    using Microsoft.Zelig.Runtime.TypeSystem;
    
    

    internal class CmsisRtosMailbox : CmsisObject
    {
        private readonly KernelCircularBuffer<UIntPtr> m_buffer;

        //--//

        public static CmsisRtosMailbox Create(int queueSize)
        {
            return new CmsisRtosMailbox(queueSize);
        }
        
        private CmsisRtosMailbox(int queueSize)
        {
            m_buffer = new KernelCircularBuffer<UIntPtr>(queueSize);
        }

        public unsafe bool TryGetMessage(int msTimeout, out UIntPtr message)
        {
            if(m_buffer.DequeueBlocking(msTimeout, out message))
            {
                return true;
            }

            return false;
        }

        public unsafe bool TryPutMessage(UIntPtr message, int msTimeout)
        {
            if(m_buffer.EnqueueBlocking(msTimeout, message))
            {
                return true;
            }

            return false;
        }

        //--//

        [GenerateUnsafeCast]
        internal extern UIntPtr ToPointer();
        
        [GenerateUnsafeCast]
        internal extern static CmsisRtosMailbox ToObject(UIntPtr mutex);
    }
}