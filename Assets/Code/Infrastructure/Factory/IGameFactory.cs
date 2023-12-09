using Code.Logic;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IGameFactory
    {
        GameObject CreateHero(Transform at);
        GameObject CreateHud(IHealth heroHealth);
    }
}