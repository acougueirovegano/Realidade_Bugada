using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void IniciarJogo()
    {
        // Garante que vai carregar a cena exata do jogo
        SceneManager.LoadScene("SampleScene"); 
    }
}