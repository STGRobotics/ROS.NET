using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Uml.Robotics.Ros;

namespace Messages.std_msgs
{
    public class Time : RosMessage
    {

        public TimeData data = new TimeData();


        public override string MD5Sum() { return "cd7166c74c552c311fbcc2fe5a7bc289"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"time data"; }
        public override string MessageType { get { return "std_msgs/Time"; } }
        public override bool IsServiceComponent() { return false; }

        public Time()
        {

        }

        public Time(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public Time(byte[] serializedMessage, ref int currentIndex)
        {
            Deserialize(serializedMessage, ref currentIndex);
        }


        public Time(TimeData d)
        {
            data = d;
        }


        public override void Deserialize(byte[] serializedMessage, ref int currentIndex)
        {

            //data
            data.sec = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            data.nsec = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
        }

        public override byte[] Serialize(bool partofsomethingelse)
        {
            List<byte[]> pieces = new List<byte[]>();

            //data
            pieces.Add(BitConverter.GetBytes(data.sec));
            pieces.Add(BitConverter.GetBytes(data.nsec));
            // combine every array in pieces into one array and return it
            int __a_b__f = pieces.Sum((__a_b__c) => __a_b__c.Length);
            int __a_b__e = 0;
            byte[] __a_b__d = new byte[__a_b__f];
            foreach (var __p__ in pieces)
            {
                Array.Copy(__p__, 0, __a_b__d, __a_b__e, __p__.Length);
                __a_b__e += __p__.Length;
            }
            return __a_b__d;
        }

        public override void Randomize()
        {
            Random rand = new Random();

            //data
            data.sec = Convert.ToInt32(rand.Next());
            data.nsec = Convert.ToInt32(rand.Next());
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
                return false;
            bool ret = true;
            var other = ____other as Messages.std_msgs.Time;
            if (other == null)
                return false;
            ret &= data.Equals(other.data);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
