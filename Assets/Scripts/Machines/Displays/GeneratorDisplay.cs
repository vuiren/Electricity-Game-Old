using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Generator))]
    public class GeneratorDisplay : MonoBehaviour
    {
        Generator generator;
        [SerializeField] TextMeshPro displayText;
        // Use this for initialization
        void Start()
        {
            generator = GetComponent<Generator>();
            displayText.color = Color.yellow;
        }

        // Update is called once per frame
        void Update()
        {
            displayText.text = generator.generatedEnergy.ToString();
        }
    }
}