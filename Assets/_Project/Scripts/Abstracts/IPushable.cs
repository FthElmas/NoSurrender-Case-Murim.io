using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPushable
{
    void OnCollisionEnter(Collision collision);
}
