using System.Collections;
using System.Collections.Generic;
using Unity.Multiplayer.Center.Common;
using UnityEngine;

namespace CommandPattern
{
    public class Player : MonoBehaviour
    {
        private Stack<ICommand> undoStack = null;
        private Stack<ICommand> redoStack = null;

        private void Awake()
        {
            undoStack = new Stack<ICommand>();
            redoStack = new Stack<ICommand>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
                ExecuteMove(new Vector3(0, 0, 1));
            if (Input.GetKeyDown(KeyCode.A))
                ExecuteMove(new Vector3(-1, 0, 0));
            if (Input.GetKeyDown(KeyCode.S))
                ExecuteMove(new Vector3(0, 0, -1));
            if (Input.GetKeyDown(KeyCode.D))
                ExecuteMove(new Vector3(1, 0, 0));

            if (Input.GetKeyDown(KeyCode.Z))
                UndoMove();
            if (Input.GetKeyDown(KeyCode.X))
                RedoMove();

        }

        public void ExecuteMove(Vector3 _direction)
        {
            if (redoStack.Count >= 0)
                redoStack.Clear();

            MoveCommand command = new MoveCommand(this, _direction);
            command.Execute();
            undoStack.Push(command);
        }

        public void RedoMove()
        {
            if (redoStack.Count <= 0)
                return;

            ICommand redoCommand = redoStack.Pop();
            redoCommand.Execute();
            undoStack.Push(redoCommand);
        }

        public void UndoMove()
        {
            if (undoStack.Count <= 0)
                return;

            ICommand undoCommand = undoStack.Pop();
            undoCommand.Undo();
            redoStack.Push(undoCommand);
        }

        public void Move(Vector3 _direction)
        {
            transform.position += _direction;
        }
    }
}
