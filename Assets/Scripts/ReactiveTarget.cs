using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

    public void ReactToHit()
    {
        StartCoroutine(Die());
    }


    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);

    }
}
