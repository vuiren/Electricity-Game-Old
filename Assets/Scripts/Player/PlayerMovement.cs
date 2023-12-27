using UnityEngine;

namespace Player
{
    public class PlayerMovement : PlayerComponent
    {
        // Update is called once per frame
        public void Move()
        {
            var horizontal = Input.GetAxis("Horizontal") * PlayerSettings.characterController.transform.right;
            var vertical = Input.GetAxis("Vertical") * PlayerSettings.characterController.transform.forward;
            var moveDirection = horizontal + vertical;
            PlayerStats.moving = moveDirection.magnitude > 0.2f;

            if (!PlayerSettings.characterController.isGrounded && !PlayerStats.elevatorPlayerIn)
            {
                moveDirection.y = -PlayerSettings.gravity;
            }

            var finalVector = PlayerSettings.moveSpeed * moveDirection.normalized * Time.deltaTime;
            if (PlayerStats.elevatorPlayerIn)
            {
                finalVector *= 0.4f;
            }
            if (PlayerStats.elevatorPlayerIn && PlayerStats.elevatorPlayerIn.moving)
            {
               // print("da");
                finalVector.y = PlayerStats.elevatorPlayerIn.moveVector.y;
            }
            PlayerStats.moveVector = finalVector;
            PlayerSettings.characterController.Move(finalVector);
        }
    }
}