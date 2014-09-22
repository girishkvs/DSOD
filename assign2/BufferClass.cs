using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace assign2
{
    public class BufferClass
    {
        private string bufferCell;

        public void setBuffer(String Value)
        {
            bufferCell = Value;
        }

        public String getBuffer()
        {
            return bufferCell;
        }
    }
}
