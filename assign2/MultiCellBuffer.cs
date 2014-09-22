using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace assign2
{
    public class MultiCellBuffer
    {
        private static int writeCounter = 0;
        private static int readCounter = 0;
        private static string bufferCellValue;

        public static BufferClass[] multiCellBuffer;

        public static Semaphore writeSemaphore = new Semaphore(3, 3);
        public static Semaphore readSemaphore = new Semaphore(0, 3);
        private static ReaderWriterLockSlim rw = new ReaderWriterLockSlim();

        public static void setOneCell(string orderString)
        {
            try
            {
                writeSemaphore.WaitOne();
                rw.EnterWriteLock();
                try
                {
                    Console.WriteLine("Writing to MultiCell Buffer of index " + writeCounter);
                    multiCellBuffer[writeCounter].setBuffer(orderString);
                    writeCounter++;
                    if (writeCounter == 3)
                        writeCounter = 0;
                }
                finally 
                {
                    rw.ExitWriteLock(); 
                }
                readSemaphore.Release();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while Writing to MultiCell Buffer " + e.Message.ToString());
            }
        }

        public static string getOneCell()
        {
            try
            {
                readSemaphore.WaitOne();
                rw.EnterReadLock();
                try
                {
                    Console.WriteLine("Reading form MultiCell Buffer of index " + readCounter);
                    bufferCellValue = multiCellBuffer[readCounter].getBuffer();
                    readCounter++;
                    if (readCounter == 3)
                        readCounter = 0;
                }
                finally 
                {
                    rw.ExitReadLock();
                }
                writeSemaphore.Release();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception While Reading from MultiCell Buffer " + e.Message.ToString());
            }
            return bufferCellValue;
        }
    }
}
