using Configs;

namespace Interface
{
    public interface IAnimatable<T> : IUpdatable
    {
        void StartAnimation(T spriteRenderer, AnimState animState, bool loop, float speed);
        void StopAnimation(T sprite);
    }
}