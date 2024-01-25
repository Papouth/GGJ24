using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AIBehavior : MonoBehaviour
{
    
    #region Variables

    [Header("AI parameters")]
    [SerializeField] private float timeMin;
    [SerializeField] private float timeMax;

    // Map variables.
    private Bounds _mapMeshBounds;  // Automatic way.
    private NavMeshAgent _navMeshAgent;

    #endregion

    #region Built-In Methods

    /**
     * <summary>
     * Start is called before the first frame update.
     * </summary>
     */
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();   // Navmesh Agent Component.
        _mapMeshBounds = GameObject.Find("Banquise").GetComponent<NavMeshSurface>().navMeshData.sourceBounds;  // Map bounds.
        
        StartCoroutine(RandomPos(CalculatePosition()));
    }

    #endregion

    #region AI Behavior Methods

    /**
     * <summary>
     * Go to a random position on the navmesh map.
     * </summary>
     * <param name="position">A random position.</param>
     */
    private IEnumerator RandomPos(Vector3 position)
    {
        _navMeshAgent.SetDestination(position);

        yield return new WaitForSeconds(Random.Range(timeMin, timeMax));    // Random Time between each action.
        StartCoroutine(RandomPos(CalculatePosition()));
    }


    /**
     * <summary>
     * Calculate a random position on the map bounds.
     * </summary>
     */
    private Vector3 CalculatePosition()
    {
        float posX = Random.Range(_mapMeshBounds.min.x, _mapMeshBounds.max.x);  // Rand x.
        float posZ = Random.Range(_mapMeshBounds.min.z, _mapMeshBounds.max.z);  // Rand z.

        return new Vector3(posX, transform.position.y, posZ);
    }

    #endregion
    
}
