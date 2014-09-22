using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace assign2
{
    public class ConfirmationBuffer
    {
        private static int writeCounter = 0;
        private static int readCounter = 0;
        private static string bufferCellValue;

        public static BufferClass[] confirmationBuffer;

        public static Semaphore writeSemaphore = new Semaphore(5, 5);
        public static Semaphore readSemaphore = new Semaphore(0, 5);
        private static ReaderWriterLockSlim rw = new ReaderWriterLockSlim();

        public static void setOneCell(string orderString)
        {
            try
            {
                writeSemaphore.WaitOne();
                rw.EnterWriteLock();
                try
                {
                    Console.WriteLine("Writing to Confirmation Buffer of index " + writeCounter);
                    confirmationBuffer[writeCounter].setBuffer(orderString);
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
                Console.WriteLine("Exception while Writing to Confirmation Buffer " + e.Message.ToString());
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
                    Console.WriteLine("Reading form Confirmation Buffer of index " + readCounter);
                    bufferCellValue = confirmationBuffer[readCounter].getBuffer();
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
                Console.WriteLine("Exception While Reading from Confirmation Buffer " + e.Message.ToString());
            }
            return bufferCellValue;
        }
    }
}
