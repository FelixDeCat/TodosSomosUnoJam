﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonoScripts.Core;
using System;

public abstract class LoadComponent : MonoBehaviour, IStartableGame
{
    public IEnumerator Load() { yield return LoadMe(); }
    protected abstract IEnumerator LoadMe();
    public abstract void OnStartGame();
}
