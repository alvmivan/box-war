﻿using System;
using System.Collections;
using Bones.Scripts.Features.Audio.Core;
using UniRx;
using UnityEngine;

namespace Bones.Scripts.Features.Audio.SFX
{
    public static class ReactiveAudioSource
    {
        public static IObservable<VolumeControl> DoPlay(this VolumeControl control)
        {
            return PlayClip(control)
                .ToObservable()
                .Select(_ => control);
        }

        private static IEnumerator PlayClip(VolumeControl control)
        {
            var clip = control.GetClip();
            yield return new WaitForSeconds(clip.length);
        }
    }
}