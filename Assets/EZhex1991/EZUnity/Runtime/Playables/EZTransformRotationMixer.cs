/* Author:          ezhex1991@outlook.com
 * CreateTime:      2019-11-07 11:24:13
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEngine;
using UnityEngine.Playables;

namespace EZhex1991.EZUnity.Playables
{
    public class EZTransformRotationMixer : PlayableBehaviour
    {
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            Transform binding = playerData as Transform;
            if (binding == null) return;

            int inputCount = playable.GetInputCount();
            if (inputCount == 0) return;

            float totalWeight = 0;
            Quaternion outputRotation = new Quaternion();
            for (int i = 0; i < inputCount; i++)
            {
                var inputPlayable = (ScriptPlayable<EZTransformConstraintBehaviour>)playable.GetInput(i);
                var inputBehaviour = inputPlayable.GetBehaviour();
                if (inputBehaviour.target == null) continue;

                float inputWeight = playable.GetInputWeight(i);
                if (inputWeight == 0) continue;

                totalWeight += inputWeight;
                outputRotation = EZUtility.QuaternionCumulate(outputRotation, inputBehaviour.target.rotation.Scale(inputWeight));
            }
            if (totalWeight < 1e-5) return;
            binding.rotation = outputRotation;
        }
    }
}
