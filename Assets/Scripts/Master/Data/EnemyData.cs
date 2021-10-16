using Stream;

namespace Master
{
	public class EnemyData
	{
		public int Id { get; private set; }
		public string CharacterName { get; private set; }
		public string PrefabName { get; private set; }
		public int Hp { get; private set; }
		public float SearchRadius { get; private set; }
		public string DefaultAIScriptName { get; private set; }

		public void Serialize(IMemoryStream stream)
		{
			int Id = new int();
			stream.Serialize(ref Id);
			this.Id = Id;
			string CharacterName = "";
			stream.Serialize(ref CharacterName);
			this.CharacterName = CharacterName;
			string PrefabName = "";
			stream.Serialize(ref PrefabName);
			this.PrefabName = PrefabName;
			int Hp = new int();
			stream.Serialize(ref Hp);
			this.Hp = Hp;
			float SearchRadius = new float();
			stream.Serialize(ref SearchRadius);
			this.SearchRadius = SearchRadius;
			string DefaultAIScriptName = "";
			stream.Serialize(ref DefaultAIScriptName);
			this.DefaultAIScriptName = DefaultAIScriptName;
		}

		public static EnemyData[] SerializeAll(byte[] buffer)
		{
			MemoryStreamReader reader = new MemoryStreamReader(buffer);
			int size = 0;
			reader.Serialize(ref size);
			EnemyData[] datas = new EnemyData[size];
			for (int i = 0; i < size; i++)
			{
				EnemyData data = new EnemyData();
				data.Serialize(reader);
				datas[i] = data;
			}
			return datas;
		}
	}
}
