using UnityEngine;

namespace CommandPattern
{
    public class MoveCommand : ICommand
    {
        private Player player = null;
        private Vector3 direction = default;

        public MoveCommand(Player _player, Vector3 _direction)
        {
            player = _player;
            direction = _direction;
        }

        public void Execute()
        {
            player.Move(direction);
        }

        public void Undo()
        {
            player.Move(-direction);
        }
    }
}