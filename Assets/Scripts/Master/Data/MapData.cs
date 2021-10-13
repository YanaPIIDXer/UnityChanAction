using Stream;

namespace Master
{
	public class MapData
	{
		public int Id { get; private set; }
		public string FileName { get; private set; }
		public float StartX { get; private set; }
		public float StartY { get; private set; }
		public float StartZ { get; private set; }
		public float StartRotation { get; private set; }

		public void Serialize(IMemoryStream stream)
		{
			int Id = new int();
			stream.Serialize(ref Id);
			this.Id = Id;
			string FileName = "";
			stream.Serialize(ref FileName);
			this.FileName = FileName;
			float StartX = new float();
			stream.Serialize(ref StartX);
			this.StartX = StartX;
			float StartY = new float();
			stream.Serialize(ref StartY);
			this.StartY = StartY;
			float StartZ = new float();
			stream.Serialize(ref StartZ);
			this.StartZ = StartZ;
			float StartRotation = new float();
			stream.Serialize(ref StartRotation);
			this.StartRotation = StartRotation;
		}

		public static MapData[] SerializeAll(byte[] buffer)
		{
			MemoryStreamReader reader = new MemoryStreamReader(buffer);
			int size = 0;
			reader.Serialize(ref size);
			MapData[] datas = new MapData[size];
			for (int i = 0; i < size; i++)
			{
				MapData data = new MapData();
				data.Serialize(reader);
				datas[i] = data;
			}
			return datas;
		}
	}
}
