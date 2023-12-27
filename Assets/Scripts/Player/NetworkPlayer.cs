using Assets.Scripts;
using Player.UI;
using UnityEngine;

namespace Player
{
    public class NetworkPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject playerCamera, playerModel;
        [SerializeField] private LayerMask hiddenLayer;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private Transform componentsParent;
        PlayerMovement playerMovement;
        PlayerBodyRotation playerBodyRotation;
        PlayerCameraRotation playerCameraRotation;
        PlayerInteractor playerInteractor;
        PlayerLookAtController playerLookAtController;
        PlayerLookAtVisualizer playerLookAtVisualizer;
        PlayerMiniGeneratorCaller miniGeneratorPlacer;
        PlayerOutputsSelector playerOutputsSelector;
        PlayerWireCreator playerWireCreator;
        PlayerWireDisconnector playerWireDisconnector;
        SyncPositions syncBodyAndHead;
        PlayerDvoinikSpawner playerDvoinikSpawner;
        PlayerAnimator playerAnimator;
        PlayerToolChanger playerToolChanger;
        PlayerBuildingPreviewWorker playerBuildingPreviewWorker;
        PlayerUIDvoiniksCount playerUIDvoiniksCount;

        private void Awake()
        {
            playerSettings.playerCamera = Camera.main;
            playerMovement = GetComponentInChildren<PlayerMovement>();
            playerBodyRotation = GetComponentInChildren<PlayerBodyRotation>();
            playerCameraRotation = GetComponentInChildren<PlayerCameraRotation>();
            playerInteractor = GetComponentInChildren<PlayerInteractor>();
            playerLookAtVisualizer = GetComponentInChildren<PlayerLookAtVisualizer>();
            miniGeneratorPlacer = GetComponentInChildren<PlayerMiniGeneratorCaller>();
            playerWireCreator = GetComponentInChildren<PlayerWireCreator>();
            playerWireDisconnector = GetComponentInChildren<PlayerWireDisconnector>();
            syncBodyAndHead = GetComponentInChildren<SyncPositions>();
            playerDvoinikSpawner = GetComponentInChildren<PlayerDvoinikSpawner>();

            playerOutputsSelector = CreateComponent<PlayerOutputsSelector>(nameof(PlayerOutputsSelector));
            playerLookAtController = CreateComponent<PlayerLookAtController>(nameof(PlayerLookAtController));
            playerAnimator = CreateComponent<PlayerAnimator>(nameof(PlayerAnimator));
            playerToolChanger = CreateComponent<PlayerToolChanger>(nameof(PlayerToolChanger));
            playerBuildingPreviewWorker = CreateComponent<PlayerBuildingPreviewWorker>(nameof(PlayerBuildingPreviewWorker));
            playerUIDvoiniksCount = CreateComponent<PlayerUIDvoiniksCount>(nameof(PlayerUIDvoiniksCount));

            var playerComponents = GetComponentsInChildren<PlayerComponent>();
            foreach (var component in playerComponents)
            {
                component.Construct(playerSettings, playerStats);
            }

            var rootReaders = GetComponentsInChildren<IRootReader>();
            foreach (var reader in rootReaders)
            {
                reader.ReadRoot(gameObject);
            }
        }

        private T CreateComponent<T>(string name) where T : PlayerComponent
        {
            var componentGo = Instantiate(new GameObject(name), componentsParent);
            var component = componentGo.AddComponent<T>();
            component.Construct(playerSettings, playerStats);
            return component;
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //  playerModel.layer = hiddenLayer;
            //playerModel.SetActive(isOwned);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            playerInteractor.Interact();
            playerMovement.Move();
            playerCameraRotation.RotateCamera();

            miniGeneratorPlacer.TryToCall();

            playerOutputsSelector.Select();

            playerToolChanger.TryToChangeTool();
            playerBuildingPreviewWorker.DrawPreview();
            playerDvoinikSpawner.TryToSpawn();
            playerUIDvoiniksCount.UpdateText();

            playerWireCreator.HandleWireCreation();
            playerWireDisconnector.DisconnectWire();
        }

        private void LateUpdate()
        {
            playerAnimator.Animate();
            playerBodyRotation.Rotate();
            syncBodyAndHead.Sync();
        }

        private void FixedUpdate()
        {
            playerLookAtController.UpdateLook();
            playerLookAtVisualizer.Visualize();
        }
    }
}