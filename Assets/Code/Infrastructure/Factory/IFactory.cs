using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IFactory
    {
        GameObject Create(Transform container = null);
    }
}