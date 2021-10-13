using Stream;

namespace Master
{
	public class CollisionData
	{
		public int SkillId { get; private set; }
		public float SpawnTime { get; private set; }
		public float LifeTime { get; private set; }
		public float Radius { get; private set; }
		public int Power { get; private set; }
		public int ReactionType { get; private set; }
		public float ReactionPower { get; private set; }
		public float OffsetX { get; private set; }
		public float OffsetY { get; private set; }
		public float OffsetZ { get; private set; }

		public void Serialize(IMemoryStream stream)
		{
			int SkillId = new int();
			stream.Serialize(ref SkillId);
			this.SkillId = SkillId;
			float SpawnTime = new float();
			stream.Serialize(ref SpawnTime);
			this.SpawnTime = SpawnTime;
			float LifeTime = new float();
			stream.Serialize(ref LifeTime);
			this.LifeTime = LifeTime;
			float Radius = new float();
			stream.Serialize(ref Radius);
			this.Radius = Radius;
			int Power = new int();
			stream.Serialize(ref Power);
			this.Power = Power;
			int ReactionType = new int();
			stream.Serialize(ref ReactionType);
			this.ReactionType = ReactionType;
			float ReactionPower = new float();
			stream.Serialize(ref ReactionPower);
			this.ReactionPower = ReactionPower;
			float OffsetX = new float();
			stream.Serialize(ref OffsetX);
			this.OffsetX = OffsetX;
			float OffsetY = new float();
			stream.Serialize(ref OffsetY);
			this.OffsetY = OffsetY;
			float OffsetZ = new float();
			stream.Serialize(ref OffsetZ);
			this.OffsetZ = OffsetZ;
		}

		public static CollisionData[] SerializeAll(byte[] buffer)
		{
			MemoryStreamReader reader = new MemoryStreamReader(buffer);
			int size = 0;
			reader.Serialize(ref size);
			CollisionData[] datas = new CollisionData[size];
			for (int i = 0; i < size; i++)
			{
				CollisionData data = new CollisionData();
				data.Serialize(reader);
				datas[i] = data;
			}
			return datas;
		}
	}
}
