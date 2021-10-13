using Stream;

namespace Master
{
	public class SkillData
	{
		public int Id { get; private set; }
		public string MotionName { get; private set; }
		public float MotionSpeed { get; private set; }
		public float PlayTime { get; private set; }
		public float AcceptLinkTime { get; private set; }
		public int LinkSkillId { get; private set; }

		public void Serialize(IMemoryStream stream)
		{
			int Id = new int();
			stream.Serialize(ref Id);
			this.Id = Id;
			string MotionName = "";
			stream.Serialize(ref MotionName);
			this.MotionName = MotionName;
			float MotionSpeed = new float();
			stream.Serialize(ref MotionSpeed);
			this.MotionSpeed = MotionSpeed;
			float PlayTime = new float();
			stream.Serialize(ref PlayTime);
			this.PlayTime = PlayTime;
			float AcceptLinkTime = new float();
			stream.Serialize(ref AcceptLinkTime);
			this.AcceptLinkTime = AcceptLinkTime;
			int LinkSkillId = new int();
			stream.Serialize(ref LinkSkillId);
			this.LinkSkillId = LinkSkillId;
		}

		public static SkillData[] SerializeAll(byte[] buffer)
		{
			MemoryStreamReader reader = new MemoryStreamReader(buffer);
			int size = 0;
			reader.Serialize(ref size);
			SkillData[] datas = new SkillData[size];
			for (int i = 0; i < size; i++)
			{
				SkillData data = new SkillData();
				data.Serialize(reader);
				datas[i] = data;
			}
			return datas;
		}
	}
}
