using UnityEngine;
using UnityEngine.UI;

namespace JimsToolbox
{
	public enum NormalizedUVOutputChannel
	{
		UV1,
		UV2,
		UV3,
		COLOR
	}

	public class NormalizedUV : BaseMeshEffect
	{
		public NormalizedUVOutputChannel outputChannel;

		protected NormalizedUV() {}

		public override void ModifyMesh(VertexHelper vh)
		{
			if (!IsActive())
				return;

			if (vh.currentVertCount != 4)
			{
				Debug.LogWarning("Cannot create normalized vertex coords. Please set mesh to \"Full rect\".");
				return;
			}

			UIVertex vert1 = new UIVertex();
			UIVertex vert2 = new UIVertex();
			UIVertex vert3 = new UIVertex();
			UIVertex vert4 = new UIVertex();

			vh.PopulateUIVertex(ref vert1, 0);
			vh.PopulateUIVertex(ref vert2, 1);
			vh.PopulateUIVertex(ref vert3, 2);
			vh.PopulateUIVertex(ref vert4, 3);

			switch (outputChannel)
			{
				case NormalizedUVOutputChannel.UV1:
					vert1.uv1.Set(0, 0);
					vert2.uv1.Set(0, 1);
					vert3.uv1.Set(1, 1);
					vert4.uv1.Set(1, 0);
					break;

				case NormalizedUVOutputChannel.UV2:
					vert1.uv2.Set(0, 0);
					vert2.uv2.Set(0, 1);
					vert3.uv2.Set(1, 1);
					vert4.uv2.Set(1, 0);
					break;

				case NormalizedUVOutputChannel.UV3:
					vert1.uv3.Set(0, 0);
					vert2.uv3.Set(0, 1);
					vert3.uv3.Set(1, 1);
					vert4.uv3.Set(1, 0);
					break;

				case NormalizedUVOutputChannel.COLOR:
					vert1.color = new Color32(0, 0, 0, 255);
					vert2.color = new Color32(0, 255, 0, 255);
					vert3.color = new Color32(255, 255, 0, 255);
					vert4.color = new Color32(255, 0, 0, 255);
					break;
			}


			vh.SetUIVertex(vert1, 0);
			vh.SetUIVertex(vert2, 1);
			vh.SetUIVertex(vert3, 2);
			vh.SetUIVertex(vert4, 3);
		}
	}
}