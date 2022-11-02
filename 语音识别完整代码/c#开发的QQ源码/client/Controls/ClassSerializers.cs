using System;
using System.IO ;

namespace LanMsg 
{
	/// <summary>
	/// ClassSerializers 的摘要说明。
	/// </summary>
	public class ClassSerializers
	{
		public ClassSerializers()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region Binary Serializers
		public   System.IO.MemoryStream SerializeBinary(object request) 
		{
			System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			System.IO.MemoryStream memStream = new System.IO.MemoryStream();
			serializer.Serialize(memStream, request);
			return memStream;
		}

		public   object DeSerializeBinary(System.IO.MemoryStream memStream) 
		{
　			memStream.Position=0;
　			System.Runtime.Serialization.Formatters.Binary.BinaryFormatter deserializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
　			object newobj = deserializer.Deserialize(memStream);
　			memStream.Close();
　			return newobj;
		}
		#endregion

		#region XML Serializers

		public   System.IO.MemoryStream SerializeSOAP(object request) 
		{

　          System.Runtime.Serialization.Formatters.Soap.SoapFormatter serializer = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
　          System.IO.MemoryStream memStream = new System.IO.MemoryStream();
　          serializer.Serialize(memStream, request);
　          return memStream;
		}

		public   object DeSerializeSOAP(System.IO.MemoryStream memStream) 
		{
　			object sr;
　			System.Runtime.Serialization.Formatters.Soap.SoapFormatter deserializer = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
　			memStream.Position=0;
　			sr = deserializer.Deserialize(memStream);
　			memStream.Close();
　			return sr;
		}

		#endregion 


	}
}
